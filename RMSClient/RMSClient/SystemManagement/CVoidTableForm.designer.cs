using RMSUI;
namespace RMS.SystemManagement
{
    partial class CVoidTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CVoidTableForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackButton = new RMSUI.FunctionalButton();
            this.VoidTableDataGridView = new RMSUI.SimpleGrid();
            this.SLColummn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OrderIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoidTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(56, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 22);
            this.panel2.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(256, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Tables";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 77);
            this.panel1.TabIndex = 21;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButton.BackgroundImage")));
            this.BackButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseDown")));
            this.BackButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseUp")));
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Arial", 10F);
            this.BackButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.BackButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.BackButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.Location = new System.Drawing.Point(273, 21);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(120, 40);
            this.BackButton.TabIndex = 19;
            this.BackButton.Text = "Close";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // VoidTableDataGridView
            // 
            this.VoidTableDataGridView.AllowUserToAddRows = false;
            this.VoidTableDataGridView.AllowUserToDeleteRows = false;
            this.VoidTableDataGridView.AllowUserToResizeColumns = false;
            this.VoidTableDataGridView.AllowUserToResizeRows = false;
            this.VoidTableDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.VoidTableDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VoidTableDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VoidTableDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.VoidTableDataGridView.ColumnHeadersHeight = 40;
            this.VoidTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.VoidTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLColummn,
            this.TableTypeColumn,
            this.TableNumberColumn,
            this.CustomerNameColumn,
            this.ActionButtonColumn,
            this.OrderIDColumn});
            this.VoidTableDataGridView.GridColor = System.Drawing.Color.Gray;
            this.VoidTableDataGridView.Location = new System.Drawing.Point(15, 14);
            this.VoidTableDataGridView.Name = "VoidTableDataGridView";
            this.VoidTableDataGridView.RowHeadersVisible = false;
            this.VoidTableDataGridView.RowTemplate.ReadOnly = true;
            this.VoidTableDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VoidTableDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VoidTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VoidTableDataGridView.ShowCellErrors = false;
            this.VoidTableDataGridView.Size = new System.Drawing.Size(661, 386);
            this.VoidTableDataGridView.TabIndex = 20;
            this.VoidTableDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VoidTableDataGridView_CellContentClick);
            // 
            // SLColummn
            // 
            this.SLColummn.HeaderText = "SL";
            this.SLColummn.Name = "SLColummn";
            this.SLColummn.ReadOnly = true;
            this.SLColummn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLColummn.Width = 50;
            // 
            // TableTypeColumn
            // 
            this.TableTypeColumn.HeaderText = "Table Type";
            this.TableTypeColumn.Name = "TableTypeColumn";
            this.TableTypeColumn.ReadOnly = true;
            this.TableTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TableTypeColumn.Width = 130;
            // 
            // TableNumberColumn
            // 
            this.TableNumberColumn.HeaderText = "Table Number";
            this.TableNumberColumn.Name = "TableNumberColumn";
            this.TableNumberColumn.ReadOnly = true;
            this.TableNumberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TableNumberColumn.Width = 130;
            // 
            // CustomerNameColumn
            // 
            this.CustomerNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerNameColumn.HeaderText = "Customer Name";
            this.CustomerNameColumn.Name = "CustomerNameColumn";
            this.CustomerNameColumn.ReadOnly = true;
            this.CustomerNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ActionButtonColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ActionButtonColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ActionButtonColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ActionButtonColumn.HeaderText = "Action";
            this.ActionButtonColumn.Name = "ActionButtonColumn";
            this.ActionButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionButtonColumn.Width = 132;
            // 
            // OrderIDColumn
            // 
            this.OrderIDColumn.HeaderText = "";
            this.OrderIDColumn.Name = "OrderIDColumn";
            this.OrderIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderIDColumn.Visible = false;
            // 
            // CVoidTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(689, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.VoidTableDataGridView);
            this.Name = "CVoidTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CVoidTable";
            this.Load += new System.EventHandler(this.CVoidTableForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VoidTableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleGrid VoidTableDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLColummn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ActionButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderIDColumn;
        private RMSUI.FunctionalButton BackButton;
        private System.Windows.Forms.Panel panel1;
    }
}