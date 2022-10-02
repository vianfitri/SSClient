
namespace SSClient.Forms
{
    partial class fDbConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDbHost = new ViControls.ViTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbPort = new ViControls.ViTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDbUser = new ViControls.ViTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDbPass = new ViControls.ViTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveConfig = new ViControls.ViButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Database Configuration";
            // 
            // txtDbHost
            // 
            this.txtDbHost.BackColor = System.Drawing.SystemColors.Window;
            this.txtDbHost.BorderColor = System.Drawing.Color.Gray;
            this.txtDbHost.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtDbHost.BorderRadius = 10;
            this.txtDbHost.BorderSize = 1;
            this.txtDbHost.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbHost.ForeColor = System.Drawing.Color.DimGray;
            this.txtDbHost.Location = new System.Drawing.Point(201, 91);
            this.txtDbHost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDbHost.Multiline = false;
            this.txtDbHost.Name = "txtDbHost";
            this.txtDbHost.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDbHost.PasswordChar = false;
            this.txtDbHost.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDbHost.PlaceholderText = "";
            this.txtDbHost.Size = new System.Drawing.Size(219, 39);
            this.txtDbHost.TabIndex = 19;
            this.txtDbHost.Texts = "";
            this.txtDbHost.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Server";
            // 
            // txtDbPort
            // 
            this.txtDbPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtDbPort.BorderColor = System.Drawing.Color.Gray;
            this.txtDbPort.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtDbPort.BorderRadius = 10;
            this.txtDbPort.BorderSize = 1;
            this.txtDbPort.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbPort.ForeColor = System.Drawing.Color.DimGray;
            this.txtDbPort.Location = new System.Drawing.Point(201, 145);
            this.txtDbPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDbPort.Multiline = false;
            this.txtDbPort.Name = "txtDbPort";
            this.txtDbPort.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDbPort.PasswordChar = false;
            this.txtDbPort.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDbPort.PlaceholderText = "";
            this.txtDbPort.Size = new System.Drawing.Size(219, 39);
            this.txtDbPort.TabIndex = 21;
            this.txtDbPort.Texts = "";
            this.txtDbPort.UnderlinedStyle = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "Port";
            // 
            // txtDbUser
            // 
            this.txtDbUser.BackColor = System.Drawing.SystemColors.Window;
            this.txtDbUser.BorderColor = System.Drawing.Color.Gray;
            this.txtDbUser.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtDbUser.BorderRadius = 10;
            this.txtDbUser.BorderSize = 1;
            this.txtDbUser.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbUser.ForeColor = System.Drawing.Color.DimGray;
            this.txtDbUser.Location = new System.Drawing.Point(201, 200);
            this.txtDbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDbUser.Multiline = false;
            this.txtDbUser.Name = "txtDbUser";
            this.txtDbUser.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDbUser.PasswordChar = false;
            this.txtDbUser.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDbUser.PlaceholderText = "";
            this.txtDbUser.Size = new System.Drawing.Size(219, 39);
            this.txtDbUser.TabIndex = 23;
            this.txtDbUser.Texts = "";
            this.txtDbUser.UnderlinedStyle = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(83, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Username";
            // 
            // txtDbPass
            // 
            this.txtDbPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtDbPass.BorderColor = System.Drawing.Color.Gray;
            this.txtDbPass.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtDbPass.BorderRadius = 10;
            this.txtDbPass.BorderSize = 1;
            this.txtDbPass.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtDbPass.Location = new System.Drawing.Point(201, 255);
            this.txtDbPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDbPass.Multiline = false;
            this.txtDbPass.Name = "txtDbPass";
            this.txtDbPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDbPass.PasswordChar = true;
            this.txtDbPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDbPass.PlaceholderText = "";
            this.txtDbPass.Size = new System.Drawing.Size(219, 39);
            this.txtDbPass.TabIndex = 25;
            this.txtDbPass.Texts = "";
            this.txtDbPass.UnderlinedStyle = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 24);
            this.label5.TabIndex = 24;
            this.label5.Text = "Password";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(184)))), ((int)(((byte)(249)))));
            this.btnSaveConfig.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(184)))), ((int)(((byte)(249)))));
            this.btnSaveConfig.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSaveConfig.BorderRadius = 10;
            this.btnSaveConfig.BorderSize = 0;
            this.btnSaveConfig.FlatAppearance.BorderSize = 0;
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConfig.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveConfig.ForeColor = System.Drawing.Color.White;
            this.btnSaveConfig.Location = new System.Drawing.Point(201, 325);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(150, 40);
            this.btnSaveConfig.TabIndex = 26;
            this.btnSaveConfig.Text = "Save";
            this.btnSaveConfig.TextColor = System.Drawing.Color.White;
            this.btnSaveConfig.UseVisualStyleBackColor = false;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // fDbConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 397);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.txtDbPass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDbUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDbPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDbHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fDbConfig";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ViControls.ViTextBox txtDbHost;
        private System.Windows.Forms.Label label2;
        private ViControls.ViTextBox txtDbPort;
        private System.Windows.Forms.Label label3;
        private ViControls.ViTextBox txtDbUser;
        private System.Windows.Forms.Label label4;
        private ViControls.ViTextBox txtDbPass;
        private System.Windows.Forms.Label label5;
        private ViControls.ViButton btnSaveConfig;
    }
}