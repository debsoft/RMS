namespace RMS
{
    partial class AuthenticationForm
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
            this.g_ErrorLabel = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.numericKeyPad1 = new RMSUI.NumericKeyPad();
            this.SuspendLayout();
            // 
            // g_ErrorLabel
            // 
            this.g_ErrorLabel.AutoSize = true;
            this.g_ErrorLabel.BackColor = System.Drawing.Color.White;
            this.g_ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.g_ErrorLabel.Location = new System.Drawing.Point(48, 44);
            this.g_ErrorLabel.Name = "g_ErrorLabel";
            this.g_ErrorLabel.Size = new System.Drawing.Size(190, 16);
            this.g_ErrorLabel.TabIndex = 20;
            this.g_ErrorLabel.Text = "Invalid user name or password";
            this.g_ErrorLabel.Visible = false;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.LoginTextBox.ForeColor = System.Drawing.Color.Black;
            this.LoginTextBox.Location = new System.Drawing.Point(40, 66);
            this.LoginTextBox.MaxLength = 30;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(211, 38);
            this.LoginTextBox.TabIndex = 23;
            this.LoginTextBox.UseSystemPasswordChar = true;
            // 
            // numericKeyPad1
            // 
            this.numericKeyPad1.BackColor = System.Drawing.Color.White;
            this.numericKeyPad1.ControlToInputText = this.LoginTextBox;
            this.numericKeyPad1.Location = new System.Drawing.Point(56, 107);
            this.numericKeyPad1.Name = "numericKeyPad1";
            this.numericKeyPad1.Size = new System.Drawing.Size(180, 235);
            this.numericKeyPad1.TabIndex = 24;
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 410);
            this.Controls.Add(this.g_ErrorLabel);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.numericKeyPad1);
            this.Name = "AuthenticationForm";
            this.Text = "RMS user authentication";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuthenticationForm_FormClosed);
            this.Load += new System.EventHandler(this.AuthenticationForm_Load);
            this.Controls.SetChildIndex(this.numericKeyPad1, 0);
            this.Controls.SetChildIndex(this.LoginTextBox, 0);
            this.Controls.SetChildIndex(this.g_ErrorLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label g_ErrorLabel;
        private System.Windows.Forms.TextBox LoginTextBox;
        private RMSUI.NumericKeyPad numericKeyPad1;
    }
}