namespace RMS.SystemManagement
{
    partial class CashReport
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
            this.amountlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.debitdataGridView = new System.Windows.Forms.DataGridView();
            this.showbutton = new System.Windows.Forms.Button();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debitdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.amountlabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.debitdataGridView);
            this.groupBox1.Location = new System.Drawing.Point(44, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 475);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debit Information";
            // 
            // amountlabel
            // 
            this.amountlabel.AutoSize = true;
            this.amountlabel.Location = new System.Drawing.Point(504, 448);
            this.amountlabel.Name = "amountlabel";
            this.amountlabel.Size = new System.Drawing.Size(28, 13);
            this.amountlabel.TabIndex = 5;
            this.amountlabel.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selected Dated Total Debit Amount(Tk):";
            // 
            // debitdataGridView
            // 
            this.debitdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.debitdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.debitdataGridView.Location = new System.Drawing.Point(21, 34);
            this.debitdataGridView.Name = "debitdataGridView";
            this.debitdataGridView.Size = new System.Drawing.Size(930, 397);
            this.debitdataGridView.TabIndex = 0;
            // 
            // showbutton
            // 
            this.showbutton.Location = new System.Drawing.Point(800, 8);
            this.showbutton.Name = "showbutton";
            this.showbutton.Size = new System.Drawing.Size(86, 31);
            this.showbutton.TabIndex = 6;
            this.showbutton.Text = "Show";
            this.showbutton.UseVisualStyleBackColor = true;
            this.showbutton.Click += new System.EventHandler(this.showbutton_Click);
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(265, 13);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(223, 20);
            this.fromdateTimePicker.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "From:";
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(533, 13);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(223, 20);
            this.todateTimePicker.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "To:";
            // 
            // CashReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showbutton);
            this.Name = "CashReport";
            this.Size = new System.Drawing.Size(1060, 541);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debitdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label amountlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView debitdataGridView;
        private System.Windows.Forms.Button showbutton;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.Label label1;
    }
}