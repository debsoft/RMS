using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RMSUI
{
    public class BaseForm: Form
    {
        private Panel panel2;
        private Panel panel3;
        private Panel panel6;
        private Label lblScreenTitle;
        private Panel panel5;
        private Panel panel4;
        private Timer myTimer;
        private System.ComponentModel.IContainer components;
        private Panel panel1;
        private Label lblTime;
        private Label lblDate;
        private Panel panel7;
        private Panel panel8;

        private string[] month = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        public BaseForm() 
        {
           InitializeComponent();
           setClock();
        }

        private void setClock()
        {
            string time = getTimeString(DateTime.Now.Hour);
            time += " : ";
            time += getTimeString(DateTime.Now.Minute);
            time += " : ";
            time += getTimeString(DateTime.Now.Second);

            lblTime.Text = time;

            string date = DateTime.Now.DayOfWeek.ToString();
            date += ", " + DateTime.Now.Day.ToString();
            date += " " + month[DateTime.Now.Month-1].ToString(); 
            date += ", " + DateTime.Now.Year.ToString();
            lblDate.Text = date;
        
        }

        private string getTimeString(int time)
        {
            return time.ToString().Length == 1 ? "0" + time.ToString() : time.ToString();
        }

        public string ScreenTitle 
        {
            get { return lblScreenTitle.Text; }
            set { lblScreenTitle.Text = value; }
        }

       private void InitializeComponent()
       {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblScreenTitle = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::RMSUI.Properties.Resources.rms_logo_client;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 44);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::RMSUI.Properties.Resources.clock_widget_bg;
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Location = new System.Drawing.Point(654, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 44);
            this.panel2.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.lblDate);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 22);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 2, 5, 0);
            this.panel8.Size = new System.Drawing.Size(142, 22);
            this.panel8.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Location = new System.Drawing.Point(64, 2);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(73, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "day moth year";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.lblTime);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 8, 5, 0);
            this.panel7.Size = new System.Drawing.Size(142, 22);
            this.panel7.TabIndex = 3;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Location = new System.Drawing.Point(70, 8);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(67, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "hr : min : sec";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(148, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(100, 10, 100, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(503, 44);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::RMSUI.Properties.Resources.base_form_title_bg_common;
            this.panel6.Controls.Add(this.lblScreenTitle);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(8, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(487, 44);
            this.panel6.TabIndex = 2;
            // 
            // lblScreenTitle
            // 
            this.lblScreenTitle.AutoSize = true;
            this.lblScreenTitle.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreenTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblScreenTitle.Location = new System.Drawing.Point(5, 11);
            this.lblScreenTitle.Name = "lblScreenTitle";
            this.lblScreenTitle.Size = new System.Drawing.Size(103, 18);
            this.lblScreenTitle.TabIndex = 0;
            this.lblScreenTitle.Text = "Screen title";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::RMSUI.Properties.Resources.base_form_title_bg_right;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(495, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 44);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::RMSUI.Properties.Resources.base_form_title_bg_left;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(8, 44);
            this.panel4.TabIndex = 0;
            // 
            // myTimer
            // 
            this.myTimer.Enabled = true;
            this.myTimer.Interval = 1000;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // BaseForm
            // 
            this.BackgroundImage = global::RMSUI.Properties.Resources.rms_home_index;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

       }

       private void button1_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void myTimer_Tick(object sender, EventArgs e)
       {
           setClock();
       }

    }
}
