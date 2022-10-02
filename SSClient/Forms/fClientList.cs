using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Machines;
using SSClient.Class;
using SSClient.Controls;

namespace SSClient.Forms
{
    public partial class fClientList : Form
    {
        #region "Fields"
        public static Semaphore Pool = new Semaphore(0, 10);
        #endregion

        #region "Constructor"
        public fClientList()
        {
            InitializeComponent();
        }
        #endregion

        #region "Method"
        public void StatusChange(string hostname, Machine.StatusCodes status, string IPAddress)
        {
            Console.WriteLine("Hostname : " + hostname + " => Status : " + status + " => IP Address : " + IPAddress);

            foreach(ClientPanel clientObj in flowLayoutPanel1.Controls)
            {
                if(clientObj.PcName == hostname)
                {
                    if (status == Machine.StatusCodes.Online)
                    {
                        clientObj.PowerState = true;
                    }
                    else
                        clientObj.PowerState = false;
                    return;
                }
            }
        }
        
        private void SaveChanges()
        {
            //MachineModule.Machines.Save();
            //MachineModule.Machines.Close();
        }

        private void fClientList_Load(object sender, EventArgs e)
        {
            // populate client list and create control
            if (MachineModule.Machines.Count > 0)
            {
                RegisterHandle();

                PopulateClient();

                flowLayoutPanel1.Invalidate();
            }
        }

        private void fClientList_Shown(object sender, EventArgs e)
        {
            //Pool.Release(10);
        }
        
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            // Unregister Client Handle
            UnregisterHandle();

            ClientProperties cp = new ClientProperties();
            cp.Create();

            if (cp.DialogResult == DialogResult.OK)
            {
                // Clear flowLayoutPanel Child Control
                flowLayoutPanel1.Controls.Clear();

                // Register Client Handle
                RegisterHandle();

                // Populate Client List
                PopulateClient();

                flowLayoutPanel1.Invalidate();

                cp.Dispose();

                return;
            }

            RegisterHandle();
        }

        private void fClientList_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unload Event Handler for Machine
            UnregisterHandle();

            flowLayoutPanel1.Controls.Clear();
        }

        private void UnregisterHandle()
        {
            foreach(Machine machine in MachineModule.Machines)
            {
                machine.StatusChange -= StatusChange;
            }
        }

        private void RegisterHandle()
        {
            foreach(Machine machine in MachineModule.Machines)
            {
                machine.StatusChange += StatusChange;
            }
        }

        private void PopulateClient()
        {
            foreach (Machine machine in MachineModule.Machines)
            {
                ClientPanel clientObj = new ClientPanel();

                clientObj.IpAddress = machine.IP;
                clientObj.MacAddress = machine.MAC;
                clientObj.PcName = machine.Name;
                clientObj.Margin = new Padding(40, 40, 40, 40);
                clientObj.BorderStyle = BorderStyle.FixedSingle;
                clientObj.ContextMenuStrip = contextMenuStrip_Machines;

                if (machine.Status == Machine.StatusCodes.Online)
                    clientObj.PowerState = true;

                flowLayoutPanel1.Controls.Add(clientObj);
            }
        }

        private void btnWakeUpAll_Click(object sender, EventArgs e)
        {
            foreach(ClientPanel cp in flowLayoutPanel1.Controls)
            {
                Networking.Wake(cp.MacAddress);
                Application.DoEvents();
                Thread.Sleep(750);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get Client Panel
            ClientPanel cpn = GetClient(sender);

            if(MessageBox.Show("Are You Sure?", "Delete Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Machine m = MachineModule.Machines[cpn.PcName];
                m.StatusChange -= StatusChange;
                MachineModule.Machines.Remove(cpn.PcName);
                flowLayoutPanel1.Controls.Remove(cpn);
                MachineModule.Machines.Save();
                flowLayoutPanel1.Invalidate();
            }
        }

        private void wakeUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get Client Panel
            ClientPanel cpn = GetClient(sender);

            Networking.Wake(cpn.MacAddress);
        }

        private void newHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Unregister Client Handle
            UnregisterHandle();

            ClientProperties cp = new ClientProperties();
            cp.Create();

            if (cp.DialogResult == DialogResult.OK)
            {
                // Clear flowLayoutPanel Child Control
                flowLayoutPanel1.Controls.Clear();

                // Register Client Handle
                RegisterHandle();

                // Populate Client List
                PopulateClient();

                flowLayoutPanel1.Invalidate();

                cp.Dispose();

                return;
            }

            RegisterHandle();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get Client Panel
            ClientPanel cpn = GetClient(sender);

            // Unregister Client Handle
            UnregisterHandle();

            ClientProperties cp = new ClientProperties();
            cp.Edit(cpn.PcName);

            if (cp.DialogResult == DialogResult.OK)
            {
                // Clear flowLayoutPanel Child Control
                flowLayoutPanel1.Controls.Clear();

                // Register Client Handle
                RegisterHandle();

                // Populate Client List
                PopulateClient();

                flowLayoutPanel1.Invalidate();

                cp.Dispose();

                return;
            }

            RegisterHandle();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get Client Panel
            ClientPanel cpn = GetClient(sender);

            ShutdownServer.ShutdownClient(cpn.PcName);
        }

        private void btnShutdownAll_Click(object sender, EventArgs e)
        {
            ShutdownServer.ShutdownAll();
        }

        private ClientPanel GetClient(object sender)
        {
            // Try to cast the sender to a ToolStripItem
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;
                    return (ClientPanel)sourceControl;
                }
            }
            return null;
        }



        #endregion
    }
}
