namespace RMS.Common
{
    partial class UserButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TouchButton = new System.Windows.Forms.Button();
            this.rmsUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TouchButton
            // 
            this.TouchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TouchButton.FlatAppearance.BorderSize = 0;
            this.TouchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TouchButton.Location = new System.Drawing.Point(-1, -2);
            this.TouchButton.Margin = new System.Windows.Forms.Padding(1);
            this.TouchButton.Name = "TouchButton";
            this.TouchButton.Size = new System.Drawing.Size(71, 68);
            this.TouchButton.TabIndex = 0;
            this.TouchButton.UseVisualStyleBackColor = true;
            this.TouchButton.Click += new System.EventHandler(this.TouchButton_Click);
            // 
            // rmsUserName
            // 
            this.rmsUserName.BackColor = System.Drawing.Color.Transparent;
            this.rmsUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmsUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rmsUserName.Location = new System.Drawing.Point(2, 66);
            this.rmsUserName.Name = "rmsUserName";
            this.rmsUserName.Size = new System.Drawing.Size(73, 18);
            this.rmsUserName.TabIndex = 5;
            this.rmsUserName.Text = "1";
            this.rmsUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rmsUserName.Click += new System.EventHandler(this.rmsUserName_Click);
            // 
            // UserButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.rmsUserName);
            this.Controls.Add(this.TouchButton);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "UserButton";
            this.Size = new System.Drawing.Size(78, 87);
            this.MouseLeave += new System.EventHandler(this.UserButton_MouseLeave);
            this.MouseEnter += new System.EventHandler(this.UserButton_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button TouchButton;
        public System.Windows.Forms.Label rmsUserName;


    }
}
