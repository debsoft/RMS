namespace RMSAdmin.Purchase
{
    partial class PurchaseForm
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
            this.quantitytextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemnamelabel = new System.Windows.Forms.Label();
            this.supplierNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.amounttextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.unitnameLebel = new System.Windows.Forms.Label();
            this.savebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Purchase";
            // 
            // quantitytextBox
            // 
            this.quantitytextBox.Location = new System.Drawing.Point(227, 151);
            this.quantitytextBox.Name = "quantitytextBox";
            this.quantitytextBox.Size = new System.Drawing.Size(119, 20);
            this.quantitytextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Name";
            // 
            // itemnamelabel
            // 
            this.itemnamelabel.AutoSize = true;
            this.itemnamelabel.Location = new System.Drawing.Point(224, 63);
            this.itemnamelabel.Name = "itemnamelabel";
            this.itemnamelabel.Size = new System.Drawing.Size(58, 13);
            this.itemnamelabel.TabIndex = 4;
            this.itemnamelabel.Text = "item_name";
            // 
            // supplierNamecomboBox
            // 
            this.supplierNamecomboBox.FormattingEnabled = true;
            this.supplierNamecomboBox.Location = new System.Drawing.Point(227, 95);
            this.supplierNamecomboBox.Name = "supplierNamecomboBox";
            this.supplierNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.supplierNamecomboBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Supplier1 Name";
            // 
            // amounttextBox
            // 
            this.amounttextBox.Location = new System.Drawing.Point(227, 196);
            this.amounttextBox.Name = "amounttextBox";
            this.amounttextBox.Size = new System.Drawing.Size(121, 20);
            this.amounttextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Amount";
            // 
            // unitnameLebel
            // 
            this.unitnameLebel.AutoSize = true;
            this.unitnameLebel.Location = new System.Drawing.Point(363, 158);
            this.unitnameLebel.Name = "unitnameLebel";
            this.unitnameLebel.Size = new System.Drawing.Size(50, 13);
            this.unitnameLebel.TabIndex = 11;
            this.unitnameLebel.Text = "unitname";
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(252, 253);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 12;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 425);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.unitnameLebel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.amounttextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.supplierNamecomboBox);
            this.Controls.Add(this.itemnamelabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantitytextBox);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseForm";
            this.Text = "Purchase Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox quantitytextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox supplierNamecomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox amounttextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button savebutton;
        public System.Windows.Forms.Label itemnamelabel;
        public System.Windows.Forms.Label unitnameLebel;
    }
}