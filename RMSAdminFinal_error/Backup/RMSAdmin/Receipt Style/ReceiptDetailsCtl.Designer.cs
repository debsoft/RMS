namespace RMSAdmin
{
    partial class ReceiptDetailsCtl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpStyle = new System.Windows.Forms.GroupBox();
            this.dgvReceiptStyles = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptStyles)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStyle
            // 
            this.grpStyle.Controls.Add(this.dgvReceiptStyles);
            this.grpStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStyle.ForeColor = System.Drawing.Color.White;
            this.grpStyle.Location = new System.Drawing.Point(0, 0);
            this.grpStyle.Name = "grpStyle";
            this.grpStyle.Size = new System.Drawing.Size(787, 462);
            this.grpStyle.TabIndex = 0;
            this.grpStyle.TabStop = false;
            this.grpStyle.Text = "Receipt Styles";
            // 
            // dgvReceiptStyles
            // 
            this.dgvReceiptStyles.AllowUserToAddRows = false;
            this.dgvReceiptStyles.AllowUserToDeleteRows = false;
            this.dgvReceiptStyles.AllowUserToResizeColumns = false;
            this.dgvReceiptStyles.AllowUserToResizeRows = false;
            this.dgvReceiptStyles.ColumnHeadersHeight = 25;
            this.dgvReceiptStyles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceiptStyles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceiptStyles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptStyles.Location = new System.Drawing.Point(3, 16);
            this.dgvReceiptStyles.Name = "dgvReceiptStyles";
            this.dgvReceiptStyles.RowHeadersVisible = false;
            this.dgvReceiptStyles.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReceiptStyles.RowTemplate.Height = 30;
            this.dgvReceiptStyles.Size = new System.Drawing.Size(781, 443);
            this.dgvReceiptStyles.TabIndex = 0;
            this.dgvReceiptStyles.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReceiptStyles_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "style_id";
            this.Column1.HeaderText = "Style ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "header";
            this.Column2.HeaderText = "Header";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "body";
            this.Column3.HeaderText = "Body";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "footer";
            this.Column4.HeaderText = "Footer";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "style_name";
            this.Column5.HeaderText = "Style Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "up";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.Column7.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column7.HeaderText = "Delete";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Visible = false;
            // 
            // ReceiptDetailsCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpStyle);
            this.Name = "ReceiptDetailsCtl";
            this.Size = new System.Drawing.Size(787, 462);
            this.Load += new System.EventHandler(this.ReceiptDetailsCtl_Load);
            this.grpStyle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptStyles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStyle;
        private System.Windows.Forms.DataGridView dgvReceiptStyles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
    }
}
