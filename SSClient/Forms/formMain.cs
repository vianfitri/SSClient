using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Machines;
using SSClient.Class;

namespace SSClient.Forms
{
    public partial class formMain : Form
    {
        #region "Fields"

        private Form activeForm = null;
        private String loginUsername = "";
        private int loginId = -1;
        private DB mysqlDbConn;
        public formLogin fLogin = null;
        public formDashboard fDash = null;

        #endregion

        #region "Constructor"
        public formMain()
        {
            InitializeComponent();
            fLogin = new formLogin(this);
            fDash = new formDashboard(this);
        }
        #endregion

        #region Properties
        public string LoginUsername {
            get { return loginUsername; }
            set { loginUsername = value; }
        }

        public int LoginId {
            get { return loginId; }
            set { loginId = value; }
        }

        public DB DBConn
        {
            get { return mysqlDbConn; }
            set { mysqlDbConn = value; }
        }
        #endregion

        #region Method

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                //activeForm.Dispose();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Clear();
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            // Get Screen Working Resolution
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            Console.WriteLine(string.Format("Screen Working Area : {0}x{1}", screenWidth, screenHeight));

            // Initialize Visual Server
            VisualServer.visualconn.StartServer();

            if (loginId == -1)
            {
                openChildForm(fLogin);
            }
        }

        private void formMain_Shown(object sender, EventArgs e)
        {

        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion


    }
}
