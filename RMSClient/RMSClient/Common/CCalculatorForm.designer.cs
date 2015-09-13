namespace RMS.Common
{
    partial class CCalculatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCalculatorForm));
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InputNameLabel = new System.Windows.Forms.Label();
            this.button1 = new RMSUI.FunctionalButton();
            this.numericKeyPad1 = new RMSUI.NumericKeyPad();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.BackColor = System.Drawing.Color.FloralWhite;
            this.InputTextBox.Enabled = false;
            this.InputTextBox.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.ForeColor = System.Drawing.Color.Black;
            this.InputTextBox.Location = new System.Drawing.Point(40, 55);
            this.InputTextBox.MaxLength = 30;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(183, 33);
            this.InputTextBox.TabIndex = 33;
            // 
            // InputNameLabel
            // 
            this.InputNameLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputNameLabel.ForeColor = System.Drawing.Color.Black;
            this.InputNameLabel.Location = new System.Drawing.Point(-2, 9);
            this.InputNameLabel.Name = "InputNameLabel";
            this.InputNameLabel.Size = new System.Drawing.Size(262, 37);
            this.InputNameLabel.TabIndex = 32;
            this.InputNameLabel.Text = "InputNameLabel";
            this.InputNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("button1.BgImageOnMouseDown")));
            this.button1.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("button1.BgImageOnMouseUp")));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10F);
            this.button1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.button1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.button1.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(138, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 40);
            this.button1.TabIndex = 37;
            this.button1.Text = "Enter";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericKeyPad1
            // 
            this.numericKeyPad1.BackColor = System.Drawing.Color.LightBlue;
            this.numericKeyPad1.ControlToInputText = this.InputTextBox;
            this.numericKeyPad1.Location = new System.Drawing.Point(40, 91);
            this.numericKeyPad1.Name = "numericKeyPad1";
            this.numericKeyPad1.Size = new System.Drawing.Size(185, 240);
            this.numericKeyPad1.TabIndex = 35;
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
            this.CancelButton.Location = new System.Drawing.Point(44, 347);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(78, 40);
            this.CancelButton.TabIndex = 34;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(265, 401);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericKeyPad1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InputNameLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CCalculatorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox InputTextBox;
        public System.Windows.Forms.Label InputNameLabel;
        private RMSUI.NumericKeyPad numericKeyPad1;
        private RMSUI.FunctionalButton button1;
        private RMSUI.FunctionalButton CancelButton;
    }
}