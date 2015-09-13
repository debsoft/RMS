namespace RMSAdmin.Purchase
{
    partial class OtherDamageOrStockOut
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
            this.othertransactiontypelebel = new System.Windows.Forms.Label();
            this.savebutton = new System.Windows.Forms.Button();
            this.otherunitnameLebel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.otheritemnamelabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quantitytextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.purposeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // othertransactiontypelebel
            // 
            this.othertransactiontypelebel.AutoSize = true;
            this.othertransactiontypelebel.Location = new System.Drawing.Point(273, 152);
            this.othertransactiontypelebel.Name = "othertransactiontypelebel";
            this.othertransactiontypelebel.Size = new System.Drawing.Size(59, 13);
            this.othertransactiontypelebel.TabIndex = 33;
            this.othertransactiontypelebel.Text = "transaction";
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(370, 330);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 32;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // otherunitnameLebel
            // 
            this.otherunitnameLebel.AutoSize = true;
            this.otherunitnameLebel.Location = new System.Drawing.Point(412, 207);
            this.otherunitnameLebel.Name = "otherunitnameLebel";
            this.otherunitnameLebel.Size = new System.Drawing.Size(50, 13);
            this.otherunitnameLebel.TabIndex = 31;
            this.otherunitnameLebel.Text = "unitname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Transaction Type";
            // 
            // otheritemnamelabel
            // 
            this.otheritemnamelabel.AutoSize = true;
            this.otheritemnamelabel.Location = new System.Drawing.Point(273, 112);
            this.otheritemnamelabel.Name = "otheritemnamelabel";
            this.otheritemnamelabel.Size = new System.Drawing.Size(58, 13);
            this.otheritemnamelabel.TabIndex = 28;
            this.otheritemnamelabel.Text = "item_name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Item Name";
            // 
            // quantitytextBox
            // 
            this.quantitytextBox.Location = new System.Drawing.Point(276, 200);
            this.quantitytextBox.Name = "quantitytextBox";
            this.quantitytextBox.Size = new System.Drawing.Size(119, 20);
            this.quantitytextBox.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Damage Report/ Stock Out Purpose";
            // 
            // purposeTextBox
            // 
            this.purposeTextBox.Location = new System.Drawing.Point(276, 236);
            this.purposeTextBox.Multiline = true;
            this.purposeTextBox.Name = "purposeTextBox";
            this.purposeTextBox.Size = new System.Drawing.Size(186, 82);
            this.purposeTextBox.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Item Damage/Stock Out";
            // 
            // OtherDamageOrStockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 398);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.purposeTextBox);
            this.Controls.Add(this.othertransactiontypelebel);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.otherunitnameLebel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.otheritemnamelabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantitytextBox);
            this.Name = "OtherDamageOrStockOut";
            this.Text = "OtherDamageOrStockOut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label othertransactiontypelebel;
        private System.Windows.Forms.Button savebutton;
        public System.Windows.Forms.Label otherunitnameLebel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label otheritemnamelabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantitytextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox purposeTextBox;
        private System.Windows.Forms.Label label1;
    }
}