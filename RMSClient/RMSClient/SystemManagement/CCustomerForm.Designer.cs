namespace RMS.SystemManagement
{
    partial class CCustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCustomerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetMembershipCard = new RMSUI.FunctionalButton();
            this.ViewAllButton = new RMSUI.FunctionalButton();
            this.AddButton = new RMSUI.FunctionalButton();
            this.UpdateButton = new RMSUI.FunctionalButton();
            this.DeleteButton = new RMSUI.FunctionalButton();
            this.label1 = new System.Windows.Forms.Label();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new RMSUI.FunctionalButton();
            this.CustomerDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackButton = new RMSUI.FunctionalButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSetMembershipCard);
            this.panel1.Controls.Add(this.ViewAllButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PhoneTextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.NameTextBox);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.CustomerDataGridView);
            this.panel1.Location = new System.Drawing.Point(3, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 483);
            this.panel1.TabIndex = 1;
            // 
            // btnSetMembershipCard
            // 
            this.btnSetMembershipCard.BackColor = System.Drawing.Color.Transparent;
            this.btnSetMembershipCard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetMembershipCard.BackgroundImage")));
            this.btnSetMembershipCard.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSetMembershipCard.BgImageOnMouseDown")));
            this.btnSetMembershipCard.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSetMembershipCard.BgImageOnMouseUp")));
            this.btnSetMembershipCard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSetMembershipCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetMembershipCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetMembershipCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetMembershipCard.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSetMembershipCard.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSetMembershipCard.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSetMembershipCard.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSetMembershipCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetMembershipCard.Location = new System.Drawing.Point(192, 429);
            this.btnSetMembershipCard.Name = "btnSetMembershipCard";
            this.btnSetMembershipCard.Size = new System.Drawing.Size(130, 40);
            this.btnSetMembershipCard.TabIndex = 61;
            this.btnSetMembershipCard.Text = "Membership Card";
            this.btnSetMembershipCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetMembershipCard.UseVisualStyleBackColor = false;
            this.btnSetMembershipCard.Click += new System.EventHandler(this.btnSetMembershipCard_Click);
            // 
            // ViewAllButton
            // 
            this.ViewAllButton.BackColor = System.Drawing.Color.Transparent;
            this.ViewAllButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewAllButton.BackgroundImage")));
            this.ViewAllButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("ViewAllButton.BgImageOnMouseDown")));
            this.ViewAllButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("ViewAllButton.BgImageOnMouseUp")));
            this.ViewAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ViewAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ViewAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ViewAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewAllButton.Font = new System.Drawing.Font("Arial", 10F);
            this.ViewAllButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.ViewAllButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.ViewAllButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.ViewAllButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewAllButton.Location = new System.Drawing.Point(631, 9);
            this.ViewAllButton.Name = "ViewAllButton";
            this.ViewAllButton.Size = new System.Drawing.Size(120, 40);
            this.ViewAllButton.TabIndex = 3;
            this.ViewAllButton.Text = "View All";
            this.ViewAllButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ViewAllButton.UseVisualStyleBackColor = false;
            this.ViewAllButton.Click += new System.EventHandler(this.ViewAllButton_Click);
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
            this.AddButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddButton.Location = new System.Drawing.Point(64, 429);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 40);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
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
            this.UpdateButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.Location = new System.Drawing.Point(332, 429);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(120, 40);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "Update";
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
            this.DeleteButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.DeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.Location = new System.Drawing.Point(458, 429);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 40);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(260, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 60;
            this.label1.Text = "Phone";
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(313, 19);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(150, 20);
            this.PhoneTextBox.TabIndex = 1;
            this.PhoneTextBox.Click += new System.EventHandler(this.PhoneTextBox_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(39, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 58;
            this.label8.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(90, 20);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(150, 20);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.Click += new System.EventHandler(this.NameTextBox_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchButton.BackgroundImage")));
            this.SearchButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("SearchButton.BgImageOnMouseDown")));
            this.SearchButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("SearchButton.BgImageOnMouseUp")));
            this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Arial", 10F);
            this.SearchButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.SearchButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.SearchButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.SearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchButton.Location = new System.Drawing.Point(504, 8);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(120, 40);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // CustomerDataGridView
            // 
            this.CustomerDataGridView.AllowUserToAddRows = false;
            this.CustomerDataGridView.AllowUserToDeleteRows = false;
            this.CustomerDataGridView.AllowUserToResizeRows = false;
            this.CustomerDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CustomerDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CustomerDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CustomerDataGridView.ColumnHeadersHeight = 25;
            this.CustomerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.PhoneColumn,
            this.AddressColumn,
            this.PostalCodeColumn,
            this.PhoneNumber,
            this.CountryColumn,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerDataGridView.Location = new System.Drawing.Point(43, 64);
            this.CustomerDataGridView.MultiSelect = false;
            this.CustomerDataGridView.Name = "CustomerDataGridView";
            this.CustomerDataGridView.ReadOnly = true;
            this.CustomerDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.CustomerDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.CustomerDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CustomerDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CustomerDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.CustomerDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.CustomerDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.CustomerDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDataGridView.RowTemplate.Height = 20;
            this.CustomerDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerDataGridView.Size = new System.Drawing.Size(708, 354);
            this.CustomerDataGridView.TabIndex = 4;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.HeaderText = "Floor/Apartment No";
            this.PhoneColumn.Name = "PhoneColumn";
            this.PhoneColumn.ReadOnly = true;
            this.PhoneColumn.Visible = false;
            // 
            // AddressColumn
            // 
            this.AddressColumn.HeaderText = "Building Name";
            this.AddressColumn.Name = "AddressColumn";
            this.AddressColumn.ReadOnly = true;
            this.AddressColumn.Visible = false;
            // 
            // PostalCodeColumn
            // 
            this.PostalCodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PostalCodeColumn.HeaderText = "House No";
            this.PostalCodeColumn.Name = "PostalCodeColumn";
            this.PostalCodeColumn.ReadOnly = true;
            this.PostalCodeColumn.Width = 80;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PhoneNumber.HeaderText = "Phone";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Width = 63;
            // 
            // CountryColumn
            // 
            this.CountryColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CountryColumn.HeaderText = "Postal Code";
            this.CountryColumn.Name = "CountryColumn";
            this.CountryColumn.ReadOnly = true;
            this.CountryColumn.Width = 89;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "Town";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 59;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Country";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 68;
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
            this.BackButton.Location = new System.Drawing.Point(48, 561);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(121, 40);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = " Back";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(802, 634);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BackButton);
            this.Name = "CCustomerForm";
            this.ScreenTitle = "Customer";
            this.VisibleChanged += new System.EventHandler(this.CCustomerForm_VisibleChanged);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView CustomerDataGridView;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private RMSUI.FunctionalButton BackButton;
        private RMSUI.FunctionalButton SearchButton;
        private RMSUI.FunctionalButton ViewAllButton;
        private RMSUI.FunctionalButton AddButton;
        private RMSUI.FunctionalButton UpdateButton;
        private RMSUI.FunctionalButton DeleteButton;
        private RMSUI.FunctionalButton btnSetMembershipCard;

    }
}