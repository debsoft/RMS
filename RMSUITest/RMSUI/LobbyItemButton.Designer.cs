namespace RMSUI
{
    partial class LobbyItemButton
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTableDetails = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblterminal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.floorlabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.floorlabel);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.lblTableDetails);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 69);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.lblType_Click);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUser.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblUser.Location = new System.Drawing.Point(3, 17);
            this.lblUser.Margin = new System.Windows.Forms.Padding(0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(91, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "lblUser";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUser.Click += new System.EventHandler(this.lblType_Click);
            this.lblUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.lblUser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            // 
            // lblTableDetails
            // 
            this.lblTableDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTableDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblTableDetails.Location = new System.Drawing.Point(0, 32);
            this.lblTableDetails.Name = "lblTableDetails";
            this.lblTableDetails.Size = new System.Drawing.Size(97, 15);
            this.lblTableDetails.TabIndex = 1;
            this.lblTableDetails.Text = "lblTableDetails";
            this.lblTableDetails.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTableDetails.Click += new System.EventHandler(this.lblType_Click);
            this.lblTableDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.lblTableDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblType.Location = new System.Drawing.Point(3, 2);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(91, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "lblType";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblType.Click += new System.EventHandler(this.lblType_Click);
            this.lblType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.lblType.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            // 
            // topPanel
            // 
            this.topPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.topPanel.Controls.Add(this.lblterminal);
            this.topPanel.Controls.Add(this.panel3);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(100, 55);
            this.topPanel.TabIndex = 1;
            this.topPanel.Click += new System.EventHandler(this.lblType_Click);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            // 
            // lblterminal
            // 
            this.lblterminal.AutoSize = true;
            this.lblterminal.Location = new System.Drawing.Point(9, 42);
            this.lblterminal.Name = "lblterminal";
            this.lblterminal.Size = new System.Drawing.Size(0, 13);
            this.lblterminal.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(50, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(50, 55);
            this.panel3.TabIndex = 0;
            this.panel3.Click += new System.EventHandler(this.lblType_Click);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(0, 16);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 24);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Num";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNumber.Click += new System.EventHandler(this.lblType_Click);
            this.lblNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.lblNumber.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            // 
            // floorlabel
            // 
            this.floorlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.floorlabel.Location = new System.Drawing.Point(0, 51);
            this.floorlabel.Name = "floorlabel";
            this.floorlabel.Size = new System.Drawing.Size(94, 14);
            this.floorlabel.TabIndex = 3;
            this.floorlabel.Text = "Floor: ";
            this.floorlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LobbyItemButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.panel1);
            this.Name = "LobbyItemButton";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(100, 133);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LobbyItemButton_MouseUp);
            this.panel1.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblTableDetails;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblterminal;
        private System.Windows.Forms.Label floorlabel;

    }
}
