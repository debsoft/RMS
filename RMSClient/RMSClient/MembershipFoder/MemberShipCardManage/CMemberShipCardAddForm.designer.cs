namespace RMS.MemberShipCardManage
{
    partial class CMemberShipCardAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMemberShipCardAddForm));
            this.label3 = new System.Windows.Forms.Label();
            this.txtMembershipCardName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDiscountRate = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.txtDiscountPercentRate = new System.Windows.Forms.TextBox();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.FinishButton = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.keyboard1 = new RMSUI.keyboard();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbInActive = new System.Windows.Forms.RadioButton();
            this.rdbActive = new System.Windows.Forms.RadioButton();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(138, 61);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 301;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMembershipCardName
            // 
            this.txtMembershipCardName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMembershipCardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembershipCardName.ForeColor = System.Drawing.Color.Black;
            this.txtMembershipCardName.Location = new System.Drawing.Point(188, 58);
            this.txtMembershipCardName.Name = "txtMembershipCardName";
            this.txtMembershipCardName.Size = new System.Drawing.Size(342, 23);
            this.txtMembershipCardName.TabIndex = 300;
            this.txtMembershipCardName.Click += new System.EventHandler(this.Name_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(116, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 305;
            this.label13.Text = "Start Date";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(143, 88);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 16);
            this.lblType.TabIndex = 304;
            this.lblType.Text = "Type";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.White;
            this.lblCode.Location = new System.Drawing.Point(142, 170);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 16);
            this.lblCode.TabIndex = 312;
            this.lblCode.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.ForeColor = System.Drawing.Color.Black;
            this.txtCode.Location = new System.Drawing.Point(188, 167);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(317, 23);
            this.txtCode.TabIndex = 306;
            this.txtCode.Click += new System.EventHandler(this.HouseNo_Click);
            // 
            // lblDiscountRate
            // 
            this.lblDiscountRate.AutoSize = true;
            this.lblDiscountRate.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountRate.ForeColor = System.Drawing.Color.White;
            this.lblDiscountRate.Location = new System.Drawing.Point(74, 224);
            this.lblDiscountRate.Name = "lblDiscountRate";
            this.lblDiscountRate.Size = new System.Drawing.Size(109, 16);
            this.lblDiscountRate.TabIndex = 311;
            this.lblDiscountRate.Text = "Discount Percent";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.BackColor = System.Drawing.Color.Transparent;
            this.lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.ForeColor = System.Drawing.Color.White;
            this.lblPoint.Location = new System.Drawing.Point(145, 197);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(38, 16);
            this.lblPoint.TabIndex = 310;
            this.lblPoint.Text = "Point";
            // 
            // txtDiscountPercentRate
            // 
            this.txtDiscountPercentRate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDiscountPercentRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountPercentRate.ForeColor = System.Drawing.Color.Black;
            this.txtDiscountPercentRate.Location = new System.Drawing.Point(188, 221);
            this.txtDiscountPercentRate.Name = "txtDiscountPercentRate";
            this.txtDiscountPercentRate.Size = new System.Drawing.Size(150, 23);
            this.txtDiscountPercentRate.TabIndex = 309;
            this.txtDiscountPercentRate.Text = "0.00";
            this.txtDiscountPercentRate.Click += new System.EventHandler(this.Town_Click);
            // 
            // txtPoint
            // 
            this.txtPoint.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint.ForeColor = System.Drawing.Color.Black;
            this.txtPoint.Location = new System.Drawing.Point(188, 194);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(151, 23);
            this.txtPoint.TabIndex = 308;
            this.txtPoint.Text = "0.00";
            this.txtPoint.Click += new System.EventHandler(this.StreetName_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(188, 266);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(342, 23);
            this.txtDescription.TabIndex = 307;
            this.txtDescription.Click += new System.EventHandler(this.Phone_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(107, 270);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(76, 16);
            this.lblDescription.TabIndex = 316;
            this.lblDescription.Text = "Description";
            // 
            // FinishButton
            // 
            this.FinishButton.BackColor = System.Drawing.Color.Transparent;
            this.FinishButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FinishButton.BackgroundImage")));
            this.FinishButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("FinishButton.BgImageOnMouseDown")));
            this.FinishButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("FinishButton.BgImageOnMouseUp")));
            this.FinishButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FinishButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.FinishButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FinishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FinishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinishButton.Font = new System.Drawing.Font("Arial", 10F);
            this.FinishButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.FinishButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.FinishButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.FinishButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FinishButton.Location = new System.Drawing.Point(433, 559);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(120, 40);
            this.FinishButton.TabIndex = 62;
            this.FinishButton.Text = "Save";
            this.FinishButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FinishButton.UseVisualStyleBackColor = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelButton.BackgroundImage")));
            this.CancelButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseDown")));
            this.CancelButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseUp")));
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 10F);
            this.CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(570, 559);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 63;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnFindCustomer.BackgroundImage = global::RMS.Properties.Resources.search2;
            this.btnFindCustomer.FlatAppearance.BorderSize = 0;
            this.btnFindCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFindCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFindCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFindCustomer.Location = new System.Drawing.Point(531, 54);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(35, 29);
            this.btnFindCustomer.TabIndex = 327;
            this.btnFindCustomer.UseVisualStyleBackColor = false;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.Location = new System.Drawing.Point(25, 302);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(665, 248);
            this.keyboard1.TabIndex = 329;
            this.keyboard1.textBox = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(140, 250);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 332;
            this.label1.Text = "Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbInActive
            // 
            this.rdbInActive.AutoSize = true;
            this.rdbInActive.BackColor = System.Drawing.Color.Transparent;
            this.rdbInActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInActive.ForeColor = System.Drawing.Color.White;
            this.rdbInActive.Location = new System.Drawing.Point(253, 247);
            this.rdbInActive.Name = "rdbInActive";
            this.rdbInActive.Size = new System.Drawing.Size(71, 17);
            this.rdbInActive.TabIndex = 331;
            this.rdbInActive.Text = "Inactive";
            this.rdbInActive.UseVisualStyleBackColor = false;
            // 
            // rdbActive
            // 
            this.rdbActive.AutoSize = true;
            this.rdbActive.BackColor = System.Drawing.Color.Transparent;
            this.rdbActive.Checked = true;
            this.rdbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbActive.ForeColor = System.Drawing.Color.White;
            this.rdbActive.Location = new System.Drawing.Point(188, 248);
            this.rdbActive.Name = "rdbActive";
            this.rdbActive.Size = new System.Drawing.Size(61, 17);
            this.rdbActive.TabIndex = 330;
            this.rdbActive.TabStop = true;
            this.rdbActive.Text = "Active";
            this.rdbActive.UseVisualStyleBackColor = false;
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.ForeColor = System.Drawing.Color.Black;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Platinum",
            "Silver",
            "Gold",
            "Diamond"});
            this.cmbType.Location = new System.Drawing.Point(188, 85);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(154, 24);
            this.cmbType.TabIndex = 333;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "  dd - MMM - yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(188, 114);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 334;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.White;
            this.lblEndDate.Location = new System.Drawing.Point(316, 117);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(64, 16);
            this.lblEndDate.TabIndex = 335;
            this.lblEndDate.Text = "End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "  dd - MMM - yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(380, 115);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 336;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(149, 143);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitle.Size = new System.Drawing.Size(34, 16);
            this.lblTitle.TabIndex = 338;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(188, 140);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(316, 23);
            this.txtTitle.TabIndex = 337;
            this.txtTitle.Click += new System.EventHandler(this.txtTitle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(338, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 339;
            this.label2.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(338, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 340;
            this.label4.Text = "%";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 341;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // CMemberShipCardAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbInActive);
            this.Controls.Add(this.rdbActive);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.btnFindCustomer);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDiscountRate);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.txtDiscountPercentRate);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMembershipCardName);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "CMemberShipCardAddForm";
            this.ScreenTitle = "Customer Information ";
            this.Text = "CCustomerInfoForm";
            this.Activated += new System.EventHandler(this.CCustomerInfoForm_Activated);
            this.Load += new System.EventHandler(this.CCustomerInfoForm_Load);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.FinishButton, 0);
            this.Controls.SetChildIndex(this.txtMembershipCardName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.txtPoint, 0);
            this.Controls.SetChildIndex(this.txtDiscountPercentRate, 0);
            this.Controls.SetChildIndex(this.lblPoint, 0);
            this.Controls.SetChildIndex(this.lblDiscountRate, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.lblCode, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.btnFindCustomer, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.Controls.SetChildIndex(this.rdbActive, 0);
            this.Controls.SetChildIndex(this.rdbInActive, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbType, 0);
            this.Controls.SetChildIndex(this.dtpStartDate, 0);
            this.Controls.SetChildIndex(this.lblEndDate, 0);
            this.Controls.SetChildIndex(this.dtpEndDate, 0);
            this.Controls.SetChildIndex(this.txtTitle, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMembershipCardName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDiscountRate;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.TextBox txtDiscountPercentRate;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnFindCustomer;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton FinishButton;
        private RMSUI.FunctionalButton CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbInActive;
        private System.Windows.Forms.RadioButton rdbActive;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;

    }
}