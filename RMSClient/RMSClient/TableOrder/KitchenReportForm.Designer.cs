namespace RMS.TableOrder
{
    partial class KitchenReportForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PaymentSlipItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KitchenPrintDataSet = new RMS.TableOrder.KitchenPrintDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentSlipItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KitchenPrintDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PaymentSlipItemsBindingSource
            // 
            this.PaymentSlipItemsBindingSource.DataMember = "PaymentSlipItems";
            this.PaymentSlipItemsBindingSource.DataSource = typeof(RMS.DataSet1);
            // 
            // ItemsBindingSource
            // 
            this.ItemsBindingSource.DataMember = "Items";
            this.ItemsBindingSource.DataSource = this.KitchenPrintDataSet;
            // 
            // KitchenPrintDataSet
            // 
            this.KitchenPrintDataSet.DataSetName = "KitchenPrintDataSet";
            this.KitchenPrintDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1_PaymentSlipItems";
            reportDataSource1.Value = this.PaymentSlipItemsBindingSource;
            reportDataSource2.Name = "KitchenPrintDataSet_Items";
            reportDataSource2.Value = this.ItemsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RMS.TableOrder.KitchenReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(543, 200);
            this.reportViewer1.TabIndex = 0;
            // 
            // KitchenReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 441);
            this.Controls.Add(this.reportViewer1);
            this.Name = "KitchenReportForm";
            this.Text = "KitchenReportForm";
            this.Load += new System.EventHandler(this.KitchenReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentSlipItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KitchenPrintDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PaymentSlipItemsBindingSource;
        private KitchenPrintDataSet KitchenPrintDataSet;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource ItemsBindingSource;
    }
}