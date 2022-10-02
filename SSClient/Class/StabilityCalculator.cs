using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using SSClient.Class;

public static class StabilityCalculator {
    #region "Struct"
    public struct Point2D
    {
        public double x, y;
    }

    // point double value
    public struct Point3D
    {
        /*
         * x = longitudinal position
         * y = transversal position
         * z = vertical position
         */
        public double x, y, z;
    }
    #endregion

    #region "Hydrostatic Data"
    public static double[] dspData_BC; // Kolom 1  = Displacement Weight (kgf) // used
    public static double[] drfData_BC; // Kolom 2  = Draft, T (mm) // used	            
    public static double[] kbtData_BC; // Kolom 7  = KBT (mm)	// used       
    public static double[] kmtData_BC; // Kolom 8  = KMT (mm)	// used  
    public static double[] lbtData_BC; // Kolom 10 = LCB (mm), at transversal mode // used      
    public static double[] lflData_BC; // Kolom 11 = LCF (mm), at longitudinal mode // used	     
    public static double[] wtiData_BC; // Kolom 12 = WTI (kgf/cm) // used  
    public static double[] mttData_BC; // Kolom 13 = MTT (kgf.m/cm) // used
    public static double[] cobData_BC; // Kolom 23 = Cb // used	   
    public static double[] copData_BC; // Kolom 24 = Cp // used	 

