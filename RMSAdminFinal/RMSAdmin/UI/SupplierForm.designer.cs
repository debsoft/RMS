namespace BistroAdmin.UI
{
    partial class SupplierForm
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
            this.supplierheadlinelabel = new System.Windows.Forms.Label();
            this.labell = new System.Windows.Forms.Label();
            this.supplierNametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contactInformationtextBox = new System.Windows.Forms.TextBox();
            this.supplierSavebutton = new System.Windows.Forms.Button();
            this.actionlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // supplierheadlinelabel
            // 
            this.supplierheadlinelabel.AutoSize = true;
            this.supplierheadlinelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierheadlinelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.supplierheadlinelabel.Location = new System.Drawing.Point(162, 38);
            this.supplierheadlinelabel.Name = "supplierheadlinelabel";
            this.supplierheadlinelabel.Size = new System.Drawing.Size(217, 31);
            this.supplierheadlinelabel.TabIndex = 10;
            this.supplierheadlinelabel.Text = "Create Supplier";
            // 
            // labell
            // 
            this.labell.AutoSize = true;
            this.labell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labell.Location = new System.Drawing.Point(149, 105);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(66, 24);
            this.labell.TabIndex = 11;
            this.labell.Text = "Name:";
            // 
            // supplierNametextBox
            // 
            this.supplierNametextBox.Location = new System.Drawing.Point(234, 105);
            this.supplierNametextBox.Name = "supplierNametextBox";
            this.supplierNametextBox.Size = new System.Drawing.Size(180, 20);
            this.supplierNametextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Contact Information:";
            // 
            // contactInformationtextBox
            // 
            this.contactInformationtextBox.Location = new System.Drawing.Point(234, 150);
            this.contactInformationtextBox.Multiline = true;
            this.contactInformationtextBox.Name = "contactInformationtextBox";
            this.contactInformationtextBox.Size = new System.Drawing.Size(180, 70);
            this.contactInformationtextBox.TabIndex = 1;
            // 
            // supplierSavebutton
            // 
            this.supplierSavebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierSavebutton.Location = new System.Drawing.Point(339, 245);
            this.supplierSavebutton.Name = "supplierSavebutton";
            this.supplierSavebutton.Size = new System.Drawing.Size(75, 34);
            this.supplierSavebutton.TabIndex = 2;
            this.supplierSavebutton.Text = "Save";
            this.supplierSavebutton.UseVisualStyleBackColor = true;
            this.supplierSavebutton.Click += new System.EventHandler(this.supplierSavebutton_Click);
            // 
            // actionlabel
            // 
            this.actionlabel.AutoSize = true;
            this.actionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.actionlabel.Location = new System.Drawing.Point(147, 301);
            this.actionlabel.Name = "actionlabel";
            this.actionlabel.Size = new System.Drawing.Size(147, 31);
            this.actionlabel.TabIndex = 7;
            this.actionlabel.Text = "action......";
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.actionlabel);
            this.Controls.Add(this.supplierSavebutton);
            this.Controls.Add(this.contactInformationtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplierNametextBox);
            this.Controls.Add(this.labell);
            this.Controls.Add(this.supplierheadlinelabel);
            this.Name = "SupplierForm";
            this.Size = new System.Drawing.Size(592, 411);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label supplierheadlinelabel;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.TextBox supplierNametextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox contactInformationtextBox;
        private System.Windows.Forms.Button supplierSavebutton;
        private System.Windows.Forms.Label actionlabel;
    }
}