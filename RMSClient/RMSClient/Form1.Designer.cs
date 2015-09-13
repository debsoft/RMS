namespace RMS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.paymentSlipItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.DataSet1 = new RMS.DataSet1();
            this.cCategoryButton1 = new RMS.Common.CCategoryButton();
            this.functionalButton1 = new RMSUI.FunctionalButton();
            this.keyButton1 = new RMSUI.KeyButton();
            this.keyboard1 = new RMSUI.keyboard();
            this.rmsToogleButton1 = new RMSUI.RMSToogleButton();
            ((System.ComponentModel.ISupportInitialize)(this.paymentSlipItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentSlipItemsBindingSource
            // 
            this.paymentSlipItemsBindingSource.DataMember = "PaymentSlipItems";
            this.paymentSlipItemsBindingSource.DataSource = typeof(RMS.DataSet1);
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.EnforceConstraints = false;
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cCategoryButton1
            // 
            this.cCategoryButton1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cCategoryButton1.CategoryID = 0;
            this.cCategoryButton1.CategoryLevel = 0;
            this.cCategoryButton1.CategoryOrder = 0;
            this.cCategoryButton1.Location = new System.Drawing.Point(355, 43);
            this.cCategoryButton1.Margin = new System.Windows.Forms.Padding(0);
            this.cCategoryButton1.Name = "cCategoryButton1";
            this.cCategoryButton1.SellingQuantityorWeight = "";
            this.cCategoryButton1.Size = new System.Drawing.Size(127, 43);
            this.cCategoryButton1.TabIndex = 0;
            this.cCategoryButton1.Text = "cCategoryButton1";
            this.cCategoryButton1.UseVisualStyleBackColor = false;
            // 
            // functionalButton1
            // 
            this.functionalButton1.BackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BackgroundImage")));
            this.functionalButton1.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BgImageOnMouseDown")));
            this.functionalButton1.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BgImageOnMouseUp")));
            this.functionalButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.functionalButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functionalButton1.Font = new System.Drawing.Font("Arial", 10F);
            this.functionalButton1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton1.FunctionType = RMSUI.RMSUIConstants.FunctionType.Add;
            this.functionalButton1.Image = ((System.Drawing.Image)(resources.GetObject("functionalButton1.Image")));
            this.functionalButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton1.Location = new System.Drawing.Point(200, 43);
            this.functionalButton1.Name = "functionalButton1";
            this.functionalButton1.Size = new System.Drawing.Size(132, 43);
            this.functionalButton1.TabIndex = 1;
            this.functionalButton1.Text = "functionalButton1";
            this.functionalButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton1.UseVisualStyleBackColor = false;
            // 
            // keyButton1
            // 
            this.keyButton1.BackColor = System.Drawing.Color.Transparent;
            this.keyButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("keyButton1.BackgroundImage")));
            this.keyButton1.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("keyButton1.BgImageOnMouseDown")));
            this.keyButton1.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("keyButton1.BgImageOnMouseUp")));
            this.keyButton1.ChangeStateText = null;
            this.keyButton1.ClearField = false;
            this.keyButton1.ControlToInputText = null;
            this.keyButton1.DefaultStateText = null;
            this.keyButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.keyButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.keyButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.keyButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyButton1.Font = new System.Drawing.Font("Arial", 20F);
            this.keyButton1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.keyButton1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.keyButton1.Location = new System.Drawing.Point(27, 43);
            this.keyButton1.Name = "keyButton1";
            this.keyButton1.RemoveLastChar = false;
            this.keyButton1.Size = new System.Drawing.Size(159, 50);
            this.keyButton1.TabIndex = 2;
            this.keyButton1.Text = "keyButton1";
            this.keyButton1.UseVisualStyleBackColor = false;
            // 
            // keyboard1
            // 
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.Location = new System.Drawing.Point(12, 134);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(728, 247);
            this.keyboard1.TabIndex = 3;
            this.keyboard1.textBox = null;
            // 
            // rmsToogleButton1
            // 
            this.rmsToogleButton1.BackColor = System.Drawing.Color.Transparent;
            this.rmsToogleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rmsToogleButton1.BackgroundImage")));
            this.rmsToogleButton1.BgImageOnMouseDown = null;
            this.rmsToogleButton1.BgImageOnMouseUp = null;
            this.rmsToogleButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.rmsToogleButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rmsToogleButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rmsToogleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rmsToogleButton1.Font = new System.Drawing.Font("Arial", 20F);
            this.rmsToogleButton1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.rmsToogleButton1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.rmsToogleButton1.IsDown = false;
            this.rmsToogleButton1.Location = new System.Drawing.Point(494, 43);
            this.rmsToogleButton1.Name = "rmsToogleButton1";
            this.rmsToogleButton1.Size = new System.Drawing.Size(226, 43);
            this.rmsToogleButton1.TabIndex = 4;
            this.rmsToogleButton1.Text = "rmsToogleButton1";
            this.rmsToogleButton1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 439);
            this.Controls.Add(this.rmsToogleButton1);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.keyButton1);
            this.Controls.Add(this.functionalButton1);
            this.Controls.Add(this.cCategoryButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentSlipItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource paymentSlipItemsBindingSource;
        private DataSet1 DataSet1;
        private Common.CCategoryButton cCategoryButton1;
        private RMSUI.FunctionalButton functionalButton1;
        private RMSUI.KeyButton keyButton1;
        private RMSUI.keyboard keyboard1;
        private RMSUI.RMSToogleButton rmsToogleButton1;
    }
}

