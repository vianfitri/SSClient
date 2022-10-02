
namespace SSClient.Forms
{
    partial class fAddInstructor
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNIP = new ViControls.ViTextBox();
            this.txtName = new ViControls.ViTextBox();
            this.txtLevel = new ViControls.ViTextBox();
            this.btnAdd = new ViControls.ViButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "NIP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level";
            // 
            // txtNIP
            // 
            this.txtNIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtNIP.BorderColor = System.Drawing.Color.Gray;
            this.txtNIP.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtNIP.BorderRadius = 10;
            this.txtNIP.BorderSize = 1;
            this.txtNIP.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIP.ForeColor = System.Drawing.Color.DimGray;
            this.txtNIP.Location = new System.Drawing.Point(175, 52);
            this.txtNIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNIP.Multiline = false;
            this.txtNIP.Name = "txtNIP";
            this.txtNIP.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNIP.PasswordChar = false;
            this.txtNIP.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNIP.PlaceholderText = "NIP";
            this.txtNIP.Size = new System.Drawing.Size(354, 39);
            this.txtNIP.TabIndex = 3;
            this.txtNIP.Texts = "";
            this.txtNIP.UnderlinedStyle = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.BorderColor = System.Drawing.Color.Gray;
            this.txtName.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtName.BorderRadius = 10;
            this.txtName.BorderSize = 1;
            this.txtName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.DimGray;
            this.txtName.Location = new System.Drawing.Point(175, 99);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtName.PasswordChar = false;
            this.txtName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtName.PlaceholderText = "FULL NAME";
            this.txtName.Size = new System.Drawing.Size(354, 39);
            this.txtName.TabIndex = 4;
            this.txtName.Texts = "";
            this.txtName.UnderlinedStyle = false;
            // 
            // txtLevel
            // 
            this.txtLevel.BackColor = System.Drawing.SystemColors.Window;
            this.txtLevel.BorderColor = System.Drawing.Color.Gray;
            this.txtLevel.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtLevel.BorderRadius = 10;
            this.txtLevel.BorderSize = 1;
            this.txtLevel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevel.ForeColor = System.Drawing.Color.DimGray;
            this.txtLevel.Location = new System.Drawing.Point(175, 146);
            this.txtLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLevel.Multiline = false;
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtLevel.PasswordChar = false;
            this.txtLevel.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtLevel.PlaceholderText = "LEVEL";
            this.txtLevel.Size = new System.Drawing.Size(354, 39);
            this.txtLevel.TabIndex = 5;
            this.txtLevel.Texts = "";
            this.txtLevel.UnderlinedStyle = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnAdd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.BorderSize = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(248, 219);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // fAddInstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 307);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fAddInstructor";
            this.Text = "ADD INSTRUCTOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ViControls.ViTextBox txtNIP;
        private ViControls.ViTextBox txtName;
        private ViControls.ViTextBox txtLevel;
        private ViControls.ViButton btnAdd;
    }
}