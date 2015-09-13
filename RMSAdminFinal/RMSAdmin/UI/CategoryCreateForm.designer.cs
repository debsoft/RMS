namespace BistroAdmin.UI
{
    partial class CategoryCreateForm
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
            this.savebutton = new System.Windows.Forms.Button();
            this.categoryNametextBox = new System.Windows.Forms.TextBox();
            this.unitNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryCreatelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Category Create";
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(168, 185);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 1;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // categoryNametextBox
            // 
            this.categoryNametextBox.Location = new System.Drawing.Point(155, 81);
            this.categoryNametextBox.Name = "categoryNametextBox";
            this.categoryNametextBox.Size = new System.Drawing.Size(100, 20);
            this.categoryNametextBox.TabIndex = 0;
            // 
            // unitNamecomboBox
            // 
            this.unitNamecomboBox.FormattingEnabled = true;
            this.unitNamecomboBox.Location = new System.Drawing.Point(155, 130);
            this.unitNamecomboBox.Name = "unitNamecomboBox";
            this.unitNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.unitNamecomboBox.TabIndex = 3;
            this.unitNamecomboBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Category Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Unit Name";
            this.label3.Visible = false;
            // 
            // categoryCreatelabel
            // 
            this.categoryCreatelabel.AutoSize = true;
            this.categoryCreatelabel.Location = new System.Drawing.Point(174, 242);
            this.categoryCreatelabel.Name = "categoryCreatelabel";
            this.categoryCreatelabel.Size = new System.Drawing.Size(60, 13);
            this.categoryCreatelabel.TabIndex = 6;
            this.categoryCreatelabel.Text = "action........";
            // 
            // CategoryCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.categoryCreatelabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.unitNamecomboBox);
            this.Controls.Add(this.categoryNametextBox);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.label1);
            this.Name = "CategoryCreateForm";
            this.Size = new System.Drawing.Size(454, 317);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.TextBox categoryNametextBox;
        private System.Windows.Forms.ComboBox unitNamecomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label categoryCreatelabel;
    }
}