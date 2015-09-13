namespace RMSAdmin.Purchase
{
    partial class DamageOrStockOut
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
            this.savebutton = new System.Windows.Forms.Button();
            this.unitnameLebel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.itemnamelabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quantitytextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.transactiontypelebel = new System.Windows.Forms.Label();
            this.purposeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(417, 338);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 23;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // unitnameLebel
            // 
            this.unitnameLebel.AutoSize = true;
            this.unitnameLebel.Location = new System.Drawing.Point(442, 206);
            this.unitnameLebel.Name = "unitnameLebel";
            this.unitnameLebel.Size = new System.Drawing.Size(50, 13);
            this.unitnameLebel.TabIndex = 22;
            this.unitnameLebel.Text = "unitname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Transaction Type";
            // 
            // itemnamelabel
            // 
            this.itemnamelabel.AutoSize = true;
            this.itemnamelabel.Location = new System.Drawing.Point(303, 111);
            this.itemnamelabel.Name = "itemnamelabel";
            this.itemnamelabel.Size = new System.Drawing.Size(58, 13);
            this.itemnamelabel.TabIndex = 16;
            this.itemnamelabel.Text = "item_name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Item Name";
            // 
            // quantitytextBox
            // 
            this.quantitytextBox.Location = new System.Drawing.Point(306, 199);
            this.quantitytextBox.Name = "quantitytextBox";
            this.quantitytextBox.Size = new System.Drawing.Size(119, 20);
            this.quantitytextBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Item Damage/Stock Out";
            // 
            // transactiontypelebel
            // 
            this.transactiontypelebel.AutoSize = true;
            this.transactiontypelebel.Location = new System.Drawing.Point(303, 151);
            this.transactiontypelebel.Name = "transactiontypelebel";
            this.transactiontypelebel.Size = new System.Drawing.Size(59, 13);
            this.transactiontypelebel.TabIndex = 24;
            this.transactiontypelebel.Text = "transaction";
            // 
            // purposeTextBox
            // 
            this.purposeTextBox.Location = new System.Drawing.Point(306, 238);
            this.purposeTextBox.Multiline = true;
            this.purposeTextBox.Name = "purposeTextBox";
            this.purposeTextBox.Size = new System.Drawing.Size(186, 82);
            this.purposeTextBox.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Damage Report/ Stock Out Purpose";
            // 
            // DamageOrStockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 479);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.purposeTextBox);
            this.Controls.Add(this.transactiontypelebel);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.unitnameLebel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.itemnamelabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantitytextBox);
            this.Controls.Add(this.label1);
            this.Name = "DamageOrStockOut";
            this.Text = "DamageOrStockOut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button savebutton;
        public System.Windows.Forms.Label unitnameLebel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label itemnamelabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantitytextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label transactiontypelebel;
        private System.Windows.Forms.TextBox purposeTextBox;
        private System.Windows.Forms.Label label3;

    }
}