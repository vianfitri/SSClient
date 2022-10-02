using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Machines;
using SSClient.Class;

namespace SSClient.Forms
{
    public partial class ClientProperties : Form
    {
        #region "Fields"
        private string _previousHostname;
        #endregion

        #region "Constructor"
        public ClientProperties()
        {
            InitializeComponent();
        }
        #endregion

        #region "Method"
        private void btnOK_Click(object sender, EventArgs e)
        {
            Machine m = new Machine();

            try
            {
                MachineModule.Machines.Remove(_previousHostname);

                m.Name = txtMachineName.Text;
                m.MAC = txtMacAddress.Text;
                m.IP = txtIPAddress.Text;
                m.Netbios = "";

                MachineModule.Machines.Add(m);
                MachineModule.Machines.Save();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtMachineName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = IsTextNotEmpty();
        }

        private void txtMacAddress_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = IsTextNotEmpty();
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = IsTextNotEmpty();
        }

        private void ClientProperties_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = IsTextNotEmpty();
        }

        public void Create()
        {
            try
            {
                _previousHostname = string.Empty;
                Text = string.Format("Properties - {0}", "New");
                txtMachineName.Text = string.Empty;
                txtMacAddress.Text = string.Empty;
                txtIPAddress.Text = string.Empty;

                ShowDialog();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.InnerException.ToString());
            }
        }

        public void Edit(string hostname)
        {
            Machine m;

            m = MachineModule.Machines[hostname];
             _previousHostname = hostname;
            Text = string.Format("Properties - {0}", hostname);
            txtMachineName.Text = m.Name;
            txtMacAddress.Text = m.MAC;
            txtIPAddress.Text = m.IP;

            ShowDialog();
        }

        private bool IsTextNotEmpty()
        {
            return txtMachineName.Text != string.Empty && txtIPAddress.Text != string.Empty && txtMacAddress.Text != string.Empty;
        }
        #endregion

        
    }
}
