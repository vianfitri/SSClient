
namespace SSClient.Forms
{
    partial class fTraineeData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTraineeData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportTrainee = new ViControls.ViButton();
            this.btnAddTrainee = new ViControls.ViButton();
            this.dgv_trainee = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bdgv_Trainee = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_trainee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgv_Trainee)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportTrainee
            // 
            this.btnImportTrainee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportTrainee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))));
            this.btnImportTrainee.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))));
            this.btnImportTrainee.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnImportTrainee.BorderRadius = 10;
            this.btnImportTrainee.BorderSize = 0;
            this.btnImportTrainee.FlatAppearance.BorderSize = 0;
            this.btnImportTrainee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportTrainee.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportTrainee.ForeColor = System.Drawing.Color.White;
            this.btnImportTrainee.Location = new System.Drawing.Point(515, 596);
            this.btnImportTrainee.Name = "btnImportTrainee";
            this.btnImportTrainee.Size = new System.Drawing.Size(150, 40);
            this.btnImportTrainee.TabIndex = 16;
            this.btnImportTrainee.Text = "Import Data";
            this.btnImportTrainee.TextColor = System.Drawing.Color.White;
            this.btnImportTrainee.UseVisualStyleBackColor = false;
            // 
            // btnAddTrainee
            // 
            this.btnAddTrainee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrainee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(184)))), ((int)(((byte)(249)))));
            this.btnAddTrainee.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(184)))), ((int)(((byte)(249)))));
            this.btnAddTrainee.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddTrainee.BorderRadius = 10;
            this.btnAddTrainee.BorderSize = 0;
            this.btnAddTrainee.FlatAppearance.BorderSize = 0;
            this.btnAddTrainee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTrainee.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTrainee.ForeColor = System.Drawing.Color.White;
            this.btnAddTrainee.Location = new System.Drawing.Point(680, 596);
            this.btnAddTrainee.Name = "btnAddTrainee";
            this.btnAddTrainee.Size = new System.Drawing.Size(150, 40);
            this.btnAddTrainee.TabIndex = 15;
            this.btnAddTrainee.Text = "Add Data";
            this.btnAddTrainee.TextColor = System.Drawing.Color.White;
            this.btnAddTrainee.UseVisualStyleBackColor = false;
            this.btnAddTrainee.Click += new System.EventHandler(this.btnAddTrainee_Click);
            // 
            // dgv_trainee
            // 
            this.dgv_trainee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_trainee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_trainee.Location = new System.Drawing.Point(61, 461);
            this.dgv_trainee.Name = "dgv_trainee";
            this.dgv_trainee.RowHeadersWidth = 51;
            this.dgv_trainee.RowTemplate.Height = 24;
            this.dgv_trainee.Size = new System.Drawing.Size(769, 112);
            this.dgv_trainee.TabIndex = 14;
            this.dgv_trainee.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(118)))), ((int)(((byte)(159)))));
            this.label2.Location = new System.Drawing.Point(60, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Trainee";
            // 
            // bdgv_Trainee
            // 
            this.bdgv_Trainee.AllowUserToAddRows = false;
            this.bdgv_Trainee.AllowUserToDeleteRows = false;
            this.bdgv_Trainee.AllowUserToOrderColumns = true;
            this.bdgv_Trainee.AllowUserToResizeColumns = false;
            this.bdgv_Trainee.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.bdgv_Trainee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bdgv_Trainee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bdgv_Trainee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bdgv_Trainee.BackgroundColor = System.Drawing.Color.White;
            this.bdgv_Trainee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bdgv_Trainee.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bdgv_Trainee.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bdgv_Trainee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bdgv_Trainee.ColumnHeadersHeight = 40;
            this.bdgv_Trainee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bdgv_Trainee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bdgv_Trainee.DefaultCellStyle = dataGridViewCellStyle5;
            //this.bdgv_Trainee.DoubleBuffered = true;
            this.bdgv_Trainee.EnableHeadersVisualStyles = false;
            this.bdgv_Trainee.GridColor = System.Drawing.Color.White;
            this.bdgv_Trainee.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.bdgv_Trainee.HeaderForeColor = System.Drawing.Color.White;
            this.bdgv_Trainee.Location = new System.Drawing.Point(61, 160);
            this.bdgv_Trainee.MultiSelect = false;
            this.bdgv_Trainee.Name = "bdgv_Trainee";
            this.bdgv_Trainee.ReadOnly = true;
            this.bdgv_Trainee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bdgv_Trainee.RowHeadersVisible = false;
            this.bdgv_Trainee.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.bdgv_Trainee.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.bdgv_Trainee.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.bdgv_Trainee.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bdgv_Trainee.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bdgv_Trainee.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.bdgv_Trainee.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.bdgv_Trainee.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.bdgv_Trainee.RowTemplate.DividerHeight = 1;
            this.bdgv_Trainee.RowTemplate.Height = 40;
            this.bdgv_Trainee.RowTemplate.ReadOnly = true;
            this.bdgv_Trainee.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bdgv_Trainee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bdgv_Trainee.Size = new System.Drawing.Size(769, 413);
            this.bdgv_Trainee.TabIndex = 17;
            this.bdgv_Trainee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bdgv_Trainee_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NO";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NIT";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Level";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4);
            this.Edit.DefaultCellStyle = dataGridViewCellStyle3;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 14;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(4);
            this.Delete.DefaultCellStyle = dataGridViewCellStyle4;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 14;
            // 
            // fTraineeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 721);
            this.Controls.Add(this.bdgv_Trainee);
            this.Controls.Add(this.btnImportTrainee);
            this.Controls.Add(this.btnAddTrainee);
            this.Controls.Add(this.dgv_trainee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fTraineeData";
            this.Text = "fTraineeData";
            this.Load += new System.EventHandler(this.fTraineeData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_trainee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgv_Trainee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ViControls.ViButton btnImportTrainee;
        private ViControls.ViButton btnAddTrainee;
        private System.Windows.Forms.DataGridView dgv_trainee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bdgv_Trainee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}