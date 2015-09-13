namespace RMSAdmin
{
    partial class FoodTypeCtl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodTypeCtl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbParentCategory = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFoodTypeList = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAddFoodType = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodTypeList)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbParentCategory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search criteria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parent Category";
            // 
            // cmbParentCategory
            // 
            this.cmbParentCategory.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbParentCategory.DisplayMember = "Parent_Category_Name";
            this.cmbParentCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentCategory.ForeColor = System.Drawing.Color.White;
            this.cmbParentCategory.FormattingEnabled = true;
            this.cmbParentCategory.Location = new System.Drawing.Point(268, 19);
            this.cmbParentCategory.Name = "cmbParentCategory";
            this.cmbParentCategory.Size = new System.Drawing.Size(226, 24);
            this.cmbParentCategory.TabIndex = 0;
            this.cmbParentCategory.ValueMember = "parent_cat_id";
            this.cmbParentCategory.SelectedIndexChanged += new System.EventHandler(this.cmbParentCategory_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvFoodTypeList);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(0, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 394);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Food Type List";
            // 
            // dgvFoodTypeList
            // 
            this.dgvFoodTypeList.AllowUserToAddRows = false;
            this.dgvFoodTypeList.AllowUserToDeleteRows = false;
            this.dgvFoodTypeList.AllowUserToResizeColumns = false;
            this.dgvFoodTypeList.AllowUserToResizeRows = false;
            this.dgvFoodTypeList.ColumnHeadersHeight = 25;
            this.dgvFoodTypeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column12,
            this.Column10,
            this.Column11});
            this.dgvFoodTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFoodTypeList.Location = new System.Drawing.Point(3, 68);
            this.dgvFoodTypeList.Name = "dgvFoodTypeList";
            this.dgvFoodTypeList.RowHeadersVisible = false;
            this.dgvFoodTypeList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvFoodTypeList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvFoodTypeList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFoodTypeList.RowTemplate.Height = 30;
            this.dgvFoodTypeList.Size = new System.Drawing.Size(801, 323);
            this.dgvFoodTypeList.TabIndex = 6;
            this.dgvFoodTypeList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFoodTypeList_CellMouseClick);
            this.dgvFoodTypeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoodTypeList_CellClick);
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "cat1_id";
            this.Column7.HeaderText = "Food Type ID";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "Category1_Name";
            this.Column8.HeaderText = "Category Type";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "Parent_Category_Name";
            this.Column9.HeaderText = "Parent Category";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Cat1_order_number";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column12.HeaderText = "Type Order";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "up";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Brown;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column10.HeaderText = "Update";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "del";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Brown;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column11.HeaderText = "Delete";
            this.Column11.Name = "Column11";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Controls.Add(this.btnAddFoodType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 52);
            this.panel2.TabIndex = 5;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDown.BackgroundImage = global::RMSAdmin.Properties.Resources.menuOrderDown;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.Location = new System.Drawing.Point(60, 3);
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
            this.btnUp.Location = new System.Drawing.Point(8, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(46, 40);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAddFoodType
            // 
            this.btnAddFoodType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFoodType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddFoodType.BackgroundImage")));
            this.btnAddFoodType.FlatAppearance.BorderSize = 0;
            this.btnAddFoodType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddFoodType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddFoodType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFoodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFoodType.ForeColor = System.Drawing.Color.Black;
            this.btnAddFoodType.Location = new System.Drawing.Point(678, 0);
            this.btnAddFoodType.Name = "btnAddFoodType";
            this.btnAddFoodType.Size = new System.Drawing.Size(120, 40);
            this.btnAddFoodType.TabIndex = 2;
            this.btnAddFoodType.Text = "Add New";
            this.btnAddFoodType.UseVisualStyleBackColor = false;
            this.btnAddFoodType.Click += new System.EventHandler(this.btnAddFoodType_Click);
            // 
            // FoodTypeCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FoodTypeCtl";
            this.Size = new System.Drawing.Size(807, 470);
            this.Load += new System.EventHandler(this.FoodTypeCtl_Load);
            this.VisibleChanged += new System.EventHandler(this.FoodTypeCtl_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodTypeList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbParentCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddFoodType;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridView dgvFoodTypeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewButtonColumn Column10;
        private System.Windows.Forms.DataGridViewButtonColumn Column11;
    }
}
