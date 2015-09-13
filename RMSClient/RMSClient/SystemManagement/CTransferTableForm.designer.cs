using RMSUI;
namespace RMS.SystemManagement
{
    partial class CTransferTableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTransferTableForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CurrrentTableDataGridView = new System.Windows.Forms.DataGridView();
            this.OrderIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.TableNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.BackButton = new RMSUI.FunctionalButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrrentTableDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CurrrentTableDataGridView);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TableNumberTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CustomerNameTextBox);
            this.panel1.Location = new System.Drawing.Point(3, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 433);
            this.panel1.TabIndex = 0;
            // 
            // CurrrentTableDataGridView
            // 
            this.CurrrentTableDataGridView.AllowUserToAddRows = false;
            this.CurrrentTableDataGridView.AllowUserToDeleteRows = false;
            this.CurrrentTableDataGridView.AllowUserToResizeRows = false;
            this.CurrrentTableDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CurrrentTableDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CurrrentTableDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.CurrrentTableDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CurrrentTableDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CurrrentTableDataGridView.ColumnHeadersHeight = 25;
            this.CurrrentTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderIDColumn,
            this.GuestCountColumn,
            this.SLColumn,
            this.TableTypeColumn,
            this.TableNumberColumn,
            this.CustomerNameColumn,
            this.ActionButtonColumn});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrrentTableDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.CurrrentTableDataGridView.Location = new System.Drawing.Point(22, 11);
            this.CurrrentTableDataGridView.Name = "CurrrentTableDataGridView";
            this.CurrrentTableDataGridView.RowHeadersVisible = false;
            this.CurrrentTableDataGridView.RowHeadersWidth = 4;
            this.CurrrentTableDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CurrrentTableDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CurrrentTableDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrrentTableDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.CurrrentTableDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.CurrrentTableDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.CurrrentTableDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CurrrentTableDataGridView.RowTemplate.Height = 20;
            this.CurrrentTableDataGridView.RowTemplate.ReadOnly = true;
            this.CurrrentTableDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrrentTableDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CurrrentTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CurrrentTableDataGridView.Size = new System.Drawing.Size(488, 392);
            this.CurrrentTableDataGridView.TabIndex = 7;
            // 
            // OrderIDColumn
            // 
            this.OrderIDColumn.HeaderText = "OrderID";
            this.OrderIDColumn.Name = "OrderIDColumn";
            this.OrderIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderIDColumn.Visible = false;
            // 
            // GuestCountColumn
            // 
            this.GuestCountColumn.HeaderText = "Guest";
            this.GuestCountColumn.Name = "GuestCountColumn";
            this.GuestCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GuestCountColumn.Visible = false;
            // 
            // SLColumn
            // 
            this.SLColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SLColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.SLColumn.HeaderText = "SL";
            this.SLColumn.Name = "SLColumn";
            this.SLColumn.ReadOnly = true;
            this.SLColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLColumn.Width = 40;
            // 
            // TableTypeColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableTypeColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.TableTypeColumn.HeaderText = "Table Type";
            this.TableTypeColumn.Name = "TableTypeColumn";
            this.TableTypeColumn.ReadOnly = true;
            this.TableTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TableNumberColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableNumberColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.TableNumberColumn.HeaderText = "Table Number";
            this.TableNumberColumn.Name = "TableNumberColumn";
            this.TableNumberColumn.ReadOnly = true;
            this.TableNumberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TableNumberColumn.Width = 80;
            // 
            // CustomerNameColumn
            // 
            this.CustomerNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerNameColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.CustomerNameColumn.HeaderText = "Customer Name";
            this.CustomerNameColumn.Name = "CustomerNameColumn";
            this.CustomerNameColumn.ReadOnly = true;
            this.CustomerNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ActionButtonColumn
            // 
            this.ActionButtonColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionButtonColumn.HeaderText = "Action";
            this.ActionButtonColumn.Name = "ActionButtonColumn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(550, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Table Number";
            // 
            // TableNumberTextBox
            // 
            this.TableNumberTextBox.BackColor = System.Drawing.Color.White;
            this.TableNumberTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TableNumberTextBox.Location = new System.Drawing.Point(553, 105);
            this.TableNumberTextBox.Name = "TableNumberTextBox";
            this.TableNumberTextBox.Size = new System.Drawing.Size(140, 20);
            this.TableNumberTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(550, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Customer Name";
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.BackColor = System.Drawing.Color.White;
            this.CustomerNameTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CustomerNameTextBox.Location = new System.Drawing.Point(553, 39);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(140, 20);
            this.CustomerNameTextBox.TabIndex = 9;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButton.BackgroundImage")));
            this.BackButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseDown")));
            this.BackButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseUp")));
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Arial", 10F);
            this.BackButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.BackButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.BackButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Back;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.Location = new System.Drawing.Point(27, 547);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(129, 50);
            this.BackButton.TabIndex = 13;
            this.BackButton.Text = "Back";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(41, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 22);
            this.panel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(-1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Tables";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CTransferTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BackButton);
            this.Name = "CTransferTableForm";
            this.ScreenTitle = "Tranfer Table";
            this.Text = "CTransferTable";
            this.Load += new System.EventHandler(this.CTransferTableForm_Load);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrrentTableDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TableNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CurrrentTableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ActionButtonColumn;
        private FunctionalButton BackButton;
    }
}