namespace RMS.Common
{
    partial class CTableIcon
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
            this.TableNumberLabel = new System.Windows.Forms.Label();
            this.TableNumberPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.UserLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GuestCountLabel = new System.Windows.Forms.Label();
            this.TableNumberPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableNumberLabel
            // 
            this.TableNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.TableNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableNumberLabel.ForeColor = System.Drawing.Color.Red;
            this.TableNumberLabel.Location = new System.Drawing.Point(0, 7);
            this.TableNumberLabel.Name = "TableNumberLabel";
            this.TableNumberLabel.Size = new System.Drawing.Size(54, 15);
            this.TableNumberLabel.TabIndex = 4;
            this.TableNumberLabel.Text = "1";
            this.TableNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TableNumberLabel.Click += new System.EventHandler(this.TableNumberLabel_Click);
            // 
            // TableNumberPanel
            // 
            this.TableNumberPanel.BackColor = System.Drawing.Color.Transparent;
            this.TableNumberPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TableNumberPanel.Controls.Add(this.TableNumberLabel);
            this.TableNumberPanel.Location = new System.Drawing.Point(21, 6);
            this.TableNumberPanel.Name = "TableNumberPanel";
            this.TableNumberPanel.Size = new System.Drawing.Size(50, 47);
            this.TableNumberPanel.TabIndex = 5;
            this.TableNumberPanel.Click += new System.EventHandler(this.TableNumberPanel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.TableNumberPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 54);
            this.panel1.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.NameLabel);
            this.flowLayoutPanel1.Controls.Add(this.GuestCountLabel);
            this.flowLayoutPanel1.Controls.Add(this.UserLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(98, 54);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // UserLabel
            // 
            this.UserLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.ForeColor = System.Drawing.Color.Yellow;
            this.UserLabel.Location = new System.Drawing.Point(3, 30);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(92, 15);
            this.UserLabel.TabIndex = 5;
            this.UserLabel.Text = "1";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLabel
            // 
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.Black;
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(92, 15);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.Text = "1";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GuestCountLabel
            // 
            this.GuestCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.GuestCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestCountLabel.ForeColor = System.Drawing.Color.Blue;
            this.GuestCountLabel.Location = new System.Drawing.Point(3, 15);
            this.GuestCountLabel.Name = "GuestCountLabel";
            this.GuestCountLabel.Size = new System.Drawing.Size(92, 15);
            this.GuestCountLabel.TabIndex = 10;
            this.GuestCountLabel.Text = "1";
            this.GuestCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CTableIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CTableIcon";
            this.Size = new System.Drawing.Size(98, 108);
            this.TableNumberPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TableNumberLabel;
        private System.Windows.Forms.Panel TableNumberPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label NameLabel;
        public System.Windows.Forms.Label GuestCountLabel;
    }
}
