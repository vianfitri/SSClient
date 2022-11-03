using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSClient.Forms;
using SSClient.Class;

namespace SSClient
{
    public partial class formLogin : Form
    {
        #region "Fields"
        formMain _parent;
        #endregion

        #region "Constructor"
        public formLogin(formMain parent)
        {
            InitializeComponent();

            this._parent = parent;
        }
        #endregion

        #region "Methods"
        #endregion

        #region "Events"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Proccess Authenticate
            if(string.IsNullOrEmpty(txtUsername.Texts))
            {
                MessageBox.Show("Please insert 'USERNAME'!", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsername.Select();
                txtUsername.Focus();
                return;
            }

            if(string.IsNullOrEmpty(txtPassword.Texts))
            {
                MessageBox.Show("Please Insert 'PASSWORD'!", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                txtPassword.Focus();
                return;
            }

            //this.Cursor = Cursors.WaitCursor;

            // Check MySQL State
            if (!ConnectorDB.MySQLConn.GetDBStatus())
            {
                btnConfig.Enabled = true;
                btnConfig.Visible = true;

                this.Cursor = Cursors.Default;

                MessageBox.Show(ConnectorDB.MySQLConn.ErrorMessage +
                    "\r\nPlease check whether database server is active? Or set up new configuration for database server!",
                    "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            // Get Login Pass
            int num = 0;

            string queryString = "SELECT * FROM shp_assets.ss_user a " +
                "INNER JOIN shp_assets.ss_subject b " +
                "ON a.uc_subject = b.uc " +
                "WHERE a.u_name = '" + txtUsername.Texts + "' " +
                "AND a.u_pass = MD5('" + txtPassword.Texts + "') " +
                "AND b.type = 3 LIMIT 0, 1";

            if (ConnectorDB.MySQLConn.GetTotalRow(queryString, ref num))
            {
                if(num == 1)
                {
                    // fetch login id
                    string logId = "";
                    string uName = "";
                    string uPass = "";
                    ConnectorDB.MySQLConn.GetData(queryString, "uc_subject", ref logId);
                    ConnectorDB.MySQLConn.GetData(queryString, "u_name", ref uName);
                    ConnectorDB.MySQLConn.GetData(queryString, "u_pass", ref uPass);
                    //MessageBox.Show("LoginID :" + logId.ToString() + 
                    //    "\r\nUsername : " + uName +
                    //    "\r\nPassword : " + uPass);
                    UserController.isLogin = true;
                    UserController.currentUcUser = logId;

                    txtUsername.Texts = "";
                    txtPassword.Texts = "";

                } 
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Please check your username/password!", "Login failed...",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsername.Select();
                    txtUsername.Focus();

                    return;
                }
            } 
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ConnectorDB.MySQLConn.ErrorMessage, "Info...",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            // Goto Main Form if success
            this._parent.openChildForm(this._parent.fDash);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            using(fDbConfig fConfigDb = new fDbConfig())
            {
                fConfigDb.DbServer = ConnectorDB.dbServer;
                fConfigDb.DbPort = ConnectorDB.dbPort;
                fConfigDb.DbUsername = ConnectorDB.dbUid;
                fConfigDb.DbPassword = ConnectorDB.dbPwd;

                if(fConfigDb.ShowDialog() == DialogResult.OK)
                {
                    ConnectorDB.dbServer = fConfigDb.DbServer;
                    ConnectorDB.dbPort = fConfigDb.DbPort;
                    ConnectorDB.dbUid = fConfigDb.DbUsername;
                    ConnectorDB.dbPwd = fConfigDb.DbPassword;

                    ConnectorDB.dataString[0] = ConnectorDB.dbServer;
                    ConnectorDB.dataString[1] = ConnectorDB.dbPort;
                    ConnectorDB.dataString[2] = ConnectorDB.dbUid;
                    ConnectorDB.dataString[3] = ConnectorDB.dbPwd;

                    if(!ConnectorDB.SaveConfig())
                    {
                        MessageBox.Show(ConnectorDB.appConf.ErrorMessage, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ConnectorDB.SetConfig();
                }
            }
        }

        private void txtPassword__TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Texts))
            {
                txtPassword.PasswordChar = false;
            } else { txtPassword.PasswordChar = true; }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            // Load D Configuration
            if(!ConnectorDB.LoadConfig())
            {
                ConnectorDB.SetDefault();

                btnConfig.Enabled = true;
                btnConfig.Visible = true;

                MessageBox.Show("Cannot load current configuration!\r\nPlease set up configuration.", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Activate();
                return;
            }

            // Set configuration for MySql
            ConnectorDB.SetConfig();
        }

        #endregion

    }
}
