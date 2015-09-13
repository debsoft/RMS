namespace BistroAdmin.UI
{
    partial class SupplierPayment
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
            this.dueOradvancelabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.supplierNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.paymentTypecomboBox = new System.Windows.Forms.ComboBox();
            this.paidPricetextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.purchaseActionlabel = new System.Windows.Forms.Label();
            this.savePaymentbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dueOradvancelabel
            // 
            this.dueOradvancelabel.AutoSize = true;
            this.dueOradvancelabel.Location = new System.Drawing.Point(466, 70);
            this.dueOradvancelabel.Name = "dueOradvancelabel";
            this.dueOradvancelabel.Size = new System.Drawing.Size(78, 13);
            this.dueOradvancelabel.TabIndex = 13;
            this.dueOradvancelabel.Text = "due/addvance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Supplier Name";
            // 
            // supplierNamecomboBox
            // 
            this.supplierNamecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierNamecomboBox.FormattingEnabled = true;
            this.supplierNamecomboBox.Location = new System.Drawing.Point(318, 67);
            this.supplierNamecomboBox.Name = "supplierNamecomboBox";
            this.supplierNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.supplierNamecomboBox.TabIndex = 0;
            this.supplierNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.supplierNamecomboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(212, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Payment Type";
            // 
            // paymentTypecomboBox
            // 
            this.paymentTypecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentTypecomboBox.FormattingEnabled = true;
            this.paymentTypecomboBox.Location = new System.Drawing.Point(318, 148);
            this.paymentTypecomboBox.Name = "paymentTypecomboBox";
            this.paymentTypecomboBox.Size = new System.Drawing.Size(121, 21);
            this.paymentTypecomboBox.TabIndex = 2;
            // 
            // paidPricetextBox
            // 
            this.paidPricetextBox.Location = new System.Drawing.Point(318, 109);
            this.paidPricetextBox.Name = "paidPricetextBox";
            this.paidPricetextBox.Size = new System.Drawing.Size(121, 20);
            this.paidPricetextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(234, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Paid Price";
            // 
            // purchaseActionlabel
            // 
            this.purchaseActionlabel.AutoSize = true;
            this.purchaseActionlabel.Location = new System.Drawing.Point(341, 227);
            this.purchaseActionlabel.Name = "purchaseActionlabel";
            this.purchaseActionlabel.Size = new System.Drawing.Size(48, 13);
            this.purchaseActionlabel.TabIndex = 25;
            this.purchaseActionlabel.Text = "acion.....";
            // 
            // savePaymentbutton
            // 
            this.savePaymentbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePaymentbutton.Location = new System.Drawing.Point(364, 188);
            this.savePaymentbutton.Name = "savePaymentbutton";
            this.savePaymentbutton.Size = new System.Drawing.Size(75, 23);
            this.savePaymentbutton.TabIndex = 3;
            this.savePaymentbutton.Text = "Save";
            this.savePaymentbutton.UseVisualStyleBackColor = true;
            this.savePaymentbutton.Click += new System.EventHandler(this.savePaymentbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 112;
            this.label1.Text = "Supplier Payment";
            // 
            // SupplierPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.purchaseActionlabel);
            this.Controls.Add(this.savePaymentbutton);
            this.Controls.Add(this.paidPricetextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.paymentTypecomboBox);
            this.Controls.Add(this.dueOradvancelabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.supplierNamecomboBox);
            this.Name = "SupplierPayment";
            this.Size = new System.Drawing.Size(851, 404);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dueOradvancelabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox supplierNamecomboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox paymentTypecomboBox;
        private System.Windows.Forms.TextBox paidPricetextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label purchaseActionlabel;
        private System.Windows.Forms.Button savePaymentbutton;
        private System.Windows.Forms.Label label1;
    }
}