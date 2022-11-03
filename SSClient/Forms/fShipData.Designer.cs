
namespace SSClient.Forms
{
    partial class fShipData
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pnlShipView = new System.Windows.Forms.Panel();
            this.pbShipImage = new System.Windows.Forms.PictureBox();
            this.pnlShipDetail = new System.Windows.Forms.Panel();
            this.lblDraft = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.lblBreadth = new System.Windows.Forms.Label();
            this.lblLbp = new System.Windows.Forms.Label();
            this.lblLoa = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShipType = new System.Windows.Forms.Label();
            this.pnlShipView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShipImage)).BeginInit();
            this.pnlShipDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ship Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(118)))), ((int)(((byte)(159)))));
            this.label2.Location = new System.Drawing.Point(45, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Ship";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "50000 DWT Bulk Carrier",
            "3650 DWT General Cargo",
            "4180 DWT Full Container"});
            this.comboBox1.Location = new System.Drawing.Point(145, 131);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "-- Choose --";
            // 
            // pnlShipView
            // 
            this.pnlShipView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShipView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.pnlShipView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipView.Controls.Add(this.pbShipImage);
            this.pnlShipView.Controls.Add(this.pnlShipDetail);
            this.pnlShipView.Location = new System.Drawing.Point(49, 178);
            this.pnlShipView.Margin = new System.Windows.Forms.Padding(2);
            this.pnlShipView.Name = "pnlShipView";
            this.pnlShipView.Size = new System.Drawing.Size(1220, 565);
            this.pnlShipView.TabIndex = 5;
            // 
            // pbShipImage
            // 
            this.pbShipImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbShipImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbShipImage.Location = new System.Drawing.Point(0, 0);
            this.pbShipImage.Name = "pbShipImage";
            this.pbShipImage.Size = new System.Drawing.Size(936, 563);
            this.pbShipImage.TabIndex = 1;
            this.pbShipImage.TabStop = false;
            // 
            // pnlShipDetail
            // 
            this.pnlShipDetail.BackColor = System.Drawing.Color.Silver;
            this.pnlShipDetail.Controls.Add(this.lblDraft);
            this.pnlShipDetail.Controls.Add(this.lblDepth);
            this.pnlShipDetail.Controls.Add(this.lblBreadth);
            this.pnlShipDetail.Controls.Add(this.lblLbp);
            this.pnlShipDetail.Controls.Add(this.lblLoa);
            this.pnlShipDetail.Controls.Add(this.label8);
            this.pnlShipDetail.Controls.Add(this.label7);
            this.pnlShipDetail.Controls.Add(this.label6);
            this.pnlShipDetail.Controls.Add(this.label5);
            this.pnlShipDetail.Controls.Add(this.label4);
            this.pnlShipDetail.Controls.Add(this.lblShipType);
            this.pnlShipDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlShipDetail.Location = new System.Drawing.Point(936, 0);
            this.pnlShipDetail.Name = "pnlShipDetail";
            this.pnlShipDetail.Size = new System.Drawing.Size(282, 563);
            this.pnlShipDetail.TabIndex = 0;
            // 
            // lblDraft
            // 
            this.lblDraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraft.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDraft.Location = new System.Drawing.Point(185, 192);
            this.lblDraft.Name = "lblDraft";
            this.lblDraft.Size = new System.Drawing.Size(76, 16);
            this.lblDraft.TabIndex = 10;
            this.lblDraft.Text = "12.800 M";
            this.lblDraft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepth
            // 
            this.lblDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDepth.Location = new System.Drawing.Point(185, 160);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(76, 16);
            this.lblDepth.TabIndex = 9;
            this.lblDepth.Text = "17.500 M";
            this.lblDepth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBreadth
            // 
            this.lblBreadth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBreadth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBreadth.Location = new System.Drawing.Point(185, 128);
            this.lblBreadth.Name = "lblBreadth";
            this.lblBreadth.Size = new System.Drawing.Size(76, 16);
            this.lblBreadth.TabIndex = 8;
            this.lblBreadth.Text = "30.500 M";
            this.lblBreadth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLbp
            // 
            this.lblLbp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLbp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLbp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLbp.Location = new System.Drawing.Point(185, 98);
            this.lblLbp.Name = "lblLbp";
            this.lblLbp.Size = new System.Drawing.Size(76, 16);
            this.lblLbp.TabIndex = 7;
            this.lblLbp.Text = "182.300 M";
            this.lblLbp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoa
            // 
            this.lblLoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLoa.Location = new System.Drawing.Point(185, 65);
            this.lblLoa.Name = "lblLoa";
            this.lblLoa.Size = new System.Drawing.Size(76, 16);
            this.lblLoa.TabIndex = 6;
            this.lblLoa.Text = "189.998 M";
            this.lblLoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "DRAFT";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "DEPTH";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "BREADTH";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "LENGTH (P.P.)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "LENGTH (O.A.)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblShipType
            // 
            this.lblShipType.AutoSize = true;
            this.lblShipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipType.Location = new System.Drawing.Point(24, 20);
            this.lblShipType.Name = "lblShipType";
            this.lblShipType.Size = new System.Drawing.Size(222, 18);
            this.lblShipType.TabIndex = 0;
            this.lblShipType.Text = "BULK CARRIER 50000 DWT";
            this.lblShipType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fShipData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 782);
            this.Controls.Add(this.pnlShipView);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fShipData";
            this.Text = "fShipData";
            this.Activated += new System.EventHandler(this.fShipData_Activated);
            this.Deactivate += new System.EventHandler(this.fShipData_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fShipData_FormClosed);
            this.Load += new System.EventHandler(this.fShipData_Load);
            this.pnlShipView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbShipImage)).EndInit();
            this.pnlShipDetail.ResumeLayout(false);
            this.pnlShipDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel pnlShipView;
        private System.Windows.Forms.PictureBox pbShipImage;
        private System.Windows.Forms.Panel pnlShipDetail;
        private System.Windows.Forms.Label lblDraft;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.Label lblBreadth;
        private System.Windows.Forms.Label lblLbp;
        private System.Windows.Forms.Label lblLoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblShipType;
    }
}