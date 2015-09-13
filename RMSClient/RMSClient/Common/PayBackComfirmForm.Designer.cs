namespace RMS.Common
{
    partial class PayBackComfirmForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayBackComfirmForm));
            this.btnPayBack = new RMSUI.FunctionalButton();
            this.btnAddServiceCharge = new RMSUI.FunctionalButton();
            this.btnCancel = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // btnPayBack
            // 
            this.btnPayBack.BackColor = System.Drawing.Color.Transparent;
            this.btnPayBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPayBack.BackgroundImage")));
            this.btnPayBack.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPayBack.BgImageOnMouseDown")));
            this.btnPayBack.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPayBack.BgImageOnMouseUp")));
            this.btnPayBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPayBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPayBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPayBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPayBack.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPayBack.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPayBack.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnPayBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayBack.Location = new System.Drawing.Point(55, 46);
            this.btnPayBack.Name = "btnPayBack";
            this.btnPayBack.Size = new System.Drawing.Size(167, 45);
            this.btnPayBack.TabIndex = 10;
            this.btnPayBack.Text = "Payment Back";
            this.btnPayBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPayBack.UseVisualStyleBackColor = false;
            this.btnPayBack.Click += new System.EventHandler(this.btnPayBack_Click);
            // 
            // btnAddServiceCharge
            // 
            this.btnAddServiceCharge.BackColor = System.Drawing.Color.Transparent;
            this.btnAddServiceCharge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddServiceCharge.BackgroundImage")));
            this.btnAddServiceCharge.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnAddServiceCharge.BgImageOnMouseDown")));
            this.btnAddServiceCharge.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnAddServiceCharge.BgImageOnMouseUp")));
            this.btnAddServiceCharge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddServiceCharge.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddServiceCharge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddServiceCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddServiceCharge.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAddServiceCharge.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnAddServiceCharge.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnAddServiceCharge.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnAddServiceCharge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddServiceCharge.Location = new System.Drawing.Point(55, 148);
            this.btnAddServiceCharge.Name = "btnAddServiceCharge";
            this.btnAddServiceCharge.Size = new System.Drawing.Size(167, 45);
            this.btnAddServiceCharge.TabIndex = 9;
            this.btnAddServiceCharge.Text = "Add To Service Charge";
            this.btnAddServiceCharge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddServiceCharge.UseVisualStyleBackColor = false;
            this.btnAddServiceCharge.Visible = false;
            this.btnAddServiceCharge.Click += new System.EventHandler(this.btnAddServiceCharge_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnCancel.BgImageOnMouseDown")));
            this.btnCancel.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnCancel.BgImageOnMouseUp")));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCancel.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnCancel.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnCancel.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(55, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(167, 45);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PayBackComfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(276, 202);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPayBack);
            this.Controls.Add(this.btnAddServiceCharge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PayBackComfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Back Comfirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private RMSUI.FunctionalButton btnAddServiceCharge;
        private RMSUI.FunctionalButton btnPayBack;
        private RMSUI.FunctionalButton btnCancel;
    }
}