using RMSUI;

namespace RMS.Reports
{
    partial class SalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBack = new RMSUI.FunctionalButton();
            this.lelGuest = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblNoOfItemsSold = new System.Windows.Forms.Label();
            this.lelTakeAwayFoodPrice = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new RMSUI.FunctionalButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lelFoodPrice = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPrintSummary = new RMSUI.FunctionalButton();
            this.btnA4Print = new RMSUI.FunctionalButton();
            this.dataGridView1 = new RMSUI.SimpleGrid();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewReport = new RMSUI.FunctionalButton();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnTakeAway = new System.Windows.Forms.RadioButton();
            this.rbtnTable = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lelOrderType = new System.Windows.Forms.Label();
            this.checkBoxDateRangeWise = new System.Windows.Forms.CheckBox();
            this.btnSetToday = new RMSUI.FunctionalButton();
            this.btnCurrentStock = new RMSUI.FunctionalButton();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFromTime = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cmbFromMinute = new System.Windows.Forms.ComboBox();
            this.cmbToMinute = new System.Windows.Forms.ComboBox();
            this.cmbToHour = new System.Windows.Forms.ComboBox();
            this.cmbFromHour = new System.Windows.Forms.ComboBox();
            this.panel11.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BgImageOnMouseDown = null;
            this.btnBack.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnBack.BgImageOnMouseUp")));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnBack.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnBack.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(5, 541);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(123, 39);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lelGuest
            // 
            this.lelGuest.AutoSize = true;
            this.lelGuest.BackColor = System.Drawing.Color.Transparent;
            this.lelGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelGuest.ForeColor = System.Drawing.Color.Black;
            this.lelGuest.Location = new System.Drawing.Point(4, 1);
            this.lelGuest.Name = "lelGuest";
            this.lelGuest.Size = new System.Drawing.Size(68, 15);
            this.lelGuest.TabIndex = 10;
            this.lelGuest.Text = "From Date:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Black;
            this.lblFromDate.Location = new System.Drawing.Point(308, 1);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(0, 38);
            this.lblFromDate.TabIndex = 11;
            // 
            // lblNoOfItemsSold
            // 
            this.lblNoOfItemsSold.AutoSize = true;
            this.lblNoOfItemsSold.BackColor = System.Drawing.Color.Transparent;
            this.lblNoOfItemsSold.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoOfItemsSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfItemsSold.ForeColor = System.Drawing.Color.Black;
            this.lblNoOfItemsSold.Location = new System.Drawing.Point(487, 1);
            this.lblNoOfItemsSold.Name = "lblNoOfItemsSold";
            this.lblNoOfItemsSold.Size = new System.Drawing.Size(153, 15);
            this.lblNoOfItemsSold.TabIndex = 18;
            this.lblNoOfItemsSold.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lelTakeAwayFoodPrice
            // 
            this.lelTakeAwayFoodPrice.AutoSize = true;
            this.lelTakeAwayFoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelTakeAwayFoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTakeAwayFoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelTakeAwayFoodPrice.Location = new System.Drawing.Point(4, 40);
            this.lelTakeAwayFoodPrice.Name = "lelTakeAwayFoodPrice";
            this.lelTakeAwayFoodPrice.Size = new System.Drawing.Size(53, 15);
            this.lelTakeAwayFoodPrice.TabIndex = 30;
            this.lelTakeAwayFoodPrice.Text = "To Date:";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.Black;
            this.lblToDate.Location = new System.Drawing.Point(308, 40);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(0, 39);
            this.lblToDate.TabIndex = 31;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.Black;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseDown")));
            this.btnPrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseUp")));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(414, 541);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(169, 38);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Text = "Print Report(RP)";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(668, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Total Orders:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalQty.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.ForeColor = System.Drawing.Color.Black;
            this.lblTotalQty.Location = new System.Drawing.Point(974, 1);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(0, 38);
            this.lblTotalQty.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(668, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 15);
            this.label5.TabIndex = 49;
            this.label5.Text = "Total Order Amount  (£)";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(974, 40);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 39);
            this.lblTotalAmount.TabIndex = 50;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label7);
            this.panel11.Controls.Add(this.tableLayoutPanel1);
            this.panel11.Location = new System.Drawing.Point(5, 376);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(5);
            this.panel11.Size = new System.Drawing.Size(991, 159);
            this.panel11.TabIndex = 54;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Summary";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lblFromDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfItemsSold, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelFoodPrice, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelGuest, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelTakeAwayFoodPrice, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblToDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalQty, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalAmount, 7, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 80);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lelFoodPrice
            // 
            this.lelFoodPrice.AutoSize = true;
            this.lelFoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelFoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelFoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelFoodPrice.Location = new System.Drawing.Point(336, 1);
            this.lelFoodPrice.Name = "lelFoodPrice";
            this.lelFoodPrice.Size = new System.Drawing.Size(133, 15);
            this.lelFoodPrice.TabIndex = 16;
            this.lelFoodPrice.Text = "Total No. of Items Sold:";
            this.lelFoodPrice.Click += new System.EventHandler(this.lelFoodPrice_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintSummary.BackColor = System.Drawing.Color.Black;
            this.btnPrintSummary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BackgroundImage")));
            this.btnPrintSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintSummary.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BgImageOnMouseDown")));
            this.btnPrintSummary.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BgImageOnMouseUp")));
            this.btnPrintSummary.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintSummary.FlatAppearance.BorderSize = 0;
            this.btnPrintSummary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintSummary.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrintSummary.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrintSummary.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrintSummary.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrintSummary.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.Image")));
            this.btnPrintSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSummary.Location = new System.Drawing.Point(163, 541);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(200, 38);
            this.btnPrintSummary.TabIndex = 55;
            this.btnPrintSummary.Text = "Print Todays Report (RP)";
            this.btnPrintSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSummary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintSummary.UseVisualStyleBackColor = false;
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // btnA4Print
            // 
            this.btnA4Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnA4Print.BackColor = System.Drawing.Color.Black;
            this.btnA4Print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnA4Print.BackgroundImage")));
            this.btnA4Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnA4Print.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnA4Print.BgImageOnMouseDown")));
            this.btnA4Print.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnA4Print.BgImageOnMouseUp")));
            this.btnA4Print.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnA4Print.FlatAppearance.BorderSize = 0;
            this.btnA4Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnA4Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnA4Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA4Print.Font = new System.Drawing.Font("Arial", 10F);
            this.btnA4Print.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnA4Print.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnA4Print.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnA4Print.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnA4Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnA4Print.Location = new System.Drawing.Point(650, 541);
            this.btnA4Print.Name = "btnA4Print";
            this.btnA4Print.Size = new System.Drawing.Size(169, 38);
            this.btnA4Print.TabIndex = 57;
            this.btnA4Print.Text = "Print A4 Size";
            this.btnA4Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnA4Print.UseVisualStyleBackColor = false;
            this.btnA4Print.Click += new System.EventHandler(this.btnPrintA4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.product_Name,
            this.ItemPrice,
            this.ItemQty,
            this.TotalAmount});
            this.dataGridView1.GridColor = System.Drawing.Color.Gray;
            this.dataGridView1.Location = new System.Drawing.Point(6, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(978, 237);
            this.dataGridView1.TabIndex = 52;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "product_id";
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            // 
            // product_Name
            // 
            this.product_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.product_Name.DataPropertyName = "product_Name";
            this.product_Name.HeaderText = "Item Name";
            this.product_Name.Name = "product_Name";
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "amount";
            this.ItemPrice.HeaderText = "ItemPrice (£)";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Width = 150;
            // 
            // ItemQty
            // 
            this.ItemQty.DataPropertyName = "quantity";
            this.ItemQty.HeaderText = "Item Qty.";
            this.ItemQty.Name = "ItemQty";
            this.ItemQty.Width = 150;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "Total Amount (£)";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Width = 200;
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnViewReport.BackgroundImage")));
            this.btnViewReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnViewReport.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnViewReport.BgImageOnMouseDown")));
            this.btnViewReport.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnViewReport.BgImageOnMouseUp")));
            this.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnViewReport.FlatAppearance.BorderSize = 0;
            this.btnViewReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Arial", 10F);
            this.btnViewReport.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnViewReport.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnViewReport.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewReport.Location = new System.Drawing.Point(519, 35);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(110, 34);
            this.btnViewReport.TabIndex = 4;
            this.btnViewReport.Text = "Show Result";
            this.btnViewReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.CustomFormat = "MMMM dd, yyyy";
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(166, 6);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(155, 23);
            this.dtpStart.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "From";
            // 
            // rbtnTakeAway
            // 
            this.rbtnTakeAway.AutoSize = true;
            this.rbtnTakeAway.BackColor = System.Drawing.Color.Transparent;
            this.rbtnTakeAway.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTakeAway.Location = new System.Drawing.Point(798, 7);
            this.rbtnTakeAway.Name = "rbtnTakeAway";
            this.rbtnTakeAway.Size = new System.Drawing.Size(95, 21);
            this.rbtnTakeAway.TabIndex = 41;
            this.rbtnTakeAway.Text = "Take Away";
            this.rbtnTakeAway.UseVisualStyleBackColor = false;
            this.rbtnTakeAway.Visible = false;
            // 
            // rbtnTable
            // 
            this.rbtnTable.AutoSize = true;
            this.rbtnTable.BackColor = System.Drawing.Color.Transparent;
            this.rbtnTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTable.Location = new System.Drawing.Point(730, 7);
            this.rbtnTable.Name = "rbtnTable";
            this.rbtnTable.Size = new System.Drawing.Size(62, 21);
            this.rbtnTable.TabIndex = 40;
            this.rbtnTable.Text = "Table";
            this.rbtnTable.UseVisualStyleBackColor = false;
            this.rbtnTable.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(327, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "To";
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.BackColor = System.Drawing.Color.Transparent;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAll.Location = new System.Drawing.Point(683, 7);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(41, 21);
            this.rbtnAll.TabIndex = 39;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = false;
            this.rbtnAll.Visible = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.CustomFormat = "MMMM dd, yyyy";
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(358, 5);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(155, 23);
            this.dtpEnd.TabIndex = 6;
            // 
            // lelOrderType
            // 
            this.lelOrderType.AutoSize = true;
            this.lelOrderType.BackColor = System.Drawing.Color.Transparent;
            this.lelOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelOrderType.Location = new System.Drawing.Point(598, 7);
            this.lelOrderType.Name = "lelOrderType";
            this.lelOrderType.Size = new System.Drawing.Size(84, 17);
            this.lelOrderType.TabIndex = 42;
            this.lelOrderType.Text = "Order type :";
            this.lelOrderType.Visible = false;
            // 
            // checkBoxDateRangeWise
            // 
            this.checkBoxDateRangeWise.AutoSize = true;
            this.checkBoxDateRangeWise.Checked = true;
            this.checkBoxDateRangeWise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDateRangeWise.Location = new System.Drawing.Point(10, 8);
            this.checkBoxDateRangeWise.Name = "checkBoxDateRangeWise";
            this.checkBoxDateRangeWise.Size = new System.Drawing.Size(109, 17);
            this.checkBoxDateRangeWise.TabIndex = 57;
            this.checkBoxDateRangeWise.Text = "With Date Range";
            this.checkBoxDateRangeWise.UseVisualStyleBackColor = true;
            this.checkBoxDateRangeWise.CheckedChanged += new System.EventHandler(this.checkBoxMothWise_CheckedChanged);
            // 
            // btnSetToday
            // 
            this.btnSetToday.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSetToday.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetToday.BackgroundImage")));
            this.btnSetToday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetToday.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSetToday.BgImageOnMouseDown")));
            this.btnSetToday.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSetToday.BgImageOnMouseUp")));
            this.btnSetToday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSetToday.FlatAppearance.BorderSize = 0;
            this.btnSetToday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetToday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetToday.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSetToday.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSetToday.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSetToday.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSetToday.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetToday.Location = new System.Drawing.Point(519, 1);
            this.btnSetToday.Name = "btnSetToday";
            this.btnSetToday.Size = new System.Drawing.Size(73, 30);
            this.btnSetToday.TabIndex = 60;
            this.btnSetToday.Text = "Reset";
            this.btnSetToday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetToday.UseVisualStyleBackColor = false;
            this.btnSetToday.Click += new System.EventHandler(this.btnSetToday_Click);
            // 
            // btnCurrentStock
            // 
            this.btnCurrentStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCurrentStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCurrentStock.BackgroundImage")));
            this.btnCurrentStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCurrentStock.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnCurrentStock.BgImageOnMouseDown")));
            this.btnCurrentStock.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnCurrentStock.BgImageOnMouseUp")));
            this.btnCurrentStock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCurrentStock.FlatAppearance.BorderSize = 0;
            this.btnCurrentStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCurrentStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCurrentStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentStock.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCurrentStock.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnCurrentStock.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnCurrentStock.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnCurrentStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentStock.Location = new System.Drawing.Point(7, 27);
            this.btnCurrentStock.Name = "btnCurrentStock";
            this.btnCurrentStock.Size = new System.Drawing.Size(105, 41);
            this.btnCurrentStock.TabIndex = 61;
            this.btnCurrentStock.Text = "Show Current Stock";
            this.btnCurrentStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCurrentStock.UseVisualStyleBackColor = false;
            this.btnCurrentStock.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(450, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "To";
            this.label6.Visible = false;
            // 
            // chkFromTime
            // 
            this.chkFromTime.AutoSize = true;
            this.chkFromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFromTime.Location = new System.Drawing.Point(119, 36);
            this.chkFromTime.Name = "chkFromTime";
            this.chkFromTime.Size = new System.Drawing.Size(187, 20);
            this.chkFromTime.TabIndex = 71;
            this.chkFromTime.Text = "From Time    7 AM To 6 AM";
            this.chkFromTime.UseVisualStyleBackColor = true;
            this.chkFromTime.Visible = false;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.cmbFromMinute);
            this.panel10.Controls.Add(this.cmbToMinute);
            this.panel10.Controls.Add(this.cmbToHour);
            this.panel10.Controls.Add(this.cmbFromHour);
            this.panel10.Controls.Add(this.chkFromTime);
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.btnCurrentStock);
            this.panel10.Controls.Add(this.btnSetToday);
            this.panel10.Controls.Add(this.checkBoxDateRangeWise);
            this.panel10.Controls.Add(this.lelOrderType);
            this.panel10.Controls.Add(this.dtpEnd);
            this.panel10.Controls.Add(this.rbtnAll);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.rbtnTable);
            this.panel10.Controls.Add(this.rbtnTakeAway);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.dtpStart);
            this.panel10.Controls.Add(this.btnViewReport);
            this.panel10.Controls.Add(this.dataGridView1);
            this.panel10.Location = new System.Drawing.Point(5, 53);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.panel10.Size = new System.Drawing.Size(991, 318);
            this.panel10.TabIndex = 53;
            // 
            // cmbFromMinute
            // 
            this.cmbFromMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromMinute.FormattingEnabled = true;
            this.cmbFromMinute.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cmbFromMinute.Location = new System.Drawing.Point(423, 32);
            this.cmbFromMinute.Name = "cmbFromMinute";
            this.cmbFromMinute.Size = new System.Drawing.Size(60, 24);
            this.cmbFromMinute.TabIndex = 75;
            this.cmbFromMinute.Text = "0";
            this.cmbFromMinute.Visible = false;
            // 
            // cmbToMinute
            // 
            this.cmbToMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToMinute.FormattingEnabled = true;
            this.cmbToMinute.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cmbToMinute.Location = new System.Drawing.Point(423, 33);
            this.cmbToMinute.Name = "cmbToMinute";
            this.cmbToMinute.Size = new System.Drawing.Size(60, 24);
            this.cmbToMinute.TabIndex = 74;
            this.cmbToMinute.Text = "0";
            this.cmbToMinute.Visible = false;
            // 
            // cmbToHour
            // 
            this.cmbToHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToHour.FormattingEnabled = true;
            this.cmbToHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbToHour.Location = new System.Drawing.Point(423, 35);
            this.cmbToHour.Name = "cmbToHour";
            this.cmbToHour.Size = new System.Drawing.Size(60, 24);
            this.cmbToHour.TabIndex = 73;
            this.cmbToHour.Text = "0";
            this.cmbToHour.Visible = false;
            // 
            // cmbFromHour
            // 
            this.cmbFromHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromHour.FormattingEnabled = true;
            this.cmbFromHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbFromHour.Location = new System.Drawing.Point(434, 30);
            this.cmbFromHour.Name = "cmbFromHour";
            this.cmbFromHour.Size = new System.Drawing.Size(60, 24);
            this.cmbFromHour.TabIndex = 72;
            this.cmbFromHour.Text = "0";
            this.cmbFromHour.Visible = false;
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1001, 590);
            this.Controls.Add(this.btnA4Print);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPrint);
            this.Name = "SalesReport";
            this.Text = "ViewReport";
            this.Load += new System.EventHandler(this.SalesReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewReport_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ViewReport_KeyPress);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.Controls.SetChildIndex(this.panel10, 0);
            this.Controls.SetChildIndex(this.panel11, 0);
            this.Controls.SetChildIndex(this.btnPrintSummary, 0);
            this.Controls.SetChildIndex(this.btnA4Print, 0);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RMSUI.FunctionalButton btnBack;
        private System.Windows.Forms.Label lelGuest;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblNoOfItemsSold;
        private System.Windows.Forms.Label lelTakeAwayFoodPrice;
        private System.Windows.Forms.Label lblToDate;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private RMSUI.FunctionalButton btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label7;
        private FunctionalButton btnPrintSummary;
        private System.Windows.Forms.Label lelFoodPrice;
        private FunctionalButton btnA4Print;
        private SimpleGrid dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private FunctionalButton btnViewReport;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnTakeAway;
        private System.Windows.Forms.RadioButton rbtnTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lelOrderType;
        private System.Windows.Forms.CheckBox checkBoxDateRangeWise;
        private FunctionalButton btnSetToday;
        private FunctionalButton btnCurrentStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkFromTime;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ComboBox cmbFromHour;
        private System.Windows.Forms.ComboBox cmbToHour;
        private System.Windows.Forms.ComboBox cmbFromMinute;
        private System.Windows.Forms.ComboBox cmbToMinute;
        //private System.Windows.Forms.Button btnBack;
    }
}