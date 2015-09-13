namespace RMSAdmin.Purchase
{
    partial class AddOtherItem
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
            this.label2 = new System.Windows.Forms.Label();
            this.itemnametextBox = new System.Windows.Forms.TextBox();
            this.unitcomboBox = new System.Windows.Forms.ComboBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.categorycomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Name";
            // 
            // itemnametextBox
            // 
            this.itemnametextBox.Location = new System.Drawing.Point(182, 137);
            this.itemnametextBox.Name = "itemnametextBox";
            this.itemnametextBox.Size = new System.Drawing.Size(121, 20);
            this.itemnametextBox.TabIndex = 2;
            // 
            // unitcomboBox
            // 
            this.unitcomboBox.FormattingEnabled = true;
            this.unitcomboBox.Items.AddRange(new object[] {
            "Per Piece",
            "Per Pound",
            "Per Kg",
            "Per Ltr",
            "Per Gm",
            "Per Pac",
            "Per Glass",
            "Per ml",
            "Per Plate",
            "Per Cup",
            "Per Tin",
            "Per 500 mg",
            "Per 1.5 Ltr",
            "Per Can",
            "Per 250 ml",
            "Per Box",
            "Per Pot",
            "Per Pcs",
            "Per Kg",
            "Per Dozen"});
            this.unitcomboBox.Location = new System.Drawing.Point(182, 179);
            this.unitcomboBox.Name = "unitcomboBox";
            this.unitcomboBox.Size = new System.Drawing.Size(121, 21);
            this.unitcomboBox.TabIndex = 3;
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(228, 235);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(75, 23);
            this.addbutton.TabIndex = 4;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Category";
            // 
            // categorycomboBox
            // 
            this.categorycomboBox.FormattingEnabled = true;
            this.categorycomboBox.Items.AddRange(new object[] {
            "Per Piece",
            "Per Pound",
            "Per Kg",
            "Per Ltr",
            "Per Gm",
            "Per Pac",
            "Per Glass",
            "Per ml",
            "Per Plate",
            "Per Cup",
            "Per Tin",
            "Per 500 mg",
            "Per 1.5 Ltr",
            "Per Can",
            "Per 250 ml",
            "Per Box",
            "Per Pot",
            "Per Pcs",
            "Per Kg",
            "Per Dozen"});
            this.categorycomboBox.Location = new System.Drawing.Point(183, 98);
            this.categorycomboBox.Name = "categorycomboBox";
            this.categorycomboBox.Size = new System.Drawing.Size(121, 21);
            this.categorycomboBox.TabIndex = 8;
            // 
            // AddOtherItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 363);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categorycomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.unitcomboBox);
            this.Controls.Add(this.itemnametextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOtherItem";
            this.Text = "AddOtherItem";
            this.Load += new System.EventHandler(this.AddOtherItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemnametextBox;
        private System.Windows.Forms.ComboBox unitcomboBox;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categorycomboBox;
    }
}