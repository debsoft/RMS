namespace RMS.Login
{
    partial class CLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLoginForm));
            this.UserButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tmrCallerID = new System.Windows.Forms.Timer(this.components);
            this.lblCallingStatus = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRMSVersion = new System.Windows.Forms.Label();
            this.grpCallerInfo = new System.Windows.Forms.GroupBox();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Timetimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grpCallerInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserButtonPanel
            // 
            this.UserButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.UserButtonPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UserButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserButtonPanel.ForeColor = System.Drawing.Color.Black;
            this.UserButtonPanel.Location = new System.Drawing.Point(38, 100);
            this.UserButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UserButtonPanel.Name = "UserButtonPanel";
            this.UserButtonPanel.Size = new System.Drawing.Size(698, 320);
            this.UserButtonPanel.TabIndex = 0;
            // 
            // tmrCallerID
            // 
            this.tmrCallerID.Tick += new System.EventHandler(this.tmrCallerID_Tick);
            // 
            // lblCallingStatus
            // 
            this.lblCallingStatus.AutoSize = true;
            this.lblCallingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCallingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCallingStatus.Location = new System.Drawing.Point(6, 16);
            this.lblCallingStatus.Name = "lblCallingStatus";
            this.lblCallingStatus.Size = new System.Drawing.Size(49, 13);
            this.lblCallingStatus.TabIndex = 21;
            this.lblCallingStatus.Text = "Calling:";
            this.lblCallingStatus.Visible = false;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPhoneNumber.Location = new System.Drawing.Point(58, 17);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(90, 13);
            this.lblPhoneNumber.TabIndex = 22;
            this.lblPhoneNumber.Text = "Phone Number";
            this.lblPhoneNumber.Visible = false;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(6, 39);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(95, 13);
            this.lblCustomerName.TabIndex = 23;
            this.lblCustomerName.Text = "Customer Name";
            this.lblCustomerName.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(67, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 47;
            this.label3.Text = "www.ibacs.co.uk";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(54, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "Restaurent Edition";
            this.label2.Visible = false;
            // 
            // lblRMSVersion
            // 
            this.lblRMSVersion.AutoSize = true;
            this.lblRMSVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblRMSVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMSVersion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRMSVersion.Location = new System.Drawing.Point(89, 37);
            this.lblRMSVersion.Name = "lblRMSVersion";
            this.lblRMSVersion.Size = new System.Drawing.Size(91, 15);
            this.lblRMSVersion.TabIndex = 45;
            this.lblRMSVersion.Text = "Version:3.0.0";
            this.lblRMSVersion.Visible = false;
            // 
            // grpCallerInfo
            // 
            this.grpCallerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpCallerInfo.BackColor = System.Drawing.Color.Transparent;
            this.grpCallerInfo.Controls.Add(this.lblPhoneNumber);
            this.grpCallerInfo.Controls.Add(this.lblCallingStatus);
            this.grpCallerInfo.Controls.Add(this.lblCustomerName);
            this.grpCallerInfo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpCallerInfo.Location = new System.Drawing.Point(15, 509);
            this.grpCallerInfo.Name = "grpCallerInfo";
            this.grpCallerInfo.Size = new System.Drawing.Size(207, 79);
            this.grpCallerInfo.TabIndex = 48;
            this.grpCallerInfo.TabStop = false;
            this.grpCallerInfo.Text = "Caller\'s Information";
            this.grpCallerInfo.Visible = false;
            // 
            // DownButton
            // 
            this.DownButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DownButton.BackgroundImage = global::RMS.Properties.Resources.DownArrow;
            this.DownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownButton.Location = new System.Drawing.Point(702, 431);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(34, 34);
            this.DownButton.TabIndex = 2;
            this.DownButton.UseVisualStyleBackColor = false;
            this.DownButton.Visible = false;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpButton.BackgroundImage")));
            this.UpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpButton.Location = new System.Drawing.Point(662, 431);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(34, 34);
            this.UpButton.TabIndex = 1;
            this.UpButton.UseVisualStyleBackColor = false;
            this.UpButton.Visible = false;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblRMSVersion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(605, 488);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 100);
            this.panel1.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "RMS Version:2016";
            // 
            // Timetimer
            // 
            this.Timetimer.Interval = 1000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 24);
            this.label1.TabIndex = 50;
            this.label1.Text = "Please select your name and press to start...";
            // 
            // CLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpCallerInfo);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.UserButtonPanel);
            this.ForeColor = System.Drawing.Color.Black;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "CLoginForm";
            this.Activated += new System.EventHandler(this.CLoginForm_Activated);
            this.Deactivate += new System.EventHandler(this.CLoginForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CLoginForm_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CLoginForm_Paint);
            this.Controls.SetChildIndex(this.UserButtonPanel, 0);
            this.Controls.SetChildIndex(this.UpButton, 0);
            this.Controls.SetChildIndex(this.DownButton, 0);
            this.Controls.SetChildIndex(this.grpCallerInfo, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.grpCallerInfo.ResumeLayout(false);
            this.grpCallerInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.FlowLayoutPanel UserButtonPanel;
        private System.Windows.Forms.Timer tmrCallerID;
        private System.Windows.Forms.Label lblCallingStatus;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRMSVersion;
        private System.Windows.Forms.GroupBox grpCallerInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer Timetimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

