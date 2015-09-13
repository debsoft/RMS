namespace RMS.Common
{
    partial class CDiscountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDiscountForm));
            this.g_CancelButton = new RMSUI.FunctionalButton();
            this.FixedAmountButton = new RMSUI.FunctionalButton();
            this.PercentButton = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // g_CancelButton
            // 
            this.g_CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.g_CancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_CancelButton.BackgroundImage")));
            this.g_CancelButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_CancelButton.BgImageOnMouseDown")));
            this.g_CancelButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_CancelButton.BgImageOnMouseUp")));
            this.g_CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_CancelButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_CancelButton.Location = new System.Drawing.Point(78, 148);
            this.g_CancelButton.Name = "g_CancelButton";
            this.g_CancelButton.Size = new System.Drawing.Size(120, 40);
            this.g_CancelButton.TabIndex = 3;
            this.g_CancelButton.Text = "Cancel";
            this.g_CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_CancelButton.UseVisualStyleBackColor = false;
            this.g_CancelButton.Click += new System.EventHandler(this.g_CancelButton_Click);
            // 
            // FixedAmountButton
            // 
            this.FixedAmountButton.BackColor = System.Drawing.Color.Transparent;
            this.FixedAmountButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FixedAmountButton.BackgroundImage")));
            this.FixedAmountButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("FixedAmountButton.BgImageOnMouseDown")));
            this.FixedAmountButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("FixedAmountButton.BgImageOnMouseUp")));
            this.FixedAmountButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FixedAmountButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FixedAmountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FixedAmountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FixedAmountButton.Font = new System.Drawing.Font("Arial", 10F);
            this.FixedAmountButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.FixedAmountButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.FixedAmountButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.FixedAmountButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FixedAmountButton.Location = new System.Drawing.Point(78, 84);
            this.FixedAmountButton.Name = "FixedAmountButton";
            this.FixedAmountButton.Size = new System.Drawing.Size(120, 40);
            this.FixedAmountButton.TabIndex = 5;
            this.FixedAmountButton.Text = "In Fixed Amount";
            this.FixedAmountButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FixedAmountButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FixedAmountButton.UseVisualStyleBackColor = false;
            this.FixedAmountButton.Click += new System.EventHandler(this.FixedAmountButton_Click);
            // 
            // PercentButton
            // 
            this.PercentButton.BackColor = System.Drawing.Color.Transparent;
            this.PercentButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PercentButton.BackgroundImage")));
            this.PercentButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("PercentButton.BgImageOnMouseDown")));
            this.PercentButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("PercentButton.BgImageOnMouseUp")));
            this.PercentButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PercentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PercentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PercentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PercentButton.Font = new System.Drawing.Font("Arial", 10F);
            this.PercentButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.PercentButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.PercentButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.PercentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PercentButton.Location = new System.Drawing.Point(78, 23);
            this.PercentButton.Name = "PercentButton";
            this.PercentButton.Size = new System.Drawing.Size(120, 40);
            this.PercentButton.TabIndex = 4;
            this.PercentButton.Text = "In Percentage";
            this.PercentButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PercentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PercentButton.UseVisualStyleBackColor = false;
            this.PercentButton.Click += new System.EventHandler(this.PercentButton_Click);
            // 
            // CDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(301, 223);
            this.ControlBox = false;
            this.Controls.Add(this.FixedAmountButton);
            this.Controls.Add(this.PercentButton);
            this.Controls.Add(this.g_CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CDiscountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Discount";
            this.ResumeLayout(false);

        }

        #endregion

        private RMSUI.FunctionalButton g_CancelButton;
        private RMSUI.FunctionalButton PercentButton;
        private RMSUI.FunctionalButton FixedAmountButton;
    }
}