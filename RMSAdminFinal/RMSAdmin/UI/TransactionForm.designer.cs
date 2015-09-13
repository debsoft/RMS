namespace BistroAdmin.UI
{
    partial class TransactionForm
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
            this.unittypelabel = new System.Windows.Forms.Label();
            this.transactionActionlabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stocklabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.transactionTypecomboBox = new System.Windows.Forms.ComboBox();
            this.itemNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.quantitytextBox = new System.Windows.Forms.TextBox();
            this.saveTransactionbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.damagelabel = new System.Windows.Forms.Label();
            this.danmagetextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // unittypelabel
            // 
            this.unittypelabel.AutoSize = true;
            this.unittypelabel.Location = new System.Drawing.Point(448, 220);
            this.unittypelabel.Name = "unittypelabel";
            this.unittypelabel.Size = new System.Drawing.Size(24, 13);
            this.unittypelabel.TabIndex = 34;
            this.unittypelabel.Text = "unit";
            // 
            // transactionActionlabel
            // 
            this.transactionActionlabel.AutoSize = true;
            this.transactionActionlabel.Location = new System.Drawing.Point(330, 389);
            this.transactionActionlabel.Name = "transactionActionlabel";
            this.transactionActionlabel.Size = new System.Drawing.Size(48, 13);
            this.transactionActionlabel.TabIndex = 33;
            this.transactionActionlabel.Text = "acion.....";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(223, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Quantity";
            // 
            // stocklabel
            // 
            this.stocklabel.AutoSize = true;
            this.stocklabel.Location = new System.Drawing.Point(448, 183);
            this.stocklabel.Name = "stocklabel";
            this.stocklabel.Size = new System.Drawing.Size(69, 13);
            this.stocklabel.TabIndex = 29;
            this.stocklabel.Text = "current stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Transaction Type";
            // 
            // transactionTypecomboBox
            // 
            this.transactionTypecomboBox.FormattingEnabled = true;
            this.transactionTypecomboBox.Location = new System.Drawing.Point(294, 180);
            this.transactionTypecomboBox.Name = "transactionTypecomboBox";
            this.transactionTypecomboBox.Size = new System.Drawing.Size(121, 21);
            this.transactionTypecomboBox.TabIndex = 2;
            this.transactionTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.transactionTypecomboBox_SelectedIndexChanged);
            // 
            // itemNamecomboBox
            // 
            this.itemNamecomboBox.FormattingEnabled = true;
            this.itemNamecomboBox.Location = new System.Drawing.Point(294, 135);
            this.itemNamecomboBox.Name = "itemNamecomboBox";
            this.itemNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.itemNamecomboBox.TabIndex = 1;
            this.itemNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.itemNamecomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Item Name";
            // 
            // categoryNamecomboBox
            // 
            this.categoryNamecomboBox.FormattingEnabled = true;
            this.categoryNamecomboBox.Location = new System.Drawing.Point(294, 86);
            this.categoryNamecomboBox.Name = "categoryNamecomboBox";
            this.categoryNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryNamecomboBox.TabIndex = 0;
            this.categoryNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.categoryNamecomboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Category Name";
            // 
            // quantitytextBox
            // 
            this.quantitytextBox.Location = new System.Drawing.Point(294, 220);
            this.quantitytextBox.Name = "quantitytextBox";
            this.quantitytextBox.Size = new System.Drawing.Size(121, 20);
            this.quantitytextBox.TabIndex = 3;
            // 
            // saveTransactionbutton
            // 
            this.saveTransactionbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTransactionbutton.Location = new System.Drawing.Point(349, 336);
            this.saveTransactionbutton.Name = "saveTransactionbutton";
            this.saveTransactionbutton.Size = new System.Drawing.Size(75, 23);
            this.saveTransactionbutton.TabIndex = 5;
            this.saveTransactionbutton.Text = "Save";
            this.saveTransactionbutton.UseVisualStyleBackColor = true;
            this.saveTransactionbutton.Click += new System.EventHandler(this.saveTransactionbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Inventory Transaction ";
            // 
            // damagelabel
            // 
            this.damagelabel.AutoSize = true;
            this.damagelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damagelabel.Location = new System.Drawing.Point(224, 270);
            this.damagelabel.Name = "damagelabel";
            this.damagelabel.Size = new System.Drawing.Size(45, 13);
            this.damagelabel.TabIndex = 35;
            this.damagelabel.Text = "Report";
            this.damagelabel.Visible = false;
            // 
            // danmagetextBox
            // 
            this.danmagetextBox.Location = new System.Drawing.Point(294, 263);
            this.danmagetextBox.Multiline = true;
            this.danmagetextBox.Name = "danmagetextBox";
            this.danmagetextBox.Size = new System.Drawing.Size(310, 52);
            this.danmagetextBox.TabIndex = 4;
            this.danmagetextBox.Visible = false;
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.danmagetextBox);
            this.Controls.Add(this.damagelabel);
            this.Controls.Add(this.unittypelabel);
            this.Controls.Add(this.transactionActionlabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stocklabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.transactionTypecomboBox);
            this.Controls.Add(this.itemNamecomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.categoryNamecomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantitytextBox);
            this.Controls.Add(this.saveTransactionbutton);
            this.Controls.Add(this.label1);
            this.Name = "TransactionForm";
            this.Size = new System.Drawing.Size(716, 454);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label unittypelabel;
        private System.Windows.Forms.Label transactionActionlabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label stocklabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox transactionTypecomboBox;
        private System.Windows.Forms.ComboBox itemNamecomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox categoryNamecomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantitytextBox;
        private System.Windows.Forms.Button saveTransactionbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label damagelabel;
        private System.Windows.Forms.TextBox danmagetextBox;
    }
}