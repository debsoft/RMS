namespace RMS.Common
{
    partial class CUseDepositForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CUseDepositForm));
            this.panel6 = new System.Windows.Forms.Panel();
            this.currencyKeyPad1 = new RMSUI.CurrencyKeyPad();
            this.g_InputTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.g_TotalLabel = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.DepositTypeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.UseButton = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SerialNumberLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.g_BalanceLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.currencyKeyPad1);
            this.panel6.Controls.Add(this.g_InputTextBox);
            this.panel6.Location = new System.Drawing.Point(316, 73);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(270, 255);
            this.panel6.TabIndex = 12;
            // 
            // currencyKeyPad1
            // 
            this.currencyKeyPad1.ControlToInputText = this.g_InputTextBox;
            this.currencyKeyPad1.Location = new System.Drawing.Point(6, 27);
            this.currencyKeyPad1.Name = "currencyKeyPad1";
            this.currencyKeyPad1.Size = new System.Drawing.Size(254, 226);
            this.currencyKeyPad1.TabIndex = 65;
            this.currencyKeyPad1.textBox = null;
            // 
            // g_InputTextBox
            // 
            this.g_InputTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.g_InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_InputTextBox.Location = new System.Drawing.Point(2, 2);
            this.g_InputTextBox.Name = "g_InputTextBox";
            this.g_InputTextBox.Size = new System.Drawing.Size(262, 26);
            this.g_InputTextBox.TabIndex = 64;
            this.g_InputTextBox.Text = "�0.000";
            this.g_InputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(316, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(270, 21);
            this.panel4.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(103, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tendered";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.g_TotalLabel);
            this.panel7.Controls.Add(this.label31);
            this.panel7.Controls.Add(this.DepositTypeLabel);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(24, 74);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(270, 128);
            this.panel7.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "By ";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(162, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Amount";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(-1, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "  Payment Type";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // g_TotalLabel
            // 
            this.g_TotalLabel.AutoSize = true;
            this.g_TotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_TotalLabel.ForeColor = System.Drawing.Color.White;
            this.g_TotalLabel.Location = new System.Drawing.Point(162, 32);
            this.g_TotalLabel.Name = "g_TotalLabel";
            this.g_TotalLabel.Size = new System.Drawing.Size(52, 16);
            this.g_TotalLabel.TabIndex = 29;
            this.g_TotalLabel.Text = "�0.000";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(9, 32);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(44, 16);
            this.label31.TabIndex = 20;
            this.label31.Text = "Total";
            // 
            // DepositTypeLabel
            // 
            this.DepositTypeLabel.AutoSize = true;
            this.DepositTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepositTypeLabel.ForeColor = System.Drawing.Color.Black;
            this.DepositTypeLabel.Location = new System.Drawing.Point(41, 63);
            this.DepositTypeLabel.Name = "DepositTypeLabel";
            this.DepositTypeLabel.Size = new System.Drawing.Size(39, 15);
            this.DepositTypeLabel.TabIndex = 21;
            this.DepositTypeLabel.Text = "Cash";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(24, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 21);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(79, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deposit Totals";
            // 
            // UseButton
            // 
            this.UseButton.BackColor = System.Drawing.Color.Transparent;
            this.UseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UseButton.BackgroundImage")));
            this.UseButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("UseButton.BgImageOnMouseDown")));
            this.UseButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("UseButton.BgImageOnMouseUp")));
            this.UseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.UseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UseButton.Font = new System.Drawing.Font("Arial", 10F);
            this.UseButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.UseButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.UseButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.UseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UseButton.Location = new System.Drawing.Point(35, 271);
            this.UseButton.Name = "UseButton";
            this.UseButton.Size = new System.Drawing.Size(120, 40);
            this.UseButton.TabIndex = 87;
            this.UseButton.Text = "Use";
            this.UseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UseButton.UseVisualStyleBackColor = false;
            this.UseButton.Click += new System.EventHandler(this.UseButton_Click);
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
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(162, 271);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 86;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 88;
            this.label2.Text = "Serial No.";
            // 
            // SerialNumberLabel
            // 
            this.SerialNumberLabel.AutoSize = true;
            this.SerialNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialNumberLabel.ForeColor = System.Drawing.Color.White;
            this.SerialNumberLabel.Location = new System.Drawing.Point(125, 25);
            this.SerialNumberLabel.Name = "SerialNumberLabel";
            this.SerialNumberLabel.Size = new System.Drawing.Size(71, 15);
            this.SerialNumberLabel.TabIndex = 89;
            this.SerialNumberLabel.Text = "12121212";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.g_BalanceLabel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(24, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 21);
            this.panel2.TabIndex = 90;
            // 
            // g_BalanceLabel
            // 
            this.g_BalanceLabel.AutoSize = true;
            this.g_BalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_BalanceLabel.ForeColor = System.Drawing.Color.White;
            this.g_BalanceLabel.Location = new System.Drawing.Point(162, -1);
            this.g_BalanceLabel.Name = "g_BalanceLabel";
            this.g_BalanceLabel.Size = new System.Drawing.Size(52, 16);
            this.g_BalanceLabel.TabIndex = 37;
            this.g_BalanceLabel.Text = "�0.000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(9, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Balance";
            // 
            // CUseDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(650, 394);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SerialNumberLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UseButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CUseDepositForm";
            this.Text = " User Deposit";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox g_InputTextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label g_TotalLabel;
        private System.Windows.Forms.Label DepositTypeLabel;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SerialNumberLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label g_BalanceLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private RMSUI.CurrencyKeyPad currencyKeyPad1;
        private RMSUI.FunctionalButton UseButton;
        private RMSUI.FunctionalButton CancelButton;
    }
}