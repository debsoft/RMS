namespace RMS.Common
{
    partial class MessageForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.messageTypeLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.Message = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(199, 152);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // messageTypeLabel
            // 
            this.messageTypeLabel.AutoSize = true;
            this.messageTypeLabel.Location = new System.Drawing.Point(142, 21);
            this.messageTypeLabel.Name = "messageTypeLabel";
            this.messageTypeLabel.Size = new System.Drawing.Size(77, 13);
            this.messageTypeLabel.TabIndex = 1;
            this.messageTypeLabel.Text = "Message Type";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(88, 53);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(186, 74);
            this.messageTextBox.TabIndex = 2;
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(12, 76);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(50, 13);
            this.Message.TabIndex = 3;
            this.Message.Text = "Message";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(88, 152);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 196);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.messageTypeLabel);
            this.Controls.Add(this.saveButton);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label messageTypeLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Button closeButton;
    }
}