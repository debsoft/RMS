namespace BistroAdmin.UI
{
    partial class ItemCreateForm
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
            this.itemCreatelabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryNamecomboBox = new System.Windows.Forms.ComboBox();
            this.itemNametextBox = new System.Windows.Forms.TextBox();
            this.savebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.unitNamecomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // itemCreatelabel
            // 
            this.itemCreatelabel.AutoSize = true;
            this.itemCreatelabel.Location = new System.Drawing.Point(336, 293);
            this.itemCreatelabel.Name = "itemCreatelabel";
            this.itemCreatelabel.Size = new System.Drawing.Size(60, 13);
            this.itemCreatelabel.TabIndex = 13;
            this.itemCreatelabel.Text = "action........";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Category Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Item Name";
            // 
            // categoryNamecomboBox
            // 
            this.categoryNamecomboBox.FormattingEnabled = true;
            this.categoryNamecomboBox.Location = new System.Drawing.Point(296, 79);
            this.categoryNamecomboBox.Name = "categoryNamecomboBox";
            this.categoryNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryNamecomboBox.TabIndex = 0;
            // 
            // itemNametextBox
            // 
            this.itemNametextBox.Location = new System.Drawing.Point(296, 128);
            this.itemNametextBox.Name = "itemNametextBox";
            this.itemNametextBox.Size = new System.Drawing.Size(121, 20);
            this.itemNametextBox.TabIndex = 1;
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(321, 238);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 3;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Item Create";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Unit Name";
            // 
            // unitNamecomboBox
            // 
            this.unitNamecomboBox.FormattingEnabled = true;
            this.unitNamecomboBox.Location = new System.Drawing.Point(296, 172);
            this.unitNamecomboBox.Name = "unitNamecomboBox";
            this.unitNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.unitNamecomboBox.TabIndex = 2;
            // 
            // ItemCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unitNamecomboBox);
            this.Controls.Add(this.itemCreatelabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryNamecomboBox);
            this.Controls.Add(this.itemNametextBox);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.label1);
            this.Name = "ItemCreateForm";
            this.Size = new System.Drawing.Size(626, 364);
            this.Load += new System.EventHandler(this.ItemCreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemCreatelabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryNamecomboBox;
        private System.Windows.Forms.TextBox itemNametextBox;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox unitNamecomboBox;
    }
}