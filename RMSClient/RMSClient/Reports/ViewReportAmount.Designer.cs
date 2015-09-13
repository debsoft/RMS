namespace RMS.Reports
{
    partial class ViewReportAmount
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
            this.printbutton = new System.Windows.Forms.Button();
            this.reportdataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.reportdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // printbutton
            // 
            this.printbutton.Location = new System.Drawing.Point(110, 30);
            this.printbutton.Name = "printbutton";
            this.printbutton.Size = new System.Drawing.Size(169, 44);
            this.printbutton.TabIndex = 3;
            this.printbutton.Text = "Print";
            this.printbutton.UseVisualStyleBackColor = true;
            this.printbutton.Click += new System.EventHandler(this.printbutton_Click);
            // 
            // reportdataGridView
            // 
            this.reportdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportdataGridView.Location = new System.Drawing.Point(54, 106);
            this.reportdataGridView.Name = "reportdataGridView";
            this.reportdataGridView.Size = new System.Drawing.Size(1263, 493);
            this.reportdataGridView.TabIndex = 2;
            // 
            // ViewReportAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.printbutton);
            this.Controls.Add(this.reportdataGridView);
            this.Name = "ViewReportAmount";
            this.Text = "ViewReportAmount";
            ((System.ComponentModel.ISupportInitialize)(this.reportdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printbutton;
        public System.Windows.Forms.DataGridView reportdataGridView;
    }
}