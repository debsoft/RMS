namespace RMS.MemberShipCardNoManage
{
    partial class CMemberShipAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMemberShipAddForm));
            this.FinishButton = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.keyboard1 = new RMSUI.keyboard();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnSearchByPhone = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDiscountRate = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.txtDiscountPercentRate = new System.Windows.Forms.TextBox();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMembershipCardName = new System.Windows.Forms.TextBox();
            this.btnMembershipCardName = new System.Windows.Forms.Button();
            this.btnMembershipCardCode = new System.Windows.Forms.Button();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbInActive = new System.Windows.Forms.RadioButton();
            this.rdbActive = new System.Windows.Forms.RadioButton();
            this.btnSelect = new RMSUI.FunctionalButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.FinishButton.Location = new System.Drawing.Point(548, 611);
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
            this.CancelButton.Location = new System.Drawing.Point(676, 611);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 63;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.Location = new System.Drawing.Point(64, 367);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(665, 239);
            this.keyboard1.TabIndex = 329;
            this.keyboard1.textBox = null;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(113, 79);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCustomerName.Size = new System.Drawing.Size(105, 16);
            this.lblCustomerName.TabIndex = 340;
            this.lblCustomerName.Text = "Customer Name";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerName.Location = new System.Drawing.Point(219, 76);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(325, 23);
            this.txtCustomerName.TabIndex = 339;
            this.txtCustomerName.Click += new System.EventHandler(this.txtCustomerName_Click);
            // 
            // btnSearchByPhone
            // 
            this.btnSearchByPhone.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchByPhone.BackgroundImage = global::RMS.Properties.Resources.search3;
            this.btnSearchByPhone.FlatAppearance.BorderSize = 0;
            this.btnSearchByPhone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearchByPhone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearchByPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByPhone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearchByPhone.Location = new System.Drawing.Point(544, 105);
            this.btnSearchByPhone.Name = "btnSearchByPhone";
            this.btnSearchByPhone.Size = new System.Drawing.Size(35, 29);
            this.btnSearchByPhone.TabIndex = 344;
            this.btnSearchByPhone.UseVisualStyleBackColor = false;
            this.btnSearchByPhone.Click += new System.EventHandler(this.btnSearchByPhone_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(171, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 343;
            this.label4.Text = "Phone";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Location = new System.Drawing.Point(219, 104);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(325, 23);
            this.txtPhoneNumber.TabIndex = 342;
            this.txtPhoneNumber.Click += new System.EventHandler(this.txtPhoneNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(134, 53);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 349;
            this.label1.Text = "Customer Info";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 136);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 350;
            this.label2.Text = "Membership Card Info";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(181, 242);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitle.Size = new System.Drawing.Size(34, 16);
            this.lblTitle.TabIndex = 366;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(219, 239);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(325, 23);
            this.txtTitle.TabIndex = 365;
            this.txtTitle.Click += new System.EventHandler(this.txtTitle_Click_1);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "  dd - MMM - yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(411, 216);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 364;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.White;
            this.lblEndDate.Location = new System.Drawing.Point(347, 216);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(64, 16);
            this.lblEndDate.TabIndex = 363;
            this.lblEndDate.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "  dd - MMM - yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(219, 213);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 362;
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
            this.cmbType.Location = new System.Drawing.Point(219, 184);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(154, 24);
            this.cmbType.TabIndex = 361;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.White;
            this.lblCode.Location = new System.Drawing.Point(174, 269);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 16);
            this.lblCode.TabIndex = 360;
            this.lblCode.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.ForeColor = System.Drawing.Color.Black;
            this.txtCode.Location = new System.Drawing.Point(219, 266);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(325, 23);
            this.txtCode.TabIndex = 355;
            this.txtCode.Click += new System.EventHandler(this.txtCode_Click);
            // 
            // lblDiscountRate
            // 
            this.lblDiscountRate.AutoSize = true;
            this.lblDiscountRate.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountRate.ForeColor = System.Drawing.Color.White;
            this.lblDiscountRate.Location = new System.Drawing.Point(106, 323);
            this.lblDiscountRate.Name = "lblDiscountRate";
            this.lblDiscountRate.Size = new System.Drawing.Size(109, 16);
            this.lblDiscountRate.TabIndex = 359;
            this.lblDiscountRate.Text = "Discount Percent";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.BackColor = System.Drawing.Color.Transparent;
            this.lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.ForeColor = System.Drawing.Color.White;
            this.lblPoint.Location = new System.Drawing.Point(177, 296);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(38, 16);
            this.lblPoint.TabIndex = 358;
            this.lblPoint.Text = "Point";
            // 
            // txtDiscountPercentRate
            // 
            this.txtDiscountPercentRate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDiscountPercentRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountPercentRate.ForeColor = System.Drawing.Color.Black;
            this.txtDiscountPercentRate.Location = new System.Drawing.Point(219, 319);
            this.txtDiscountPercentRate.Name = "txtDiscountPercentRate";
            this.txtDiscountPercentRate.Size = new System.Drawing.Size(150, 23);
            this.txtDiscountPercentRate.TabIndex = 357;
            this.txtDiscountPercentRate.Text = "0.00";
            this.txtDiscountPercentRate.Click += new System.EventHandler(this.txtDiscountPercentRate_Click);
            // 
            // txtPoint
            // 
            this.txtPoint.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint.ForeColor = System.Drawing.Color.Black;
            this.txtPoint.Location = new System.Drawing.Point(219, 292);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(151, 23);
            this.txtPoint.TabIndex = 356;
            this.txtPoint.Text = "0.00";
            this.txtPoint.Click += new System.EventHandler(this.txtPoint_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(148, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 354;
            this.label13.Text = "Start Date";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(175, 187);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 16);
            this.lblType.TabIndex = 353;
            this.lblType.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(170, 160);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 352;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMembershipCardName
            // 
            this.txtMembershipCardName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMembershipCardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembershipCardName.ForeColor = System.Drawing.Color.Black;
            this.txtMembershipCardName.Location = new System.Drawing.Point(219, 157);
            this.txtMembershipCardName.Name = "txtMembershipCardName";
            this.txtMembershipCardName.Size = new System.Drawing.Size(325, 23);
            this.txtMembershipCardName.TabIndex = 351;
            this.txtMembershipCardName.Click += new System.EventHandler(this.txtMembershipCardName_Click);
            // 
            // btnMembershipCardName
            // 
            this.btnMembershipCardName.BackColor = System.Drawing.Color.Transparent;
            this.btnMembershipCardName.BackgroundImage = global::RMS.Properties.Resources.search3;
            this.btnMembershipCardName.FlatAppearance.BorderSize = 0;
            this.btnMembershipCardName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMembershipCardName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMembershipCardName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembershipCardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembershipCardName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMembershipCardName.Location = new System.Drawing.Point(544, 154);
            this.btnMembershipCardName.Name = "btnMembershipCardName";
            this.btnMembershipCardName.Size = new System.Drawing.Size(35, 29);
            this.btnMembershipCardName.TabIndex = 367;
            this.btnMembershipCardName.UseVisualStyleBackColor = false;
            this.btnMembershipCardName.Click += new System.EventHandler(this.btnMembershipCardName_Click);
            // 
            // btnMembershipCardCode
            // 
            this.btnMembershipCardCode.BackColor = System.Drawing.Color.Transparent;
            this.btnMembershipCardCode.BackgroundImage = global::RMS.Properties.Resources.search3;
            this.btnMembershipCardCode.FlatAppearance.BorderSize = 0;
            this.btnMembershipCardCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMembershipCardCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMembershipCardCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembershipCardCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembershipCardCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMembershipCardCode.Location = new System.Drawing.Point(544, 263);
            this.btnMembershipCardCode.Name = "btnMembershipCardCode";
            this.btnMembershipCardCode.Size = new System.Drawing.Size(35, 29);
            this.btnMembershipCardCode.TabIndex = 368;
            this.btnMembershipCardCode.UseVisualStyleBackColor = false;
            this.btnMembershipCardCode.Click += new System.EventHandler(this.btnMembershipCardCode_Click);
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
            this.btnFindCustomer.Location = new System.Drawing.Point(544, 73);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(35, 29);
            this.btnFindCustomer.TabIndex = 369;
            this.btnFindCustomer.UseVisualStyleBackColor = false;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(172, 349);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 372;
            this.label5.Text = "Status";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbInActive
            // 
            this.rdbInActive.AutoSize = true;
            this.rdbInActive.BackColor = System.Drawing.Color.Transparent;
            this.rdbInActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInActive.ForeColor = System.Drawing.Color.White;
            this.rdbInActive.Location = new System.Drawing.Point(285, 346);
            this.rdbInActive.Name = "rdbInActive";
            this.rdbInActive.Size = new System.Drawing.Size(71, 17);
            this.rdbInActive.TabIndex = 371;
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
            this.rdbActive.Location = new System.Drawing.Point(220, 347);
            this.rdbActive.Name = "rdbActive";
            this.rdbActive.Size = new System.Drawing.Size(61, 17);
            this.rdbActive.TabIndex = 370;
            this.rdbActive.TabStop = true;
            this.rdbActive.Text = "Active";
            this.rdbActive.UseVisualStyleBackColor = false;
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
            this.btnSelect.Location = new System.Drawing.Point(422, 611);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 40);
            this.btnSelect.TabIndex = 373;
            this.btnSelect.Text = "OK";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(371, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 16);
            this.label6.TabIndex = 374;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(372, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 16);
            this.label7.TabIndex = 375;
            this.label7.Text = "%";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 376;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // CMemberShipAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 656);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdbInActive);
            this.Controls.Add(this.rdbActive);
            this.Controls.Add(this.btnFindCustomer);
            this.Controls.Add(this.btnMembershipCardCode);
            this.Controls.Add(this.btnMembershipCardName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDiscountRate);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.txtDiscountPercentRate);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMembershipCardName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchByPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "CMemberShipAddForm";
            this.ScreenTitle = "Customer Information ";
            this.Text = "CCustomerInfoForm";
            this.Activated += new System.EventHandler(this.CCustomerInfoForm_Activated);
            this.Load += new System.EventHandler(this.CCustomerInfoForm_Load);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.FinishButton, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.Controls.SetChildIndex(this.txtCustomerName, 0);
            this.Controls.SetChildIndex(this.lblCustomerName, 0);
            this.Controls.SetChildIndex(this.txtPhoneNumber, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnSearchByPhone, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtMembershipCardName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtPoint, 0);
            this.Controls.SetChildIndex(this.txtDiscountPercentRate, 0);
            this.Controls.SetChildIndex(this.lblPoint, 0);
            this.Controls.SetChildIndex(this.lblDiscountRate, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.lblCode, 0);
            this.Controls.SetChildIndex(this.cmbType, 0);
            this.Controls.SetChildIndex(this.dtpStartDate, 0);
            this.Controls.SetChildIndex(this.lblEndDate, 0);
            this.Controls.SetChildIndex(this.dtpEndDate, 0);
            this.Controls.SetChildIndex(this.txtTitle, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnMembershipCardName, 0);
            this.Controls.SetChildIndex(this.btnMembershipCardCode, 0);
            this.Controls.SetChildIndex(this.btnFindCustomer, 0);
            this.Controls.SetChildIndex(this.rdbActive, 0);
            this.Controls.SetChildIndex(this.rdbInActive, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton CancelButton;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDiscountRate;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.TextBox txtDiscountPercentRate;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMembershipCardName;
        private System.Windows.Forms.Button btnMembershipCardName;
        private System.Windows.Forms.Button btnMembershipCardCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbInActive;
        private System.Windows.Forms.RadioButton rdbActive;
        public RMSUI.FunctionalButton FinishButton;
        public RMSUI.FunctionalButton btnSelect;
        public System.Windows.Forms.Button btnSearchByPhone;
        public System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;

    }
}