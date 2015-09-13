namespace RMSAdmin
{
    partial class FoodItemCtl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodItemCtl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFoodType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddRawMaterial = new System.Windows.Forms.Button();
            this.btnAddFoodItem = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.dgvFoodItem = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Controls.Add(this.cmbParent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbFoodType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 103);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(301, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbCategory.DisplayMember = "cat2_name";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.ForeColor = System.Drawing.Color.White;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(358, 74);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(212, 21);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.ValueMember = "cat2_id";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // cmbParent
            // 
            this.cmbParent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbParent.DisplayMember = "Parent_Category_Name";
            this.cmbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParent.ForeColor = System.Drawing.Color.White;
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new System.Drawing.Point(358, 17);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new System.Drawing.Size(212, 21);
            this.cmbParent.TabIndex = 0;
            this.cmbParent.ValueMember = "parent_cat_id";
            this.cmbParent.SelectedIndexChanged += new System.EventHandler(this.cmbParent_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(292, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Food Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(267, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Parent Category";
            // 
            // cmbFoodType
            // 
            this.cmbFoodType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbFoodType.DisplayMember = "Category1_Name";
            this.cmbFoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFoodType.ForeColor = System.Drawing.Color.White;
            this.cmbFoodType.FormattingEnabled = true;
            this.cmbFoodType.Location = new System.Drawing.Point(358, 44);
            this.cmbFoodType.Name = "cmbFoodType";
            this.cmbFoodType.Size = new System.Drawing.Size(212, 21);
            this.cmbFoodType.TabIndex = 1;
            this.cmbFoodType.ValueMember = "cat1_id";
            this.cmbFoodType.SelectedIndexChanged += new System.EventHandler(this.cmbFoodType_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnAddRawMaterial);
            this.panel2.Controls.Add(this.btnAddFoodItem);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 52);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(358, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add RM Category ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddRawMaterial
            // 
            this.btnAddRawMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRawMaterial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddRawMaterial.BackgroundImage")));
            this.btnAddRawMaterial.FlatAppearance.BorderSize = 0;
            this.btnAddRawMaterial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddRawMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddRawMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRawMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRawMaterial.ForeColor = System.Drawing.Color.Black;
            this.btnAddRawMaterial.Location = new System.Drawing.Point(573, 7);
            this.btnAddRawMaterial.Name = "btnAddRawMaterial";
            this.btnAddRawMaterial.Size = new System.Drawing.Size(120, 39);
            this.btnAddRawMaterial.TabIndex = 3;
            this.btnAddRawMaterial.Text = "Add Raw Material ";
            this.btnAddRawMaterial.UseVisualStyleBackColor = false;
            this.btnAddRawMaterial.Click += new System.EventHandler(this.btnAddRawMaterial_Click);
            // 
            // btnAddFoodItem
            // 
            this.btnAddFoodItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFoodItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddFoodItem.BackgroundImage")));
            this.btnAddFoodItem.FlatAppearance.BorderSize = 0;
            this.btnAddFoodItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddFoodItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddFoodItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFoodItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFoodItem.ForeColor = System.Drawing.Color.Black;
            this.btnAddFoodItem.Location = new System.Drawing.Point(699, 7);
            this.btnAddFoodItem.Name = "btnAddFoodItem";
            this.btnAddFoodItem.Size = new System.Drawing.Size(120, 39);
            this.btnAddFoodItem.TabIndex = 2;
            this.btnAddFoodItem.Text = "Add New";
            this.btnAddFoodItem.UseVisualStyleBackColor = false;
            this.btnAddFoodItem.Click += new System.EventHandler(this.btnAddParentCategory_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDown.BackgroundImage = global::RMSAdmin.Properties.Resources.menuOrderDown;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.Location = new System.Drawing.Point(58, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(46, 40);
            this.btnDown.TabIndex = 1;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUp.BackgroundImage = global::RMSAdmin.Properties.Resources.menuOrderUp;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.Location = new System.Drawing.Point(6, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(46, 40);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = false;
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
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column6,
            this.Column7});
            this.dgvFoodItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFoodItem.Location = new System.Drawing.Point(0, 155);
            this.dgvFoodItem.Name = "dgvFoodItem";
            this.dgvFoodItem.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFoodItem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFoodItem.RowTemplate.Height = 30;
            this.dgvFoodItem.Size = new System.Drawing.Size(822, 326);
            this.dgvFoodItem.TabIndex = 8;
            this.dgvFoodItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoodItem_CellClick);
            this.dgvFoodItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoodItem_CellContentClick);
            this.dgvFoodItem.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFoodItem_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "cat3_id";
            this.Column1.HeaderText = "Food Item ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Category3_Name";
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Category3_Order";
            this.Column3.HeaderText = "Item Order Number";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Category2_Name";
            this.Column4.HeaderText = "Category";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Category1_Name";
            this.Column5.HeaderText = "Food Type";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "Parent_Category_Name";
            this.Column8.HeaderText = "Parent Category";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "up";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Brown;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Update";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "del";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column7.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column7.HeaderText = "Delete";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FoodItemCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.dgvFoodItem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FoodItemCtl";
            this.Size = new System.Drawing.Size(822, 481);
            this.Load += new System.EventHandler(this.FoodItemCtl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodItem)).EndInit();
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
       // public System.Windows.Forms.Button btnAddRawMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
        public System.Windows.Forms.Button btnAddFoodItem;
        public System.Windows.Forms.Button btnAddRawMaterial;
        public System.Windows.Forms.Button button1;
    }
}
