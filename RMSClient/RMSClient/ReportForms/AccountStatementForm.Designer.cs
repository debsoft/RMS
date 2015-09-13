namespace RMS.ReportForms
{
    partial class AccountStatementForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.todateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.showButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1017, 495);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(477, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 32;
            this.label2.Text = "Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.fromdateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromdateTimePicker.Location = new System.Drawing.Point(540, 8);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(102, 20);
            this.fromdateTimePicker.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(648, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "to";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // todateTimePicker2
            // 
            this.todateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.todateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todateTimePicker2.Location = new System.Drawing.Point(683, 8);
            this.todateTimePicker2.Name = "todateTimePicker2";
            this.todateTimePicker2.Size = new System.Drawing.Size(102, 20);
            this.todateTimePicker2.TabIndex = 35;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(791, 6);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(61, 24);
            this.showButton.TabIndex = 36;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // AccountStatementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 495);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.todateTimePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "AccountStatementForm";
            this.Text = "AccountStatementForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker todateTimePicker2;
        private System.Windows.Forms.Button showButton;
    }
}