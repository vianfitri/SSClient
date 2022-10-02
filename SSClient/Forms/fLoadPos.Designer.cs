
namespace SSClient.Forms
{
    partial class fLoadPos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartLoadSideView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartLoadTopView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartLoadFrontView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVertcPosM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudVertcPos = new System.Windows.Forms.NumericUpDown();
            this.txtLongPosMtr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudLongPos = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.txtTransvPosMtr = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtLoadTon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTransvPos = new System.Windows.Forms.NumericUpDown();
            this.label94 = new System.Windows.Forms.Label();
            this.nudLoad = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbGy = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txbGz = new System.Windows.Forms.TextBox();
            this.txbGx = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txbGmy = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txbGmz = new System.Windows.Forms.TextBox();
            this.txbGmx = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnView3D = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadSideView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadTopView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadFrontView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVertcPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransvPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Stability Calculation";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(338, 70);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(552, 592);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.chartLoadSideView);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(544, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SIDE VIEW";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(4, 271);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Panel1MinSize = 332;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Maroon;
            this.splitContainer1.Panel2MinSize = 379;
            this.splitContainer1.Size = new System.Drawing.Size(716, 293);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 1;
            // 
            // chartLoadSideView
            // 
            this.chartLoadSideView.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.LabelStyle.Format = "F0";
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Title = "X, Longitudinal (mm)";
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea1.AxisY.Title = "Z, Vertical (mm)";
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.White;
            this.chartLoadSideView.ChartAreas.Add(chartArea1);
            this.chartLoadSideView.Location = new System.Drawing.Point(0, 0);
            this.chartLoadSideView.Name = "chartLoadSideView";
            this.chartLoadSideView.Size = new System.Drawing.Size(471, 265);
            this.chartLoadSideView.TabIndex = 0;
            this.chartLoadSideView.Text = "Load, Side View";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Load, Side View";
            this.chartLoadSideView.Titles.Add(title1);
            this.chartLoadSideView.PrePaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chartLoadSideView_PrePaint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartLoadTopView);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(544, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TOP VIEW";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartLoadTopView
            // 
            chartArea2.Name = "ChartArea1";
            this.chartLoadTopView.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chartLoadTopView.Legends.Add(legend1);
            this.chartLoadTopView.Location = new System.Drawing.Point(22, 17);
            this.chartLoadTopView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartLoadTopView.Name = "chartLoadTopView";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLoadTopView.Series.Add(series1);
            this.chartLoadTopView.Size = new System.Drawing.Size(504, 253);
            this.chartLoadTopView.TabIndex = 0;
            this.chartLoadTopView.Text = "chart2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartLoadFrontView);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(544, 566);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "FRONT VIEW";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartLoadFrontView
            // 
            chartArea3.Name = "ChartArea1";
            this.chartLoadFrontView.ChartAreas.Add(chartArea3);
            legend2.Name = "Legend1";
            this.chartLoadFrontView.Legends.Add(legend2);
            this.chartLoadFrontView.Location = new System.Drawing.Point(20, 17);
            this.chartLoadFrontView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartLoadFrontView.Name = "chartLoadFrontView";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartLoadFrontView.Series.Add(series2);
            this.chartLoadFrontView.Size = new System.Drawing.Size(510, 253);
            this.chartLoadFrontView.TabIndex = 0;
            this.chartLoadFrontView.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtVertcPosM);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudVertcPos);
            this.groupBox1.Controls.Add(this.txtLongPosMtr);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudLongPos);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.txtTransvPosMtr);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.txtLoadTon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudTransvPos);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.nudLoad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(48, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(268, 240);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " LOAD ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 104;
            this.label9.Text = "( mm )";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(217, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 103;
            this.label10.Text = "( m )";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 102;
            this.label7.Text = "( mm )";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "( m )";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "( mm )";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "( kg )";
            // 
            // txtVertcPosM
            // 
            this.txtVertcPosM.Location = new System.Drawing.Point(156, 199);
            this.txtVertcPosM.Name = "txtVertcPosM";
            this.txtVertcPosM.ReadOnly = true;
            this.txtVertcPosM.Size = new System.Drawing.Size(56, 19);
            this.txtVertcPosM.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Vertical Position";
            // 
            // nudVertcPos
            // 
            this.nudVertcPos.Location = new System.Drawing.Point(156, 177);
            this.nudVertcPos.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudVertcPos.Name = "nudVertcPos";
            this.nudVertcPos.Size = new System.Drawing.Size(56, 19);
            this.nudVertcPos.TabIndex = 96;
            // 
            // txtLongPosMtr
            // 
            this.txtLongPosMtr.Location = new System.Drawing.Point(156, 153);
            this.txtLongPosMtr.Name = "txtLongPosMtr";
            this.txtLongPosMtr.ReadOnly = true;
            this.txtLongPosMtr.Size = new System.Drawing.Size(56, 19);
            this.txtLongPosMtr.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "Longitudinal Position";
            // 
            // nudLongPos
            // 
            this.nudLongPos.Location = new System.Drawing.Point(156, 131);
            this.nudLongPos.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudLongPos.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudLongPos.Name = "nudLongPos";
            this.nudLongPos.Size = new System.Drawing.Size(56, 19);
            this.nudLongPos.TabIndex = 93;
            this.nudLongPos.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(217, 109);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(27, 13);
            this.label52.TabIndex = 92;
            this.label52.Text = "( m )";
            // 
            // txtTransvPosMtr
            // 
            this.txtTransvPosMtr.Location = new System.Drawing.Point(156, 106);
            this.txtTransvPosMtr.Name = "txtTransvPosMtr";
            this.txtTransvPosMtr.ReadOnly = true;
            this.txtTransvPosMtr.Size = new System.Drawing.Size(56, 19);
            this.txtTransvPosMtr.TabIndex = 91;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(217, 64);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(34, 13);
            this.label48.TabIndex = 90;
            this.label48.Text = "( ton )";
            // 
            // txtLoadTon
            // 
            this.txtLoadTon.Location = new System.Drawing.Point(156, 62);
            this.txtLoadTon.Name = "txtLoadTon";
            this.txtLoadTon.ReadOnly = true;
            this.txtLoadTon.Size = new System.Drawing.Size(56, 19);
            this.txtLoadTon.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Transversal Position";
            // 
            // nudTransvPos
            // 
            this.nudTransvPos.Location = new System.Drawing.Point(156, 84);
            this.nudTransvPos.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudTransvPos.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            -2147483648});
            this.nudTransvPos.Name = "nudTransvPos";
            this.nudTransvPos.Size = new System.Drawing.Size(56, 19);
            this.nudTransvPos.TabIndex = 87;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(20, 41);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(68, 13);
            this.label94.TabIndex = 86;
            this.label94.Text = "Load Weight";
            // 
            // nudLoad
            // 
            this.nudLoad.DecimalPlaces = 1;
            this.nudLoad.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudLoad.Location = new System.Drawing.Point(156, 40);
            this.nudLoad.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLoad.Name = "nudLoad";
            this.nudLoad.Size = new System.Drawing.Size(56, 19);
            this.nudLoad.TabIndex = 85;
            this.nudLoad.ValueChanged += new System.EventHandler(this.nudLoad_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbGy);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txbGz);
            this.groupBox2.Controls.Add(this.txbGx);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txbGmy);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txbGmz);
            this.groupBox2.Controls.Add(this.txbGmx);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(48, 326);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(268, 229);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " CENTER OF GRAVITY";
            // 
            // txbGy
            // 
            this.txbGy.Location = new System.Drawing.Point(124, 172);
            this.txbGy.Name = "txbGy";
            this.txbGy.ReadOnly = true;
            this.txbGy.Size = new System.Drawing.Size(76, 20);
            this.txbGy.TabIndex = 67;
            this.txbGy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(40, 199);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 70;
            this.label16.Text = "Gz (mm)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(40, 176);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 66;
            this.label17.Text = "Gy (mm)";
            // 
            // txbGz
            // 
            this.txbGz.Location = new System.Drawing.Point(124, 197);
            this.txbGz.Name = "txbGz";
            this.txbGz.ReadOnly = true;
            this.txbGz.Size = new System.Drawing.Size(76, 20);
            this.txbGz.TabIndex = 71;
            this.txbGz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbGx
            // 
            this.txbGx.Location = new System.Drawing.Point(124, 149);
            this.txbGx.Name = "txbGx";
            this.txbGx.ReadOnly = true;
            this.txbGx.Size = new System.Drawing.Size(76, 20);
            this.txbGx.TabIndex = 69;
            this.txbGx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 68;
            this.label18.Text = "Gx (mm)";
            // 
            // txbGmy
            // 
            this.txbGmy.Location = new System.Drawing.Point(124, 67);
            this.txbGmy.Name = "txbGmy";
            this.txbGmy.ReadOnly = true;
            this.txbGmy.Size = new System.Drawing.Size(76, 20);
            this.txbGmy.TabIndex = 60;
            this.txbGmy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 63;
            this.label13.Text = "Gmz (mm)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 59;
            this.label14.Text = "Gmy (mm)";
            // 
            // txbGmz
            // 
            this.txbGmz.Location = new System.Drawing.Point(124, 92);
            this.txbGmz.Name = "txbGmz";
            this.txbGmz.ReadOnly = true;
            this.txbGmz.Size = new System.Drawing.Size(76, 20);
            this.txbGmz.TabIndex = 64;
            this.txbGmz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbGmx
            // 
            this.txbGmx.Location = new System.Drawing.Point(124, 44);
            this.txbGmx.Name = "txbGmx";
            this.txbGmx.ReadOnly = true;
            this.txbGmx.Size = new System.Drawing.Size(76, 20);
            this.txbGmx.TabIndex = 62;
            this.txbGmx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 61;
            this.label15.Text = "Gmx (mm)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 126);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "CG of Ship Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "CG of Load";
            // 
            // btnView3D
            // 
            this.btnView3D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView3D.Location = new System.Drawing.Point(814, 31);
            this.btnView3D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnView3D.Name = "btnView3D";
            this.btnView3D.Size = new System.Drawing.Size(74, 34);
            this.btnView3D.TabIndex = 21;
            this.btnView3D.Text = "3D View";
            this.btnView3D.UseVisualStyleBackColor = true;
            this.btnView3D.Click += new System.EventHandler(this.btnView3D_Click);
            // 
            // fLoadPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 687);
            this.Controls.Add(this.btnView3D);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fLoadPos";
            this.Text = "fLoadPos";
            this.Load += new System.EventHandler(this.fLoadPos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadSideView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadTopView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadFrontView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVertcPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransvPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoadSideView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoadTopView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoadFrontView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtTransvPosMtr;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtLoadTon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTransvPos;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.NumericUpDown nudLoad;
        private System.Windows.Forms.TextBox txtVertcPosM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudVertcPos;
        private System.Windows.Forms.TextBox txtLongPosMtr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudLongPos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbGmy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txbGmz;
        private System.Windows.Forms.TextBox txbGmx;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbGy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txbGz;
        private System.Windows.Forms.TextBox txbGx;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnView3D;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}