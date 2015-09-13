namespace RMS.Common
{
    partial class CWinKeyboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CWinKeyboardForm));
            this.CancelButton = new RMSUI.FunctionalButton();
            this.SaveButton = new RMSUI.FunctionalButton();
            this.ContentTextBox = new System.Windows.Forms.TextBox();
            this.PromptLabel = new System.Windows.Forms.Label();
            this.keyboard1 = new RMSUI.keyboard();
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
            this.CancelButton.Location = new System.Drawing.Point(279, 433);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 41;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
            this.SaveButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("SaveButton.BgImageOnMouseDown")));
            this.SaveButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("SaveButton.BgImageOnMouseUp")));
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Arial", 10F);
            this.SaveButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.SaveButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.SaveButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(415, 433);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 40);
            this.SaveButton.TabIndex = 42;
            this.SaveButton.Text = "Save";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.BackColor = System.Drawing.Color.White;
            this.ContentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentTextBox.ForeColor = System.Drawing.Color.Black;
            this.ContentTextBox.Location = new System.Drawing.Point(241, 81);
            this.ContentTextBox.Multiline = true;
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(312, 60);
            this.ContentTextBox.TabIndex = 44;
            this.ContentTextBox.Tag = "";
            this.ContentTextBox.Click += new System.EventHandler(this.ContentTextBox_Click);
            // 
            // PromptLabel
            // 
            this.PromptLabel.BackColor = System.Drawing.Color.Transparent;
            this.PromptLabel.ForeColor = System.Drawing.Color.Black;
            this.PromptLabel.Location = new System.Drawing.Point(116, 41);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PromptLabel.Size = new System.Drawing.Size(547, 28);
            this.PromptLabel.TabIndex = 45;
            this.PromptLabel.Text = "PromptLabel";
            this.PromptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboard1.ControlToInputText = this.ContentTextBox;
            this.keyboard1.Location = new System.Drawing.Point(57, 163);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(671, 247);
            this.keyboard1.TabIndex = 46;
            this.keyboard1.textBox = null;
            // 
            // CWinKeyboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.ContentTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CWinKeyboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ContentTextBox;
        private System.Windows.Forms.Label PromptLabel;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton CancelButton;
        private RMSUI.FunctionalButton SaveButton;

    }
}