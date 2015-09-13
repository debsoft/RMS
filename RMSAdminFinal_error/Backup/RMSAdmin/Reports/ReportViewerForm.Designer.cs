namespace RMSAdmin
{
    partial class ReportViewerForm
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
            this.cRptViewerAdmin = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRptViewerAdmin
            // 
            this.cRptViewerAdmin.ActiveViewIndex = -1;
            this.cRptViewerAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRptViewerAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRptViewerAdmin.Location = new System.Drawing.Point(0, 0);
            this.cRptViewerAdmin.Name = "cRptViewerAdmin";
            this.cRptViewerAdmin.SelectionFormula = "";
            this.cRptViewerAdmin.Size = new System.Drawing.Size(793, 490);
            this.cRptViewerAdmin.TabIndex = 0;
            this.cRptViewerAdmin.ViewTimeSelectionFormula = "";
            // 
            // ReportViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 490);
            this.Controls.Add(this.cRptViewerAdmin);
            this.Name = "ReportViewerForm";
            this.Text = "RMS report management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRptViewerAdmin;
    }
}