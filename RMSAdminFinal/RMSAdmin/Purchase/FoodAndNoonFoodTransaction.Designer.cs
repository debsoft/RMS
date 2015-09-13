namespace RMSAdmin.Purchase
{
    partial class FoodAndNoonFoodTransaction
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
            this.label2 = new System.Windows.Forms.Label();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showreportButton = new System.Windows.Forms.Button();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fooddataGridView = new System.Windows.Forms.DataGridView();
            this.printReportbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.categorycomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fooddataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(237, 26);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 2;
            // 
            // showreportButton
            // 
            this.showreportButton.Location = new System.Drawing.Point(561, 71);
            this.showreportButton.Name = "showreportButton";
            this.showreportButton.Size = new System.Drawing.Size(75, 23);
            this.showreportButton.TabIndex = 3;
            this.showreportButton.Text = "Show";
            this.showreportButton.UseVisualStyleBackColor = true;
            this.showreportButton.Click += new System.EventHandler(this.showreportButton_Click);
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(474, 26);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 4;
            // 
            // fooddataGridView
            // 
            this.fooddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fooddataGridView.Location = new System.Drawing.Point(46, 140);
            this.fooddataGridView.Name = "fooddataGridView";
            this.fooddataGridView.Size = new System.Drawing.Size(868, 289);
            this.fooddataGridView.TabIndex = 5;
            // 
            // printReportbutton
            // 
            this.printReportbutton.Location = new System.Drawing.Point(46, 51);
            this.printReportbutton.Name = "printReportbutton";
            this.printReportbutton.Size = new System.Drawing.Size(75, 23);
            this.printReportbutton.TabIndex = 6;
            this.printReportbutton.Text = "Print";
            this.printReportbutton.UseVisualStyleBackColor = true;
            this.printReportbutton.Click += new System.EventHandler(this.printReportbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Category";
            // 
            // categorycomboBox
            // 
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
            this.categorycomboBox.Location = new System.Drawing.Point(384, 68);
            this.categorycomboBox.Name = "categorycomboBox";
            this.categorycomboBox.Size = new System.Drawing.Size(121, 21);
            this.categorycomboBox.TabIndex = 15;
            // 
            // FoodAndNoonFoodTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 458);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categorycomboBox);
            this.Controls.Add(this.printReportbutton);
            this.Controls.Add(this.fooddataGridView);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.showreportButton);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FoodAndNoonFoodTransaction";
            this.Text = "FoodAndNoonFoodTransaction";
            this.Load += new System.EventHandler(this.FoodAndNoonFoodTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fooddataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Button showreportButton;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.DataGridView fooddataGridView;
        private System.Windows.Forms.Button printReportbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categorycomboBox;
    }
}