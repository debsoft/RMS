namespace BistroAdmin.UI
{
    partial class RawMaterialsItemDetails
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
            this.categorypanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryNamecomboBox = new System.Windows.Forms.ComboBox();
            this.rawmaterislaItemdataGridView = new System.Windows.Forms.DataGridView();
            this.II_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.II_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IC_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.up = new System.Windows.Forms.DataGridViewButtonColumn();
            this.del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.categorypanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawmaterislaItemdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // categorypanel
            // 
            this.categorypanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.categorypanel.Controls.Add(this.label5);
            this.categorypanel.Controls.Add(this.label1);
            this.categorypanel.Controls.Add(this.categoryNamecomboBox);
            this.categorypanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categorypanel.Location = new System.Drawing.Point(0, 0);
            this.categorypanel.Name = "categorypanel";
            this.categorypanel.Size = new System.Drawing.Size(834, 81);
            this.categorypanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(307, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 24);
            this.label5.TabIndex = 112;
            this.label5.Text = "Raw Materials Details Report";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category";
            // 
            // categoryNamecomboBox
            // 
            this.categoryNamecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryNamecomboBox.FormattingEnabled = true;
            this.categoryNamecomboBox.Location = new System.Drawing.Point(326, 43);
            this.categoryNamecomboBox.Name = "categoryNamecomboBox";
            this.categoryNamecomboBox.Size = new System.Drawing.Size(240, 21);
            this.categoryNamecomboBox.TabIndex = 0;
            this.categoryNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.categoryNamecomboBox_SelectedIndexChanged);
            // 
            // rawmaterislaItemdataGridView
            // 
            this.rawmaterislaItemdataGridView.AllowUserToAddRows = false;
            this.rawmaterislaItemdataGridView.AllowUserToDeleteRows = false;
            this.rawmaterislaItemdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rawmaterislaItemdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rawmaterislaItemdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.II_id,
            this.II_name,
            this.IC_id,
            this.unit_name,
            this.up,
            this.del});
            this.rawmaterislaItemdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawmaterislaItemdataGridView.Location = new System.Drawing.Point(0, 81);
            this.rawmaterislaItemdataGridView.Name = "rawmaterislaItemdataGridView";
            this.rawmaterislaItemdataGridView.ReadOnly = true;
            this.rawmaterislaItemdataGridView.Size = new System.Drawing.Size(834, 265);
            this.rawmaterislaItemdataGridView.TabIndex = 1;
            this.rawmaterislaItemdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rawmaterislaItemdataGridView_CellContentClick);
            this.rawmaterislaItemdataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rawmaterislaItemdataGridView_CellContentDoubleClick);
            // 
            // II_id
            // 
            this.II_id.DataPropertyName = "II_id";
            this.II_id.HeaderText = "Item Id";
            this.II_id.Name = "II_id";
            this.II_id.ReadOnly = true;
            this.II_id.Visible = false;
            // 
            // II_name
            // 
            this.II_name.DataPropertyName = "II_name";
            this.II_name.HeaderText = "Item Name";
            this.II_name.Name = "II_name";
            this.II_name.ReadOnly = true;
            // 
            // IC_id
            // 
            this.IC_id.DataPropertyName = "IC_id";
            this.IC_id.HeaderText = "Item Category";
            this.IC_id.Name = "IC_id";
            this.IC_id.ReadOnly = true;
            this.IC_id.Visible = false;
            // 
            // unit_name
            // 
            this.unit_name.DataPropertyName = "unit_name";
            this.unit_name.HeaderText = "Unit Name";
            this.unit_name.Name = "unit_name";
            this.unit_name.ReadOnly = true;
            // 
            // up
            // 
            this.up.DataPropertyName = "up";
            this.up.HeaderText = "Update";
            this.up.Name = "up";
            this.up.ReadOnly = true;
            // 
            // del
            // 
            this.del.DataPropertyName = "del";
            this.del.HeaderText = "Delete";
            this.del.Name = "del";
            this.del.ReadOnly = true;
            // 
            // RawMaterialsItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rawmaterislaItemdataGridView);
            this.Controls.Add(this.categorypanel);
            this.Name = "RawMaterialsItemDetails";
            this.Size = new System.Drawing.Size(834, 346);
            this.Load += new System.EventHandler(this.RawMaterialsItemDetails_Load);
            this.categorypanel.ResumeLayout(false);
            this.categorypanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawmaterislaItemdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel categorypanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryNamecomboBox;
        private System.Windows.Forms.DataGridView rawmaterislaItemdataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn II_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn II_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn IC_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_name;
        private System.Windows.Forms.DataGridViewButtonColumn up;
        private System.Windows.Forms.DataGridViewButtonColumn del;
        private System.Windows.Forms.Label label5;
    }
}