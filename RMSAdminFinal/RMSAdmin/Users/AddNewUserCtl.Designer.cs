namespace RMSAdmin
{
    partial class AddNewUserCtl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewUserCtl));
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoInActive = new System.Windows.Forms.RadioButton();
            this.chkOpenDrawer = new System.Windows.Forms.CheckBox();
            this.chkUsers = new System.Windows.Forms.CheckBox();
            this.chkUpdateItems = new System.Windows.Forms.CheckBox();
            this.chkExitRms = new System.Windows.Forms.CheckBox();
            this.chkBooking = new System.Windows.Forms.CheckBox();
            this.chkUnlockTable = new System.Windows.Forms.CheckBox();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.chkTransferTable = new System.Windows.Forms.CheckBox();
            this.chkVoidTable = new System.Windows.Forms.CheckBox();
            this.chkTillReport = new System.Windows.Forms.CheckBox();
            this.chkDeposit = new System.Windows.Forms.CheckBox();
            this.chkViewReport = new System.Windows.Forms.CheckBox();
            this.chkLogRegister = new System.Windows.Forms.CheckBox();
            this.chkReviewTrans = new System.Windows.Forms.CheckBox();
            this.chkMergeTable = new System.Windows.Forms.CheckBox();
            this.chkRemoveItems = new System.Windows.Forms.CheckBox();
            this.lblSaveStatus = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkSettings = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkRmsAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "User Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(37, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "User Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(263, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Sex";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(42, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Black;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(99, 30);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Black;
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(99, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // cmbUserType
            // 
            this.cmbUserType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbUserType.DisplayMember = "Display";
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.ForeColor = System.Drawing.Color.White;
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(99, 97);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(121, 21);
            this.cmbUserType.TabIndex = 2;
            this.cmbUserType.ValueMember = "Value";
            this.cmbUserType.DropDown += new System.EventHandler(this.cmbUserType_DropDown);
            // 
            // cmbSex
            // 
            this.cmbSex.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.ForeColor = System.Drawing.Color.White;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbSex.Location = new System.Drawing.Point(304, 97);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(121, 21);
            this.cmbSex.TabIndex = 3;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.ForeColor = System.Drawing.Color.White;
            this.rdoActive.Location = new System.Drawing.Point(99, 137);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(55, 17);
            this.rdoActive.TabIndex = 4;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // rdoInActive
            // 
            this.rdoInActive.AutoSize = true;
            this.rdoInActive.ForeColor = System.Drawing.Color.White;
            this.rdoInActive.Location = new System.Drawing.Point(203, 137);
            this.rdoInActive.Name = "rdoInActive";
            this.rdoInActive.Size = new System.Drawing.Size(63, 17);
            this.rdoInActive.TabIndex = 5;
            this.rdoInActive.TabStop = true;
            this.rdoInActive.Text = "Inactive";
            this.rdoInActive.UseVisualStyleBackColor = true;
            // 
            // chkOpenDrawer
            // 
            this.chkOpenDrawer.AutoSize = true;
            this.chkOpenDrawer.ForeColor = System.Drawing.Color.White;
            this.chkOpenDrawer.Location = new System.Drawing.Point(34, 188);
            this.chkOpenDrawer.Name = "chkOpenDrawer";
            this.chkOpenDrawer.Size = new System.Drawing.Size(89, 17);
            this.chkOpenDrawer.TabIndex = 6;
            this.chkOpenDrawer.Text = "Open Drawer";
            this.chkOpenDrawer.UseVisualStyleBackColor = true;
            // 
            // chkUsers
            // 
            this.chkUsers.AutoSize = true;
            this.chkUsers.ForeColor = System.Drawing.Color.White;
            this.chkUsers.Location = new System.Drawing.Point(278, 246);
            this.chkUsers.Name = "chkUsers";
            this.chkUsers.Size = new System.Drawing.Size(53, 17);
            this.chkUsers.TabIndex = 18;
            this.chkUsers.Text = "Users";
            this.chkUsers.UseVisualStyleBackColor = true;
            // 
            // chkUpdateItems
            // 
            this.chkUpdateItems.AutoSize = true;
            this.chkUpdateItems.ForeColor = System.Drawing.Color.White;
            this.chkUpdateItems.Location = new System.Drawing.Point(513, 220);
            this.chkUpdateItems.Name = "chkUpdateItems";
            this.chkUpdateItems.Size = new System.Drawing.Size(89, 17);
            this.chkUpdateItems.TabIndex = 15;
            this.chkUpdateItems.Text = "Update Items";
            this.chkUpdateItems.UseVisualStyleBackColor = true;
            // 
            // chkExitRms
            // 
            this.chkExitRms.AutoSize = true;
            this.chkExitRms.ForeColor = System.Drawing.Color.White;
            this.chkExitRms.Location = new System.Drawing.Point(390, 220);
            this.chkExitRms.Name = "chkExitRms";
            this.chkExitRms.Size = new System.Drawing.Size(73, 17);
            this.chkExitRms.TabIndex = 14;
            this.chkExitRms.Text = "Exit  RMS";
            this.chkExitRms.UseVisualStyleBackColor = true;
            // 
            // chkBooking
            // 
            this.chkBooking.AutoSize = true;
            this.chkBooking.ForeColor = System.Drawing.Color.White;
            this.chkBooking.Location = new System.Drawing.Point(169, 246);
            this.chkBooking.Name = "chkBooking";
            this.chkBooking.Size = new System.Drawing.Size(65, 17);
            this.chkBooking.TabIndex = 17;
            this.chkBooking.Text = "Booking";
            this.chkBooking.UseVisualStyleBackColor = true;
            // 
            // chkUnlockTable
            // 
            this.chkUnlockTable.AutoSize = true;
            this.chkUnlockTable.ForeColor = System.Drawing.Color.White;
            this.chkUnlockTable.Location = new System.Drawing.Point(34, 246);
            this.chkUnlockTable.Name = "chkUnlockTable";
            this.chkUnlockTable.Size = new System.Drawing.Size(90, 17);
            this.chkUnlockTable.TabIndex = 16;
            this.chkUnlockTable.Text = "Unlock Table";
            this.chkUnlockTable.UseVisualStyleBackColor = true;
            // 
            // chkCustomer
            // 
            this.chkCustomer.AutoSize = true;
            this.chkCustomer.ForeColor = System.Drawing.Color.White;
            this.chkCustomer.Location = new System.Drawing.Point(513, 188);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(75, 17);
            this.chkCustomer.TabIndex = 10;
            this.chkCustomer.Text = "Customers";
            this.chkCustomer.UseVisualStyleBackColor = true;
            // 
            // chkTransferTable
            // 
            this.chkTransferTable.AutoSize = true;
            this.chkTransferTable.ForeColor = System.Drawing.Color.White;
            this.chkTransferTable.Location = new System.Drawing.Point(278, 188);
            this.chkTransferTable.Name = "chkTransferTable";
            this.chkTransferTable.Size = new System.Drawing.Size(95, 17);
            this.chkTransferTable.TabIndex = 8;
            this.chkTransferTable.Text = "Transfer Table";
            this.chkTransferTable.UseVisualStyleBackColor = true;
            // 
            // chkVoidTable
            // 
            this.chkVoidTable.AutoSize = true;
            this.chkVoidTable.ForeColor = System.Drawing.Color.White;
            this.chkVoidTable.Location = new System.Drawing.Point(169, 188);
            this.chkVoidTable.Name = "chkVoidTable";
            this.chkVoidTable.Size = new System.Drawing.Size(77, 17);
            this.chkVoidTable.TabIndex = 7;
            this.chkVoidTable.Text = "Void Table";
            this.chkVoidTable.UseVisualStyleBackColor = true;
            // 
            // chkTillReport
            // 
            this.chkTillReport.AutoSize = true;
            this.chkTillReport.ForeColor = System.Drawing.Color.White;
            this.chkTillReport.Location = new System.Drawing.Point(278, 220);
            this.chkTillReport.Name = "chkTillReport";
            this.chkTillReport.Size = new System.Drawing.Size(88, 17);
            this.chkTillReport.TabIndex = 13;
            this.chkTillReport.Text = "Till Reporting";
            this.chkTillReport.UseVisualStyleBackColor = true;
            // 
            // chkDeposit
            // 
            this.chkDeposit.AutoSize = true;
            this.chkDeposit.ForeColor = System.Drawing.Color.White;
            this.chkDeposit.Location = new System.Drawing.Point(390, 246);
            this.chkDeposit.Name = "chkDeposit";
            this.chkDeposit.Size = new System.Drawing.Size(62, 17);
            this.chkDeposit.TabIndex = 19;
            this.chkDeposit.Text = "Deposit";
            this.chkDeposit.UseVisualStyleBackColor = true;
            // 
            // chkViewReport
            // 
            this.chkViewReport.AutoSize = true;
            this.chkViewReport.ForeColor = System.Drawing.Color.White;
            this.chkViewReport.Location = new System.Drawing.Point(169, 220);
            this.chkViewReport.Name = "chkViewReport";
            this.chkViewReport.Size = new System.Drawing.Size(84, 17);
            this.chkViewReport.TabIndex = 12;
            this.chkViewReport.Text = "View Report";
            this.chkViewReport.UseVisualStyleBackColor = true;
            // 
            // chkLogRegister
            // 
            this.chkLogRegister.AutoSize = true;
            this.chkLogRegister.ForeColor = System.Drawing.Color.White;
            this.chkLogRegister.Location = new System.Drawing.Point(34, 269);
            this.chkLogRegister.Name = "chkLogRegister";
            this.chkLogRegister.Size = new System.Drawing.Size(86, 17);
            this.chkLogRegister.TabIndex = 21;
            this.chkLogRegister.Text = "Log Register";
            this.chkLogRegister.UseVisualStyleBackColor = true;
            // 
            // chkReviewTrans
            // 
            this.chkReviewTrans.AutoSize = true;
            this.chkReviewTrans.ForeColor = System.Drawing.Color.White;
            this.chkReviewTrans.Location = new System.Drawing.Point(34, 220);
            this.chkReviewTrans.Name = "chkReviewTrans";
            this.chkReviewTrans.Size = new System.Drawing.Size(121, 17);
            this.chkReviewTrans.TabIndex = 11;
            this.chkReviewTrans.Text = "Review Transaction";
            this.chkReviewTrans.UseVisualStyleBackColor = true;
            // 
            // chkMergeTable
            // 
            this.chkMergeTable.AutoSize = true;
            this.chkMergeTable.ForeColor = System.Drawing.Color.White;
            this.chkMergeTable.Location = new System.Drawing.Point(390, 188);
            this.chkMergeTable.Name = "chkMergeTable";
            this.chkMergeTable.Size = new System.Drawing.Size(86, 17);
            this.chkMergeTable.TabIndex = 9;
            this.chkMergeTable.Text = "Merge Table";
            this.chkMergeTable.UseVisualStyleBackColor = true;
            // 
            // chkRemoveItems
            // 
            this.chkRemoveItems.AutoSize = true;
            this.chkRemoveItems.ForeColor = System.Drawing.Color.White;
            this.chkRemoveItems.Location = new System.Drawing.Point(513, 246);
            this.chkRemoveItems.Name = "chkRemoveItems";
            this.chkRemoveItems.Size = new System.Drawing.Size(94, 17);
            this.chkRemoveItems.TabIndex = 20;
            this.chkRemoveItems.Text = "Remove Items";
            this.chkRemoveItems.UseVisualStyleBackColor = true;
            // 
            // lblSaveStatus
            // 
            this.lblSaveStatus.AutoSize = true;
            this.lblSaveStatus.ForeColor = System.Drawing.Color.White;
            this.lblSaveStatus.Location = new System.Drawing.Point(245, 371);
            this.lblSaveStatus.Name = "lblSaveStatus";
            this.lblSaveStatus.Size = new System.Drawing.Size(228, 13);
            this.lblSaveStatus.TabIndex = 68;
            this.lblSaveStatus.Text = "User information has beeen saved successfully";
            this.lblSaveStatus.Visible = false;
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(320, 399);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(120, 40);
            this.btnDone.TabIndex = 25;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(193, 399);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(67, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkSettings
            // 
            this.chkSettings.AutoSize = true;
            this.chkSettings.ForeColor = System.Drawing.Color.White;
            this.chkSettings.Location = new System.Drawing.Point(169, 269);
            this.chkSettings.Name = "chkSettings";
            this.chkSettings.Size = new System.Drawing.Size(101, 17);
            this.chkSettings.TabIndex = 22;
            this.chkSettings.Text = "System Settings";
            this.chkSettings.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(447, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkRmsAdmin
            // 
            this.chkRmsAdmin.AutoSize = true;
            this.chkRmsAdmin.ForeColor = System.Drawing.Color.White;
            this.chkRmsAdmin.Location = new System.Drawing.Point(278, 269);
            this.chkRmsAdmin.Name = "chkRmsAdmin";
            this.chkRmsAdmin.Size = new System.Drawing.Size(82, 17);
            this.chkRmsAdmin.TabIndex = 69;
            this.chkRmsAdmin.Text = "RMS Admin";
            this.chkRmsAdmin.UseVisualStyleBackColor = true;
            // 
            // AddNewUserCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.chkRmsAdmin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkSettings);
            this.Controls.Add(this.lblSaveStatus);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkRemoveItems);
            this.Controls.Add(this.chkMergeTable);
            this.Controls.Add(this.chkReviewTrans);
            this.Controls.Add(this.chkLogRegister);
            this.Controls.Add(this.chkViewReport);
            this.Controls.Add(this.chkDeposit);
            this.Controls.Add(this.chkTillReport);
            this.Controls.Add(this.chkVoidTable);
            this.Controls.Add(this.chkTransferTable);
            this.Controls.Add(this.chkCustomer);
            this.Controls.Add(this.chkUnlockTable);
            this.Controls.Add(this.chkBooking);
            this.Controls.Add(this.chkExitRms);
            this.Controls.Add(this.chkUpdateItems);
            this.Controls.Add(this.chkUsers);
            this.Controls.Add(this.chkOpenDrawer);
            this.Controls.Add(this.rdoInActive);
            this.Controls.Add(this.rdoActive);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "AddNewUserCtl";
            this.Size = new System.Drawing.Size(693, 476);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoInActive;
        private System.Windows.Forms.CheckBox chkOpenDrawer;
        private System.Windows.Forms.CheckBox chkUsers;
        private System.Windows.Forms.CheckBox chkUpdateItems;
        private System.Windows.Forms.CheckBox chkExitRms;
        private System.Windows.Forms.CheckBox chkBooking;
        private System.Windows.Forms.CheckBox chkUnlockTable;
        private System.Windows.Forms.CheckBox chkCustomer;
        private System.Windows.Forms.CheckBox chkTransferTable;
        private System.Windows.Forms.CheckBox chkVoidTable;
        private System.Windows.Forms.CheckBox chkTillReport;
        private System.Windows.Forms.CheckBox chkDeposit;
        private System.Windows.Forms.CheckBox chkViewReport;
        private System.Windows.Forms.CheckBox chkLogRegister;
        private System.Windows.Forms.CheckBox chkReviewTrans;
        private System.Windows.Forms.CheckBox chkMergeTable;
        private System.Windows.Forms.CheckBox chkRemoveItems;
        private System.Windows.Forms.Label lblSaveStatus;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkRmsAdmin;
    }
}
