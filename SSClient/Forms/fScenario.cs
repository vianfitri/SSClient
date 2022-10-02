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
    public partial class fScenario : Form
    {
        public fScenario()
        {
            InitializeComponent();
        }

        private void dummyScenData()
        {
            bdgv_scenlist.Rows.Add(
                new object[]
                {
                    1,
                    "Skenario 1",
                    "3650 DWT General Cargo",
                    null,
                    null
                }
            );

            bdgv_scenlist.Rows.Add(
                new object[]
                {
                    2,
                    "General Cargo ship",
                    "3650 DWT General Cargo",
                    null,
                    null
                }
            );

            bdgv_scenlist.Rows.Add(
                new object[]
                {
                    3,
                    "Stability GenCar",
                    "3650 DWT General Cargo",
                    null,
                    null
                }
            );

            bdgv_scenlist.Rows.Add(
                new object[]
                {
                    4,
                    "Containership Stability",
                    "4180 DWT Full Container",
                    null,
                    null
                }
            );

            bdgv_scenlist.Rows.Add(
                new object[]
                {
                    5,
                    "Stabilitas Bulkcarrier",
                    "50000 DWT Bulk Carrier",
                    null,
                    null
                }
            );

            bdgv_scenlist.Rows.Add(
                new object[]
                {
                    6,
                    "Skenario kapal bulk",
                    "50000 DWT Bulk Carrier",
                    null,
                    null
                }
            );
        }

        private void fScenario_Load(object sender, EventArgs e)
        {
            dummyScenData();
        }
    }
}
