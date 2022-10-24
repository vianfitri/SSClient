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
        private DB mysqlDBConn;
        private ReadWriteFile appConf;

        private string[] dataString = new string[4];
        private string[] identifiedString = { "[MySQL]", "Server=", "Port=", "Uid=", "Pwd="};
        private string dbServer, dbPort, dbUid, dbPwd;

        private string configDir =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ShipStab";
        #endregion

        #region "Constructor"
        public formLogin(formMain parent)
        {
            InitializeComponent();

            // init
            mysqlDBConn = new DB();
            appConf = new ReadWriteFile();

            this._parent = parent;
        }
        #endregion

        #region "Methods"
        private bool LoadConfig()
        {
            bool stat = appConf.LoadConfig(configDir, "db.ini", identifiedString, ref dataString);

            if (stat)
            {
                dbServer = dataString[0];
                dbPort = dataString[1];
                dbUid = dataString[2];
                dbPwd = dataString[3];
            }

            return stat;
        }

        private bool SaveConfig()
        {
            bool stat = appConf.SaveConfig(configDir, "db.ini", identifiedString, ref dataString);

            if (!stat)
                MessageBox.Show(appConf.ErrorMessage, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return stat;
        }
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

            this.Cursor = Cursors.WaitCursor;

            // Check MySQL State
            if (!mysqlDBConn.GetDBStatus())
            {
                btnConfig.Enabled = true;
                btnConfig.Visible = true;

                this.Cursor = Cursors.Default;

                MessageBox.Show(mysqlDBConn.ErrorMessage +
                    "\r\nPlease check whether database server is active? Or set up new configuration for database server!",
                    "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            // Get Login Pass
            int num = 0;

            string queryString = "SELECT * FROM shp_assets.ss_user a " +
                "WHERE a.u_name = '" + txtUsername.Texts +
                "' AND a.u_pass = MD5('" + txtPassword.Texts +
                "') LIMIT 0, 1";

            if(mysqlDBConn.GetTotalRow(queryString, ref num))
            {
                if(num == 1)
                {
                    MessageBox.Show("Login Success");

                    // fetch login id
                    int logId = -1;
                    string uName = "";
                    string uPass = "";
                    mysqlDBConn.GetData(queryString, "id_subject", ref logId);
                    mysqlDBConn.GetData(queryString, "u_name", ref uName);
                    mysqlDBConn.GetData(queryString, "u_pass", ref uPass);
                    //MessageBox.Show("LoginID :" + logId.ToString() + 
                    //    "\r\nUsername : " + uName +
                    //    "\r\nPassword : " + uPass);
                    this._parent.DBConn = mysqlDBConn;
                    this._parent.LoginId = logId;
                    
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
                MessageBox.Show(mysqlDBConn.ErrorMessage, "Info...",
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
                fConfigDb.DbServer = dbServer;
                fConfigDb.DbPort = dbPort;
                fConfigDb.DbUsername = dbUid;
                fConfigDb.DbPassword = dbPwd;

                if(fConfigDb.ShowDialog() == DialogResult.OK)
                {
                    dbServer = fConfigDb.DbServer;
                    dbPort = fConfigDb.DbPort;
                    dbUid = fConfigDb.DbUsername;
                    dbPwd = fConfigDb.DbPassword;

                    dataString[0] = dbServer;
                    dataString[1] = dbPort;
                    dataString[2] = dbUid;
                    dataString[3] = dbPwd;

                    if(!SaveConfig())
                    {
                        MessageBox.Show(appConf.ErrorMessage, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    SetMySqlConfig();
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
            if(!LoadConfig())
            {
                SetDefaultConfig();

                btnConfig.Enabled = true;
                btnConfig.Visible = true;

                MessageBox.Show("Cannot load current configuration!\r\nPlease set up configuration.", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Activate();
                return;
            }

            // Set configuration for MySql
            SetMySqlConfig();
        }

        private void SetMySqlConfig()
        {
            mysqlDBConn.DbHost = dbServer;
            mysqlDBConn.DbPort = dbPort;
            mysqlDBConn.DbUser = dbUid;
            mysqlDBConn.DbPassword = dbPwd;
        }

        private void SetDefaultConfig()
        {
            dbServer = "localhost";
            dbPort = "3306";
            dbUid = "root";
            dbPwd = "admin123!";
        }
        #endregion

    }
}
