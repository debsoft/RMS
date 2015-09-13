namespace RMS
{
    partial class ShowStatisticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowStatisticsForm));
            this.GraphPictureBox = new System.Windows.Forms.PictureBox();
            this.btnOK = new RMSUI.FunctionalButton();
            ((System.ComponentModel.ISupportInitialize)(this.GraphPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphPictureBox
            // 
            this.GraphPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.GraphPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GraphPictureBox.Location = new System.Drawing.Point(4, 3);
            this.GraphPictureBox.Name = "GraphPictureBox";
            this.GraphPictureBox.Size = new System.Drawing.Size(594, 416);
            this.GraphPictureBox.TabIndex = 17;
            this.GraphPictureBox.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnOK.BgImageOnMouseDown")));
            this.btnOK.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnOK.BgImageOnMouseUp")));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial", 10F);
            this.btnOK.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnOK.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnOK.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(224, 425);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(111, 40);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "Close";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ShowStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 472);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.GraphPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ShowStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.GraphPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphPictureBox;
        private RMSUI.FunctionalButton btnOK;
    }
}