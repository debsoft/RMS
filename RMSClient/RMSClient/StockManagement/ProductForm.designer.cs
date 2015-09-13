namespace RMS.StockManagement
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.panelUCHolder = new System.Windows.Forms.Panel();
            this.btnBack = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // panelUCHolder
            // 
            this.panelUCHolder.BackColor = System.Drawing.Color.Transparent;
            this.panelUCHolder.Location = new System.Drawing.Point(6, 59);
            this.panelUCHolder.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.panelUCHolder.Name = "panelUCHolder";
            this.panelUCHolder.Size = new System.Drawing.Size(1012, 628);
            this.panelUCHolder.TabIndex = 3;
            this.panelUCHolder.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUCHolder_Paint);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BgImageOnMouseDown = null;
            this.btnBack.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnBack.BgImageOnMouseUp")));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnBack.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnBack.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(6, 692);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 43);
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "Back  To System Management";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 740);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panelUCHolder);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.Controls.SetChildIndex(this.panelUCHolder, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUCHolder;
        private RMSUI.FunctionalButton btnBack;

    }
}