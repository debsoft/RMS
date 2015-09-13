namespace RMS
{
    partial class ProductQuantityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductQuantityForm));
            this.CancelButton = new RMSUI.FunctionalButton();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.numericKeyPad1 = new RMSUI.NumericKeyPad();
            this.EnterButton = new RMSUI.FunctionalButton();
            this.SuspendLayout();
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
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(84, 343);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(80, 40);
            this.CancelButton.TabIndex = 49;
            this.CancelButton.Text = "Close";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.BackColor = System.Drawing.Color.White;
            this.InputTextBox.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.ForeColor = System.Drawing.Color.Black;
            this.InputTextBox.Location = new System.Drawing.Point(84, 58);
            this.InputTextBox.MaxLength = 30;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(166, 33);
            this.InputTextBox.TabIndex = 48;
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(12, 10);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(294, 37);
            this.lblProductName.TabIndex = 47;
            this.lblProductName.Text = "InputNameLabel";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericKeyPad1
            // 
            this.numericKeyPad1.BackColor = System.Drawing.Color.White;
            this.numericKeyPad1.ControlToInputText = this.InputTextBox;
            this.numericKeyPad1.Location = new System.Drawing.Point(76, 97);
            this.numericKeyPad1.Name = "numericKeyPad1";
            this.numericKeyPad1.Size = new System.Drawing.Size(182, 240);
            this.numericKeyPad1.TabIndex = 50;
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.Transparent;
            this.EnterButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnterButton.BackgroundImage")));
            this.EnterButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("EnterButton.BgImageOnMouseDown")));
            this.EnterButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("EnterButton.BgImageOnMouseUp")));
            this.EnterButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.EnterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EnterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterButton.Font = new System.Drawing.Font("Arial", 10F);
            this.EnterButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.EnterButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.EnterButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.EnterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnterButton.Location = new System.Drawing.Point(170, 343);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(80, 40);
            this.EnterButton.TabIndex = 51;
            this.EnterButton.Text = "Enter";
            this.EnterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // ProductQuantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(331, 398);
            this.ControlBox = false;
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.numericKeyPad1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.lblProductName);
            this.Name = "ProductQuantityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Quantity Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox InputTextBox;
        public System.Windows.Forms.Label lblProductName;
        private RMSUI.NumericKeyPad numericKeyPad1;
        private RMSUI.FunctionalButton CancelButton;
        private RMSUI.FunctionalButton EnterButton;
    }
}