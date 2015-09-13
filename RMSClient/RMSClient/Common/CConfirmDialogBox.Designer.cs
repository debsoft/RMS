namespace RMS.Common
{
    partial class CConfirmDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CConfirmDialogBox));
            this.g_YesButton = new RMSUI.FunctionalButton();
            this.g_MessageLabel = new System.Windows.Forms.Label();
            this.g_NoButton = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // g_YesButton
            // 
            this.g_YesButton.BackColor = System.Drawing.Color.Transparent;
            this.g_YesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_YesButton.BackgroundImage")));
            this.g_YesButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_YesButton.BgImageOnMouseDown")));
            this.g_YesButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_YesButton.BgImageOnMouseUp")));
            this.g_YesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.g_YesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_YesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_YesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_YesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_YesButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_YesButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_YesButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_YesButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_YesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_YesButton.Location = new System.Drawing.Point(25, 137);
            this.g_YesButton.Name = "g_YesButton";
            this.g_YesButton.Size = new System.Drawing.Size(120, 40);
            this.g_YesButton.TabIndex = 0;
            this.g_YesButton.Text = "Yes";
            this.g_YesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_YesButton.UseVisualStyleBackColor = false;
            this.g_YesButton.Click += new System.EventHandler(this.g_YesButton_Click);
            // 
            // g_MessageLabel
            // 
            this.g_MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.g_MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_MessageLabel.ForeColor = System.Drawing.Color.Black;
            this.g_MessageLabel.Location = new System.Drawing.Point(1, 9);
            this.g_MessageLabel.Name = "g_MessageLabel";
            this.g_MessageLabel.Size = new System.Drawing.Size(303, 109);
            this.g_MessageLabel.TabIndex = 2;
            this.g_MessageLabel.Text = "Message";
            this.g_MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // g_NoButton
            // 
            this.g_NoButton.BackColor = System.Drawing.Color.Transparent;
            this.g_NoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_NoButton.BackgroundImage")));
            this.g_NoButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_NoButton.BgImageOnMouseDown")));
            this.g_NoButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_NoButton.BgImageOnMouseUp")));
            this.g_NoButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.g_NoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_NoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_NoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_NoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_NoButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_NoButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_NoButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_NoButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_NoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_NoButton.Location = new System.Drawing.Point(151, 137);
            this.g_NoButton.Name = "g_NoButton";
            this.g_NoButton.Size = new System.Drawing.Size(120, 40);
            this.g_NoButton.TabIndex = 1;
            this.g_NoButton.Text = "No";
            this.g_NoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_NoButton.UseVisualStyleBackColor = false;
            this.g_NoButton.Click += new System.EventHandler(this.g_NoButton_Click);
            // 
            // CConfirmDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(306, 189);
            this.ControlBox = false;
            this.Controls.Add(this.g_NoButton);
            this.Controls.Add(this.g_MessageLabel);
            this.Controls.Add(this.g_YesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CConfirmDialogBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label g_MessageLabel;
        private RMSUI.FunctionalButton g_YesButton;
        private RMSUI.FunctionalButton g_NoButton;
    }
}