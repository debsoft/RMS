namespace RMS.Reports
{
    partial class MembershipDiscountSaleDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MembershipDiscountSaleDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.membershipDiscountReportDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printButton = new RMSUI.FunctionalButton();
            ((System.ComponentModel.ISupportInitialize)(this.membershipDiscountReportDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(373, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Member  Details Report With Discount";
            // 
            // membershipDiscountReportDataGridView
            // 
            this.membershipDiscountReportDataGridView.AllowUserToAddRows = false;
            this.membershipDiscountReportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.membershipDiscountReportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.membershipDiscountReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membershipDiscountReportDataGridView.Location = new System.Drawing.Point(3, 3);
            this.membershipDiscountReportDataGridView.Name = "membershipDiscountReportDataGridView";
            this.membershipDiscountReportDataGridView.ReadOnly = true;
            this.membershipDiscountReportDataGridView.Size = new System.Drawing.Size(1100, 430);
            this.membershipDiscountReportDataGridView.TabIndex = 2;
            this.membershipDiscountReportDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.membershipDiscountReportDataGridView_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.membershipDiscountReportDataGridView);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 436);
            this.panel1.TabIndex = 4;
            // 
            // printButton
            // 
            this.printButton.BackColor = System.Drawing.Color.Transparent;
            this.printButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("printButton.BackgroundImage")));
            this.printButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("printButton.BgImageOnMouseDown")));
            this.printButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("printButton.BgImageOnMouseUp")));
            this.printButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.printButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.printButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.printButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.printButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printButton.Font = new System.Drawing.Font("Arial", 10F);
            this.printButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.printButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.printButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printButton.Location = new System.Drawing.Point(15, 25);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(120, 33);
            this.printButton.TabIndex = 69;
            this.printButton.Text = "Print";
            this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printButton.UseVisualStyleBackColor = false;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // MembershipDiscountSaleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 509);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MembershipDiscountSaleDetails";
            this.Text = "MembershipDiscountSaleDetails";
            this.Load += new System.EventHandler(this.MembershipDiscountSaleDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membershipDiscountReportDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView membershipDiscountReportDataGridView;
        private System.Windows.Forms.Panel panel1;
        private RMSUI.FunctionalButton printButton;
    }
}