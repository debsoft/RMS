namespace BistroAdmin.UI
{
    partial class InventoryPurchaseForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.savePurchasebutton = new System.Windows.Forms.Button();
            this.quantitytextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemNamecomboBox = new System.Windows.Forms.ComboBox();
            this.supplierNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dueOradvancelabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pricetextBox = new System.Windows.Forms.TextBox();
            this.purchaseActionlabel = new System.Windows.Forms.Label();
            this.unittypelabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.paidPricetextBox = new System.Windows.Forms.TextBox();
            this.paymentTypecomboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.expiredateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Inventory Purchase ";
            // 
            // savePurchasebutton
            // 
            this.savePurchasebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePurchasebutton.Location = new System.Drawing.Point(288, 423);
            this.savePurchasebutton.Name = "savePurchasebutton";
            this.savePurchasebutton.Size = new System.Drawing.Size(75, 23);
            this.savePurchasebutton.TabIndex = 4;
            this.savePurchasebutton.Text = "Save";
            this.savePurchasebutton.UseVisualStyleBackColor = true;
            this.savePurchasebutton.Click += new System.EventHandler(this.savePurchasebutton_Click);
            // 
            // quantitytextBox
            // 
            this.quantitytextBox.Location = new System.Drawing.Point(242, 207);
            this.quantitytextBox.Name = "quantitytextBox";
            this.quantitytextBox.Size = new System.Drawing.Size(121, 20);
            this.quantitytextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Category Name";
            // 
            // categoryNamecomboBox
            // 
            this.categoryNamecomboBox.FormattingEnabled = true;
            this.categoryNamecomboBox.Location = new System.Drawing.Point(242, 73);
            this.categoryNamecomboBox.Name = "categoryNamecomboBox";
            this.categoryNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryNamecomboBox.TabIndex = 5;
            this.categoryNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.categoryNamecomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item Name";
            // 
            // itemNamecomboBox
            // 
            this.itemNamecomboBox.FormattingEnabled = true;
            this.itemNamecomboBox.Location = new System.Drawing.Point(242, 122);
            this.itemNamecomboBox.Name = "itemNamecomboBox";
            this.itemNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.itemNamecomboBox.TabIndex = 7;
            this.itemNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.itemNamecomboBox_SelectedIndexChanged);
            // 
            // supplierNamecomboBox
            // 
            this.supplierNamecomboBox.FormattingEnabled = true;
            this.supplierNamecomboBox.Location = new System.Drawing.Point(242, 167);
            this.supplierNamecomboBox.Name = "supplierNamecomboBox";
            this.supplierNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.supplierNamecomboBox.TabIndex = 8;
            this.supplierNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.supplierNamecomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(142, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Supplier Name";
            // 
            // dueOradvancelabel
            // 
            this.dueOradvancelabel.AutoSize = true;
            this.dueOradvancelabel.Location = new System.Drawing.Point(396, 170);
            this.dueOradvancelabel.Name = "dueOradvancelabel";
            this.dueOradvancelabel.Size = new System.Drawing.Size(78, 13);
            this.dueOradvancelabel.TabIndex = 10;
            this.dueOradvancelabel.Text = "due/addvance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(171, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(157, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total Price";
            // 
            // pricetextBox
            // 
            this.pricetextBox.Location = new System.Drawing.Point(244, 259);
            this.pricetextBox.Name = "pricetextBox";
            this.pricetextBox.Size = new System.Drawing.Size(119, 20);
            this.pricetextBox.TabIndex = 1;
            // 
            // purchaseActionlabel
            // 
            this.purchaseActionlabel.AutoSize = true;
            this.purchaseActionlabel.Location = new System.Drawing.Point(255, 449);
            this.purchaseActionlabel.Name = "purchaseActionlabel";
            this.purchaseActionlabel.Size = new System.Drawing.Size(48, 13);
            this.purchaseActionlabel.TabIndex = 14;
            this.purchaseActionlabel.Text = "acion.....";
            this.purchaseActionlabel.Click += new System.EventHandler(this.purchaseActionlabel_Click);
            // 
            // unittypelabel
            // 
            this.unittypelabel.AutoSize = true;
            this.unittypelabel.Location = new System.Drawing.Point(396, 207);
            this.unittypelabel.Name = "unittypelabel";
            this.unittypelabel.Size = new System.Drawing.Size(24, 13);
            this.unittypelabel.TabIndex = 15;
            this.unittypelabel.Text = "unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(160, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Paid Price";
            // 
            // paidPricetextBox
            // 
            this.paidPricetextBox.Location = new System.Drawing.Point(244, 297);
            this.paidPricetextBox.Name = "paidPricetextBox";
            this.paidPricetextBox.Size = new System.Drawing.Size(119, 20);
            this.paidPricetextBox.TabIndex = 2;
            // 
            // paymentTypecomboBox
            // 
            this.paymentTypecomboBox.FormattingEnabled = true;
            this.paymentTypecomboBox.Location = new System.Drawing.Point(242, 334);
            this.paymentTypecomboBox.Name = "paymentTypecomboBox";
            this.paymentTypecomboBox.Size = new System.Drawing.Size(121, 21);
            this.paymentTypecomboBox.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(139, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Payment Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(148, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Expire Date";
            // 
            // expiredateTimePicker
            // 
            this.expiredateTimePicker.Location = new System.Drawing.Point(242, 377);
            this.expiredateTimePicker.Name = "expiredateTimePicker";
            this.expiredateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.expiredateTimePicker.TabIndex = 22;
            // 
            // InventoryPurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.expiredateTimePicker);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.paymentTypecomboBox);
            this.Controls.Add(this.paidPricetextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.unittypelabel);
            this.Controls.Add(this.purchaseActionlabel);
            this.Controls.Add(this.pricetextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dueOradvancelabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.supplierNamecomboBox);
            this.Controls.Add(this.itemNamecomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.categoryNamecomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantitytextBox);
            this.Controls.Add(this.savePurchasebutton);
            this.Controls.Add(this.label1);
            this.Name = "InventoryPurchaseForm";
            this.Size = new System.Drawing.Size(699, 489);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savePurchasebutton;
        private System.Windows.Forms.TextBox quantitytextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryNamecomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox itemNamecomboBox;
        private System.Windows.Forms.ComboBox supplierNamecomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dueOradvancelabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pricetextBox;
        private System.Windows.Forms.Label purchaseActionlabel;
        private System.Windows.Forms.Label unittypelabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox paidPricetextBox;
        private System.Windows.Forms.ComboBox paymentTypecomboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker expiredateTimePicker;
    }
}