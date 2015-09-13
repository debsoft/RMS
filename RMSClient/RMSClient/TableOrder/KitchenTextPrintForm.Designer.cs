namespace RMS.TableOrder
{
    partial class KitchenTextPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenTextPrintForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PromptLabel = new System.Windows.Forms.Label();
            this.txtKitchenText = new System.Windows.Forms.TextBox();
            this.btnSend = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new RMSUI.FunctionalButton();
            this.dgvKitchenText = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddOrder = new RMSUI.FunctionalButton();
            this.keyboard1 = new RMSUI.keyboard();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenText)).BeginInit();
            this.SuspendLayout();
            // 
            // PromptLabel
            // 
            this.PromptLabel.BackColor = System.Drawing.Color.Transparent;
            this.PromptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromptLabel.ForeColor = System.Drawing.Color.Transparent;
            this.PromptLabel.Location = new System.Drawing.Point(191, 49);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PromptLabel.Size = new System.Drawing.Size(290, 26);
            this.PromptLabel.TabIndex = 89;
            this.PromptLabel.Text = "Kitchen Text ";
            this.PromptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKitchenText
            // 
            this.txtKitchenText.BackColor = System.Drawing.Color.White;
            this.txtKitchenText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKitchenText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKitchenText.ForeColor = System.Drawing.Color.Black;
            this.txtKitchenText.Location = new System.Drawing.Point(138, 78);
            this.txtKitchenText.Multiline = true;
            this.txtKitchenText.Name = "txtKitchenText";
            this.txtKitchenText.Size = new System.Drawing.Size(402, 86);
            this.txtKitchenText.TabIndex = 88;
            this.txtKitchenText.TextChanged += new System.EventHandler(this.txtKitchenText_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSend.BackgroundImage")));
            this.btnSend.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSend.BgImageOnMouseDown")));
            this.btnSend.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSend.BgImageOnMouseUp")));
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSend.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSend.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSend.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(357, 453);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 40);
            this.btnSend.TabIndex = 87;
            this.btnSend.Text = "Send";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelButton.BackgroundImage")));
            this.CancelButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseDown")));
            this.CancelButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseUp")));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 10F);
            this.CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(483, 453);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 86;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(680, 51);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 90;
            this.label1.Text = "Kitchen Text List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnClear.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnClear.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnClear.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(231, 453);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.TabIndex = 91;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvKitchenText
            // 
            this.dgvKitchenText.AllowUserToAddRows = false;
            this.dgvKitchenText.AllowUserToDeleteRows = false;
            this.dgvKitchenText.AllowUserToResizeColumns = false;
            this.dgvKitchenText.AllowUserToResizeRows = false;
            this.dgvKitchenText.ColumnHeadersHeight = 25;
            this.dgvKitchenText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvKitchenText.Location = new System.Drawing.Point(672, 78);
            this.dgvKitchenText.MultiSelect = false;
            this.dgvKitchenText.Name = "dgvKitchenText";
            this.dgvKitchenText.ReadOnly = true;
            this.dgvKitchenText.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvKitchenText.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKitchenText.Size = new System.Drawing.Size(126, 352);
            this.dgvKitchenText.TabIndex = 0;
            this.dgvKitchenText.SelectionChanged += new System.EventHandler(this.dgvKitchenText_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Kitchen Text Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnAddOrder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddOrder.BackgroundImage")));
            this.btnAddOrder.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnAddOrder.BgImageOnMouseDown")));
            this.btnAddOrder.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnAddOrder.BgImageOnMouseUp")));
            this.btnAddOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrder.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAddOrder.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnAddOrder.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnAddOrder.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnAddOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOrder.Location = new System.Drawing.Point(105, 453);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(120, 40);
            this.btnAddOrder.TabIndex = 93;
            this.btnAddOrder.Text = "Add To Order";
            this.btnAddOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboard1.ControlToInputText = this.txtKitchenText;
            this.keyboard1.Location = new System.Drawing.Point(3, 183);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(666, 247);
            this.keyboard1.TabIndex = 94;
            this.keyboard1.textBox = null;
            // 
            // KitchenTextPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvKitchenText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.txtKitchenText);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.btnSend);
            this.Name = "KitchenTextPrintForm";
            this.ScreenTitle = "Kitchen Text Print";
            this.Text = "Kitchen Text ";
            this.Load += new System.EventHandler(this.KitchenTextPrintForm_Load);
            this.Controls.SetChildIndex(this.btnSend, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnAddOrder, 0);
            this.Controls.SetChildIndex(this.txtKitchenText, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.Controls.SetChildIndex(this.PromptLabel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvKitchenText, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PromptLabel;
        private System.Windows.Forms.TextBox txtKitchenText;
        private System.Windows.Forms.Label label1;
        private KeyboardClassLibrary.Keyboardcontrol masterKeyControl;
        private System.Windows.Forms.DataGridView dgvKitchenText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton CancelButton;
        private RMSUI.FunctionalButton btnClear;
        public RMSUI.FunctionalButton btnSend;
        private RMSUI.FunctionalButton btnAddOrder;
    }
}