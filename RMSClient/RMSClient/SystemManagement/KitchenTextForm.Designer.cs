﻿namespace RMS.SystemManagement
{
    partial class KitchenTextForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenTextForm));
            this.dgvKitchenText = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.txtKitchenText = new System.Windows.Forms.TextBox();
            this.btnClear = new RMSUI.FunctionalButton();
            this.btnDelete = new RMSUI.FunctionalButton();
            this.btnUpdate = new RMSUI.FunctionalButton();
            this.keyboard1 = new RMSUI.keyboard();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenText)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKitchenText
            // 
            this.dgvKitchenText.AllowUserToAddRows = false;
            this.dgvKitchenText.AllowUserToDeleteRows = false;
            this.dgvKitchenText.AllowUserToOrderColumns = true;
            this.dgvKitchenText.AllowUserToResizeColumns = false;
            this.dgvKitchenText.AllowUserToResizeRows = false;
            this.dgvKitchenText.BackgroundColor = System.Drawing.Color.LightGreen;
            this.dgvKitchenText.ColumnHeadersHeight = 25;
            this.dgvKitchenText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvKitchenText.Location = new System.Drawing.Point(684, 81);
            this.dgvKitchenText.Name = "dgvKitchenText";
            this.dgvKitchenText.ReadOnly = true;
            this.dgvKitchenText.RowHeadersVisible = false;
            this.dgvKitchenText.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvKitchenText.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvKitchenText.Size = new System.Drawing.Size(201, 357);
            this.dgvKitchenText.TabIndex = 0;
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
            this.Column2.HeaderText = "Text";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(723, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kitchen Text List";
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
            this.SaveButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.SaveButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.SaveButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(158, 397);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 40);
            this.SaveButton.TabIndex = 85;
            this.SaveButton.Text = "Save";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(534, 397);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 84;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // txtKitchenText
            // 
            this.txtKitchenText.BackColor = System.Drawing.Color.Gainsboro;
            this.txtKitchenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKitchenText.ForeColor = System.Drawing.Color.Black;
            this.txtKitchenText.Location = new System.Drawing.Point(184, 77);
            this.txtKitchenText.Multiline = true;
            this.txtKitchenText.Name = "txtKitchenText";
            this.txtKitchenText.Size = new System.Drawing.Size(339, 41);
            this.txtKitchenText.TabIndex = 86;
            this.txtKitchenText.Click += new System.EventHandler(this.txtKitchenText_Click);
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
            this.btnClear.Location = new System.Drawing.Point(32, 397);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.TabIndex = 87;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnDelete.BgImageOnMouseDown")));
            this.btnDelete.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnDelete.BgImageOnMouseUp")));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10F);
            this.btnDelete.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnDelete.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnDelete.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(409, 397);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 88;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BgImageOnMouseDown")));
            this.btnUpdate.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BgImageOnMouseUp")));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10F);
            this.btnUpdate.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnUpdate.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnUpdate.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(284, 397);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnUpdate.TabIndex = 89;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboard1.ControlToInputText = this.txtKitchenText;
            this.keyboard1.Location = new System.Drawing.Point(14, 135);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(666, 247);
            this.keyboard1.TabIndex = 90;
            this.keyboard1.textBox = null;
            // 
            // KitchenTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(886, 575);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.txtKitchenText);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvKitchenText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KitchenTextForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitchen Text List";
            this.Load += new System.EventHandler(this.KitchenTextForm_Load);
            this.Controls.SetChildIndex(this.dgvKitchenText, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.txtKitchenText, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKitchenText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKitchenText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton SaveButton;
        private RMSUI.FunctionalButton CancelButton;
        private RMSUI.FunctionalButton btnClear;
        private RMSUI.FunctionalButton btnDelete;
        private RMSUI.FunctionalButton btnUpdate;
    }
}