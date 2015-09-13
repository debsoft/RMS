namespace BistroAdmin.UI
{
    partial class InventoryStockReportForm
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
            this.totalBalancelabel = new System.Windows.Forms.Label();
            this.totalReturnlabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.totalSaleslabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.receiveSumLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.printStockReportbutton = new System.Windows.Forms.Button();
            this.viewAllAbovecheckBox = new System.Windows.Forms.CheckBox();
            this.viewAllRawcheckBox = new System.Windows.Forms.CheckBox();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.rawMaterialsNameComboBox = new System.Windows.Forms.ComboBox();
            this.categoryNameComboBox = new System.Windows.Forms.ComboBox();
            this.showButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inventorystockDataGridView = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.inventorystockDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalBalancelabel
            // 
            this.totalBalancelabel.AutoSize = true;
            this.totalBalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBalancelabel.Location = new System.Drawing.Point(916, 159);
            this.totalBalancelabel.Name = "totalBalancelabel";
            this.totalBalancelabel.Size = new System.Drawing.Size(32, 13);
            this.totalBalancelabel.TabIndex = 85;
            this.totalBalancelabel.Text = "0.00";
            // 
            // totalReturnlabel
            // 
            this.totalReturnlabel.AutoSize = true;
            this.totalReturnlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalReturnlabel.Location = new System.Drawing.Point(192, 512);
            this.totalReturnlabel.Name = "totalReturnlabel";
            this.totalReturnlabel.Size = new System.Drawing.Size(32, 13);
            this.totalReturnlabel.TabIndex = 83;
            this.totalReturnlabel.Text = "0.00";
            this.totalReturnlabel.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(104, 512);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 82;
            this.label11.Text = "Total Return:";
            this.label11.Visible = false;
            // 
            // totalSaleslabel
            // 
            this.totalSaleslabel.AutoSize = true;
            this.totalSaleslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSaleslabel.Location = new System.Drawing.Point(192, 489);
            this.totalSaleslabel.Name = "totalSaleslabel";
            this.totalSaleslabel.Size = new System.Drawing.Size(32, 13);
            this.totalSaleslabel.TabIndex = 81;
            this.totalSaleslabel.Text = "0.00";
            this.totalSaleslabel.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(111, 489);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "Total Sales:";
            this.label9.Visible = false;
            // 
            // receiveSumLabel
            // 
            this.receiveSumLabel.AutoSize = true;
            this.receiveSumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiveSumLabel.Location = new System.Drawing.Point(192, 463);
            this.receiveSumLabel.Name = "receiveSumLabel";
            this.receiveSumLabel.Size = new System.Drawing.Size(32, 13);
            this.receiveSumLabel.TabIndex = 79;
            this.receiveSumLabel.Text = "0.00";
            this.receiveSumLabel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Total Received:";
            this.label7.Visible = false;
            // 
            // printStockReportbutton
            // 
            this.printStockReportbutton.Location = new System.Drawing.Point(108, 146);
            this.printStockReportbutton.Margin = new System.Windows.Forms.Padding(5);
            this.printStockReportbutton.Name = "printStockReportbutton";
            this.printStockReportbutton.Size = new System.Drawing.Size(125, 35);
            this.printStockReportbutton.TabIndex = 77;
            this.printStockReportbutton.Text = "Print";
            this.printStockReportbutton.UseVisualStyleBackColor = true;
            this.printStockReportbutton.Click += new System.EventHandler(this.printStockReportbutton_Click);
            // 
            // viewAllAbovecheckBox
            // 
            this.viewAllAbovecheckBox.AutoSize = true;
            this.viewAllAbovecheckBox.Location = new System.Drawing.Point(790, 115);
            this.viewAllAbovecheckBox.Name = "viewAllAbovecheckBox";
            this.viewAllAbovecheckBox.Size = new System.Drawing.Size(142, 17);
            this.viewAllAbovecheckBox.TabIndex = 76;
            this.viewAllAbovecheckBox.Text = "View All Above Category";
            this.viewAllAbovecheckBox.UseVisualStyleBackColor = true;
            // 
            // viewAllRawcheckBox
            // 
            this.viewAllRawcheckBox.AutoSize = true;
            this.viewAllRawcheckBox.Location = new System.Drawing.Point(790, 79);
            this.viewAllRawcheckBox.Name = "viewAllRawcheckBox";
            this.viewAllRawcheckBox.Size = new System.Drawing.Size(63, 17);
            this.viewAllRawcheckBox.TabIndex = 75;
            this.viewAllRawcheckBox.Text = "View All";
            this.viewAllRawcheckBox.UseVisualStyleBackColor = true;
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(703, 39);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 74;
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(401, 39);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 73;
            // 
            // rawMaterialsNameComboBox
            // 
            this.rawMaterialsNameComboBox.FormattingEnabled = true;
            this.rawMaterialsNameComboBox.Location = new System.Drawing.Point(550, 113);
            this.rawMaterialsNameComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.rawMaterialsNameComboBox.Name = "rawMaterialsNameComboBox";
            this.rawMaterialsNameComboBox.Size = new System.Drawing.Size(199, 21);
            this.rawMaterialsNameComboBox.TabIndex = 72;
            // 
            // categoryNameComboBox
            // 
            this.categoryNameComboBox.FormattingEnabled = true;
            this.categoryNameComboBox.Location = new System.Drawing.Point(550, 77);
            this.categoryNameComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.categoryNameComboBox.Name = "categoryNameComboBox";
            this.categoryNameComboBox.Size = new System.Drawing.Size(199, 21);
            this.categoryNameComboBox.TabIndex = 64;
            this.categoryNameComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryNameComboBox_SelectedIndexChanged);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(627, 148);
            this.showButton.Margin = new System.Windows.Forms.Padding(5);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(125, 35);
            this.showButton.TabIndex = 63;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Category Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(631, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "To Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "From Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, -58);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Raw Materials Report";
            // 
            // inventorystockDataGridView
            // 
            this.inventorystockDataGridView.AllowUserToAddRows = false;
            this.inventorystockDataGridView.AllowUserToDeleteRows = false;
            this.inventorystockDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventorystockDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.inventorystockDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inventorystockDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventorystockDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.ItemName,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column4,
            this.ItemId,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.BalancePrice});
            this.inventorystockDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.inventorystockDataGridView.Location = new System.Drawing.Point(108, 188);
            this.inventorystockDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.inventorystockDataGridView.Name = "inventorystockDataGridView";
            this.inventorystockDataGridView.ReadOnly = true;
            this.inventorystockDataGridView.Size = new System.Drawing.Size(854, 275);
            this.inventorystockDataGridView.TabIndex = 65;
            this.inventorystockDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventorystockDataGridView_CellContentDoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(778, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 13);
            this.label13.TabIndex = 84;
            this.label13.Text = "Total Balance Price:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(397, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 24);
            this.label8.TabIndex = 112;
            this.label8.Text = "Inventory Stock Report";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Date";
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CategoryName";
            this.Column2.HeaderText = "Category Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ReceivedQty";
            this.Column5.HeaderText = "Received Qty";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "SendQty";
            this.Column6.HeaderText = "Send Qty";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DamageQty";
            this.Column7.HeaderText = "Damage Qty ";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "BalanceQty";
            this.Column8.HeaderText = "Balance Qty";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CategoryId";
            this.Column4.HeaderText = "CategoryId";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "UnitPrice";
            this.Column10.HeaderText = "UnitPrice";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Unit";
            this.Column11.HeaderText = "Unit";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "InventoryStockReportId";
            this.Column12.HeaderText = "InventoryStockReportId";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "SaleQty";
            this.Column13.HeaderText = "Sale Qty";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Price";
            this.Column14.HeaderText = "Price";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            // 
            // BalancePrice
            // 
            this.BalancePrice.DataPropertyName = "BalancePrice";
            this.BalancePrice.HeaderText = "BalancePrice";
            this.BalancePrice.Name = "BalancePrice";
            this.BalancePrice.ReadOnly = true;
            this.BalancePrice.Visible = false;
            // 
            // InventoryStockReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.label8);
            this.Controls.Add(this.totalBalancelabel);
            this.Controls.Add(this.totalReturnlabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.totalSaleslabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.receiveSumLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.printStockReportbutton);
            this.Controls.Add(this.viewAllAbovecheckBox);
            this.Controls.Add(this.viewAllRawcheckBox);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.rawMaterialsNameComboBox);
            this.Controls.Add(this.categoryNameComboBox);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inventorystockDataGridView);
            this.Controls.Add(this.label13);
            this.Name = "InventoryStockReportForm";
            this.Size = new System.Drawing.Size(1293, 554);
            ((System.ComponentModel.ISupportInitialize)(this.inventorystockDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalBalancelabel;
        private System.Windows.Forms.Label totalReturnlabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label totalSaleslabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label receiveSumLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button printStockReportbutton;
        private System.Windows.Forms.CheckBox viewAllAbovecheckBox;
        private System.Windows.Forms.CheckBox viewAllRawcheckBox;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.ComboBox rawMaterialsNameComboBox;
        private System.Windows.Forms.ComboBox categoryNameComboBox;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView inventorystockDataGridView;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancePrice;
    }
}