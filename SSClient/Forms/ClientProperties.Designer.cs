
namespace SSClient.Forms
{
    partial class ClientProperties
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbPing = new System.Windows.Forms.GroupBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.lbMAC = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbPing.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gbPing);
            this.panel1.Controls.Add(this.txtMacAddress);
            this.panel1.Controls.Add(this.lbMAC);
            this.panel1.Controls.Add(this.txtMachineName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Location = new System.Drawing.Point(25, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 214);
            this.panel1.TabIndex = 0;
            // 
            // gbPing
            // 
            this.gbPing.Controls.Add(this.txtIPAddress);
            this.gbPing.Controls.Add(this.label1);
            this.gbPing.Location = new System.Drawing.Point(34, 113);
            this.gbPing.Name = "gbPing";
            this.gbPing.Size = new System.Drawing.Size(418, 70);
            this.gbPing.TabIndex = 7;
            this.gbPing.TabStop = false;
            this.gbPing.Text = "Ping";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(179, 30);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(171, 22);
            this.txtIPAddress.TabIndex = 7;
            this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIPAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Local IP Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Location = new System.Drawing.Point(153, 72);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(172, 22);
            this.txtMacAddress.TabIndex = 6;
            this.txtMacAddress.TextChanged += new System.EventHandler(this.txtMacAddress_TextChanged);
            // 
            // lbMAC
            // 
            this.lbMAC.AutoSize = true;
            this.lbMAC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMAC.Location = new System.Drawing.Point(31, 75);
            this.lbMAC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMAC.Name = "lbMAC";
            this.lbMAC.Size = new System.Drawing.Size(93, 17);
            this.lbMAC.TabIndex = 5;
            this.lbMAC.Text = "MAC Address";
            this.lbMAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMachineName
            // 
            this.txtMachineName.Location = new System.Drawing.Point(153, 29);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(299, 22);
            this.txtMachineName.TabIndex = 4;
            this.txtMachineName.TextChanged += new System.EventHandler(this.txtMachineName_TextChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbName.Location = new System.Drawing.Point(79, 32);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(45, 17);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(321, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(416, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ClientProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 322);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Name = "ClientProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.Load += new System.EventHandler(this.ClientProperties_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbPing.ResumeLayout(false);
            this.gbPing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.TextBox txtMacAddress;
        internal System.Windows.Forms.Label lbMAC;
        private System.Windows.Forms.GroupBox gbPing;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddress;
    }
}