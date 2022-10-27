using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SSClient.Class;

namespace SSClient.Forms
{
    public partial class fSSS : Form
    {
        #region "Fields"

        formDashboard _parent;
        private DB mysqlConn = null;

        #region "Pract Variables To Save"
        int id_practicum = 0;
        float heel_val = 0;
        float trim_val = 0;
        float tmmb_weight = 0f;
        float tmmb_pos = 0f;
        float tmmd_weight = 0f;
        float tmmd_pos = 0f;
        float tkk_weight = 0f;
        float tkk_pos = 0f;
        float tnt_weight = 0f;
        float tnt_pos = 0f;
        float aft_draft = 0f;
        float fwd_draft = 0f;
        float time_elapsed = 0f;

        // Score criteria
        float angle_max = 6;
        float draft_aft_max = 0;
        float draft_fwd_max = 0;
        float time_duration_max = 0;
        
        // Score to save
        float angle_heel_score = 0;
        float angle_trim_score = 0;
        float aft_draft_score = 0;
        float fwd_draft_score = 0;
        float time_speed_score = 0;
        float accomplished_score = 0;
        #endregion

        #region "Load"
        double dWeightTotalShip;
        double dWeightTotalShip_Real;

        double xCGLightShip; // LCG =  60 mm, hasil praktikum 20160128
        double yCGLightShip; // TKG =   0.2 mm, hasil praktikum 20151230
        double zCGLightShip; // KG  = 110 mm, hasil praktikum 20151230
        double xCGTotalLoad;
        double yCGTotalLoad;
        double zCGTotalLoad;
        double xCGTotalShip;
        double yCGTotalShip;
        double zCGTotalShip;

        double mTMMB;
        double mTMMD;
        double mTKK;
        double mTNT;

        double mTMMB_real;
        double mTMMD_real;
        double mTKK_real;
        double mTNT_real;

        double heel_angle = 0; // in deg
        double trim_angle = 0; // in deg
        #endregion

        #region "Hydrostatic Data"
        double dDispVal = 0;   // displacement value in kgf
        double dHeelVal = 0;   // heel angle in deg
        double dTrimVal = 0;   // trim angle in deg, 20150822
        double dGZVal = 0;     // GZ value in mm
        double dKNVal = 0;     // KN value in mm
        double dKBTVal = 0;    // KB transversal value in mm
        double dKMTVal = 0;    // KM transversal value in mm
        double dBMTVal = 0;    // BM transversal value in mm
        double dTCBVal = 0;    // CB transversal value in mm
        double dVCBVal = 0;    // VCB transversal value in mm
        double dDraftVal = 0;  // draft value in mm
        double dInputVal = 0;  // Input value = Displacement or Draft
        double dOutputVal = 0; // Output value = Displacement or Draft

        double dWTIVal = 0;   // Weight To Immerse value in kgf/cm, 20150901
        double dMTTVal = 0;   // Moment To Trim value in kgf.m/cm, 20150901
        double dCOBVal = 0;   // Coefficient of Block, 20150907
        double dCOPVal = 0;   // Coefficient of Prismatic, 20150907

        double dVBLVal = 0;    // VCB longitudinal value in mm
        double dKMLVal = 0;    // KM longitudinal value in mm
        double dBMLVal = 0;    // BM longitudinal value in mm
        double dLBLVal = 0;    // CB longitudinal value in mm
        double dLFLVal = 0;    // LCF longitudinal value in mm 
        double dVFLVal = 0;    // VCF longitudinal value in mm 
        double dX0Val = 0;     // X0, x position of origin point (analysis frame), from AP (after perpendiculat)

        double dDispVal_Real = 0;   // displacement value in kgf
        double dGZVal_Real = 0;     // GZ value in mm
        double dKNVal_Real = 0;     // KN value in mm
        double dKGVal_Real = 0;     // KG value in mm
        double dKBTVal_Real = 0;    // KB transversal value in mm
        double dVCBVal_Real = 0;    // CB vertical value in mm
        double dKMTVal_Real = 0;    // KM transversal value in mm
        double dBMTVal_Real = 0;    // BM transversal value in mm
        double dTCBVal_Real = 0;    // CB transversal value in mm
        double dDraftVal_Real = 0;  // draft value in mm
        double dInputVal_Real = 0;  // Input value = Displacement or Draft
        double dOutputVal_Real = 0; // Output value = Displacement or Draft

        double dWTIVal_Real = 0;   // Weight To Immerse value in kgf/cm, 20150901
        double dMTTVal_Real = 0;   // Moment To Trim value in kgf.m/cm, 20150901
        double dCOBVal_Real = 0;   // Coefficient of Block, 20150907
        double dCOPVal_Real = 0;   // Coefficient of Prismatic, 20150907

        double dKBLVal_Real = 0;    // KB longitudinal value in mm
        double dKMLVal_Real = 0;    // KM longitudinal value in mm
        double dBMLVal_Real = 0;    // BM longitudinal value in mm
        double dLBLVal_Real = 0;    // CB longitudinal value in mm
        double dLFLVal_Real = 0;    // LCF longitudinal value in mm 
        double dVFLVal_Real = 0;    // KCF longitudinal value in mm 
        double dX0Val_Real = 0;     // X0, x position of origin point (analysis frame), from AP (after perpendiculat)
        #endregion

        #region "Chart Series"
        // ChartSeries
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

        Series lcb_series = new Series(); // LCB
        Series lcf_series = new Series(); // LCF
        Series mtt_series = new Series(); // MTCT
        Series dsp_series = new Series(); // Displacement
        Series wti_series = new Series(); // Tonne Per Centimeter (TPC) or Weight To Immerse (WTI)
        Series kbt_series = new Series(); // KB Transversal
        Series kmt_series = new Series(); // KM Transversal
        Series cob_series = new Series(); // Cb = Block Coefficient
        Series cop_series = new Series(); // Cp = Prismatic Coefficient
        #endregion

        #region "Chart Point"
        StabilityCalculator.Point3D TMMB_Pos = new StabilityCalculator.Point3D { x = 300, y = 0, z = 106 };
        StabilityCalculator.Point3D TMMD_Pos = new StabilityCalculator.Point3D { x = 1100, y = 0, z = 106 };
        StabilityCalculator.Point3D TKK_Pos = new StabilityCalculator.Point3D { x = 1100, y = 0, z = 275 };
        StabilityCalculator.Point3D TNT_Pos = new StabilityCalculator.Point3D { x = 1225, y = 0, z = 48 };
        StabilityCalculator.Point3D TMMB_Pos_Real = new StabilityCalculator.Point3D();
        StabilityCalculator.Point3D TMMD_Pos_Real = new StabilityCalculator.Point3D();
        StabilityCalculator.Point3D TKK_Pos_Real = new StabilityCalculator.Point3D();
        StabilityCalculator.Point3D TNT_Pos_Real = new StabilityCalculator.Point3D();
        #endregion

        #region "Hydrostatic Scale"
        float K_lcb = 50;   // Contant for graphic, LCB
        float K_lcf = 60;   // Contant for graphic, LCF
        float K_dsp = 50;   // Contant for graphic, Displacement
        float K_kbt = 50;   // Contant for graphic, KBT
        float K_kmt = 1;    // Contant for graphic, KMT
        float K_mtt = 1000; // Contant for graphic, MTCT
        float K_wti = 500;  // Contant for graphic, TPC or WTI
        float K_cob = 5000; // Contant for graphic, Cb = Block Coefficient
        float K_cop = 3000; // Contant for graphic, Cp = Prismatic Coefficient
        #endregion

        #endregion

        #region "Constructor"
        public fSSS(formDashboard parent)
        {
            InitializeComponent();
            this._parent = parent;
        }
        #endregion

        #region "Properties"
        public DB MySQLConn
        {
            get { return mysqlConn; }
            set { mysqlConn = value; }
        }
        #endregion

