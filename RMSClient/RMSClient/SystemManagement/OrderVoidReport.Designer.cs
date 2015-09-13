namespace RMS.SystemManagement
{
    partial class OrderVoidReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderVoidReport));
            this.btnSetToday = new RMSUI.FunctionalButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.orderVoiddataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.orderVoiddataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.btnSetToday.Location = new System.Drawing.Point(698, 38);
            this.btnSetToday.Name = "btnSetToday";
            this.btnSetToday.Size = new System.Drawing.Size(67, 30);
            this.btnSetToday.TabIndex = 65;
            this.btnSetToday.Text = "Show";
            this.btnSetToday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetToday.UseVisualStyleBackColor = true;
            this.btnSetToday.Click += new System.EventHandler(this.btnSetToday_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(473, 42);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(219, 23);
            this.dtpEnd.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(442, 45);
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
            this.label1.Location = new System.Drawing.Point(171, 45);
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
            this.dtpStart.Location = new System.Drawing.Point(217, 42);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(219, 23);
            this.dtpStart.TabIndex = 61;
            // 
            // orderVoiddataGridView
            // 
            this.orderVoiddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderVoiddataGridView.Location = new System.Drawing.Point(53, 121);
            this.orderVoiddataGridView.Name = "orderVoiddataGridView";
            this.orderVoiddataGridView.Size = new System.Drawing.Size(830, 330);
            this.orderVoiddataGridView.TabIndex = 66;
            // 
            // OrderVoidReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 463);
            this.Controls.Add(this.orderVoiddataGridView);
            this.Controls.Add(this.btnSetToday);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStart);
            this.Name = "OrderVoidReport";
            this.Text = "OrderVoidReport";
            ((System.ComponentModel.ISupportInitialize)(this.orderVoiddataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RMSUI.FunctionalButton btnSetToday;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DataGridView orderVoiddataGridView;
    }
}