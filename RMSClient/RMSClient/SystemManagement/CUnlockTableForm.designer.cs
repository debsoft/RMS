using RMSUI;
namespace RMS.SystemManagement
{
    partial class CUnlockTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CUnlockTableForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new RMSUI.FunctionalButton();
            this.UnlockTableDataGridView = new RMSUI.SimpleGrid();
            this.SLColummn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OrderIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnlockTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(79, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 22);
            this.panel2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(-4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Tables";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 72);
            this.panel1.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("button1.BgImageOnMouseDown")));
            this.button1.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("button1.BgImageOnMouseUp")));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10F);
            this.button1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.button1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.button1.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(241, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 40);
            this.button1.TabIndex = 19;
            this.button1.Text = "Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UnlockTableDataGridView
            // 
            this.UnlockTableDataGridView.AllowUserToAddRows = false;
            this.UnlockTableDataGridView.AllowUserToDeleteRows = false;
            this.UnlockTableDataGridView.AllowUserToResizeRows = false;
            this.UnlockTableDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.UnlockTableDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UnlockTableDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UnlockTableDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UnlockTableDataGridView.ColumnHeadersHeight = 40;
            this.UnlockTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UnlockTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLColummn,
            this.TableTypeColumn,
            this.TableNumberColumn,
            this.CustomerNameColumn,
            this.ActionButtonColumn,
            this.OrderIDColumn});
            this.UnlockTableDataGridView.GridColor = System.Drawing.Color.Gray;
            this.UnlockTableDataGridView.Location = new System.Drawing.Point(10, 11);
            this.UnlockTableDataGridView.Name = "UnlockTableDataGridView";
            this.UnlockTableDataGridView.RowHeadersVisible = false;
            this.UnlockTableDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnlockTableDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UnlockTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UnlockTableDataGridView.Size = new System.Drawing.Size(633, 428);
            this.UnlockTableDataGridView.TabIndex = 20;
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
            this.ActionButtonColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ActionButtonColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ActionButtonColumn.HeaderText = "Action";
            this.ActionButtonColumn.Name = "ActionButtonColumn";
            this.ActionButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OrderIDColumn
            // 
            this.OrderIDColumn.HeaderText = "";
            this.OrderIDColumn.Name = "OrderIDColumn";
            this.OrderIDColumn.Visible = false;
            // 
            // CUnlockTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(655, 520);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UnlockTableDataGridView);
            this.Name = "CUnlockTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlock Order ";
            this.Load += new System.EventHandler(this.CUnlockTableForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UnlockTableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleGrid UnlockTableDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private RMSUI.FunctionalButton button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLColummn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ActionButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderIDColumn;

    }
}