namespace RMSAdmin.Purchase
{
    partial class EmployeeSalaryReport
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
            this.employeereportdataGridView = new System.Windows.Forms.DataGridView();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showreportButton = new System.Windows.Forms.Button();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.employeecheckBox = new System.Windows.Forms.CheckBox();
            this.employeecomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.printreportButton = new System.Windows.Forms.Button();
            this.yearcomboBox = new System.Windows.Forms.ComboBox();
            this.monthcomboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeereportdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // employeereportdataGridView
            // 
            this.employeereportdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeereportdataGridView.Location = new System.Drawing.Point(81, 164);
            this.employeereportdataGridView.Name = "employeereportdataGridView";
            this.employeereportdataGridView.Size = new System.Drawing.Size(868, 289);
            this.employeereportdataGridView.TabIndex = 23;
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(537, 9);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 22;
            this.todateTimePicker.Visible = false;
            // 
            // showreportButton
            // 
            this.showreportButton.Location = new System.Drawing.Point(488, 123);
            this.showreportButton.Name = "showreportButton";
            this.showreportButton.Size = new System.Drawing.Size(75, 23);
            this.showreportButton.TabIndex = 21;
            this.showreportButton.Text = "Show";
            this.showreportButton.UseVisualStyleBackColor = true;
            this.showreportButton.Click += new System.EventHandler(this.showreportButton_Click);
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(300, 9);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 20;
            this.fromdateTimePicker.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "To";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "From";
            this.label1.Visible = false;
            // 
            // employeecheckBox
            // 
            this.employeecheckBox.AutoSize = true;
            this.employeecheckBox.Location = new System.Drawing.Point(602, 88);
            this.employeecheckBox.Name = "employeecheckBox";
            this.employeecheckBox.Size = new System.Drawing.Size(105, 17);
            this.employeecheckBox.TabIndex = 24;
            this.employeecheckBox.Text = "Active Employee";
            this.employeecheckBox.UseVisualStyleBackColor = true;
            // 
            // employeecomboBox
            // 
            this.employeecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeecomboBox.FormattingEnabled = true;
            this.employeecomboBox.Location = new System.Drawing.Point(464, 85);
            this.employeecomboBox.Name = "employeecomboBox";
            this.employeecomboBox.Size = new System.Drawing.Size(121, 21);
            this.employeecomboBox.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Employee Name";
            // 
            // printreportButton
            // 
            this.printreportButton.Location = new System.Drawing.Point(81, 123);
            this.printreportButton.Name = "printreportButton";
            this.printreportButton.Size = new System.Drawing.Size(75, 23);
            this.printreportButton.TabIndex = 27;
            this.printreportButton.Text = "Print";
            this.printreportButton.UseVisualStyleBackColor = true;
            this.printreportButton.Click += new System.EventHandler(this.printreportButton_Click);
            // 
            // yearcomboBox
            // 
            this.yearcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearcomboBox.FormattingEnabled = true;
            this.yearcomboBox.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.yearcomboBox.Location = new System.Drawing.Point(613, 46);
            this.yearcomboBox.Name = "yearcomboBox";
            this.yearcomboBox.Size = new System.Drawing.Size(121, 28);
            this.yearcomboBox.TabIndex = 30;
            // 
            // monthcomboBox
            // 
            this.monthcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthcomboBox.FormattingEnabled = true;
            this.monthcomboBox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthcomboBox.Location = new System.Drawing.Point(475, 46);
            this.monthcomboBox.Name = "monthcomboBox";
            this.monthcomboBox.Size = new System.Drawing.Size(121, 28);
            this.monthcomboBox.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(322, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Paid Salary Month";
            // 
            // EmployeeSalaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 506);
            this.Controls.Add(this.yearcomboBox);
            this.Controls.Add(this.monthcomboBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.printreportButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.employeecomboBox);
            this.Controls.Add(this.employeecheckBox);
            this.Controls.Add(this.employeereportdataGridView);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.showreportButton);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EmployeeSalaryReport";
            this.Text = "EmployeeSalaryReport";
            ((System.ComponentModel.ISupportInitialize)(this.employeereportdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView employeereportdataGridView;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.Button showreportButton;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox employeecheckBox;
        private System.Windows.Forms.ComboBox employeecomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button printreportButton;
        private System.Windows.Forms.ComboBox yearcomboBox;
        private System.Windows.Forms.ComboBox monthcomboBox;
        private System.Windows.Forms.Label label12;
    }
}