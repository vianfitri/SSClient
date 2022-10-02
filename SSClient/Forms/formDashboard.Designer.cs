
namespace SSClient
{
    partial class formDashboard
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
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.hiddenPannel = new System.Windows.Forms.Panel();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.btnClientList = new FontAwesome.Sharp.IconButton();
            this.btnReport = new FontAwesome.Sharp.IconButton();
            this.btnStability = new FontAwesome.Sharp.IconButton();
            this.btnScenario = new FontAwesome.Sharp.IconButton();
            this.pnlUserSubmenu = new System.Windows.Forms.Panel();
            this.btnAccount = new FontAwesome.Sharp.IconButton();
            this.btnTrainee = new FontAwesome.Sharp.IconButton();
            this.btnInstructor = new FontAwesome.Sharp.IconButton();
            this.btnUsers = new FontAwesome.Sharp.IconButton();
            this.pnlMasterDataSubmenu = new System.Windows.Forms.Panel();
            this.btnCargoData = new FontAwesome.Sharp.IconButton();
            this.btnShipData = new FontAwesome.Sharp.IconButton();
            this.btnMasterData = new FontAwesome.Sharp.IconButton();
            this.pnlUserPic = new System.Windows.Forms.Panel();
            this.btnLogout = new ViControls.ViButton();
            this.lblPriviledge = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.userPic = new ViControls.CircularPicture();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMainMenu.SuspendLayout();
            this.pnlUserSubmenu.SuspendLayout();
            this.pnlMasterDataSubmenu.SuspendLayout();
            this.pnlUserPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pnlMainMenu.Controls.Add(this.hiddenPannel);
            this.pnlMainMenu.Controls.Add(this.btnSettings);
            this.pnlMainMenu.Controls.Add(this.btnClientList);
            this.pnlMainMenu.Controls.Add(this.btnReport);
            this.pnlMainMenu.Controls.Add(this.btnStability);
            this.pnlMainMenu.Controls.Add(this.btnScenario);
            this.pnlMainMenu.Controls.Add(this.pnlUserSubmenu);
            this.pnlMainMenu.Controls.Add(this.btnUsers);
            this.pnlMainMenu.Controls.Add(this.pnlMasterDataSubmenu);
            this.pnlMainMenu.Controls.Add(this.btnMasterData);
            this.pnlMainMenu.Controls.Add(this.pnlUserPic);
            this.pnlMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMainMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(250, 821);
            this.pnlMainMenu.TabIndex = 0;
            // 
            // hiddenPannel
            // 
            this.hiddenPannel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hiddenPannel.Location = new System.Drawing.Point(0, 803);
            this.hiddenPannel.Margin = new System.Windows.Forms.Padding(2);
            this.hiddenPannel.Name = "hiddenPannel";
            this.hiddenPannel.Size = new System.Drawing.Size(250, 18);
            this.hiddenPannel.TabIndex = 23;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnSettings.IconColor = System.Drawing.Color.White;
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 24;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 573);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSettings.Size = new System.Drawing.Size(250, 45);
            this.btnSettings.TabIndex = 22;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClientList
            // 
            this.btnClientList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientList.FlatAppearance.BorderSize = 0;
            this.btnClientList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientList.ForeColor = System.Drawing.Color.White;
            this.btnClientList.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.btnClientList.IconColor = System.Drawing.Color.White;
            this.btnClientList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientList.IconSize = 24;
            this.btnClientList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientList.Location = new System.Drawing.Point(0, 528);
            this.btnClientList.Margin = new System.Windows.Forms.Padding(2);
            this.btnClientList.Name = "btnClientList";
            this.btnClientList.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnClientList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClientList.Size = new System.Drawing.Size(250, 45);
            this.btnClientList.TabIndex = 21;
            this.btnClientList.Text = "Client List";
            this.btnClientList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientList.UseVisualStyleBackColor = true;
            this.btnClientList.Click += new System.EventHandler(this.btnClientList_Click);
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnReport.IconColor = System.Drawing.Color.White;
            this.btnReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReport.IconSize = 24;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(0, 483);
            this.btnReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReport.Size = new System.Drawing.Size(250, 45);
            this.btnReport.TabIndex = 20;
            this.btnReport.Text = "Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnStability
            // 
            this.btnStability.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStability.FlatAppearance.BorderSize = 0;
            this.btnStability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStability.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStability.ForeColor = System.Drawing.Color.White;
            this.btnStability.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            this.btnStability.IconColor = System.Drawing.Color.White;
            this.btnStability.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStability.IconSize = 24;
            this.btnStability.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStability.Location = new System.Drawing.Point(0, 438);
            this.btnStability.Margin = new System.Windows.Forms.Padding(2);
            this.btnStability.Name = "btnStability";
            this.btnStability.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnStability.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStability.Size = new System.Drawing.Size(250, 45);
            this.btnStability.TabIndex = 19;
            this.btnStability.Text = "Stability";
            this.btnStability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStability.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStability.UseVisualStyleBackColor = true;
            this.btnStability.Click += new System.EventHandler(this.btnStability_Click);
            // 
            // btnScenario
            // 
            this.btnScenario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScenario.FlatAppearance.BorderSize = 0;
            this.btnScenario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScenario.ForeColor = System.Drawing.Color.White;
            this.btnScenario.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            this.btnScenario.IconColor = System.Drawing.Color.White;
            this.btnScenario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnScenario.IconSize = 24;
            this.btnScenario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScenario.Location = new System.Drawing.Point(0, 393);
            this.btnScenario.Margin = new System.Windows.Forms.Padding(2);
            this.btnScenario.Name = "btnScenario";
            this.btnScenario.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnScenario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnScenario.Size = new System.Drawing.Size(250, 45);
            this.btnScenario.TabIndex = 19;
            this.btnScenario.Text = "Scenario";
            this.btnScenario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScenario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScenario.UseVisualStyleBackColor = true;
            this.btnScenario.Visible = false;
            this.btnScenario.Click += new System.EventHandler(this.btnScenario_Click);
            // 
            // pnlUserSubmenu
            // 
            this.pnlUserSubmenu.Controls.Add(this.btnAccount);
            this.pnlUserSubmenu.Controls.Add(this.btnTrainee);
            this.pnlUserSubmenu.Controls.Add(this.btnInstructor);
            this.pnlUserSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserSubmenu.Location = new System.Drawing.Point(0, 259);
            this.pnlUserSubmenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlUserSubmenu.Name = "pnlUserSubmenu";
            this.pnlUserSubmenu.Size = new System.Drawing.Size(250, 134);
            this.pnlUserSubmenu.TabIndex = 16;
            // 
            // btnAccount
            // 
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnAccount.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnAccount.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAccount.IconSize = 24;
            this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Location = new System.Drawing.Point(0, 90);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(32, 0, 15, 0);
            this.btnAccount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAccount.Size = new System.Drawing.Size(250, 45);
            this.btnAccount.TabIndex = 18;
            this.btnAccount.Text = "Account";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnTrainee
            // 
            this.btnTrainee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrainee.FlatAppearance.BorderSize = 0;
            this.btnTrainee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainee.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnTrainee.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            this.btnTrainee.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnTrainee.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTrainee.IconSize = 24;
            this.btnTrainee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrainee.Location = new System.Drawing.Point(0, 45);
            this.btnTrainee.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrainee.Name = "btnTrainee";
            this.btnTrainee.Padding = new System.Windows.Forms.Padding(32, 0, 15, 0);
            this.btnTrainee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTrainee.Size = new System.Drawing.Size(250, 45);
            this.btnTrainee.TabIndex = 17;
            this.btnTrainee.Text = "Trainee";
            this.btnTrainee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrainee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrainee.UseVisualStyleBackColor = true;
            this.btnTrainee.Click += new System.EventHandler(this.btnTrainee_Click);
            // 
            // btnInstructor
            // 
            this.btnInstructor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInstructor.FlatAppearance.BorderSize = 0;
            this.btnInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstructor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnInstructor.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnInstructor.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnInstructor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInstructor.IconSize = 24;
            this.btnInstructor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstructor.Location = new System.Drawing.Point(0, 0);
            this.btnInstructor.Margin = new System.Windows.Forms.Padding(2);
            this.btnInstructor.Name = "btnInstructor";
            this.btnInstructor.Padding = new System.Windows.Forms.Padding(32, 0, 15, 0);
            this.btnInstructor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnInstructor.Size = new System.Drawing.Size(250, 45);
            this.btnInstructor.TabIndex = 16;
            this.btnInstructor.Text = "Instructor";
            this.btnInstructor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstructor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstructor.UseVisualStyleBackColor = true;
            this.btnInstructor.Click += new System.EventHandler(this.btnInstructor_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnUsers.IconColor = System.Drawing.Color.White;
            this.btnUsers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsers.IconSize = 24;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(0, 214);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnUsers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUsers.Size = new System.Drawing.Size(250, 45);
            this.btnUsers.TabIndex = 15;
            this.btnUsers.Text = "User";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // pnlMasterDataSubmenu
            // 
            this.pnlMasterDataSubmenu.Controls.Add(this.btnCargoData);
            this.pnlMasterDataSubmenu.Controls.Add(this.btnShipData);
            this.pnlMasterDataSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMasterDataSubmenu.Location = new System.Drawing.Point(0, 125);
            this.pnlMasterDataSubmenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMasterDataSubmenu.Name = "pnlMasterDataSubmenu";
            this.pnlMasterDataSubmenu.Size = new System.Drawing.Size(250, 89);
            this.pnlMasterDataSubmenu.TabIndex = 2;
            // 
            // btnCargoData
            // 
            this.btnCargoData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargoData.FlatAppearance.BorderSize = 0;
            this.btnCargoData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargoData.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnCargoData.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.btnCargoData.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnCargoData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCargoData.IconSize = 24;
            this.btnCargoData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargoData.Location = new System.Drawing.Point(0, 45);
            this.btnCargoData.Margin = new System.Windows.Forms.Padding(2);
            this.btnCargoData.Name = "btnCargoData";
            this.btnCargoData.Padding = new System.Windows.Forms.Padding(32, 0, 15, 0);
            this.btnCargoData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCargoData.Size = new System.Drawing.Size(250, 45);
            this.btnCargoData.TabIndex = 14;
            this.btnCargoData.Text = "Cargo";
            this.btnCargoData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargoData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargoData.UseVisualStyleBackColor = true;
            this.btnCargoData.Click += new System.EventHandler(this.btnCargoData_Click);
            // 
            // btnShipData
            // 
            this.btnShipData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShipData.FlatAppearance.BorderSize = 0;
            this.btnShipData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShipData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShipData.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnShipData.IconChar = FontAwesome.Sharp.IconChar.Ship;
            this.btnShipData.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnShipData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShipData.IconSize = 24;
            this.btnShipData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShipData.Location = new System.Drawing.Point(0, 0);
            this.btnShipData.Margin = new System.Windows.Forms.Padding(2);
            this.btnShipData.Name = "btnShipData";
            this.btnShipData.Padding = new System.Windows.Forms.Padding(32, 0, 15, 0);
            this.btnShipData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnShipData.Size = new System.Drawing.Size(250, 45);
            this.btnShipData.TabIndex = 13;
            this.btnShipData.Text = "Ship";
            this.btnShipData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShipData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShipData.UseVisualStyleBackColor = true;
            this.btnShipData.Click += new System.EventHandler(this.btnShipData_Click);
            // 
            // btnMasterData
            // 
            this.btnMasterData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMasterData.FlatAppearance.BorderSize = 0;
            this.btnMasterData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterData.ForeColor = System.Drawing.Color.White;
            this.btnMasterData.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnMasterData.IconColor = System.Drawing.Color.White;
            this.btnMasterData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMasterData.IconSize = 24;
            this.btnMasterData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasterData.Location = new System.Drawing.Point(0, 80);
            this.btnMasterData.Margin = new System.Windows.Forms.Padding(2);
            this.btnMasterData.Name = "btnMasterData";
            this.btnMasterData.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnMasterData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMasterData.Size = new System.Drawing.Size(250, 45);
            this.btnMasterData.TabIndex = 1;
            this.btnMasterData.Text = "Master Data";
            this.btnMasterData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasterData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMasterData.UseVisualStyleBackColor = true;
            this.btnMasterData.Click += new System.EventHandler(this.btnMasterData_Click);
            // 
            // pnlUserPic
            // 
            this.pnlUserPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.pnlUserPic.Controls.Add(this.btnLogout);
            this.pnlUserPic.Controls.Add(this.lblPriviledge);
            this.pnlUserPic.Controls.Add(this.lblUsername);
            this.pnlUserPic.Controls.Add(this.userPic);
            this.pnlUserPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserPic.Location = new System.Drawing.Point(0, 0);
            this.pnlUserPic.Margin = new System.Windows.Forms.Padding(2);
            this.pnlUserPic.Name = "pnlUserPic";
            this.pnlUserPic.Size = new System.Drawing.Size(250, 80);
            this.pnlUserPic.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnLogout.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnLogout.BackgroundImage = global::SSClient.Properties.Resources.logout1;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogout.BorderRadius = 28;
            this.btnLogout.BorderSize = 0;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(210, 20);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(26, 28);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.TextColor = System.Drawing.Color.White;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblPriviledge
            // 
            this.lblPriviledge.AutoSize = true;
            this.lblPriviledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriviledge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.lblPriviledge.Location = new System.Drawing.Point(76, 39);
            this.lblPriviledge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPriviledge.Name = "lblPriviledge";
            this.lblPriviledge.Size = new System.Drawing.Size(76, 15);
            this.lblPriviledge.TabIndex = 3;
            this.lblPriviledge.Text = "super admin";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(76, 20);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(88, 20);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "username";
            // 
            // userPic
            // 
            this.userPic.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.userPic.BorderColor = System.Drawing.Color.RoyalBlue;
            this.userPic.BorderColor2 = System.Drawing.Color.HotPink;
            this.userPic.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.userPic.BorderSize = 1;
            this.userPic.GradientAngle = 50F;
            this.userPic.Image = global::SSClient.Properties.Resources.user;
            this.userPic.Location = new System.Drawing.Point(8, 9);
            this.userPic.Margin = new System.Windows.Forms.Padding(2);
            this.userPic.Name = "userPic";
            this.userPic.Size = new System.Drawing.Size(54, 58);
            this.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPic.TabIndex = 1;
            this.userPic.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(250, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1334, 821);
            this.pnlContent.TabIndex = 1;
            // 
            // formDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1584, 821);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMainMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSClient";
            this.Load += new System.EventHandler(this.formDashboard_Load);
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlUserSubmenu.ResumeLayout(false);
            this.pnlMasterDataSubmenu.ResumeLayout(false);
            this.pnlUserPic.ResumeLayout(false);
            this.pnlUserPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.Panel pnlUserPic;
        private FontAwesome.Sharp.IconButton btnMasterData;
        private System.Windows.Forms.Panel pnlMasterDataSubmenu;
        private FontAwesome.Sharp.IconButton btnShipData;
        private FontAwesome.Sharp.IconButton btnCargoData;
        private FontAwesome.Sharp.IconButton btnUsers;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnClientList;
        private FontAwesome.Sharp.IconButton btnReport;
        private FontAwesome.Sharp.IconButton btnScenario;
        private FontAwesome.Sharp.IconButton btnStability;
        private System.Windows.Forms.Panel pnlUserSubmenu;
        private FontAwesome.Sharp.IconButton btnAccount;
        private FontAwesome.Sharp.IconButton btnTrainee;
        private FontAwesome.Sharp.IconButton btnInstructor;
        private System.Windows.Forms.Panel pnlContent;
        private ViControls.CircularPicture userPic;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPriviledge;
        private ViControls.ViButton btnLogout;
        private System.Windows.Forms.Panel hiddenPannel;
    }
}

