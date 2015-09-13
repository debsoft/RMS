namespace RMS
{
    partial class ViewOrderLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewOrderLogForm));
            this.dgvLogRecords = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackButton = new RMSUI.FunctionalButton();
            this.btnPrint = new RMSUI.FunctionalButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLogRecords
            // 
            this.dgvLogRecords.AllowUserToAddRows = false;
            this.dgvLogRecords.AllowUserToDeleteRows = false;
            this.dgvLogRecords.AllowUserToResizeColumns = false;
            this.dgvLogRecords.AllowUserToResizeRows = false;
            this.dgvLogRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLogRecords.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvLogRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column5,
            this.Column1,
            this.Column3,
            this.Column4});
            this.dgvLogRecords.Location = new System.Drawing.Point(42, 67);
            this.dgvLogRecords.Name = "dgvLogRecords";
            this.dgvLogRecords.ReadOnly = true;
            this.dgvLogRecords.RowHeadersVisible = false;
            this.dgvLogRecords.Size = new System.Drawing.Size(717, 428);
            this.dgvLogRecords.TabIndex = 13;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Terminal ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Order Id";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "User Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Date and Time";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Activity";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
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
            this.BackButton.Location = new System.Drawing.Point(664, 518);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 40);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Back ";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseDown")));
            this.btnPrint.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrint.BgImageOnMouseUp")));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrint.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrint.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrint.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(563, 518);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 40);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ViewOrderLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvLogRecords);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.btnPrint);
            this.Name = "ViewOrderLogForm";
            this.ScreenTitle = "Order Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewOrderLogForm";
            this.Activated += new System.EventHandler(this.ViewOrderLogForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewOrderLogForm_FormClosed);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.dgvLogRecords, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLogRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private RMSUI.FunctionalButton BackButton;
        private RMSUI.FunctionalButton btnPrint;
    }
}