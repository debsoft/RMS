namespace RMS.MemberShipCardNoManage
{
    partial class CMemberShipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMemberShipForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new RMSUI.FunctionalButton();
            this.ViewAllButton = new RMSUI.FunctionalButton();
            this.AddButton = new RMSUI.FunctionalButton();
            this.UpdateButton = new RMSUI.FunctionalButton();
            this.DeleteButton = new RMSUI.FunctionalButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SearchButton = new RMSUI.FunctionalButton();
            this.dgvMembership = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mebershipCardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipCardCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipCardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipCardTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountPercentRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackButton = new RMSUI.FunctionalButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembership)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.ViewAllButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.dgvMembership);
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 600);
            this.panel1.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelect.BackgroundImage")));
            this.btnSelect.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSelect.BgImageOnMouseDown")));
            this.btnSelect.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSelect.BgImageOnMouseUp")));
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSelect.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSelect.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSelect.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSelect.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(663, 516);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 40);
            this.btnSelect.TabIndex = 62;
            this.btnSelect.Text = "OK";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ViewAllButton
            // 
            this.ViewAllButton.BackColor = System.Drawing.Color.Transparent;
            this.ViewAllButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewAllButton.BackgroundImage")));
            this.ViewAllButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("ViewAllButton.BgImageOnMouseDown")));
            this.ViewAllButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("ViewAllButton.BgImageOnMouseUp")));
            this.ViewAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ViewAllButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
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
            this.AddButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Arial", 10F);
            this.AddButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.AddButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.AddButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddButton.Location = new System.Drawing.Point(411, 470);
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
            this.UpdateButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Arial", 10F);
            this.UpdateButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.UpdateButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.UpdateButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.Location = new System.Drawing.Point(537, 470);
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
            this.DeleteButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Arial", 10F);
            this.DeleteButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.DeleteButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.DeleteButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.DeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.Location = new System.Drawing.Point(663, 470);
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
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 60;
            this.label1.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(313, 19);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.Click += new System.EventHandler(this.PhoneTextBox_Click);
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Click += new System.EventHandler(this.NameTextBox_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchButton.BackgroundImage")));
            this.SearchButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("SearchButton.BgImageOnMouseDown")));
            this.SearchButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("SearchButton.BgImageOnMouseUp")));
            this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SearchButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
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
            // dgvMembership
            // 
            this.dgvMembership.AllowUserToAddRows = false;
            this.dgvMembership.AllowUserToDeleteRows = false;
            this.dgvMembership.AllowUserToResizeRows = false;
            this.dgvMembership.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMembership.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMembership.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMembership.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMembership.ColumnHeadersHeight = 25;
            this.dgvMembership.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.customerID,
            this.customerName,
            this.customerPhone,
            this.membershipCardType,
            this.mebershipCardID,
            this.membershipCardCode,
            this.membershipCardName,
            this.membershipCardTitle,
            this.point,
            this.discountPercentRate,
            this.issueDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembership.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMembership.Location = new System.Drawing.Point(9, 59);
            this.dgvMembership.MultiSelect = false;
            this.dgvMembership.Name = "dgvMembership";
            this.dgvMembership.ReadOnly = true;
            this.dgvMembership.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMembership.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMembership.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMembership.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMembership.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMembership.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvMembership.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvMembership.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMembership.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembership.RowTemplate.Height = 20;
            this.dgvMembership.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMembership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembership.Size = new System.Drawing.Size(775, 393);
            this.dgvMembership.TabIndex = 4;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // customerID
            // 
            this.customerID.DataPropertyName = "customerID";
            this.customerID.HeaderText = "Customer ID";
            this.customerID.Name = "customerID";
            this.customerID.ReadOnly = true;
            // 
            // customerName
            // 
            this.customerName.DataPropertyName = "customerName";
            this.customerName.HeaderText = "Customer Name";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // customerPhone
            // 
            this.customerPhone.DataPropertyName = "customerPhone";
            this.customerPhone.HeaderText = "Customer Phone";
            this.customerPhone.Name = "customerPhone";
            this.customerPhone.ReadOnly = true;
            // 
            // membershipCardType
            // 
            this.membershipCardType.DataPropertyName = "membershipCardType";
            this.membershipCardType.HeaderText = "Membership Card Type";
            this.membershipCardType.Name = "membershipCardType";
            this.membershipCardType.ReadOnly = true;
            // 
            // mebershipCardID
            // 
            this.mebershipCardID.DataPropertyName = "mebershipCardID";
            this.mebershipCardID.HeaderText = "Mebership Card ID";
            this.mebershipCardID.Name = "mebershipCardID";
            this.mebershipCardID.ReadOnly = true;
            // 
            // membershipCardCode
            // 
            this.membershipCardCode.DataPropertyName = "membershipCardCode";
            this.membershipCardCode.HeaderText = "Membership Card Code";
            this.membershipCardCode.Name = "membershipCardCode";
            this.membershipCardCode.ReadOnly = true;
            // 
            // membershipCardName
            // 
            this.membershipCardName.DataPropertyName = "membershipCardName";
            this.membershipCardName.HeaderText = "Membership Card Name";
            this.membershipCardName.Name = "membershipCardName";
            this.membershipCardName.ReadOnly = true;
            // 
            // membershipCardTitle
            // 
            this.membershipCardTitle.DataPropertyName = "membershipCardTitle";
            this.membershipCardTitle.HeaderText = "Membership Card Title";
            this.membershipCardTitle.Name = "membershipCardTitle";
            this.membershipCardTitle.ReadOnly = true;
            // 
            // point
            // 
            this.point.DataPropertyName = "point";
            this.point.HeaderText = "Point";
            this.point.Name = "point";
            this.point.ReadOnly = true;
            // 
            // discountPercentRate
            // 
            this.discountPercentRate.DataPropertyName = "discountPercentRate";
            this.discountPercentRate.HeaderText = "Discount Percent";
            this.discountPercentRate.Name = "discountPercentRate";
            this.discountPercentRate.ReadOnly = true;
            // 
            // issueDate
            // 
            this.issueDate.DataPropertyName = "issueDate";
            this.issueDate.HeaderText = "Issue Date";
            this.issueDate.Name = "issueDate";
            this.issueDate.ReadOnly = true;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButton.BackgroundImage")));
            this.BackButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseDown")));
            this.BackButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseUp")));
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Arial", 10F);
            this.BackButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.BackButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.BackButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Back;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.Location = new System.Drawing.Point(45, 470);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(121, 40);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = " Back";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(0, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 309;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(5, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 40);
            this.button2.TabIndex = 342;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Location = new System.Drawing.Point(-1, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 40);
            this.button3.TabIndex = 342;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.Location = new System.Drawing.Point(0, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 40);
            this.button4.TabIndex = 342;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.Location = new System.Drawing.Point(-12, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 40);
            this.button5.TabIndex = 342;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.Location = new System.Drawing.Point(28, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 40);
            this.button6.TabIndex = 342;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Black;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.Location = new System.Drawing.Point(28, -3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 40);
            this.button7.TabIndex = 342;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Black;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.Location = new System.Drawing.Point(-1, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 40);
            this.button8.TabIndex = 342;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Black;
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.Location = new System.Drawing.Point(0, -3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 40);
            this.button9.TabIndex = 342;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Black;
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.Location = new System.Drawing.Point(6, 6);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(140, 40);
            this.button10.TabIndex = 342;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // CMemberShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(802, 600);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.panel1);
            this.Name = "CMemberShipForm";
            this.ScreenTitle = "Customer";
            this.VisibleChanged += new System.EventHandler(this.CCustomerForm_VisibleChanged);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.button10, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembership)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMembership;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private RMSUI.FunctionalButton BackButton;
        private RMSUI.FunctionalButton SearchButton;
        private RMSUI.FunctionalButton ViewAllButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn mebershipCardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipCardCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipCardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipCardTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn point;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountPercentRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn issueDate;
        public RMSUI.FunctionalButton btnSelect;
        public RMSUI.FunctionalButton AddButton;
        public RMSUI.FunctionalButton UpdateButton;
        public RMSUI.FunctionalButton DeleteButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;

    }
}