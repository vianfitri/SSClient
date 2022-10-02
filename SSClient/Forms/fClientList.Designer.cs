
namespace SSClient.Forms
{
    partial class fClientList
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddClient = new ViControls.ViButton();
            this.contextMenuStrip_Machines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wakeUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWakeUpAll = new ViControls.ViButton();
            this.btnShutdownAll = new ViControls.ViButton();
            this.contextMenuStrip_Machines.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(118)))), ((int)(((byte)(159)))));
            this.label2.Location = new System.Drawing.Point(45, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Client";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(46, 130);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(577, 386);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(184)))), ((int)(((byte)(249)))));
            this.btnAddClient.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(184)))), ((int)(((byte)(249)))));
            this.btnAddClient.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddClient.BorderRadius = 10;
            this.btnAddClient.BorderSize = 0;
            this.btnAddClient.FlatAppearance.BorderSize = 0;
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(510, 530);
            this.btnAddClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(112, 32);
            this.btnAddClient.TabIndex = 13;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.TextColor = System.Drawing.Color.White;
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // contextMenuStrip_Machines
            // 
            this.contextMenuStrip_Machines.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Machines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wakeUpToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.toolStripSeparator1,
            this.newHostToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip_Machines.Name = "contextMenuStrip_Machines";
            this.contextMenuStrip_Machines.Size = new System.Drawing.Size(137, 140);
            // 
            // wakeUpToolStripMenuItem
            // 
            this.wakeUpToolStripMenuItem.Image = global::SSClient.Properties.Resources.Stock_Index_Up_16x16;
            this.wakeUpToolStripMenuItem.Name = "wakeUpToolStripMenuItem";
            this.wakeUpToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.wakeUpToolStripMenuItem.Text = "Wake Up";
            this.wakeUpToolStripMenuItem.Click += new System.EventHandler(this.wakeUpToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Enabled = false;
            this.shutdownToolStripMenuItem.Image = global::SSClient.Properties.Resources.Stock_Index_Down_16x16;
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.shutdownToolStripMenuItem.Text = "Shut Down";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // newHostToolStripMenuItem
            // 
            this.newHostToolStripMenuItem.Image = global::SSClient.Properties.Resources._new;
            this.newHostToolStripMenuItem.Name = "newHostToolStripMenuItem";
            this.newHostToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.newHostToolStripMenuItem.Text = "New host";
            this.newHostToolStripMenuItem.Click += new System.EventHandler(this.newHostToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::SSClient.Properties.Resources.Settings_16x16;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SSClient.Properties.Resources.deletered;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnWakeUpAll
            // 
            this.btnWakeUpAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWakeUpAll.BackColor = System.Drawing.Color.Green;
            this.btnWakeUpAll.BackgroundColor = System.Drawing.Color.Green;
            this.btnWakeUpAll.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnWakeUpAll.BorderRadius = 10;
            this.btnWakeUpAll.BorderSize = 0;
            this.btnWakeUpAll.FlatAppearance.BorderSize = 0;
            this.btnWakeUpAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWakeUpAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWakeUpAll.ForeColor = System.Drawing.Color.White;
            this.btnWakeUpAll.Location = new System.Drawing.Point(46, 530);
            this.btnWakeUpAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnWakeUpAll.Name = "btnWakeUpAll";
            this.btnWakeUpAll.Size = new System.Drawing.Size(133, 32);
            this.btnWakeUpAll.TabIndex = 15;
            this.btnWakeUpAll.Text = "Wake Up All";
            this.btnWakeUpAll.TextColor = System.Drawing.Color.White;
            this.btnWakeUpAll.UseVisualStyleBackColor = false;
            this.btnWakeUpAll.Click += new System.EventHandler(this.btnWakeUpAll_Click);
            // 
            // btnShutdownAll
            // 
            this.btnShutdownAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShutdownAll.BackColor = System.Drawing.Color.Maroon;
            this.btnShutdownAll.BackgroundColor = System.Drawing.Color.Maroon;
            this.btnShutdownAll.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnShutdownAll.BorderRadius = 10;
            this.btnShutdownAll.BorderSize = 0;
            this.btnShutdownAll.Enabled = false;
            this.btnShutdownAll.FlatAppearance.BorderSize = 0;
            this.btnShutdownAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutdownAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShutdownAll.ForeColor = System.Drawing.Color.White;
            this.btnShutdownAll.Location = new System.Drawing.Point(195, 530);
            this.btnShutdownAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShutdownAll.Name = "btnShutdownAll";
            this.btnShutdownAll.Size = new System.Drawing.Size(148, 32);
            this.btnShutdownAll.TabIndex = 16;
            this.btnShutdownAll.Text = "Shut Down All";
            this.btnShutdownAll.TextColor = System.Drawing.Color.White;
            this.btnShutdownAll.UseVisualStyleBackColor = false;
            this.btnShutdownAll.Visible = false;
            this.btnShutdownAll.Click += new System.EventHandler(this.btnShutdownAll_Click);
            // 
            // fClientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 586);
            this.Controls.Add(this.btnShutdownAll);
            this.Controls.Add(this.btnWakeUpAll);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fClientList";
            this.Text = "fClientList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fClientList_FormClosing);
            this.Load += new System.EventHandler(this.fClientList_Load);
            this.Shown += new System.EventHandler(this.fClientList_Shown);
            this.contextMenuStrip_Machines.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ViControls.ViButton btnAddClient;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Machines;
        private System.Windows.Forms.ToolStripMenuItem wakeUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newHostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private ViControls.ViButton btnWakeUpAll;
        private ViControls.ViButton btnShutdownAll;
    }
}