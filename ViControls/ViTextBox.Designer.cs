
namespace ViControls
{
    partial class ViTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBase
            // 
            this.txtBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase.Location = new System.Drawing.Point(10, 7);
            this.txtBase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(230, 18);
            this.txtBase.TabIndex = 0;
            this.txtBase.Click += new System.EventHandler(this.txtBase_Click);
            this.txtBase.TextChanged += new System.EventHandler(this.txtBase_TextChanged);
            this.txtBase.Enter += new System.EventHandler(this.txtBase_Enter);
            this.txtBase.Leave += new System.EventHandler(this.txtBase_Leave);
            this.txtBase.MouseEnter += new System.EventHandler(this.txtBase_MouseEnter);
            this.txtBase.MouseLeave += new System.EventHandler(this.txtBase_MouseLeave);
            // 
            // ViTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.txtBase);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ViTextBox";
            this.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.Size = new System.Drawing.Size(250, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBase;
    }
}
