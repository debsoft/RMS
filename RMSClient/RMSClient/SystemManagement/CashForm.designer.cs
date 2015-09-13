namespace RMS.SystemManagement
{
    partial class CashForm
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
            this.debitdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.savebutton = new System.Windows.Forms.Button();
            this.creditgroupBox = new System.Windows.Forms.GroupBox();
            this.amounttextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.depositepersontextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.banknametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.creditgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // debitdateTimePicker
            // 
            this.debitdateTimePicker.Location = new System.Drawing.Point(251, 128);
            this.debitdateTimePicker.Name = "debitdateTimePicker";
            this.debitdateTimePicker.Size = new System.Drawing.Size(256, 20);
            this.debitdateTimePicker.TabIndex = 20;
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(406, 248);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(101, 39);
            this.savebutton.TabIndex = 15;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // creditgroupBox
            // 
            this.creditgroupBox.Controls.Add(this.amounttextBox);
            this.creditgroupBox.Controls.Add(this.label6);
            this.creditgroupBox.Controls.Add(this.depositepersontextBox);
            this.creditgroupBox.Controls.Add(this.label5);
            this.creditgroupBox.Controls.Add(this.label4);
            this.creditgroupBox.Controls.Add(this.debitdateTimePicker);
            this.creditgroupBox.Controls.Add(this.savebutton);
            this.creditgroupBox.Controls.Add(this.banknametextBox);
            this.creditgroupBox.Controls.Add(this.label1);
            this.creditgroupBox.Location = new System.Drawing.Point(83, 20);
            this.creditgroupBox.Name = "creditgroupBox";
            this.creditgroupBox.Size = new System.Drawing.Size(665, 448);
            this.creditgroupBox.TabIndex = 1;
            this.creditgroupBox.TabStop = false;
            this.creditgroupBox.Text = "Cash  Information";
            // 
            // amounttextBox
            // 
            this.amounttextBox.Location = new System.Drawing.Point(251, 204);
            this.amounttextBox.Name = "amounttextBox";
            this.amounttextBox.Size = new System.Drawing.Size(256, 20);
            this.amounttextBox.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Amount";
            // 
            // depositepersontextBox
            // 
            this.depositepersontextBox.Location = new System.Drawing.Point(251, 163);
            this.depositepersontextBox.Name = "depositepersontextBox";
            this.depositepersontextBox.Size = new System.Drawing.Size(256, 20);
            this.depositepersontextBox.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Cash Person";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Date";
            // 
            // banknametextBox
            // 
            this.banknametextBox.Location = new System.Drawing.Point(253, 90);
            this.banknametextBox.Name = "banknametextBox";
            this.banknametextBox.Size = new System.Drawing.Size(256, 20);
            this.banknametextBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Amount Source";
            // 
            // CashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.creditgroupBox);
            this.Name = "CashForm";
            this.Size = new System.Drawing.Size(830, 488);
            this.creditgroupBox.ResumeLayout(false);
            this.creditgroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker debitdateTimePicker;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.GroupBox creditgroupBox;
        private System.Windows.Forms.TextBox amounttextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox depositepersontextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox banknametextBox;
        private System.Windows.Forms.Label label1;
    }
}