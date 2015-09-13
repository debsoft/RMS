namespace RMS.Common
{
    partial class DueBillPaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DueBillPaymentForm));
            this.CancelButton = new RMSUI.FunctionalButton();
            this.enterbutton = new RMSUI.FunctionalButton();
            this.g_InputTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.currencyKeyPad1 = new RMSUI.CurrencyKeyPad();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelButton.BackgroundImage")));
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseDown")));
            this.CancelButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseUp")));
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(75, 301);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(79, 42);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // enterbutton
            // 
            this.enterbutton.BackColor = System.Drawing.Color.Transparent;
            this.enterbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enterbutton.BackgroundImage")));
            this.enterbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.enterbutton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("enterbutton.BgImageOnMouseDown")));
            this.enterbutton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("enterbutton.BgImageOnMouseUp")));
            this.enterbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.enterbutton.FlatAppearance.BorderSize = 0;
            this.enterbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.enterbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.enterbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterbutton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterbutton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.enterbutton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.enterbutton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.enterbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enterbutton.Location = new System.Drawing.Point(201, 300);
            this.enterbutton.Name = "enterbutton";
            this.enterbutton.Size = new System.Drawing.Size(79, 42);
            this.enterbutton.TabIndex = 13;
            this.enterbutton.Text = "\r\n";
            this.enterbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.enterbutton.UseVisualStyleBackColor = false;
            this.enterbutton.Click += new System.EventHandler(this.enterbutton_Click);
            // 
            // g_InputTextBox
            // 
            this.g_InputTextBox.BackColor = System.Drawing.Color.White;
            this.g_InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.g_InputTextBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_InputTextBox.Location = new System.Drawing.Point(3, 20);
            this.g_InputTextBox.MaxLength = 99999999;
            this.g_InputTextBox.Name = "g_InputTextBox";
            this.g_InputTextBox.Size = new System.Drawing.Size(290, 26);
            this.g_InputTextBox.TabIndex = 64;
            this.g_InputTextBox.Text = "£0.00";
            this.g_InputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tendered";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.currencyKeyPad1);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.g_InputTextBox);
            this.panel6.Location = new System.Drawing.Point(50, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(298, 270);
            this.panel6.TabIndex = 11;
            // 
            // currencyKeyPad1
            // 
            this.currencyKeyPad1.ControlToInputText = this.g_InputTextBox;
            this.currencyKeyPad1.Location = new System.Drawing.Point(9, 57);
            this.currencyKeyPad1.Name = "currencyKeyPad1";
            this.currencyKeyPad1.Size = new System.Drawing.Size(271, 208);
            this.currencyKeyPad1.TabIndex = 65;
            this.currencyKeyPad1.textBox = null;
            // 
            // DueBillPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 352);
            this.ControlBox = false;
            this.Controls.Add(this.enterbutton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.panel6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DueBillPaymentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DueBillPaymentForm";
            this.TopMost = true;
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RMSUI.FunctionalButton CancelButton;
        private RMSUI.FunctionalButton enterbutton;
        private System.Windows.Forms.TextBox g_InputTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private RMSUI.CurrencyKeyPad currencyKeyPad1;
    }
}