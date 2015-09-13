namespace RMS.SystemManagement
{
    partial class ReservationReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationReport));
            this.reportdataGridView = new System.Windows.Forms.DataGridView();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.reportShowbutton = new RMSUI.FunctionalButton();
            this.printDetailsfunctionalButton = new RMSUI.FunctionalButton();
            ((System.ComponentModel.ISupportInitialize)(this.reportdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportdataGridView
            // 
            this.reportdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportdataGridView.Location = new System.Drawing.Point(38, 105);
            this.reportdataGridView.Name = "reportdataGridView";
            this.reportdataGridView.Size = new System.Drawing.Size(1099, 404);
            this.reportdataGridView.TabIndex = 0;
            this.reportdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reportdataGridView_CellContentClick);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(480, 15);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(219, 23);
            this.dtpEnd.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(449, 18);
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
            this.label1.Location = new System.Drawing.Point(178, 18);
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
            this.dtpStart.Location = new System.Drawing.Point(224, 15);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(219, 23);
            this.dtpStart.TabIndex = 61;
            // 
            // reportShowbutton
            // 
            this.reportShowbutton.BackColor = System.Drawing.Color.Transparent;
            this.reportShowbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reportShowbutton.BackgroundImage")));
            this.reportShowbutton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("reportShowbutton.BgImageOnMouseDown")));
            this.reportShowbutton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("reportShowbutton.BgImageOnMouseUp")));
            this.reportShowbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.reportShowbutton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.reportShowbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.reportShowbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.reportShowbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportShowbutton.Font = new System.Drawing.Font("Arial", 10F);
            this.reportShowbutton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.reportShowbutton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.reportShowbutton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.reportShowbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportShowbutton.Location = new System.Drawing.Point(705, 11);
            this.reportShowbutton.Name = "reportShowbutton";
            this.reportShowbutton.Size = new System.Drawing.Size(67, 30);
            this.reportShowbutton.TabIndex = 65;
            this.reportShowbutton.Text = "Show";
            this.reportShowbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reportShowbutton.UseVisualStyleBackColor = true;
            this.reportShowbutton.Click += new System.EventHandler(this.reportShowbutton_Click);
            // 
            // printDetailsfunctionalButton
            // 
            this.printDetailsfunctionalButton.BackColor = System.Drawing.Color.Transparent;
            this.printDetailsfunctionalButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("printDetailsfunctionalButton.BackgroundImage")));
            this.printDetailsfunctionalButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("printDetailsfunctionalButton.BgImageOnMouseDown")));
            this.printDetailsfunctionalButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("printDetailsfunctionalButton.BgImageOnMouseUp")));
            this.printDetailsfunctionalButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.printDetailsfunctionalButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.printDetailsfunctionalButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.printDetailsfunctionalButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.printDetailsfunctionalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printDetailsfunctionalButton.Font = new System.Drawing.Font("Arial", 10F);
            this.printDetailsfunctionalButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.printDetailsfunctionalButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.printDetailsfunctionalButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.printDetailsfunctionalButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printDetailsfunctionalButton.Location = new System.Drawing.Point(252, 515);
            this.printDetailsfunctionalButton.Name = "printDetailsfunctionalButton";
            this.printDetailsfunctionalButton.Size = new System.Drawing.Size(142, 46);
            this.printDetailsfunctionalButton.TabIndex = 66;
            this.printDetailsfunctionalButton.Text = "PrintDetails";
            this.printDetailsfunctionalButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printDetailsfunctionalButton.UseVisualStyleBackColor = true;
            this.printDetailsfunctionalButton.Click += new System.EventHandler(this.printDetailsfunctionalButton_Click);
            // 
            // ReservationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 562);
            this.Controls.Add(this.printDetailsfunctionalButton);
            this.Controls.Add(this.reportShowbutton);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.reportdataGridView);
            this.Name = "ReservationReport";
            this.Text = "ReservationReport";
            ((System.ComponentModel.ISupportInitialize)(this.reportdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView reportdataGridView;
        private RMSUI.FunctionalButton reportShowbutton;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private RMSUI.FunctionalButton printDetailsfunctionalButton;
    }
}