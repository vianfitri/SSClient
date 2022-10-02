using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SSClient.Class;

namespace SSClient.Forms
{
    public partial class fLoadPos : Form
    {
        #region "Graph Algoritm"
        // create series
        Series lat_shipform_series = new Series();   // for showing ship form (amidship)
        Series lat_initshipform_series = new Series();  // for showing ship form (initial, static), lateral plane
        Series wtrline_series = new Series();    // for showing waterline 
        Series kmtline_series = new Series();    // for showing KMT line, including G
        Series bmtline_series = new Series();    // for showing BMT line
        Series gztline_series = new Series();    // for showing GZT line, 20140822 
        Series kntline_series = new Series();    // for showing KNT line, 20140823 
        Series clpline_series = new Series();    // for showing CLP line, 20160217 

        Series gpoint_series = new Series();     // for showing point G = G1 (G total ship)
        Series zpoint_series = new Series();     // for showing point Z, 20140822 
        Series bpoint_series = new Series();     // for showing point B 
        Series mpoint_series = new Series();     // for showing point M 
        Series kpoint_series = new Series();     // for showing point K, 20140823 
        Series npoint_series = new Series();     // for showing point N, 20140823 
        Series g0point_series = new Series();    // for showing point G0, G lightship, 20150827
        Series gmpoint_series = new Series();    // for showing point Gm, G total muatan, 20150827

        Series lon_shipform_series = new Series();    // for showing ship form, longitudinal plane
        Series lon_wtrline_series = new Series();     // for showing waterline longitudinal
        Series lon_initwtrline_series = new Series(); // for showing waterline longitudinal, rotatable waterline
        Series lon_kmtline_series = new Series();     // for showing ship form, longitudinal plane
        Series lon_bmtline_series = new Series();     // for showing waterline longitudinal
        Series lon_gpoint_series = new Series();      // for showing point G = G1 (G total ship)
        Series lon_bpoint_series = new Series();      // for showing point B 
        Series lon_mpoint_series = new Series();      // for showing point M 
        Series lon_cofpoint_series = new Series();    // for showing point COF 

        Series lon_g0point_series = new Series();       // for showing point G0 (G lightship), 20150827
        Series lon_gmpoint_series = new Series();       // for showing point Gm (G total muatan), 20150827

        Series lon_initshipform_series = new Series();  // for showing ship form (initial, static), longitudinal plane
        Series loadline_series = new Series();          // for showing load distribution 
        Series shearline_series = new Series();         // for showing shear force 
        Series bmomentline_series = new Series();       // for showing bending moment 
        Series topview_lat_shipform_series = new Series();  // for showing ship form, top view plane

        Series[] gzcrosscurve_series;
        Series[] gzcrosspoint_series;
        Series[] kncrosscurve_series;
        Series[] kncrosspoint_series;

        Series tmmb_xy_point_series = new Series();
        Series tmmb_xz_point_series = new Series();
        Series tmmb_yz_point_series = new Series();
        Series tmmd_xy_point_series = new Series();
        Series tmmd_xz_point_series = new Series();
        Series tmmd_yz_point_series = new Series();
        Series tkk_xy_point_series = new Series();
        Series tkk_xz_point_series = new Series();
        Series tkk_yz_point_series = new Series();
        Series tnt_xy_point_series = new Series();
        Series tnt_xz_point_series = new Series();
        Series tnt_yz_point_series = new Series();

        #endregion

        #region "Constructor"
        public fLoadPos()
        {
            InitializeComponent();
        }
        #endregion

        #region "Method"
        private void fLoadPos_Load(object sender, EventArgs e)
        {
            StabilityCalculator.LoadConfiguration(Application.StartupPath + "\\Data\\BC.cfg");

            StabilityCalculator.InitializeShipData();

            // Setting Longitudinal Ship form Hull Series
            settingLongHullSerries();

            // Load Side View Chart
            settingChartLoadSide();
        }

