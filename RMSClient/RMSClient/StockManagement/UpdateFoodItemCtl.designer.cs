namespace RMS.StockManagement
{
    partial class UpdateFoodItemCtl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFoodItemCtl));
            this.grpCategory = new System.Windows.Forms.GroupBox();
            this.cmbSellingIn = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.txtInitialQuantity = new System.Windows.Forms.TextBox();
            this.rdoInActive = new System.Windows.Forms.RadioButton();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBarPrice = new System.Windows.Forms.TextBox();
            this.txtTakeawayPrice = new System.Windows.Forms.TextBox();
            this.lblSaveStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTablePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkBar = new System.Windows.Forms.CheckBox();
            this.chkTakeAway = new System.Windows.Forms.CheckBox();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFoodType = new System.Windows.Forms.ComboBox();
            this.grpCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCategory
            // 
            this.grpCategory.Controls.Add(this.cmbSellingIn);
            this.grpCategory.Controls.Add(this.label13);
            this.grpCategory.Controls.Add(this.chkUnlimited);
            this.grpCategory.Controls.Add(this.txtInitialQuantity);
            this.grpCategory.Controls.Add(this.rdoInActive);
            this.grpCategory.Controls.Add(this.rdoActive);
            this.grpCategory.Controls.Add(this.label12);
            this.grpCategory.Controls.Add(this.txtBarCode);
            this.grpCategory.Controls.Add(this.label11);
            this.grpCategory.Controls.Add(this.label10);
            this.grpCategory.Controls.Add(this.txtDescription);
            this.grpCategory.Controls.Add(this.label9);
            this.grpCategory.Controls.Add(this.label8);
            this.grpCategory.Controls.Add(this.label7);
            this.grpCategory.Controls.Add(this.txtBarPrice);
            this.grpCategory.Controls.Add(this.txtTakeawayPrice);
            this.grpCategory.Controls.Add(this.lblSaveStatus);
            this.grpCategory.Controls.Add(this.btnCancel);
            this.grpCategory.Controls.Add(this.btnDone);
            this.grpCategory.Controls.Add(this.btnSave);
            this.grpCategory.Controls.Add(this.txtTablePrice);
            this.grpCategory.Controls.Add(this.label6);
            this.grpCategory.Controls.Add(this.label5);
            this.grpCategory.Controls.Add(this.chkBar);
            this.grpCategory.Controls.Add(this.chkTakeAway);
            this.grpCategory.Controls.Add(this.chkTable);
            this.grpCategory.Controls.Add(this.label4);
            this.grpCategory.Controls.Add(this.txtProductName);
            this.grpCategory.Controls.Add(this.label3);
            this.grpCategory.Controls.Add(this.cmbCategory);
            this.grpCategory.Controls.Add(this.cmbParent);
            this.grpCategory.Controls.Add(this.label2);
            this.grpCategory.Controls.Add(this.label1);
            this.grpCategory.Controls.Add(this.cmbFoodType);
            this.grpCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpCategory.Location = new System.Drawing.Point(12, 22);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Size = new System.Drawing.Size(719, 445);
            this.grpCategory.TabIndex = 0;
            this.grpCategory.TabStop = false;
            this.grpCategory.Text = "Category Information";
            // 
            // cmbSellingIn
            // 
            this.cmbSellingIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbSellingIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSellingIn.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSellingIn.FormattingEnabled = true;
            this.cmbSellingIn.Items.AddRange(new object[] {
            "Per Piece",
            "Per Pound"});
            this.cmbSellingIn.Location = new System.Drawing.Point(429, 258);
            this.cmbSellingIn.Name = "cmbSellingIn";
            this.cmbSellingIn.Size = new System.Drawing.Size(96, 21);
            this.cmbSellingIn.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(129, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Stock Quantity";
            // 
            // chkUnlimited
            // 
            this.chkUnlimited.AutoSize = true;
            this.chkUnlimited.Location = new System.Drawing.Point(319, 213);
            this.chkUnlimited.Name = "chkUnlimited";
            this.chkUnlimited.Size = new System.Drawing.Size(69, 17);
            this.chkUnlimited.TabIndex = 38;
            this.chkUnlimited.Text = "Unlimited";
            this.chkUnlimited.UseVisualStyleBackColor = true;
            this.chkUnlimited.CheckedChanged += new System.EventHandler(this.chkUnlimited_CheckedChanged);
            // 
            // txtInitialQuantity
            // 
            this.txtInitialQuantity.BackColor = System.Drawing.Color.Black;
            this.txtInitialQuantity.ForeColor = System.Drawing.Color.White;
            this.txtInitialQuantity.Location = new System.Drawing.Point(213, 213);
            this.txtInitialQuantity.Name = "txtInitialQuantity";
            this.txtInitialQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtInitialQuantity.TabIndex = 37;
            // 
            // rdoInActive
            // 
            this.rdoInActive.AutoSize = true;
            this.rdoInActive.BackColor = System.Drawing.Color.Black;
            this.rdoInActive.ForeColor = System.Drawing.Color.White;
            this.rdoInActive.Location = new System.Drawing.Point(340, 349);
            this.rdoInActive.Name = "rdoInActive";
            this.rdoInActive.Size = new System.Drawing.Size(63, 17);
            this.rdoInActive.TabIndex = 13;
            this.rdoInActive.TabStop = true;
            this.rdoInActive.Text = "Inactive";
            this.rdoInActive.UseVisualStyleBackColor = false;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.BackColor = System.Drawing.Color.Black;
            this.rdoActive.ForeColor = System.Drawing.Color.White;
            this.rdoActive.Location = new System.Drawing.Point(213, 349);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(55, 17);
            this.rdoActive.TabIndex = 12;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = false;
            this.rdoActive.CheckedChanged += new System.EventHandler(this.rdoActive_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(154, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Barcode";
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Black;
            this.txtBarCode.ForeColor = System.Drawing.Color.White;
            this.txtBarCode.Location = new System.Drawing.Point(213, 146);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.ReadOnly = true;
            this.txtBarCode.Size = new System.Drawing.Size(212, 20);
            this.txtBarCode.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(147, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(127, 349);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Product Status";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Black;
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(213, 289);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(212, 52);
            this.txtDescription.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(380, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Bar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(283, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Takeaway";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(218, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Table";
            // 
            // txtBarPrice
            // 
            this.txtBarPrice.BackColor = System.Drawing.Color.Black;
            this.txtBarPrice.ForeColor = System.Drawing.Color.White;
            this.txtBarPrice.Location = new System.Drawing.Point(370, 258);
            this.txtBarPrice.Name = "txtBarPrice";
            this.txtBarPrice.Size = new System.Drawing.Size(53, 20);
            this.txtBarPrice.TabIndex = 10;
            // 
            // txtTakeawayPrice
            // 
            this.txtTakeawayPrice.BackColor = System.Drawing.Color.Black;
            this.txtTakeawayPrice.ForeColor = System.Drawing.Color.White;
            this.txtTakeawayPrice.Location = new System.Drawing.Point(286, 258);
            this.txtTakeawayPrice.Name = "txtTakeawayPrice";
            this.txtTakeawayPrice.Size = new System.Drawing.Size(53, 20);
            this.txtTakeawayPrice.TabIndex = 9;
            // 
            // lblSaveStatus
            // 
            this.lblSaveStatus.AutoSize = true;
            this.lblSaveStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSaveStatus.Location = new System.Drawing.Point(204, 372);
            this.lblSaveStatus.Name = "lblSaveStatus";
            this.lblSaveStatus.Size = new System.Drawing.Size(188, 13);
            this.lblSaveStatus.TabIndex = 24;
            this.lblSaveStatus.Text = "Category has been saved successfully";
            this.lblSaveStatus.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(442, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.Black;
            this.btnDone.Location = new System.Drawing.Point(316, 400);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(120, 40);
            this.btnDone.TabIndex = 15;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(191, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Update";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTablePrice
            // 
            this.txtTablePrice.BackColor = System.Drawing.Color.Black;
            this.txtTablePrice.ForeColor = System.Drawing.Color.White;
            this.txtTablePrice.Location = new System.Drawing.Point(211, 258);
            this.txtTablePrice.Name = "txtTablePrice";
            this.txtTablePrice.Size = new System.Drawing.Size(53, 20);
            this.txtTablePrice.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(173, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(159, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "View On";
            // 
            // chkBar
            // 
            this.chkBar.AutoSize = true;
            this.chkBar.BackColor = System.Drawing.Color.Black;
            this.chkBar.ForeColor = System.Drawing.Color.White;
            this.chkBar.Location = new System.Drawing.Point(383, 180);
            this.chkBar.Name = "chkBar";
            this.chkBar.Size = new System.Drawing.Size(42, 17);
            this.chkBar.TabIndex = 7;
            this.chkBar.Text = "Bar";
            this.chkBar.UseVisualStyleBackColor = false;
            // 
            // chkTakeAway
            // 
            this.chkTakeAway.AutoSize = true;
            this.chkTakeAway.BackColor = System.Drawing.Color.Black;
            this.chkTakeAway.ForeColor = System.Drawing.Color.White;
            this.chkTakeAway.Location = new System.Drawing.Point(288, 180);
            this.chkTakeAway.Name = "chkTakeAway";
            this.chkTakeAway.Size = new System.Drawing.Size(80, 17);
            this.chkTakeAway.TabIndex = 6;
            this.chkTakeAway.Text = "Take Away";
            this.chkTakeAway.UseVisualStyleBackColor = false;
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.BackColor = System.Drawing.Color.Black;
            this.chkTable.ForeColor = System.Drawing.Color.White;
            this.chkTable.Location = new System.Drawing.Point(213, 180);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(53, 17);
            this.chkTable.TabIndex = 5;
            this.chkTable.Text = "Table";
            this.chkTable.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(126, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Black;
            this.txtProductName.ForeColor = System.Drawing.Color.White;
            this.txtProductName.Location = new System.Drawing.Point(213, 120);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(212, 20);
            this.txtProductName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(130, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Category 3";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbCategory.DisplayMember = "Category2_Name";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.ForeColor = System.Drawing.Color.White;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(213, 90);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(212, 21);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.ValueMember = "cat2_id";
            // 
            // cmbParent
            // 
            this.cmbParent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbParent.DisplayMember = "Parent_Category_Name";
            this.cmbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParent.ForeColor = System.Drawing.Color.White;
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new System.Drawing.Point(213, 33);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new System.Drawing.Size(212, 21);
            this.cmbParent.TabIndex = 0;
            this.cmbParent.ValueMember = "parent_cat_id";
            this.cmbParent.SelectedIndexChanged += new System.EventHandler(this.cmbParent_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(130, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Category 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(130, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Category 1";
            // 
            // cmbFoodType
            // 
            this.cmbFoodType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbFoodType.DisplayMember = "cat1_name";
            this.cmbFoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFoodType.ForeColor = System.Drawing.Color.White;
            this.cmbFoodType.FormattingEnabled = true;
            this.cmbFoodType.Location = new System.Drawing.Point(213, 60);
            this.cmbFoodType.Name = "cmbFoodType";
            this.cmbFoodType.Size = new System.Drawing.Size(212, 21);
            this.cmbFoodType.TabIndex = 1;
            this.cmbFoodType.ValueMember = "cat1_id";
            this.cmbFoodType.SelectedIndexChanged += new System.EventHandler(this.cmbFoodType_SelectedIndexChanged);
            // 
            // UpdateFoodItemCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.grpCategory);
            this.Name = "UpdateFoodItemCtl";
            this.Size = new System.Drawing.Size(787, 484);
            this.Load += new System.EventHandler(this.UpdateFoodItemCtl_Load);
            this.grpCategory.ResumeLayout(false);
            this.grpCategory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBarPrice;
        private System.Windows.Forms.TextBox txtTakeawayPrice;
        private System.Windows.Forms.Label lblSaveStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTablePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBar;
        private System.Windows.Forms.CheckBox chkTakeAway;
        private System.Windows.Forms.CheckBox chkTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbParent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFoodType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.RadioButton rdoInActive;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.TextBox txtInitialQuantity;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbSellingIn;
    }
}
