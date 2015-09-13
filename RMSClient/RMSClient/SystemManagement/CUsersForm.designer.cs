using RMSUI;

namespace RMS.SystemManagement
{
    partial class CUsersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CUsersForm));
            this.UserDataGridView = new System.Windows.Forms.DataGridView();
            this.UserIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new RMSUI.FunctionalButton();
            this.AddButton = new RMSUI.FunctionalButton();
            this.UpdateButton = new RMSUI.FunctionalButton();
            this.DeleteButton = new RMSUI.FunctionalButton();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserDataGridView
            // 
            this.UserDataGridView.AllowUserToAddRows = false;
            this.UserDataGridView.AllowUserToDeleteRows = false;
            this.UserDataGridView.AllowUserToResizeRows = false;
            this.UserDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.UserDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.UserDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UserDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UserDataGridView.ColumnHeadersHeight = 25;
            this.UserDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserIDColumn,
            this.SLColumn,
            this.UserNameColumn,
            this.UserTypeColumn,
            this.StatusColumn,
            this.GenderColumn});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.UserDataGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.UserDataGridView.Location = new System.Drawing.Point(70, 73);
            this.UserDataGridView.Name = "UserDataGridView";
            this.UserDataGridView.ReadOnly = true;
            this.UserDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.UserDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.UserDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UserDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.UserDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.UserDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.UserDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserDataGridView.RowTemplate.Height = 20;
            this.UserDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UserDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserDataGridView.Size = new System.Drawing.Size(660, 443);
            this.UserDataGridView.TabIndex = 66;
            // 
            // UserIDColumn
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserIDColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.UserIDColumn.HeaderText = "ID";
            this.UserIDColumn.Name = "UserIDColumn";
            this.UserIDColumn.ReadOnly = true;
            this.UserIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserIDColumn.Visible = false;
            // 
            // SLColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SLColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.SLColumn.HeaderText = "SL";
            this.SLColumn.Name = "SLColumn";
            this.SLColumn.ReadOnly = true;
            this.SLColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLColumn.Width = 40;
            // 
            // UserNameColumn
            // 
            this.UserNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserNameColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.UserNameColumn.HeaderText = "User Name";
            this.UserNameColumn.Name = "UserNameColumn";
            this.UserNameColumn.ReadOnly = true;
            this.UserNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserTypeColumn
            // 
            this.UserTypeColumn.HeaderText = "User Type";
            this.UserTypeColumn.Name = "UserTypeColumn";
            this.UserTypeColumn.ReadOnly = true;
            this.UserTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserTypeColumn.Width = 140;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StatusColumn.Width = 140;
            // 
            // GenderColumn
            // 
            this.GenderColumn.HeaderText = "Gender";
            this.GenderColumn.Name = "GenderColumn";
            this.GenderColumn.ReadOnly = true;
            this.GenderColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GenderColumn.Width = 120;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(71, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 22);
            this.panel3.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(297, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Users";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.White;
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
            this.BackButton.Location = new System.Drawing.Point(70, 615);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(140, 40);
            this.BackButton.TabIndex = 16;
            this.BackButton.Text = "    Back";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
            this.AddButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("AddButton.BgImageOnMouseDown")));
            this.AddButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("AddButton.BgImageOnMouseUp")));
            this.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Arial", 10F);
            this.AddButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.AddButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.AddButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddButton.Location = new System.Drawing.Point(206, 522);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 40);
            this.AddButton.TabIndex = 69;
            this.AddButton.Text = "Add";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpdateButton.BackgroundImage")));
            this.UpdateButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("UpdateButton.BgImageOnMouseDown")));
            this.UpdateButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("UpdateButton.BgImageOnMouseUp")));
            this.UpdateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.UpdateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Arial", 10F);
            this.UpdateButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.UpdateButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.UpdateButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.Location = new System.Drawing.Point(334, 522);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(120, 40);
            this.UpdateButton.TabIndex = 68;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
            this.DeleteButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BgImageOnMouseDown")));
            this.DeleteButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BgImageOnMouseUp")));
            this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Arial", 10F);
            this.DeleteButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.DeleteButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.DeleteButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.DeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.Location = new System.Drawing.Point(460, 522);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 40);
            this.DeleteButton.TabIndex = 67;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(837, 680);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.UserDataGridView);
            this.Controls.Add(this.BackButton);
            this.Name = "CUsersForm";
            this.Activated += new System.EventHandler(this.CUsersForm_Activated);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.UserDataGridView, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            this.Controls.SetChildIndex(this.UpdateButton, 0);
            this.Controls.SetChildIndex(this.AddButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UserDataGridView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderColumn;
        private FunctionalButton BackButton;
        private FunctionalButton AddButton;
        private FunctionalButton UpdateButton;
        private FunctionalButton DeleteButton;
    }
}