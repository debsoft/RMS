namespace BistroAdmin.UI
{
    partial class SupplierPaymentReportForm
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
            this.paymentcheckBox = new System.Windows.Forms.CheckBox();
            this.paymentTypecomboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.printRawmaterialsReportbutton = new System.Windows.Forms.Button();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.supplierdatapaymentGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewAllsuppliercheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.supplierNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierdatapaymentGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentcheckBox
            // 
            this.paymentcheckBox.AutoSize = true;
            this.paymentcheckBox.Location = new System.Drawing.Point(743, 148);
            this.paymentcheckBox.Name = "paymentcheckBox";
            this.paymentcheckBox.Size = new System.Drawing.Size(127, 17);
            this.paymentcheckBox.TabIndex = 106;
            this.paymentcheckBox.Text = "Active Payment Type";
            this.paymentcheckBox.UseVisualStyleBackColor = true;
            // 
            // paymentTypecomboBox
            // 
            this.paymentTypecomboBox.FormattingEnabled = true;
            this.paymentTypecomboBox.Location = new System.Drawing.Point(503, 146);
            this.paymentTypecomboBox.Margin = new System.Windows.Forms.Padding(5);
            this.paymentTypecomboBox.Name = "paymentTypecomboBox";
            this.paymentTypecomboBox.Size = new System.Drawing.Size(199, 21);
            this.paymentTypecomboBox.TabIndex = 105;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 104;
            this.label8.Text = "Payment Type";
            // 
            // printRawmaterialsReportbutton
            // 
            this.printRawmaterialsReportbutton.Location = new System.Drawing.Point(113, 192);
            this.printRawmaterialsReportbutton.Margin = new System.Windows.Forms.Padding(5);
            this.printRawmaterialsReportbutton.Name = "printRawmaterialsReportbutton";
            this.printRawmaterialsReportbutton.Size = new System.Drawing.Size(125, 35);
            this.printRawmaterialsReportbutton.TabIndex = 103;
            this.printRawmaterialsReportbutton.Text = "Print";
            this.printRawmaterialsReportbutton.UseVisualStyleBackColor = true;
            this.printRawmaterialsReportbutton.Click += new System.EventHandler(this.printRawmaterialsReportbutton_Click);
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(651, 66);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 100;
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(349, 66);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 99;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(582, 192);
            this.showButton.Margin = new System.Windows.Forms.Padding(5);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(125, 35);
            this.showButton.TabIndex = 89;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "To Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "From Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 93;
            // 
            // supplierdatapaymentGridView
            // 
            this.supplierdatapaymentGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.supplierdatapaymentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierdatapaymentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.supplierdatapaymentGridView.Location = new System.Drawing.Point(113, 237);
            this.supplierdatapaymentGridView.Name = "supplierdatapaymentGridView";
            this.supplierdatapaymentGridView.Size = new System.Drawing.Size(714, 259);
            this.supplierdatapaymentGridView.TabIndex = 107;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SupplierPaymentReportId";
            this.Column1.HeaderText = "Report Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PaymentDate";
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SupplierName";
            this.Column3.HeaderText = "Supplier Name";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TotalAmount";
            this.Column4.HeaderText = "Total Amount";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "PaidAmount";
            this.Column5.HeaderText = "Paid Amount";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PaymentType";
            this.Column6.HeaderText = "Payment Type";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "UserName";
            this.Column7.HeaderText = "UserName ";
            this.Column7.Name = "Column7";
            // 
            // viewAllsuppliercheckBox
            // 
            this.viewAllsuppliercheckBox.AutoSize = true;
            this.viewAllsuppliercheckBox.Location = new System.Drawing.Point(743, 102);
            this.viewAllsuppliercheckBox.Name = "viewAllsuppliercheckBox";
            this.viewAllsuppliercheckBox.Size = new System.Drawing.Size(63, 17);
            this.viewAllsuppliercheckBox.TabIndex = 110;
            this.viewAllsuppliercheckBox.Text = "View All";
            this.viewAllsuppliercheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 109;
            this.label1.Text = "Supplier Name";
            // 
            // supplierNamecomboBox
            // 
            this.supplierNamecomboBox.FormattingEnabled = true;
            this.supplierNamecomboBox.Location = new System.Drawing.Point(503, 103);
            this.supplierNamecomboBox.Name = "supplierNamecomboBox";
            this.supplierNamecomboBox.Size = new System.Drawing.Size(199, 21);
            this.supplierNamecomboBox.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(419, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 24);
            this.label5.TabIndex = 111;
            this.label5.Text = "Supplier Payment Report";
            // 
            // SupplierPaymentReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.label5);
            this.Controls.Add(this.viewAllsuppliercheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplierNamecomboBox);
            this.Controls.Add(this.supplierdatapaymentGridView);
            this.Controls.Add(this.paymentcheckBox);
            this.Controls.Add(this.paymentTypecomboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.printRawmaterialsReportbutton);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "SupplierPaymentReportForm";
            this.Size = new System.Drawing.Size(988, 499);
            ((System.ComponentModel.ISupportInitialize)(this.supplierdatapaymentGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox paymentcheckBox;
        private System.Windows.Forms.ComboBox paymentTypecomboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button printRawmaterialsReportbutton;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView supplierdatapaymentGridView;
        private System.Windows.Forms.CheckBox viewAllsuppliercheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox supplierNamecomboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label5;
    }
}