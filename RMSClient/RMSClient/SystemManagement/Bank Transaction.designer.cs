namespace RMS.SystemManagement
{
    partial class Bank_Transaction
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
            this.toppanel = new System.Windows.Forms.Panel();
            this.balancebutton = new System.Windows.Forms.Button();
            this.otherDrbutton = new System.Windows.Forms.Button();
            this.debitreportbutton = new System.Windows.Forms.Button();
            this.creditreportbutton = new System.Windows.Forms.Button();
            this.othercreditbutton = new System.Windows.Forms.Button();
            this.creditbutton = new System.Windows.Forms.Button();
            this.debitbutton = new System.Windows.Forms.Button();
            this.footerpanel = new System.Windows.Forms.Panel();
            this.contentpanel = new System.Windows.Forms.Panel();
            this.cashreportbutton = new System.Windows.Forms.Button();
            this.cashbutton = new System.Windows.Forms.Button();
            this.toppanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toppanel
            // 
            this.toppanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toppanel.Controls.Add(this.cashreportbutton);
            this.toppanel.Controls.Add(this.cashbutton);
            this.toppanel.Controls.Add(this.balancebutton);
            this.toppanel.Controls.Add(this.otherDrbutton);
            this.toppanel.Controls.Add(this.debitreportbutton);
            this.toppanel.Controls.Add(this.creditreportbutton);
            this.toppanel.Controls.Add(this.othercreditbutton);
            this.toppanel.Controls.Add(this.creditbutton);
            this.toppanel.Controls.Add(this.debitbutton);
            this.toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toppanel.Location = new System.Drawing.Point(0, 0);
            this.toppanel.Name = "toppanel";
            this.toppanel.Size = new System.Drawing.Size(976, 35);
            this.toppanel.TabIndex = 0;
            // 
            // balancebutton
            // 
            this.balancebutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.balancebutton.Location = new System.Drawing.Point(498, 0);
            this.balancebutton.Name = "balancebutton";
            this.balancebutton.Size = new System.Drawing.Size(83, 35);
            this.balancebutton.TabIndex = 6;
            this.balancebutton.Text = "Balance";
            this.balancebutton.UseVisualStyleBackColor = true;
            this.balancebutton.Click += new System.EventHandler(this.balancebutton_Click);
            // 
            // otherDrbutton
            // 
            this.otherDrbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.otherDrbutton.Location = new System.Drawing.Point(415, 0);
            this.otherDrbutton.Name = "otherDrbutton";
            this.otherDrbutton.Size = new System.Drawing.Size(83, 35);
            this.otherDrbutton.TabIndex = 5;
            this.otherDrbutton.Text = "Ot. Dr. Report";
            this.otherDrbutton.UseVisualStyleBackColor = true;
            this.otherDrbutton.Click += new System.EventHandler(this.otherDrbutton_Click);
            // 
            // debitreportbutton
            // 
            this.debitreportbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.debitreportbutton.Location = new System.Drawing.Point(332, 0);
            this.debitreportbutton.Name = "debitreportbutton";
            this.debitreportbutton.Size = new System.Drawing.Size(83, 35);
            this.debitreportbutton.TabIndex = 4;
            this.debitreportbutton.Text = "Dr. Report";
            this.debitreportbutton.UseVisualStyleBackColor = true;
            this.debitreportbutton.Click += new System.EventHandler(this.debitreportbutton_Click);
            // 
            // creditreportbutton
            // 
            this.creditreportbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.creditreportbutton.Location = new System.Drawing.Point(249, 0);
            this.creditreportbutton.Name = "creditreportbutton";
            this.creditreportbutton.Size = new System.Drawing.Size(83, 35);
            this.creditreportbutton.TabIndex = 3;
            this.creditreportbutton.Text = "Cr. Report";
            this.creditreportbutton.UseVisualStyleBackColor = true;
            this.creditreportbutton.Click += new System.EventHandler(this.creditreportbutton_Click);
            // 
            // othercreditbutton
            // 
            this.othercreditbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.othercreditbutton.Location = new System.Drawing.Point(166, 0);
            this.othercreditbutton.Name = "othercreditbutton";
            this.othercreditbutton.Size = new System.Drawing.Size(83, 35);
            this.othercreditbutton.TabIndex = 2;
            this.othercreditbutton.Text = "Other Debit";
            this.othercreditbutton.UseVisualStyleBackColor = true;
            this.othercreditbutton.Click += new System.EventHandler(this.othercreditbutton_Click);
            // 
            // creditbutton
            // 
            this.creditbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.creditbutton.Location = new System.Drawing.Point(83, 0);
            this.creditbutton.Name = "creditbutton";
            this.creditbutton.Size = new System.Drawing.Size(83, 35);
            this.creditbutton.TabIndex = 1;
            this.creditbutton.Text = "Bank Credit";
            this.creditbutton.UseVisualStyleBackColor = true;
            this.creditbutton.Click += new System.EventHandler(this.creditbutton_Click);
            // 
            // debitbutton
            // 
            this.debitbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.debitbutton.Location = new System.Drawing.Point(0, 0);
            this.debitbutton.Name = "debitbutton";
            this.debitbutton.Size = new System.Drawing.Size(83, 35);
            this.debitbutton.TabIndex = 0;
            this.debitbutton.Text = "Bank Debit";
            this.debitbutton.UseVisualStyleBackColor = true;
            this.debitbutton.Click += new System.EventHandler(this.debitbutton_Click);
            // 
            // footerpanel
            // 
            this.footerpanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.footerpanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerpanel.Location = new System.Drawing.Point(0, 447);
            this.footerpanel.Name = "footerpanel";
            this.footerpanel.Size = new System.Drawing.Size(976, 47);
            this.footerpanel.TabIndex = 1;
            // 
            // contentpanel
            // 
            this.contentpanel.AutoScroll = true;
            this.contentpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentpanel.Location = new System.Drawing.Point(0, 35);
            this.contentpanel.Name = "contentpanel";
            this.contentpanel.Size = new System.Drawing.Size(976, 412);
            this.contentpanel.TabIndex = 2;
            // 
            // cashreportbutton
            // 
            this.cashreportbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.cashreportbutton.Location = new System.Drawing.Point(664, 0);
            this.cashreportbutton.Name = "cashreportbutton";
            this.cashreportbutton.Size = new System.Drawing.Size(83, 35);
            this.cashreportbutton.TabIndex = 10;
            this.cashreportbutton.Text = "Cash Report";
            this.cashreportbutton.UseVisualStyleBackColor = true;
            this.cashreportbutton.Click += new System.EventHandler(this.cashreportbutton_Click);
            // 
            // cashbutton
            // 
            this.cashbutton.Dock = System.Windows.Forms.DockStyle.Left;
            this.cashbutton.Location = new System.Drawing.Point(581, 0);
            this.cashbutton.Name = "cashbutton";
            this.cashbutton.Size = new System.Drawing.Size(83, 35);
            this.cashbutton.TabIndex = 9;
            this.cashbutton.Text = "Cash";
            this.cashbutton.UseVisualStyleBackColor = true;
            this.cashbutton.Click += new System.EventHandler(this.cashbutton_Click);
            // 
            // Bank_Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 494);
            this.Controls.Add(this.contentpanel);
            this.Controls.Add(this.footerpanel);
            this.Controls.Add(this.toppanel);
            this.Name = "Bank_Transaction";
            this.Text = "Bank_Transaction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toppanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel toppanel;
        private System.Windows.Forms.Button debitbutton;
        private System.Windows.Forms.Panel footerpanel;
        private System.Windows.Forms.Panel contentpanel;
        private System.Windows.Forms.Button othercreditbutton;
        private System.Windows.Forms.Button creditbutton;
        private System.Windows.Forms.Button creditreportbutton;
        private System.Windows.Forms.Button otherDrbutton;
        private System.Windows.Forms.Button debitreportbutton;
        private System.Windows.Forms.Button balancebutton;
        private System.Windows.Forms.Button cashreportbutton;
        private System.Windows.Forms.Button cashbutton;
    }
}