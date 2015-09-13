﻿namespace RMS.Common
{
    partial class CMultipleSplitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMultipleSplitForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGuestbillText = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrintGuestBill = new RMSUI.FunctionalButton();
            this.g_CanceButton = new RMSUI.FunctionalButton();
            this.numericKeyPad1 = new RMSUI.NumericKeyPad();
            this.txtBoxSplit = new System.Windows.Forms.TextBox();
            this.btnSplit = new RMSUI.FunctionalButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblGuestbillText);
            this.panel1.Location = new System.Drawing.Point(220, 43);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(316, 315);
            this.panel1.TabIndex = 0;
            // 
            // lblGuestbillText
            // 
            this.lblGuestbillText.AutoSize = true;
            this.lblGuestbillText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuestbillText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestbillText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGuestbillText.Location = new System.Drawing.Point(5, 5);
            this.lblGuestbillText.Name = "lblGuestbillText";
            this.lblGuestbillText.Size = new System.Drawing.Size(75, 11);
            this.lblGuestbillText.TabIndex = 0;
            this.lblGuestbillText.Tag = "";
            this.lblGuestbillText.Text = " bill text";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnPrintGuestBill);
            this.panel2.Controls.Add(this.g_CanceButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 60);
            this.panel2.TabIndex = 1;
            // 
            // btnPrintGuestBill
            // 
            this.btnPrintGuestBill.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintGuestBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.BackgroundImage")));
            this.btnPrintGuestBill.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.BgImageOnMouseDown")));
            this.btnPrintGuestBill.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.BgImageOnMouseUp")));
            this.btnPrintGuestBill.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPrintGuestBill.Enabled = false;
            this.btnPrintGuestBill.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrintGuestBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintGuestBill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintGuestBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintGuestBill.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrintGuestBill.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrintGuestBill.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrintGuestBill.FunctionType = RMSUI.RMSUIConstants.FunctionType.Print;
            this.btnPrintGuestBill.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGuestBill.Image")));
            this.btnPrintGuestBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintGuestBill.Location = new System.Drawing.Point(206, 9);
            this.btnPrintGuestBill.Name = "btnPrintGuestBill";
            this.btnPrintGuestBill.Size = new System.Drawing.Size(158, 40);
            this.btnPrintGuestBill.TabIndex = 45;
            this.btnPrintGuestBill.Text = "Print Guest Bill";
            this.btnPrintGuestBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintGuestBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintGuestBill.UseVisualStyleBackColor = false;
            this.btnPrintGuestBill.Click += new System.EventHandler(this.btnGuestBill_Click);
            // 
            // g_CanceButton
            // 
            this.g_CanceButton.BackColor = System.Drawing.Color.Transparent;
            this.g_CanceButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_CanceButton.BackgroundImage")));
            this.g_CanceButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_CanceButton.BgImageOnMouseDown")));
            this.g_CanceButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_CanceButton.BgImageOnMouseUp")));
            this.g_CanceButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.g_CanceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_CanceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_CanceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_CanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_CanceButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_CanceButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_CanceButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_CanceButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_CanceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_CanceButton.Location = new System.Drawing.Point(399, 9);
            this.g_CanceButton.Name = "g_CanceButton";
            this.g_CanceButton.Size = new System.Drawing.Size(137, 40);
            this.g_CanceButton.TabIndex = 44;
            this.g_CanceButton.Text = "Close";
            this.g_CanceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_CanceButton.UseVisualStyleBackColor = false;
            // 
            // numericKeyPad1
            // 
            this.numericKeyPad1.BackColor = System.Drawing.Color.White;
            this.numericKeyPad1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericKeyPad1.ControlToInputText = this.txtBoxSplit;
            this.numericKeyPad1.Location = new System.Drawing.Point(20, 75);
            this.numericKeyPad1.Name = "numericKeyPad1";
            this.numericKeyPad1.Size = new System.Drawing.Size(181, 283);
            this.numericKeyPad1.TabIndex = 36;
            // 
            // txtBoxSplit
            // 
            this.txtBoxSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSplit.Location = new System.Drawing.Point(20, 43);
            this.txtBoxSplit.Name = "txtBoxSplit";
            this.txtBoxSplit.Size = new System.Drawing.Size(181, 26);
            this.txtBoxSplit.TabIndex = 37;
            // 
            // btnSplit
            // 
            this.btnSplit.BackColor = System.Drawing.Color.Transparent;
            this.btnSplit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSplit.BackgroundImage")));
            this.btnSplit.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSplit.BgImageOnMouseDown")));
            this.btnSplit.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSplit.BgImageOnMouseUp")));
            this.btnSplit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSplit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSplit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSplit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSplit.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSplit.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSplit.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSplit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSplit.Location = new System.Drawing.Point(30, 309);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(162, 40);
            this.btnSplit.TabIndex = 45;
            this.btnSplit.Text = "Split";
            this.btnSplit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSplit.UseVisualStyleBackColor = false;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Guest Bill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Split Num:";
            // 
            // CMultipleSplitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(548, 434);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.txtBoxSplit);
            this.Controls.Add(this.numericKeyPad1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CMultipleSplitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple Bill Split ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGuestbillText;
        private System.Windows.Forms.Panel panel2;
        private RMSUI.FunctionalButton g_CanceButton;
        private RMSUI.FunctionalButton btnPrintGuestBill;
        private RMSUI.NumericKeyPad numericKeyPad1;
        private RMSUI.FunctionalButton btnSplit;
        private System.Windows.Forms.TextBox txtBoxSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}