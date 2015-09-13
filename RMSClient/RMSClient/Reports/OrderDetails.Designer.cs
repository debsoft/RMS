namespace RMS.Reports
{
    partial class OrderDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetails));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lelOrderID = new System.Windows.Forms.Label();
            this.lelOrderInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.duebillPaymentButton = new RMSUI.FunctionalButton();
            this.btnPrintGuestBill = new RMSUI.FunctionalButton();
            this.btnBack = new RMSUI.FunctionalButton();
            this.dgvOrderDetails = new RMSUI.SimpleGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Item details";
            // 
            // lelOrderID
            // 
            this.lelOrderID.AutoSize = true;
            this.lelOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelOrderID.Location = new System.Drawing.Point(10, 7);
            this.lelOrderID.Name = "lelOrderID";
            this.lelOrderID.Size = new System.Drawing.Size(88, 20);
            this.lelOrderID.TabIndex = 6;
            this.lelOrderID.Text = "Order ID :";
            // 
            // lelOrderInfo
            // 
            this.lelOrderInfo.AutoSize = true;
            this.lelOrderInfo.Location = new System.Drawing.Point(13, 35);
            this.lelOrderInfo.Name = "lelOrderInfo";
            this.lelOrderInfo.Size = new System.Drawing.Size(38, 13);
            this.lelOrderInfo.TabIndex = 7;
            this.lelOrderInfo.Text = "label 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label 1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.duebillPaymentButton);
            this.panel1.Controls.Add(this.btnPrintGuestBill);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 52);
            this.panel1.TabIndex = 10;
            // 
            // duebillPaymentButton
            // 
            this.duebillPaymentButton.BackColor = System.Drawing.Color.LightGray;
            this.duebillPaymentButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("duebillPaymentButton.BackgroundImage")));
            this.duebillPaymentButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("duebillPaymentButton.BgImageOnMouseDown")));
            this.duebillPaymentButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("duebillPaymentButton.BgImageOnMouseUp")));
            this.duebillPaymentButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.duebillPaymentButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.duebillPaymentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.duebillPaymentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.duebillPaymentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.duebillPaymentButton.Font = new System.Drawing.Font("Arial", 10F);
            this.duebillPaymentButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.duebillPaymentButton.ForeColorOnMouseDown = System.Drawing.Color.Black;
            this.duebillPaymentButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.duebillPaymentButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.duebillPaymentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.duebillPaymentButton.Location = new System.Drawing.Point(305, 7);
            this.duebillPaymentButton.Name = "duebillPaymentButton";
            this.duebillPaymentButton.Size = new System.Drawing.Size(114, 38);
            this.duebillPaymentButton.TabIndex = 7;
            this.duebillPaymentButton.Text = "Due Payment";
            this.duebillPaymentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.duebillPaymentButton.UseVisualStyleBackColor = false;
            this.duebillPaymentButton.Click += new System.EventHandler(this.duebillPaymentButton_Click);
            // 
            // btnPrintGuestBill
            // 
            this.btnPrintGuestBill.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintGuestBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.BackgroundImage")));
            this.btnPrintGuestBill.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.BgImageOnMouseDown")));
            this.btnPrintGuestBill.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.BgImageOnMouseUp")));
            this.btnPrintGuestBill.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintGuestBill.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnPrintGuestBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintGuestBill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintGuestBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintGuestBill.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrintGuestBill.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrintGuestBill.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrintGuestBill.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrintGuestBill.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrintGuestBill.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.Image")));
            this.btnPrintGuestBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintGuestBill.Location = new System.Drawing.Point(438, 7);
            this.btnPrintGuestBill.Name = "btnPrintGuestBill";
            this.btnPrintGuestBill.Size = new System.Drawing.Size(154, 38);
            this.btnPrintGuestBill.TabIndex = 6;
            this.btnPrintGuestBill.Text = "Print Guest Bill";
            this.btnPrintGuestBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintGuestBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintGuestBill.UseVisualStyleBackColor = true;
            this.btnPrintGuestBill.Click += new System.EventHandler(this.btnPrintGuestBill_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightGray;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnBack.BgImageOnMouseDown")));
            this.btnBack.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnBack.BgImageOnMouseUp")));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.ForeColorOnMouseDown = System.Drawing.Color.Black;
            this.btnBack.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnBack.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(601, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 38);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Close";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrderDetails.GridColor = System.Drawing.Color.Gray;
            this.dgvOrderDetails.Location = new System.Drawing.Point(11, 154);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowHeadersVisible = false;
            this.dgvOrderDetails.Size = new System.Drawing.Size(703, 250);
            this.dgvOrderDetails.TabIndex = 4;
            // 
            // OrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(725, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lelOrderInfo);
            this.Controls.Add(this.lelOrderID);
            this.Controls.Add(this.dgvOrderDetails);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "OrderDetails";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order item details";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lelOrderID;
        private System.Windows.Forms.Label lelOrderInfo;
        private RMSUI.FunctionalButton btnBack;
        private RMSUI.SimpleGrid dgvOrderDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private RMSUI.FunctionalButton btnPrintGuestBill;
        private RMSUI.FunctionalButton duebillPaymentButton;
    }
}