        #region "Method"
        private void fSSS_Load(object sender, EventArgs e)
        {
            // Set MySQL Connector
            MySQLConn = this._parent.MySQLConn;

            StabilityCalculator.LoadConfiguration(Application.StartupPath + "\\Data\\BC.cfg");

            // SplitContainer Setting
            spcShipStability.SplitterDistance = Screen.PrimaryScreen.Bounds.Width - 690;

            // initialize amidship points, then translate each point 
            StabilityCalculator.shippoints_init = (StabilityCalculator.Point2D[])StabilityCalculator.shippoints_BC.Clone();

            #region "Series SetUp"
            lat_shipform_series.Name = "Bidang Melintang Kapal";
            lat_shipform_series.Color = Color.FromArgb(0, 0, 0);
            lat_shipform_series.ChartType = SeriesChartType.Line; // Fast Line can show line only, not show marker! ssw, 20130619 
            lat_shipform_series.BorderWidth = 2;

            lat_initshipform_series.Name = "Bidang Melintang Kapal Awal";
            lat_initshipform_series.Color = Color.FromArgb(0, 0, 0);
            lat_initshipform_series.ChartType = SeriesChartType.Line; // Fast Line can show line only, not show marker! ssw, 20130619 
            lat_initshipform_series.BorderWidth = 2;

            lon_shipform_series.Name = "Bidang Membujur Kapal";
            lon_shipform_series.Color = Color.FromArgb(0, 0, 0);
            lon_shipform_series.ChartType = SeriesChartType.Line; // Fast Line can show line only, not show marker! ssw, 20130619 
            lon_shipform_series.BorderWidth = 2;

            topview_lat_shipform_series.Name = "Bidang Kapal Tampak Atas";
            topview_lat_shipform_series.Color = Color.FromArgb(0, 0, 0);
            topview_lat_shipform_series.ChartType = SeriesChartType.Line; // Fast Line can show line only, not show marker! ssw, 20130619 
            topview_lat_shipform_series.BorderWidth = 2;

            lon_initshipform_series.Name = "Bidang Membujur Kapal Awal";
            lon_initshipform_series.Color = Color.FromArgb(0, 0, 0);
            lon_initshipform_series.ChartType = SeriesChartType.Line; // Fast Line can show line only, not show marker! ssw, 20130619 
            lon_initshipform_series.BorderWidth = 2;

            gpoint_series.Name = "Titik Berat";
            gpoint_series.Color = Color.FromArgb(0, 0, 0);
            gpoint_series.ChartType = SeriesChartType.Line; // Fast Point can show marker! ssw, 20130619 
            gpoint_series.MarkerStyle = MarkerStyle.Circle;
            gpoint_series.MarkerSize = 15;
            gpoint_series.Label = "G";
            gpoint_series.LabelForeColor = Color.FromArgb(0, 0, 0);
            gpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_gpoint_series.Name = "Titik Berat Membujur";
            lon_gpoint_series.Color = Color.FromArgb(0, 0, 0);
            lon_gpoint_series.ChartType = SeriesChartType.Line; // Fast Point can show marker! ssw, 20130619 
            lon_gpoint_series.MarkerStyle = MarkerStyle.Circle;
            lon_gpoint_series.MarkerSize = 15;
            lon_gpoint_series.Label = "G";
            lon_gpoint_series.LabelForeColor = Color.FromArgb(0, 0, 0);
            lon_gpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            bpoint_series.Name = "Titik Buoyancy Melintang";
            bpoint_series.Color = Color.FromArgb(0, 0, 255);
            bpoint_series.ChartType = SeriesChartType.Line; // Fast Point can show marker! ssw, 20130619 
            bpoint_series.MarkerStyle = MarkerStyle.Circle;
            bpoint_series.MarkerSize = 15;
            bpoint_series.Label = "B";
            bpoint_series.LabelForeColor = Color.FromArgb(0, 0, 255);
            bpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_bpoint_series.Name = "Titik Buoyancy Membujur";
            lon_bpoint_series.Color = Color.FromArgb(0, 0, 255);
            lon_bpoint_series.ChartType = SeriesChartType.Line; // Fast Point can show marker! ssw, 20130619 
            lon_bpoint_series.MarkerStyle = MarkerStyle.Circle;
            lon_bpoint_series.MarkerSize = 15;
            lon_bpoint_series.Label = "B";
            lon_bpoint_series.LabelForeColor = Color.FromArgb(0, 0, 255);
            lon_bpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            mpoint_series.Name = "Metacenter Melintang";
            mpoint_series.Color = Color.FromArgb(255, 0, 0);
            mpoint_series.ChartType = SeriesChartType.Line; // Fast Point can show marker! ssw, 20130619 
            mpoint_series.MarkerStyle = MarkerStyle.Circle;
            mpoint_series.MarkerSize = 15;
            mpoint_series.Label = "M";
            mpoint_series.LabelForeColor = Color.FromArgb(255, 0, 0);
            mpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_mpoint_series.Name = "Metacenter Membujur";
            lon_mpoint_series.Color = Color.FromArgb(255, 0, 0);
            lon_mpoint_series.ChartType = SeriesChartType.Line; // Fast Point can show marker! ssw, 20130619 
            lon_mpoint_series.MarkerStyle = MarkerStyle.Circle;
            lon_mpoint_series.MarkerSize = 15;
            lon_mpoint_series.Label = "M";
            lon_mpoint_series.LabelForeColor = Color.FromArgb(255, 0, 0);
            lon_mpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_cofpoint_series.Name = "Titik Apung";
            lon_cofpoint_series.Color = Color.FromArgb(255, 0, 0);
            lon_cofpoint_series.ChartType = SeriesChartType.Line; // Fast Point can show marker! ssw, 20130619 
            lon_cofpoint_series.MarkerStyle = MarkerStyle.Circle;
            lon_cofpoint_series.MarkerSize = 15;
            lon_cofpoint_series.Label = "COF";
            lon_cofpoint_series.LabelForeColor = Color.FromArgb(255, 0, 0);
            lon_cofpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            zpoint_series.Name = "Titik Z";
            zpoint_series.Color = Color.FromArgb(0, 155, 0); // green
            zpoint_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            zpoint_series.MarkerStyle = MarkerStyle.Circle;
            zpoint_series.MarkerSize = 15;
            zpoint_series.Label = "Z";
            zpoint_series.LabelForeColor = Color.FromArgb(0, 155, 0);
            zpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            kpoint_series.Name = "Titik K";
            kpoint_series.Color = Color.FromArgb(150, 150, 0); // green
            kpoint_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            kpoint_series.MarkerStyle = MarkerStyle.Circle;
            kpoint_series.MarkerSize = 15;
            kpoint_series.Label = "K";
            kpoint_series.LabelForeColor = Color.FromArgb(150, 150, 0);
            kpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            npoint_series.Name = "Titik N";
            npoint_series.Color = Color.FromArgb(0, 155, 155); // green
            npoint_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            npoint_series.MarkerStyle = MarkerStyle.Circle;
            npoint_series.MarkerSize = 15;
            npoint_series.Label = "N";
            npoint_series.LabelForeColor = Color.FromArgb(0, 155, 155);
            npoint_series.Font = new Font("Microsoft Sans Serif", 14);

            wtrline_series.Name = "Garis Air Melintang";
            wtrline_series.Color = Color.FromArgb(0, 0, 255);
            wtrline_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            wtrline_series.MarkerStyle = MarkerStyle.Circle;
            wtrline_series.MarkerSize = 10;
            wtrline_series.Label = "WL";
            wtrline_series.LabelForeColor = Color.FromArgb(0, 0, 255);
            wtrline_series.BorderWidth = 2;
            wtrline_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_wtrline_series.Name = "Garis Air Membujur";
            lon_wtrline_series.Color = Color.FromArgb(0, 0, 255);
            lon_wtrline_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            lon_wtrline_series.MarkerStyle = MarkerStyle.Circle;
            lon_wtrline_series.MarkerSize = 10;
            lon_wtrline_series.Label = "WL";
            lon_wtrline_series.LabelForeColor = Color.FromArgb(0, 0, 255);
            lon_wtrline_series.BorderWidth = 2;
            lon_wtrline_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_initwtrline_series.Name = "Garis Air Membujur Awal";
            lon_initwtrline_series.Color = Color.FromArgb(0, 0, 255);
            lon_initwtrline_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            lon_initwtrline_series.MarkerStyle = MarkerStyle.Circle;
            lon_initwtrline_series.MarkerSize = 10;
            lon_initwtrline_series.Label = "WL0";
            lon_initwtrline_series.LabelForeColor = Color.FromArgb(0, 0, 255);
            lon_initwtrline_series.BorderWidth = 2;
            lon_initwtrline_series.Font = new Font("Microsoft Sans Serif", 14);

            kmtline_series.Name = "Garis KM Melintang";
            kmtline_series.Color = Color.FromArgb(255, 0, 0); // red
            kmtline_series.ChartType = SeriesChartType.FastLine; // Fast Line can show line only, not show marker! ssw, 20130619 
            kmtline_series.Label = "";
            kmtline_series.LabelForeColor = Color.FromArgb(255, 0, 0); // red
            kmtline_series.BorderWidth = 1;
            kmtline_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_kmtline_series.Name = "Garis KM Membujur";
            lon_kmtline_series.Color = Color.FromArgb(255, 0, 0); // red
            lon_kmtline_series.ChartType = SeriesChartType.FastLine; // Fast Line can show line only, not show marker! ssw, 20130619 
            lon_kmtline_series.Label = "";
            lon_kmtline_series.LabelForeColor = Color.FromArgb(255, 0, 0); // red
            lon_kmtline_series.BorderWidth = 1;
            lon_kmtline_series.Font = new Font("Microsoft Sans Serif", 14);

            bmtline_series.Name = "Garis BM Melintang";
            bmtline_series.Color = Color.FromArgb(0, 0, 255); // blue
            bmtline_series.ChartType = SeriesChartType.FastLine; // Fast Line can show line only, not show marker! ssw, 20130619 
            bmtline_series.Label = "";
            bmtline_series.LabelForeColor = Color.FromArgb(0, 0, 255); // blue
            bmtline_series.BorderWidth = 1;
            bmtline_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_bmtline_series.Name = "Garis BM Membujur";
            lon_bmtline_series.Color = Color.FromArgb(0, 0, 255); // blue
            lon_bmtline_series.ChartType = SeriesChartType.FastLine; // Fast Line can show line only, not show marker! ssw, 20130619 
            lon_bmtline_series.Label = "";
            lon_bmtline_series.LabelForeColor = Color.FromArgb(0, 0, 255); // blue
            lon_bmtline_series.BorderWidth = 1;
            lon_bmtline_series.Font = new Font("Microsoft Sans Serif", 14);

            gztline_series.Name = "Garis GZ";
            gztline_series.Color = Color.FromArgb(0, 155, 0); // green
            gztline_series.ChartType = SeriesChartType.FastLine; // Fast Line can show line only, not show marker! ssw, 20130619 
            gztline_series.Label = "";
            gztline_series.LabelForeColor = Color.FromArgb(0, 0, 255); // blue
            gztline_series.BorderWidth = 1;
            gztline_series.Font = new Font("Microsoft Sans Serif", 14);

            kntline_series.Name = "Garis KN";
            kntline_series.Color = Color.FromArgb(0, 155, 0); // green
            kntline_series.ChartType = SeriesChartType.FastLine; // Fast Line can show line only, not show marker! ssw, 20130619 
            kntline_series.Label = "";
            kntline_series.LabelForeColor = Color.FromArgb(0, 0, 255); // blue
            kntline_series.BorderWidth = 1;
            kntline_series.Font = new Font("Microsoft Sans Serif", 14);

            clpline_series.Name = "Garis CLP";
            clpline_series.Color = Color.FromArgb(0, 0, 0); // black
            clpline_series.ChartType = SeriesChartType.FastLine; // Fast Line can show line only, not show marker! ssw, 20130619 
            clpline_series.Label = "";
            clpline_series.LabelForeColor = Color.FromArgb(0, 0, 0); // black
            clpline_series.BorderWidth = 2;
            clpline_series.Font = new Font("Microsoft Sans Serif", 14);

            g0point_series.Name = "Titik Berat Kapal Kosong";
            g0point_series.Color = Color.Brown;
            g0point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            g0point_series.MarkerStyle = MarkerStyle.Circle;
            g0point_series.MarkerSize = 15;
            g0point_series.Label = "G0";
            g0point_series.LabelForeColor = g0point_series.Color;
            g0point_series.Font = new Font("Microsoft Sans Serif", 14);

            gmpoint_series.Name = "Titik Berat Muatan Total";
            gmpoint_series.Color = Color.Magenta;
            gmpoint_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            gmpoint_series.MarkerStyle = MarkerStyle.Circle;
            gmpoint_series.MarkerSize = 15;
            gmpoint_series.Label = "Gm";
            gmpoint_series.LabelForeColor = gmpoint_series.Color;
            gmpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_g0point_series.Name = "Titik Berat Kapal Kosong Membujur";
            lon_g0point_series.Color = Color.Brown;
            lon_g0point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            lon_g0point_series.MarkerStyle = MarkerStyle.Circle;
            lon_g0point_series.MarkerSize = 15;
            lon_g0point_series.Label = "G0";
            lon_g0point_series.LabelForeColor = lon_g0point_series.Color;
            lon_g0point_series.Font = new Font("Microsoft Sans Serif", 14);

            lon_gmpoint_series.Name = "Titik Berat Muatan Total Longitudinal";
            lon_gmpoint_series.Color = Color.Magenta;
            lon_gmpoint_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            lon_gmpoint_series.MarkerStyle = MarkerStyle.Circle;
            lon_gmpoint_series.MarkerSize = 15;
            lon_gmpoint_series.Label = "Gm";
            lon_gmpoint_series.LabelForeColor = lon_gmpoint_series.Color;
            lon_gmpoint_series.Font = new Font("Microsoft Sans Serif", 14);

            tmmb_xy_point_series.Name = "TMMB XY";
            tmmb_xy_point_series.Color = Color.Red;
            tmmb_xy_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tmmb_xy_point_series.MarkerStyle = MarkerStyle.Circle;
            tmmb_xy_point_series.MarkerSize = 15;
            tmmb_xy_point_series.Label = "TMMB";
            tmmb_xy_point_series.LabelForeColor = tmmb_xy_point_series.Color;
            tmmb_xy_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tmmb_xz_point_series.Name = "TMMB XZ";
            tmmb_xz_point_series.Color = Color.Red;
            tmmb_xz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tmmb_xz_point_series.MarkerStyle = MarkerStyle.Circle;
            tmmb_xz_point_series.MarkerSize = 15;
            tmmb_xz_point_series.Label = "TMMB";
            tmmb_xz_point_series.LabelForeColor = tmmb_xz_point_series.Color;
            tmmb_xz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tmmb_yz_point_series.Name = "TMMB YZ";
            tmmb_yz_point_series.Color = Color.Red;
            tmmb_yz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tmmb_yz_point_series.MarkerStyle = MarkerStyle.Circle;
            tmmb_yz_point_series.MarkerSize = 15;
            tmmb_yz_point_series.Label = "TMMB";
            tmmb_yz_point_series.LabelForeColor = tmmb_yz_point_series.Color;
            tmmb_yz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tmmd_xy_point_series.Name = "TMMD XY";
            tmmd_xy_point_series.Color = Color.Green;
            tmmd_xy_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tmmd_xy_point_series.MarkerStyle = MarkerStyle.Circle;
            tmmd_xy_point_series.MarkerSize = 15;
            tmmd_xy_point_series.Label = "TMMD";
            tmmd_xy_point_series.LabelForeColor = tmmd_xy_point_series.Color;
            tmmd_xy_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tmmd_xz_point_series.Name = "TMMD XZ";
            tmmd_xz_point_series.Color = Color.Green;
            tmmd_xz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tmmd_xz_point_series.MarkerStyle = MarkerStyle.Circle;
            tmmd_xz_point_series.MarkerSize = 15;
            tmmd_xz_point_series.Label = "TMMD";
            tmmd_xz_point_series.LabelForeColor = tmmd_xz_point_series.Color;
            tmmd_xz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tmmd_yz_point_series.Name = "TMMD YZ";
            tmmd_yz_point_series.Color = Color.Green;
            tmmd_yz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tmmd_yz_point_series.MarkerStyle = MarkerStyle.Circle;
            tmmd_yz_point_series.MarkerSize = 15;
            tmmd_yz_point_series.Label = "TMMD";
            tmmd_yz_point_series.LabelForeColor = tmmd_yz_point_series.Color;
            tmmd_yz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tkk_xy_point_series.Name = "TKK XY";
            tkk_xy_point_series.Color = Color.Blue;
            tkk_xy_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tkk_xy_point_series.MarkerStyle = MarkerStyle.Circle;
            tkk_xy_point_series.MarkerSize = 15;
            tkk_xy_point_series.Label = "TKK";
            tkk_xy_point_series.LabelForeColor = tkk_xy_point_series.Color;
            tkk_xy_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tkk_xz_point_series.Name = "TKK XZ";
            tkk_xz_point_series.Color = Color.Blue;
            tkk_xz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tkk_xz_point_series.MarkerStyle = MarkerStyle.Circle;
            tkk_xz_point_series.MarkerSize = 15;
            tkk_xz_point_series.Label = "TKK";
            tkk_xz_point_series.LabelForeColor = tkk_xz_point_series.Color;
            tkk_xz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tkk_yz_point_series.Name = "TKK YZ";
            tkk_yz_point_series.Color = Color.Blue;
            tkk_yz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tkk_yz_point_series.MarkerStyle = MarkerStyle.Circle;
            tkk_yz_point_series.MarkerSize = 15;
            tkk_yz_point_series.Label = "TKK";
            tkk_yz_point_series.LabelForeColor = tkk_yz_point_series.Color;
            tkk_yz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tnt_xy_point_series.Name = "TNT XY";
            tnt_xy_point_series.Color = Color.Magenta;
            tnt_xy_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tnt_xy_point_series.MarkerStyle = MarkerStyle.Circle;
            tnt_xy_point_series.MarkerSize = 15;
            tnt_xy_point_series.Label = "TNT";
            tnt_xy_point_series.LabelForeColor = tnt_xy_point_series.Color;
            tnt_xy_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tnt_xz_point_series.Name = "TNT XZ";
            tnt_xz_point_series.Color = Color.Magenta;
            tnt_xz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tnt_xz_point_series.MarkerStyle = MarkerStyle.Circle;
            tnt_xz_point_series.MarkerSize = 15;
            tnt_xz_point_series.Label = "TNT";
            tnt_xz_point_series.LabelForeColor = tnt_xz_point_series.Color;
            tnt_xz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            tnt_yz_point_series.Name = "TNT YZ";
            tnt_yz_point_series.Color = Color.Magenta;
            tnt_yz_point_series.ChartType = SeriesChartType.Line; // Fast Point and Line can show marker! ssw, 20130619 
            tnt_yz_point_series.MarkerStyle = MarkerStyle.Circle;
            tnt_yz_point_series.MarkerSize = 15;
            tnt_yz_point_series.Label = "TNT";
            tnt_yz_point_series.LabelForeColor = tnt_yz_point_series.Color;
            tnt_yz_point_series.Font = new Font("Microsoft Sans Serif", 14);

            // Hydrostatic Series
            lcb_series.Name = "LCB (x 1/" + K_lcb.ToString("F0") + " mm)";
            lcb_series.Color = Color.Red;
            lcb_series.ChartType = SeriesChartType.Line;
            lcb_series.MarkerStyle = MarkerStyle.Circle;
            lcb_series.MarkerSize = 3;
            lcb_series.Label = "";
            lcb_series.LabelForeColor = lcb_series.Color;
            lcb_series.BorderWidth = 2;
            lcb_series.Font = new Font("Microsoft Sans Serif", 14);

            lcf_series.Name = "LCF (x 1/" + K_lcf.ToString("F0") + " mm)";
            lcf_series.Color = Color.Green;
            lcf_series.ChartType = SeriesChartType.Line;
            lcf_series.MarkerStyle = MarkerStyle.Circle;
            lcf_series.MarkerSize = 3;
            lcf_series.Label = "";
            lcf_series.LabelForeColor = lcf_series.Color;
            lcf_series.BorderWidth = 2;
            lcf_series.Font = new Font("Microsoft Sans Serif", 14);

            mtt_series.Name = "MTCT (x 1/" + K_mtt.ToString("F0") + " kg-cm/mm)";
            mtt_series.Color = Color.Blue;
            mtt_series.ChartType = SeriesChartType.Line;
            mtt_series.MarkerStyle = MarkerStyle.Circle;
            mtt_series.MarkerSize = 3;
            mtt_series.Label = "";
            mtt_series.LabelForeColor = mtt_series.Color;
            mtt_series.BorderWidth = 2;
            mtt_series.Font = new Font("Microsoft Sans Serif", 14);

            dsp_series.Name = "∆ (x 1/" + K_dsp.ToString("F0") + " (kgf)";
            dsp_series.Color = Color.Maroon;
            dsp_series.ChartType = SeriesChartType.Line;
            dsp_series.MarkerStyle = MarkerStyle.Circle;
            dsp_series.MarkerSize = 3;
            dsp_series.Label = "";
            dsp_series.LabelForeColor = dsp_series.Color;
            dsp_series.BorderWidth = 2;
            dsp_series.Font = new Font("Microsoft Sans Serif", 14);

            wti_series.Name = "TPC (x 1/" + K_wti.ToString("F0") + " kg/mm)";
            wti_series.Color = Color.LightBlue;
            wti_series.ChartType = SeriesChartType.Line;
            wti_series.MarkerStyle = MarkerStyle.Circle;
            wti_series.MarkerSize = 3;
            wti_series.Label = "";
            wti_series.LabelForeColor = dsp_series.Color;
            wti_series.BorderWidth = 2;
            wti_series.Font = new Font("Microsoft Sans Serif", 14);

            kbt_series.Name = "KBt (x 1/" + K_kbt.ToString("F0") + " mm)";
            kbt_series.Color = Color.Yellow;
            kbt_series.ChartType = SeriesChartType.Line;
            kbt_series.MarkerStyle = MarkerStyle.Circle;
            kbt_series.MarkerSize = 3;
            kbt_series.Label = "";
            kbt_series.LabelForeColor = kbt_series.Color;
            kbt_series.BorderWidth = 2;
            kbt_series.Font = new Font("Microsoft Sans Serif", 14);

            kmt_series.Name = "KMt (x 1/" + K_kmt.ToString("F0") + " mm)";
            kmt_series.Color = Color.Magenta;
            kmt_series.ChartType = SeriesChartType.Line;
            kmt_series.MarkerStyle = MarkerStyle.Circle;
            kmt_series.MarkerSize = 3;
            kmt_series.Label = "";
            kmt_series.LabelForeColor = kmt_series.Color;
            kmt_series.BorderWidth = 2;
            kmt_series.Font = new Font("Microsoft Sans Serif", 14);

            cob_series.Name = "Cb (x 1/" + K_cob.ToString("F0") + " )";
            cob_series.Color = Color.DarkOrange;
            cob_series.ChartType = SeriesChartType.Line;
            cob_series.MarkerStyle = MarkerStyle.Circle;
            cob_series.MarkerSize = 3;
            cob_series.Label = "";
            cob_series.LabelForeColor = kmt_series.Color;
            cob_series.BorderWidth = 2;
            cob_series.Font = new Font("Microsoft Sans Serif", 14);

            cop_series.Name = "Cp (x 1/" + K_cop.ToString("F0") + " )";
            cop_series.Color = Color.LightGreen;
            cop_series.ChartType = SeriesChartType.Line;
            cop_series.MarkerStyle = MarkerStyle.Circle;
            cop_series.MarkerSize = 3;
            cop_series.Label = "";
            cop_series.LabelForeColor = kmt_series.Color;
            cop_series.BorderWidth = 2;
            cop_series.Font = new Font("Microsoft Sans Serif", 14);
            #endregion

            #region "Chart SetUp"

            // Chart Transversal
            crtTransversal.Titles.Clear();
            crtTransversal.Titles.Add("Kapal Bulk Carrier - MV TIRAM");
            crtTransversal.Titles.Add("Penampang Kapal, Amidship, Tampak Depan");
            crtTransversal.Titles[0].Font = new Font("Microsoft Sans Serif", 16);
            crtTransversal.Titles[1].Font = new Font("Microsoft Sans Serif", 16);

            crtTransversal.Series.Add(lat_shipform_series);// series[0]  = hull ship
            crtTransversal.Series.Add(wtrline_series);     // series[1]  = WL (waterline) 
            crtTransversal.Series.Add(kmtline_series);     // series[2]  = KM line 
            crtTransversal.Series.Add(bmtline_series);     // series[3]  = BM line 
            crtTransversal.Series.Add(gztline_series);     // series[4]  = GZ line
            crtTransversal.Series.Add(kntline_series);     // series[5]  = KN line
            crtTransversal.Series.Add(clpline_series);     // series[6]  = KG = Center Line Plane
            crtTransversal.Series.Add(gpoint_series);      // series[7]  = G (center of gravity)
            crtTransversal.Series.Add(bpoint_series);      // series[8]  = B (center of buoyancy)
            crtTransversal.Series.Add(mpoint_series);      // series[9]  = M (metacenter)
            crtTransversal.Series.Add(zpoint_series);      // series[10] = Z point 
            crtTransversal.Series.Add(kpoint_series);      // series[11] = K point
            crtTransversal.Series.Add(npoint_series);      // series[12] = N point
            crtTransversal.Series.Add(g0point_series);     // series[13] = G0 point
            crtTransversal.Series.Add(gmpoint_series);     // series[14] = Gm point

            crtTransversal.ChartAreas[0].AxisX.Minimum = -300;
            crtTransversal.ChartAreas[0].AxisX.Maximum = 300;
            crtTransversal.ChartAreas[0].AxisY.Minimum = -100;
            crtTransversal.ChartAreas[0].AxisY.Maximum = 500;

            // Chart Longitudinal
            crtLongitudinal.Titles.Clear();
            crtLongitudinal.Titles.Add("Kapal Bulk Carrier - MV TIRAM");
            crtLongitudinal.Titles.Add("Bidang Membujur Kapal");
            crtLongitudinal.Titles[0].Font = new Font("Microsoft Sans Serif", 16);
            crtLongitudinal.Titles[1].Font = new Font("Microsoft Sans Serif", 16);

            crtLongitudinal.Series.Add(lon_shipform_series);     // series[0]  = hull ship, 20140919
            crtLongitudinal.Series.Add(lon_wtrline_series);      // series[1]  = WL (waterline), static, current waterline, 20140919
            crtLongitudinal.Series.Add(lon_initwtrline_series);  // series[2]  = WL (waterline), rotatable, initial, 20140919 
            crtLongitudinal.Series.Add(lon_kmtline_series);      // series[3]  = KML line, 20140926
            crtLongitudinal.Series.Add(lon_bmtline_series);      // series[4]  = BML line, 20140926 
            crtLongitudinal.Series.Add(lon_gpoint_series);       // series[5]  = G (center of gravity) , 20140926 
            crtLongitudinal.Series.Add(lon_bpoint_series);       // series[6]  = B (center of buoyancy), 20140926 
            crtLongitudinal.Series.Add(lon_mpoint_series);       // series[7]  = M (metacenter, longitudinal ), 20140926 
            crtLongitudinal.Series.Add(lon_cofpoint_series);     // series[8]  = COF point, 20140926
            crtLongitudinal.Series.Add(lon_g0point_series);      // series[9]  = G0 (CG Lightship), 20150827 
            crtLongitudinal.Series.Add(lon_gmpoint_series);      // series[10] = Gm (CG Total Load), 20150827 

            crtLongitudinal.ChartAreas[0].AxisX.Minimum = -1100;
            crtLongitudinal.ChartAreas[0].AxisX.Maximum = 1100;
            crtLongitudinal.ChartAreas[0].AxisY.Minimum = -500;
            crtLongitudinal.ChartAreas[0].AxisY.Maximum = 1700;

            // Chart Load, Side View
            crtLoadSideView.Titles.Clear();
            crtLoadSideView.Titles.Add("Muatan, Tampak Samping");
            crtLoadSideView.Titles[0].Font = new Font("Microsoft Sans Serif", 14);

            crtLoadSideView.Series.Clear();
            for (int i = 0; i < StabilityCalculator.shippointslon_BC.Length; i++)
            {
                lon_initshipform_series.Points.AddXY(
                    StabilityCalculator.shippointslon_BC[i].x, 
                    StabilityCalculator.shippointslon_BC[i].y
                );
            }
            crtLoadSideView.Series.Add(lon_initshipform_series);  // series[0]  = hull ship
            crtLoadSideView.Series.Add(tmmb_xz_point_series);    // series[1]  = TMMB
            crtLoadSideView.Series.Add(tmmd_xz_point_series);    // series[2]  = TMMD
            crtLoadSideView.Series.Add(tkk_xz_point_series);     // series[3]  = TKK
            crtLoadSideView.Series.Add(tnt_xz_point_series);     // series[4]  = TNT

            crtLoadSideView.ChartAreas[0].AxisX.Minimum = -600;
            crtLoadSideView.ChartAreas[0].AxisX.Maximum = 600;
            crtLoadSideView.ChartAreas[0].AxisY.Minimum = -500;
            crtLoadSideView.ChartAreas[0].AxisY.Maximum = 900;

            // Chart Load, Front View
            crtLoadFrontView.Titles.Clear();
            crtLoadFrontView.Titles.Add("Muatan, Tampak Depan");
            crtLoadFrontView.Titles[0].Font = new Font("Microsoft Sans Serif", 14);

            crtLoadFrontView.Series.Clear();
            lat_initshipform_series.Points.Clear();
            for (int i = 0; i < StabilityCalculator.shippoints_init.Length; i++)
            {
                lat_initshipform_series.Points.AddXY(
                    StabilityCalculator.shippoints_init[i].x,
                    StabilityCalculator.shippoints_init[i].y
                );
            }
            crtLoadFrontView.Series.Add(lat_initshipform_series); // series[0]  = hull ship
            crtLoadFrontView.Series.Add(tmmb_yz_point_series);    // series[1]  = TMMB
            crtLoadFrontView.Series.Add(tmmd_yz_point_series);    // series[2]  = TMMD
            crtLoadFrontView.Series.Add(tkk_yz_point_series);     // series[3]  = TKK
            crtLoadFrontView.Series.Add(tnt_yz_point_series);     // series[4]  = TNT

            crtLoadFrontView.ChartAreas[0].AxisX.Minimum = -300;
            crtLoadFrontView.ChartAreas[0].AxisX.Maximum = 300;
            crtLoadFrontView.ChartAreas[0].AxisY.Minimum = -100;
            crtLoadFrontView.ChartAreas[0].AxisY.Maximum = 500;

            // Chart Load, Top View
            crtLoadTopView.Titles.Clear();
            crtLoadTopView.Titles.Add("Muatan, Tampak Atas");
            crtLoadTopView.Titles[0].Font = new Font("Microsoft Sans Serif", 14);
            crtLoadTopView.Series.Clear();

            topview_lat_shipform_series.Points.Clear();
            for (int i = 0; i < StabilityCalculator.shippointsTopView_BC.Length; i++)
            {
                topview_lat_shipform_series.Points.AddXY(
                    StabilityCalculator.shippointsTopView_BC[i].x,
                    StabilityCalculator.shippointsTopView_BC[i].y
                );
            }
            crtLoadTopView.Series.Add(topview_lat_shipform_series);  // series[0]  = hull ship, top view
            crtLoadTopView.Series.Add(tmmb_xy_point_series);    // series[1]  = TMMB
            crtLoadTopView.Series.Add(tmmd_xy_point_series);    // series[2]  = TMMD
            crtLoadTopView.Series.Add(tkk_xy_point_series);     // series[3]  = TKK
            crtLoadTopView.Series.Add(tnt_xy_point_series);     // series[4]  = TNT

            crtLoadTopView.ChartAreas[0].AxisX.Minimum = -700;
            crtLoadTopView.ChartAreas[0].AxisX.Maximum = 700;
            crtLoadTopView.ChartAreas[0].AxisY.Minimum = -700;
            crtLoadTopView.ChartAreas[0].AxisY.Maximum = 700;

            // Chart Hydrostatic Curve
            crtHydrostaticCurve.Titles.Clear();
            crtHydrostaticCurve.Titles.Add("Kapal Bulk Carrier - MV TIRAM");
            crtHydrostaticCurve.Titles.Add("Kurva Hidrostatik");
            crtHydrostaticCurve.Titles[0].Font = new Font("Microsoft Sans Serif", 16);
            crtHydrostaticCurve.Titles[1].Font = new Font("Microsoft Sans Serif", 16);

            crtHydrostaticCurve.Series.Clear();
            crtHydrostaticCurve.Series.Add(lcb_series);
            crtHydrostaticCurve.Series.Add(lcf_series);
            crtHydrostaticCurve.Series.Add(mtt_series);
            crtHydrostaticCurve.Series.Add(dsp_series);
            crtHydrostaticCurve.Series.Add(wti_series);
            crtHydrostaticCurve.Series.Add(kbt_series);
            crtHydrostaticCurve.Series.Add(kmt_series);
            crtHydrostaticCurve.Series.Add(cob_series);
            crtHydrostaticCurve.Series.Add(cop_series);

            // to show legend, use only 1 command line = Legends.Add(...)
            // but first state series name!
            crtHydrostaticCurve.Legends.Clear();
            crtHydrostaticCurve.Legends.Add(lcb_series.Name);
            crtHydrostaticCurve.Legends[0].Docking = Docking.Right;
            crtHydrostaticCurve.Legends[0].BackColor = Color.White;
            crtHydrostaticCurve.Legends[0].ForeColor = Color.Black;

            // Chart GZ and KN Curve
            crtGZCrossCurve.Titles.Clear();
            crtGZCrossCurve.Titles.Add("Kapal Bulk Carrier - MV TIRAM");
            crtGZCrossCurve.Titles.Add("Kurva Silang GZ");
            crtGZCrossCurve.Titles[0].Font = new Font("Microsoft Sans Serif", 16);
            crtGZCrossCurve.Titles[1].Font = new Font("Microsoft Sans Serif", 16);

            crtKNCrossCurve.Titles.Clear();
            crtKNCrossCurve.Titles.Add("Kapal Bulk Carrier - MV TIRAM");
            crtKNCrossCurve.Titles.Add("Kurva Silang KN");
            crtKNCrossCurve.Titles[0].Font = new Font("Microsoft Sans Serif", 16);
            crtKNCrossCurve.Titles[1].Font = new Font("Microsoft Sans Serif", 16);
            #endregion

            // Initialize Ship Data
            StabilityCalculator.InitializeShipData();

            SettingInputValue();

            DrawHydrostaticCurve();

            // Input 1 : displacement, draft
            cbbDispOrDraft.SelectedIndex = 0;

            // Water type, 0 = Sea Water, 1 = Fresh Water
            cbbWaterType.SelectedIndex = 1;

            // Transversal Graph, Marker and Line series selection
            for (int i = 0; i < 6; i++)
            {
                cbbMarkerSelect.Items.Add(crtTransversal.Series[i + 6].Name);
                cbbLineSelect.Items.Add(crtTransversal.Series[i].Name);
            }
            cbbMarkerSelect.SelectedIndex = 0;
            cbbLineSelect.SelectedIndex = 0;

            // HS curve, Marker and Line series selection
            for (int i = 0; i < crtHydrostaticCurve.Series.Count; i++)
            {
                cbbHSLineSelect.Items.Add(crtHydrostaticCurve.Series[i].Name);
            }
            cbbHSLineSelect.SelectedIndex = 0;
            cbxUseDispOrDraftReal.Checked = true;

            InitPractData();
        }

