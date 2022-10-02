
namespace SSClient.Forms
{
    partial class fAddTrainee
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
            this.btnTraineeAdd = new ViControls.ViButton();
            this.txtTraineeName = new ViControls.ViTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTraineeNIT = new ViControls.ViTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTraineeLevel = new ViControls.ViTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTraineeAdd
            // 
            this.btnTraineeAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnTraineeAdd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnTraineeAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTraineeAdd.BorderRadius = 10;
            this.btnTraineeAdd.BorderSize = 0;
            this.btnTraineeAdd.FlatAppearance.BorderSize = 0;
            this.btnTraineeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraineeAdd.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraineeAdd.ForeColor = System.Drawing.Color.White;
            this.btnTraineeAdd.Location = new System.Drawing.Point(242, 265);
            this.btnTraineeAdd.Name = "btnTraineeAdd";
            this.btnTraineeAdd.Size = new System.Drawing.Size(150, 40);
            this.btnTraineeAdd.TabIndex = 9;
            this.btnTraineeAdd.Text = "ADD";
            this.btnTraineeAdd.TextColor = System.Drawing.Color.White;
            this.btnTraineeAdd.UseVisualStyleBackColor = false;
            this.btnTraineeAdd.Click += new System.EventHandler(this.btnTraineeAdd_Click);
            // 
            // txtTraineeName
            // 
            this.txtTraineeName.BackColor = System.Drawing.SystemColors.Window;
            this.txtTraineeName.BorderColor = System.Drawing.Color.Gray;
            this.txtTraineeName.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtTraineeName.BorderRadius = 10;
            this.txtTraineeName.BorderSize = 1;
            this.txtTraineeName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraineeName.ForeColor = System.Drawing.Color.DimGray;
            this.txtTraineeName.Location = new System.Drawing.Point(195, 71);
            this.txtTraineeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTraineeName.Multiline = false;
            this.txtTraineeName.Name = "txtTraineeName";
            this.txtTraineeName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTraineeName.PasswordChar = false;
            this.txtTraineeName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTraineeName.PlaceholderText = "Full Name";
            this.txtTraineeName.Size = new System.Drawing.Size(354, 39);
            this.txtTraineeName.TabIndex = 8;
            this.txtTraineeName.Texts = "";
            this.txtTraineeName.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Full Name";
            // 
            // txtTraineeNIT
            // 
            this.txtTraineeNIT.BackColor = System.Drawing.SystemColors.Window;
            this.txtTraineeNIT.BorderColor = System.Drawing.Color.Gray;
            this.txtTraineeNIT.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtTraineeNIT.BorderRadius = 10;
            this.txtTraineeNIT.BorderSize = 1;
            this.txtTraineeNIT.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraineeNIT.ForeColor = System.Drawing.Color.DimGray;
            this.txtTraineeNIT.Location = new System.Drawing.Point(195, 123);
            this.txtTraineeNIT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTraineeNIT.Multiline = false;
            this.txtTraineeNIT.Name = "txtTraineeNIT";
            this.txtTraineeNIT.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTraineeNIT.PasswordChar = false;
            this.txtTraineeNIT.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTraineeNIT.PlaceholderText = "NIT";
            this.txtTraineeNIT.Size = new System.Drawing.Size(354, 39);
            this.txtTraineeNIT.TabIndex = 11;
            this.txtTraineeNIT.Texts = "";
            this.txtTraineeNIT.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "NIT";
            // 
            // txtTraineeLevel
            // 
            this.txtTraineeLevel.BackColor = System.Drawing.SystemColors.Window;
            this.txtTraineeLevel.BorderColor = System.Drawing.Color.Gray;
            this.txtTraineeLevel.BorderFocusColor = System.Drawing.Color.SkyBlue;
            this.txtTraineeLevel.BorderRadius = 10;
            this.txtTraineeLevel.BorderSize = 1;
            this.txtTraineeLevel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraineeLevel.ForeColor = System.Drawing.Color.DimGray;
            this.txtTraineeLevel.Location = new System.Drawing.Point(193, 179);
            this.txtTraineeLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTraineeLevel.Multiline = false;
            this.txtTraineeLevel.Name = "txtTraineeLevel";
            this.txtTraineeLevel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTraineeLevel.PasswordChar = false;
            this.txtTraineeLevel.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTraineeLevel.PlaceholderText = "Level";
            this.txtTraineeLevel.Size = new System.Drawing.Size(179, 39);
            this.txtTraineeLevel.TabIndex = 13;
            this.txtTraineeLevel.Texts = "";
            this.txtTraineeLevel.UnderlinedStyle = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Level";
            // 
            // fAddTrainee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 347);
            this.Controls.Add(this.txtTraineeLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTraineeNIT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTraineeAdd);
            this.Controls.Add(this.txtTraineeName);
            this.Controls.Add(this.label2);
            this.Name = "fAddTrainee";
            this.Text = "ADD TRAINEE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ViControls.ViButton btnTraineeAdd;
        private ViControls.ViTextBox txtTraineeName;
        private System.Windows.Forms.Label label2;
        private ViControls.ViTextBox txtTraineeNIT;
        private System.Windows.Forms.Label label1;
        private ViControls.ViTextBox txtTraineeLevel;
        private System.Windows.Forms.Label label3;
    }
}