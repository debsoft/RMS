namespace RMSAdmin.Purchase
{
    partial class ProfitLossReport
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
            this.profitlossdataGridView = new System.Windows.Forms.DataGridView();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showreportButton = new System.Windows.Forms.Button();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportprintbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.profitlossdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // profitlossdataGridView
            // 
            this.profitlossdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.profitlossdataGridView.Location = new System.Drawing.Point(38, 141);
            this.profitlossdataGridView.Name = "profitlossdataGridView";
            this.profitlossdataGridView.Size = new System.Drawing.Size(868, 289);
            this.profitlossdataGridView.TabIndex = 17;
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(443, 53);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 16;
            // 
            // showreportButton
            // 
            this.showreportButton.Location = new System.Drawing.Point(666, 52);
            this.showreportButton.Name = "showreportButton";
            this.showreportButton.Size = new System.Drawing.Size(75, 23);
            this.showreportButton.TabIndex = 15;
            this.showreportButton.Text = "Show";
            this.showreportButton.UseVisualStyleBackColor = true;
            this.showreportButton.Click += new System.EventHandler(this.showreportButton_Click);
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(206, 53);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "From";
            // 
            // reportprintbutton
            // 
            this.reportprintbutton.Location = new System.Drawing.Point(38, 57);
            this.reportprintbutton.Name = "reportprintbutton";
            this.reportprintbutton.Size = new System.Drawing.Size(75, 23);
            this.reportprintbutton.TabIndex = 18;
            this.reportprintbutton.Text = "Print";
            this.reportprintbutton.UseVisualStyleBackColor = true;
            this.reportprintbutton.Click += new System.EventHandler(this.reportprintbutton_Click);
            // 
            // ProfitLossReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 483);
            this.Controls.Add(this.reportprintbutton);
            this.Controls.Add(this.profitlossdataGridView);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.showreportButton);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProfitLossReport";
            this.Text = "ProfitLossReport";
            ((System.ComponentModel.ISupportInitialize)(this.profitlossdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView profitlossdataGridView;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.Button showreportButton;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reportprintbutton;
    }
}