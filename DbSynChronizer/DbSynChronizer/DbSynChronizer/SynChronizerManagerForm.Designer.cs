namespace DbSynChronizer
{
    partial class SynChronizerManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynChronizerManagerForm));
            this.tmrDbSynchronizer = new System.Windows.Forms.Timer(this.components);
            this.synchronizerNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.conMnuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMnuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrp = new System.Windows.Forms.StatusStrip();
            this.tsRunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.picBoxActiveStatus = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tlTips = new System.Windows.Forms.ToolTip(this.components);
            this.conMnuItem.SuspendLayout();
            this.statusStrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxActiveStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrDbSynchronizer
            // 
            this.tmrDbSynchronizer.Interval = 1000;
            this.tmrDbSynchronizer.Tick += new System.EventHandler(this.tmrDbSynchronizer_Tick);
            // 
            // synchronizerNotification
            // 
            this.synchronizerNotification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.synchronizerNotification.BalloonTipText = "Online Orders Synchronizer";
            this.synchronizerNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("synchronizerNotification.Icon")));
            this.synchronizerNotification.Text = "Online Orders Synchroning...";
            this.synchronizerNotification.Visible = true;
            this.synchronizerNotification.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.synchronizerNotification_MouseDoubleClick);
            // 
            // conMnuItem
            // 
            this.conMnuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMnuItemOpen,
            this.tsMnuItemExit});
            this.conMnuItem.Name = "conMnuItem";
            this.conMnuItem.Size = new System.Drawing.Size(112, 48);
            // 
            // tsMnuItemOpen
            // 
            this.tsMnuItemOpen.Name = "tsMnuItemOpen";
            this.tsMnuItemOpen.Size = new System.Drawing.Size(111, 22);
            this.tsMnuItemOpen.Text = "Open";
            this.tsMnuItemOpen.Click += new System.EventHandler(this.tsMnuItemOpen_Click);
            // 
            // tsMnuItemExit
            // 
            this.tsMnuItemExit.Name = "tsMnuItemExit";
            this.tsMnuItemExit.Size = new System.Drawing.Size(111, 22);
            this.tsMnuItemExit.Text = "Exit";
            this.tsMnuItemExit.Click += new System.EventHandler(this.tsMnuItemExit_Click);
            // 
            // statusStrp
            // 
            this.statusStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRunStatus});
            this.statusStrp.Location = new System.Drawing.Point(0, 222);
            this.statusStrp.Name = "statusStrp";
            this.statusStrp.Size = new System.Drawing.Size(292, 22);
            this.statusStrp.TabIndex = 4;
            this.statusStrp.Text = "The service is running";
            // 
            // tsRunStatus
            // 
            this.tsRunStatus.Name = "tsRunStatus";
            this.tsRunStatus.Size = new System.Drawing.Size(111, 17);
            this.tsRunStatus.Text = "The service is running";
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Size = new System.Drawing.Size(46, 17);
            this.tsStatusLabel.Text = "Running";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(186, 71);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(76, 13);
            this.lblStart.TabIndex = 6;
            this.lblStart.Text = "Start/Continue";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Location = new System.Drawing.Point(186, 130);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(29, 13);
            this.lblStop.TabIndex = 8;
            this.lblStop.Text = "Stop";
            // 
            // picBoxActiveStatus
            // 
            this.picBoxActiveStatus.Image = global::DbSynChronizer.Properties.Resources.DB;
            this.picBoxActiveStatus.InitialImage = global::DbSynChronizer.Properties.Resources.Database;
            this.picBoxActiveStatus.Location = new System.Drawing.Point(12, 40);
            this.picBoxActiveStatus.Name = "picBoxActiveStatus";
            this.picBoxActiveStatus.Size = new System.Drawing.Size(130, 129);
            this.picBoxActiveStatus.TabIndex = 9;
            this.picBoxActiveStatus.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::DbSynChronizer.Properties.Resources.control_play_button;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.Location = new System.Drawing.Point(148, 62);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(32, 30);
            this.btnStart.TabIndex = 1;
            this.tlTips.SetToolTip(this.btnStart, "Click Here To Start The Service");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::DbSynChronizer.Properties.Resources.control_stop_button;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Location = new System.Drawing.Point(148, 121);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(32, 30);
            this.btnStop.TabIndex = 5;
            this.tlTips.SetToolTip(this.btnStop, "Click Here To Stop The Service");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // SynChronizerManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 244);
            this.Controls.Add(this.picBoxActiveStatus);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.statusStrp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SynChronizerManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Synchronizer";
            this.Load += new System.EventHandler(this.SynChronizerManagerForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SynChronizerManagerForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SynChronizerManagerForm_FormClosing);
            this.Resize += new System.EventHandler(this.SynChronizerManagerForm_Resize);
            this.conMnuItem.ResumeLayout(false);
            this.statusStrp.ResumeLayout(false);
            this.statusStrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxActiveStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrDbSynchronizer;
        private System.Windows.Forms.NotifyIcon synchronizerNotification;
        private System.Windows.Forms.ContextMenuStrip conMnuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMnuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem tsMnuItemExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrp;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.PictureBox picBoxActiveStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsRunStatus;
        private System.Windows.Forms.ToolTip tlTips;
    }
}

