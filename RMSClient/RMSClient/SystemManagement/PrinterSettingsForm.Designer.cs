namespace RMS.SystemManagement
{
    partial class PrinterSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinterSettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxKitchenPrinterName = new System.Windows.Forms.TextBox();
            this.txtBoxBevaragePrinterName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonYex = new System.Windows.Forms.RadioButton();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.txtBoxClientPrinterName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPrinterList = new System.Windows.Forms.ComboBox();
            this.cbBevaragePrinter = new System.Windows.Forms.ComboBox();
            this.cbGuestBillPrinterList = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbBevaragePrintSize38 = new System.Windows.Forms.RadioButton();
            this.rdbBevaragePrintSize26 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbKitchenPaperSize38 = new System.Windows.Forms.RadioButton();
            this.rdbKitchenPaperSize26 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxotherBillPrinterList = new System.Windows.Forms.ComboBox();
            this.txtBoxotherPrinterName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxothernonfoodBillPrinterList = new System.Windows.Forms.ComboBox();
            this.txtBoxothernonfoodPrinterNametextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTestKitchenPrint = new RMSUI.FunctionalButton();
            this.btnTestBevaragePrint = new RMSUI.FunctionalButton();
            this.functionalButton2 = new RMSUI.FunctionalButton();
            this.btnPrinterSettings = new RMSUI.FunctionalButton();
            this.btnTestClientPrint = new RMSUI.FunctionalButton();
            this.keyboard1 = new RMSUI.keyboard();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 17);
            this.label1.TabIndex = 96;
            this.label1.Text = "Kitchen Printer Name/Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 17);
            this.label2.TabIndex = 97;
            this.label2.Text = "Bevarage Printer Name/Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 17);
            this.label3.TabIndex = 98;
            this.label3.Text = "Enable Serial Printer";
            // 
            // txtBoxKitchenPrinterName
            // 
            this.txtBoxKitchenPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxKitchenPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxKitchenPrinterName.Location = new System.Drawing.Point(224, 12);
            this.txtBoxKitchenPrinterName.Name = "txtBoxKitchenPrinterName";
            this.txtBoxKitchenPrinterName.Size = new System.Drawing.Size(283, 23);
            this.txtBoxKitchenPrinterName.TabIndex = 99;
            // 
            // txtBoxBevaragePrinterName
            // 
            this.txtBoxBevaragePrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxBevaragePrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBevaragePrinterName.Location = new System.Drawing.Point(224, 46);
            this.txtBoxBevaragePrinterName.Name = "txtBoxBevaragePrinterName";
            this.txtBoxBevaragePrinterName.Size = new System.Drawing.Size(283, 23);
            this.txtBoxBevaragePrinterName.TabIndex = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnTestKitchenPrint);
            this.panel1.Controls.Add(this.btnTestBevaragePrint);
            this.panel1.Controls.Add(this.functionalButton2);
            this.panel1.Controls.Add(this.btnPrinterSettings);
            this.panel1.Controls.Add(this.btnTestClientPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 477);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 59);
            this.panel1.TabIndex = 129;
            // 
            // radioButtonYex
            // 
            this.radioButtonYex.AutoSize = true;
            this.radioButtonYex.Checked = true;
            this.radioButtonYex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonYex.Location = new System.Drawing.Point(226, 166);
            this.radioButtonYex.Name = "radioButtonYex";
            this.radioButtonYex.Size = new System.Drawing.Size(50, 21);
            this.radioButtonYex.TabIndex = 130;
            this.radioButtonYex.TabStop = true;
            this.radioButtonYex.Text = "Yes";
            this.radioButtonYex.UseVisualStyleBackColor = true;
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNo.Location = new System.Drawing.Point(282, 166);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(44, 21);
            this.radioButtonNo.TabIndex = 131;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            // 
            // txtBoxClientPrinterName
            // 
            this.txtBoxClientPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxClientPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxClientPrinterName.Location = new System.Drawing.Point(224, 77);
            this.txtBoxClientPrinterName.Name = "txtBoxClientPrinterName";
            this.txtBoxClientPrinterName.Size = new System.Drawing.Size(283, 23);
            this.txtBoxClientPrinterName.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 17);
            this.label4.TabIndex = 132;
            this.label4.Text = "Guest Bill Printer Name/Address";
            // 
            // cbPrinterList
            // 
            this.cbPrinterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrinterList.FormattingEnabled = true;
            this.cbPrinterList.Location = new System.Drawing.Point(513, 12);
            this.cbPrinterList.Name = "cbPrinterList";
            this.cbPrinterList.Size = new System.Drawing.Size(176, 23);
            this.cbPrinterList.TabIndex = 167;
            this.cbPrinterList.SelectedIndexChanged += new System.EventHandler(this.cbPrinterList_SelectedIndexChanged);
            // 
            // cbBevaragePrinter
            // 
            this.cbBevaragePrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBevaragePrinter.FormattingEnabled = true;
            this.cbBevaragePrinter.Location = new System.Drawing.Point(513, 46);
            this.cbBevaragePrinter.Name = "cbBevaragePrinter";
            this.cbBevaragePrinter.Size = new System.Drawing.Size(176, 23);
            this.cbBevaragePrinter.TabIndex = 168;
            this.cbBevaragePrinter.SelectedIndexChanged += new System.EventHandler(this.cbBevaragePrinter_SelectedIndexChanged);
            // 
            // cbGuestBillPrinterList
            // 
            this.cbGuestBillPrinterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGuestBillPrinterList.FormattingEnabled = true;
            this.cbGuestBillPrinterList.Location = new System.Drawing.Point(513, 77);
            this.cbGuestBillPrinterList.Name = "cbGuestBillPrinterList";
            this.cbGuestBillPrinterList.Size = new System.Drawing.Size(176, 23);
            this.cbGuestBillPrinterList.TabIndex = 169;
            this.cbGuestBillPrinterList.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.rdbKitchenPaperSize38);
            this.panel2.Controls.Add(this.rdbKitchenPaperSize26);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(346, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 33);
            this.panel2.TabIndex = 170;
            this.panel2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdbBevaragePrintSize38);
            this.panel3.Controls.Add(this.rdbBevaragePrintSize26);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(372, 33);
            this.panel3.TabIndex = 171;
            this.panel3.Visible = false;
            // 
            // rdbBevaragePrintSize38
            // 
            this.rdbBevaragePrintSize38.AutoSize = true;
            this.rdbBevaragePrintSize38.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBevaragePrintSize38.Location = new System.Drawing.Point(274, 4);
            this.rdbBevaragePrintSize38.Name = "rdbBevaragePrintSize38";
            this.rdbBevaragePrintSize38.Size = new System.Drawing.Size(42, 21);
            this.rdbBevaragePrintSize38.TabIndex = 137;
            this.rdbBevaragePrintSize38.TabStop = true;
            this.rdbBevaragePrintSize38.Text = "38";
            this.rdbBevaragePrintSize38.UseVisualStyleBackColor = true;
            // 
            // rdbBevaragePrintSize26
            // 
            this.rdbBevaragePrintSize26.AutoSize = true;
            this.rdbBevaragePrintSize26.Checked = true;
            this.rdbBevaragePrintSize26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBevaragePrintSize26.Location = new System.Drawing.Point(203, 4);
            this.rdbBevaragePrintSize26.Name = "rdbBevaragePrintSize26";
            this.rdbBevaragePrintSize26.Size = new System.Drawing.Size(42, 21);
            this.rdbBevaragePrintSize26.TabIndex = 136;
            this.rdbBevaragePrintSize26.TabStop = true;
            this.rdbBevaragePrintSize26.Text = "26";
            this.rdbBevaragePrintSize26.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 17);
            this.label6.TabIndex = 135;
            this.label6.Text = "Bevarage Printer Paper Size";
            // 
            // rdbKitchenPaperSize38
            // 
            this.rdbKitchenPaperSize38.AutoSize = true;
            this.rdbKitchenPaperSize38.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKitchenPaperSize38.Location = new System.Drawing.Point(274, 6);
            this.rdbKitchenPaperSize38.Name = "rdbKitchenPaperSize38";
            this.rdbKitchenPaperSize38.Size = new System.Drawing.Size(42, 21);
            this.rdbKitchenPaperSize38.TabIndex = 134;
            this.rdbKitchenPaperSize38.TabStop = true;
            this.rdbKitchenPaperSize38.Text = "38";
            this.rdbKitchenPaperSize38.UseVisualStyleBackColor = true;
            // 
            // rdbKitchenPaperSize26
            // 
            this.rdbKitchenPaperSize26.AutoSize = true;
            this.rdbKitchenPaperSize26.Checked = true;
            this.rdbKitchenPaperSize26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKitchenPaperSize26.Location = new System.Drawing.Point(203, 6);
            this.rdbKitchenPaperSize26.Name = "rdbKitchenPaperSize26";
            this.rdbKitchenPaperSize26.Size = new System.Drawing.Size(42, 21);
            this.rdbKitchenPaperSize26.TabIndex = 133;
            this.rdbKitchenPaperSize26.TabStop = true;
            this.rdbKitchenPaperSize26.Text = "26";
            this.rdbKitchenPaperSize26.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 17);
            this.label5.TabIndex = 132;
            this.label5.Text = "Kitchen Printer Paper Size";
            // 
            // comboBoxotherBillPrinterList
            // 
            this.comboBoxotherBillPrinterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxotherBillPrinterList.FormattingEnabled = true;
            this.comboBoxotherBillPrinterList.Location = new System.Drawing.Point(514, 111);
            this.comboBoxotherBillPrinterList.Name = "comboBoxotherBillPrinterList";
            this.comboBoxotherBillPrinterList.Size = new System.Drawing.Size(176, 23);
            this.comboBoxotherBillPrinterList.TabIndex = 173;
            this.comboBoxotherBillPrinterList.SelectedIndexChanged += new System.EventHandler(this.comboBoxotherBillPrinterList_SelectedIndexChanged);
            // 
            // txtBoxotherPrinterName
            // 
            this.txtBoxotherPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxotherPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxotherPrinterName.Location = new System.Drawing.Point(225, 111);
            this.txtBoxotherPrinterName.Name = "txtBoxotherPrinterName";
            this.txtBoxotherPrinterName.Size = new System.Drawing.Size(283, 23);
            this.txtBoxotherPrinterName.TabIndex = 172;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 17);
            this.label7.TabIndex = 171;
            this.label7.Text = "Other Bill Printer Name/Address";
            // 
            // comboBoxothernonfoodBillPrinterList
            // 
            this.comboBoxothernonfoodBillPrinterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxothernonfoodBillPrinterList.FormattingEnabled = true;
            this.comboBoxothernonfoodBillPrinterList.Location = new System.Drawing.Point(513, 141);
            this.comboBoxothernonfoodBillPrinterList.Name = "comboBoxothernonfoodBillPrinterList";
            this.comboBoxothernonfoodBillPrinterList.Size = new System.Drawing.Size(176, 23);
            this.comboBoxothernonfoodBillPrinterList.TabIndex = 176;
            this.comboBoxothernonfoodBillPrinterList.SelectedIndexChanged += new System.EventHandler(this.comboBoxothernonfoodBillPrinterList_SelectedIndexChanged);
            // 
            // txtBoxothernonfoodPrinterNametextBox
            // 
            this.txtBoxothernonfoodPrinterNametextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxothernonfoodPrinterNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxothernonfoodPrinterNametextBox.Location = new System.Drawing.Point(224, 141);
            this.txtBoxothernonfoodPrinterNametextBox.Name = "txtBoxothernonfoodPrinterNametextBox";
            this.txtBoxothernonfoodPrinterNametextBox.Size = new System.Drawing.Size(283, 23);
            this.txtBoxothernonfoodPrinterNametextBox.TabIndex = 175;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 17);
            this.label8.TabIndex = 174;
            this.label8.Text = "Other NF Bill Printer Name/Add";
            // 
            // btnTestKitchenPrint
            // 
            this.btnTestKitchenPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnTestKitchenPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestKitchenPrint.BackgroundImage")));
            this.btnTestKitchenPrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnTestKitchenPrint.BgImageOnMouseDown")));
            this.btnTestKitchenPrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnTestKitchenPrint.BgImageOnMouseUp")));
            this.btnTestKitchenPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTestKitchenPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTestKitchenPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTestKitchenPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestKitchenPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTestKitchenPrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnTestKitchenPrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnTestKitchenPrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnTestKitchenPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestKitchenPrint.Location = new System.Drawing.Point(282, 10);
            this.btnTestKitchenPrint.Name = "btnTestKitchenPrint";
            this.btnTestKitchenPrint.Size = new System.Drawing.Size(132, 39);
            this.btnTestKitchenPrint.TabIndex = 131;
            this.btnTestKitchenPrint.Text = "Test Kitchen Print";
            this.btnTestKitchenPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestKitchenPrint.UseVisualStyleBackColor = false;
            this.btnTestKitchenPrint.Visible = false;
            this.btnTestKitchenPrint.Click += new System.EventHandler(this.btnTestKitchenPrint_Click);
            // 
            // btnTestBevaragePrint
            // 
            this.btnTestBevaragePrint.BackColor = System.Drawing.Color.Transparent;
            this.btnTestBevaragePrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestBevaragePrint.BackgroundImage")));
            this.btnTestBevaragePrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnTestBevaragePrint.BgImageOnMouseDown")));
            this.btnTestBevaragePrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnTestBevaragePrint.BgImageOnMouseUp")));
            this.btnTestBevaragePrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTestBevaragePrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTestBevaragePrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTestBevaragePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestBevaragePrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTestBevaragePrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnTestBevaragePrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnTestBevaragePrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnTestBevaragePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestBevaragePrint.Location = new System.Drawing.Point(420, 10);
            this.btnTestBevaragePrint.Name = "btnTestBevaragePrint";
            this.btnTestBevaragePrint.Size = new System.Drawing.Size(154, 39);
            this.btnTestBevaragePrint.TabIndex = 130;
            this.btnTestBevaragePrint.Text = "Test Bevarage Print";
            this.btnTestBevaragePrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestBevaragePrint.UseVisualStyleBackColor = false;
            this.btnTestBevaragePrint.Visible = false;
            this.btnTestBevaragePrint.Click += new System.EventHandler(this.btnTestBevaragePrint_Click);
            // 
            // functionalButton2
            // 
            this.functionalButton2.BackColor = System.Drawing.Color.Transparent;
            this.functionalButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functionalButton2.BackgroundImage")));
            this.functionalButton2.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("functionalButton2.BgImageOnMouseDown")));
            this.functionalButton2.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("functionalButton2.BgImageOnMouseUp")));
            this.functionalButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.functionalButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.functionalButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.functionalButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.functionalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functionalButton2.Font = new System.Drawing.Font("Arial", 10F);
            this.functionalButton2.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton2.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton2.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.functionalButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton2.Location = new System.Drawing.Point(580, 10);
            this.functionalButton2.Name = "functionalButton2";
            this.functionalButton2.Size = new System.Drawing.Size(102, 39);
            this.functionalButton2.TabIndex = 129;
            this.functionalButton2.Text = "Close";
            this.functionalButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton2.UseVisualStyleBackColor = false;
            // 
            // btnPrinterSettings
            // 
            this.btnPrinterSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnPrinterSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrinterSettings.BackgroundImage")));
            this.btnPrinterSettings.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrinterSettings.BgImageOnMouseDown")));
            this.btnPrinterSettings.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrinterSettings.BgImageOnMouseUp")));
            this.btnPrinterSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrinterSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrinterSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrinterSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinterSettings.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrinterSettings.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrinterSettings.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrinterSettings.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnPrinterSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrinterSettings.Location = new System.Drawing.Point(13, 10);
            this.btnPrinterSettings.Name = "btnPrinterSettings";
            this.btnPrinterSettings.Size = new System.Drawing.Size(120, 39);
            this.btnPrinterSettings.TabIndex = 127;
            this.btnPrinterSettings.Text = "Save Settings";
            this.btnPrinterSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrinterSettings.UseVisualStyleBackColor = false;
            this.btnPrinterSettings.Click += new System.EventHandler(this.btnSavePrinterSettings_Click);
            // 
            // btnTestClientPrint
            // 
            this.btnTestClientPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnTestClientPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestClientPrint.BackgroundImage")));
            this.btnTestClientPrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnTestClientPrint.BgImageOnMouseDown")));
            this.btnTestClientPrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnTestClientPrint.BgImageOnMouseUp")));
            this.btnTestClientPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTestClientPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTestClientPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTestClientPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestClientPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTestClientPrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnTestClientPrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnTestClientPrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnTestClientPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestClientPrint.Location = new System.Drawing.Point(139, 10);
            this.btnTestClientPrint.Name = "btnTestClientPrint";
            this.btnTestClientPrint.Size = new System.Drawing.Size(137, 39);
            this.btnTestClientPrint.TabIndex = 128;
            this.btnTestClientPrint.Text = "Test Client Print";
            this.btnTestClientPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestClientPrint.UseVisualStyleBackColor = false;
            this.btnTestClientPrint.Visible = false;
            this.btnTestClientPrint.Click += new System.EventHandler(this.btnTestClientPrint_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.keyboard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.Location = new System.Drawing.Point(15, 212);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(666, 247);
            this.keyboard1.TabIndex = 95;
            this.keyboard1.textBox = null;
            // 
            // PrinterSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(790, 536);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxothernonfoodBillPrinterList);
            this.Controls.Add(this.txtBoxothernonfoodPrinterNametextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxotherBillPrinterList);
            this.Controls.Add(this.txtBoxotherPrinterName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbGuestBillPrinterList);
            this.Controls.Add(this.cbBevaragePrinter);
            this.Controls.Add(this.cbPrinterList);
            this.Controls.Add(this.txtBoxClientPrinterName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButtonNo);
            this.Controls.Add(this.radioButtonYex);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBoxBevaragePrinterName);
            this.Controls.Add(this.txtBoxKitchenPrinterName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyboard1);
            this.Name = "PrinterSettingsForm";
            this.Text = "Printer Settings";
            this.Load += new System.EventHandler(this.PrinterSettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RMSUI.keyboard keyboard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxKitchenPrinterName;
        private System.Windows.Forms.TextBox txtBoxBevaragePrinterName;
        private RMSUI.FunctionalButton btnPrinterSettings;
        private RMSUI.FunctionalButton btnTestClientPrint;
        private System.Windows.Forms.Panel panel1;
        private RMSUI.FunctionalButton btnTestKitchenPrint;
        private RMSUI.FunctionalButton btnTestBevaragePrint;
        private RMSUI.FunctionalButton functionalButton2;
        private System.Windows.Forms.RadioButton radioButtonYex;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.TextBox txtBoxClientPrinterName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPrinterList;
        private System.Windows.Forms.ComboBox cbBevaragePrinter;
        private System.Windows.Forms.ComboBox cbGuestBillPrinterList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbKitchenPaperSize38;
        private System.Windows.Forms.RadioButton rdbKitchenPaperSize26;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbBevaragePrintSize38;
        private System.Windows.Forms.RadioButton rdbBevaragePrintSize26;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxotherBillPrinterList;
        private System.Windows.Forms.TextBox txtBoxotherPrinterName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxothernonfoodBillPrinterList;
        private System.Windows.Forms.TextBox txtBoxothernonfoodPrinterNametextBox;
        private System.Windows.Forms.Label label8;
    }
}