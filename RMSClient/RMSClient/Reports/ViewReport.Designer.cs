using RMSUI;

namespace RMS.Reports
{
    partial class ViewReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnViewReport = new RMSUI.FunctionalButton();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new RMSUI.FunctionalButton();
            this.lelGuest = new System.Windows.Forms.Label();
            this.lelGuest_Value = new System.Windows.Forms.Label();
            this.lelTableFoodPrice = new System.Windows.Forms.Label();
            this.lelTableFoodPrice_Value = new System.Windows.Forms.Label();
            this.lelTableNonfoodPrice = new System.Windows.Forms.Label();
            this.lelTableNonfoodPrice_Value = new System.Windows.Forms.Label();
            this.lelFoodPrice_Value = new System.Windows.Forms.Label();
            this.lelNonfoodPrice_Value = new System.Windows.Forms.Label();
            this.lelVat = new System.Windows.Forms.Label();
            this.lelOrderTotal_Value = new System.Windows.Forms.Label();
            this.lelServiceCharge_Value = new System.Windows.Forms.Label();
            this.lelDiscount_Value = new System.Windows.Forms.Label();
            this.lelVat_Value = new System.Windows.Forms.Label();
            this.lelTakeAwayFoodPrice = new System.Windows.Forms.Label();
            this.lelTakeAwayFoodPrice_Value = new System.Windows.Forms.Label();
            this.lelTakeAwayNonfoodPrice = new System.Windows.Forms.Label();
            this.lelTakeAwayNonfoodPrice_Value = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new RMSUI.FunctionalButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnTable = new System.Windows.Forms.RadioButton();
            this.rbtnTakeAway = new System.Windows.Forms.RadioButton();
            this.lelOrderType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lelCashTotal_value = new System.Windows.Forms.Label();
            this.lelEftTotal_value = new System.Windows.Forms.Label();
            this.lel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lelTotalpaidEXVAT_value = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lelTotalpaidIncVAT_value = new System.Windows.Forms.Label();
            this.btnItemWiseReport = new RMSUI.FunctionalButton();
            this.radioButtonCheat = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new RMSUI.SimpleGrid();
            this.panel10 = new System.Windows.Forms.Panel();
            this.orderComplementoryRadioButton = new System.Windows.Forms.RadioButton();
            this.dueTotalradioButton1 = new System.Windows.Forms.RadioButton();
            this.complementoryRadioButton = new System.Windows.Forms.RadioButton();
            this.dueRadioButton = new System.Windows.Forms.RadioButton();
            this.tableNumbertextBox = new System.Windows.Forms.TextBox();
            this.tableNumberradioButton = new System.Windows.Forms.RadioButton();
            this.waitercomboBox = new System.Windows.Forms.ComboBox();
            this.waiterradioButton = new System.Windows.Forms.RadioButton();
            this.toTimeFormatcomboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toMinutecomboBox = new System.Windows.Forms.ComboBox();
            this.toHourcomboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.fromTimeFormatcomboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fromMinutecomboBox = new System.Windows.Forms.ComboBox();
            this.fromHourcomboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkTerminalName = new System.Windows.Forms.CheckBox();
            this.cmbTerminalName = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.btnSetToday = new RMSUI.FunctionalButton();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMonthList = new System.Windows.Forms.ComboBox();
            this.checkBoxDateRangeWise = new System.Windows.Forms.CheckBox();
            this.cheatPanel = new System.Windows.Forms.Panel();
            this.txtBoxCheatPercent = new System.Windows.Forms.MaskedTextBox();
            this.radioButtonActualReport = new System.Windows.Forms.RadioButton();
            this.btn_go = new RMSUI.FunctionalButton();
            this.txtBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.lelFoodPrice = new System.Windows.Forms.Label();
            this.lelNonfoodPrice = new System.Windows.Forms.Label();
            this.lelOrderTotal = new System.Windows.Forms.Label();
            this.lelServiceCharge = new System.Windows.Forms.Label();
            this.lelDiscount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.profitlebel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dueTotalLabel = new System.Windows.Forms.Label();
            this.complementorylabel = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPrintSummary = new RMSUI.FunctionalButton();
            this.btnFPPrintSummary = new RMSUI.FunctionalButton();
            this.btnClearFP = new RMSUI.FunctionalButton();
            this.functionalButton1 = new RMSUI.FunctionalButton();
            this.functionalButton2 = new RMSUI.FunctionalButton();
            this.excelButton = new RMSUI.FunctionalButton();
            this.functionalButton3 = new RMSUI.FunctionalButton();
            this.label16 = new System.Windows.Forms.Label();
            this.itemDiscountlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel10.SuspendLayout();
            this.cheatPanel.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.Transparent;
            this.btnViewReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnViewReport.BackgroundImage")));
            this.btnViewReport.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnViewReport.BgImageOnMouseDown")));
            this.btnViewReport.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnViewReport.BgImageOnMouseUp")));
            this.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnViewReport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnViewReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Arial", 10F);
            this.btnViewReport.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnViewReport.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnViewReport.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewReport.Location = new System.Drawing.Point(488, 61);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(157, 30);
            this.btnViewReport.TabIndex = 4;
            this.btnViewReport.Text = "Show Result";
            this.btnViewReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(171, 8);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(219, 23);
            this.dtpStart.TabIndex = 5;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(427, 8);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(219, 23);
            this.dtpEnd.TabIndex = 6;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "From";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(396, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "To";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnBack.BgImageOnMouseDown")));
            this.btnBack.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnBack.BgImageOnMouseUp")));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnBack.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnBack.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(1152, 594);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 50);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
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
            this.lelGuest.Size = new System.Drawing.Size(67, 15);
            this.lelGuest.TabIndex = 10;
            this.lelGuest.Text = "Total guest";
            // 
            // lelGuest_Value
            // 
            this.lelGuest_Value.AutoSize = true;
            this.lelGuest_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelGuest_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelGuest_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelGuest_Value.ForeColor = System.Drawing.Color.Black;
            this.lelGuest_Value.Location = new System.Drawing.Point(365, 1);
            this.lelGuest_Value.Name = "lelGuest_Value";
            this.lelGuest_Value.Size = new System.Drawing.Size(41, 21);
            this.lelGuest_Value.TabIndex = 11;
            this.lelGuest_Value.Text = "label4";
            // 
            // lelTableFoodPrice
            // 
            this.lelTableFoodPrice.AutoSize = true;
            this.lelTableFoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelTableFoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTableFoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelTableFoodPrice.Location = new System.Drawing.Point(4, 67);
            this.lelTableFoodPrice.Name = "lelTableFoodPrice";
            this.lelTableFoodPrice.Size = new System.Drawing.Size(95, 15);
            this.lelTableFoodPrice.TabIndex = 12;
            this.lelTableFoodPrice.Text = "Table food price";
            // 
            // lelTableFoodPrice_Value
            // 
            this.lelTableFoodPrice_Value.AutoSize = true;
            this.lelTableFoodPrice_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelTableFoodPrice_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelTableFoodPrice_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTableFoodPrice_Value.ForeColor = System.Drawing.Color.Black;
            this.lelTableFoodPrice_Value.Location = new System.Drawing.Point(365, 67);
            this.lelTableFoodPrice_Value.Name = "lelTableFoodPrice_Value";
            this.lelTableFoodPrice_Value.Size = new System.Drawing.Size(41, 21);
            this.lelTableFoodPrice_Value.TabIndex = 13;
            this.lelTableFoodPrice_Value.Text = "label3";
            // 
            // lelTableNonfoodPrice
            // 
            this.lelTableNonfoodPrice.AutoSize = true;
            this.lelTableNonfoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelTableNonfoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTableNonfoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelTableNonfoodPrice.Location = new System.Drawing.Point(4, 89);
            this.lelTableNonfoodPrice.Name = "lelTableNonfoodPrice";
            this.lelTableNonfoodPrice.Size = new System.Drawing.Size(119, 15);
            this.lelTableNonfoodPrice.TabIndex = 14;
            this.lelTableNonfoodPrice.Text = "Table non food price";
            // 
            // lelTableNonfoodPrice_Value
            // 
            this.lelTableNonfoodPrice_Value.AutoSize = true;
            this.lelTableNonfoodPrice_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelTableNonfoodPrice_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelTableNonfoodPrice_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTableNonfoodPrice_Value.ForeColor = System.Drawing.Color.Black;
            this.lelTableNonfoodPrice_Value.Location = new System.Drawing.Point(365, 89);
            this.lelTableNonfoodPrice_Value.Name = "lelTableNonfoodPrice_Value";
            this.lelTableNonfoodPrice_Value.Size = new System.Drawing.Size(41, 21);
            this.lelTableNonfoodPrice_Value.TabIndex = 15;
            this.lelTableNonfoodPrice_Value.Text = "label4";
            // 
            // lelFoodPrice_Value
            // 
            this.lelFoodPrice_Value.AutoSize = true;
            this.lelFoodPrice_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelFoodPrice_Value.Dock = System.Windows.Forms.DockStyle.Top;
            this.lelFoodPrice_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelFoodPrice_Value.ForeColor = System.Drawing.Color.Black;
            this.lelFoodPrice_Value.Location = new System.Drawing.Point(585, 1);
            this.lelFoodPrice_Value.Name = "lelFoodPrice_Value";
            this.lelFoodPrice_Value.Size = new System.Drawing.Size(251, 15);
            this.lelFoodPrice_Value.TabIndex = 18;
            this.lelFoodPrice_Value.Text = "label5";
            this.lelFoodPrice_Value.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lelNonfoodPrice_Value
            // 
            this.lelNonfoodPrice_Value.AutoSize = true;
            this.lelNonfoodPrice_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelNonfoodPrice_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelNonfoodPrice_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelNonfoodPrice_Value.ForeColor = System.Drawing.Color.Black;
            this.lelNonfoodPrice_Value.Location = new System.Drawing.Point(795, 23);
            this.lelNonfoodPrice_Value.Name = "lelNonfoodPrice_Value";
            this.lelNonfoodPrice_Value.Size = new System.Drawing.Size(41, 21);
            this.lelNonfoodPrice_Value.TabIndex = 19;
            this.lelNonfoodPrice_Value.Text = "label6";
            // 
            // lelVat
            // 
            this.lelVat.AutoSize = true;
            this.lelVat.BackColor = System.Drawing.Color.Transparent;
            this.lelVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelVat.ForeColor = System.Drawing.Color.Black;
            this.lelVat.Location = new System.Drawing.Point(864, 45);
            this.lelVat.Name = "lelVat";
            this.lelVat.Size = new System.Drawing.Size(24, 15);
            this.lelVat.TabIndex = 23;
            this.lelVat.Text = "Vat";
            // 
            // lelOrderTotal_Value
            // 
            this.lelOrderTotal_Value.AutoSize = true;
            this.lelOrderTotal_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelOrderTotal_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelOrderTotal_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelOrderTotal_Value.ForeColor = System.Drawing.Color.Black;
            this.lelOrderTotal_Value.Location = new System.Drawing.Point(795, 45);
            this.lelOrderTotal_Value.Name = "lelOrderTotal_Value";
            this.lelOrderTotal_Value.Size = new System.Drawing.Size(41, 21);
            this.lelOrderTotal_Value.TabIndex = 25;
            this.lelOrderTotal_Value.Text = "label8";
            // 
            // lelServiceCharge_Value
            // 
            this.lelServiceCharge_Value.AutoSize = true;
            this.lelServiceCharge_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelServiceCharge_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelServiceCharge_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelServiceCharge_Value.ForeColor = System.Drawing.Color.Black;
            this.lelServiceCharge_Value.Location = new System.Drawing.Point(795, 67);
            this.lelServiceCharge_Value.Name = "lelServiceCharge_Value";
            this.lelServiceCharge_Value.Size = new System.Drawing.Size(41, 21);
            this.lelServiceCharge_Value.TabIndex = 26;
            this.lelServiceCharge_Value.Text = "label9";
            // 
            // lelDiscount_Value
            // 
            this.lelDiscount_Value.AutoSize = true;
            this.lelDiscount_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelDiscount_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelDiscount_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelDiscount_Value.ForeColor = System.Drawing.Color.Black;
            this.lelDiscount_Value.Location = new System.Drawing.Point(788, 89);
            this.lelDiscount_Value.Name = "lelDiscount_Value";
            this.lelDiscount_Value.Size = new System.Drawing.Size(48, 21);
            this.lelDiscount_Value.TabIndex = 27;
            this.lelDiscount_Value.Text = "label10";
            // 
            // lelVat_Value
            // 
            this.lelVat_Value.AutoSize = true;
            this.lelVat_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelVat_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelVat_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelVat_Value.ForeColor = System.Drawing.Color.Black;
            this.lelVat_Value.Location = new System.Drawing.Point(1220, 45);
            this.lelVat_Value.Name = "lelVat_Value";
            this.lelVat_Value.Size = new System.Drawing.Size(48, 21);
            this.lelVat_Value.TabIndex = 28;
            this.lelVat_Value.Text = "label11";
            // 
            // lelTakeAwayFoodPrice
            // 
            this.lelTakeAwayFoodPrice.AutoSize = true;
            this.lelTakeAwayFoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelTakeAwayFoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTakeAwayFoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelTakeAwayFoodPrice.Location = new System.Drawing.Point(4, 23);
            this.lelTakeAwayFoodPrice.Name = "lelTakeAwayFoodPrice";
            this.lelTakeAwayFoodPrice.Size = new System.Drawing.Size(122, 15);
            this.lelTakeAwayFoodPrice.TabIndex = 30;
            this.lelTakeAwayFoodPrice.Text = "Take away food price";
            // 
            // lelTakeAwayFoodPrice_Value
            // 
            this.lelTakeAwayFoodPrice_Value.AutoSize = true;
            this.lelTakeAwayFoodPrice_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelTakeAwayFoodPrice_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelTakeAwayFoodPrice_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTakeAwayFoodPrice_Value.ForeColor = System.Drawing.Color.Black;
            this.lelTakeAwayFoodPrice_Value.Location = new System.Drawing.Point(365, 23);
            this.lelTakeAwayFoodPrice_Value.Name = "lelTakeAwayFoodPrice_Value";
            this.lelTakeAwayFoodPrice_Value.Size = new System.Drawing.Size(41, 21);
            this.lelTakeAwayFoodPrice_Value.TabIndex = 31;
            this.lelTakeAwayFoodPrice_Value.Text = "label4";
            // 
            // lelTakeAwayNonfoodPrice
            // 
            this.lelTakeAwayNonfoodPrice.AutoSize = true;
            this.lelTakeAwayNonfoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelTakeAwayNonfoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTakeAwayNonfoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelTakeAwayNonfoodPrice.Location = new System.Drawing.Point(4, 45);
            this.lelTakeAwayNonfoodPrice.Name = "lelTakeAwayNonfoodPrice";
            this.lelTakeAwayNonfoodPrice.Size = new System.Drawing.Size(119, 21);
            this.lelTakeAwayNonfoodPrice.TabIndex = 32;
            this.lelTakeAwayNonfoodPrice.Text = "Take away non food price";
            // 
            // lelTakeAwayNonfoodPrice_Value
            // 
            this.lelTakeAwayNonfoodPrice_Value.AutoSize = true;
            this.lelTakeAwayNonfoodPrice_Value.BackColor = System.Drawing.Color.Transparent;
            this.lelTakeAwayNonfoodPrice_Value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelTakeAwayNonfoodPrice_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTakeAwayNonfoodPrice_Value.ForeColor = System.Drawing.Color.Black;
            this.lelTakeAwayNonfoodPrice_Value.Location = new System.Drawing.Point(365, 45);
            this.lelTakeAwayNonfoodPrice_Value.Name = "lelTakeAwayNonfoodPrice_Value";
            this.lelTakeAwayNonfoodPrice_Value.Size = new System.Drawing.Size(41, 21);
            this.lelTakeAwayNonfoodPrice_Value.TabIndex = 35;
            this.lelTakeAwayNonfoodPrice_Value.Text = "label8";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseDown")));
            this.btnPrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseUp")));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(166, 594);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(160, 50);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Text = "Print Details";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.BackColor = System.Drawing.Color.Transparent;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAll.Location = new System.Drawing.Point(326, 36);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(41, 21);
            this.rbtnAll.TabIndex = 39;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = false;
            // 
            // rbtnTable
            // 
            this.rbtnTable.AutoSize = true;
            this.rbtnTable.BackColor = System.Drawing.Color.Transparent;
            this.rbtnTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTable.Location = new System.Drawing.Point(369, 36);
            this.rbtnTable.Name = "rbtnTable";
            this.rbtnTable.Size = new System.Drawing.Size(106, 21);
            this.rbtnTable.TabIndex = 40;
            this.rbtnTable.Text = "Table/Token";
            this.rbtnTable.UseVisualStyleBackColor = false;
            // 
            // rbtnTakeAway
            // 
            this.rbtnTakeAway.AutoSize = true;
            this.rbtnTakeAway.BackColor = System.Drawing.Color.Transparent;
            this.rbtnTakeAway.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTakeAway.Location = new System.Drawing.Point(481, 36);
            this.rbtnTakeAway.Name = "rbtnTakeAway";
            this.rbtnTakeAway.Size = new System.Drawing.Size(95, 21);
            this.rbtnTakeAway.TabIndex = 41;
            this.rbtnTakeAway.Text = "Take Away";
            this.rbtnTakeAway.UseVisualStyleBackColor = false;
            // 
            // lelOrderType
            // 
            this.lelOrderType.AutoSize = true;
            this.lelOrderType.BackColor = System.Drawing.Color.Transparent;
            this.lelOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelOrderType.Location = new System.Drawing.Point(242, 38);
            this.lelOrderType.Name = "lelOrderType";
            this.lelOrderType.Size = new System.Drawing.Size(84, 17);
            this.lelOrderType.TabIndex = 42;
            this.lelOrderType.Text = "Order type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(864, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 43;
            this.label3.Text = "Cash Total";
            // 
            // lelCashTotal_value
            // 
            this.lelCashTotal_value.AutoSize = true;
            this.lelCashTotal_value.BackColor = System.Drawing.Color.Transparent;
            this.lelCashTotal_value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelCashTotal_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelCashTotal_value.ForeColor = System.Drawing.Color.Black;
            this.lelCashTotal_value.Location = new System.Drawing.Point(1220, 67);
            this.lelCashTotal_value.Name = "lelCashTotal_value";
            this.lelCashTotal_value.Size = new System.Drawing.Size(48, 21);
            this.lelCashTotal_value.TabIndex = 44;
            this.lelCashTotal_value.Text = "label10";
            // 
            // lelEftTotal_value
            // 
            this.lelEftTotal_value.AutoSize = true;
            this.lelEftTotal_value.BackColor = System.Drawing.Color.Transparent;
            this.lelEftTotal_value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelEftTotal_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelEftTotal_value.ForeColor = System.Drawing.Color.Black;
            this.lelEftTotal_value.Location = new System.Drawing.Point(1220, 89);
            this.lelEftTotal_value.Name = "lelEftTotal_value";
            this.lelEftTotal_value.Size = new System.Drawing.Size(48, 21);
            this.lelEftTotal_value.TabIndex = 46;
            this.lelEftTotal_value.Text = "label10";
            // 
            // lel
            // 
            this.lel.AutoSize = true;
            this.lel.BackColor = System.Drawing.Color.Transparent;
            this.lel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lel.ForeColor = System.Drawing.Color.Black;
            this.lel.Location = new System.Drawing.Point(864, 89);
            this.lel.Name = "lel";
            this.lel.Size = new System.Drawing.Size(59, 15);
            this.lel.TabIndex = 45;
            this.lel.Text = "EFT Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(864, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Total Paid(Ex. Vat)";
            // 
            // lelTotalpaidEXVAT_value
            // 
            this.lelTotalpaidEXVAT_value.AutoSize = true;
            this.lelTotalpaidEXVAT_value.BackColor = System.Drawing.Color.Transparent;
            this.lelTotalpaidEXVAT_value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelTotalpaidEXVAT_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTotalpaidEXVAT_value.ForeColor = System.Drawing.Color.Black;
            this.lelTotalpaidEXVAT_value.Location = new System.Drawing.Point(1220, 1);
            this.lelTotalpaidEXVAT_value.Name = "lelTotalpaidEXVAT_value";
            this.lelTotalpaidEXVAT_value.Size = new System.Drawing.Size(48, 21);
            this.lelTotalpaidEXVAT_value.TabIndex = 48;
            this.lelTotalpaidEXVAT_value.Text = "label10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(864, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 49;
            this.label5.Text = "Total Paid(Inc. Vat)";
            // 
            // lelTotalpaidIncVAT_value
            // 
            this.lelTotalpaidIncVAT_value.AutoSize = true;
            this.lelTotalpaidIncVAT_value.BackColor = System.Drawing.Color.Transparent;
            this.lelTotalpaidIncVAT_value.Dock = System.Windows.Forms.DockStyle.Right;
            this.lelTotalpaidIncVAT_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelTotalpaidIncVAT_value.ForeColor = System.Drawing.Color.Black;
            this.lelTotalpaidIncVAT_value.Location = new System.Drawing.Point(1220, 23);
            this.lelTotalpaidIncVAT_value.Name = "lelTotalpaidIncVAT_value";
            this.lelTotalpaidIncVAT_value.Size = new System.Drawing.Size(48, 21);
            this.lelTotalpaidIncVAT_value.TabIndex = 50;
            this.lelTotalpaidIncVAT_value.Text = "label10";
            // 
            // btnItemWiseReport
            // 
            this.btnItemWiseReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItemWiseReport.BackColor = System.Drawing.Color.Transparent;
            this.btnItemWiseReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnItemWiseReport.BackgroundImage")));
            this.btnItemWiseReport.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnItemWiseReport.BgImageOnMouseDown")));
            this.btnItemWiseReport.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnItemWiseReport.BgImageOnMouseUp")));
            this.btnItemWiseReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnItemWiseReport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnItemWiseReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnItemWiseReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnItemWiseReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemWiseReport.Font = new System.Drawing.Font("Arial", 10F);
            this.btnItemWiseReport.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnItemWiseReport.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnItemWiseReport.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnItemWiseReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItemWiseReport.Location = new System.Drawing.Point(-10, 579);
            this.btnItemWiseReport.Name = "btnItemWiseReport";
            this.btnItemWiseReport.Size = new System.Drawing.Size(160, 50);
            this.btnItemWiseReport.TabIndex = 30;
            this.btnItemWiseReport.Text = "View Item Wise Report";
            this.btnItemWiseReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItemWiseReport.UseVisualStyleBackColor = true;
            this.btnItemWiseReport.Visible = false;
            this.btnItemWiseReport.Click += new System.EventHandler(this.btnItemWiseReport_Click);
            // 
            // radioButtonCheat
            // 
            this.radioButtonCheat.AutoSize = true;
            this.radioButtonCheat.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonCheat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButtonCheat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCheat.ForeColor = System.Drawing.Color.Black;
            this.radioButtonCheat.Location = new System.Drawing.Point(48, 5);
            this.radioButtonCheat.Name = "radioButtonCheat";
            this.radioButtonCheat.Size = new System.Drawing.Size(104, 17);
            this.radioButtonCheat.TabIndex = 43;
            this.radioButtonCheat.Text = "Reduced Report";
            this.radioButtonCheat.UseVisualStyleBackColor = false;
            this.radioButtonCheat.Click += new System.EventHandler(this.radioButtonCheat_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
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
            this.dataGridView1.GridColor = System.Drawing.Color.Gray;
            this.dataGridView1.Location = new System.Drawing.Point(6, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1272, 246);
            this.dataGridView1.TabIndex = 52;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.orderComplementoryRadioButton);
            this.panel10.Controls.Add(this.dueTotalradioButton1);
            this.panel10.Controls.Add(this.complementoryRadioButton);
            this.panel10.Controls.Add(this.dueRadioButton);
            this.panel10.Controls.Add(this.tableNumbertextBox);
            this.panel10.Controls.Add(this.tableNumberradioButton);
            this.panel10.Controls.Add(this.waitercomboBox);
            this.panel10.Controls.Add(this.waiterradioButton);
            this.panel10.Controls.Add(this.toTimeFormatcomboBox);
            this.panel10.Controls.Add(this.label11);
            this.panel10.Controls.Add(this.toMinutecomboBox);
            this.panel10.Controls.Add(this.toHourcomboBox);
            this.panel10.Controls.Add(this.label12);
            this.panel10.Controls.Add(this.fromTimeFormatcomboBox);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.fromMinutecomboBox);
            this.panel10.Controls.Add(this.fromHourcomboBox);
            this.panel10.Controls.Add(this.label13);
            this.panel10.Controls.Add(this.chkTerminalName);
            this.panel10.Controls.Add(this.cmbTerminalName);
            this.panel10.Controls.Add(this.comboBoxYear);
            this.panel10.Controls.Add(this.btnSetToday);
            this.panel10.Controls.Add(this.label8);
            this.panel10.Controls.Add(this.comboBoxMonthList);
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
            this.panel10.Controls.Add(this.cheatPanel);
            this.panel10.Controls.Add(this.btn_go);
            this.panel10.Controls.Add(this.txtBoxSerialNumber);
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.dataGridView1);
            this.panel10.Location = new System.Drawing.Point(5, 53);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.panel10.Size = new System.Drawing.Size(1285, 358);
            this.panel10.TabIndex = 53;
            this.panel10.Paint += new System.Windows.Forms.PaintEventHandler(this.panel10_Paint);
            // 
            // orderComplementoryRadioButton
            // 
            this.orderComplementoryRadioButton.AutoSize = true;
            this.orderComplementoryRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.orderComplementoryRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderComplementoryRadioButton.Location = new System.Drawing.Point(1066, 71);
            this.orderComplementoryRadioButton.Name = "orderComplementoryRadioButton";
            this.orderComplementoryRadioButton.Size = new System.Drawing.Size(165, 21);
            this.orderComplementoryRadioButton.TabIndex = 102;
            this.orderComplementoryRadioButton.Text = "Order Complementory";
            this.orderComplementoryRadioButton.UseVisualStyleBackColor = false;
            // 
            // dueTotalradioButton1
            // 
            this.dueTotalradioButton1.AutoSize = true;
            this.dueTotalradioButton1.BackColor = System.Drawing.Color.Transparent;
            this.dueTotalradioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dueTotalradioButton1.Location = new System.Drawing.Point(582, 37);
            this.dueTotalradioButton1.Name = "dueTotalradioButton1";
            this.dueTotalradioButton1.Size = new System.Drawing.Size(93, 21);
            this.dueTotalradioButton1.TabIndex = 101;
            this.dueTotalradioButton1.Text = "Due Order";
            this.dueTotalradioButton1.UseVisualStyleBackColor = false;
            // 
            // complementoryRadioButton
            // 
            this.complementoryRadioButton.AutoSize = true;
            this.complementoryRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.complementoryRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complementoryRadioButton.Location = new System.Drawing.Point(936, 70);
            this.complementoryRadioButton.Name = "complementoryRadioButton";
            this.complementoryRadioButton.Size = new System.Drawing.Size(124, 21);
            this.complementoryRadioButton.TabIndex = 100;
            this.complementoryRadioButton.Text = "Complementory";
            this.complementoryRadioButton.UseVisualStyleBackColor = false;
            // 
            // dueRadioButton
            // 
            this.dueRadioButton.AutoSize = true;
            this.dueRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.dueRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dueRadioButton.Location = new System.Drawing.Point(878, 69);
            this.dueRadioButton.Name = "dueRadioButton";
            this.dueRadioButton.Size = new System.Drawing.Size(52, 21);
            this.dueRadioButton.TabIndex = 99;
            this.dueRadioButton.Text = "Due";
            this.dueRadioButton.UseVisualStyleBackColor = false;
            // 
            // tableNumbertextBox
            // 
            this.tableNumbertextBox.Enabled = false;
            this.tableNumbertextBox.Location = new System.Drawing.Point(772, 69);
            this.tableNumbertextBox.Name = "tableNumbertextBox";
            this.tableNumbertextBox.Size = new System.Drawing.Size(100, 20);
            this.tableNumbertextBox.TabIndex = 98;
            // 
            // tableNumberradioButton
            // 
            this.tableNumberradioButton.AutoSize = true;
            this.tableNumberradioButton.BackColor = System.Drawing.Color.Transparent;
            this.tableNumberradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableNumberradioButton.Location = new System.Drawing.Point(661, 66);
            this.tableNumberradioButton.Name = "tableNumberradioButton";
            this.tableNumberradioButton.Size = new System.Drawing.Size(116, 21);
            this.tableNumberradioButton.TabIndex = 97;
            this.tableNumberradioButton.Text = "Table Number";
            this.tableNumberradioButton.UseVisualStyleBackColor = false;
            this.tableNumberradioButton.CheckedChanged += new System.EventHandler(this.tableNumberradioButton_CheckedChanged);
            // 
            // waitercomboBox
            // 
            this.waitercomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waitercomboBox.Enabled = false;
            this.waitercomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitercomboBox.FormattingEnabled = true;
            this.waitercomboBox.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019"});
            this.waitercomboBox.Location = new System.Drawing.Point(79, 65);
            this.waitercomboBox.Name = "waitercomboBox";
            this.waitercomboBox.Size = new System.Drawing.Size(71, 24);
            this.waitercomboBox.TabIndex = 96;
            // 
            // waiterradioButton
            // 
            this.waiterradioButton.AutoSize = true;
            this.waiterradioButton.BackColor = System.Drawing.Color.Transparent;
            this.waiterradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waiterradioButton.Location = new System.Drawing.Point(13, 66);
            this.waiterradioButton.Name = "waiterradioButton";
            this.waiterradioButton.Size = new System.Drawing.Size(67, 21);
            this.waiterradioButton.TabIndex = 95;
            this.waiterradioButton.Text = "Waiter";
            this.waiterradioButton.UseVisualStyleBackColor = false;
            this.waiterradioButton.CheckedChanged += new System.EventHandler(this.waiterradioButton_CheckedChanged);
            // 
            // toTimeFormatcomboBox
            // 
            this.toTimeFormatcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTimeFormatcomboBox.FormattingEnabled = true;
            this.toTimeFormatcomboBox.Location = new System.Drawing.Point(887, 34);
            this.toTimeFormatcomboBox.Name = "toTimeFormatcomboBox";
            this.toTimeFormatcomboBox.Size = new System.Drawing.Size(45, 24);
            this.toTimeFormatcomboBox.TabIndex = 94;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(769, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 16);
            this.label11.TabIndex = 93;
            this.label11.Text = ":";
            // 
            // toMinutecomboBox
            // 
            this.toMinutecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toMinutecomboBox.FormattingEnabled = true;
            this.toMinutecomboBox.Location = new System.Drawing.Point(839, 34);
            this.toMinutecomboBox.Name = "toMinutecomboBox";
            this.toMinutecomboBox.Size = new System.Drawing.Size(40, 24);
            this.toMinutecomboBox.TabIndex = 92;
            // 
            // toHourcomboBox
            // 
            this.toHourcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toHourcomboBox.FormattingEnabled = true;
            this.toHourcomboBox.Location = new System.Drawing.Point(787, 34);
            this.toHourcomboBox.Name = "toHourcomboBox";
            this.toHourcomboBox.Size = new System.Drawing.Size(40, 24);
            this.toHourcomboBox.TabIndex = 91;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(750, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 16);
            this.label12.TabIndex = 90;
            this.label12.Text = "To";
            // 
            // fromTimeFormatcomboBox
            // 
            this.fromTimeFormatcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTimeFormatcomboBox.FormattingEnabled = true;
            this.fromTimeFormatcomboBox.Location = new System.Drawing.Point(887, 4);
            this.fromTimeFormatcomboBox.Name = "fromTimeFormatcomboBox";
            this.fromTimeFormatcomboBox.Size = new System.Drawing.Size(45, 24);
            this.fromTimeFormatcomboBox.TabIndex = 89;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(769, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 16);
            this.label9.TabIndex = 88;
            this.label9.Text = ":";
            // 
            // fromMinutecomboBox
            // 
            this.fromMinutecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromMinutecomboBox.FormattingEnabled = true;
            this.fromMinutecomboBox.Location = new System.Drawing.Point(839, 4);
            this.fromMinutecomboBox.Name = "fromMinutecomboBox";
            this.fromMinutecomboBox.Size = new System.Drawing.Size(40, 24);
            this.fromMinutecomboBox.TabIndex = 87;
            // 
            // fromHourcomboBox
            // 
            this.fromHourcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromHourcomboBox.FormattingEnabled = true;
            this.fromHourcomboBox.Location = new System.Drawing.Point(787, 4);
            this.fromHourcomboBox.Name = "fromHourcomboBox";
            this.fromHourcomboBox.Size = new System.Drawing.Size(40, 24);
            this.fromHourcomboBox.TabIndex = 86;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(734, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 16);
            this.label13.TabIndex = 85;
            this.label13.Text = "From";
            // 
            // chkTerminalName
            // 
            this.chkTerminalName.AutoSize = true;
            this.chkTerminalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkTerminalName.Location = new System.Drawing.Point(158, 66);
            this.chkTerminalName.Name = "chkTerminalName";
            this.chkTerminalName.Size = new System.Drawing.Size(131, 21);
            this.chkTerminalName.TabIndex = 64;
            this.chkTerminalName.Text = "Terminal Name :";
            this.chkTerminalName.UseVisualStyleBackColor = true;
            // 
            // cmbTerminalName
            // 
            this.cmbTerminalName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTerminalName.FormattingEnabled = true;
            this.cmbTerminalName.Location = new System.Drawing.Point(291, 64);
            this.cmbTerminalName.Name = "cmbTerminalName";
            this.cmbTerminalName.Size = new System.Drawing.Size(176, 24);
            this.cmbTerminalName.TabIndex = 63;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019"});
            this.comboBoxYear.Location = new System.Drawing.Point(104, 34);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(71, 24);
            this.comboBoxYear.TabIndex = 61;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // btnSetToday
            // 
            this.btnSetToday.BackColor = System.Drawing.Color.Transparent;
            this.btnSetToday.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetToday.BackgroundImage")));
            this.btnSetToday.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSetToday.BgImageOnMouseDown")));
            this.btnSetToday.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSetToday.BgImageOnMouseUp")));
            this.btnSetToday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSetToday.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSetToday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetToday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetToday.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSetToday.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSetToday.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSetToday.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSetToday.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetToday.Location = new System.Drawing.Point(652, 4);
            this.btnSetToday.Name = "btnSetToday";
            this.btnSetToday.Size = new System.Drawing.Size(67, 30);
            this.btnSetToday.TabIndex = 60;
            this.btnSetToday.Text = "Reset";
            this.btnSetToday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetToday.UseVisualStyleBackColor = true;
            this.btnSetToday.Click += new System.EventHandler(this.btnSetToday_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 17);
            this.label8.TabIndex = 59;
            this.label8.Text = "Select Month :";
            // 
            // comboBoxMonthList
            // 
            this.comboBoxMonthList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonthList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMonthList.FormattingEnabled = true;
            this.comboBoxMonthList.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.comboBoxMonthList.Location = new System.Drawing.Point(180, 34);
            this.comboBoxMonthList.Name = "comboBoxMonthList";
            this.comboBoxMonthList.Size = new System.Drawing.Size(56, 24);
            this.comboBoxMonthList.TabIndex = 58;
            this.comboBoxMonthList.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonthList_SelectedIndexChanged);
            // 
            // checkBoxDateRangeWise
            // 
            this.checkBoxDateRangeWise.AutoSize = true;
            this.checkBoxDateRangeWise.Checked = true;
            this.checkBoxDateRangeWise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDateRangeWise.Location = new System.Drawing.Point(10, 11);
            this.checkBoxDateRangeWise.Name = "checkBoxDateRangeWise";
            this.checkBoxDateRangeWise.Size = new System.Drawing.Size(109, 17);
            this.checkBoxDateRangeWise.TabIndex = 57;
            this.checkBoxDateRangeWise.Text = "With Date Range";
            this.checkBoxDateRangeWise.UseVisualStyleBackColor = true;
            this.checkBoxDateRangeWise.CheckedChanged += new System.EventHandler(this.checkBoxMothWise_CheckedChanged);
            // 
            // cheatPanel
            // 
            this.cheatPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cheatPanel.Controls.Add(this.txtBoxCheatPercent);
            this.cheatPanel.Controls.Add(this.radioButtonCheat);
            this.cheatPanel.Controls.Add(this.radioButtonActualReport);
            this.cheatPanel.Location = new System.Drawing.Point(1026, 5);
            this.cheatPanel.Name = "cheatPanel";
            this.cheatPanel.Size = new System.Drawing.Size(251, 27);
            this.cheatPanel.TabIndex = 56;
            // 
            // txtBoxCheatPercent
            // 
            this.txtBoxCheatPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxCheatPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCheatPercent.Location = new System.Drawing.Point(3, 0);
            this.txtBoxCheatPercent.Mask = "00%";
            this.txtBoxCheatPercent.Name = "txtBoxCheatPercent";
            this.txtBoxCheatPercent.Size = new System.Drawing.Size(39, 26);
            this.txtBoxCheatPercent.TabIndex = 55;
            this.txtBoxCheatPercent.Text = "60";
            this.txtBoxCheatPercent.Visible = false;
            // 
            // radioButtonActualReport
            // 
            this.radioButtonActualReport.AutoSize = true;
            this.radioButtonActualReport.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonActualReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButtonActualReport.Checked = true;
            this.radioButtonActualReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonActualReport.ForeColor = System.Drawing.Color.Black;
            this.radioButtonActualReport.Location = new System.Drawing.Point(158, 5);
            this.radioButtonActualReport.Name = "radioButtonActualReport";
            this.radioButtonActualReport.Size = new System.Drawing.Size(90, 17);
            this.radioButtonActualReport.TabIndex = 51;
            this.radioButtonActualReport.TabStop = true;
            this.radioButtonActualReport.Text = "Actual Report";
            this.radioButtonActualReport.UseVisualStyleBackColor = false;
            // 
            // btn_go
            // 
            this.btn_go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_go.BackColor = System.Drawing.Color.Transparent;
            this.btn_go.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_go.BackgroundImage")));
            this.btn_go.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btn_go.BgImageOnMouseDown")));
            this.btn_go.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btn_go.BgImageOnMouseUp")));
            this.btn_go.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btn_go.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_go.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_go.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_go.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_go.Font = new System.Drawing.Font("Arial", 10F);
            this.btn_go.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btn_go.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btn_go.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btn_go.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_go.Location = new System.Drawing.Point(1227, 41);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(50, 28);
            this.btn_go.TabIndex = 54;
            this.btn_go.Text = "Go";
            this.btn_go.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // txtBoxSerialNumber
            // 
            this.txtBoxSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSerialNumber.Location = new System.Drawing.Point(1094, 42);
            this.txtBoxSerialNumber.Name = "txtBoxSerialNumber";
            this.txtBoxSerialNumber.Size = new System.Drawing.Size(129, 26);
            this.txtBoxSerialNumber.TabIndex = 54;
            this.txtBoxSerialNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSerialNumber_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(946, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "Search with Serial No.  :";
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label7);
            this.panel11.Controls.Add(this.tableLayoutPanel1);
            this.panel11.Controls.Add(this.label10);
            this.panel11.Controls.Add(this.profitlebel);
            this.panel11.Location = new System.Drawing.Point(5, 412);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(5);
            this.panel11.Size = new System.Drawing.Size(1285, 165);
            this.panel11.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, -1);
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
            this.tableLayoutPanel1.Controls.Add(this.itemDiscountlabel, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lelGuest_Value, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelFoodPrice_Value, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelFoodPrice, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelNonfoodPrice, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lelNonfoodPrice_Value, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lelGuest, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelTakeAwayFoodPrice, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lelTakeAwayFoodPrice_Value, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lelTakeAwayNonfoodPrice, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lelTakeAwayNonfoodPrice_Value, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lelTableFoodPrice, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lelTableNonfoodPrice, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lelTableFoodPrice_Value, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lelTableNonfoodPrice_Value, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lelOrderTotal, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lelOrderTotal_Value, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lelServiceCharge, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lelServiceCharge_Value, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lelDiscount, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lelDiscount_Value, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lelTotalpaidEXVAT_value, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lelTotalpaidIncVAT_value, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.lelVat, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.lelVat_Value, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.lelCashTotal_value, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.lel, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.lelEftTotal_value, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.label14, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.dueTotalLabel, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.complementorylabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label16, 6, 5);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1272, 136);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(4, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 15);
            this.label15.TabIndex = 55;
            this.label15.Text = "Complementory Total";
            // 
            // lelFoodPrice
            // 
            this.lelFoodPrice.AutoSize = true;
            this.lelFoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelFoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelFoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelFoodPrice.Location = new System.Drawing.Point(434, 1);
            this.lelFoodPrice.Name = "lelFoodPrice";
            this.lelFoodPrice.Size = new System.Drawing.Size(65, 15);
            this.lelFoodPrice.TabIndex = 16;
            this.lelFoodPrice.Text = "Food price";
            // 
            // lelNonfoodPrice
            // 
            this.lelNonfoodPrice.AutoSize = true;
            this.lelNonfoodPrice.BackColor = System.Drawing.Color.Transparent;
            this.lelNonfoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelNonfoodPrice.ForeColor = System.Drawing.Color.Black;
            this.lelNonfoodPrice.Location = new System.Drawing.Point(434, 23);
            this.lelNonfoodPrice.Name = "lelNonfoodPrice";
            this.lelNonfoodPrice.Size = new System.Drawing.Size(87, 15);
            this.lelNonfoodPrice.TabIndex = 17;
            this.lelNonfoodPrice.Text = "Non food price";
            // 
            // lelOrderTotal
            // 
            this.lelOrderTotal.AutoSize = true;
            this.lelOrderTotal.BackColor = System.Drawing.Color.Transparent;
            this.lelOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelOrderTotal.ForeColor = System.Drawing.Color.Black;
            this.lelOrderTotal.Location = new System.Drawing.Point(434, 45);
            this.lelOrderTotal.Name = "lelOrderTotal";
            this.lelOrderTotal.Size = new System.Drawing.Size(68, 15);
            this.lelOrderTotal.TabIndex = 20;
            this.lelOrderTotal.Text = "Order Total";
            // 
            // lelServiceCharge
            // 
            this.lelServiceCharge.AutoSize = true;
            this.lelServiceCharge.BackColor = System.Drawing.Color.Transparent;
            this.lelServiceCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelServiceCharge.ForeColor = System.Drawing.Color.Black;
            this.lelServiceCharge.Location = new System.Drawing.Point(434, 67);
            this.lelServiceCharge.Name = "lelServiceCharge";
            this.lelServiceCharge.Size = new System.Drawing.Size(88, 15);
            this.lelServiceCharge.TabIndex = 21;
            this.lelServiceCharge.Text = "Service charge";
            // 
            // lelDiscount
            // 
            this.lelDiscount.AutoSize = true;
            this.lelDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lelDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lelDiscount.ForeColor = System.Drawing.Color.Black;
            this.lelDiscount.Location = new System.Drawing.Point(434, 89);
            this.lelDiscount.Name = "lelDiscount";
            this.lelDiscount.Size = new System.Drawing.Size(55, 15);
            this.lelDiscount.TabIndex = 22;
            this.lelDiscount.Text = "Discount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(836, -1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 15);
            this.label10.TabIndex = 52;
            this.label10.Text = "Profit";
            this.label10.Visible = false;
            // 
            // profitlebel
            // 
            this.profitlebel.AutoSize = true;
            this.profitlebel.Location = new System.Drawing.Point(884, 1);
            this.profitlebel.Name = "profitlebel";
            this.profitlebel.Size = new System.Drawing.Size(35, 13);
            this.profitlebel.TabIndex = 51;
            this.profitlebel.Text = "label9";
            this.profitlebel.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(434, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 53;
            this.label14.Text = "Due Total";
            // 
            // dueTotalLabel
            // 
            this.dueTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dueTotalLabel.AutoSize = true;
            this.dueTotalLabel.BackColor = System.Drawing.Color.Transparent;
            this.dueTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dueTotalLabel.ForeColor = System.Drawing.Color.Black;
            this.dueTotalLabel.Location = new System.Drawing.Point(788, 111);
            this.dueTotalLabel.Name = "dueTotalLabel";
            this.dueTotalLabel.Size = new System.Drawing.Size(48, 15);
            this.dueTotalLabel.TabIndex = 54;
            this.dueTotalLabel.Text = "label10";
            // 
            // complementorylabel
            // 
            this.complementorylabel.AutoSize = true;
            this.complementorylabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.complementorylabel.Location = new System.Drawing.Point(365, 111);
            this.complementorylabel.Name = "complementorylabel";
            this.complementorylabel.Size = new System.Drawing.Size(41, 24);
            this.complementorylabel.TabIndex = 56;
            this.complementorylabel.Text = "label16";
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintSummary.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BackgroundImage")));
            this.btnPrintSummary.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BgImageOnMouseDown")));
            this.btnPrintSummary.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.BgImageOnMouseUp")));
            this.btnPrintSummary.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintSummary.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintSummary.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrintSummary.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrintSummary.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrintSummary.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrintSummary.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSummary.Image")));
            this.btnPrintSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSummary.Location = new System.Drawing.Point(328, 594);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(160, 50);
            this.btnPrintSummary.TabIndex = 55;
            this.btnPrintSummary.Text = "Print Summary (Cash And Card)";
            this.btnPrintSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSummary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintSummary.UseVisualStyleBackColor = true;
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // btnFPPrintSummary
            // 
            this.btnFPPrintSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFPPrintSummary.BackColor = System.Drawing.Color.Transparent;
            this.btnFPPrintSummary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFPPrintSummary.BackgroundImage")));
            this.btnFPPrintSummary.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnFPPrintSummary.BgImageOnMouseDown")));
            this.btnFPPrintSummary.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnFPPrintSummary.BgImageOnMouseUp")));
            this.btnFPPrintSummary.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnFPPrintSummary.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnFPPrintSummary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFPPrintSummary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFPPrintSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFPPrintSummary.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFPPrintSummary.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnFPPrintSummary.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnFPPrintSummary.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnFPPrintSummary.Image = ((System.Drawing.Image)(resources.GetObject("btnFPPrintSummary.Image")));
            this.btnFPPrintSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFPPrintSummary.Location = new System.Drawing.Point(490, 594);
            this.btnFPPrintSummary.Name = "btnFPPrintSummary";
            this.btnFPPrintSummary.Size = new System.Drawing.Size(160, 50);
            this.btnFPPrintSummary.TabIndex = 56;
            this.btnFPPrintSummary.Text = "Print Summary (FP)";
            this.btnFPPrintSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFPPrintSummary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFPPrintSummary.UseVisualStyleBackColor = true;
            this.btnFPPrintSummary.Click += new System.EventHandler(this.btnFPPrintSummary_Click);
            // 
            // btnClearFP
            // 
            this.btnClearFP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearFP.BackColor = System.Drawing.Color.Transparent;
            this.btnClearFP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClearFP.BackgroundImage")));
            this.btnClearFP.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnClearFP.BgImageOnMouseDown")));
            this.btnClearFP.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnClearFP.BgImageOnMouseUp")));
            this.btnClearFP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnClearFP.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClearFP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClearFP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClearFP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFP.Font = new System.Drawing.Font("Arial", 10F);
            this.btnClearFP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearFP.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnClearFP.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnClearFP.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnClearFP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearFP.Location = new System.Drawing.Point(837, 594);
            this.btnClearFP.Name = "btnClearFP";
            this.btnClearFP.Size = new System.Drawing.Size(160, 50);
            this.btnClearFP.TabIndex = 57;
            this.btnClearFP.Text = "Clear FP";
            this.btnClearFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearFP.UseVisualStyleBackColor = false;
            this.btnClearFP.Visible = false;
            this.btnClearFP.Click += new System.EventHandler(this.btnClearFP_Click);
            // 
            // functionalButton1
            // 
            this.functionalButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.functionalButton1.BackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BackgroundImage")));
            this.functionalButton1.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BgImageOnMouseDown")));
            this.functionalButton1.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BgImageOnMouseUp")));
            this.functionalButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.functionalButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functionalButton1.Font = new System.Drawing.Font("Arial", 10F);
            this.functionalButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.functionalButton1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton1.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.functionalButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton1.Location = new System.Drawing.Point(654, 593);
            this.functionalButton1.Name = "functionalButton1";
            this.functionalButton1.Size = new System.Drawing.Size(160, 50);
            this.functionalButton1.TabIndex = 58;
            this.functionalButton1.Text = "Amount Report(DateWise)";
            this.functionalButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton1.UseVisualStyleBackColor = false;
            this.functionalButton1.Click += new System.EventHandler(this.functionalButton1_Click);
            // 
            // functionalButton2
            // 
            this.functionalButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.functionalButton2.BackColor = System.Drawing.Color.Transparent;
            this.functionalButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functionalButton2.BackgroundImage")));
            this.functionalButton2.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("functionalButton2.BgImageOnMouseDown")));
            this.functionalButton2.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("functionalButton2.BgImageOnMouseUp")));
            this.functionalButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.functionalButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.functionalButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.functionalButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.functionalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functionalButton2.Font = new System.Drawing.Font("Arial", 10F);
            this.functionalButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.functionalButton2.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton2.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton2.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.functionalButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton2.Location = new System.Drawing.Point(820, 594);
            this.functionalButton2.Name = "functionalButton2";
            this.functionalButton2.Size = new System.Drawing.Size(160, 50);
            this.functionalButton2.TabIndex = 59;
            this.functionalButton2.Text = "Category Wise Report";
            this.functionalButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton2.UseVisualStyleBackColor = false;
            this.functionalButton2.Click += new System.EventHandler(this.functionalButton2_Click);
            // 
            // excelButton
            // 
            this.excelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.excelButton.BackColor = System.Drawing.Color.Transparent;
            this.excelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("excelButton.BackgroundImage")));
            this.excelButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("excelButton.BgImageOnMouseDown")));
            this.excelButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("excelButton.BgImageOnMouseUp")));
            this.excelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.excelButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.excelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.excelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.excelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelButton.Font = new System.Drawing.Font("Arial", 10F);
            this.excelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.excelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.excelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.excelButton.Image = ((System.Drawing.Image)(resources.GetObject("excelButton.Image")));
            this.excelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excelButton.Location = new System.Drawing.Point(5, 594);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(160, 50);
            this.excelButton.TabIndex = 60;
            this.excelButton.Text = "Convert Excel";
            this.excelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // functionalButton3
            // 
            this.functionalButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.functionalButton3.BackColor = System.Drawing.Color.Transparent;
            this.functionalButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functionalButton3.BackgroundImage")));
            this.functionalButton3.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("functionalButton3.BgImageOnMouseDown")));
            this.functionalButton3.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("functionalButton3.BgImageOnMouseUp")));
            this.functionalButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.functionalButton3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.functionalButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.functionalButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.functionalButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functionalButton3.Font = new System.Drawing.Font("Arial", 10F);
            this.functionalButton3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.functionalButton3.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton3.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton3.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.functionalButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton3.Location = new System.Drawing.Point(986, 594);
            this.functionalButton3.Name = "functionalButton3";
            this.functionalButton3.Size = new System.Drawing.Size(160, 50);
            this.functionalButton3.TabIndex = 61;
            this.functionalButton3.Text = "Membership Report";
            this.functionalButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton3.UseVisualStyleBackColor = false;
            this.functionalButton3.Click += new System.EventHandler(this.functionalButton3_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(864, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 15);
            this.label16.TabIndex = 57;
            this.label16.Text = "Item Discount";
            // 
            // itemDiscountlabel
            // 
            this.itemDiscountlabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.itemDiscountlabel.AutoSize = true;
            this.itemDiscountlabel.Location = new System.Drawing.Point(1233, 116);
            this.itemDiscountlabel.Name = "itemDiscountlabel";
            this.itemDiscountlabel.Size = new System.Drawing.Size(35, 13);
            this.itemDiscountlabel.TabIndex = 59;
            this.itemDiscountlabel.Text = "label9";
            // 
            // ViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1295, 647);
            this.Controls.Add(this.functionalButton3);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.functionalButton2);
            this.Controls.Add(this.functionalButton1);
            this.Controls.Add(this.btnClearFP);
            this.Controls.Add(this.btnFPPrintSummary);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnItemWiseReport);
            this.Name = "ViewReport";
            this.Text = "ViewReport";
            this.Load += new System.EventHandler(this.ViewReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewReport_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ViewReport_KeyPress);
            this.Controls.SetChildIndex(this.btnItemWiseReport, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.Controls.SetChildIndex(this.panel10, 0);
            this.Controls.SetChildIndex(this.panel11, 0);
            this.Controls.SetChildIndex(this.btnPrintSummary, 0);
            this.Controls.SetChildIndex(this.btnFPPrintSummary, 0);
            this.Controls.SetChildIndex(this.btnClearFP, 0);
            this.Controls.SetChildIndex(this.functionalButton1, 0);
            this.Controls.SetChildIndex(this.functionalButton2, 0);
            this.Controls.SetChildIndex(this.excelButton, 0);
            this.Controls.SetChildIndex(this.functionalButton3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.cheatPanel.ResumeLayout(false);
            this.cheatPanel.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RMSUI.FunctionalButton btnViewReport;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RMSUI.FunctionalButton btnBack;
        private System.Windows.Forms.Label lelGuest;
        private System.Windows.Forms.Label lelGuest_Value;
        private System.Windows.Forms.Label lelTableFoodPrice;
        private System.Windows.Forms.Label lelTableFoodPrice_Value;
        private System.Windows.Forms.Label lelTableNonfoodPrice;
        private System.Windows.Forms.Label lelTableNonfoodPrice_Value;
        private System.Windows.Forms.Label lelFoodPrice_Value;
        private System.Windows.Forms.Label lelNonfoodPrice_Value;
        private System.Windows.Forms.Label lelVat;
        private System.Windows.Forms.Label lelOrderTotal_Value;
        private System.Windows.Forms.Label lelServiceCharge_Value;
        private System.Windows.Forms.Label lelDiscount_Value;
        private System.Windows.Forms.Label lelVat_Value;
        private System.Windows.Forms.Label lelTakeAwayFoodPrice;
        private System.Windows.Forms.Label lelTakeAwayFoodPrice_Value;
        private System.Windows.Forms.Label lelTakeAwayNonfoodPrice;
        private System.Windows.Forms.Label lelTakeAwayNonfoodPrice_Value;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private RMSUI.FunctionalButton btnPrint;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.RadioButton rbtnTable;
        private System.Windows.Forms.RadioButton rbtnTakeAway;
        private System.Windows.Forms.Label lelOrderType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lelCashTotal_value;
        private System.Windows.Forms.Label lelEftTotal_value;
        private System.Windows.Forms.Label lel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lelTotalpaidEXVAT_value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lelTotalpaidIncVAT_value;
        private SimpleGrid dataGridView1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private FunctionalButton btn_go;
        private System.Windows.Forms.TextBox txtBoxSerialNumber;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonCheat;
        private System.Windows.Forms.RadioButton radioButtonActualReport;
        private System.Windows.Forms.MaskedTextBox txtBoxCheatPercent;
        private System.Windows.Forms.Panel cheatPanel;
        private System.Windows.Forms.PrintDialog printDialog1;
        private FunctionalButton btnItemWiseReport;
        private System.Windows.Forms.Label label7;
        private FunctionalButton btnPrintSummary;
        private System.Windows.Forms.Label lelFoodPrice;
        private System.Windows.Forms.Label lelNonfoodPrice;
        private System.Windows.Forms.Label lelOrderTotal;
        private System.Windows.Forms.Label lelServiceCharge;
        private System.Windows.Forms.Label lelDiscount;
        private FunctionalButton btnFPPrintSummary;
        private System.Windows.Forms.CheckBox checkBoxDateRangeWise;
        private System.Windows.Forms.ComboBox comboBoxMonthList;
        private FunctionalButton btnSetToday;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private FunctionalButton btnClearFP;
        private System.Windows.Forms.CheckBox chkTerminalName;
        private System.Windows.Forms.ComboBox cmbTerminalName;
        private FunctionalButton functionalButton1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label profitlebel;
        private System.Windows.Forms.ComboBox toTimeFormatcomboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox toMinutecomboBox;
        private System.Windows.Forms.ComboBox toHourcomboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox fromTimeFormatcomboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox fromMinutecomboBox;
        private System.Windows.Forms.ComboBox fromHourcomboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox waitercomboBox;
        private System.Windows.Forms.RadioButton waiterradioButton;
        private System.Windows.Forms.RadioButton tableNumberradioButton;
        private System.Windows.Forms.TextBox tableNumbertextBox;
        private FunctionalButton functionalButton2;
        private System.Windows.Forms.RadioButton complementoryRadioButton;
        private System.Windows.Forms.RadioButton dueRadioButton;
        private FunctionalButton excelButton;
        private FunctionalButton functionalButton3;
        private System.Windows.Forms.RadioButton dueTotalradioButton1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label dueTotalLabel;
        private System.Windows.Forms.RadioButton orderComplementoryRadioButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label complementorylabel;
        private System.Windows.Forms.Label itemDiscountlabel;
        private System.Windows.Forms.Label label16;
        //private System.Windows.Forms.Button btnBack;
    }
}