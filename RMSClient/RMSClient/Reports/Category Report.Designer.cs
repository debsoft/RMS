namespace RMS.Reports
{
    partial class Category_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Category_Report));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.rbtnparentcategory = new System.Windows.Forms.RadioButton();
            this.rbtsubcategory = new System.Windows.Forms.RadioButton();
            this.cmbparentcategory = new System.Windows.Forms.ComboBox();
            this.cmbsubcategory = new System.Windows.Forms.ComboBox();
            this.categorydataGridView = new System.Windows.Forms.DataGridView();
            this.btnViewReport = new RMSUI.FunctionalButton();
            this.functionalButton1 = new RMSUI.FunctionalButton();
            this.lblPriceTotal = new System.Windows.Forms.Label();
            this.itemMenucomboBox = new System.Windows.Forms.ComboBox();
            this.itemRadioButton = new System.Windows.Forms.RadioButton();
            this.complementoryRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.categorydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(502, 4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(219, 23);
            this.dtpEnd.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "From";
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(246, 4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(219, 23);
            this.dtpStart.TabIndex = 61;
            // 
            // rbtnparentcategory
            // 
            this.rbtnparentcategory.AutoSize = true;
            this.rbtnparentcategory.BackColor = System.Drawing.Color.Transparent;
            this.rbtnparentcategory.Checked = true;
            this.rbtnparentcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnparentcategory.Location = new System.Drawing.Point(311, 46);
            this.rbtnparentcategory.Name = "rbtnparentcategory";
            this.rbtnparentcategory.Size = new System.Drawing.Size(129, 21);
            this.rbtnparentcategory.TabIndex = 65;
            this.rbtnparentcategory.TabStop = true;
            this.rbtnparentcategory.Text = "Parent Category";
            this.rbtnparentcategory.UseVisualStyleBackColor = false;
            this.rbtnparentcategory.CheckedChanged += new System.EventHandler(this.rbtnparentcategory_CheckedChanged);
            // 
            // rbtsubcategory
            // 
            this.rbtsubcategory.AutoSize = true;
            this.rbtsubcategory.BackColor = System.Drawing.Color.Transparent;
            this.rbtsubcategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtsubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtsubcategory.Location = new System.Drawing.Point(311, 83);
            this.rbtsubcategory.Name = "rbtsubcategory";
            this.rbtsubcategory.Size = new System.Drawing.Size(112, 21);
            this.rbtsubcategory.TabIndex = 66;
            this.rbtsubcategory.Text = "Sub Category";
            this.rbtsubcategory.UseVisualStyleBackColor = false;
            this.rbtsubcategory.CheckedChanged += new System.EventHandler(this.rbtsubcategory_CheckedChanged);
            // 
            // cmbparentcategory
            // 
            this.cmbparentcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbparentcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbparentcategory.FormattingEnabled = true;
            this.cmbparentcategory.Location = new System.Drawing.Point(446, 46);
            this.cmbparentcategory.Name = "cmbparentcategory";
            this.cmbparentcategory.Size = new System.Drawing.Size(176, 24);
            this.cmbparentcategory.TabIndex = 67;
            // 
            // cmbsubcategory
            // 
            this.cmbsubcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsubcategory.Enabled = false;
            this.cmbsubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsubcategory.FormattingEnabled = true;
            this.cmbsubcategory.Location = new System.Drawing.Point(446, 83);
            this.cmbsubcategory.Name = "cmbsubcategory";
            this.cmbsubcategory.Size = new System.Drawing.Size(176, 24);
            this.cmbsubcategory.TabIndex = 68;
            this.cmbsubcategory.SelectedIndexChanged += new System.EventHandler(this.cmbsubcategory_SelectedIndexChanged);
            // 
            // categorydataGridView
            // 
            this.categorydataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categorydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categorydataGridView.Location = new System.Drawing.Point(75, 244);
            this.categorydataGridView.Name = "categorydataGridView";
            this.categorydataGridView.Size = new System.Drawing.Size(961, 350);
            this.categorydataGridView.TabIndex = 70;
            this.categorydataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.categorydataGridView_DataBindingComplete);
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
            this.btnViewReport.Location = new System.Drawing.Point(547, 188);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(157, 30);
            this.btnViewReport.TabIndex = 69;
            this.btnViewReport.Text = "Show Result";
            this.btnViewReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // functionalButton1
            // 
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
            this.functionalButton1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton1.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.functionalButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton1.Location = new System.Drawing.Point(83, 203);
            this.functionalButton1.Name = "functionalButton1";
            this.functionalButton1.Size = new System.Drawing.Size(157, 30);
            this.functionalButton1.TabIndex = 71;
            this.functionalButton1.Text = "Print";
            this.functionalButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton1.UseVisualStyleBackColor = true;
            this.functionalButton1.Click += new System.EventHandler(this.functionalButton1_Click);
            // 
            // lblPriceTotal
            // 
            this.lblPriceTotal.AutoSize = true;
            this.lblPriceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceTotal.Location = new System.Drawing.Point(784, 203);
            this.lblPriceTotal.Name = "lblPriceTotal";
            this.lblPriceTotal.Size = new System.Drawing.Size(80, 17);
            this.lblPriceTotal.TabIndex = 72;
            this.lblPriceTotal.Text = "Total Price:";
            // 
            // itemMenucomboBox
            // 
            this.itemMenucomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemMenucomboBox.Enabled = false;
            this.itemMenucomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemMenucomboBox.FormattingEnabled = true;
            this.itemMenucomboBox.Location = new System.Drawing.Point(446, 116);
            this.itemMenucomboBox.Name = "itemMenucomboBox";
            this.itemMenucomboBox.Size = new System.Drawing.Size(176, 24);
            this.itemMenucomboBox.TabIndex = 74;
            // 
            // itemRadioButton
            // 
            this.itemRadioButton.AutoSize = true;
            this.itemRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.itemRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.itemRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemRadioButton.Location = new System.Drawing.Point(311, 116);
            this.itemRadioButton.Name = "itemRadioButton";
            this.itemRadioButton.Size = new System.Drawing.Size(91, 21);
            this.itemRadioButton.TabIndex = 73;
            this.itemRadioButton.Text = "Item Menu";
            this.itemRadioButton.UseVisualStyleBackColor = false;
            this.itemRadioButton.CheckedChanged += new System.EventHandler(this.itemRadioButton_CheckedChanged);
            // 
            // complementoryRadioButton
            // 
            this.complementoryRadioButton.AutoSize = true;
            this.complementoryRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.complementoryRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.complementoryRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complementoryRadioButton.Location = new System.Drawing.Point(311, 160);
            this.complementoryRadioButton.Name = "complementoryRadioButton";
            this.complementoryRadioButton.Size = new System.Drawing.Size(124, 21);
            this.complementoryRadioButton.TabIndex = 75;
            this.complementoryRadioButton.Text = "Complementory";
            this.complementoryRadioButton.UseVisualStyleBackColor = false;
            // 
            // Category_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 609);
            this.Controls.Add(this.complementoryRadioButton);
            this.Controls.Add(this.itemMenucomboBox);
            this.Controls.Add(this.itemRadioButton);
            this.Controls.Add(this.lblPriceTotal);
            this.Controls.Add(this.functionalButton1);
            this.Controls.Add(this.categorydataGridView);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.cmbsubcategory);
            this.Controls.Add(this.cmbparentcategory);
            this.Controls.Add(this.rbtnparentcategory);
            this.Controls.Add(this.rbtsubcategory);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStart);
            this.Name = "Category_Report";
            this.Text = "Category_Report";
            ((System.ComponentModel.ISupportInitialize)(this.categorydataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.RadioButton rbtnparentcategory;
        private System.Windows.Forms.RadioButton rbtsubcategory;
        private System.Windows.Forms.ComboBox cmbparentcategory;
        private System.Windows.Forms.ComboBox cmbsubcategory;
        private RMSUI.FunctionalButton btnViewReport;
        private System.Windows.Forms.DataGridView categorydataGridView;
        private RMSUI.FunctionalButton functionalButton1;
        private System.Windows.Forms.Label lblPriceTotal;
        private System.Windows.Forms.ComboBox itemMenucomboBox;
        private System.Windows.Forms.RadioButton itemRadioButton;
        private System.Windows.Forms.RadioButton complementoryRadioButton;
    }
}