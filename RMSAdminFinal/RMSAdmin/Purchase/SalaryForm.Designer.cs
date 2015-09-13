namespace RMSAdmin.Purchase
{
    partial class SalaryForm
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
            this.addemployeebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.findemployeebutton = new System.Windows.Forms.Button();
            this.employeedataGridView = new System.Windows.Forms.DataGridView();
            this.employeeNametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeePostion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeePId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.employeedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addemployeebutton
            // 
            this.addemployeebutton.Location = new System.Drawing.Point(669, 32);
            this.addemployeebutton.Name = "addemployeebutton";
            this.addemployeebutton.Size = new System.Drawing.Size(129, 37);
            this.addemployeebutton.TabIndex = 16;
            this.addemployeebutton.Text = "Add Employee";
            this.addemployeebutton.UseVisualStyleBackColor = true;
            this.addemployeebutton.Click += new System.EventHandler(this.addemployeebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "EmployeeName";
            // 
            // findemployeebutton
            // 
            this.findemployeebutton.Location = new System.Drawing.Point(519, 33);
            this.findemployeebutton.Name = "findemployeebutton";
            this.findemployeebutton.Size = new System.Drawing.Size(83, 27);
            this.findemployeebutton.TabIndex = 14;
            this.findemployeebutton.Text = "Search";
            this.findemployeebutton.UseVisualStyleBackColor = true;
            this.findemployeebutton.Click += new System.EventHandler(this.findemployeebutton_Click);
            // 
            // employeedataGridView
            // 
            this.employeedataGridView.AllowUserToAddRows = false;
            this.employeedataGridView.AllowUserToDeleteRows = false;
            this.employeedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeedataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeId,
            this.EmployeeName,
            this.EmployeePostion,
            this.EmployeePhone,
            this.EmployeeAddress,
            this.EmployeePId,
            this.TotalPaidAmount,
            this.LastPayDate,
            this.LastPaidAmount,
            this.Paid,
            this.Update,
            this.Delete});
            this.employeedataGridView.Location = new System.Drawing.Point(28, 162);
            this.employeedataGridView.Name = "employeedataGridView";
            this.employeedataGridView.ReadOnly = true;
            this.employeedataGridView.Size = new System.Drawing.Size(846, 303);
            this.employeedataGridView.TabIndex = 13;
            this.employeedataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeedataGridView_CellContentClick);
            // 
            // employeeNametextBox
            // 
            this.employeeNametextBox.Location = new System.Drawing.Point(289, 36);
            this.employeeNametextBox.Name = "employeeNametextBox";
            this.employeeNametextBox.Size = new System.Drawing.Size(206, 20);
            this.employeeNametextBox.TabIndex = 12;
            this.employeeNametextBox.TextChanged += new System.EventHandler(this.employeeNametextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(527, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "All Employee View ";
            // 
            // EmployeeId
            // 
            this.EmployeeId.DataPropertyName = "EmployeeId";
            this.EmployeeId.HeaderText = "Employee Id";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // EmployeePostion
            // 
            this.EmployeePostion.DataPropertyName = "EmployeePostion";
            this.EmployeePostion.HeaderText = "Employee Postion";
            this.EmployeePostion.Name = "EmployeePostion";
            this.EmployeePostion.ReadOnly = true;
            // 
            // EmployeePhone
            // 
            this.EmployeePhone.DataPropertyName = "EmployeePhone";
            this.EmployeePhone.HeaderText = "Employee Phone";
            this.EmployeePhone.Name = "EmployeePhone";
            this.EmployeePhone.ReadOnly = true;
            this.EmployeePhone.Visible = false;
            // 
            // EmployeeAddress
            // 
            this.EmployeeAddress.DataPropertyName = "EmployeeAddress";
            this.EmployeeAddress.HeaderText = "Employee Address";
            this.EmployeeAddress.Name = "EmployeeAddress";
            this.EmployeeAddress.ReadOnly = true;
            this.EmployeeAddress.Visible = false;
            // 
            // EmployeePId
            // 
            this.EmployeePId.DataPropertyName = "EmployeePId";
            this.EmployeePId.HeaderText = "Employee PId";
            this.EmployeePId.Name = "EmployeePId";
            this.EmployeePId.ReadOnly = true;
            this.EmployeePId.Visible = false;
            // 
            // TotalPaidAmount
            // 
            this.TotalPaidAmount.DataPropertyName = "TotalPaidAmount";
            this.TotalPaidAmount.HeaderText = "Total Amount";
            this.TotalPaidAmount.Name = "TotalPaidAmount";
            this.TotalPaidAmount.ReadOnly = true;
            this.TotalPaidAmount.Visible = false;
            // 
            // LastPayDate
            // 
            this.LastPayDate.DataPropertyName = "LastPayDate";
            this.LastPayDate.HeaderText = "Last Pay Date";
            this.LastPayDate.Name = "LastPayDate";
            this.LastPayDate.ReadOnly = true;
            // 
            // LastPaidAmount
            // 
            this.LastPaidAmount.DataPropertyName = "LastPaidAmount";
            this.LastPaidAmount.HeaderText = "Last Paid Amount";
            this.LastPaidAmount.MinimumWidth = 10;
            this.LastPaidAmount.Name = "LastPaidAmount";
            this.LastPaidAmount.ReadOnly = true;
            this.LastPaidAmount.Visible = false;
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "Paid";
            this.Paid.HeaderText = "Paid";
            this.Paid.Name = "Paid";
            this.Paid.ReadOnly = true;
            // 
            // Update
            // 
            this.Update.DataPropertyName = "Update";
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            this.Update.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // SalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 503);
            this.Controls.Add(this.addemployeebutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findemployeebutton);
            this.Controls.Add(this.employeedataGridView);
            this.Controls.Add(this.employeeNametextBox);
            this.Controls.Add(this.label2);
            this.Name = "SalaryForm";
            this.Text = "SalaryForm";
            ((System.ComponentModel.ISupportInitialize)(this.employeedataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addemployeebutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button findemployeebutton;
        private System.Windows.Forms.DataGridView employeedataGridView;
        private System.Windows.Forms.TextBox employeeNametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeePostion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeePId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPaidAmount;
        private System.Windows.Forms.DataGridViewButtonColumn Paid;
        private System.Windows.Forms.DataGridViewButtonColumn Update;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}