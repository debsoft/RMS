namespace BistroAdmin.UI
{
    partial class SupplierInformationForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.supplierNamecomboBox = new System.Windows.Forms.ComboBox();
            this.viewAllsuppliercheckBox = new System.Windows.Forms.CheckBox();
            this.supplierdataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printReportbutton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(255, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Supplier Name";
            // 
            // supplierNamecomboBox
            // 
            this.supplierNamecomboBox.FormattingEnabled = true;
            this.supplierNamecomboBox.Location = new System.Drawing.Point(361, 56);
            this.supplierNamecomboBox.Name = "supplierNamecomboBox";
            this.supplierNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.supplierNamecomboBox.TabIndex = 14;
            // 
            // viewAllsuppliercheckBox
            // 
            this.viewAllsuppliercheckBox.AutoSize = true;
            this.viewAllsuppliercheckBox.Location = new System.Drawing.Point(512, 58);
            this.viewAllsuppliercheckBox.Name = "viewAllsuppliercheckBox";
            this.viewAllsuppliercheckBox.Size = new System.Drawing.Size(63, 17);
            this.viewAllsuppliercheckBox.TabIndex = 50;
            this.viewAllsuppliercheckBox.Text = "View All";
            this.viewAllsuppliercheckBox.UseVisualStyleBackColor = true;
            // 
            // supplierdataGridView
            // 
            this.supplierdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.supplierdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.supplierdataGridView.Location = new System.Drawing.Point(50, 150);
            this.supplierdataGridView.Name = "supplierdataGridView";
            this.supplierdataGridView.Size = new System.Drawing.Size(714, 248);
            this.supplierdataGridView.TabIndex = 51;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SupplierId";
            this.Column1.HeaderText = "Supplier Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ContactInformation";
            this.Column3.HeaderText = "Contact Information";
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
            this.Column6.DataPropertyName = "DueAmount";
            this.Column6.HeaderText = "Due Amount";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "AdvanceAmount";
            this.Column7.HeaderText = "Advance Amount";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "PaymentType";
            this.Column8.HeaderText = "Payment Type";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // printReportbutton
            // 
            this.printReportbutton.Location = new System.Drawing.Point(50, 107);
            this.printReportbutton.Margin = new System.Windows.Forms.Padding(5);
            this.printReportbutton.Name = "printReportbutton";
            this.printReportbutton.Size = new System.Drawing.Size(125, 35);
            this.printReportbutton.TabIndex = 53;
            this.printReportbutton.Text = "Print";
            this.printReportbutton.UseVisualStyleBackColor = true;
            this.printReportbutton.Click += new System.EventHandler(this.printReportbutton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(374, 101);
            this.showButton.Margin = new System.Windows.Forms.Padding(5);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(125, 35);
            this.showButton.TabIndex = 52;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(303, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 24);
            this.label5.TabIndex = 112;
            this.label5.Text = "Supplier Information";
            // 
            // SupplierInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.label5);
            this.Controls.Add(this.printReportbutton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.supplierdataGridView);
            this.Controls.Add(this.viewAllsuppliercheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.supplierNamecomboBox);
            this.Name = "SupplierInformationForm";
            this.Size = new System.Drawing.Size(896, 418);
            ((System.ComponentModel.ISupportInitialize)(this.supplierdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox supplierNamecomboBox;
        private System.Windows.Forms.CheckBox viewAllsuppliercheckBox;
        private System.Windows.Forms.DataGridView supplierdataGridView;
        private System.Windows.Forms.Button printReportbutton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label5;
    }
}