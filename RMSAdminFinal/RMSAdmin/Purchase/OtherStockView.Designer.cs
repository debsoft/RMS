namespace RMSAdmin.Purchase
{
    partial class OtherStockView
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
            this.label1 = new System.Windows.Forms.Label();
            this.findItembutton = new System.Windows.Forms.Button();
            this.otherpurchaseStoredataGridView = new System.Windows.Forms.DataGridView();
            this.itemNametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.additembutton = new System.Windows.Forms.Button();
            this.CategoryAddbutton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Purchase = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Return = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StockOut = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Damage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.otherpurchaseStoredataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item Name";
            // 
            // findItembutton
            // 
            this.findItembutton.Location = new System.Drawing.Point(559, 41);
            this.findItembutton.Name = "findItembutton";
            this.findItembutton.Size = new System.Drawing.Size(83, 27);
            this.findItembutton.TabIndex = 8;
            this.findItembutton.Text = "Search";
            this.findItembutton.UseVisualStyleBackColor = true;
            this.findItembutton.Click += new System.EventHandler(this.findItembutton_Click);
            // 
            // otherpurchaseStoredataGridView
            // 
            this.otherpurchaseStoredataGridView.AllowUserToAddRows = false;
            this.otherpurchaseStoredataGridView.AllowUserToDeleteRows = false;
            this.otherpurchaseStoredataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherpurchaseStoredataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column11,
            this.Column12,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Purchase,
            this.Return,
            this.StockOut,
            this.Damage,
            this.Delete});
            this.otherpurchaseStoredataGridView.Location = new System.Drawing.Point(32, 174);
            this.otherpurchaseStoredataGridView.Name = "otherpurchaseStoredataGridView";
            this.otherpurchaseStoredataGridView.ReadOnly = true;
            this.otherpurchaseStoredataGridView.Size = new System.Drawing.Size(1040, 509);
            this.otherpurchaseStoredataGridView.TabIndex = 7;
            this.otherpurchaseStoredataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.otherpurchaseStoredataGridView_CellContentClick);
            // 
            // itemNametextBox
            // 
            this.itemNametextBox.Location = new System.Drawing.Point(329, 44);
            this.itemNametextBox.Name = "itemNametextBox";
            this.itemNametextBox.Size = new System.Drawing.Size(206, 20);
            this.itemNametextBox.TabIndex = 6;
            this.itemNametextBox.TextChanged += new System.EventHandler(this.itemNametextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(470, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "All Item View ";
            // 
            // additembutton
            // 
            this.additembutton.Location = new System.Drawing.Point(709, 41);
            this.additembutton.Name = "additembutton";
            this.additembutton.Size = new System.Drawing.Size(129, 37);
            this.additembutton.TabIndex = 10;
            this.additembutton.Text = "Add Item";
            this.additembutton.UseVisualStyleBackColor = true;
            this.additembutton.Click += new System.EventHandler(this.additembutton_Click);
            // 
            // CategoryAddbutton
            // 
            this.CategoryAddbutton.Location = new System.Drawing.Point(848, 41);
            this.CategoryAddbutton.Name = "CategoryAddbutton";
            this.CategoryAddbutton.Size = new System.Drawing.Size(129, 37);
            this.CategoryAddbutton.TabIndex = 11;
            this.CategoryAddbutton.Text = "Add Category";
            this.CategoryAddbutton.UseVisualStyleBackColor = true;
            this.CategoryAddbutton.Click += new System.EventHandler(this.CategoryAddbutton_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "StoreId";
            this.Column1.HeaderText = "Store Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "CategoryName";
            this.Column11.HeaderText = "Category Name";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "CategoryId";
            this.Column12.HeaderText = "Category Id";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ItemName";
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Quantity";
            this.Column3.HeaderText = "Quantity";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Unit";
            this.Column4.HeaderText = "Unit";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Amount";
            this.Column5.HeaderText = "Amount";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "UnitPrice";
            this.Column6.HeaderText = "Unit Price";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Purchase
            // 
            this.Purchase.DataPropertyName = "Purchase";
            this.Purchase.HeaderText = "Purchase";
            this.Purchase.Name = "Purchase";
            this.Purchase.ReadOnly = true;
            this.Purchase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Purchase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Return
            // 
            this.Return.DataPropertyName = "Return";
            this.Return.HeaderText = "Return";
            this.Return.Name = "Return";
            this.Return.ReadOnly = true;
            this.Return.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Return.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // StockOut
            // 
            this.StockOut.DataPropertyName = "StockOut";
            this.StockOut.HeaderText = "Stock Out";
            this.StockOut.Name = "StockOut";
            this.StockOut.ReadOnly = true;
            this.StockOut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StockOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Damage
            // 
            this.Damage.DataPropertyName = "Damage";
            this.Damage.HeaderText = "Damage";
            this.Damage.Name = "Damage";
            this.Damage.ReadOnly = true;
            this.Damage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Damage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OtherStockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 730);
            this.Controls.Add(this.CategoryAddbutton);
            this.Controls.Add(this.additembutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findItembutton);
            this.Controls.Add(this.otherpurchaseStoredataGridView);
            this.Controls.Add(this.itemNametextBox);
            this.Controls.Add(this.label2);
            this.Name = "OtherStockView";
            this.Text = "OtherStockView";
            ((System.ComponentModel.ISupportInitialize)(this.otherpurchaseStoredataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button findItembutton;
        private System.Windows.Forms.DataGridView otherpurchaseStoredataGridView;
        private System.Windows.Forms.TextBox itemNametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button additembutton;
        private System.Windows.Forms.Button CategoryAddbutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Purchase;
        private System.Windows.Forms.DataGridViewButtonColumn Return;
        private System.Windows.Forms.DataGridViewButtonColumn StockOut;
        private System.Windows.Forms.DataGridViewButtonColumn Damage;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}