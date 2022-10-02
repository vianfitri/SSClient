using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSClient.Forms
{
    public partial class fDbConfig : Form
    {
        #region "Fields"
        public string DbServer
        {
            get { return txtDbHost.Texts.ToLower(); }
            set { txtDbHost.Texts = value.ToLower(); }
        }

        public string DbPort
        {
            get { return txtDbPort.Texts.ToLower(); }
            set { txtDbPort.Texts = value.ToLower(); }
        }

        public string DbUsername
        {
            get { return txtDbUser.Texts; }
            set { txtDbUser.Texts = value; }
        }

        public string DbPassword
        {
            get { return txtDbPass.Texts; }
            set { txtDbPass.Texts = value; }
        }
        #endregion

        #region "Constructor"
        public fDbConfig()
        {
            InitializeComponent();
        }
        #endregion

        #region "Events"
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDbHost.Texts))
            {
                MessageBox.Show("Server / Host IP must be not empty!", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDbHost.Select();
                txtDbHost.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDbPort.Texts))
            {
                MessageBox.Show("Port No.must be not empty!", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDbPort.Select();
                txtDbPort.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDbUser.Texts))
            {
                MessageBox.Show("User must be not empty!", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDbUser.Select();
                txtDbUser.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
        #endregion


    }
}
