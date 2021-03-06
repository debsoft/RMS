namespace RMS.SystemManagement
{
    partial class CBookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBookingForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FinishRadioButton = new System.Windows.Forms.RadioButton();
            this.AllRadioButton = new System.Windows.Forms.RadioButton();
            this.CallBackRadioButton = new System.Windows.Forms.RadioButton();
            this.ConfirmRadioButton = new System.Windows.Forms.RadioButton();
            this.ProvisionalRadioButton = new System.Windows.Forms.RadioButton();
            this.AddButton = new RMSUI.FunctionalButton();
            this.UpdateButton = new RMSUI.FunctionalButton();
            this.DeleteButton = new RMSUI.FunctionalButton();
            this.viewBookingDataGridView = new System.Windows.Forms.DataGridView();
            this.BookingIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myCalendar = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.ViewButton = new RMSUI.FunctionalButton();
            this.MonthPlusButton = new RMSUI.FunctionalButton();
            this.MonthMinusButton = new RMSUI.FunctionalButton();
            this.YearPlusButton = new RMSUI.FunctionalButton();
            this.YearMinusButton = new RMSUI.FunctionalButton();
            this.BackButton = new RMSUI.FunctionalButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewBookingDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.FinishRadioButton);
            this.panel1.Controls.Add(this.AllRadioButton);
            this.panel1.Controls.Add(this.CallBackRadioButton);
            this.panel1.Controls.Add(this.ConfirmRadioButton);
            this.panel1.Controls.Add(this.ProvisionalRadioButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.viewBookingDataGridView);
            this.panel1.Controls.Add(this.myCalendar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DateLabel);
            this.panel1.Controls.Add(this.ViewButton);
            this.panel1.Controls.Add(this.MonthPlusButton);
            this.panel1.Controls.Add(this.MonthMinusButton);
            this.panel1.Controls.Add(this.YearPlusButton);
            this.panel1.Controls.Add(this.YearMinusButton);
            this.panel1.Location = new System.Drawing.Point(3, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 541);
            this.panel1.TabIndex = 2;
            // 
            // FinishRadioButton
            // 
            this.FinishRadioButton.AutoSize = true;
            this.FinishRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.FinishRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishRadioButton.ForeColor = System.Drawing.Color.White;
            this.FinishRadioButton.Location = new System.Drawing.Point(706, 27);
            this.FinishRadioButton.Name = "FinishRadioButton";
            this.FinishRadioButton.Size = new System.Drawing.Size(72, 17);
            this.FinishRadioButton.TabIndex = 65;
            this.FinishRadioButton.Text = "Finished";
            this.FinishRadioButton.UseVisualStyleBackColor = false;
            this.FinishRadioButton.CheckedChanged += new System.EventHandler(this.FinishRadioButton_CheckedChanged);
            // 
            // AllRadioButton
            // 
            this.AllRadioButton.AutoSize = true;
            this.AllRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.AllRadioButton.Checked = true;
            this.AllRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllRadioButton.ForeColor = System.Drawing.Color.White;
            this.AllRadioButton.Location = new System.Drawing.Point(325, 27);
            this.AllRadioButton.Name = "AllRadioButton";
            this.AllRadioButton.Size = new System.Drawing.Size(39, 17);
            this.AllRadioButton.TabIndex = 64;
            this.AllRadioButton.TabStop = true;
            this.AllRadioButton.Text = "All";
            this.AllRadioButton.UseVisualStyleBackColor = false;
            this.AllRadioButton.CheckedChanged += new System.EventHandler(this.AllRadioButton_CheckedChanged);
            // 
            // CallBackRadioButton
            // 
            this.CallBackRadioButton.AutoSize = true;
            this.CallBackRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.CallBackRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallBackRadioButton.ForeColor = System.Drawing.Color.White;
            this.CallBackRadioButton.Location = new System.Drawing.Point(609, 27);
            this.CallBackRadioButton.Name = "CallBackRadioButton";
            this.CallBackRadioButton.Size = new System.Drawing.Size(79, 17);
            this.CallBackRadioButton.TabIndex = 60;
            this.CallBackRadioButton.Text = "Call Back";
            this.CallBackRadioButton.UseVisualStyleBackColor = false;
            this.CallBackRadioButton.CheckedChanged += new System.EventHandler(this.CallBackRadioButton_CheckedChanged);
            // 
            // ConfirmRadioButton
            // 
            this.ConfirmRadioButton.AutoSize = true;
            this.ConfirmRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.ConfirmRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmRadioButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmRadioButton.Location = new System.Drawing.Point(497, 27);
            this.ConfirmRadioButton.Name = "ConfirmRadioButton";
            this.ConfirmRadioButton.Size = new System.Drawing.Size(81, 17);
            this.ConfirmRadioButton.TabIndex = 59;
            this.ConfirmRadioButton.Text = "Confirmed";
            this.ConfirmRadioButton.UseVisualStyleBackColor = false;
            this.ConfirmRadioButton.CheckedChanged += new System.EventHandler(this.ConfirmRadioButton_CheckedChanged);
            // 
            // ProvisionalRadioButton
            // 
            this.ProvisionalRadioButton.AutoSize = true;
            this.ProvisionalRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.ProvisionalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProvisionalRadioButton.ForeColor = System.Drawing.Color.White;
            this.ProvisionalRadioButton.Location = new System.Drawing.Point(386, 27);
            this.ProvisionalRadioButton.Name = "ProvisionalRadioButton";
            this.ProvisionalRadioButton.Size = new System.Drawing.Size(87, 17);
            this.ProvisionalRadioButton.TabIndex = 58;
            this.ProvisionalRadioButton.Text = "Provisional";
            this.ProvisionalRadioButton.UseVisualStyleBackColor = false;
            this.ProvisionalRadioButton.CheckedChanged += new System.EventHandler(this.ProvisionalRadioButton_CheckedChanged);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
            this.AddButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("AddButton.BgImageOnMouseDown")));
            this.AddButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("AddButton.BgImageOnMouseUp")));
            this.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.Black;
            this.AddButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.AddButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.AddButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddButton.Location = new System.Drawing.Point(375, 477);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 40);
            this.AddButton.TabIndex = 56;
            this.AddButton.Text = "Add";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UpdateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpdateButton.BackgroundImage")));
            this.UpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("UpdateButton.BgImageOnMouseDown")));
            this.UpdateButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("UpdateButton.BgImageOnMouseUp")));
            this.UpdateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.UpdateButton.FlatAppearance.BorderSize = 0;
            this.UpdateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.ForeColor = System.Drawing.Color.Black;
            this.UpdateButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.UpdateButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.UpdateButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.Location = new System.Drawing.Point(482, 477);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(120, 40);
            this.UpdateButton.TabIndex = 55;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BgImageOnMouseDown")));
            this.DeleteButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BgImageOnMouseUp")));
            this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.Black;
            this.DeleteButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.DeleteButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.DeleteButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.DeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.Location = new System.Drawing.Point(608, 477);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 40);
            this.DeleteButton.TabIndex = 54;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // viewBookingDataGridView
            // 
            this.viewBookingDataGridView.AllowUserToAddRows = false;
            this.viewBookingDataGridView.AllowUserToDeleteRows = false;
            this.viewBookingDataGridView.AllowUserToResizeRows = false;
            this.viewBookingDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.viewBookingDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.viewBookingDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewBookingDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.viewBookingDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.viewBookingDataGridView.ColumnHeadersHeight = 32;
            this.viewBookingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookingIDColumn,
            this.SLColumn,
            this.CustomerNameColumn,
            this.PhoneColumn,
            this.BookingTypeColumn,
            this.GuestCountColumn,
            this.AddressColumn,
            this.CommentsColumn});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.viewBookingDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.viewBookingDataGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.viewBookingDataGridView.Location = new System.Drawing.Point(312, 67);
            this.viewBookingDataGridView.Name = "viewBookingDataGridView";
            this.viewBookingDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.viewBookingDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.viewBookingDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.viewBookingDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.viewBookingDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.viewBookingDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBookingDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.viewBookingDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.viewBookingDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.viewBookingDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.viewBookingDataGridView.RowTemplate.Height = 20;
            this.viewBookingDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.viewBookingDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.viewBookingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewBookingDataGridView.Size = new System.Drawing.Size(467, 402);
            this.viewBookingDataGridView.TabIndex = 41;
            // 
            // BookingIDColumn
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BookingIDColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.BookingIDColumn.HeaderText = "ID";
            this.BookingIDColumn.Name = "BookingIDColumn";
            this.BookingIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BookingIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookingIDColumn.Visible = false;
            // 
            // SLColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SLColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.SLColumn.HeaderText = "SL";
            this.SLColumn.Name = "SLColumn";
            this.SLColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLColumn.Width = 30;
            // 
            // CustomerNameColumn
            // 
            this.CustomerNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerNameColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.CustomerNameColumn.HeaderText = "Customer Name";
            this.CustomerNameColumn.Name = "CustomerNameColumn";
            this.CustomerNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PhoneColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PhoneColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.PhoneColumn.HeaderText = "Phone";
            this.PhoneColumn.Name = "PhoneColumn";
            this.PhoneColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PhoneColumn.Width = 60;
            // 
            // BookingTypeColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BookingTypeColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.BookingTypeColumn.HeaderText = "Booking Type";
            this.BookingTypeColumn.Name = "BookingTypeColumn";
            this.BookingTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookingTypeColumn.Width = 60;
            // 
            // GuestCountColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GuestCountColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.GuestCountColumn.HeaderText = "No of Guest";
            this.GuestCountColumn.Name = "GuestCountColumn";
            this.GuestCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GuestCountColumn.Width = 40;
            // 
            // AddressColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AddressColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.AddressColumn.HeaderText = "Company / Adress";
            this.AddressColumn.Name = "AddressColumn";
            this.AddressColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AddressColumn.Width = 105;
            // 
            // CommentsColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CommentsColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";
            this.CommentsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CommentsColumn.Width = 95;
            // 
            // myCalendar
            // 
            this.myCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.myCalendar.Location = new System.Drawing.Point(57, 95);
            this.myCalendar.Name = "myCalendar";
            this.myCalendar.TabIndex = 36;
            this.myCalendar.TitleBackColor = System.Drawing.Color.Gray;
            this.myCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.myCalendar_DateChanged);
            this.myCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.myCalendar_DateSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(80, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 23;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.BackColor = System.Drawing.Color.Transparent;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.ForeColor = System.Drawing.Color.White;
            this.DateLabel.Location = new System.Drawing.Point(88, 67);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(101, 20);
            this.DateLabel.TabIndex = 22;
            this.DateLabel.Text = "05-01-2008";
            // 
            // ViewButton
            // 
            this.ViewButton.BackColor = System.Drawing.Color.Transparent;
            this.ViewButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewButton.BackgroundImage")));
            this.ViewButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("ViewButton.BgImageOnMouseDown")));
            this.ViewButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("ViewButton.BgImageOnMouseUp")));
            this.ViewButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ViewButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ViewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewButton.Font = new System.Drawing.Font("Arial", 10F);
            this.ViewButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.ViewButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.ViewButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.ViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewButton.Location = new System.Drawing.Point(88, 308);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(120, 40);
            this.ViewButton.TabIndex = 5;
            this.ViewButton.Text = "View";
            this.ViewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ViewButton.UseVisualStyleBackColor = false;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // MonthPlusButton
            // 
            this.MonthPlusButton.BackColor = System.Drawing.Color.Transparent;
            this.MonthPlusButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MonthPlusButton.BackgroundImage")));
            this.MonthPlusButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("MonthPlusButton.BgImageOnMouseDown")));
            this.MonthPlusButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("MonthPlusButton.BgImageOnMouseUp")));
            this.MonthPlusButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MonthPlusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MonthPlusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MonthPlusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthPlusButton.Font = new System.Drawing.Font("Arial", 10F);
            this.MonthPlusButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.MonthPlusButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.MonthPlusButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.MonthPlusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MonthPlusButton.Location = new System.Drawing.Point(155, 262);
            this.MonthPlusButton.Name = "MonthPlusButton";
            this.MonthPlusButton.Size = new System.Drawing.Size(76, 40);
            this.MonthPlusButton.TabIndex = 4;
            this.MonthPlusButton.Text = "Month(+)";
            this.MonthPlusButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MonthPlusButton.UseVisualStyleBackColor = false;
            this.MonthPlusButton.Click += new System.EventHandler(this.MonthPlusButton_Click);
            // 
            // MonthMinusButton
            // 
            this.MonthMinusButton.BackColor = System.Drawing.Color.Transparent;
            this.MonthMinusButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MonthMinusButton.BackgroundImage")));
            this.MonthMinusButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("MonthMinusButton.BgImageOnMouseDown")));
            this.MonthMinusButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("MonthMinusButton.BgImageOnMouseUp")));
            this.MonthMinusButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MonthMinusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MonthMinusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MonthMinusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthMinusButton.Font = new System.Drawing.Font("Arial", 10F);
            this.MonthMinusButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.MonthMinusButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.MonthMinusButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.MonthMinusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MonthMinusButton.Location = new System.Drawing.Point(74, 262);
            this.MonthMinusButton.Name = "MonthMinusButton";
            this.MonthMinusButton.Size = new System.Drawing.Size(78, 40);
            this.MonthMinusButton.TabIndex = 3;
            this.MonthMinusButton.Text = "Month (-)";
            this.MonthMinusButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MonthMinusButton.UseVisualStyleBackColor = false;
            this.MonthMinusButton.Click += new System.EventHandler(this.MonthMinusButton_Click);
            // 
            // YearPlusButton
            // 
            this.YearPlusButton.BackColor = System.Drawing.Color.Transparent;
            this.YearPlusButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("YearPlusButton.BackgroundImage")));
            this.YearPlusButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("YearPlusButton.BgImageOnMouseDown")));
            this.YearPlusButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("YearPlusButton.BgImageOnMouseUp")));
            this.YearPlusButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.YearPlusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.YearPlusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.YearPlusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YearPlusButton.Font = new System.Drawing.Font("Arial", 10F);
            this.YearPlusButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.YearPlusButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.YearPlusButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.YearPlusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YearPlusButton.Location = new System.Drawing.Point(233, 262);
            this.YearPlusButton.Name = "YearPlusButton";
            this.YearPlusButton.Size = new System.Drawing.Size(71, 40);
            this.YearPlusButton.TabIndex = 2;
            this.YearPlusButton.Text = "Year( +)";
            this.YearPlusButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.YearPlusButton.UseVisualStyleBackColor = false;
            this.YearPlusButton.Click += new System.EventHandler(this.YearPlusButton_Click);
            // 
            // YearMinusButton
            // 
            this.YearMinusButton.BackColor = System.Drawing.Color.Transparent;
            this.YearMinusButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("YearMinusButton.BackgroundImage")));
            this.YearMinusButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("YearMinusButton.BgImageOnMouseDown")));
            this.YearMinusButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("YearMinusButton.BgImageOnMouseUp")));
            this.YearMinusButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.YearMinusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.YearMinusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.YearMinusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YearMinusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearMinusButton.ForeColor = System.Drawing.Color.Black;
            this.YearMinusButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.YearMinusButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.YearMinusButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.YearMinusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YearMinusButton.Location = new System.Drawing.Point(5, 262);
            this.YearMinusButton.Name = "YearMinusButton";
            this.YearMinusButton.Size = new System.Drawing.Size(67, 41);
            this.YearMinusButton.TabIndex = 1;
            this.YearMinusButton.Text = "Year( - )";
            this.YearMinusButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.YearMinusButton.UseVisualStyleBackColor = false;
            this.YearMinusButton.Click += new System.EventHandler(this.YearMinusButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButton.BackgroundImage")));
            this.BackButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseDown")));
            this.BackButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("BackButton.BgImageOnMouseUp")));
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Arial", 10F);
            this.BackButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.BackButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.BackButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Back;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.Location = new System.Drawing.Point(27, 619);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(120, 40);
            this.BackButton.TabIndex = 20;
            this.BackButton.Text = "Back";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(293, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(467, 22);
            this.panel3.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(211, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bookings";
            // 
            // CBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(801, 677);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BackButton);
            this.Name = "CBookingForm";
            this.ScreenTitle = "Customer Booking";
            this.Activated += new System.EventHandler(this.CBookingForm_Activated);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewBookingDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView viewBookingDataGridView;
        private System.Windows.Forms.MonthCalendar myCalendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private RMSUI.FunctionalButton BackButton;
        private RMSUI.FunctionalButton ViewButton;
        private RMSUI.FunctionalButton MonthPlusButton;
        private RMSUI.FunctionalButton MonthMinusButton;
        private RMSUI.FunctionalButton YearPlusButton;
        private RMSUI.FunctionalButton YearMinusButton;
        private RMSUI.FunctionalButton UpdateButton;
        private RMSUI.FunctionalButton DeleteButton;
        private RMSUI.FunctionalButton AddButton;
        private System.Windows.Forms.RadioButton CallBackRadioButton;
        private System.Windows.Forms.RadioButton ConfirmRadioButton;
        private System.Windows.Forms.RadioButton ProvisionalRadioButton;
        private System.Windows.Forms.RadioButton AllRadioButton;
        private System.Windows.Forms.RadioButton FinishRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsColumn;

    }
}