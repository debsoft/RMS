namespace RMSAdmin.Purchase
{
    partial class UpdateEmployee
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
            this.employeeAddresstextBox = new System.Windows.Forms.TextBox();
            this.employeePhonetextBox = new System.Windows.Forms.TextBox();
            this.employeeNametextBox = new System.Windows.Forms.TextBox();
            this.employeePidtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateEmployeebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.positiontextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // employeeAddresstextBox
            // 
            this.employeeAddresstextBox.Location = new System.Drawing.Point(263, 238);
            this.employeeAddresstextBox.Multiline = true;
            this.employeeAddresstextBox.Name = "employeeAddresstextBox";
            this.employeeAddresstextBox.Size = new System.Drawing.Size(244, 76);
            this.employeeAddresstextBox.TabIndex = 20;
            // 
            // employeePhonetextBox
            // 
            this.employeePhonetextBox.Location = new System.Drawing.Point(263, 206);
            this.employeePhonetextBox.Name = "employeePhonetextBox";
            this.employeePhonetextBox.Size = new System.Drawing.Size(244, 20);
            this.employeePhonetextBox.TabIndex = 19;
            // 
            // employeeNametextBox
            // 
            this.employeeNametextBox.Location = new System.Drawing.Point(263, 123);
            this.employeeNametextBox.Name = "employeeNametextBox";
            this.employeeNametextBox.Size = new System.Drawing.Size(244, 20);
            this.employeeNametextBox.TabIndex = 18;
            // 
            // employeePidtextBox
            // 
            this.employeePidtextBox.Location = new System.Drawing.Point(97, 12);
            this.employeePidtextBox.Name = "employeePidtextBox";
            this.employeePidtextBox.Size = new System.Drawing.Size(244, 20);
            this.employeePidtextBox.TabIndex = 17;
            this.employeePidtextBox.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "PId";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name";
            // 
            // UpdateEmployeebutton
            // 
            this.UpdateEmployeebutton.Location = new System.Drawing.Point(432, 348);
            this.UpdateEmployeebutton.Name = "UpdateEmployeebutton";
            this.UpdateEmployeebutton.Size = new System.Drawing.Size(75, 23);
            this.UpdateEmployeebutton.TabIndex = 12;
            this.UpdateEmployeebutton.Text = "Update";
            this.UpdateEmployeebutton.UseVisualStyleBackColor = true;
            this.UpdateEmployeebutton.Click += new System.EventHandler(this.UpdateEmployeebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Update Employee";
            // 
            // positiontextBox
            // 
            this.positiontextBox.Location = new System.Drawing.Point(263, 166);
            this.positiontextBox.Name = "positiontextBox";
            this.positiontextBox.Size = new System.Drawing.Size(244, 20);
            this.positiontextBox.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Position";
            // 
            // UpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 448);
            this.Controls.Add(this.positiontextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.employeeAddresstextBox);
            this.Controls.Add(this.employeePhonetextBox);
            this.Controls.Add(this.employeeNametextBox);
            this.Controls.Add(this.employeePidtextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpdateEmployeebutton);
            this.Controls.Add(this.label1);
            this.Name = "UpdateEmployee";
            this.Text = "UpdateEmployee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdateEmployeebutton;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox employeeAddresstextBox;
        public System.Windows.Forms.TextBox employeePhonetextBox;
        public System.Windows.Forms.TextBox employeeNametextBox;
        public System.Windows.Forms.TextBox employeePidtextBox;
        public System.Windows.Forms.TextBox positiontextBox;
        private System.Windows.Forms.Label label6;
    }
}