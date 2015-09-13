namespace RMS.Common
{
    partial class CCategory4Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCategory4Form));
            this.g_Category4Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.g_CancelButton = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // g_Category4Panel
            // 
            this.g_Category4Panel.Location = new System.Drawing.Point(37, 42);
            this.g_Category4Panel.Name = "g_Category4Panel";
            this.g_Category4Panel.Size = new System.Drawing.Size(300, 200);
            this.g_Category4Panel.TabIndex = 1;
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
            this.g_CancelButton.Location = new System.Drawing.Point(140, 248);
            this.g_CancelButton.Name = "g_CancelButton";
            this.g_CancelButton.Size = new System.Drawing.Size(120, 40);
            this.g_CancelButton.TabIndex = 2;
            this.g_CancelButton.Text = "Cancel";
            this.g_CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_CancelButton.UseVisualStyleBackColor = false;
            this.g_CancelButton.Click += new System.EventHandler(this.g_CancelButton_Click);
            // 
            // CCategory4Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 309);
            this.ControlBox = false;
            this.Controls.Add(this.g_CancelButton);
            this.Controls.Add(this.g_Category4Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CCategory4Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel g_Category4Panel;
        private RMSUI.FunctionalButton g_CancelButton;
    }
}