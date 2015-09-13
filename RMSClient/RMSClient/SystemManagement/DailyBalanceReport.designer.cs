namespace RMS.SystemManagement
{
    partial class DailyBalanceReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datetodateprintbutton = new System.Windows.Forms.Button();
            this.balancedataGridView = new System.Windows.Forms.DataGridView();
            this.showbutton = new System.Windows.Forms.Button();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.debiotamountlabel = new System.Windows.Forms.Label();
            this.creditlabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.balancelabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.otherdebitlabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalbalanceprintbutton = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.cashlabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balancedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.datetodateprintbutton);
            this.groupBox1.Controls.Add(this.balancedataGridView);
            this.groupBox1.Location = new System.Drawing.Point(44, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 475);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balance Information";
            // 
            // datetodateprintbutton
            // 
            this.datetodateprintbutton.Location = new System.Drawing.Point(865, 438);
            this.datetodateprintbutton.Name = "datetodateprintbutton";
            this.datetodateprintbutton.Size = new System.Drawing.Size(86, 31);
            this.datetodateprintbutton.TabIndex = 7;
            this.datetodateprintbutton.Text = "Print";
            this.datetodateprintbutton.UseVisualStyleBackColor = true;
            this.datetodateprintbutton.Click += new System.EventHandler(this.datetodateprintbutton_Click);
            // 
            // balancedataGridView
            // 
            this.balancedataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.balancedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balancedataGridView.Location = new System.Drawing.Point(21, 34);
            this.balancedataGridView.Name = "balancedataGridView";
            this.balancedataGridView.Size = new System.Drawing.Size(930, 397);
            this.balancedataGridView.TabIndex = 0;
            // 
            // showbutton
            // 
            this.showbutton.Location = new System.Drawing.Point(779, 14);
            this.showbutton.Name = "showbutton";
            this.showbutton.Size = new System.Drawing.Size(86, 31);
            this.showbutton.TabIndex = 6;
            this.showbutton.Text = "Show";
            this.showbutton.UseVisualStyleBackColor = true;
            this.showbutton.Click += new System.EventHandler(this.showbutton_Click);
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(538, 17);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(223, 20);
            this.todateTimePicker.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "To:";
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(270, 17);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(223, 20);
            this.fromdateTimePicker.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1057, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Till Now Total Debit Amount(Tk.)";
            // 
            // debiotamountlabel
            // 
            this.debiotamountlabel.AutoSize = true;
            this.debiotamountlabel.Location = new System.Drawing.Point(1261, 112);
            this.debiotamountlabel.Name = "debiotamountlabel";
            this.debiotamountlabel.Size = new System.Drawing.Size(28, 13);
            this.debiotamountlabel.TabIndex = 11;
            this.debiotamountlabel.Text = "0.00";
            // 
            // creditlabel
            // 
            this.creditlabel.AutoSize = true;
            this.creditlabel.Location = new System.Drawing.Point(1261, 74);
            this.creditlabel.Name = "creditlabel";
            this.creditlabel.Size = new System.Drawing.Size(28, 13);
            this.creditlabel.TabIndex = 13;
            this.creditlabel.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1057, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Till Now Total Credit Amount(Tk.)";
            // 
            // balancelabel
            // 
            this.balancelabel.AutoSize = true;
            this.balancelabel.Location = new System.Drawing.Point(1261, 154);
            this.balancelabel.Name = "balancelabel";
            this.balancelabel.Size = new System.Drawing.Size(28, 13);
            this.balancelabel.TabIndex = 17;
            this.balancelabel.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1041, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Till Now Total Balance Amount(Tk.)";
            // 
            // otherdebitlabel
            // 
            this.otherdebitlabel.AutoSize = true;
            this.otherdebitlabel.Location = new System.Drawing.Point(1261, 192);
            this.otherdebitlabel.Name = "otherdebitlabel";
            this.otherdebitlabel.Size = new System.Drawing.Size(28, 13);
            this.otherdebitlabel.TabIndex = 15;
            this.otherdebitlabel.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1028, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Till Now Total other Debit Amount(Tk.)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1023, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Till Now Total Cash in hand Amount(Tk.)";
            // 
            // totalbalanceprintbutton
            // 
            this.totalbalanceprintbutton.Location = new System.Drawing.Point(1216, 260);
            this.totalbalanceprintbutton.Name = "totalbalanceprintbutton";
            this.totalbalanceprintbutton.Size = new System.Drawing.Size(86, 31);
            this.totalbalanceprintbutton.TabIndex = 22;
            this.totalbalanceprintbutton.Text = "Print";
            this.totalbalanceprintbutton.UseVisualStyleBackColor = true;
            this.totalbalanceprintbutton.Click += new System.EventHandler(this.totalbalanceprintbutton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // cashlabel
            // 
            this.cashlabel.AutoSize = true;
            this.cashlabel.Location = new System.Drawing.Point(1261, 222);
            this.cashlabel.Name = "cashlabel";
            this.cashlabel.Size = new System.Drawing.Size(28, 13);
            this.cashlabel.TabIndex = 21;
            this.cashlabel.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "0.00";
            // 
            // DailyBalanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.totalbalanceprintbutton);
            this.Controls.Add(this.cashlabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.balancelabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.otherdebitlabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.creditlabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.debiotamountlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showbutton);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.label1);
            this.Name = "DailyBalanceReport";
            this.Size = new System.Drawing.Size(1332, 541);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balancedataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView balancedataGridView;
        private System.Windows.Forms.Button showbutton;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label debiotamountlabel;
        private System.Windows.Forms.Label creditlabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label balancelabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label otherdebitlabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button datetodateprintbutton;
        private System.Windows.Forms.Button totalbalanceprintbutton;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label cashlabel;
    }
}