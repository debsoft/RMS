namespace RMS.Common
{
    partial class CMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMessageBox));
            this.g_OKButton = new RMSUI.FunctionalButton();
            this.g_MessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // g_OKButton
            // 
            this.g_OKButton.BackColor = System.Drawing.Color.Transparent;
            this.g_OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_OKButton.BackgroundImage")));
            this.g_OKButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_OKButton.BgImageOnMouseDown")));
            this.g_OKButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_OKButton.BgImageOnMouseUp")));
            this.g_OKButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_OKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_OKButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_OKButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_OKButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_OKButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_OKButton.Location = new System.Drawing.Point(123, 167);
            this.g_OKButton.Name = "g_OKButton";
            this.g_OKButton.Size = new System.Drawing.Size(88, 40);
            this.g_OKButton.TabIndex = 0;
            this.g_OKButton.Text = "OK";
            this.g_OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_OKButton.UseVisualStyleBackColor = false;
            this.g_OKButton.Click += new System.EventHandler(this.g_OKButton_Click);
            // 
            // g_MessageTextBox
            // 
            this.g_MessageTextBox.AllowDrop = true;
            this.g_MessageTextBox.BackColor = System.Drawing.Color.White;
            this.g_MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.g_MessageTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.g_MessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_MessageTextBox.ForeColor = System.Drawing.Color.Black;
            this.g_MessageTextBox.Location = new System.Drawing.Point(22, 12);
            this.g_MessageTextBox.Multiline = true;
            this.g_MessageTextBox.Name = "g_MessageTextBox";
            this.g_MessageTextBox.Size = new System.Drawing.Size(296, 121);
            this.g_MessageTextBox.TabIndex = 38;
            this.g_MessageTextBox.TabStop = false;
            this.g_MessageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 222);
            this.ControlBox = false;
            this.Controls.Add(this.g_MessageTextBox);
            this.Controls.Add(this.g_OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox g_MessageTextBox;
        private RMSUI.FunctionalButton g_OKButton;
    }
}