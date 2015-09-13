namespace BistroAdmin.UI
{
    partial class ItemUpdateForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.closebutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.unitNamecomboBox = new System.Windows.Forms.ComboBox();
            this.updatestatuslabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryNamecomboBox = new System.Windows.Forms.ComboBox();
            this.itemNametextBox = new System.Windows.Forms.TextBox();
            this.updatebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.closebutton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.unitNamecomboBox);
            this.groupBox1.Controls.Add(this.updatestatuslabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.categoryNamecomboBox);
            this.groupBox1.Controls.Add(this.itemNametextBox);
            this.groupBox1.Controls.Add(this.updatebutton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(49, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Raw Materials";
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(328, 246);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(75, 23);
            this.closebutton.TabIndex = 25;
            this.closebutton.Text = "Close";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Unit Name";
            // 
            // unitNamecomboBox
            // 
            this.unitNamecomboBox.FormattingEnabled = true;
            this.unitNamecomboBox.Location = new System.Drawing.Point(250, 174);
            this.unitNamecomboBox.Name = "unitNamecomboBox";
            this.unitNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.unitNamecomboBox.TabIndex = 18;
            // 
            // updatestatuslabel
            // 
            this.updatestatuslabel.AutoSize = true;
            this.updatestatuslabel.Location = new System.Drawing.Point(260, 219);
            this.updatestatuslabel.Name = "updatestatuslabel";
            this.updatestatuslabel.Size = new System.Drawing.Size(60, 13);
            this.updatestatuslabel.TabIndex = 23;
            this.updatestatuslabel.Text = "action........";
            this.updatestatuslabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Category Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Item Name";
            // 
            // categoryNamecomboBox
            // 
            this.categoryNamecomboBox.FormattingEnabled = true;
            this.categoryNamecomboBox.Location = new System.Drawing.Point(250, 81);
            this.categoryNamecomboBox.Name = "categoryNamecomboBox";
            this.categoryNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryNamecomboBox.TabIndex = 16;
            // 
            // itemNametextBox
            // 
            this.itemNametextBox.Location = new System.Drawing.Point(250, 130);
            this.itemNametextBox.Name = "itemNametextBox";
            this.itemNametextBox.Size = new System.Drawing.Size(121, 20);
            this.itemNametextBox.TabIndex = 17;
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(232, 246);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(75, 23);
            this.updatebutton.TabIndex = 19;
            this.updatebutton.Text = "Update";
            this.updatebutton.UseVisualStyleBackColor = true;
            this.updatebutton.Click += new System.EventHandler(this.updatebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Item Update";
            // 
            // ItemUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemUpdateForm";
            this.Size = new System.Drawing.Size(644, 417);
            this.Load += new System.EventHandler(this.ItemUpdateForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox unitNamecomboBox;
        private System.Windows.Forms.Label updatestatuslabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryNamecomboBox;
        private System.Windows.Forms.TextBox itemNametextBox;
        private System.Windows.Forms.Button updatebutton;
        private System.Windows.Forms.Label label1;

    }
}
