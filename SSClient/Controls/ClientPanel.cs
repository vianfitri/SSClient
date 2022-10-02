using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSClient.Controls
{
    public partial class ClientPanel : UserControl
    {
        #region "Fields"
        private string ipAddress;
        private string pcName;
        private string macAddress;
        private bool loginState = false;
        private bool powerState = false;
        private bool remoteState = false;
        private int userId = 0;
        #endregion

        #region "Constructor"
        public ClientPanel()
        {
            InitializeComponent();
        }
        #endregion

        #region "Properties"
        public string IpAddress { 
            get => ipAddress; 
            set => ipAddress = value; 
        }

        public string PcName { 
            get => pcName;
            set { 
                pcName = value;
                lblPCName.Text = pcName;
                Invalidate();
            }
        }

        public string MacAddress { 
            get => macAddress; 
            set => macAddress = value; 
        }

        public bool LoginState { 
            get => loginState; 
            set { 
                loginState = value;
                if (loginState)
                {
                    lblLogin.Text = "Logged In";
                    lblLogin.BackColor = Color.FromArgb(60, 174, 113);
                }
                else
                {
                    lblLogin.Text = "Not Logged In Yet";
                    lblLogin.BackColor = Color.FromArgb(171, 171, 171);
                }
                    
                Invalidate();
            } 
        }

        public bool PowerState {
            get => powerState;
            set
            {
                powerState = value;
                if (powerState)
                    if (remoteState)
                        pbStatus.Image = Properties.Resources.computer_on;
                    else
                        pbStatus.Image = Properties.Resources.computer_idle;
                else
                    pbStatus.Image = Properties.Resources.computer_off;

                Invalidate();
            }
        }

        public bool RemoteState { 
            get => remoteState; 
            set
            {
                remoteState = value;
                if (powerState)
                    if (remoteState)
                        pbStatus.Image = Properties.Resources.computer_on;
                    else
                        pbStatus.Image = Properties.Resources.computer_idle;
                else
                    pbStatus.Image = Properties.Resources.computer_off;

                Invalidate();
            }
        }

        public int UserId { 
            get => userId; 
            set => userId = value; 
        }

        #endregion
    }
}
