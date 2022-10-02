
namespace SSClient.Forms
{
    partial class View3D
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
            this.pnl3DView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl3DView
            // 
            this.pnl3DView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl3DView.Location = new System.Drawing.Point(33, 61);
            this.pnl3DView.Name = "pnl3DView";
            this.pnl3DView.Size = new System.Drawing.Size(1124, 766);
            this.pnl3DView.TabIndex = 0;
            this.pnl3DView.Resize += new System.EventHandler(this.pnl3DView_Resize);
            // 
            // View3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 853);
            this.Controls.Add(this.pnl3DView);
            this.MinimizeBox = false;
            this.Name = "View3D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View3D";
            this.Activated += new System.EventHandler(this.View3D_Activated);
            this.Deactivate += new System.EventHandler(this.View3D_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.View3D_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl3DView;
    }
}