namespace RMS.Common
{
    partial class CSpecialModifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSpecialModifyForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.SaveButton = new RMSUI.FunctionalButton();
            this.ContentTextBox = new System.Windows.Forms.TextBox();
            this.PromptLabel = new System.Windows.Forms.Label();
            this.dgvKitchenText = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new RMSUI.FunctionalButton();
            this.keyboard1 = new RMSUI.keyboard();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenText)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelButton.BackgroundImage")));
            this.CancelButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseDown")));
            this.CancelButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseUp")));
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 10F);
            this.CancelButton.ForeColor = System.Drawing.Color.Black;
            this.CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(185, 421);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 41;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
            this.SaveButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("SaveButton.BgImageOnMouseDown")));
            this.SaveButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("SaveButton.BgImageOnMouseUp")));
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Arial", 10F);
            this.SaveButton.ForeColor = System.Drawing.Color.Black;
            this.SaveButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.SaveButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.SaveButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(310, 421);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 40);
            this.SaveButton.TabIndex = 42;
            this.SaveButton.Text = "Modify";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.BackColor = System.Drawing.Color.White;
            this.ContentTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentTextBox.ForeColor = System.Drawing.Color.Black;
            this.ContentTextBox.Location = new System.Drawing.Point(205, 103);
            this.ContentTextBox.Multiline = true;
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(324, 35);
            this.ContentTextBox.TabIndex = 44;
            this.ContentTextBox.Click += new System.EventHandler(this.ContentTextBox_Click);
            // 
            // PromptLabel
            // 
            this.PromptLabel.BackColor = System.Drawing.Color.Transparent;
            this.PromptLabel.ForeColor = System.Drawing.Color.Black;
            this.PromptLabel.Location = new System.Drawing.Point(128, 53);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PromptLabel.Size = new System.Drawing.Size(476, 46);
            this.PromptLabel.TabIndex = 45;
            this.PromptLabel.Text = "Please Enter Special/Modify Information";
            this.PromptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvKitchenText
            // 
            this.dgvKitchenText.AllowUserToAddRows = false;
            this.dgvKitchenText.AllowUserToDeleteRows = false;
            this.dgvKitchenText.AllowUserToOrderColumns = true;
            this.dgvKitchenText.AllowUserToResizeColumns = false;
            this.dgvKitchenText.AllowUserToResizeRows = false;
            this.dgvKitchenText.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgvKitchenText.ColumnHeadersHeight = 25;
            this.dgvKitchenText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvKitchenText.Location = new System.Drawing.Point(666, 51);
            this.dgvKitchenText.Name = "dgvKitchenText";
            this.dgvKitchenText.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKitchenText.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKitchenText.RowHeadersVisible = false;
            this.dgvKitchenText.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvKitchenText.Size = new System.Drawing.Size(143, 350);
            this.dgvKitchenText.TabIndex = 60;
            this.dgvKitchenText.SelectionChanged += new System.EventHandler(this.dgvKitchenText_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Text Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Special Modification Text";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnClear.BgImageOnMouseDown")));
            this.btnClear.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnClear.BgImageOnMouseUp")));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnClear.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnClear.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(435, 421);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.TabIndex = 61;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboard1.ControlToInputText = this.ContentTextBox;
            this.keyboard1.ForeColor = System.Drawing.Color.Black;
            this.keyboard1.Location = new System.Drawing.Point(3, 151);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(660, 250);
            this.keyboard1.TabIndex = 62;
            this.keyboard1.textBox = null;
            // 
            // CSpecialModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(811, 571);
            this.Controls.Add(this.dgvKitchenText);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.ContentTextBox);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CSpecialModifyForm";
            this.ScreenTitle = "Special Modify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Special/Modify";
            this.Load += new System.EventHandler(this.CSpecialModifyForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CMiscItemForm_Paint);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.Controls.SetChildIndex(this.ContentTextBox, 0);
            this.Controls.SetChildIndex(this.PromptLabel, 0);
            this.Controls.SetChildIndex(this.dgvKitchenText, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ContentTextBox;
        private System.Windows.Forms.Label PromptLabel;
        private System.Windows.Forms.DataGridView dgvKitchenText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton CancelButton;
        private RMSUI.FunctionalButton SaveButton;
        private RMSUI.FunctionalButton btnClear;

    }
}