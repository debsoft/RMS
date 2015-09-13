namespace RMS.Reports
{
    partial class RawMat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawMat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnA4Print = new RMSUI.FunctionalButton();
            this.btnPrint = new RMSUI.FunctionalButton();
            this.btnPrintSummary = new RMSUI.FunctionalButton();
            this.btnBack = new RMSUI.FunctionalButton();
            this.RawMatGrid = new RMSUI.SimpleGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RawMatGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date From";
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(89, 62);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(200, 20);
            this.fromDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(362, 62);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(200, 20);
            this.toDate.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::RMS.Properties.Resources.reports1;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(582, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "product_id";
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            // 
            // product_Name
            // 
            this.product_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.product_Name.DataPropertyName = "product_Name";
            this.product_Name.HeaderText = "Item Name";
            this.product_Name.Name = "product_Name";
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "amount";
            this.ItemPrice.HeaderText = "ItemPrice (£)";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Width = 150;
            // 
            // ItemQty
            // 
            this.ItemQty.DataPropertyName = "quantity";
            this.ItemQty.HeaderText = "Item Qty.";
            this.ItemQty.Name = "ItemQty";
            this.ItemQty.Width = 150;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "Total Amount (£)";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 31);
            this.label3.TabIndex = 61;
            this.label3.Text = "Raw Material Report";
            // 
            // btnA4Print
            // 
            this.btnA4Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnA4Print.BackColor = System.Drawing.Color.Black;
            this.btnA4Print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnA4Print.BackgroundImage")));
            this.btnA4Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnA4Print.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnA4Print.BgImageOnMouseDown")));
            this.btnA4Print.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnA4Print.BgImageOnMouseUp")));
            this.btnA4Print.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnA4Print.FlatAppearance.BorderSize = 0;
            this.btnA4Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnA4Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnA4Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA4Print.Font = new System.Drawing.Font("Arial", 10F);
            this.btnA4Print.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnA4Print.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnA4Print.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnA4Print.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnA4Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnA4Print.Location = new System.Drawing.Point(614, 436);
            this.btnA4Print.Name = "btnA4Print";
            this.btnA4Print.Size = new System.Drawing.Size(169, 38);
            this.btnA4Print.TabIndex = 60;
            this.btnA4Print.Text = "Print A4 Size";
            this.btnA4Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnA4Print.UseVisualStyleBackColor = false;
            this.btnA4Print.Visible = false;
            this.btnA4Print.Click += new System.EventHandler(this.btnA4Print_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.Black;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseDown")));
            this.btnPrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseUp")));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(582, 348);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(169, 38);
            this.btnPrint.TabIndex = 59;
            this.btnPrint.Text = "Print Report(RP)";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintSummary.BackColor = System.Drawing.Color.Black;
            this.btnPrintSummary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BackgroundImage")));
            this.btnPrintSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintSummary.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BgImageOnMouseDown")));
            this.btnPrintSummary.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BgImageOnMouseUp")));
            this.btnPrintSummary.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintSummary.FlatAppearance.BorderSize = 0;
            this.btnPrintSummary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintSummary.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrintSummary.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrintSummary.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrintSummary.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrintSummary.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.Image")));
            this.btnPrintSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSummary.Location = new System.Drawing.Point(396, 410);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(200, 38);
            this.btnPrintSummary.TabIndex = 58;
            this.btnPrintSummary.Text = "Print Todays Report (RP)";
            this.btnPrintSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSummary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintSummary.UseVisualStyleBackColor = false;
            this.btnPrintSummary.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BgImageOnMouseDown = null;
            this.btnBack.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnBack.BgImageOnMouseUp")));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnBack.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnBack.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(15, 380);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(123, 39);
            this.btnBack.TabIndex = 57;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // RawMatGrid
            // 
            this.RawMatGrid.AllowUserToAddRows = false;
            this.RawMatGrid.AllowUserToDeleteRows = false;
            this.RawMatGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RawMatGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.RawMatGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RawMatGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RawMatGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RawMatGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RawMatGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.RawMatGrid.GridColor = System.Drawing.Color.Gray;
            this.RawMatGrid.Location = new System.Drawing.Point(15, 107);
            this.RawMatGrid.Name = "RawMatGrid";
            this.RawMatGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.RawMatGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.RawMatGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RawMatGrid.Size = new System.Drawing.Size(725, 183);
            this.RawMatGrid.TabIndex = 53;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cat3_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProdID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn5.HeaderText = "Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cat3_name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "UnitsInStock";
            this.dataGridViewTextBoxColumn3.HeaderText = "Total Stock";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "uom";
            this.dataGridViewTextBoxColumn4.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "AdditionalQty";
            this.dataGridViewTextBoxColumn6.HeaderText = "Received Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 170;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PrevQty";
            this.dataGridViewTextBoxColumn7.HeaderText = "Previous Stock Qty";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 170;
            // 
            // RawMat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(783, 486);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnA4Print);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.RawMatGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.label1);
            this.Name = "RawMat";
            this.Text = "RawMat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.RawMatGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.CheckBox chkFromTime;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private RMSUI.SimpleGrid RawMatGrid;
        private RMSUI.FunctionalButton btnBack;
        private RMSUI.FunctionalButton btnPrintSummary;
        private RMSUI.FunctionalButton btnPrint;
        private RMSUI.FunctionalButton btnA4Print;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}