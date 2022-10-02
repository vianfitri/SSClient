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
    public partial class fSetting : Form
    {
        public fSetting()
        {
            InitializeComponent();
        }

        private void btnPassChange_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Password changed successfuly!");
        }
    }
}