        private void crtLoadSideView_PrePaint(object sender, ChartPaintEventArgs e)
        {
            // algorithm to make chart always in correct aspect ratio, ssw 20140809
            float GraphX = crtLoadSideView.ChartAreas[0].InnerPlotPosition.X * crtLoadSideView.Width / 100;
            float GraphY = crtLoadSideView.ChartAreas[0].InnerPlotPosition.Y * crtLoadSideView.Height / 100;
            float GraphR = crtLoadSideView.ChartAreas[0].InnerPlotPosition.Right * crtLoadSideView.Width / 100;
            float GraphB = crtLoadSideView.ChartAreas[0].InnerPlotPosition.Bottom * crtLoadSideView.Height / 100;

            float TitleHeight = 0;
            if (crtLoadSideView.Titles.Count > 1)
            {
                for (int i = 0; i < crtLoadSideView.Titles.Count; i++)
                {
                    TitleHeight += crtLoadSideView.Titles[i].Font.Height;
                }
            }

            float GraphWidth = crtLoadSideView.ChartAreas[0].InnerPlotPosition.Width * crtLoadSideView.Width / 100;
            float GraphHeight = crtLoadSideView.ChartAreas[0].InnerPlotPosition.Height * crtLoadSideView.Height / 100 - TitleHeight;
            double AxisYLength = crtLoadSideView.ChartAreas[0].AxisY.Maximum - crtLoadSideView.ChartAreas[0].AxisY.Minimum;
            double AxisXLength = 100 * Math.Round(GraphWidth / GraphHeight * AxisYLength / 100);

            crtLoadSideView.ChartAreas[0].AxisX.Minimum = (int)(-1 * AxisXLength / 2);
            crtLoadSideView.ChartAreas[0].AxisX.Maximum = (int)(+1 * AxisXLength / 2);

            crtLoadSideView.ChartAreas[0].AxisX.Interval = 150;
        }

