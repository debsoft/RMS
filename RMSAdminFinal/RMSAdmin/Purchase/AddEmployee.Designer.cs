namespace RMSAdmin.Purchase
{
    partial class AddEmployee
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
            this.addEmployeebutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.employeePidtextBox = new System.Windows.Forms.TextBox();
            this.employeeNametextBox = new System.Windows.Forms.TextBox();
            this.employeePhonetextBox = new System.Windows.Forms.TextBox();
            this.employeeAddresstextBox = new System.Windows.Forms.TextBox();
            this.positiontextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Employee";
            // 
            // addEmployeebutton
            // 
            this.addEmployeebutton.Location = new System.Drawing.Point(484, 298);
            this.addEmployeebutton.Name = "addEmployeebutton";
            this.addEmployeebutton.Size = new System.Drawing.Size(75, 23);
            this.addEmployeebutton.TabIndex = 2;
            this.addEmployeebutton.Text = "Insert";
            this.addEmployeebutton.UseVisualStyleBackColor = true;
            this.addEmployeebutton.Click += new System.EventHandler(this.addEmployeebutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "PId";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Address";
            // 
            // employeePidtextBox
            // 
            this.employeePidtextBox.Location = new System.Drawing.Point(12, 342);
            this.employeePidtextBox.Name = "employeePidtextBox";
            this.employeePidtextBox.Size = new System.Drawing.Size(244, 20);
            this.employeePidtextBox.TabIndex = 7;
            this.employeePidtextBox.Visible = false;
            // 
            // employeeNametextBox
            // 
            this.employeeNametextBox.Location = new System.Drawing.Point(315, 76);
            this.employeeNametextBox.Name = "employeeNametextBox";
            this.employeeNametextBox.Size = new System.Drawing.Size(244, 20);
            this.employeeNametextBox.TabIndex = 8;
            // 
            // employeePhonetextBox
            // 
            this.employeePhonetextBox.Location = new System.Drawing.Point(315, 156);
            this.employeePhonetextBox.Name = "employeePhonetextBox";
            this.employeePhonetextBox.Size = new System.Drawing.Size(244, 20);
            this.employeePhonetextBox.TabIndex = 9;
            // 
            // employeeAddresstextBox
            // 
            this.employeeAddresstextBox.Location = new System.Drawing.Point(315, 188);
            this.employeeAddresstextBox.Multiline = true;
            this.employeeAddresstextBox.Name = "employeeAddresstextBox";
            this.employeeAddresstextBox.Size = new System.Drawing.Size(244, 76);
            this.employeeAddresstextBox.TabIndex = 10;
            // 
            // positiontextBox
            // 
            this.positiontextBox.Location = new System.Drawing.Point(315, 117);
            this.positiontextBox.Name = "positiontextBox";
            this.positiontextBox.Size = new System.Drawing.Size(244, 20);
            this.positiontextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Position";
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 413);
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
            this.Controls.Add(this.addEmployeebutton);
            this.Controls.Add(this.label1);
            this.Name = "AddEmployee";
            this.Text = "Add Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addEmployeebutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox employeePidtextBox;
        private System.Windows.Forms.TextBox employeeNametextBox;
        private System.Windows.Forms.TextBox employeePhonetextBox;
        private System.Windows.Forms.TextBox employeeAddresstextBox;
        private System.Windows.Forms.TextBox positiontextBox;
        private System.Windows.Forms.Label label6;
    }
}