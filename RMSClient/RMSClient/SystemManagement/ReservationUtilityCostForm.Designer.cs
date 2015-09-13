namespace RMS.SystemManagement
{
    partial class ReservationUtilityCostForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.totalamountlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.utilitycostdataGridView = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.itemunitpricetextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.itemnametextBox = new System.Windows.Forms.TextBox();
            this.additembutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.utilitycostdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // totalamountlabel
            // 
            this.totalamountlabel.AutoSize = true;
            this.totalamountlabel.Location = new System.Drawing.Point(174, 364);
            this.totalamountlabel.Name = "totalamountlabel";
            this.totalamountlabel.Size = new System.Drawing.Size(28, 13);
            this.totalamountlabel.TabIndex = 45;
            this.totalamountlabel.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Total Amount(Tk)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Utility Cost Information";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(306, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Item Information";
            // 
            // utilitycostdataGridView
            // 
            this.utilitycostdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.utilitycostdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.utilitycostdataGridView.Location = new System.Drawing.Point(18, 121);
            this.utilitycostdataGridView.Name = "utilitycostdataGridView";
            this.utilitycostdataGridView.Size = new System.Drawing.Size(701, 205);
            this.utilitycostdataGridView.TabIndex = 39;
            this.utilitycostdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.utilitycostdataGridView_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(312, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Price";
            // 
            // itemunitpricetextBox
            // 
            this.itemunitpricetextBox.Location = new System.Drawing.Point(360, 68);
            this.itemunitpricetextBox.Name = "itemunitpricetextBox";
            this.itemunitpricetextBox.Size = new System.Drawing.Size(157, 20);
            this.itemunitpricetextBox.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Item Type";
            // 
            // itemnametextBox
            // 
            this.itemnametextBox.Location = new System.Drawing.Point(119, 68);
            this.itemnametextBox.Name = "itemnametextBox";
            this.itemnametextBox.Size = new System.Drawing.Size(157, 20);
            this.itemnametextBox.TabIndex = 35;
            // 
            // additembutton
            // 
            this.additembutton.Location = new System.Drawing.Point(537, 67);
            this.additembutton.Name = "additembutton";
            this.additembutton.Size = new System.Drawing.Size(75, 23);
            this.additembutton.TabIndex = 47;
            this.additembutton.Text = "Add Item";
            this.additembutton.UseVisualStyleBackColor = true;
            this.additembutton.Click += new System.EventHandler(this.additembutton_Click);
            // 
            // ReservationUtilityCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 470);
            this.Controls.Add(this.additembutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.totalamountlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.utilitycostdataGridView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.itemunitpricetextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.itemnametextBox);
            this.Name = "ReservationUtilityCostForm";
            this.Text = "ReservationUtilityCostForm";
            ((System.ComponentModel.ISupportInitialize)(this.utilitycostdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label totalamountlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView utilitycostdataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox itemunitpricetextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox itemnametextBox;
        private System.Windows.Forms.Button additembutton;
    }
}