        private void crtLoadFrontView_PrePaint(object sender, ChartPaintEventArgs e)
        {
            // algorithm to make chart always in correct aspect ratio, ssw 20140809
            float GraphX = crtLoadFrontView.ChartAreas[0].InnerPlotPosition.X * crtLoadFrontView.Width / 100;
            float GraphY = crtLoadFrontView.ChartAreas[0].InnerPlotPosition.Y * crtLoadFrontView.Height / 100;
            float GraphR = crtLoadFrontView.ChartAreas[0].InnerPlotPosition.Right * crtLoadFrontView.Width / 100;
            float GraphB = crtLoadFrontView.ChartAreas[0].InnerPlotPosition.Bottom * crtLoadFrontView.Height / 100;

            float TitleHeight = 0;
            if (crtLoadFrontView.Titles.Count > 1)
            {
                for (int i = 0; i < crtLoadFrontView.Titles.Count; i++)
                {
                    TitleHeight += crtLoadFrontView.Titles[i].Font.Height;
                }
            }

            float GraphWidth = crtLoadFrontView.ChartAreas[0].InnerPlotPosition.Width * crtLoadFrontView.Width / 100;
            float GraphHeight = crtLoadFrontView.ChartAreas[0].InnerPlotPosition.Height * crtLoadFrontView.Height / 100 - TitleHeight;
            double AxisYLength = crtLoadFrontView.ChartAreas[0].AxisY.Maximum - crtLoadFrontView.ChartAreas[0].AxisY.Minimum;
            double AxisXLength = 50 * Math.Round(GraphWidth / GraphHeight * AxisYLength / 50);

            crtLoadFrontView.ChartAreas[0].AxisX.Minimum = (int)(-1 * AxisXLength / 2);
            crtLoadFrontView.ChartAreas[0].AxisX.Maximum = (int)(+1 * AxisXLength / 2);

            crtLoadFrontView.ChartAreas[0].AxisX.Interval = 50;
        }

        private void crtLoadTopView_PrePaint(object sender, ChartPaintEventArgs e)
        {
            // algorithm to make chart always in correct aspect ratio, ssw 20140809
            float GraphX = crtLoadTopView.ChartAreas[0].InnerPlotPosition.X * crtLoadTopView.Width / 100;
            float GraphY = crtLoadTopView.ChartAreas[0].InnerPlotPosition.Y * crtLoadTopView.Height / 100;
            float GraphR = crtLoadTopView.ChartAreas[0].InnerPlotPosition.Right * crtLoadTopView.Width / 100;
            float GraphB = crtLoadTopView.ChartAreas[0].InnerPlotPosition.Bottom * crtLoadTopView.Height / 100;

            float TitleHeight = 0;
            if (crtLoadTopView.Titles.Count > 1)
            {
                for (int i = 0; i < crtLoadTopView.Titles.Count; i++)
                {
                    TitleHeight += crtLoadTopView.Titles[i].Font.Height;
                }
            }

            float GraphWidth = crtLoadTopView.ChartAreas[0].InnerPlotPosition.Width * crtLoadTopView.Width / 100;
            float GraphHeight = crtLoadTopView.ChartAreas[0].InnerPlotPosition.Height * crtLoadTopView.Height / 100 - TitleHeight;
            double AxisYLength = crtLoadTopView.ChartAreas[0].AxisY.Maximum - crtLoadTopView.ChartAreas[0].AxisY.Minimum;
            double AxisXLength = 100 * Math.Round(GraphWidth / GraphHeight * AxisYLength / 100);

            crtLoadTopView.ChartAreas[0].AxisX.Minimum = (int)(-1 * AxisXLength / 2);
            crtLoadTopView.ChartAreas[0].AxisX.Maximum = (int)(+1 * AxisXLength / 2);

            crtLoadTopView.ChartAreas[0].AxisX.Interval = 150;
        }

        private void crtLongitudinal_PrePaint(object sender, ChartPaintEventArgs e)
        {
            // algorithm to make chart always in correct aspect ratio, ssw 20140809
            float GraphX = crtLongitudinal.ChartAreas[0].InnerPlotPosition.X * crtLongitudinal.Width / 100;
            float GraphY = crtLongitudinal.ChartAreas[0].InnerPlotPosition.Y * crtLongitudinal.Height / 100;
            float GraphR = crtLongitudinal.ChartAreas[0].InnerPlotPosition.Right * crtLongitudinal.Width / 100;
            float GraphB = crtLongitudinal.ChartAreas[0].InnerPlotPosition.Bottom * crtLongitudinal.Height / 100;

            float TitleHeight = 0;
            if (crtLongitudinal.Titles.Count > 1)
            {
                for (int i = 0; i < crtLongitudinal.Titles.Count; i++)
                {
                    TitleHeight += crtLongitudinal.Titles[i].Font.Height;
                }
            }

            float GraphWidth = crtLongitudinal.ChartAreas[0].InnerPlotPosition.Width * crtLongitudinal.Width / 100;
            float GraphHeight = crtLongitudinal.ChartAreas[0].InnerPlotPosition.Height * crtLongitudinal.Height / 100 - TitleHeight;
            double AxisYLength = crtLongitudinal.ChartAreas[0].AxisY.Maximum - crtLongitudinal.ChartAreas[0].AxisY.Minimum;
            double AxisXLength = 100 * Math.Round(GraphWidth / GraphHeight * AxisYLength / 100);

            crtLongitudinal.ChartAreas[0].AxisX.Minimum = (int)(-1 * AxisXLength / 2);
            crtLongitudinal.ChartAreas[0].AxisX.Maximum = (int)(+1 * AxisXLength / 2);

            crtLongitudinal.ChartAreas[0].AxisX.Interval = 100;
        }

        private void crtTransversal_PrePaint(object sender, ChartPaintEventArgs e)
        {
            // algorithm to make chart always in correct aspect ratio, ssw 20140809
            float GraphX = crtTransversal.ChartAreas[0].InnerPlotPosition.X * crtTransversal.Width / 100;
            float GraphY = crtTransversal.ChartAreas[0].InnerPlotPosition.Y * crtTransversal.Height / 100;
            float GraphR = crtTransversal.ChartAreas[0].InnerPlotPosition.Right * crtTransversal.Width / 100;
            float GraphB = crtTransversal.ChartAreas[0].InnerPlotPosition.Bottom * crtTransversal.Height / 100;

            float TitleHeight = 0;
            if (crtTransversal.Titles.Count > 1)
            {
                for (int i = 0; i < crtTransversal.Titles.Count; i++)
                {
                    TitleHeight += crtTransversal.Titles[i].Font.Height;
                }
            }

            float GraphWidth = crtTransversal.ChartAreas[0].InnerPlotPosition.Width * crtTransversal.Width / 100;
            float GraphHeight = crtTransversal.ChartAreas[0].InnerPlotPosition.Height * crtTransversal.Height / 100 - TitleHeight;
            double AxisYLength = crtTransversal.ChartAreas[0].AxisY.Maximum - crtTransversal.ChartAreas[0].AxisY.Minimum;
            double AxisXLength = 50 * Math.Round(GraphWidth / GraphHeight * AxisYLength / 50);

            crtTransversal.ChartAreas[0].AxisX.Minimum = (int)(-1 * AxisXLength / 2);
            crtTransversal.ChartAreas[0].AxisX.Maximum = (int)(+1 * AxisXLength / 2);

            crtTransversal.ChartAreas[0].AxisX.Interval = 50;
        }

        private void nudBebanTMMB_ValueChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudBebanTMMD_ValueChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudBebanTKK_ValueChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudBebanTNT_ValueChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void scbPosisiTMMB_Scroll(object sender, ScrollEventArgs e)
        {
            nudPosisiTMMB.Value = scbPosisiTMMB.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void scbPosisiTMMD_Scroll(object sender, ScrollEventArgs e)
        {
            nudPosisiTMMD.Value = scbPosisiTMMD.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void scbPosisiTKK_Scroll(object sender, ScrollEventArgs e)
        {
            nudPosisiTKK.Value = scbPosisiTKK.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void scbPosisiTNT_Scroll(object sender, ScrollEventArgs e)
        {
            nudPosisiTNT.Value = scbPosisiTNT.Minimum + scbPosisiTNT.Maximum - scbPosisiTNT.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudPosisiTMMB_ValueChanged(object sender, EventArgs e)
        {
            scbPosisiTMMB.Value = (int)nudPosisiTMMB.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudPosisiTMMD_ValueChanged(object sender, EventArgs e)
        {
            scbPosisiTMMD.Value = (int)nudPosisiTMMD.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudPosisiTKK_ValueChanged(object sender, EventArgs e)
        {
            scbPosisiTKK.Value = (int)nudPosisiTKK.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudPosisiTNT_ValueChanged(object sender, EventArgs e)
        {
            scbPosisiTNT.Value = scbPosisiTNT.Minimum + scbPosisiTNT.Maximum - (int)nudPosisiTNT.Value;
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();

            SetPracValue();
        }

        private void nudHSLineWidth_ValueChanged(object sender, EventArgs e)
        {
            int i = cbbHSLineSelect.SelectedIndex;
            crtHydrostaticCurve.Series[i].BorderWidth = (int)nudHSLineWidth.Value;
        }

        private void cbbDispOrDraft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDispOrDraft.SelectedIndex == 0) // input = displacement (kgf)
            {
                nudDispOrDraftVal.Minimum = 1;   // disp min =    1 kg
                nudDispOrDraftVal.Maximum = 90; // disp max =  150 kg
                scbDispOrDraftVal.Minimum = (int)nudDispOrDraftVal.Minimum * 10;
                scbDispOrDraftVal.Maximum = (int)nudDispOrDraftVal.Maximum * 10;
                lblInput1LowerVal.Text = (scbDispOrDraftVal.Minimum / 10).ToString() + " kg";
                lblInput1MiddleVal.Text = (scbDispOrDraftVal.Maximum / 20).ToString() + " kg";
                lblInput1UpperVal.Text = (scbDispOrDraftVal.Maximum / 10).ToString() + " kg";
                lblDraftValue.Text = "Draft (mm)";
                lblDraftRealValue.Text = "Draft (m)";
            }
            else // input = draft (mm)
            {
                nudDispOrDraftVal.Minimum = 1;   // draft min =    1 mm
                nudDispOrDraftVal.Maximum = 150; // draft max =  170 mm
                scbDispOrDraftVal.Minimum = (int)nudDispOrDraftVal.Minimum * 10;
                scbDispOrDraftVal.Maximum = (int)nudDispOrDraftVal.Maximum * 10;
                lblInput1LowerVal.Text = (scbDispOrDraftVal.Minimum / 10).ToString() + " mm";
                lblInput1MiddleVal.Text = (scbDispOrDraftVal.Maximum / 20).ToString() + " mm";
                lblInput1UpperVal.Text = (scbDispOrDraftVal.Maximum / 10).ToString() + " mm";
                lblDraftValue.Text = "Displ. (kgf)";
                lblDraftRealValue.Text = "Displ. (ton)";
            }
        }

        private void cbxUseDispOrDraftReal_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();
        }

        private void cbxUseHeelReal_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();
        }

        private void cbxUseTrimReal_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();
        }

        private void cbxUseKGReal_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCG_and_Attitude();
            DrawGZandKNCurves();
        }

        private void pnlHSBGColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnlHSBGColor.BackColor;
            colorDialog1.ShowDialog();
            pnlHSBGColor.BackColor = colorDialog1.Color;
            crtHydrostaticCurve.ChartAreas[0].BackColor = colorDialog1.Color;
            crtHydrostaticCurve.Legends[0].BackColor = colorDialog1.Color;
        }

        private void pnlHSLineColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnlHSLineColor.BackColor;
            colorDialog1.ShowDialog();
            pnlHSLineColor.BackColor = colorDialog1.Color;
            int i = cbbHSLineSelect.SelectedIndex;
            crtHydrostaticCurve.Series[i].Color = colorDialog1.Color;
        }

