namespace RMS.StockManagement
{
    partial class ProductItemCtl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductItemCtl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_stock_level_2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintOutofReorderLevel = new RMSUI.FunctionalButton();
            this.btnPrintOutOfStock = new RMSUI.FunctionalButton();
            this.btnOutofReorderLevel = new RMSUI.FunctionalButton();
            this.txt_price_level_2 = new System.Windows.Forms.TextBox();
            this.txt_price_level = new System.Windows.Forms.TextBox();
            this.btnViewOutOfStock = new RMSUI.FunctionalButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_item_name = new System.Windows.Forms.TextBox();
            this.txt_stock_level = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFoodType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_stock_level = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.cmb_price_level = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStockPrint = new RMSUI.FunctionalButton();
            this.btnExportProductListCSV = new RMSUI.FunctionalButton();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.btnAddFoodItem = new RMSUI.FunctionalButton();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.dgvFoodItem = new System.Windows.Forms.DataGridView();
            this.cat3_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category3_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category3_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parent_Category_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category1_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category2_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReorderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddStock = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Reconcile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_no_row_found = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodItem)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt_stock_level_2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.txt_stock_level);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmb_stock_level);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_barcode);
            this.panel1.Controls.Add(this.cmb_price_level);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 148);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txt_stock_level_2
            // 
            this.txt_stock_level_2.Enabled = false;
            this.txt_stock_level_2.Location = new System.Drawing.Point(925, 6);
            this.txt_stock_level_2.Name = "txt_stock_level_2";
            this.txt_stock_level_2.Size = new System.Drawing.Size(69, 20);
            this.txt_stock_level_2.TabIndex = 21;
            this.txt_stock_level_2.Visible = false;
            this.txt_stock_level_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_stock_level_2_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrintOutofReorderLevel);
            this.groupBox2.Controls.Add(this.btnPrintOutOfStock);
            this.groupBox2.Controls.Add(this.btnOutofReorderLevel);
            this.groupBox2.Controls.Add(this.txt_price_level_2);
            this.groupBox2.Controls.Add(this.txt_price_level);
            this.groupBox2.Controls.Add(this.btnViewOutOfStock);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_description);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_item_name);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(348, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 112);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced Filter";
            // 
            // btnPrintOutofReorderLevel
            // 
            this.btnPrintOutofReorderLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintOutofReorderLevel.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintOutofReorderLevel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintOutofReorderLevel.BackgroundImage")));
            this.btnPrintOutofReorderLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintOutofReorderLevel.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrintOutofReorderLevel.BgImageOnMouseDown")));
            this.btnPrintOutofReorderLevel.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrintOutofReorderLevel.BgImageOnMouseUp")));
            this.btnPrintOutofReorderLevel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintOutofReorderLevel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintOutofReorderLevel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintOutofReorderLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintOutofReorderLevel.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrintOutofReorderLevel.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrintOutofReorderLevel.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrintOutofReorderLevel.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnPrintOutofReorderLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintOutofReorderLevel.Location = new System.Drawing.Point(468, 67);
            this.btnPrintOutofReorderLevel.Name = "btnPrintOutofReorderLevel";
            this.btnPrintOutofReorderLevel.Size = new System.Drawing.Size(151, 39);
            this.btnPrintOutofReorderLevel.TabIndex = 20;
            this.btnPrintOutofReorderLevel.Text = "Print Reorder Stock";
            this.btnPrintOutofReorderLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintOutofReorderLevel.UseVisualStyleBackColor = false;
            this.btnPrintOutofReorderLevel.Click += new System.EventHandler(this.functionalButton1_Click);
            // 
            // btnPrintOutOfStock
            // 
            this.btnPrintOutOfStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintOutOfStock.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintOutOfStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintOutOfStock.BackgroundImage")));
            this.btnPrintOutOfStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintOutOfStock.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrintOutOfStock.BgImageOnMouseDown")));
            this.btnPrintOutOfStock.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrintOutOfStock.BgImageOnMouseUp")));
            this.btnPrintOutOfStock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintOutOfStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintOutOfStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintOutOfStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintOutOfStock.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrintOutOfStock.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrintOutOfStock.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrintOutOfStock.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnPrintOutOfStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintOutOfStock.Location = new System.Drawing.Point(468, 22);
            this.btnPrintOutOfStock.Name = "btnPrintOutOfStock";
            this.btnPrintOutOfStock.Size = new System.Drawing.Size(151, 39);
            this.btnPrintOutOfStock.TabIndex = 18;
            this.btnPrintOutOfStock.Text = "Print Out Of Stock";
            this.btnPrintOutOfStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintOutOfStock.UseVisualStyleBackColor = false;
            this.btnPrintOutOfStock.Click += new System.EventHandler(this.btnPrintOutOfStock_Click);
            // 
            // btnOutofReorderLevel
            // 
            this.btnOutofReorderLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutofReorderLevel.BackColor = System.Drawing.Color.Transparent;
            this.btnOutofReorderLevel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOutofReorderLevel.BackgroundImage")));
            this.btnOutofReorderLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOutofReorderLevel.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnOutofReorderLevel.BgImageOnMouseDown")));
            this.btnOutofReorderLevel.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnOutofReorderLevel.BgImageOnMouseUp")));
            this.btnOutofReorderLevel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnOutofReorderLevel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOutofReorderLevel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOutofReorderLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutofReorderLevel.Font = new System.Drawing.Font("Arial", 10F);
            this.btnOutofReorderLevel.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnOutofReorderLevel.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnOutofReorderLevel.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnOutofReorderLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutofReorderLevel.Location = new System.Drawing.Point(304, 66);
            this.btnOutofReorderLevel.Name = "btnOutofReorderLevel";
            this.btnOutofReorderLevel.Size = new System.Drawing.Size(151, 39);
            this.btnOutofReorderLevel.TabIndex = 19;
            this.btnOutofReorderLevel.Text = "Out of Reorder Level";
            this.btnOutofReorderLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOutofReorderLevel.UseVisualStyleBackColor = false;
            this.btnOutofReorderLevel.Click += new System.EventHandler(this.btnOutofReorderLevel_Click);
            // 
            // txt_price_level_2
            // 
            this.txt_price_level_2.Enabled = false;
            this.txt_price_level_2.Location = new System.Drawing.Point(589, -18);
            this.txt_price_level_2.Name = "txt_price_level_2";
            this.txt_price_level_2.Size = new System.Drawing.Size(69, 21);
            this.txt_price_level_2.TabIndex = 19;
            this.txt_price_level_2.Visible = false;
            this.txt_price_level_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_price_level_2_KeyPress);
            // 
            // txt_price_level
            // 
            this.txt_price_level.Enabled = false;
            this.txt_price_level.Location = new System.Drawing.Point(502, -18);
            this.txt_price_level.Name = "txt_price_level";
            this.txt_price_level.Size = new System.Drawing.Size(69, 21);
            this.txt_price_level.TabIndex = 18;
            this.txt_price_level.Visible = false;
            this.txt_price_level.TextChanged += new System.EventHandler(this.txt_price_level_TextChanged_1);
            this.txt_price_level.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_price_level_KeyPress);
            // 
            // btnViewOutOfStock
            // 
            this.btnViewOutOfStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewOutOfStock.BackColor = System.Drawing.Color.Transparent;
            this.btnViewOutOfStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnViewOutOfStock.BackgroundImage")));
            this.btnViewOutOfStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnViewOutOfStock.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnViewOutOfStock.BgImageOnMouseDown")));
            this.btnViewOutOfStock.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnViewOutOfStock.BgImageOnMouseUp")));
            this.btnViewOutOfStock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnViewOutOfStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnViewOutOfStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnViewOutOfStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOutOfStock.Font = new System.Drawing.Font("Arial", 10F);
            this.btnViewOutOfStock.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnViewOutOfStock.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnViewOutOfStock.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnViewOutOfStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewOutOfStock.Location = new System.Drawing.Point(304, 22);
            this.btnViewOutOfStock.Name = "btnViewOutOfStock";
            this.btnViewOutOfStock.Size = new System.Drawing.Size(151, 39);
            this.btnViewOutOfStock.TabIndex = 17;
            this.btnViewOutOfStock.Text = "Search";
            this.btnViewOutOfStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewOutOfStock.UseVisualStyleBackColor = false;
            this.btnViewOutOfStock.Click += new System.EventHandler(this.btnViewOutOfStock_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(577, -15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "-";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(578, -53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "-";
            this.label10.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description";
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(75, 66);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(199, 21);
            this.txt_description.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Item Name";
            // 
            // txt_item_name
            // 
            this.txt_item_name.Location = new System.Drawing.Point(76, 31);
            this.txt_item_name.Name = "txt_item_name";
            this.txt_item_name.Size = new System.Drawing.Size(199, 21);
            this.txt_item_name.TabIndex = 1;
            this.txt_item_name.TextChanged += new System.EventHandler(this.txt_item_name_TextChanged);
            this.txt_item_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_item_name_KeyPress);
            // 
            // txt_stock_level
            // 
            this.txt_stock_level.Enabled = false;
            this.txt_stock_level.Location = new System.Drawing.Point(838, 6);
            this.txt_stock_level.Name = "txt_stock_level";
            this.txt_stock_level.Size = new System.Drawing.Size(69, 20);
            this.txt_stock_level.TabIndex = 20;
            this.txt_stock_level.Visible = false;
            this.txt_stock_level.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_stock_level_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbFoodType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.cmbParent);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 112);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category Level 1";
            // 
            // cmbFoodType
            // 
            this.cmbFoodType.BackColor = System.Drawing.Color.White;
            this.cmbFoodType.DisplayMember = "Category1_Name";
            this.cmbFoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFoodType.ForeColor = System.Drawing.Color.Black;
            this.cmbFoodType.FormattingEnabled = true;
            this.cmbFoodType.Location = new System.Drawing.Point(99, 51);
            this.cmbFoodType.Name = "cmbFoodType";
            this.cmbFoodType.Size = new System.Drawing.Size(212, 23);
            this.cmbFoodType.TabIndex = 1;
            this.cmbFoodType.ValueMember = "cat1_id";
            this.cmbFoodType.SelectedIndexChanged += new System.EventHandler(this.cmbFoodType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category Level 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category Level 2";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.White;
            this.cmbCategory.DisplayMember = "cat2_name";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.ForeColor = System.Drawing.Color.Black;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(99, 79);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(212, 23);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.ValueMember = "cat2_id";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // cmbParent
            // 
            this.cmbParent.BackColor = System.Drawing.Color.White;
            this.cmbParent.DisplayMember = "Parent_Category_Name";
            this.cmbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParent.ForeColor = System.Drawing.Color.Black;
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new System.Drawing.Point(99, 23);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new System.Drawing.Size(212, 23);
            this.cmbParent.TabIndex = 0;
            this.cmbParent.ValueMember = "parent_cat_id";
            this.cmbParent.SelectedIndexChanged += new System.EventHandler(this.cmbParent_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Search Products";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(826, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Stock Level";
            this.label8.Visible = false;
            // 
            // cmb_stock_level
            // 
            this.cmb_stock_level.BackColor = System.Drawing.Color.White;
            this.cmb_stock_level.DisplayMember = "Parent_Category_Name";
            this.cmb_stock_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_stock_level.ForeColor = System.Drawing.Color.Black;
            this.cmb_stock_level.FormattingEnabled = true;
            this.cmb_stock_level.Items.AddRange(new object[] {
            "Show All",
            "ReOrder Level",
            "0 Level",
            "Less Than",
            "Greater Than",
            "In Between",
            "Specific"});
            this.cmb_stock_level.Location = new System.Drawing.Point(894, 0);
            this.cmb_stock_level.Name = "cmb_stock_level";
            this.cmb_stock_level.Size = new System.Drawing.Size(97, 21);
            this.cmb_stock_level.TabIndex = 8;
            this.cmb_stock_level.Visible = false;
            this.cmb_stock_level.SelectedIndexChanged += new System.EventHandler(this.cmb_stock_level_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(818, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Price Level";
            this.label9.Visible = false;
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(937, 5);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(34, 20);
            this.txt_barcode.TabIndex = 0;
            this.txt_barcode.Visible = false;
            this.txt_barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_barcode_KeyPress);
            // 
            // cmb_price_level
            // 
            this.cmb_price_level.BackColor = System.Drawing.Color.White;
            this.cmb_price_level.DisplayMember = "Parent_Category_Name";
            this.cmb_price_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_price_level.ForeColor = System.Drawing.Color.Black;
            this.cmb_price_level.FormattingEnabled = true;
            this.cmb_price_level.Items.AddRange(new object[] {
            "All Price",
            "Less Than",
            "Greater Than",
            "In Between",
            "Specific"});
            this.cmb_price_level.Location = new System.Drawing.Point(883, -1);
            this.cmb_price_level.Name = "cmb_price_level";
            this.cmb_price_level.Size = new System.Drawing.Size(97, 21);
            this.cmb_price_level.TabIndex = 11;
            this.cmb_price_level.ValueMember = "parent_cat_id";
            this.cmb_price_level.Visible = false;
            this.cmb_price_level.SelectedIndexChanged += new System.EventHandler(this.cmb_price_level_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(901, -8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Barcode";
            this.label5.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnStockPrint);
            this.panel2.Controls.Add(this.btnExportProductListCSV);
            this.panel2.Controls.Add(this.lblRowCount);
            this.panel2.Controls.Add(this.btnAddFoodItem);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 46);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnStockPrint
            // 
            this.btnStockPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStockPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnStockPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStockPrint.BackgroundImage")));
            this.btnStockPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStockPrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnStockPrint.BgImageOnMouseDown")));
            this.btnStockPrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnStockPrint.BgImageOnMouseUp")));
            this.btnStockPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnStockPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStockPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStockPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnStockPrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnStockPrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnStockPrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnStockPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockPrint.Location = new System.Drawing.Point(653, 4);
            this.btnStockPrint.Name = "btnStockPrint";
            this.btnStockPrint.Size = new System.Drawing.Size(151, 39);
            this.btnStockPrint.TabIndex = 21;
            this.btnStockPrint.Text = "Print ";
            this.btnStockPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockPrint.UseVisualStyleBackColor = false;
            this.btnStockPrint.Click += new System.EventHandler(this.functionalButton2_Click);
            // 
            // btnExportProductListCSV
            // 
            this.btnExportProductListCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportProductListCSV.BackColor = System.Drawing.Color.Transparent;
            this.btnExportProductListCSV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportProductListCSV.BackgroundImage")));
            this.btnExportProductListCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportProductListCSV.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnExportProductListCSV.BgImageOnMouseDown")));
            this.btnExportProductListCSV.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnExportProductListCSV.BgImageOnMouseUp")));
            this.btnExportProductListCSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnExportProductListCSV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExportProductListCSV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExportProductListCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportProductListCSV.Font = new System.Drawing.Font("Arial", 10F);
            this.btnExportProductListCSV.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnExportProductListCSV.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnExportProductListCSV.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnExportProductListCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportProductListCSV.Location = new System.Drawing.Point(817, 4);
            this.btnExportProductListCSV.Name = "btnExportProductListCSV";
            this.btnExportProductListCSV.Size = new System.Drawing.Size(151, 38);
            this.btnExportProductListCSV.TabIndex = 4;
            this.btnExportProductListCSV.Text = "Export to CSV";
            this.btnExportProductListCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportProductListCSV.UseVisualStyleBackColor = false;
            this.btnExportProductListCSV.Click += new System.EventHandler(this.btnExportProductListCSV_Click);
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(7, 14);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(54, 17);
            this.lblRowCount.TabIndex = 3;
            this.lblRowCount.Text = "label12";
            // 
            // btnAddFoodItem
            // 
            this.btnAddFoodItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFoodItem.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFoodItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddFoodItem.BackgroundImage")));
            this.btnAddFoodItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddFoodItem.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnAddFoodItem.BgImageOnMouseDown")));
            this.btnAddFoodItem.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnAddFoodItem.BgImageOnMouseUp")));
            this.btnAddFoodItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddFoodItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddFoodItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddFoodItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFoodItem.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAddFoodItem.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnAddFoodItem.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnAddFoodItem.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnAddFoodItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFoodItem.Location = new System.Drawing.Point(240, 3);
            this.btnAddFoodItem.Name = "btnAddFoodItem";
            this.btnAddFoodItem.Size = new System.Drawing.Size(111, 39);
            this.btnAddFoodItem.TabIndex = 2;
            this.btnAddFoodItem.Text = "Add New";
            this.btnAddFoodItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddFoodItem.UseVisualStyleBackColor = false;
            this.btnAddFoodItem.Visible = false;
            this.btnAddFoodItem.Click += new System.EventHandler(this.btnAddParentCategory_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.Location = new System.Drawing.Point(188, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(46, 40);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Visible = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.Location = new System.Drawing.Point(152, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(46, 40);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Visible = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // dgvFoodItem
            // 
            this.dgvFoodItem.AllowUserToAddRows = false;
            this.dgvFoodItem.AllowUserToDeleteRows = false;
            this.dgvFoodItem.AllowUserToResizeColumns = false;
            this.dgvFoodItem.AllowUserToResizeRows = false;
            this.dgvFoodItem.ColumnHeadersHeight = 25;
            this.dgvFoodItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cat3_id,
            this.Category3_Name,
            this.UnitsInStock,
            this.BarCode,
            this.Category3_Order,
            this.RetailPrice,
            this.Parent_Category_Name,
            this.Category1_Name,
            this.Category2_Name,
            this.ReorderLevel,
            this.description,
            this.AddStock,
            this.Reconcile,
            this.Column6,
            this.Column7});
            this.dgvFoodItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvFoodItem.Location = new System.Drawing.Point(5, 5);
            this.dgvFoodItem.Name = "dgvFoodItem";
            this.dgvFoodItem.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFoodItem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFoodItem.RowTemplate.Height = 30;
            this.dgvFoodItem.Size = new System.Drawing.Size(988, 426);
            this.dgvFoodItem.TabIndex = 8;
            this.dgvFoodItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoodItem_CellClick);
            this.dgvFoodItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoodItem_CellContentClick);
            this.dgvFoodItem.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFoodItem_CellMouseClick);
            this.dgvFoodItem.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFoodItem_DataBindingComplete);
            // 
            // cat3_id
            // 
            this.cat3_id.DataPropertyName = "cat3_id";
            this.cat3_id.HeaderText = "Food Item ID";
            this.cat3_id.Name = "cat3_id";
            this.cat3_id.Visible = false;
            // 
            // Category3_Name
            // 
            this.Category3_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Category3_Name.DataPropertyName = "Category3_Name";
            this.Category3_Name.HeaderText = "Product Name";
            this.Category3_Name.Name = "Category3_Name";
            this.Category3_Name.ReadOnly = true;
            // 
            // UnitsInStock
            // 
            this.UnitsInStock.DataPropertyName = "UnitsInStock";
            this.UnitsInStock.HeaderText = "Stock";
            this.UnitsInStock.Name = "UnitsInStock";
            // 
            // BarCode
            // 
            this.BarCode.DataPropertyName = "Barcode";
            this.BarCode.HeaderText = "Bar Code";
            this.BarCode.Name = "BarCode";
            this.BarCode.Visible = false;
            // 
            // Category3_Order
            // 
            this.Category3_Order.DataPropertyName = "Category3_Order";
            this.Category3_Order.HeaderText = "Item Order Number";
            this.Category3_Order.Name = "Category3_Order";
            this.Category3_Order.ReadOnly = true;
            this.Category3_Order.Visible = false;
            // 
            // RetailPrice
            // 
            this.RetailPrice.DataPropertyName = "RetailPrice";
            this.RetailPrice.HeaderText = "Sale Price";
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.Visible = false;
            // 
            // Parent_Category_Name
            // 
            this.Parent_Category_Name.DataPropertyName = "Parent_Category_Name";
            this.Parent_Category_Name.HeaderText = "parent_cat";
            this.Parent_Category_Name.Name = "Parent_Category_Name";
            this.Parent_Category_Name.Visible = false;
            // 
            // Category1_Name
            // 
            this.Category1_Name.DataPropertyName = "Category1_Name";
            this.Category1_Name.HeaderText = "cat1";
            this.Category1_Name.Name = "Category1_Name";
            this.Category1_Name.ReadOnly = true;
            this.Category1_Name.Visible = false;
            // 
            // Category2_Name
            // 
            this.Category2_Name.DataPropertyName = "Category2_Name";
            this.Category2_Name.HeaderText = "cat2";
            this.Category2_Name.Name = "Category2_Name";
            this.Category2_Name.ReadOnly = true;
            this.Category2_Name.Visible = false;
            // 
            // ReorderLevel
            // 
            this.ReorderLevel.DataPropertyName = "ReorderLevel";
            this.ReorderLevel.HeaderText = "ReorderLevel";
            this.ReorderLevel.Name = "ReorderLevel";
            this.ReorderLevel.Visible = false;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "description";
            this.description.Name = "description";
            this.description.Visible = false;
            // 
            // AddStock
            // 
            this.AddStock.DataPropertyName = "addStock";
            this.AddStock.HeaderText = "Add Stock";
            this.AddStock.Name = "AddStock";
            this.AddStock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AddStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Reconcile
            // 
            this.Reconcile.DataPropertyName = "Reconcile";
            this.Reconcile.HeaderText = "Reconcile";
            this.Reconcile.Name = "Reconcile";
            this.Reconcile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Reconcile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "up";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Setting";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "del";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column7.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column7.HeaderText = "Delete";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl_no_row_found);
            this.panel3.Controls.Add(this.dgvFoodItem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 194);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(1000, 506);
            this.panel3.TabIndex = 9;
            // 
            // lbl_no_row_found
            // 
            this.lbl_no_row_found.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_no_row_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_no_row_found.Location = new System.Drawing.Point(5, 431);
            this.lbl_no_row_found.Name = "lbl_no_row_found";
            this.lbl_no_row_found.Size = new System.Drawing.Size(988, 94);
            this.lbl_no_row_found.TabIndex = 9;
            this.lbl_no_row_found.Text = "No Product Found.";
            this.lbl_no_row_found.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductItemCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ProductItemCtl";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.FoodItemCtl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodItem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbParent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFoodType;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridView dgvFoodItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private RMSUI.FunctionalButton btnAddFoodItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_price_level;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_stock_level;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_item_name;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_price_level;
        private System.Windows.Forms.TextBox txt_price_level_2;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_no_row_found;
        private System.Windows.Forms.TextBox txt_stock_level_2;
        private System.Windows.Forms.TextBox txt_stock_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private RMSUI.FunctionalButton btnExportProductListCSV;
        private RMSUI.FunctionalButton btnPrintOutOfStock;
        private RMSUI.FunctionalButton btnViewOutOfStock;
        private RMSUI.FunctionalButton btnOutofReorderLevel;
        private RMSUI.FunctionalButton btnPrintOutofReorderLevel;
        private RMSUI.FunctionalButton btnStockPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat3_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category3_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category3_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parent_Category_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category1_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category2_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReorderLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewButtonColumn AddStock;
        private System.Windows.Forms.DataGridViewButtonColumn Reconcile;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
    }
}
