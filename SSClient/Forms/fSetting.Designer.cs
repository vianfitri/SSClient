
namespace SSClient.Forms
{
    partial class fSetting
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
            this.viPanel1 = new ViControls.ViPanel();
            this.btnPassChange = new ViControls.ViButton();
            this.txtRetypePass = new ViControls.ViTextBox();
            this.txtNewPass = new ViControls.ViTextBox();
            this.txtOldPass = new ViControls.ViTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.viPanel2 = new ViControls.ViPanel();
            this.btnDBConnChange = new ViControls.ViButton();
            this.txtDBName = new ViControls.ViTextBox();
            this.txtDBPass = new ViControls.ViTextBox();
            this.txtBDUser = new ViControls.ViTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.viPanel1.SuspendLayout();
            this.viPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Setting";
            // 
            // viPanel1
            // 
            this.viPanel1.BackColor = System.Drawing.Color.White;
            this.viPanel1.Controls.Add(this.btnPassChange);
            this.viPanel1.Controls.Add(this.txtRetypePass);
            this.viPanel1.Controls.Add(this.txtNewPass);
            this.viPanel1.Controls.Add(this.txtOldPass);
            this.viPanel1.Controls.Add(this.label14);
            this.viPanel1.Controls.Add(this.label15);
            this.viPanel1.Controls.Add(this.label16);
            this.viPanel1.Controls.Add(this.label17);
            this.viPanel1.Location = new System.Drawing.Point(455, 128);
            this.viPanel1.MBack = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.viPanel1.MMatrixRound = 15;
            this.viPanel1.Name = "viPanel1";
            this.viPanel1.Size = new System.Drawing.Size(337, 413);
            this.viPanel1.TabIndex = 12;
            // 
            // btnPassChange
            // 
            this.btnPassChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(162)))), ((int)(((byte)(220)))));
            this.btnPassChange.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(162)))), ((int)(((byte)(220)))));
            this.btnPassChange.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPassChange.BorderRadius = 10;
            this.btnPassChange.BorderSize = 0;
            this.btnPassChange.FlatAppearance.BorderSize = 0;
            this.btnPassChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassChange.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassChange.ForeColor = System.Drawing.Color.White;
            this.btnPassChange.Location = new System.Drawing.Point(183, 318);
            this.btnPassChange.Name = "btnPassChange";
            this.btnPassChange.Size = new System.Drawing.Size(107, 40);
            this.btnPassChange.TabIndex = 15;
            this.btnPassChange.Text = "Change";
            this.btnPassChange.TextColor = System.Drawing.Color.White;
            this.btnPassChange.UseVisualStyleBackColor = false;
            this.btnPassChange.Click += new System.EventHandler(this.btnPassChange_Click);
            // 
            // txtRetypePass
            // 
            this.txtRetypePass.BackColor = System.Drawing.SystemColors.Window;
            this.txtRetypePass.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtRetypePass.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtRetypePass.BorderRadius = 8;
            this.txtRetypePass.BorderSize = 1;
            this.txtRetypePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetypePass.ForeColor = System.Drawing.Color.DimGray;
            this.txtRetypePass.Location = new System.Drawing.Point(37, 262);
            this.txtRetypePass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRetypePass.Multiline = false;
            this.txtRetypePass.Name = "txtRetypePass";
            this.txtRetypePass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtRetypePass.PasswordChar = true;
            this.txtRetypePass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtRetypePass.PlaceholderText = "Re-type Password";
            this.txtRetypePass.Size = new System.Drawing.Size(253, 35);
            this.txtRetypePass.TabIndex = 14;
            this.txtRetypePass.Texts = "";
            this.txtRetypePass.UnderlinedStyle = false;
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewPass.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtNewPass.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNewPass.BorderRadius = 8;
            this.txtNewPass.BorderSize = 1;
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtNewPass.Location = new System.Drawing.Point(37, 186);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPass.Multiline = false;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNewPass.PasswordChar = true;
            this.txtNewPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNewPass.PlaceholderText = "New Password";
            this.txtNewPass.Size = new System.Drawing.Size(253, 35);
            this.txtNewPass.TabIndex = 13;
            this.txtNewPass.Texts = "";
            this.txtNewPass.UnderlinedStyle = false;
            // 
            // txtOldPass
            // 
            this.txtOldPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldPass.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtOldPass.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtOldPass.BorderRadius = 8;
            this.txtOldPass.BorderSize = 1;
            this.txtOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtOldPass.Location = new System.Drawing.Point(37, 113);
            this.txtOldPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOldPass.Multiline = false;
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtOldPass.PasswordChar = true;
            this.txtOldPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOldPass.PlaceholderText = "Old Password";
            this.txtOldPass.Size = new System.Drawing.Size(253, 35);
            this.txtOldPass.TabIndex = 12;
            this.txtOldPass.Texts = "";
            this.txtOldPass.UnderlinedStyle = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.label14.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(33, 238);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 20);
            this.label14.TabIndex = 11;
            this.label14.Text = "Re-type Password";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.label15.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(33, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 20);
            this.label15.TabIndex = 10;
            this.label15.Text = "New Password";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.label16.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(33, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 20);
            this.label16.TabIndex = 9;
            this.label16.Text = "Old Password";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.label17.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(33, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(218, 20);
            this.label17.TabIndex = 8;
            this.label17.Text = "Change Password Account";
            // 
            // viPanel2
            // 
            this.viPanel2.Controls.Add(this.btnDBConnChange);
            this.viPanel2.Controls.Add(this.txtDBName);
            this.viPanel2.Controls.Add(this.txtDBPass);
            this.viPanel2.Controls.Add(this.txtBDUser);
            this.viPanel2.Controls.Add(this.label10);
            this.viPanel2.Controls.Add(this.label11);
            this.viPanel2.Controls.Add(this.label12);
            this.viPanel2.Controls.Add(this.label13);
            this.viPanel2.Location = new System.Drawing.Point(64, 128);
            this.viPanel2.MBack = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(221)))));
            this.viPanel2.MMatrixRound = 15;
            this.viPanel2.Name = "viPanel2";
            this.viPanel2.Size = new System.Drawing.Size(337, 413);
            this.viPanel2.TabIndex = 13;
            // 
            // btnDBConnChange
            // 
            this.btnDBConnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(162)))), ((int)(((byte)(220)))));
            this.btnDBConnChange.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(162)))), ((int)(((byte)(220)))));
            this.btnDBConnChange.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDBConnChange.BorderRadius = 10;
            this.btnDBConnChange.BorderSize = 0;
            this.btnDBConnChange.FlatAppearance.BorderSize = 0;
            this.btnDBConnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDBConnChange.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBConnChange.ForeColor = System.Drawing.Color.White;
            this.btnDBConnChange.Location = new System.Drawing.Point(183, 318);
            this.btnDBConnChange.Name = "btnDBConnChange";
            this.btnDBConnChange.Size = new System.Drawing.Size(107, 40);
            this.btnDBConnChange.TabIndex = 15;
            this.btnDBConnChange.Text = "Change";
            this.btnDBConnChange.TextColor = System.Drawing.Color.White;
            this.btnDBConnChange.UseVisualStyleBackColor = false;
            // 
            // txtDBName
            // 
            this.txtDBName.BackColor = System.Drawing.SystemColors.Window;
            this.txtDBName.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDBName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDBName.BorderRadius = 8;
            this.txtDBName.BorderSize = 1;
            this.txtDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBName.ForeColor = System.Drawing.Color.DimGray;
            this.txtDBName.Location = new System.Drawing.Point(37, 262);
            this.txtDBName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDBName.Multiline = false;
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDBName.PasswordChar = false;
            this.txtDBName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDBName.PlaceholderText = "";
            this.txtDBName.Size = new System.Drawing.Size(253, 35);
            this.txtDBName.TabIndex = 14;
            this.txtDBName.Texts = "Database";
            this.txtDBName.UnderlinedStyle = false;
            // 
            // txtDBPass
            // 
            this.txtDBPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtDBPass.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDBPass.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDBPass.BorderRadius = 8;
            this.txtDBPass.BorderSize = 1;
            this.txtDBPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtDBPass.Location = new System.Drawing.Point(37, 186);
            this.txtDBPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDBPass.Multiline = false;
            this.txtDBPass.Name = "txtDBPass";
            this.txtDBPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDBPass.PasswordChar = true;
            this.txtDBPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDBPass.PlaceholderText = "Password";
            this.txtDBPass.Size = new System.Drawing.Size(253, 35);
            this.txtDBPass.TabIndex = 13;
            this.txtDBPass.Texts = "";
            this.txtDBPass.UnderlinedStyle = false;
            // 
            // txtBDUser
            // 
            this.txtBDUser.BackColor = System.Drawing.SystemColors.Window;
            this.txtBDUser.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtBDUser.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtBDUser.BorderRadius = 8;
            this.txtBDUser.BorderSize = 1;
            this.txtBDUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDUser.ForeColor = System.Drawing.Color.DimGray;
            this.txtBDUser.Location = new System.Drawing.Point(37, 113);
            this.txtBDUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBDUser.Multiline = false;
            this.txtBDUser.Name = "txtBDUser";
            this.txtBDUser.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBDUser.PasswordChar = false;
            this.txtBDUser.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBDUser.PlaceholderText = "Username";
            this.txtBDUser.Size = new System.Drawing.Size(253, 35);
            this.txtBDUser.TabIndex = 12;
            this.txtBDUser.Texts = "";
            this.txtBDUser.UnderlinedStyle = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(221)))));
            this.label10.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(33, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Database";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(221)))));
            this.label11.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Password";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(221)))));
            this.label12.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(33, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "Username";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(221)))));
            this.label13.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(33, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(175, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Database Connection";
            // 
            // fSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 721);
            this.Controls.Add(this.viPanel2);
            this.Controls.Add(this.viPanel1);
            this.Controls.Add(this.label1);
            this.Name = "fSetting";
            this.Text = "fSetting";
            this.viPanel1.ResumeLayout(false);
            this.viPanel1.PerformLayout();
            this.viPanel2.ResumeLayout(false);
            this.viPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ViControls.ViPanel viPanel1;
        private ViControls.ViButton btnPassChange;
        private ViControls.ViTextBox txtRetypePass;
        private ViControls.ViTextBox txtNewPass;
        private ViControls.ViTextBox txtOldPass;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private ViControls.ViPanel viPanel2;
        private ViControls.ViButton btnDBConnChange;
        private ViControls.ViTextBox txtDBName;
        private ViControls.ViTextBox txtDBPass;
        private ViControls.ViTextBox txtBDUser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}