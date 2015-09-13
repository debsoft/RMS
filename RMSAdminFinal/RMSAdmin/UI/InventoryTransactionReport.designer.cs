namespace BistroAdmin.UI
{
    partial class InventoryTransactionReport
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
            this.transactioncheckBox = new System.Windows.Forms.CheckBox();
            this.transactionNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.printTransactionReportbutton = new System.Windows.Forms.Button();
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
            this.inventoryTransactionDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTransactionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // transactioncheckBox
            // 
            this.transactioncheckBox.AutoSize = true;
            this.transactioncheckBox.Location = new System.Drawing.Point(774, 142);
            this.transactioncheckBox.Name = "transactioncheckBox";
            this.transactioncheckBox.Size = new System.Drawing.Size(115, 17);
            this.transactioncheckBox.TabIndex = 88;
            this.transactioncheckBox.Text = "Active Transaction";
            this.transactioncheckBox.UseVisualStyleBackColor = true;
            // 
            // transactionNamecomboBox
            // 
            this.transactionNamecomboBox.FormattingEnabled = true;
            this.transactionNamecomboBox.Location = new System.Drawing.Point(534, 140);
            this.transactionNamecomboBox.Margin = new System.Windows.Forms.Padding(5);
            this.transactionNamecomboBox.Name = "transactionNamecomboBox";
            this.transactionNamecomboBox.Size = new System.Drawing.Size(199, 21);
            this.transactionNamecomboBox.TabIndex = 87;
            this.transactionNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.transactionNamecomboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(434, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 86;
            this.label8.Text = "Transaction Type";
            // 
            // printTransactionReportbutton
            // 
            this.printTransactionReportbutton.Location = new System.Drawing.Point(114, 170);
            this.printTransactionReportbutton.Margin = new System.Windows.Forms.Padding(5);
            this.printTransactionReportbutton.Name = "printTransactionReportbutton";
            this.printTransactionReportbutton.Size = new System.Drawing.Size(125, 35);
            this.printTransactionReportbutton.TabIndex = 77;
            this.printTransactionReportbutton.Text = "Print";
            this.printTransactionReportbutton.UseVisualStyleBackColor = true;
            this.printTransactionReportbutton.Click += new System.EventHandler(this.printTransactionReportbutton_Click);
            // 
            // viewAllAbovecheckBox
            // 
            this.viewAllAbovecheckBox.AutoSize = true;
            this.viewAllAbovecheckBox.Location = new System.Drawing.Point(774, 110);
            this.viewAllAbovecheckBox.Name = "viewAllAbovecheckBox";
            this.viewAllAbovecheckBox.Size = new System.Drawing.Size(142, 17);
            this.viewAllAbovecheckBox.TabIndex = 76;
            this.viewAllAbovecheckBox.Text = "View All Above Category";
            this.viewAllAbovecheckBox.UseVisualStyleBackColor = true;
            // 
            // viewAllRawcheckBox
            // 
            this.viewAllRawcheckBox.AutoSize = true;
            this.viewAllRawcheckBox.Location = new System.Drawing.Point(774, 74);
            this.viewAllRawcheckBox.Name = "viewAllRawcheckBox";
            this.viewAllRawcheckBox.Size = new System.Drawing.Size(63, 17);
            this.viewAllRawcheckBox.TabIndex = 75;
            this.viewAllRawcheckBox.Text = "View All";
            this.viewAllRawcheckBox.UseVisualStyleBackColor = true;
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(687, 34);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 74;
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(385, 34);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 73;
            // 
            // rawMaterialsNameComboBox
            // 
            this.rawMaterialsNameComboBox.FormattingEnabled = true;
            this.rawMaterialsNameComboBox.Location = new System.Drawing.Point(534, 108);
            this.rawMaterialsNameComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.rawMaterialsNameComboBox.Name = "rawMaterialsNameComboBox";
            this.rawMaterialsNameComboBox.Size = new System.Drawing.Size(199, 21);
            this.rawMaterialsNameComboBox.TabIndex = 72;
            // 
            // categoryNameComboBox
            // 
            this.categoryNameComboBox.FormattingEnabled = true;
            this.categoryNameComboBox.Location = new System.Drawing.Point(534, 72);
            this.categoryNameComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.categoryNameComboBox.Name = "categoryNameComboBox";
            this.categoryNameComboBox.Size = new System.Drawing.Size(199, 21);
            this.categoryNameComboBox.TabIndex = 64;
            this.categoryNameComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryNameComboBox_SelectedIndexChanged);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(613, 170);
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
            this.label6.Location = new System.Drawing.Point(449, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Category Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "To Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "From Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, -56);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Raw Materials Report";
            // 
            // inventoryTransactionDataGridView
            // 
            this.inventoryTransactionDataGridView.AllowUserToAddRows = false;
            this.inventoryTransactionDataGridView.AllowUserToDeleteRows = false;
            this.inventoryTransactionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryTransactionDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.inventoryTransactionDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inventoryTransactionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryTransactionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column4,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column12});
            this.inventoryTransactionDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.inventoryTransactionDataGridView.Location = new System.Drawing.Point(114, 209);
            this.inventoryTransactionDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.inventoryTransactionDataGridView.Name = "inventoryTransactionDataGridView";
            this.inventoryTransactionDataGridView.ReadOnly = true;
            this.inventoryTransactionDataGridView.Size = new System.Drawing.Size(860, 292);
            this.inventoryTransactionDataGridView.TabIndex = 65;
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
            // Column3
            // 
            this.Column3.DataPropertyName = "ItemName";
            this.Column3.HeaderText = "Item Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Quantity";
            this.Column5.HeaderText = "Quantity";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Unit";
            this.Column6.HeaderText = "Unit";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "UnitPrice";
            this.Column4.HeaderText = "Unit Price";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TotalPrice";
            this.Column7.HeaderText = "Total Price";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TransactionType";
            this.Column8.HeaderText = "Transaction Type";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DamageReport";
            this.Column9.HeaderText = "Damage Report";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "UserName";
            this.Column12.HeaderText = "User Name";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(396, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 24);
            this.label7.TabIndex = 112;
            this.label7.Text = "Inventory Transaction Report";
            // 
            // InventoryTransactionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.label7);
            this.Controls.Add(this.transactioncheckBox);
            this.Controls.Add(this.transactionNamecomboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.printTransactionReportbutton);
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
            this.Controls.Add(this.inventoryTransactionDataGridView);
            this.Name = "InventoryTransactionReport";
            this.Size = new System.Drawing.Size(1260, 505);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTransactionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox transactioncheckBox;
        private System.Windows.Forms.ComboBox transactionNamecomboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button printTransactionReportbutton;
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
        private System.Windows.Forms.DataGridView inventoryTransactionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Label label7;
    }
}