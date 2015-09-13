namespace RMS.SystemManagement
{
    partial class OtherGuestReservationForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.otherguestdataGridView = new System.Windows.Forms.DataGridView();
            this.additembutton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.itemunitpricetextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.itemnametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guestnumbertextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalamountlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.otherguestdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(299, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Item Information";
            // 
            // otherguestdataGridView
            // 
            this.otherguestdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherguestdataGridView.Location = new System.Drawing.Point(11, 172);
            this.otherguestdataGridView.Name = "otherguestdataGridView";
            this.otherguestdataGridView.Size = new System.Drawing.Size(701, 205);
            this.otherguestdataGridView.TabIndex = 27;
            this.otherguestdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.otherguestdataGridView_CellContentClick);
            // 
            // additembutton
            // 
            this.additembutton.Location = new System.Drawing.Point(539, 117);
            this.additembutton.Name = "additembutton";
            this.additembutton.Size = new System.Drawing.Size(75, 23);
            this.additembutton.TabIndex = 26;
            this.additembutton.Text = "Add Item";
            this.additembutton.UseVisualStyleBackColor = true;
            this.additembutton.Click += new System.EventHandler(this.additembutton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Unit Price";
            // 
            // itemunitpricetextBox
            // 
            this.itemunitpricetextBox.Location = new System.Drawing.Point(363, 119);
            this.itemunitpricetextBox.Name = "itemunitpricetextBox";
            this.itemunitpricetextBox.Size = new System.Drawing.Size(157, 20);
            this.itemunitpricetextBox.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Item Name";
            // 
            // itemnametextBox
            // 
            this.itemnametextBox.Location = new System.Drawing.Point(112, 119);
            this.itemnametextBox.Name = "itemnametextBox";
            this.itemnametextBox.Size = new System.Drawing.Size(157, 20);
            this.itemnametextBox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Number Of Guest";
            // 
            // guestnumbertextBox
            // 
            this.guestnumbertextBox.Location = new System.Drawing.Point(112, 76);
            this.guestnumbertextBox.Name = "guestnumbertextBox";
            this.guestnumbertextBox.Size = new System.Drawing.Size(157, 20);
            this.guestnumbertextBox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Other Guest Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Total Amount(Tk)";
            // 
            // totalamountlabel
            // 
            this.totalamountlabel.AutoSize = true;
            this.totalamountlabel.Location = new System.Drawing.Point(167, 415);
            this.totalamountlabel.Name = "totalamountlabel";
            this.totalamountlabel.Size = new System.Drawing.Size(28, 13);
            this.totalamountlabel.TabIndex = 33;
            this.totalamountlabel.Text = "0.00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OtherGuestReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 499);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.totalamountlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guestnumbertextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.otherguestdataGridView);
            this.Controls.Add(this.additembutton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.itemunitpricetextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.itemnametextBox);
            this.Name = "OtherGuestReservationForm";
            this.Text = "OtherGuestReservationForm";
            ((System.ComponentModel.ISupportInitialize)(this.otherguestdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView otherguestdataGridView;
        private System.Windows.Forms.Button additembutton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox itemunitpricetextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox itemnametextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox guestnumbertextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalamountlabel;
        private System.Windows.Forms.Button button1;
    }
}