        private void pnlHSGridColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnlHSGridColor.BackColor;
            colorDialog1.ShowDialog();
            pnlHSGridColor.BackColor = colorDialog1.Color;
            crtHydrostaticCurve.ChartAreas[0].Axes[0].MajorGrid.LineColor = colorDialog1.Color;
            crtHydrostaticCurve.ChartAreas[0].Axes[1].MajorGrid.LineColor = colorDialog1.Color;
        }

        private void pnlHSLegendTextColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnlHSLegendTextColor.BackColor;
            colorDialog1.ShowDialog();
            pnlHSLegendTextColor.BackColor = colorDialog1.Color;
            crtHydrostaticCurve.Legends[0].ForeColor = colorDialog1.Color;
        }

        private void cbbHSLineSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbHSLineSelect.SelectedIndex;
            pnlHSLineColor.BackColor = crtHydrostaticCurve.Series[i].Color;
        }

        private void rbnGZStaticStability_CheckedChanged(object sender, EventArgs e)
        {
            DrawGZandKNCurves();
        }

        private void rbnKNStaticStability_CheckedChanged(object sender, EventArgs e)
        {
            DrawGZandKNCurves();
        }

        private void rbnGZCrossCurve_CheckedChanged(object sender, EventArgs e)
        {
            DrawGZandKNCurves();
        }

        private void rbnKNCrossCurve_CheckedChanged(object sender, EventArgs e)
        {
            DrawGZandKNCurves();
        }

        private void rbnGZatGivenDispAndKG_CheckedChanged(object sender, EventArgs e)
        {
            DrawGZandKNCurves();
        }

        private void rbnKNatGivenDispAndKG_CheckedChanged(object sender, EventArgs e)
        {
            DrawGZandKNCurves();
        }

        private void scbDispOrDraftVal_Scroll(object sender, ScrollEventArgs e)
        {
            if (cbxUseDispOrDraftReal.Checked)
            {
                scbDispOrDraftVal.Value = (int)(dWeightTotalShip * 10);
                dInputVal = (double)scbDispOrDraftVal.Value / 10;
            }
            else
            {
                dInputVal = (double)scbDispOrDraftVal.Value / 10;
                dWeightTotalShip = dInputVal;
            }
            nudDispOrDraftVal.Value = (decimal)dInputVal;
            CalculateTransverseHydrostatic();
            CalculateLongitudinalHydrostatic();
            DrawGZandKNCurves(); // 20150908
        }

        private void scbHeelVal_Scroll(object sender, ScrollEventArgs e)
        {
            if (cbxUseHeelReal.Checked)
            {
                scbHeelVal.Value = (int)(heel_angle * 100);
                dHeelVal = heel_angle;
            }
            else
            {
                dHeelVal = (double)scbHeelVal.Value / 100;
            }
            nudHeelVal.Value = (decimal)dHeelVal;
            CalculateTransverseHydrostatic();
            DrawGZandKNCurves(); // 20150908
        }

        private void nudDispOrDraftVal_ValueChanged(object sender, EventArgs e)
        {
            if (cbxUseDispOrDraftReal.Checked)
            {
                nudDispOrDraftVal.Value = (decimal)dWeightTotalShip;
                dInputVal = (double)nudDispOrDraftVal.Value;
            }
            else
            {
                dInputVal = (double)nudDispOrDraftVal.Value;
                dWeightTotalShip = dInputVal;
            }
            scbDispOrDraftVal.Value = (int)(dInputVal * 10);
            CalculateTransverseHydrostatic();
            CalculateLongitudinalHydrostatic();
            DrawGZandKNCurves(); // 20150908

            SendShipDataTo3D();
        }

        private void nudHeelVal_ValueChanged(object sender, EventArgs e)
        {
            if (cbxUseHeelReal.Checked)
            {
                nudHeelVal.Value = (decimal)(heel_angle);
                dHeelVal = heel_angle;
            }
            else
            {
                dHeelVal = (double)nudHeelVal.Value;
            }
            scbHeelVal.Value = (int)(dHeelVal * 100);
            CalculateTransverseHydrostatic();
            DrawGZandKNCurves(); // 20150908

            SendShipDataTo3D();
        }

        private void scbTrimVal_Scroll(object sender, ScrollEventArgs e)
        {
            if (cbxUseTrimReal.Checked)
            {
                scbTrimVal.Value = (int)(trim_angle * 100);
                dTrimVal = trim_angle;
            }
            else
            {
                dTrimVal = (double)scbTrimVal.Value / 100;
            }
            nudTrimVal.Value = (decimal)dTrimVal;
            CalculateLongitudinalHydrostatic();
        }

        private void nudTrimVal_ValueChanged(object sender, EventArgs e)
        {
            if (cbxUseTrimReal.Checked)
            {
                nudTrimVal.Value = (decimal)(trim_angle);
                dTrimVal = trim_angle;
            }
            else
            {
                dTrimVal = (double)nudTrimVal.Value;
            }
            scbTrimVal.Value = (int)(dTrimVal * 100);
            CalculateLongitudinalHydrostatic();

            SendShipDataTo3D();
        }

        private void tabControlGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlGraph.SelectedIndex == 1) // tab transversal
            {
                if (!cbxUseHeelReal.Checked) scbHeelVal.Enabled = true;
                CalculateTransverseHydrostatic();
            }
            else if (tabControlGraph.SelectedIndex == 2) // tab Longitudinal
            {
                if (!cbxUseTrimReal.Checked) scbTrimVal.Enabled = true;
                CalculateLongitudinalHydrostatic();
            }
        }

        private void scbKGVal_Scroll(object sender, ScrollEventArgs e)
        {
            if (cbxUseKGReal.Checked)
            {
                scbKGVal.Value = (int)(zCGTotalShip * 10);
            }
            else
            {
                zCGTotalShip = (double)scbKGVal.Value / 10;
            }

            nudKGVal.Value = (decimal)zCGTotalShip;

            CalculateTransverseHydrostatic();
            CalculateLongitudinalHydrostatic();
            DrawGZandKNCurves(); // 20150908
        }

        private void nudKGVal_ValueChanged(object sender, EventArgs e)
        {
            if (cbxUseKGReal.Checked)
            {
                nudKGVal.Value = (decimal)(zCGTotalShip);
            }
            else
            {
                zCGTotalShip = (double)nudKGVal.Value;
            }

            scbKGVal.Value = (int)(zCGTotalShip * 10);

            CalculateTransverseHydrostatic();
            CalculateLongitudinalHydrostatic();
            DrawGZandKNCurves(); // 20150908
        }

        private void cbxMarkerShow_CheckedChanged(object sender, EventArgs e)
        {
            int i = cbbMarkerSelect.SelectedIndex + 6;
            if (cbxMarkerShow.Checked)
            {
                crtTransversal.Series[i].MarkerSize = (int)nudMarkerSize.Value;
            }
            else
            {
                crtTransversal.Series[i].MarkerSize = 0;
            }
        }

        private void cbbMarkerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbMarkerSelect.SelectedIndex + 6;
            if (crtTransversal.Series[i].MarkerSize == 0)
            {
                cbxMarkerShow.Checked = false;
            }
            else
            {
                nudMarkerSize.Value = (decimal)crtTransversal.Series[i].MarkerSize;
                cbxMarkerShow.Checked = true;
            }

            pnlMarkerColor.BackColor = crtTransversal.Series[i].Color;
        }

        private void nudMarkerSize_ValueChanged(object sender, EventArgs e)
        {
            int i = cbbMarkerSelect.SelectedIndex + 6;
            crtTransversal.Series[i].MarkerSize = (int)nudMarkerSize.Value;
        }

        private void cbbLineSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbLineSelect.SelectedIndex;
            if (crtTransversal.Series[i].BorderWidth == 0)
            {
                cbxLineShow.Checked = false;
            }
            else
            {
                nudLineWidth.Value = (decimal)crtTransversal.Series[i].BorderWidth;
                cbxLineShow.Checked = true;
            }
            pnlLineColor.BackColor = crtTransversal.Series[i].Color;
        }

        private void cbxLineShow_CheckedChanged(object sender, EventArgs e)
        {
            int i = cbbLineSelect.SelectedIndex;
            if (cbxLineShow.Checked)
            {
                crtTransversal.Series[i].BorderWidth = (int)nudLineWidth.Value;
            }
            else
            {
                crtTransversal.Series[i].BorderWidth = 0;
            }
        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            int i = cbbLineSelect.SelectedIndex;
            crtTransversal.Series[i].BorderWidth = (int)nudLineWidth.Value;
        }

        private void pnlMarkerColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnlMarkerColor.BackColor;
            colorDialog1.ShowDialog();
            pnlMarkerColor.BackColor = colorDialog1.Color;
            int i = cbbMarkerSelect.SelectedIndex + 6;
            crtTransversal.Series[i].MarkerColor = colorDialog1.Color;
            crtTransversal.Series[i].LabelForeColor = colorDialog1.Color;
        }

        private void pnlLineColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnlLineColor.BackColor;
            colorDialog1.ShowDialog();
            pnlLineColor.BackColor = colorDialog1.Color;
            int i = cbbLineSelect.SelectedIndex;
            crtTransversal.Series[i].Color = colorDialog1.Color;
        }

        private void SettingInputValue()
        {
            if (cbbDispOrDraft.SelectedIndex == 0) // input = displacement (kgf)
            {
                nudDispOrDraftVal.Minimum = 1;   // disp min =    1 kg
                nudDispOrDraftVal.Maximum = 90; // disp max =  150 kg
                scbDispOrDraftVal.Minimum = (int)nudDispOrDraftVal.Minimum * 10;
                scbDispOrDraftVal.Maximum = (int)nudDispOrDraftVal.Maximum * 10;
                lblInput1LowerVal.Text = (scbDispOrDraftVal.Minimum / 10).ToString() + " kg";
                lblInput1MiddleVal.Text = (scbDispOrDraftVal.Maximum / 20).ToString() + " kg";
                lblInput1UpperVal.Text = (scbDispOrDraftVal.Maximum / 10).ToString() + " kg";
            }
            else // input = draft (mm)
            {
                nudDispOrDraftVal.Minimum = 1;   // draft min =    1 mm
                nudDispOrDraftVal.Maximum = 150; // draft max =  170 mm
                scbDispOrDraftVal.Minimum = (int)nudDispOrDraftVal.Minimum * 10;
                scbDispOrDraftVal.Maximum = (int)nudDispOrDraftVal.Maximum * 10;
                lblInput1LowerVal.Text = (scbDispOrDraftVal.Minimum / 10).ToString() + " mm";
                lblInput1MiddleVal.Text = (scbDispOrDraftVal.Maximum / 20).ToString() + " mm";
                lblInput1UpperVal.Text = (scbDispOrDraftVal.Maximum / 10).ToString() + " mm";
            }
        }

        private void DrawHydrostaticCurve()
        {
            for (int i = 0; i < StabilityCalculator.lbtData_BC.Count(); i++)
            {
                lcb_series.Points.AddXY(StabilityCalculator.lbtData_BC[i] * K_lcb, StabilityCalculator.drfData_BC[i]); // LCB
                lcf_series.Points.AddXY(StabilityCalculator.lflData_BC[i] * K_lcf, StabilityCalculator.drfData_BC[i]); // LCF 
                dsp_series.Points.AddXY(StabilityCalculator.dspData_BC[i] * K_dsp, StabilityCalculator.drfData_BC[i]); // Displacement 
                kbt_series.Points.AddXY(StabilityCalculator.kbtData_BC[i] * K_kbt, StabilityCalculator.drfData_BC[i]); // KBT
                kmt_series.Points.AddXY(StabilityCalculator.kmtData_BC[i] * K_kmt, StabilityCalculator.drfData_BC[i]); // KMT
                mtt_series.Points.AddXY(StabilityCalculator.mttData_BC[i] * K_mtt, StabilityCalculator.drfData_BC[i]); // MTCT
                wti_series.Points.AddXY(StabilityCalculator.wtiData_BC[i] * K_wti, StabilityCalculator.drfData_BC[i]); // TPC
                cob_series.Points.AddXY(StabilityCalculator.cobData_BC[i] * K_cob, StabilityCalculator.drfData_BC[i]); // Cb = Block Coefficient
                cop_series.Points.AddXY(StabilityCalculator.copData_BC[i] * K_cop, StabilityCalculator.drfData_BC[i]); // Cp = Prismatic Coefficient
            }
        }

        private void CalculateCG_and_Attitude()
        {
            mTMMB = (double)nudBebanTMMB.Value;
            mTMMD = (double)nudBebanTMMD.Value;
            mTKK = (double)nudBebanTKK.Value;
            mTNT = (double)nudBebanTNT.Value;

            double ship_scale = StabilityCalculator.ship_scale;
            double weight_scale = ship_scale * ship_scale * ship_scale / 1000;
            mTMMB_real = mTMMB * weight_scale; // in ton
            mTMMD_real = mTMMD * weight_scale; // in ton
            mTKK_real = mTKK * weight_scale; // in ton
            mTNT_real = mTNT * weight_scale; // in ton

            double dWeightTotalLoad = mTMMB + mTMMD + mTKK + mTNT;
            dWeightTotalShip = StabilityCalculator.dWeightLightShip + dWeightTotalLoad;

            double dWeightLightShip_Real = StabilityCalculator.dWeightLightShip * weight_scale;
            double dWeightTotalLoad_Real = dWeightTotalLoad * weight_scale;
            double dWeightTotalShip_Real = dWeightTotalShip * weight_scale;

            // Check total load
            if (dWeightTotalLoad <= 0)
            {
                txbInfoMuatan.ForeColor = Color.Red;
                txbInfoMuatan.Text = "Muatan Kosong !!!";
            }
            else
            {
                txbInfoMuatan.ForeColor = Color.Green;
                txbInfoMuatan.Text = "Muatan Total = " + dWeightTotalLoad.ToString("F1") + " kg = "
                    + dWeightTotalLoad_Real.ToString("F1") + " ton";
            }
            txbBobotTotal.ForeColor = Color.Blue;
            txbBobotTotal.Text = "Bobot Total Kapal = " + dWeightTotalShip.ToString("F1") + " kg = "
                + dWeightTotalShip_Real.ToString("F1") + " ton";

            TMMB_Pos.x = (double)nudPosisiTMMB.Value - 1096.5;
            TMMB_Pos.y = 0;
            TMMB_Pos.z = 106 + 0.5 * mTMMB * 10;

            TMMD_Pos.x = (double)nudPosisiTMMD.Value - 1096.5;
            TMMD_Pos.y = 0;
            TMMD_Pos.z = 106 + 0.5 * mTMMD * 10;

            TKK_Pos.x = 1100 - 1096.5;
            TKK_Pos.y = (double)nudPosisiTKK.Value;
            TKK_Pos.z = 275 + 0.5 * mTKK * 10;

            TNT_Pos.x = 1225 - 1096.5;
            TNT_Pos.y = 0;
            TNT_Pos.z = (double)nudPosisiTNT.Value + 43 + 0.5 * mTNT * 15;

            //TMMB_Pos_Real.x = TMMB_Pos.x * ship_scale / 1000; // in meter
            TMMB_Pos_Real.x = (double)nudPosisiTMMB.Value * ship_scale / 1000; // in meter
            TMMB_Pos_Real.y = TMMB_Pos.y * ship_scale / 1000; // in meter
            TMMB_Pos_Real.z = TMMB_Pos.z * ship_scale / 1000; // in meter

            //TMMD_Pos_Real.x = TMMD_Pos.x * ship_scale / 1000; // in meter
            TMMD_Pos_Real.x = (double)nudPosisiTMMD.Value * ship_scale / 1000; // in meter
            TMMD_Pos_Real.y = TMMD_Pos.y * ship_scale / 1000; // in meter
            TMMD_Pos_Real.z = TMMD_Pos.z * ship_scale / 1000; // in meter

            TKK_Pos_Real.x = TKK_Pos.x * ship_scale / 1000; // in meter
            TKK_Pos_Real.y = TKK_Pos.y * ship_scale / 1000; // in meter
            TKK_Pos_Real.z = TKK_Pos.z * ship_scale / 1000; // in meter

            TNT_Pos_Real.x = TNT_Pos.x * ship_scale / 1000; // in meter
            TNT_Pos_Real.y = TNT_Pos.y * ship_scale / 1000; // in meter
            TNT_Pos_Real.z = TNT_Pos.z * ship_scale / 1000; // in meter

            if (dWeightTotalLoad > 0)
            {
                xCGTotalLoad = (TMMB_Pos.x * mTMMB + TMMD_Pos.x * mTMMD + TKK_Pos.x * mTKK + TNT_Pos.x * mTNT) / dWeightTotalLoad;
                yCGTotalLoad = (TMMB_Pos.y * mTMMB + TMMD_Pos.y * mTMMD + TKK_Pos.y * mTKK + TNT_Pos.y * mTNT) / dWeightTotalLoad;
                zCGTotalLoad = (TMMB_Pos.z * mTMMB + TMMB_Pos.z * mTMMD + TKK_Pos.z * mTKK + TNT_Pos.z * mTNT) / dWeightTotalLoad;
            }

            xCGTotalShip = (xCGTotalLoad * dWeightTotalLoad + StabilityCalculator.xCGLightShip * StabilityCalculator.dWeightLightShip) / dWeightTotalShip;
            yCGTotalShip = (yCGTotalLoad * dWeightTotalLoad + StabilityCalculator.yCGLightShip * StabilityCalculator.dWeightLightShip) / dWeightTotalShip;
            zCGTotalShip = (zCGTotalLoad * dWeightTotalLoad + StabilityCalculator.zCGLightShip * StabilityCalculator.dWeightLightShip) / dWeightTotalShip;

            StabilityCalculator.CalculationHeelAndTrim(dWeightTotalShip, xCGTotalShip, yCGTotalShip, zCGTotalShip, ref heel_angle, ref trim_angle);

            // calculate transverse and longitudinal stability
            if (cbxUseDispOrDraftReal.Checked)
            {
                scbDispOrDraftVal.Value = (int)(dWeightTotalShip * 10);
                nudDispOrDraftVal.Value = (decimal)(scbDispOrDraftVal.Value / 10);
            }

            if (cbxUseHeelReal.Checked)
            {
                scbHeelVal.Value = (int)(heel_angle * 100);
                nudHeelVal.Value = (decimal)(heel_angle);
            }

            if (cbxUseTrimReal.Checked)
            {
                scbTrimVal.Value = (int)(trim_angle * 100);
                nudTrimVal.Value = (decimal)(trim_angle);
            }

            if (cbxUseKGReal.Checked)
            {
                scbKGVal.Value = (int)(zCGTotalShip * 10);
                nudKGVal.Value = (decimal)zCGTotalShip;
            }

            // Show Results
            txbGmx.Text = xCGTotalLoad.ToString("F1");
            txbGmy.Text = yCGTotalLoad.ToString("F1");
            txbGmz.Text = zCGTotalLoad.ToString("F1");

            txbGx.Text = xCGTotalShip.ToString("F1");
            txbGy.Text = yCGTotalShip.ToString("F1");
            txbGz.Text = zCGTotalShip.ToString("F1");

            // Draw position
            tmmb_xy_point_series.Points.Clear();
            tmmb_xz_point_series.Points.Clear();
            tmmb_yz_point_series.Points.Clear();

            tmmb_xy_point_series.Points.AddXY(TMMB_Pos.x, TMMB_Pos.y);
            tmmb_xz_point_series.Points.AddXY(TMMB_Pos.x, TMMB_Pos.z);
            tmmb_yz_point_series.Points.AddXY(TMMB_Pos.y, TMMB_Pos.z);

            tmmd_xy_point_series.Points.Clear();
            tmmd_xz_point_series.Points.Clear();
            tmmd_yz_point_series.Points.Clear();

            tmmd_xy_point_series.Points.AddXY(TMMD_Pos.x, TMMD_Pos.y);
            tmmd_xz_point_series.Points.AddXY(TMMD_Pos.x, TMMD_Pos.z);
            tmmd_yz_point_series.Points.AddXY(TMMD_Pos.y, TMMD_Pos.z);

            tkk_xy_point_series.Points.Clear();
            tkk_xz_point_series.Points.Clear();
            tkk_yz_point_series.Points.Clear();

            tkk_xy_point_series.Points.AddXY(TKK_Pos.x, TKK_Pos.y);
            tkk_xz_point_series.Points.AddXY(TKK_Pos.x, TKK_Pos.z);
            tkk_yz_point_series.Points.AddXY(TKK_Pos.y, TKK_Pos.z);

            tnt_xy_point_series.Points.Clear();
            tnt_xz_point_series.Points.Clear();
            tnt_yz_point_series.Points.Clear();

            tnt_xy_point_series.Points.AddXY(TNT_Pos.x, TNT_Pos.y);
            tnt_xz_point_series.Points.AddXY(TNT_Pos.x, TNT_Pos.z);
            tnt_yz_point_series.Points.AddXY(TNT_Pos.y, TNT_Pos.z);

            // show real ship values
            txbBebanTMMB.Text = mTMMB_real.ToString("F2");
            txbPosisiTMMB.Text = TMMB_Pos_Real.x.ToString("F2");
            txbBebanTMMD.Text = mTMMD_real.ToString("F2");
            txbPosisiTMMD.Text = TMMD_Pos_Real.x.ToString("F2");
            txbBebanTKK.Text = mTKK_real.ToString("F2");
            txbPosisiTKK.Text = TKK_Pos_Real.y.ToString("F2");
            txbBebanTNT.Text = mTNT_real.ToString("F2");
            txbPosisiTNT.Text = TNT_Pos_Real.z.ToString("F2");

        }

        private void CalculateTransverseHydrostatic()
        {
            double ship_scale = StabilityCalculator.ship_scale;
            double weight_scale = ship_scale * ship_scale * ship_scale / 1000;

            dInputVal = (double)scbDispOrDraftVal.Value / 10;
            if (cbbDispOrDraft.SelectedIndex == 0) // input1 = displacement
            {
                dDispVal = dInputVal;
                dInputVal_Real = dInputVal * weight_scale; // 20160201
                dDraftVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.dspData_BC, StabilityCalculator.T1D_drfData);
                dWTIVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.dspData_BC, StabilityCalculator.T1D_wtiData);
                dMTTVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.dspData_BC, StabilityCalculator.T1D_mttData);
                dCOBVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.dspData_BC, StabilityCalculator.T1D_cobData);
                dCOPVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.dspData_BC, StabilityCalculator.T1D_copData);
                dOutputVal = dDraftVal;
                dOutputVal_Real = dOutputVal * ship_scale / 1000; // 20160128
            }
            else // input1 = draft
            {
                dDraftVal = dInputVal;
                dInputVal_Real = dInputVal * ship_scale / 1000; // 20160201
                dDispVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.T1D_drfData, StabilityCalculator.dspData_BC);
                dWTIVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.T1D_drfData, StabilityCalculator.T1D_wtiData);
                dMTTVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.T1D_drfData, StabilityCalculator.T1D_mttData);
                dCOBVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.T1D_drfData, StabilityCalculator.T1D_cobData);
                dCOPVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.T1D_drfData, StabilityCalculator.T1D_copData);
                dOutputVal = dDispVal;
                dOutputVal_Real = dOutputVal * weight_scale; // 20160128
            }

            dTCBVal = Math.Sign(dHeelVal) * StabilityCalculator.Interpolate2D(Math.Abs(dHeelVal), dDispVal, StabilityCalculator.T1D_helData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_tbtData);
            dVCBVal = StabilityCalculator.Interpolate2D(Math.Abs(dHeelVal), dDispVal, StabilityCalculator.T1D_helData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_vbtData);
            dKMTVal = StabilityCalculator.Interpolate2D(Math.Abs(dHeelVal), dDispVal, StabilityCalculator.T1D_helData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_kmtData);
            dBMTVal = StabilityCalculator.Interpolate2D(Math.Abs(dHeelVal), dDispVal, StabilityCalculator.T1D_helData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_bmtData);

            for (int i = 0; i < crtTransversal.Series.Count; i++)
            {
                crtTransversal.Series[i].Points.Clear();
            }

            // define reference points: center of rotation
            double cX = 0;
            double cY = 0; // ini adalah titik yang tepat, ssw 20160217

            // define G point, in Ship coordinate, if cbxUseKGReal.Checked,ssw 20160106
            double Gx = yCGTotalShip;
            double Gy = zCGTotalShip;

            if (!cbxUseKGReal.Checked & !cbxUseHeelReal.Checked)
            {
                Gx = 0;
                Gy = StabilityCalculator.zCGLightShip;
            }

            // define K point, in Ship coordinate, point C as center of rotation, 20140819
            double Kx = 0;
            double Ky = 0;

            // define B point, in Ship coordinate
            double dHeelRad = dHeelVal * Math.PI / 180;
            double Bx = dTCBVal;
            double By = dVCBVal;

            // define N Point, in Ship coordinate
            dKNVal = Bx * Math.Cos(-dHeelRad) + By * Math.Sin(-dHeelRad);
            double Nx = dKNVal * Math.Cos(-dHeelRad);
            double Ny = dKNVal * Math.Sin(-dHeelRad);

            // define M point, in Ship coordinate, point C as center of rotation, 20140819
            double Mx = dKNVal * Math.Cos(-dHeelRad) - dKMTVal * Math.Sin(-dHeelRad);
            double My = dKNVal * Math.Sin(-dHeelRad) + dKMTVal * Math.Cos(-dHeelRad);

            // calculate KBT
            dKBTVal = -Bx * Math.Sin(-dHeelRad) + By * Math.Cos(-dHeelRad);

            // define G0 point (G lightship) in Ship coordinate, 20150827
            double G0x = StabilityCalculator.yCGLightShip;
            double G0y = StabilityCalculator.zCGLightShip;

            // define Gm point (G total load) in Ship coordinate, 20150827
            double Gmx = yCGTotalLoad;
            double Gmy = zCGTotalLoad;

            // calculate and draw GZ, calculate KN correction
            // note: if we calculate KN directly from kntData,
            // we will get inconsisten position of KN, so we need to correct it
            // ssw, 20150824
            // ssw, 20160111
            dGZVal = Gy * Math.Sin(-dHeelRad) - Bx * Math.Cos(-dHeelRad) - By * Math.Sin(-dHeelRad);
            double Zx = -dGZVal * Math.Cos(-dHeelRad);
            double Zy = Gy - dGZVal * Math.Sin(-dHeelRad);

            // point CLP (Center Line Plane)
            double Px = Kx;
            double Py = StabilityCalculator.shippoints_init[0].y;

            // do rotational transformation, point C as center of rotation
            StabilityCalculator.Rotate_point(ref Gx, ref Gy, cX, cY, dHeelVal);
            StabilityCalculator.Rotate_point(ref Mx, ref My, cX, cY, dHeelVal);
            StabilityCalculator.Rotate_point(ref Bx, ref By, cX, cY, dHeelVal);
            StabilityCalculator.Rotate_point(ref Nx, ref Ny, cX, cY, dHeelVal);
            StabilityCalculator.Rotate_point(ref Kx, ref Ky, cX, cY, dHeelVal);
            StabilityCalculator.Rotate_point(ref G0x, ref G0y, cX, cY, dHeelVal); // 20150827
            StabilityCalculator.Rotate_point(ref Gmx, ref Gmy, cX, cY, dHeelVal); // 20150827
            StabilityCalculator.Rotate_point(ref Zx, ref Zy, cX, cY, dHeelVal);   // 20160111
            StabilityCalculator.Rotate_point(ref Px, ref Py, cX, cY, dHeelVal);   // 20160217

            // draw rotated amidship, series 1, HULL FORM LINE
            StabilityCalculator.Point2D[] shippoints = (StabilityCalculator.Point2D[])StabilityCalculator.shippoints_init.Clone();
            for (int i = 0; i < shippoints.Length; i++)
            {
                StabilityCalculator.Rotate_point(ref shippoints[i].x, ref shippoints[i].y, cX, cY, dHeelVal);
                lat_shipform_series.Points.AddXY(shippoints[i].x, shippoints[i].y);

                SendShipDataTo3D();
            }

            // draw WL (waterline), series 2, WL line
            crtTransversal.Series[1].Points.AddXY(0.9 * crtTransversal.ChartAreas[0].AxisX.Minimum, dDraftVal); // series 4, waterline
            crtTransversal.Series[1].Points.AddXY(0.9 * crtTransversal.ChartAreas[0].AxisX.Maximum, dDraftVal); // series 4, waterline

            // draw KM line, series 3
            crtTransversal.Series[2].Points.AddXY(Mx, My);    // series 3, M point
            crtTransversal.Series[2].Points.AddXY(Kx, Ky);    // series 3, K point

            // draw BM line, series 4
            crtTransversal.Series[3].Points.AddXY(Mx, My);    // series 4, M point
            crtTransversal.Series[3].Points.AddXY(Bx, By);    // series 4, B point

            // draw GZ line, series 5
            crtTransversal.Series[4].Points.AddXY(Gx, Gy);    // series 5, G point
            crtTransversal.Series[4].Points.AddXY(Zx, Zy);    // series 5, Z point

            // draw KN line, series 6
            crtTransversal.Series[5].Points.AddXY(Kx, Ky);    // series 6, K point
            crtTransversal.Series[5].Points.AddXY(Nx, Ny);    // series 6, N point

            // draw KG line = Center Line Plane (CLP), 20160217, series 7
            crtTransversal.Series[6].Points.AddXY(Kx, Ky);    // series 7, K point
            crtTransversal.Series[6].Points.AddXY(Px, Py);    // series 7, P point

            // Draw G, B, M, Z point
            crtTransversal.Series[7].Points.AddXY(Gx, Gy);    // series 8, K point
            crtTransversal.Series[8].Points.AddXY(Bx, By);    // series 9, B point
            crtTransversal.Series[9].Points.AddXY(Mx, My);    // series 10, M point
            crtTransversal.Series[10].Points.AddXY(Zx, Zy);   // series 11, Z point
            crtTransversal.Series[11].Points.AddXY(Kx, Ky);   // series 12, K point
            crtTransversal.Series[12].Points.AddXY(Nx, Ny);   // series 13, N point
            crtTransversal.Series[13].Points.AddXY(G0x, G0y); // series 14, G0 point, 20150827
            crtTransversal.Series[14].Points.AddXY(Gmx, Gmy); // series 15, Gm point, 20150827

            txbGZValue.Text = dGZVal.ToString("F2"); // 20150929
            txbKNValue.Text = dKNVal.ToString("F2"); // 20150929

            txbKBValue.Text = dKBTVal.ToString("F2");
            txbKMValue.Text = dKMTVal.ToString("F2");
            txbDraftValue.Text = dOutputVal.ToString("F2");
            txbTCBValue.Text = dTCBVal.ToString("F2");

            txbMTTValue.Text = dMTTVal.ToString("F2"); // 20150901
            txbWTIValue.Text = dWTIVal.ToString("F2"); // 20150901
            txbCOBValue.Text = dCOBVal.ToString("F2"); // 20150907
            txbCOPValue.Text = dCOPVal.ToString("F2"); // 20150907

            // real ship
            dGZVal_Real = dGZVal * ship_scale / 1000; // 20160128
            dKNVal_Real = dKNVal * ship_scale / 1000; // 20160128

            dKBTVal_Real = dKBTVal * ship_scale / 1000; // 20160128
            dKMTVal_Real = dKMTVal * ship_scale / 1000; // 20160128
            //dOutputVal_Real = dOutputVal * ship_scale; // 20160128
            dTCBVal_Real = dTCBVal * ship_scale / 1000; // 20160128

            dMTTVal_Real = dMTTVal * weight_scale; // 20160128
            dWTIVal_Real = dWTIVal * ship_scale * ship_scale / 1000; // 20160128
            dCOBVal_Real = dCOBVal; // 20160128
            dCOPVal_Real = dCOPVal; // 20160128

            //dKGVal_Real = KG_BC_REAL * ship_scale / 1000; // 20160201
            dKGVal_Real = zCGTotalShip * ship_scale / 1000; // 20160201

            txbGZValue_Real.Text = (dGZVal_Real).ToString("F2"); // 20160128
            txbKNValue_Real.Text = (dKNVal_Real).ToString("F2"); // 20160128

            txbKBValue_Real.Text = (dKBTVal_Real).ToString("F2"); // 20160128
            txbKMValue_Real.Text = (dKMTVal_Real).ToString("F2");// 20160128
            txbDraftValue_Real.Text = (dOutputVal_Real).ToString("F2"); // 20160128 
            txbTCBValue_Real.Text = (dTCBVal_Real).ToString("F2"); // 20160128

            txbMTTValue_Real.Text = (dMTTVal_Real).ToString("F2"); // 20160128
            txbWTIValue_Real.Text = (dWTIVal_Real).ToString("F2"); // 20160128
            txbCOBValue_Real.Text = (dCOBVal_Real).ToString("F2"); // 20160128
            txbCOPValue_Real.Text = (dCOPVal_Real).ToString("F2"); // 20160128

            txbDispOrDraftVal_Real.Text = dInputVal_Real.ToString("F2"); // 20160201
            txbKGVal_Real.Text = dKGVal_Real.ToString("F2"); // 20160201
        }

        private void CalculateLongitudinalHydrostatic()
        {
            double ship_scale = StabilityCalculator.ship_scale;
            double weight_scale = ship_scale * ship_scale * ship_scale / 1000;

            dInputVal = (double)scbDispOrDraftVal.Value / 10;
            if (cbbDispOrDraft.SelectedIndex == 0) // input1 = displacement
            {
                dDispVal = dInputVal;
                dDraftVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.dspData_BC, StabilityCalculator.T1D_drfData);
                dOutputVal = dDraftVal;
                dOutputVal_Real = dOutputVal * ship_scale / 1000; // 20160128
            }
            else // input1 = draft
            {
                dDraftVal = dInputVal;
                dDispVal = StabilityCalculator.Interpolate1D(dInputVal, StabilityCalculator.T1D_drfData, StabilityCalculator.dspData_BC);
                dDispVal_Real = dDispVal * weight_scale; // 20160218
                dOutputVal = dDispVal;
                dOutputVal_Real = dDispVal_Real; // 20160128, 20160218
            }

            dVBLVal = StabilityCalculator.Interpolate2D(dTrimVal, dDispVal, StabilityCalculator.T1D_trmData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_vblData);
            dKMLVal = StabilityCalculator.Interpolate2D(dTrimVal, dDispVal, StabilityCalculator.T1D_trmData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_kmlData);
            dBMLVal = StabilityCalculator.Interpolate2D(dTrimVal, dDispVal, StabilityCalculator.T1D_trmData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_bmlData);
            dLBLVal = StabilityCalculator.Interpolate2D(dTrimVal, dDispVal, StabilityCalculator.T1D_trmData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_lblData);
            dLFLVal = StabilityCalculator.Interpolate2D(dTrimVal, dDispVal, StabilityCalculator.T1D_trmData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_lflData);
            dVFLVal = StabilityCalculator.Interpolate2D(dTrimVal, dDispVal, StabilityCalculator.T1D_trmData, StabilityCalculator.T1D_dspData, StabilityCalculator.T2D_kflData);

            // clear all series
            for (int i = 0; i < crtLongitudinal.Series.Count; i++)
            {
                crtLongitudinal.Series[i].Points.Clear();
            }

            double cX = 0;
            double cY = 0; // ini adalah titik yang tepat, ssw 20160217

            // define G point, in Ship coordinate, if cbxUseKGReal.Checked,ssw 20160106
            double Gx = xCGTotalShip;
            double Gy = zCGTotalShip;

            if (!cbxUseKGReal.Checked & !cbxUseTrimReal.Checked)
            {
                Gx = 0;
                Gy = StabilityCalculator.zCGLightShip;
            }

            // set K point, in Ship coordinate, 
            double Kx = 0;
            double Ky = 0;

            // define B point, in Ship coordinate
            double dTrimRad = dTrimVal * Math.PI / 180;
            double Bx = dLBLVal;
            double By = dVBLVal;

            // define N Point, in Ship coordinate
            dKNVal = Bx * Math.Cos(dTrimRad) + By * Math.Sin(dTrimRad);
            double Nx = dKNVal * Math.Cos(dTrimRad);
            double Ny = dKNVal * Math.Sin(dTrimRad);

            // define M point, in Ship coordinate, point C as center of rotation, 20140819
            double Mx = dKNVal * Math.Cos(dTrimRad) - dKMLVal * Math.Sin(dTrimRad);
            double My = dKNVal * Math.Sin(dTrimRad) + dKMLVal * Math.Cos(dTrimRad);

            // set COF point, in Ship coordinate
            double COFx = dLFLVal;
            double COFy = dVFLVal;

            // set rotable WL point, in Ship coordinate
            double WL1x = 0.9 * crtLongitudinal.ChartAreas[0].AxisX.Minimum;
            double WL2x = 0.9 * crtLongitudinal.ChartAreas[0].AxisX.Maximum;
            double WL1y = dDraftVal;
            double WL2y = dDraftVal;

            // draw rotated longitudinal plane of the ship
            StabilityCalculator.Point2D[] shippointslon = (StabilityCalculator.Point2D[])StabilityCalculator.shippointslon_init.Clone();
            for (int i = 0; i < shippointslon.Length; i++)
            {
                StabilityCalculator.Rotate_point(ref shippointslon[i].x, ref shippointslon[i].y, 0, dDraftVal, -dTrimVal);
                crtLongitudinal.Series[0].Points.AddXY(shippointslon[i].x, shippointslon[i].y);
                SendShipDataTo3D();
            }

            // define G0 point (G lightship) in Ship coordinate, 20150827
            double G0x = StabilityCalculator.xCGLightShip;
            double G0y = StabilityCalculator.zCGLightShip;

            // define Gm point (G total load) in Ship coordinate, 20150827
            double Gmx = xCGTotalLoad;
            double Gmy = zCGTotalLoad;

            StabilityCalculator.Rotate_point(ref Gx, ref Gy, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref Kx, ref Ky, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref Mx, ref My, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref Bx, ref By, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref COFx, ref COFy, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref WL1x, ref WL1y, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref WL2x, ref WL2y, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref G0x, ref G0y, cX, cY, -dTrimVal);
            StabilityCalculator.Rotate_point(ref Gmx, ref Gmy, cX, cY, -dTrimVal);

            // draw static WL (waterline)
            crtLongitudinal.Series[1].Points.AddXY(0.9 * crtLongitudinal.ChartAreas[0].AxisX.Minimum, dDraftVal); // series 4, waterline
            crtLongitudinal.Series[1].Points.AddXY(0.9 * crtLongitudinal.ChartAreas[0].AxisX.Maximum, dDraftVal); // series 4, waterline

            // draw rotated WL line
            crtLongitudinal.Series[2].Points.AddXY(WL1x, WL1y);
            crtLongitudinal.Series[2].Points.AddXY(WL2x, WL2y);

            // draw KML line
            crtLongitudinal.Series[3].Points.AddXY(Mx, My); // series 3, M point
            crtLongitudinal.Series[3].Points.AddXY(Kx, Ky); // series 3, K point

            // draw BM line
            crtLongitudinal.Series[4].Points.AddXY(Mx, My); // series 4, M point
            crtLongitudinal.Series[4].Points.AddXY(Bx, By); // series 4, B point

            // Draw G, B, M, COF point
            crtLongitudinal.Series[5].Points.AddXY(Gx, Gy);
            crtLongitudinal.Series[6].Points.AddXY(Bx, By);
            crtLongitudinal.Series[7].Points.AddXY(Mx, My);
            crtLongitudinal.Series[8].Points.AddXY(COFx, COFy);
            crtLongitudinal.Series[9].Points.AddXY(G0x, G0y);  // 20150827
            crtLongitudinal.Series[10].Points.AddXY(Gmx, Gmy); // 20150827  

            // Show values in textbox
            txbKMLValue.Text = dKMLVal.ToString("F2");
            txbLCBValue.Text = dLBLVal.ToString("F2");
            txbLCFValue.Text = dLFLVal.ToString("F2");

            // Show real ship values in textbox, 20160128
            dKMLVal_Real = dKMLVal * ship_scale / 1000;
            dLBLVal_Real = dLBLVal * ship_scale / 1000;
            dLFLVal_Real = dLFLVal * ship_scale / 1000;
            //dKGVal_Real = KG_BC_REAL * ship_scale / 1000; // 20160201
            dKGVal_Real = zCGTotalShip * ship_scale / 1000; // 20160201

            txbKMLValue_Real.Text = dKMLVal_Real.ToString("F2");
            txbLCBValue_Real.Text = dLBLVal_Real.ToString("F2");
            txbLCFValue_Real.Text = dLFLVal_Real.ToString("F2");

            txbDispOrDraftVal_Real.Text = dInputVal_Real.ToString("F2"); // 20160201
            txbKGVal_Real.Text = dKGVal_Real.ToString("F2"); // 20160201
        }

        private void DrawGZandKNCurves()
        {
            crtGZCrossCurve.Series.Clear();
            crtKNCrossCurve.Series.Clear();
            crtGZCrossCurve.ChartAreas[0].AxisY.Maximum = 100;
            crtGZCrossCurve.ChartAreas[0].AxisY.Minimum = -100;
            crtKNCrossCurve.ChartAreas[0].AxisY.Maximum = 150;
            crtKNCrossCurve.ChartAreas[0].AxisY.Minimum = -150;

            // GZ Curve Chart
            if (rbnGZCrossCurve.Checked)
            {
                crtGZCrossCurve.Titles[1].Text = "Kestabilan Statik GZ (KG = 100 mm)";

                gzcrosscurve_series = new Series[StabilityCalculator.heel_KMT_BC.Count()];
                gzcrosspoint_series = new Series[StabilityCalculator.heel_KMT_BC.Count()];
                crtGZCrossCurve.ChartAreas[0].AxisX.Title = "Displacement (kg)";

                for (int i = 0; i < StabilityCalculator.heel_KMT_BC.Count(); i++)
                {
                    Series lineSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    lineSeries.Color = clr;
                    lineSeries.ChartType = SeriesChartType.FastLine;
                    lineSeries.BorderWidth = 2;
                    gzcrosscurve_series[i] = lineSeries;
                    crtGZCrossCurve.Series.Add(gzcrosscurve_series[i]);
                }
                for (int i = 0; i < StabilityCalculator.heel_KMT_BC.Count(); i++)
                {
                    Series pointSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    pointSeries.Color = clr;
                    pointSeries.ChartType = SeriesChartType.Point;
                    pointSeries.MarkerStyle = MarkerStyle.Circle;
                    pointSeries.MarkerSize = 5;
                    pointSeries.Label = StabilityCalculator.heel_KMT_BC[i].ToString() + " deg";
                    pointSeries.LabelForeColor = clr;
                    pointSeries.BorderWidth = 2;
                    pointSeries.Font = new Font("Microsoft Sans Serif", 14);
                    gzcrosspoint_series[i] = pointSeries;
                    crtGZCrossCurve.Series.Add(gzcrosspoint_series[i]);
                }

                for (int j = 0; j < StabilityCalculator.heel_KMT_BC.Count(); j++)
                {
                    for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                    {
                        double w = StabilityCalculator.disp_KMT_BC[i];
                        double Bx = StabilityCalculator.tbtData_2D_BC[j, i];
                        double By = StabilityCalculator.vbtData_2D_BC[j, i];

                        double dHeelRad = StabilityCalculator.heel_KMT_BC[j] * Math.PI / 180;
                        double Gy = zCGTotalShip;
                        dGZVal = Gy * Math.Sin(-dHeelRad) - Bx * Math.Cos(-dHeelRad) - By * Math.Sin(-dHeelRad);

                        gzcrosscurve_series[j].Points.AddXY(w, dGZVal);
                    }
                    int iPoint = j;
                    if (iPoint >= gzcrosscurve_series[j].Points.Count()) iPoint = gzcrosscurve_series[j].Points.Count() - 1;
                    double x = gzcrosscurve_series[j].Points[iPoint].XValue;
                    double y = gzcrosscurve_series[j].Points[iPoint].YValues[0];

                    gzcrosspoint_series[j].Points.AddXY(x, y);
                }

            }
            else if (rbnGZStaticStability.Checked)
            {
                crtGZCrossCurve.Titles[1].Text = "Kurva Silang GZ (KG = 110 mm)";
                gzcrosscurve_series = new Series[StabilityCalculator.disp_KMT_BC.Count()];
                gzcrosspoint_series = new Series[StabilityCalculator.disp_KMT_BC.Count()];
                crtGZCrossCurve.ChartAreas[0].AxisX.Title = "Heel (deg)";

                for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                {
                    Series lineSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    lineSeries.Color = clr;
                    lineSeries.ChartType = SeriesChartType.FastLine;
                    lineSeries.BorderWidth = 2;
                    gzcrosscurve_series[i] = lineSeries;
                    crtGZCrossCurve.Series.Add(gzcrosscurve_series[i]);
                }
                for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                {
                    Series pointSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    pointSeries.Color = clr;
                    pointSeries.ChartType = SeriesChartType.Point;
                    pointSeries.MarkerStyle = MarkerStyle.Circle;
                    pointSeries.MarkerSize = 5;
                    pointSeries.Label = StabilityCalculator.disp_KMT_BC[i].ToString() + " kgf";
                    pointSeries.LabelForeColor = clr;
                    pointSeries.BorderWidth = 2;
                    pointSeries.Font = new Font("Microsoft Sans Serif", 14);
                    gzcrosspoint_series[i] = pointSeries;
                    crtGZCrossCurve.Series.Add(gzcrosspoint_series[i]);
                }
                for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                {
                    for (int j = 0; j < StabilityCalculator.heel_KMT_BC.Count(); j++)
                    {
                        double w = StabilityCalculator.disp_KMT_BC[i];
                        double Bx = StabilityCalculator.tbtData_2D_BC[j, i];
                        double By = StabilityCalculator.vbtData_2D_BC[j, i];

                        double dHeelRad = StabilityCalculator.heel_KMT_BC[j] * Math.PI / 180;
                        double Gy = zCGTotalShip;
                        dGZVal = Gy * Math.Sin(-dHeelRad) - Bx * Math.Cos(-dHeelRad) - By * Math.Sin(-dHeelRad);

                        gzcrosscurve_series[i].Points.AddXY(StabilityCalculator.heel_KMT_BC[j], dGZVal);
                    }
                    int jPoint = i;
                    if (jPoint >= gzcrosscurve_series[i].Points.Count()) jPoint = gzcrosscurve_series[i].Points.Count() - 1;
                    double x = gzcrosscurve_series[i].Points[jPoint].XValue;
                    double y = gzcrosscurve_series[i].Points[jPoint].YValues[0];
                    gzcrosspoint_series[i].Points.AddXY(x, y);
                }
            }
            else if (rbnGZatGivenDispAndKG.Checked)
            {
                crtGZCrossCurve.Titles[1].Text = "Kestabilan Statik GZ (KG = " + zCGTotalShip.ToString("F0") + " mm, Disp = " + dWeightTotalShip.ToString("F1") + " kg)";
                gzcrosscurve_series = new Series[1];
                gzcrosspoint_series = new Series[1];
                crtGZCrossCurve.ChartAreas[0].AxisX.Title = "Heel (deg)";

                for (int i = 0; i < 1; i++)
                {
                    Series lineSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    lineSeries.Color = clr;
                    lineSeries.ChartType = SeriesChartType.FastLine;
                    lineSeries.BorderWidth = 2;
                    gzcrosscurve_series[i] = lineSeries;
                    crtGZCrossCurve.Series.Add(gzcrosscurve_series[i]);
                }
                for (int j = 0; j < StabilityCalculator.heel_KMT_BC.Count(); j++)
                {
                    double dHeelDeg = StabilityCalculator.heel_KMT_BC[j];
                    double dHeelRad = dHeelDeg * Math.PI / 180;

                    double Bx = Math.Sign(dHeelDeg) * StabilityCalculator.Interpolate2D(
                        Math.Abs(dHeelDeg), 
                        dWeightTotalShip, 
                        StabilityCalculator.T1D_helData, 
                        StabilityCalculator.T1D_dspData, 
                        StabilityCalculator.T2D_tbtData
                    );

                    double By = StabilityCalculator.Interpolate2D(
                        Math.Abs(dHeelDeg), 
                        dWeightTotalShip, 
                        StabilityCalculator.T1D_helData, 
                        StabilityCalculator.T1D_dspData, 
                        StabilityCalculator.T2D_vbtData
                    );

                    double Gy = zCGTotalShip;
                    dGZVal = Gy * Math.Sin(-dHeelRad) - Bx * Math.Cos(-dHeelRad) - By * Math.Sin(-dHeelRad);
                    gzcrosscurve_series[0].Points.AddXY(dHeelDeg, dGZVal);
                }
            }

            // KN Curve Chart
            if (rbnKNCrossCurve.Checked)
            {
                crtKNCrossCurve.Titles[1].Text = "Kestabilan Statik KN (KG = 110 mm)";
                kncrosscurve_series = new Series[StabilityCalculator.heel_KMT_BC.Count()];
                kncrosspoint_series = new Series[StabilityCalculator.heel_KMT_BC.Count()];
                crtKNCrossCurve.ChartAreas[0].AxisX.Title = "Displacement (kg)";

                for (int i = 0; i < StabilityCalculator.heel_KMT_BC.Count(); i++)
                {
                    Series lineSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    lineSeries.Color = clr;
                    lineSeries.ChartType = SeriesChartType.FastLine;
                    lineSeries.BorderWidth = 2;
                    kncrosscurve_series[i] = lineSeries;
                    crtKNCrossCurve.Series.Add(kncrosscurve_series[i]);
                }
                for (int i = 0; i < StabilityCalculator.heel_KMT_BC.Count(); i++)
                {
                    Series pointSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    pointSeries.Color = clr;
                    pointSeries.ChartType = SeriesChartType.Point;
                    pointSeries.MarkerStyle = MarkerStyle.Circle;
                    pointSeries.MarkerSize = 5;
                    pointSeries.Label = StabilityCalculator.heel_KMT_BC[i].ToString() + " deg";
                    pointSeries.LabelForeColor = clr;
                    pointSeries.BorderWidth = 2;
                    pointSeries.Font = new Font("Microsoft Sans Serif", 14);
                    kncrosspoint_series[i] = pointSeries;
                    crtKNCrossCurve.Series.Add(kncrosspoint_series[i]);
                }

                for (int j = 0; j < StabilityCalculator.heel_KMT_BC.Count(); j++)
                {
                    for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                    {
                        double w = StabilityCalculator.disp_KMT_BC[i];
                        double kn = StabilityCalculator.kntData_2D_BC[j, i];
                        kncrosscurve_series[j].Points.AddXY(w, kn);
                    }
                    int iPoint = j;
                    if (iPoint >= kncrosscurve_series[j].Points.Count()) iPoint = kncrosscurve_series[j].Points.Count() - 1;
                    double x = kncrosscurve_series[j].Points[iPoint].XValue;
                    double y = kncrosscurve_series[j].Points[iPoint].YValues[0];
                    kncrosspoint_series[j].Points.AddXY(x, y);
                }
            }
            else if (rbnKNStaticStability.Checked)
            {
                crtKNCrossCurve.Titles[1].Text = "Kurva Silang KN (KG = 110 mm)";
                kncrosscurve_series = new Series[StabilityCalculator.disp_KMT_BC.Count()];
                kncrosspoint_series = new Series[StabilityCalculator.disp_KMT_BC.Count()];
                crtKNCrossCurve.ChartAreas[0].AxisX.Title = "Heel (deg)";

                for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                {
                    Series lineSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    lineSeries.Color = clr;
                    lineSeries.ChartType = SeriesChartType.FastLine;
                    lineSeries.BorderWidth = 2;
                    kncrosscurve_series[i] = lineSeries;
                    crtKNCrossCurve.Series.Add(kncrosscurve_series[i]);
                }
                for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                {
                    Series pointSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    pointSeries.Color = clr;
                    pointSeries.ChartType = SeriesChartType.Point;
                    pointSeries.MarkerStyle = MarkerStyle.Circle;
                    pointSeries.MarkerSize = 5;
                    pointSeries.Label = StabilityCalculator.disp_KMT_BC[i].ToString() + " kgf";
                    pointSeries.LabelForeColor = clr;
                    pointSeries.BorderWidth = 2;
                    pointSeries.Font = new Font("Microsoft Sans Serif", 14);
                    kncrosspoint_series[i] = pointSeries;
                    crtKNCrossCurve.Series.Add(kncrosspoint_series[i]);
                }

                for (int i = 0; i < StabilityCalculator.disp_KMT_BC.Count(); i++)
                {
                    for (int j = 0; j < StabilityCalculator.heel_KMT_BC.Count(); j++)
                    {
                        double w = StabilityCalculator.disp_KMT_BC[i];
                        double kn = StabilityCalculator.kntData_2D_BC[j, i];
                        kncrosscurve_series[i].Points.AddXY(StabilityCalculator.heel_KMT_BC[j], kn);
                    }
                    int jPoint = i;
                    if (jPoint >= kncrosscurve_series[i].Points.Count()) jPoint = kncrosscurve_series[i].Points.Count() - 1;
                    double x = kncrosscurve_series[i].Points[jPoint].XValue;
                    double y = kncrosscurve_series[i].Points[jPoint].YValues[0];

                    kncrosspoint_series[i].Points.AddXY(x, y);
                }
            }
            else if (rbnKNatGivenDispAndKG.Checked)
            {
                crtKNCrossCurve.Titles[1].Text = "Kestabilan Statik KN (KG = " + zCGTotalShip.ToString("F0") + " mm, Disp = " + dWeightTotalShip.ToString("F1") + " kg)";
                kncrosscurve_series = new Series[1];
                kncrosspoint_series = new Series[1];
                crtKNCrossCurve.ChartAreas[0].AxisX.Title = "Heel (deg)";

                for (int i = 0; i < 1; i++)
                {
                    Series lineSeries = new Series();
                    Color clr = Color.FromArgb(5 * i, 0, 255 - 5 * i);
                    lineSeries.Color = clr;
                    lineSeries.ChartType = SeriesChartType.FastLine;
                    lineSeries.BorderWidth = 2;
                    kncrosscurve_series[i] = lineSeries;
                    crtKNCrossCurve.Series.Add(kncrosscurve_series[i]);
                }

                for (int j = 0; j < StabilityCalculator.heel_KMT_BC.Count(); j++)
                {
                    double kn = StabilityCalculator.Interpolate2D(
                        StabilityCalculator.heel_KMT_BC[j], 
                        dWeightTotalShip,
                        StabilityCalculator.heel_KMT_BC,
                        StabilityCalculator.disp_KMT_BC,
                        StabilityCalculator.kntData_2D_BC
                    );
                    kncrosscurve_series[0].Points.AddXY(StabilityCalculator.heel_KMT_BC[j], kn);
                }
            }

            txbX0Value.Text = StabilityCalculator.LCG_BC.ToString("F1");
            txbX0Value_Real.Text = (StabilityCalculator.LCG_BC * StabilityCalculator.ship_scale / 1000).ToString("F1");
        }

        private void InitPractData()
        {
            // initialize test data
            string qInitPrac = "SELECT * FROM `" + ParamsGlobal.test_db_name + "`.`ss_practicum`";

            DataTable dtInitPrac = new DataTable();
            if (MySQLConn.GetTableData(qInitPrac, ref dtInitPrac))
            {
                id_practicum = int.Parse(dtInitPrac.Rows[0]["id"].ToString());
                nudBebanTMMB.Value = decimal.Parse(dtInitPrac.Rows[0]["tmmb_weight"].ToString());
                nudBebanTMMD.Value = decimal.Parse(dtInitPrac.Rows[0]["tmmd_wight"].ToString());
                nudBebanTKK.Value = decimal.Parse(dtInitPrac.Rows[0]["tkk_weight"].ToString());
                nudBebanTNT.Value = decimal.Parse(dtInitPrac.Rows[0]["tnt_weight"].ToString());

                nudPosisiTMMB.Value = decimal.Parse(dtInitPrac.Rows[0]["tmmb_position"].ToString());
                nudPosisiTMMD.Value = decimal.Parse(dtInitPrac.Rows[0]["tmmd_position"].ToString());
                nudPosisiTKK.Value = decimal.Parse(dtInitPrac.Rows[0]["tkk_position"].ToString());
                nudPosisiTNT.Value = decimal.Parse(dtInitPrac.Rows[0]["tnt_position"].ToString());
            }

            cbxUseHeelReal.Checked = true;
            cbxUseTrimReal.Checked = true;

        }

        private void SetPracValue()
        {
            tmmb_weight = (float)mTMMB;
            tmmd_weight = (float)mTMMD;
            tkk_weight = (float)mTKK;
            tnt_weight = (float)mTNT;

            tmmb_pos = (float)nudPosisiTMMB.Value;
            tmmd_pos = (float)nudPosisiTMMD.Value;
            tkk_pos = (float)nudPosisiTKK.Value;
            tnt_pos = (float)nudPosisiTNT.Value;

            heel_val = (float)heel_angle;
            trim_val = (float)trim_angle;
        }

        private void SavePractValue(int accomplished = 0)
        {
            // generate random pract id

            // Calculate Score
            CalculateScore(accomplished);

            // create id ss_execute
            Random rnd = new Random();
            string tmstr = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString();
            string tm5last = tmstr.Substring(tmstr.Length - 5, 5);
            string id_execute = rnd.Next(100, 999).ToString() + "_" + tm5last + "_" + rnd.Next(10, 99).ToString();

            // Save Value of Practic
            string qValExec = "INSERT INTO `" + ParamsGlobal.test_db_name + "`.`ss_execute` (" +
                "`id_practicum`, `id_student`, `tmmb_weight`, `tmmb_position`,`tmmd_wight`, `tmmd_position`," +
                "`tkk_weight`,`tkk_position`,`tnt_weight`,`tnt_position`) VALUES ("+ id_practicum + ", " +
                "0, "+ tmmb_weight + ", " + tmmb_pos + ", " + tmmd_weight + ", " + tmmd_pos + ", " +
                tkk_weight + ", " + tkk_pos + ", " + tnt_weight + ", " + tnt_pos + ");";

            string qValScore = "INSERT INTO `" + ParamsGlobal.test_db_name + "`.`ss_scoring`(" +
                "`id_execute`,`id_student`,"+
                "`angle_heel`,`angle_heel_score`,`angle_trim`,`angle_trim_score`,"+
                "`draft_aft`,`draft_aft_score`,`draft_fwd`,`draft_fwd_score`," +
                "`time_elapse`,`time_elapsed_score`," +
                "`is_accomplished`,`accomplished_score`) VALUES (" +
                "1, 0," + 
                heel_val + "," + angle_heel_score + "," + trim_val + "," + angle_trim_score + "," +
                aft_draft + "," + aft_draft_score + "," + fwd_draft + "," + fwd_draft_score + "," +
                time_elapsed + "," + time_speed_score + "," +
                accomplished + "," + accomplished_score + ");";

            string qValPrac = qValExec + qValScore;

            if(MySQLConn.SetCommand(qValPrac))
            {
                btnEndAssessment.Visible = false;
            }
        }

        private void btnEndAssessment_Click(object sender, EventArgs e)
        {
            SavePractValue(1);
        }

        private void CalculateScore(int accomplished = 0)
        {
            // calculate angle score
            if (Math.Abs(heel_val) <= angle_max) angle_heel_score = 100;
            else
                angle_heel_score = (float)(100 - (Math.Abs(heel_val) - angle_max) / 0.5 * 10);

            if (Math.Abs(trim_val) <= angle_max) angle_trim_score = 100;
            else
                angle_trim_score = (float)(100 - (Math.Abs(trim_val) - angle_max) / 0.5 * 10);

            // calculate draft score
            if (aft_draft <= draft_aft_max) aft_draft_score = 100;
            else
                aft_draft_score = (float)(100 - (aft_draft - draft_aft_max) / 0.5 * 10);

            if (fwd_draft <= draft_fwd_max) fwd_draft_score = 100;
            else
                fwd_draft_score = (float)(100 - (fwd_draft - draft_fwd_max) / 0.5 * 10);

            // calculate time speed

            // accomplished score
            accomplished_score = 100 * accomplished;            
        }

        private void SendShipDataTo3D()
        {
            string message = "Attitude," + heel_angle.ToString("F2") + "," +
                trim_angle.ToString("F2") + "," + dWeightTotalShip.ToString("F2");

            VisualServer.visualconn.Send(message);
        }
        #endregion

        private void btnReloadCFG_Click(object sender, EventArgs e)
        {

        }

        
    }
}
