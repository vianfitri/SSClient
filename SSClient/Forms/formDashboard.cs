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

        System.Timers.Timer t;
        int h, m, s;
        private float timeElapsed = 0; // in minute
        private float timeStandard = 0; // in minute
        #endregion

        #region "Constructor"
        public formDashboard(formMain parent)
        {
            InitializeComponent();
            customizeDesign();
            this._parent = parent;
            t = new System.Timers.Timer();
        }
        #endregion

        #region "Properties"
        public float TimeElapsed
        {
            get { return timeElapsed; }
            set { timeElapsed = value; }
        }

        public float TimeStandard
        {
            get { return timeStandard; }
            set { timeStandard = value; }
        }
        #endregion

        #region "Methods"
        private void LoadExercise()
        {
            string qExerc = "SELECT * FROM `shp_assets`.`ss_exercise` WHERE uc = '111-11111-11'";
            int exerciseMode = 0;

            if (ConnectorDB.MySQLConn.GetData(qExerc, "mode", ref exerciseMode))
            {
                if (exerciseMode == 0)
                {
                    ExerciseController.EMode = ExerciseController.ExerciseMode.Training;
                }
                else if (exerciseMode == 1)
                {
                    ExerciseController.EMode = ExerciseController.ExerciseMode.Test;
                }
            }
        }

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

        private void loadLoginInfo(string logId)
        {
            DataTable dtLoginInfo = new DataTable();
            string qrStr = "SELECT a.uc, " +
                "b.first_name, b.last_name, b.birthday, b.sex, b.email, b.photos, " +
                "c.typename " +
                "FROM shp_assets.ss_user a " +
                "INNER JOIN shp_assets.ss_subject b " +
                "ON a.uc_subject = b.uc " +
                "INNER JOIN shp_assets.ss_usertype c " +
                "ON b.type = c.id " +
                "WHERE a.uc = '" + logId + "' LIMIT 0, 1";

            if (ConnectorDB.MySQLConn.GetTableData(qrStr, ref dtLoginInfo))
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
                UserController.isLogin = false;
                UserController.currentUcUser = "";
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

            // Load Exercise mode
            LoadExercise();

            if(ExerciseController.EMode == ExerciseController.ExerciseMode.Test)
            {
                btnStability.Visible = false;
               
                // Load Scenario and Duplicate DB Scen
                ScenLoad();

                // Init Time For Test
                InitTimeTest();

                pnlTimerTest.Visible = true;
            }
            else
            {
                btnStability.Visible = true;
                pnlTimerTest.Visible = false;
            }

            loadLoginInfo(UserController.currentUcUser);

            hideSubmenu();
        }

        private void btnStability_Click(object sender, EventArgs e)
        {
            // Load Instructor Data
            openChildForm(new fSSS(this));

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

            if (ConnectorDB.MySQLConn.GetTotalRow(qActScen, ref activeScenNum))
            {
                if (activeScenNum > 0)
                {
                    // get data from active scenario
                    DataTable dActScen = new DataTable();
                    if (ConnectorDB.MySQLConn.GetTableData(qActScen, ref dActScen))
                    {
                        int ScenPractNum = 0;
                        // get data scenario practicum for student. if null created
                        string qScenPra = "SELECT * FROM `shp_assets`.`ss_scenario_practicum` " +
                            "WHERE uc_scenario = '" + dActScen.Rows[0]["uc"] + "' " +
                            "AND uc_student = '" + UserController.currentUcUser + "'";

                        if (ConnectorDB.MySQLConn.GetTotalRow(qScenPra, ref ScenPractNum))
                        {
                            if (ScenPractNum > 0)
                            {
                                // get database name for student practicum
                                DataTable dScenPra = new DataTable();
                                if(ConnectorDB.MySQLConn.GetTableData(qScenPra, ref dScenPra))
                                {
                                    ExerciseController.CurrentDBName = dScenPra.Rows[0]["db_name"].ToString();
                                    btnStability_Click(null,null);
                                }
                            }
                            else
                            {
                                // duplicate database
                                string fromDB = dActScen.Rows[0]["db_name"].ToString();
                                string toDB = dActScen.Rows[0]["db_name"].ToString() + "_" + UserController.currentUcUser;

                                if(ConnectorDB.MySQLConn.DuplicateDB(fromDB, toDB))
                                {
                                    // insert data to Scenario Practicum table
                                    string qInScenPra = "INSERT INTO `shp_assets`.`ss_scenario_practicum` " +
                                        "(" +
                                        "`uc`, " +
                                        "`uc_scenario`," +
                                        "`db_name`," +
                                        "`uc_student`" +
                                        ") VALUES (" +
                                        "'" + UserController.currentUcUser + "'," +
                                        "'" + dActScen.Rows[0]["uc"] + "'," +
                                        "'" + toDB + "'," + 
                                        "'" + UserController.currentUcUser + "'" + 
                                        ")";

                                    if (ConnectorDB.MySQLConn.SetCommand(qInScenPra))
                                    {
                                        ExerciseController.CurrentDBName = toDB;
                                        btnStability_Click(null, null);
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

        private void InitTimeTest()
        {
            t.Interval = 1000; // 1s
            t.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                txtTimeE.Text = string.Format("{0}:{1}:{2}",
                    h.ToString().PadLeft(2, '0'),
                    m.ToString().PadLeft(2, '0'),
                    s.ToString().PadLeft(2, '0')
                    );

                timeElapsed = (h * 60) + m + (s / 60);
            }));
        }

        public void StartTest()
        {
            int timeStdHour = (int)(timeStandard / 60);
            int timeStdMinute = (int)(timeStandard - (timeStdHour * 60));
            txtStdTime.Text = string.Format("{0}:{1}:{2}",
                timeStdHour.ToString().PadLeft(2, '0'),
                timeStdMinute.ToString().PadLeft(2, '0'),
                "00");
            t.Start();
        }

        public void StopTest()
        {
            t.Stop();

            // Reset h, m, s
            h = 0;
            m = 0;
            s = 0;
            txtTimeE.Text = "00:00:00";
            txtStdTime.Text = "00:00:00";
        }

        private void formDashboard_VisibleChanged(object sender, EventArgs e)
        {
            if (UserController.isLogin)
            {
                loadLoginInfo(UserController.currentUcUser);
            }
        }
        #endregion
    }
}
