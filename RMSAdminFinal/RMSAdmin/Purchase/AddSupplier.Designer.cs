namespace RMSAdmin.Purchase
{
    partial class AddSupplier
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
            this.supplierAddbutton = new System.Windows.Forms.Button();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.informationtextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // supplierAddbutton
            // 
            this.supplierAddbutton.Location = new System.Drawing.Point(310, 217);
            this.supplierAddbutton.Name = "supplierAddbutton";
            this.supplierAddbutton.Size = new System.Drawing.Size(75, 23);
            this.supplierAddbutton.TabIndex = 1;
            this.supplierAddbutton.Text = "Create";
            this.supplierAddbutton.UseVisualStyleBackColor = true;
            this.supplierAddbutton.Click += new System.EventHandler(this.supplierAddbutton_Click);
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(228, 78);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(222, 20);
            this.NametextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Information";
            // 
            // informationtextBox
            // 
            this.informationtextBox.Location = new System.Drawing.Point(228, 127);
            this.informationtextBox.Multiline = true;
            this.informationtextBox.Name = "informationtextBox";
            this.informationtextBox.Size = new System.Drawing.Size(222, 69);
            this.informationtextBox.TabIndex = 4;
            // 
            // AddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 363);
            this.Controls.Add(this.informationtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NametextBox);
            this.Controls.Add(this.supplierAddbutton);
            this.Controls.Add(this.label1);
            this.Name = "AddSupplier";
            this.Text = "AddSupplier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button supplierAddbutton;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox informationtextBox;
    }
}