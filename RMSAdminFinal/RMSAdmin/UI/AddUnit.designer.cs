namespace BistroAdmin.UI
{
    partial class AddUnit
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
            this.unitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.unitCreatelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unitButton
            // 
            this.unitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitButton.Location = new System.Drawing.Point(133, 132);
            this.unitButton.Name = "unitButton";
            this.unitButton.Size = new System.Drawing.Size(75, 23);
            this.unitButton.TabIndex = 1;
            this.unitButton.Text = "Save";
            this.unitButton.UseVisualStyleBackColor = true;
            this.unitButton.Click += new System.EventHandler(this.unitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Create Unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Unit";
            // 
            // unitTextBox
            // 
            this.unitTextBox.Location = new System.Drawing.Point(119, 73);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(100, 20);
            this.unitTextBox.TabIndex = 0;
            // 
            // unitCreatelabel
            // 
            this.unitCreatelabel.AutoSize = true;
            this.unitCreatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCreatelabel.Location = new System.Drawing.Point(130, 176);
            this.unitCreatelabel.Name = "unitCreatelabel";
            this.unitCreatelabel.Size = new System.Drawing.Size(90, 16);
            this.unitCreatelabel.TabIndex = 11;
            this.unitCreatelabel.Text = "action..........";
            // 
            // AddUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.unitCreatelabel);
            this.Controls.Add(this.unitTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unitButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "AddUnit";
            this.Size = new System.Drawing.Size(370, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button unitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.Label unitCreatelabel;
    }
}