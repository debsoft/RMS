namespace RMSAdmin.Purchase
{
    partial class OtherTransactionView
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
            this.otherdataGridView = new System.Windows.Forms.DataGridView();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showreportButton = new System.Windows.Forms.Button();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.printReportbutton = new System.Windows.Forms.Button();
            this.categorycomboBox = new System.Windows.Forms.ComboBox();
            this.categoryRadioButton = new System.Windows.Forms.RadioButton();
            this.transactionRadioButton = new System.Windows.Forms.RadioButton();
            this.transactionTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.otherdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // otherdataGridView
            // 
            this.otherdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherdataGridView.Location = new System.Drawing.Point(32, 152);
            this.otherdataGridView.Name = "otherdataGridView";
            this.otherdataGridView.Size = new System.Drawing.Size(868, 289);
            this.otherdataGridView.TabIndex = 11;
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(436, 27);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 10;
            // 
            // showreportButton
            // 
            this.showreportButton.Location = new System.Drawing.Point(554, 101);
            this.showreportButton.Name = "showreportButton";
            this.showreportButton.Size = new System.Drawing.Size(75, 23);
            this.showreportButton.TabIndex = 9;
            this.showreportButton.Text = "Show";
            this.showreportButton.UseVisualStyleBackColor = true;
            this.showreportButton.Click += new System.EventHandler(this.showreportButton_Click);
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(199, 27);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "From";
            // 
            // printReportbutton
            // 
            this.printReportbutton.Location = new System.Drawing.Point(50, 63);
            this.printReportbutton.Name = "printReportbutton";
            this.printReportbutton.Size = new System.Drawing.Size(75, 23);
            this.printReportbutton.TabIndex = 12;
            this.printReportbutton.Text = "Print";
            this.printReportbutton.UseVisualStyleBackColor = true;
            this.printReportbutton.Click += new System.EventHandler(this.printReportbutton_Click);
            // 
            // categorycomboBox
            // 
            this.categorycomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categorycomboBox.FormattingEnabled = true;
            this.categorycomboBox.Items.AddRange(new object[] {
            "Per Piece",
            "Per Pound",
            "Per Kg",
            "Per Ltr",
            "Per Gm",
            "Per Pac",
            "Per Glass",
            "Per ml",
            "Per Plate",
            "Per Cup",
            "Per Tin",
            "Per 500 mg",
            "Per 1.5 Ltr",
            "Per Can",
            "Per 250 ml",
            "Per Box",
            "Per Pot",
            "Per Pcs",
            "Per Kg",
            "Per Dozen"});
            this.categorycomboBox.Location = new System.Drawing.Point(277, 62);
            this.categorycomboBox.Name = "categorycomboBox";
            this.categorycomboBox.Size = new System.Drawing.Size(121, 21);
            this.categorycomboBox.TabIndex = 13;
            // 
            // categoryRadioButton
            // 
            this.categoryRadioButton.AutoSize = true;
            this.categoryRadioButton.Checked = true;
            this.categoryRadioButton.Location = new System.Drawing.Point(199, 63);
            this.categoryRadioButton.Name = "categoryRadioButton";
            this.categoryRadioButton.Size = new System.Drawing.Size(67, 17);
            this.categoryRadioButton.TabIndex = 14;
            this.categoryRadioButton.Text = "Category";
            this.categoryRadioButton.UseVisualStyleBackColor = true;
            this.categoryRadioButton.CheckedChanged += new System.EventHandler(this.categoryRadioButton_CheckedChanged);
            // 
            // transactionRadioButton
            // 
            this.transactionRadioButton.AutoSize = true;
            this.transactionRadioButton.Location = new System.Drawing.Point(413, 63);
            this.transactionRadioButton.Name = "transactionRadioButton";
            this.transactionRadioButton.Size = new System.Drawing.Size(81, 17);
            this.transactionRadioButton.TabIndex = 16;
            this.transactionRadioButton.Text = "Transaction";
            this.transactionRadioButton.UseVisualStyleBackColor = true;
            this.transactionRadioButton.CheckedChanged += new System.EventHandler(this.transactionRadioButton_CheckedChanged);
            // 
            // transactionTypeComboBox
            // 
            this.transactionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transactionTypeComboBox.Enabled = false;
            this.transactionTypeComboBox.FormattingEnabled = true;
            this.transactionTypeComboBox.Items.AddRange(new object[] {
            "Per Piece",
            "Per Pound",
            "Per Kg",
            "Per Ltr",
            "Per Gm",
            "Per Pac",
            "Per Glass",
            "Per ml",
            "Per Plate",
            "Per Cup",
            "Per Tin",
            "Per 500 mg",
            "Per 1.5 Ltr",
            "Per Can",
            "Per 250 ml",
            "Per Box",
            "Per Pot",
            "Per Pcs",
            "Per Kg",
            "Per Dozen"});
            this.transactionTypeComboBox.Location = new System.Drawing.Point(501, 62);
            this.transactionTypeComboBox.Name = "transactionTypeComboBox";
            this.transactionTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.transactionTypeComboBox.TabIndex = 15;
            // 
            // OtherTransactionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 505);
            this.Controls.Add(this.transactionRadioButton);
            this.Controls.Add(this.transactionTypeComboBox);
            this.Controls.Add(this.categoryRadioButton);
            this.Controls.Add(this.categorycomboBox);
            this.Controls.Add(this.printReportbutton);
            this.Controls.Add(this.otherdataGridView);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.showreportButton);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OtherTransactionView";
            this.Text = "OtherTransactionView";
            this.Load += new System.EventHandler(this.OtherTransactionView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.otherdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView otherdataGridView;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.Button showreportButton;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button printReportbutton;
        private System.Windows.Forms.ComboBox categorycomboBox;
        private System.Windows.Forms.RadioButton categoryRadioButton;
        private System.Windows.Forms.RadioButton transactionRadioButton;
        private System.Windows.Forms.ComboBox transactionTypeComboBox;
    }
}