    public static double[] disp_KMT_BC = new double[16] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };
    //double[] heel_KMT_BC = new double[13] { 0, 5, 10, 15, 20, 25, 30, 40, 50, 60, 70, 80, 90 };
    public static double[] heel_KMT_BC = new double[28] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90 }; // 20160113

    // trim angle (deg), new Bulk Carrier model scale 1:87, 20150827
    public static double[] trim_KML_BC = new double[11] { -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10 };

    // new data, new Bulk Carrier model scale 1:87, 20150827
    //double KG_BC_LS = 110;    // mm, light-ship KG (INCLINING TEST DATA, 20151230); 
    //double KG_BC_REAL = 110;  // mm from Keel (INCLINING TEST DATA, 20160102); 
    //double KG_BC_LS = 100;    // mm, light-ship KG (INCLINING TEST DATA, 20151230); 
    //double KG_BC_REAL = 100;  // mm from Keel (INCLINING TEST DATA, 20160102); 
    public static double LCG_BC = 1096.5;   // mm from AP = X0 (CATIA DATA, 20160102); 
    public static double KG_BC_ORCA3D = 0;  // mm from Keel (vertical position of Zero point in ORCA3D, 20160102); 

    // knt = KN at Transversal Mode
    // lookup table data : kntData(row, column), new Bulk Carrier model scale 1:87, 20160107
    // row   = heel_KMT_BC
    // colum = disp_KMT_BC
    public static double[,] kntData_2D_BC;

    // tbt = Tranverse CB at Tranversal Mode, ORCA3D = TCB
    // lookup table data : tbtData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = heel_KMT_BC
    // colum = disp_KMT_BC
    public static double[,] tbtData_2D_BC;

    // vbt = Vertical CB at Tranversal Mode, ORCA3D = VCB
    // lookup table data : vbtData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = heel_KMT_BC
    // colum = disp_KMT_BC
    public static double[,] vbtData_2D_BC;

    // kbt = KB at Tranversal Mode
    // lookup table data : kbtData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = heel_KMT_BC
    // colum = disp_KMT_BC
    public static double[,] kbtData_2D_BC;

    // kmt = KM at Tranversal Mode 
    // lookup table data : kmtData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = heel_KMT_BC
    // colum = disp_KMT_BC
    public static double[,] kmtData_2D_BC;

    // bmt = BM at Tranversal Mode 
    // lookup table data : kmtData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = heel_KMT_BC
    // colum = disp_KMT_BC
    public static double[,] bmtData_2D_BC;

    // lbt = LCB at Tranversal Mode
    // lookup table data : lbtData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = heel_KMT_BC
    // colum = disp_KMT_BC
    public static double[,] lbtData_2D_BC;


    // lbl = LCB at Longitudinal Mode
    // lookup table data : lbtData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = trim_KML_BC
    // colum = disp_KMT_BC
    public static double[,] lblData_2D_BC;

    // kbl = KB at Longitudinal Mode 
    // lookup table data : kblData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = trim_KML_BC
    // colum = disp_KMT_BC
    public static double[,] kblData_2D_BC;

    // vbl = Vertical CB at Longitudinal Mode, ORCA3D = VCB
    // lookup table data : vblData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = trim_KML_BC
    // colum = disp_KMT_BC
    public static double[,] vblData_2D_BC;

    // kml = KM at Longitudinal Mode 
    // lookup table data : kmlData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = trim_KML_BC
    // colum = disp_KMT_BC
    public static double[,] kmlData_2D_BC;

    // bml = BM at Longitudinal Mode 
    // lookup table data : kmlData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = trim_KML_BC
    // colum = disp_KMT_BC
    public static double[,] bmlData_2D_BC;

    // lfl = LCF at Longitudinal Mode
    // lookup table data : lflData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = trim_KML_BC
    // colum = disp_KMT_BC
    public static double[,] lflData_2D_BC;

    // kfl = KF at Longitudinal Mode 
    // lookup table data : kflData(row, column), new Bulk Carrier model scale 1:87, 20150827
    // row   = trim_KML_BC
    // colum = disp_KMT_BC
    public static double[,] kflData_2D_BC;

    // Other Data
    //double[,] T2D_gztData;  // GZT table, transversal GZ, 2D look-up table 
    public static double[,] T2D_kntData;  // KNT table, transversal KN, 2D look-up table 
    public static double[,] T2D_tbtData;  // TCB table, transversal CB, 2D look-up table
    public static double[,] T2D_lblData;  // LCB table, longitudinal CB, 2D look-up table
                                          //double[,] T2D_kbtData;  // KBT table, transversal KB, 2D look-up table
    public static double[,] T2D_vbtData;  // VCB table, vertical CB, lateral mode, 2D look-up table
                                          //double[,] T2D_kblData;  // KBL table, longitudinal KB, 2D look-up table
    public static double[,] T2D_vblData;  // VCB table, vertical CB, longitudinal mode, 2D look-up table
    public static double[,] T2D_kmtData;  // KMT table, transversal KM, 2D look-up table
    public static double[,] T2D_bmtData;  // BMT table, transversal BM, 2D look-up table
    public static double[,] T2D_kmlData;  // KML table, longitudinal KM, 2D look-up table
    public static double[,] T2D_bmlData;  // BML table, longitudinal BM, 2D look-up table
    public static double[,] T2D_kflData;  // KCF table, longitudinal KF, 2D look-tup table
    public static double[,] T2D_lflData;  // LCF table, longitudinal CF, 2D look-up table
    public static double[] T1D_drfData;  // draught (draft), 1D look-up table (1D Table = Vector)
    public static double[] T1D_dspData;  // displacement, 1D look-up table (1D Table = Vector)
    public static double[] T1D_helData;  // heel angle, 1D look-up table (1D Table = Vector)
    public static double[] T1D_trmData;  // trim angle, 1D look-up table (1D Table = Vector)
    public static double[] T1D_wtiData;  // Weight To Immerse, Ton Per Centimeter, 1D look-up table (1D Table = Vector)
    public static double[] T1D_mttData;  // Moment To Trim, Moment to Change Trim, 1D look-up table (1D Table = Vector)
    public static double[] T1D_cobData;  // Coefficient of Block, Cb, 1D look-up table (1D Table = Vector)
    public static double[] T1D_copData;  // Coefficient of Prismatic, Cp, 1D look-up table (1D Table = Vector)

    //double kgDataOrca3D; // KG Data at ORCA3D,  
    // kgDataOrca3D is vertical position of Zero Point at ORCA3D measured from Keel
    // this is the center point of rotation
    //double kgDataReal;   // KG Data real, the real G point of ship

    static double dDispVal = 0;   // displacement value in kgf
    static double dHeelVal = 0;   // heel angle in deg
    static double dTrimVal = 0;   // trim angle in deg, 20150822
    static double dGZVal = 0;     // GZ value in mm
                                  //double dGZCorVal = 0;  // GZ corrected value in mm
    static double dKNVal = 0;     // KN value in mm
    static double dKBTVal = 0;    // KB transversal value in mm
    static double dKMTVal = 0;    // KM transversal value in mm
    static double dBMTVal = 0;    // BM transversal value in mm
    static double dTCBVal = 0;    // CB transversal value in mm
    static double dVCBVal = 0;    // VCB transversal value in mm
    static double dDraftVal = 0;  // draft value in mm
    static double dInputVal = 0;  // Input value = Displacement or Draft
    static double dOutputVal = 0; // Output value = Displacement or Draft

    static double dWTIVal = 0;   // Weight To Immerse value in kgf/cm, 20150901
    static double dMTTVal = 0;   // Moment To Trim value in kgf.m/cm, 20150901
    static double dCOBVal = 0;   // Coefficient of Block, 20150907
    static double dCOPVal = 0;   // Coefficient of Prismatic, 20150907

    //double dKBLVal = 0;    // KB longitudinal value in mm
    static double dVBLVal = 0;    // VCB longitudinal value in mm
    static double dKMLVal = 0;    // KM longitudinal value in mm
    static double dBMLVal = 0;    // BM longitudinal value in mm
    static double dLBLVal = 0;    // CB longitudinal value in mm
    static double dLFLVal = 0;    // LCF longitudinal value in mm 
    static double dVFLVal = 0;    // VCF longitudinal value in mm 
    static double dX0Val = 0;     // X0, x position of origin point (analysis frame), from AP (after perpendiculat)


    static double dDispVal_Real = 0;   // displacement value in kgf
                                       //double dHeelVal_Real = 0;   // heel angle in deg
                                       //double dTrimVal_Real = 0;   // trim angle in deg, 20150822
    static double dGZVal_Real = 0;     // GZ value in mm
                                       //double dGZCorVal_Real = 0;  // GZ corrected value in mm
    static double dKNVal_Real = 0;     // KN value in mm
    static double dKGVal_Real = 0;     // KG value in mm
    static double dKBTVal_Real = 0;    // KB transversal value in mm
    static double dVCBVal_Real = 0;    // CB vertical value in mm
    static double dKMTVal_Real = 0;    // KM transversal value in mm
    static double dBMTVal_Real = 0;    // BM transversal value in mm
    static double dTCBVal_Real = 0;    // CB transversal value in mm
    static double dDraftVal_Real = 0;  // draft value in mm
    static double dInputVal_Real = 0;  // Input value = Displacement or Draft
    static double dOutputVal_Real = 0; // Output value = Displacement or Draft

    static double dWTIVal_Real = 0;   // Weight To Immerse value in kgf/cm, 20150901
    static double dMTTVal_Real = 0;   // Moment To Trim value in kgf.m/cm, 20150901
    static double dCOBVal_Real = 0;   // Coefficient of Block, 20150907
    static double dCOPVal_Real = 0;   // Coefficient of Prismatic, 20150907

    static double dKBLVal_Real = 0;    // KB longitudinal value in mm
    static double dKMLVal_Real = 0;    // KM longitudinal value in mm
    static double dBMLVal_Real = 0;    // BM longitudinal value in mm
    static double dLBLVal_Real = 0;    // CB longitudinal value in mm
    static double dLFLVal_Real = 0;    // LCF longitudinal value in mm 
    static double dVFLVal_Real = 0;    // KCF longitudinal value in mm 
    static double dX0Val_Real = 0;     // X0, x position of origin point (analysis frame), from AP (after perpendiculat)
    #endregion

    #region "CG Data"
    public static double dWeightLightShip; // 20151230
    public static double dWeightTotalLoad;
    public static double dWeightTotalShip;
    public static double dWeightLightShip_Real; // 20150219
    public static double dWeightTotalLoad_Real; // 20150219
    public static double dWeightTotalShip_Real; // 20150219

    //double xCGLightShip =  90.0; // LCG =  90 mm, hasil praktikum 20151230
    public static double xCGLightShip; // LCG =  60 mm, hasil praktikum 20160128
    public static double yCGLightShip; // TKG =   0.2 mm, hasil praktikum 20151230
    public static double zCGLightShip; // KG  = 110 mm, hasil praktikum 20151230
    public static double xCGTotalLoad;
    public static double yCGTotalLoad;
    public static double zCGTotalLoad;
    public static double xCGTotalShip;
    public static double yCGTotalShip;
    public static double zCGTotalShip;

    public static double ship_scale = 87.0;
    public static double heel_angle = 0; // in deg
    public static double trim_angle = 0; // in deg

    public static double mLoad = 0;
    public static double mLoadReal = 0;

    public static Point3D LoadPos = new Point3D { x = 0, y = 0, z = 0 };
    public static Point3D LoadPos_Real = new Point3D();
    #endregion

    #region "ShipPoint"

    public static Point2D[] shippoints = new Point2D[26];
    public static Point2D[] shippoints_init = new Point2D[26];
    public static Point2D[] shippoints_BC = new Point2D[26]
    {
            new Point2D{x =  -57.5  ,   y =  459.8}, // point 0
            new Point2D{x = -80.5   ,   y =  390.8}, // point 1
            new Point2D{x = -143.7  ,   y =  390.8}, // point 2
            new Point2D{x = -143.7  ,   y =  344.8}, // point 3
            new Point2D{x = -114.9  ,   y =  333.3}, // point 4
            new Point2D{x = -114.9  ,   y =  203.4}, // point 5
            new Point2D{x = -182.1  ,   y =  203.4}, // point 6
            new Point2D{x = -182.1  ,   y =   22.4}, // point 7
            new Point2D{x = -179.9  ,   y =   14.9}, // point 8
            new Point2D{x = -176.4  ,   y =   10.0}, // point 9
            new Point2D{x = -171.0  ,   y =    3.5}, // point 10
            new Point2D{x = -158.0  ,   y =    0.0}, // point 11 
            new Point2D{x =  0.0    ,   y =    0.0}, // point 12
            new Point2D{x =  158.0  ,   y =    0.0}, // point 13
            new Point2D{x =  171.0  ,   y =    3.5}, // point 14
            new Point2D{x =  176.4  ,   y =   10.0}, // point 15
            new Point2D{x =  179.9  ,   y =   14.9}, // point 16
            new Point2D{x =  182.1  ,   y =   22.4}, // point 17
            new Point2D{x =  182.1  ,   y =  203.4}, // point 18
            new Point2D{x =  114.9  ,   y =  203.4}, // point 19
            new Point2D{x =  114.9  ,   y =  333.3}, // point 20
            new Point2D{x =  143.7  ,   y =  344.8}, // point 21 
            new Point2D{x =  143.7  ,   y =  390.8}, // point 22
            new Point2D{x =  80.5   ,   y =  390.8}, // point 23
            new Point2D{x =  57.5   ,   y =  459.8}, // point 24
            new Point2D{x = -57.5   ,   y =  459.8}  // point 25
    };

    public static Point2D[] shippointslon = new Point2D[33]; // longitudinal hull coordinate
    public static Point2D[] shippointslon_init = new Point2D[33];
    public static Point2D[] shippointslon_BC = new Point2D[33]  // Bulk Carrier
    {
            new Point2D{x = -1096.5,    y = 204.0}, // point 0
            new Point2D{x = -1096.5,    y = 128.3}, // point 1
            new Point2D{x =  -970.2,    y =  90.4}, // point 2
            new Point2D{x =  -970.2,    y =  23.1}, // point 3
            new Point2D{x =  -963.9,    y =  14.7}, // point 4
            new Point2D{x =  -953.4,    y =   6.3}, // point 5
            new Point2D{x =  -945.0,    y =   0.0}, // point 6
            new Point2D{x =   -35.6,    y =   0.0}, // point 7
            new Point2D{x =  1080.0,    y =   0.0}, // point 8
            new Point2D{x =  1109.5,    y =   8.4}, // point 9
            new Point2D{x =  1128.5,    y =  25.2}, // point 10
            new Point2D{x =  1145.3,    y =  42.1}, // point 11 
            new Point2D{x =  1151.6,    y =  67.3}, // point 12
            new Point2D{x =  1141.1,    y =  96.7}, // point 13
            new Point2D{x =  1092.7,    y = 136.7}, // point 14
            new Point2D{x =  1090.6,    y = 149.3}, // point 15
            new Point2D{x =  1092.7,    y = 155.6}, // point 16
            new Point2D{x =  1132.7,    y = 231.3}, // point 17
            new Point2D{x =   949.5,    y = 231.3}, // point 18
            new Point2D{x =   924.3,    y = 204.0}, // point 19
            new Point2D{x =  -610.3,    y = 204.0}, // point 20
            new Point2D{x =  -610.3,    y = 402.3}, // point 21
            new Point2D{x =  -667.8,    y = 402.3}, // point 22
            new Point2D{x =  -667.8,    y = 459.8}, // point 23
            new Point2D{x =  -782.7,    y = 459.8}, // point 24
            new Point2D{x =  -782.7,    y = 344.8}, // point 25
            new Point2D{x =  -840.2,    y = 344.8}, // point 26
            new Point2D{x =  -840.2,    y = 459.8}, // point 27
            new Point2D{x =  -897.7,    y = 459.8}, // point 28
            new Point2D{x =  -955.1,    y = 287.4}, // point 29
            new Point2D{x = -1012.6,    y = 287.4}, // point 30
            new Point2D{x = -1012.6,    y = 204.0}, // point 31 
            new Point2D{x = -1096.5,    y = 204.0}  // point 32
    };

    public static Point2D[] shippointsTopView_BC = new Point2D[30] {  // Bulk Carrier Scale 1:87, top view, 20151223
            new Point2D{x = -1096.5,    y =    0.0}, // point 0
            new Point2D{x = -1096.5,    y = -131.1}, // point 1
            new Point2D{x = -1023.4,    y = -149.9}, // point 2
            new Point2D{x =  -971.0,    y = -163.0}, // point 3
            new Point2D{x =  -903.5,    y = -170.5}, // point 4
            new Point2D{x =  -854.8,    y = -174.2}, // point 5
            new Point2D{x =   580.2,    y = -174.2}, // point 6
            new Point2D{x =   726.3,    y = -168.6}, // point 7
            new Point2D{x =   842.5,    y = -157.4}, // point 8
            new Point2D{x =   956.8,    y = -134.9}, // point 9
            new Point2D{x =   981.1,    y = -148.0}, // point 10
            new Point2D{x =  1044.8,    y = -123.6}, // point 11 
            new Point2D{x =  1091.7,    y =  -97.4}, // point 12
            new Point2D{x =  1127.2,    y =  -65.6}, // point 13
            new Point2D{x =  1151.6,    y =  -16.9}, // point 14
            new Point2D{x =  1151.6,    y =   16.9}, // point 15
            new Point2D{x =  1127.2,    y =   65.6}, // point 16
            new Point2D{x =  1091.7,    y =   97.4}, // point 17
            new Point2D{x =  1044.8,    y =  123.6}, // point 18
            new Point2D{x =   981.1,    y =  148.0}, // point 19
            new Point2D{x =   956.8,    y =  134.9}, // point 20
            new Point2D{x =   842.5,    y =  157.4}, // point 21
            new Point2D{x =   726.3,    y =  168.6}, // point 22
            new Point2D{x =   580.2,    y =  174.2}, // point 23
            new Point2D{x =  -854.8,    y =  174.2}, // point 24
            new Point2D{x =  -903.5,    y =  170.5}, // point 25
            new Point2D{x =  -971.0,    y =  163.0}, // point 26
            new Point2D{x = -1023.4,    y =  149.9}, // point 27
            new Point2D{x = -1096.5,    y =  131.1}, // point 28
            new Point2D{x = -1096.5,    y =    0.0}  // point 29
        };
    #endregion

    #region "Method"
    // Configuration Load
    public static void LoadConfiguration(string fileName)
    {
        try
        {
            string strLCG_LS = IniFile.IniReadValue("CG LightShip", "LCG_LS", fileName);
            string strTCG_LS = IniFile.IniReadValue("CG LightShip", "TCG_LS", fileName);
            string strKG_LS = IniFile.IniReadValue("CG LightShip", "KG_LS", fileName);

            string strDIS_LS = IniFile.IniReadValue("Displacement", "DIS_LS", fileName);
            string strDIS_LOD = IniFile.IniReadValue("Displacement", "DIS_LOD", fileName);
            string strDIS_TOT = IniFile.IniReadValue("Displacement", "DIS_TOT", fileName);

            xCGLightShip = Convert.ToDouble(strLCG_LS); // LCG =  60 mm, hasil praktikum 20160128
            yCGLightShip = Convert.ToDouble(strTCG_LS); // TKG =   0.2 mm, hasil praktikum 20151230
            zCGLightShip = Convert.ToDouble(strKG_LS);  // KG  = 110 mm, hasil praktikum 20151230

            dWeightLightShip = Convert.ToDouble(strDIS_LS);  // Displacement of Light Ship
            dWeightTotalLoad = Convert.ToDouble(strDIS_LOD); // Displacement of Total Load
            dWeightTotalShip = Convert.ToDouble(strDIS_TOT); // Displacement of Total Ship
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error StabilityCalculator Load : " + ex.Message);
        }
    }

    // Initialize Ship Data
    public static void InitializeShipData()
    {
        ReadCSV_HS_Data(Application.StartupPath + "\\Data\\HS_BC.csv", 81);

        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\KN_BC.csv", 28, 16, ref kntData_2D_BC);

        for (int j = 0; j < heel_KMT_BC.Count(); j++)
        {
            for (int i = 0; i < disp_KMT_BC.Count(); i++)
            {
                kntData_2D_BC[j, i] = -kntData_2D_BC[j, i];
            }
        }

        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\LCB_BC.csv", 28, 16, ref lbtData_2D_BC); // not used
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\TCB_BC.csv", 28, 16, ref tbtData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\VCB_BC.csv", 28, 16, ref vbtData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\KMT_BC.csv", 28, 16, ref kmtData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\BMT_BC.csv", 28, 16, ref bmtData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\KML_BC.csv", 11, 16, ref kmlData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\BML_BC.csv", 11, 16, ref bmlData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\LBL_BC.csv", 11, 16, ref lblData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\VBL_BC.csv", 11, 16, ref vblData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\LCF_BC.csv", 11, 16, ref lflData_2D_BC);
        ReadCSV_2D_Data(Application.StartupPath + "\\Data\\VCF_BC.csv", 11, 16, ref kflData_2D_BC);

        T2D_kntData = (double[,])kntData_2D_BC.Clone();
        T2D_tbtData = (double[,])tbtData_2D_BC.Clone();
        T2D_vbtData = (double[,])vbtData_2D_BC.Clone(); // 20160217
        T2D_kmtData = (double[,])kmtData_2D_BC.Clone();
        T2D_bmtData = (double[,])bmtData_2D_BC.Clone();
        T2D_lblData = (double[,])lblData_2D_BC.Clone();
        T2D_vblData = (double[,])vblData_2D_BC.Clone(); // 20160218
        T2D_kmlData = (double[,])kmlData_2D_BC.Clone();
        T2D_bmlData = (double[,])bmlData_2D_BC.Clone();
        T2D_lflData = (double[,])lflData_2D_BC.Clone();
        T2D_kflData = (double[,])kflData_2D_BC.Clone();

        T1D_drfData = (double[])drfData_BC.Clone();
        T1D_helData = (double[])heel_KMT_BC.Clone();
        T1D_dspData = (double[])disp_KMT_BC.Clone();
        T1D_trmData = (double[])trim_KML_BC.Clone();
        T1D_wtiData = (double[])wtiData_BC.Clone(); // 20150901
        T1D_mttData = (double[])mttData_BC.Clone(); // 20150901
        T1D_cobData = (double[])cobData_BC.Clone(); // 20150907
        T1D_copData = (double[])copData_BC.Clone(); // 20150907

        dX0Val = LCG_BC;

        // initialize ship longitudinal plane 
        shippointslon_init = (Point2D[])shippointslon_BC.Clone();
    }

    // Read Hydrostatic Data CSV File
    public static void ReadCSV_HS_Data(string strFileName, int row)
    {
        var reader = new StreamReader(File.OpenRead(strFileName));
        dspData_BC = new double[row]; // Kolom 1  = Displacement Weight (kgf) // used
        drfData_BC = new double[row]; // Kolom 2  = Draft, T (mm) // used	            
        kbtData_BC = new double[row]; // Kolom 7  = KBT (mm)	// used       
        kmtData_BC = new double[row]; // Kolom 8  = KMT (mm)	// used  
        lbtData_BC = new double[row]; // Kolom 10 = LCB (mm), at transversal mode // used      
        lflData_BC = new double[row]; // Kolom 11 = LCF (mm), at longitudinal mode // used	     
        wtiData_BC = new double[row]; // Kolom 12 = WTI (kgf/cm) // used  
        mttData_BC = new double[row]; // Kolom 13 = MTT (kgf.m/cm) // used
        cobData_BC = new double[row]; // Kolom 23 = Cb // used	   
        copData_BC = new double[row]; // Kolom 24 = Cp // used

        int i = 0;
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');

            if (values.Length >= 9)
            {
                dspData_BC[i] = Convert.ToDouble(values[0]); // Kolom 1  = Displacement Weight (kgf) // used
                drfData_BC[i] = Convert.ToDouble(values[1]); // Kolom 2  = Draft, T (mm) // used	            
                kbtData_BC[i] = Convert.ToDouble(values[2]); // Kolom 7  = KBT (mm)	// used       
                kmtData_BC[i] = Convert.ToDouble(values[3]); // Kolom 8  = KMT (mm)	// used  
                lbtData_BC[i] = Convert.ToDouble(values[4]); // Kolom 10 = LCB (mm), at transversal mode // used      
                lflData_BC[i] = Convert.ToDouble(values[5]); // Kolom 11 = LCF (mm), at longitudinal mode // used	     
                wtiData_BC[i] = Convert.ToDouble(values[6]); // Kolom 12 = WTI (kgf/cm) // used
                mttData_BC[i] = Convert.ToDouble(values[7]); // Kolom 13 = MTT (kgf.m/cm) // used
                cobData_BC[i] = Convert.ToDouble(values[8]); // Kolom 23 = Cb // used	   
                copData_BC[i] = Convert.ToDouble(values[9]); // Kolom 24 = Cp // used
            }
            i += 1;
        }
    }

    public static void ReadCSV_2D_Data(string strFileName, int row, int col, ref double[,] z)
    {
         z = new double[row, col];

        var reader = new StreamReader(File.OpenRead(strFileName));
        int i = 0;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            if (values.Length >= col)
            {
                for (int j = 0; j < col; j++)
                {
                    z[i, j] = Convert.ToDouble(values[j]);
                }
            }
            i += 1;
        }
    }

    // function for interpolate lookup table 2D
    public static double Interpolate2D(double xs, double ys, double[] x, double[] y, double[,] z)
    {
        int N = x.Length;
        int M = y.Length;

        int k;
        int i;
        // first check for input x
        if (xs < x[0])  // case 0
        {
            i = 0;
        }
        else if (xs > x[N - 1]) // case 1
        {
            i = N - 2;
        }
        else // case 2
        {
            for (k = 0; k < N - 1; k++)
            {
                if (xs < x[k])
                {
                    break;
                }
            }
            i = k - 1;
        }

        int j;

        // first check for input y
        if (ys < y[0])  // case 0
        {
            j = 0;
        }
        else if (ys > y[M - 1]) // case 1
        {
            j = M - 2;
        }
        else // case 2
        {
            for (k = 0; k < M - 1; k++)
            {
                if (ys < y[k])
                {
                    break;
                }
            }
            j = k - 1;
        }

        double zA = z[i, j];
        double zB = z[i, j + 1];
        double zC = z[i + 1, j + 1];
        double zD = z[i + 1, j];

        double dx = xs - x[i];
        double dy = ys - y[j];
        double delx = x[i + 1] - x[i];
        double dely = y[j + 1] - y[j];

        double zs = zA + dy / dely * (zB - zA) + dx / delx * (zD - zA) + dx / delx * dy / dely * (zA + zC - zB - zD);

        return zs;
    }

    // function for interpolate lookup table 1D
    public static double Interpolate1D(double xs, double[] x, double[] z)
    {
        int N = x.Length;

        int k; 
        int i;
        // first check for input x
        if (xs < x[0])  // case 0
        {
            i = 0;
        }
        else if (xs > x[N - 1]) // case 1
        {
            i = N - 2;
        }
        else // case 2
        {
            for (k = 0; k < N - 1; k++)
            {
                if (xs < x[k])
                {
                    break;
                }
            }
            i = k - 1;
        }

        double zA = z[i];
        double zB = z[i + 1];

        double dx = xs - x[i];
        double delx = x[i + 1] - x[i];

        double zs = zA + dx / delx * (zB - zA);

        return zs;
    }

    public static void Rotate_point(ref double px, ref double py, double cx, double cy, double angle_deg)
    {
        double s = Math.Sin(angle_deg * Math.PI / 180);
        double c = Math.Cos(angle_deg * Math.PI / 180);

        // translate point back to origin:
        px -= cx;
        py -= cy;

        // rotate point
        double xnew = px * c - py * s;
        double ynew = px * s + py * c;

        // translate point back:
        px = xnew + cx;
        py = ynew + cy;
    }

    // Calculation Heel And Trim At Given Displacement and CG
    public static void CalculationHeelAndTrim(double Disp, double Gx, double Gy, double Gz, ref double outHeel, ref double outTrim)
    {
        double heeldeg = 0, trimdeg = 0;
        double heelrad = 0, trimrad = 0;

        double heelleftdeg, heelleftrad, heelrightdeg, heelrightrad;
        double trimleftdeg, trimleftrad, trimrightdeg, trimrightrad;

        double Mx, MxLeft, MxRight, dMx, My, MyLeft, MyRight, dMy, Mz, MzLeft, MzRight, dMz;
        double Bx, BxLeft, BxRight, By, ByLeft, ByRight, Bz, BzLeft, BzRight;

        double heelradold = 0, trimradold = 0;
        double deltaphi = 1, deltatheta = 1;
        double f_phi, df_phi, f_theta, df_theta;
        int iCount = 0;
        double errHeel = 0.001; // define error in radians
        double errTrim = 0.001; // define error in radians

        double dKNValLeft, dKNValRight, dKMTValLeft, dKMTValRight, dKMLValLeft, dKMLValRight;

        for (iCount = 0; iCount < 50; iCount++) // heel iteration
        {
            heelleftdeg = heeldeg - 0.1;
            heelrightdeg = heeldeg + 0.1;
            heelleftrad = heelleftdeg * Math.PI / 180;
            heelrightrad = heelrightdeg * Math.PI / 180;

            By = Math.Sign(heeldeg) * Interpolate2D(Math.Abs(heeldeg), Disp, T1D_helData, T1D_dspData, T2D_tbtData);
            Bz = Interpolate2D(Math.Abs(heeldeg), Disp, T1D_helData, T1D_dspData, T2D_vbtData);
            dKMTVal = Interpolate2D(Math.Abs(heeldeg), Disp, T1D_helData, T1D_dspData, T2D_kmtData);

            ByLeft = Math.Sign(heelleftdeg) * Interpolate2D(Math.Abs(heelleftdeg), Disp, T1D_helData, T1D_dspData, T2D_tbtData);
            BzLeft = Interpolate2D(Math.Abs(heelleftdeg), Disp, T1D_helData, T1D_dspData, T2D_vbtData);
            dKMTValLeft = Interpolate2D(Math.Abs(heelleftdeg), Disp, T1D_helData, T1D_dspData, T2D_kmtData);

            ByRight = Math.Sign(heelrightdeg) * Interpolate2D(Math.Abs(heelrightdeg), Disp, T1D_helData, T1D_dspData, T2D_tbtData);
            BzRight = Interpolate2D(Math.Abs(heelrightdeg), Disp, T1D_helData, T1D_dspData, T2D_vbtData);
            dKMTValRight = Interpolate2D(Math.Abs(heelrightdeg), Disp, T1D_helData, T1D_dspData, T2D_kmtData);

            dKNVal = By * Math.Cos(-heelrad) + Bz * Math.Sin(-heelrad);
            dKNValLeft = ByLeft * Math.Cos(-heelleftrad) + BzLeft * Math.Sin(-heelleftrad);
            dKNValRight = ByRight * Math.Cos(-heelrightrad) + BzRight * Math.Sin(-heelrightrad);

            My = dKNVal * Math.Cos(-heelrad) - dKMTVal * Math.Sin(-heelrad);
            Mz = dKNVal * Math.Sin(-heelrad) + dKMTVal * Math.Cos(-heelrad);

            MyLeft = dKNValLeft * Math.Cos(-heelleftrad) - dKNValLeft * Math.Sin(-heelleftrad);
            MzLeft = -dKNValLeft * Math.Sin(-heelleftrad) + dKNValLeft * Math.Cos(-heelleftrad);

            MyRight = dKNValRight * Math.Cos(-heelrightrad) - dKNValRight * Math.Sin(-heelrightrad);
            MzRight = -dKNValRight * Math.Sin(-heelrightrad) + dKNValRight * Math.Cos(-heelrightrad);

            dMy = (MyRight - MyLeft) / 0.2;
            dMz = (MzRight - MzLeft) / 0.2;

            double u = Gy - My;
            double v = Gz - Mz;

            f_phi = Math.Tan(heelrad) - u / v;
            df_phi = 1 / (Math.Cos(heelrad) * Math.Cos(heelrad)) + (dMy * v - u * dMz) / (v * v);
            heelradold = heelrad;
            heelrad = heelradold - f_phi / df_phi;
            heeldeg = heelrad * 180 / Math.PI;
            deltaphi = Math.Abs(heelrad - heelradold);

            if (deltaphi <= errHeel)
            {
                break;
            }
        } // end of heel iteration

        for (iCount = 0; iCount < 50; iCount++) // trim iteration
        {
            trimleftdeg = trimdeg - 0.1;
            trimrightdeg = trimdeg + 0.1;
            trimleftrad = trimleftdeg * Math.PI / 180;
            trimrightrad = trimrightdeg * Math.PI / 180;

            Bx = Interpolate2D(trimdeg, Disp, T1D_trmData, T1D_dspData, T2D_lblData);
            Bz = Interpolate2D(trimdeg, Disp, T1D_trmData, T1D_dspData, T2D_vblData);
            dKMLVal = Interpolate2D(trimdeg, Disp, T1D_trmData, T1D_dspData, T2D_kmlData);

            BxLeft = Interpolate2D(trimleftdeg, Disp, T1D_trmData, T1D_dspData, T2D_lblData);
            BzLeft = Interpolate2D(trimleftdeg, Disp, T1D_trmData, T1D_dspData, T2D_vblData);
            dKMLValLeft = Interpolate2D(trimleftdeg, Disp, T1D_trmData, T1D_dspData, T2D_kmlData);

            BxRight = Interpolate2D(trimrightdeg, Disp, T1D_trmData, T1D_dspData, T2D_lblData);
            BzRight = Interpolate2D(trimrightdeg, Disp, T1D_trmData, T1D_dspData, T2D_vblData);
            dKMLValRight = Interpolate2D(trimrightdeg, Disp, T1D_trmData, T1D_dspData, T2D_kmlData);

            dKNVal = Bx * Math.Cos(trimrad) + Bz * Math.Sin(trimrad);
            dKNValLeft = BxLeft * Math.Cos(trimleftrad) + BzLeft * Math.Sin(trimleftrad);
            dKNValRight = BxRight * Math.Cos(trimrightrad) + BzRight * Math.Sin(trimrightrad);

            Mx = dKNVal * Math.Cos(trimrad) - dKMLVal * Math.Sin(trimrad);
            Mz = dKNVal * Math.Sin(trimrad) + dKMLVal * Math.Cos(trimrad);

            MxLeft = dKNValLeft * Math.Cos(trimleftrad) - dKMLValLeft * Math.Sin(trimleftrad);
            MzLeft = dKNValLeft * Math.Sin(trimleftrad) + dKMLValLeft * Math.Cos(trimleftrad);

            MxRight = dKNValRight * Math.Cos(trimrightrad) - dKMLValRight * Math.Sin(trimrightrad);
            MzRight = dKNValRight * Math.Sin(trimrightrad) + dKMLValRight * Math.Cos(trimrightrad);

            dMx = (MxRight - MxLeft) / 0.2;
            dMz = (MzRight - MzLeft) / 0.2;

            double u = Gx - Mx;
            double v = Gz - Mz;

            f_theta = Math.Tan(trimrad) + u / v;
            df_theta = 1 / (Math.Cos(trimrad) * Math.Cos(trimrad)) + (dMx * v - u * dMz) / (v * v);
            trimradold = trimrad;
            trimrad = trimradold - f_theta / df_theta;
            trimdeg = trimrad * 180 / Math.PI;
            deltatheta = Math.Abs(trimrad - trimradold);
            if (deltatheta <= errTrim)
            {
                break;
            }
        } // end of trim iteration

        outHeel = heeldeg;
        outTrim = trimdeg;
    }

    // Calculation CG and Ship Attitude
    public static void CalculateCG_and_Attitude()
    {
        double weight_scale = ship_scale * ship_scale * ship_scale / 1000; // in ton

        mLoadReal = mLoad * weight_scale; // in ton
        dWeightTotalLoad = mLoad;
        dWeightTotalShip = dWeightLightShip + dWeightTotalLoad;

        dWeightLightShip_Real = dWeightLightShip * weight_scale;
        dWeightTotalLoad_Real = dWeightTotalLoad * weight_scale;
        dWeightTotalShip_Real = dWeightTotalShip * weight_scale;

        // load position
        LoadPos.x = 1100 - 1096.5;
        LoadPos.y = 0;
        LoadPos.z = 275 + 0.5 * mLoad * 10;

        // load position real
        LoadPos_Real.x = LoadPos.x * ship_scale / 1000; // in meter
        LoadPos_Real.y = LoadPos.y * ship_scale / 1000; // in meter
        LoadPos_Real.z = LoadPos.z * ship_scale / 1000; // in meter

        if (dWeightTotalLoad > 0)
        {
            xCGTotalLoad = (LoadPos.x * mLoad) / dWeightTotalLoad;
            yCGTotalLoad = (LoadPos.y * mLoad) / dWeightTotalLoad;
            zCGTotalLoad = (LoadPos.z * mLoad) / dWeightTotalLoad;
        }

        xCGTotalShip = (xCGTotalLoad * dWeightTotalLoad + xCGLightShip * dWeightLightShip) / dWeightTotalShip;
        yCGTotalShip = (yCGTotalLoad * dWeightTotalLoad + yCGLightShip * dWeightLightShip) / dWeightTotalShip;
        zCGTotalShip = (zCGTotalLoad * dWeightTotalLoad + zCGLightShip * dWeightLightShip) / dWeightTotalShip;

        CalculationHeelAndTrim(dWeightTotalShip, xCGTotalShip, yCGTotalShip, zCGTotalShip, ref heel_angle, ref trim_angle);
    }
    #endregion
}