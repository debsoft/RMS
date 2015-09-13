namespace RMS.Common
{
    partial class PaymentMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethod));
            this.cashButton = new RMSUI.FunctionalButton();
            this.eftButton = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // cashButton
            // 
            this.cashButton.BackColor = System.Drawing.Color.Transparent;
            this.cashButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cashButton.BackgroundImage")));
            this.cashButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cashButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("cashButton.BgImageOnMouseDown")));
            this.cashButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("cashButton.BgImageOnMouseUp")));
            this.cashButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cashButton.FlatAppearance.BorderSize = 0;
            this.cashButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cashButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cashButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.cashButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.cashButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.cashButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cashButton.Location = new System.Drawing.Point(75, 12);
            this.cashButton.Name = "cashButton";
            this.cashButton.Size = new System.Drawing.Size(90, 42);
            this.cashButton.TabIndex = 11;
            this.cashButton.Text = "Cash";
            this.cashButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cashButton.UseVisualStyleBackColor = true;
            this.cashButton.Click += new System.EventHandler(this.cashButton_Click);
            // 
            // eftButton
            // 
            this.eftButton.BackColor = System.Drawing.Color.Transparent;
            this.eftButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eftButton.BackgroundImage")));
            this.eftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eftButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("eftButton.BgImageOnMouseDown")));
            this.eftButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("eftButton.BgImageOnMouseUp")));
            this.eftButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.eftButton.FlatAppearance.BorderSize = 0;
            this.eftButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.eftButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.eftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eftButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.eftButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.eftButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.eftButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.eftButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eftButton.Location = new System.Drawing.Point(193, 12);
            this.eftButton.Name = "eftButton";
            this.eftButton.Size = new System.Drawing.Size(90, 42);
            this.eftButton.TabIndex = 12;
            this.eftButton.Text = "EFT";
            this.eftButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.eftButton.UseVisualStyleBackColor = true;
            this.eftButton.Click += new System.EventHandler(this.eftButton_Click);
            // 
            // PaymentMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 80);
            this.ControlBox = false;
            this.Controls.Add(this.eftButton);
            this.Controls.Add(this.cashButton);
            this.Name = "PaymentMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Method";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private RMSUI.FunctionalButton cashButton;
        private RMSUI.FunctionalButton eftButton;
    }
}