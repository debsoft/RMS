namespace RMS.Reports
{
    partial class MembershipDiscountReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MembershipDiscountReport));
            this.membershipDiscountReportDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cardSearchButton = new RMSUI.FunctionalButton();
            this.viewAllButton = new RMSUI.FunctionalButton();
            this.nameSearchButton = new RMSUI.FunctionalButton();
            this.printButton = new RMSUI.FunctionalButton();
            ((System.ComponentModel.ISupportInitialize)(this.membershipDiscountReportDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.membershipDiscountReportDataGridView.Size = new System.Drawing.Size(1043, 375);
            this.membershipDiscountReportDataGridView.TabIndex = 0;
            this.membershipDiscountReportDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membershipDiscountReportDataGridView_CellContentClick);
            this.membershipDiscountReportDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.membershipDiscountReportDataGridView_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Member Report With Discount";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.membershipDiscountReportDataGridView);
            this.panel1.Location = new System.Drawing.Point(12, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 381);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(389, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "Card";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(436, 38);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 20);
            this.txtCode.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(45, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 65;
            this.label8.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 61;
            // 
            // cardSearchButton
            // 
            this.cardSearchButton.BackColor = System.Drawing.Color.Transparent;
            this.cardSearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardSearchButton.BackgroundImage")));
            this.cardSearchButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("cardSearchButton.BgImageOnMouseDown")));
            this.cardSearchButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("cardSearchButton.BgImageOnMouseUp")));
            this.cardSearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cardSearchButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.cardSearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cardSearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cardSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cardSearchButton.Font = new System.Drawing.Font("Arial", 10F);
            this.cardSearchButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.cardSearchButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.cardSearchButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.cardSearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cardSearchButton.Location = new System.Drawing.Point(592, 36);
            this.cardSearchButton.Name = "cardSearchButton";
            this.cardSearchButton.Size = new System.Drawing.Size(123, 28);
            this.cardSearchButton.TabIndex = 67;
            this.cardSearchButton.Text = "Search";
            this.cardSearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cardSearchButton.UseVisualStyleBackColor = false;
            this.cardSearchButton.Click += new System.EventHandler(this.cardSearchButton_Click);
            // 
            // viewAllButton
            // 
            this.viewAllButton.BackColor = System.Drawing.Color.Transparent;
            this.viewAllButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("viewAllButton.BackgroundImage")));
            this.viewAllButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("viewAllButton.BgImageOnMouseDown")));
            this.viewAllButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("viewAllButton.BgImageOnMouseUp")));
            this.viewAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.viewAllButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.viewAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.viewAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.viewAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewAllButton.Font = new System.Drawing.Font("Arial", 10F);
            this.viewAllButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.viewAllButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.viewAllButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.viewAllButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewAllButton.Location = new System.Drawing.Point(746, 34);
            this.viewAllButton.Name = "viewAllButton";
            this.viewAllButton.Size = new System.Drawing.Size(120, 33);
            this.viewAllButton.TabIndex = 64;
            this.viewAllButton.Text = "View All";
            this.viewAllButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewAllButton.UseVisualStyleBackColor = false;
            this.viewAllButton.Click += new System.EventHandler(this.viewAllButton_Click);
            // 
            // nameSearchButton
            // 
            this.nameSearchButton.BackColor = System.Drawing.Color.Transparent;
            this.nameSearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nameSearchButton.BackgroundImage")));
            this.nameSearchButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("nameSearchButton.BgImageOnMouseDown")));
            this.nameSearchButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("nameSearchButton.BgImageOnMouseUp")));
            this.nameSearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.nameSearchButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.nameSearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nameSearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nameSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameSearchButton.Font = new System.Drawing.Font("Arial", 10F);
            this.nameSearchButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.nameSearchButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.nameSearchButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.nameSearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nameSearchButton.Location = new System.Drawing.Point(254, 32);
            this.nameSearchButton.Name = "nameSearchButton";
            this.nameSearchButton.Size = new System.Drawing.Size(123, 28);
            this.nameSearchButton.TabIndex = 63;
            this.nameSearchButton.Text = "Search";
            this.nameSearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.nameSearchButton.UseVisualStyleBackColor = false;
            this.nameSearchButton.Click += new System.EventHandler(this.nameSearchButton_Click);
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
            this.printButton.Location = new System.Drawing.Point(882, 34);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(120, 33);
            this.printButton.TabIndex = 68;
            this.printButton.Text = "Print";
            this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printButton.UseVisualStyleBackColor = false;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // MembershipDiscountReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 475);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.cardSearchButton);
            this.Controls.Add(this.viewAllButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.nameSearchButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MembershipDiscountReport";
            this.Text = "MembershipDiscountReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MembershipDiscountReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membershipDiscountReportDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView membershipDiscountReportDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private RMSUI.FunctionalButton viewAllButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private RMSUI.FunctionalButton nameSearchButton;
        private RMSUI.FunctionalButton cardSearchButton;
        private RMSUI.FunctionalButton printButton;
    }
}