        // calculate 
        private void nudLoad_ValueChanged(object sender, EventArgs e)
        {
            StabilityCalculator.mLoad = (double)nudLoad.Value;
            StabilityCalculator.CalculateCG_and_Attitude();

            // Show Center of Gravity Position
            txbGmx.Text = StabilityCalculator.xCGTotalLoad.ToString("F1");
            txbGmy.Text = StabilityCalculator.yCGTotalLoad.ToString("F1");
            txbGmz.Text = StabilityCalculator.zCGTotalLoad.ToString("F1");

            txbGx.Text = StabilityCalculator.xCGTotalShip.ToString("F1");
            txbGy.Text = StabilityCalculator.yCGTotalShip.ToString("F1");
            txbGz.Text = StabilityCalculator.zCGTotalShip.ToString("F1");
        }

        private void btnView3D_Click(object sender, EventArgs e)
        {
            View3D f3DView = new View3D();
            f3DView.Show();
        }

        private void settingLongHullSerries()
        {
            lon_initshipform_series.Name = "Initial Ship Longitudinal Field";
            lon_initshipform_series.Color = Color.FromArgb(0, 0, 0);
            lon_initshipform_series.ChartType = SeriesChartType.Line;
            lon_initshipform_series.BorderWidth = 2;
        }

        private void settingChartLoadSide()
        {
            chartLoadSideView.Titles.Clear();
            chartLoadSideView.Titles.Add("Load, Side View");
            chartLoadSideView.Titles[0].Font = new Font("Microsoft Sans Serif", 16);

            chartLoadSideView.Series.Clear();

            // load shippoint hull longitudinal
            for(int i=0; i<StabilityCalculator.shippointslon_BC.Length; i++)
            {
                lon_initshipform_series.Points.AddXY(
                    StabilityCalculator.shippointslon_BC[i].x, 
                    StabilityCalculator.shippointslon_BC[i].y
                );
            }

            chartLoadSideView.Series.Add(lon_initshipform_series);

            chartLoadSideView.ChartAreas[0].AxisX.Minimum = -600;
            chartLoadSideView.ChartAreas[0].AxisX.Maximum = 600;
            chartLoadSideView.ChartAreas[0].AxisY.Minimum = -300;
            chartLoadSideView.ChartAreas[0].AxisY.Maximum = 900;
        }

        private void chartLoadSideView_PrePaint(object sender, ChartPaintEventArgs e)
        {
            // algorithm to make chart always in correct aspect ratio
            float GraphX = chartLoadSideView.ChartAreas[0].InnerPlotPosition.X * chartLoadSideView.Width / 100;
            float GraphY = chartLoadSideView.ChartAreas[0].InnerPlotPosition.Y * chartLoadSideView.Height / 100;
            float GraphR = chartLoadSideView.ChartAreas[0].InnerPlotPosition.Right * chartLoadSideView.Width / 100;
            float GraphB = chartLoadSideView.ChartAreas[0].InnerPlotPosition.Bottom * chartLoadSideView.Height / 100;

            float TitleHeight = 0;
            if (chartLoadSideView.Titles.Count > 1)
            {
                for (int i = 0; i < chartLoadSideView.Titles.Count; i++)
                {
                    TitleHeight += chartLoadSideView.Titles[i].Font.Height;
                }
            }

            float GraphWidth = chartLoadSideView.ChartAreas[0].InnerPlotPosition.Width * chartLoadSideView.Width / 100;
            float GraphHeight = chartLoadSideView.ChartAreas[0].InnerPlotPosition.Height * chartLoadSideView.Height / 100 - TitleHeight;
            double AxisYLength = chartLoadSideView.ChartAreas[0].AxisY.Maximum - chartLoadSideView.ChartAreas[0].AxisY.Minimum;
            double AxisXLength = 100 * Math.Round(GraphWidth / GraphHeight * AxisYLength / 100);

            chartLoadSideView.ChartAreas[0].AxisX.Minimum = (int)(-1 * AxisXLength / 2);
            chartLoadSideView.ChartAreas[0].AxisX.Maximum = (int)(+1 * AxisXLength / 2);

            chartLoadSideView.ChartAreas[0].AxisX.Interval = 100;
        }
        #endregion


    }
}
