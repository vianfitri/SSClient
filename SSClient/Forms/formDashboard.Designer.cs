
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
            this.btnStability = new FontAwesome.Sharp.IconButton();
            this.pnlUserPic = new System.Windows.Forms.Panel();
            this.btnLogout = new ViControls.ViButton();
            this.lblPriviledge = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.userPic = new ViControls.CircularPicture();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeE = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMainMenu.SuspendLayout();
            this.pnlUserPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pnlMainMenu.Controls.Add(this.panel1);
            this.pnlMainMenu.Controls.Add(this.hiddenPannel);
            this.pnlMainMenu.Controls.Add(this.btnSettings);
            this.pnlMainMenu.Controls.Add(this.btnStability);
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
            this.btnSettings.Location = new System.Drawing.Point(0, 125);
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
            this.btnStability.Location = new System.Drawing.Point(0, 80);
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
            this.btnStability.Visible = false;
            this.btnStability.Click += new System.EventHandler(this.btnStability_Click);
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
            this.btnLogout.BackgroundImage = global::SSInstructor.Properties.Resources.logout2;
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
            this.userPic.BackgroundImage = global::SSInstructor.Properties.Resources.user1;
            this.userPic.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.userPic.BorderColor = System.Drawing.Color.RoyalBlue;
            this.userPic.BorderColor2 = System.Drawing.Color.HotPink;
            this.userPic.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.userPic.BorderSize = 1;
            this.userPic.GradientAngle = 50F;
            this.userPic.Image = global::SSInstructor.Properties.Resources.user1;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTimeE);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(250, 174);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elapsed Time";
            // 
            // txtTimeE
            // 
            this.txtTimeE.BackColor = System.Drawing.Color.DimGray;
            this.txtTimeE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimeE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeE.ForeColor = System.Drawing.Color.White;
            this.txtTimeE.Location = new System.Drawing.Point(66, 48);
            this.txtTimeE.Margin = new System.Windows.Forms.Padding(5);
            this.txtTimeE.Name = "txtTimeE";
            this.txtTimeE.ReadOnly = true;
            this.txtTimeE.Size = new System.Drawing.Size(100, 22);
            this.txtTimeE.TabIndex = 1;
            this.txtTimeE.Text = "00:00:00";
            this.txtTimeE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(66, 121);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "00:00:00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(60, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum Time";
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
            this.pnlUserPic.ResumeLayout(false);
            this.pnlUserPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.Panel pnlUserPic;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnStability;
        private System.Windows.Forms.Panel pnlContent;
        private ViControls.CircularPicture userPic;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPriviledge;
        private ViControls.ViButton btnLogout;
        private System.Windows.Forms.Panel hiddenPannel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimeE;
        private System.Windows.Forms.Label label1;
    }
}

