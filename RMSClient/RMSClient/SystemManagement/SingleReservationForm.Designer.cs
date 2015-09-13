namespace RMS.SystemManagement
{
    partial class SingleReservationForm
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
            this.printpreviewtextBox = new System.Windows.Forms.TextBox();
            this.printbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printpreviewtextBox
            // 
            this.printpreviewtextBox.Location = new System.Drawing.Point(55, 49);
            this.printpreviewtextBox.Multiline = true;
            this.printpreviewtextBox.Name = "printpreviewtextBox";
            this.printpreviewtextBox.ReadOnly = true;
            this.printpreviewtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.printpreviewtextBox.Size = new System.Drawing.Size(867, 475);
            this.printpreviewtextBox.TabIndex = 0;
            // 
            // printbutton
            // 
            this.printbutton.Location = new System.Drawing.Point(91, 12);
            this.printbutton.Name = "printbutton";
            this.printbutton.Size = new System.Drawing.Size(113, 31);
            this.printbutton.TabIndex = 1;
            this.printbutton.Text = "Print";
            this.printbutton.UseVisualStyleBackColor = true;
            this.printbutton.Click += new System.EventHandler(this.printbutton_Click);
            // 
            // SingleReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 549);
            this.Controls.Add(this.printbutton);
            this.Controls.Add(this.printpreviewtextBox);
            this.Name = "SingleReservationForm";
            this.Text = "SingleReservationForm";
            this.Load += new System.EventHandler(this.SingleReservationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox printpreviewtextBox;
        private System.Windows.Forms.Button printbutton;
    }
}