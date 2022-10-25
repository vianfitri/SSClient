using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSClient.Forms;
using SSClient.Class;

namespace SSClient
{
    public partial class formDashboard : Form
    {
        #region "Fields"
        formMain _parent;
        private Form activeForm = null;
        private DB mysqlDbConn;
        #endregion

        #region "Constructor"
        public formDashboard(formMain parent)
        {
            InitializeComponent();
            customizeDesign();
            this._parent = parent;
        }
        #endregion

        #region "Methods"
        private void customizeDesign()
        {
        }

        private void hideSubmenu()
        {
            // Killl Another Application If Exist
            Process[] procs = Process.GetProcessesByName("ShipStability");
            foreach(Process proc in procs)
            {
                proc.Kill();
            }
        }

        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void loadLoginInfo(int logId)
        {
            DataTable dtLoginInfo = new DataTable();
            string qrStr = "SELECT a.idss_user, " +
                "b.first_name, b.last_name, b.birthday, b.sex, b.email, b.photos, " +
                "c.typename " +
                "FROM shp_assets.ss_user a " +
                "INNER JOIN shp_assets.ss_subject b " +
                "ON a.id_subject = b.idsubject " +
                "INNER JOIN shp_assets.ss_usertype c " +
                "ON b.type = c.id " +
                "WHERE a.idss_user = " + logId + " LIMIT 0, 1";

            if(mysqlDbConn.GetTableData(qrStr, ref dtLoginInfo))
            {
                lblUsername.Text = dtLoginInfo.Rows[0]["first_name"].ToString();
                lblPriviledge.Text = dtLoginInfo.Rows[0]["typename"].ToString();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Load Setting Page
            openChildForm(new fSetting());

            hideSubmenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this._parent.LoginId = -1;
                this._parent.openChildForm(this._parent.fLogin);
                openChildForm(new formWelcome());
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            // Load default content
            openChildForm(new formWelcome());

            // set mysql data connector
            mysqlDbConn = this._parent.DBConn;

            // fetch login user information
            int currentLogId = this._parent.LoginId;

            // Load Scenario and Duplicate DB Scen
            ScenLoad();

            loadLoginInfo(currentLogId);

            hideSubmenu();
        }

        private void btnStability_Click(object sender, EventArgs e)
        {
            // Load Instructor Data
            openChildForm(new fSSS());

            hideSubmenu();
        }

        private void hiddenPannel_Click(object sender, EventArgs e)
        {
            // Load Instructor Data
            //openChildForm(new fSSS());

            //hideSubmenu();
        }

        private void ScenLoad()
        {
            // Get Active Scenario
            int activeScenNum = 0;

            string qActScen = "SELECT * FROM `shp_assets`.`ss_scenario` WHERE is_active = 1";

            if (mysqlDbConn.GetTotalRow(qActScen, ref activeScenNum))
            {
                if (activeScenNum > 0)
                {
                    // get data from active scenario
                    DataTable dActScen = new DataTable();
                    if (mysqlDbConn.GetTableData(qActScen, ref dActScen))
                    {
                        int ScenPractNum = 0;
                        // get data scenario practicum for student. if null created
                        string qScenPra = "SELECT * FROM `shp_assets`.`ss_scenario_practicum` " +
                            "WHERE id_scenario = " + dActScen.Rows[0]["id"] + " " +
                            "AND id_student = " + this._parent.LoginId;

                        if (mysqlDbConn.GetTotalRow(qScenPra, ref ScenPractNum))
                        {
                            if (ScenPractNum > 0)
                            {
                                // get database name for student practicum
                                DataTable dScenPra = new DataTable();
                                if(mysqlDbConn.GetTableData(qScenPra, ref dScenPra))
                                {
                                    ParamsGlobal.test_db_name = dScenPra.Rows[0]["db_name"].ToString();
                                }
                            }
                            else
                            {
                                // duplicate database
                                string fromDB = dActScen.Rows[0]["db_name"].ToString();
                                string toDB = dActScen.Rows[0]["db_name"].ToString() + "_" + this._parent.LoginId;

                                if(mysqlDbConn.DuplicateDB(fromDB, toDB))
                                {
                                    // insert data to Scenario Practicum table
                                    string qInScenPra = "INSERT INTO `shp_assets`.`ss_scenario_practicum`(" +
                                        "`id_scenario`,`db_name`,`id_student`) VALUES (" + dActScen.Rows[0]["id"] + "," +
                                        "'" + toDB + "', " + this._parent.LoginId + ")";

                                    if (mysqlDbConn.SetCommand(qInScenPra))
                                    {
                                        ParamsGlobal.test_db_name = toDB;
                                    }
                                }
                            }
                        }

                    }
                } 
                else
                {
                    Console.WriteLine("No Active Scenario");
                }
            }
        }
        #endregion
    }
}
