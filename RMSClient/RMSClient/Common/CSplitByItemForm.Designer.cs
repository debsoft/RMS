namespace RMS.Common
{
    partial class CSplitByItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSplitByItemForm));
            this.g_PrintBill1ListBox = new System.Windows.Forms.ListBox();
            this.g_PrintBill2ListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.g_PrintGuestBillButton = new RMSUI.FunctionalButton();
            this.g_CanceButton = new RMSUI.FunctionalButton();
            this.g_LeftAddButton = new RMSUI.FunctionalButton();
            this.g_RightAddButton = new RMSUI.FunctionalButton();
            this.g_PrintBill3ListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // g_PrintBill1ListBox
            // 
            this.g_PrintBill1ListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.g_PrintBill1ListBox.FormattingEnabled = true;
            this.g_PrintBill1ListBox.Location = new System.Drawing.Point(34, 33);
            this.g_PrintBill1ListBox.Name = "g_PrintBill1ListBox";
            this.g_PrintBill1ListBox.Size = new System.Drawing.Size(180, 173);
            this.g_PrintBill1ListBox.TabIndex = 37;
            // 
            // g_PrintBill2ListBox
            // 
            this.g_PrintBill2ListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.g_PrintBill2ListBox.FormattingEnabled = true;
            this.g_PrintBill2ListBox.Location = new System.Drawing.Point(286, 33);
            this.g_PrintBill2ListBox.Name = "g_PrintBill2ListBox";
            this.g_PrintBill2ListBox.Size = new System.Drawing.Size(180, 173);
            this.g_PrintBill2ListBox.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(87, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Main Bill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(349, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Print Bill";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // g_PrintGuestBillButton
            // 
            this.g_PrintGuestBillButton.BackColor = System.Drawing.Color.Transparent;
            this.g_PrintGuestBillButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_PrintGuestBillButton.BackgroundImage")));
            this.g_PrintGuestBillButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_PrintGuestBillButton.BgImageOnMouseDown")));
            this.g_PrintGuestBillButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_PrintGuestBillButton.BgImageOnMouseUp")));
            this.g_PrintGuestBillButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_PrintGuestBillButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_PrintGuestBillButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_PrintGuestBillButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_PrintGuestBillButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_PrintGuestBillButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_PrintGuestBillButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_PrintGuestBillButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_PrintGuestBillButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_PrintGuestBillButton.Location = new System.Drawing.Point(325, 212);
            this.g_PrintGuestBillButton.Name = "g_PrintGuestBillButton";
            this.g_PrintGuestBillButton.Size = new System.Drawing.Size(120, 32);
            this.g_PrintGuestBillButton.TabIndex = 44;
            this.g_PrintGuestBillButton.Text = "Print Guest Bill";
            this.g_PrintGuestBillButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_PrintGuestBillButton.UseVisualStyleBackColor = false;
            this.g_PrintGuestBillButton.Click += new System.EventHandler(this.g_PrintGuestBillButton_Click);
            // 
            // g_CanceButton
            // 
            this.g_CanceButton.BackColor = System.Drawing.Color.Transparent;
            this.g_CanceButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_CanceButton.BackgroundImage")));
            this.g_CanceButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_CanceButton.BgImageOnMouseDown")));
            this.g_CanceButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_CanceButton.BgImageOnMouseUp")));
            this.g_CanceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_CanceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_CanceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_CanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_CanceButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_CanceButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_CanceButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_CanceButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_CanceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_CanceButton.Location = new System.Drawing.Point(200, 288);
            this.g_CanceButton.Name = "g_CanceButton";
            this.g_CanceButton.Size = new System.Drawing.Size(120, 40);
            this.g_CanceButton.TabIndex = 43;
            this.g_CanceButton.Text = "Close";
            this.g_CanceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_CanceButton.UseVisualStyleBackColor = false;
            this.g_CanceButton.Click += new System.EventHandler(this.g_CanceButton_Click);
            // 
            // g_LeftAddButton
            // 
            this.g_LeftAddButton.BackColor = System.Drawing.Color.Transparent;
            this.g_LeftAddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_LeftAddButton.BackgroundImage")));
            this.g_LeftAddButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_LeftAddButton.BgImageOnMouseDown")));
            this.g_LeftAddButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_LeftAddButton.BgImageOnMouseUp")));
            this.g_LeftAddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_LeftAddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_LeftAddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_LeftAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_LeftAddButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_LeftAddButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_LeftAddButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_LeftAddButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Previous;
            this.g_LeftAddButton.Image = ((System.Drawing.Image)(resources.GetObject("g_LeftAddButton.Image")));
            this.g_LeftAddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_LeftAddButton.Location = new System.Drawing.Point(227, 100);
            this.g_LeftAddButton.Name = "g_LeftAddButton";
            this.g_LeftAddButton.Size = new System.Drawing.Size(45, 40);
            this.g_LeftAddButton.TabIndex = 40;
            this.g_LeftAddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_LeftAddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.g_LeftAddButton.UseVisualStyleBackColor = false;
            this.g_LeftAddButton.Click += new System.EventHandler(this.g_LeftAddButton_Click);
            // 
            // g_RightAddButton
            // 
            this.g_RightAddButton.BackColor = System.Drawing.Color.Transparent;
            this.g_RightAddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_RightAddButton.BackgroundImage")));
            this.g_RightAddButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_RightAddButton.BgImageOnMouseDown")));
            this.g_RightAddButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_RightAddButton.BgImageOnMouseUp")));
            this.g_RightAddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_RightAddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_RightAddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_RightAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_RightAddButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_RightAddButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_RightAddButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_RightAddButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Next;
            this.g_RightAddButton.Image = ((System.Drawing.Image)(resources.GetObject("g_RightAddButton.Image")));
            this.g_RightAddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_RightAddButton.Location = new System.Drawing.Point(227, 54);
            this.g_RightAddButton.Name = "g_RightAddButton";
            this.g_RightAddButton.Size = new System.Drawing.Size(45, 40);
            this.g_RightAddButton.TabIndex = 39;
            this.g_RightAddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_RightAddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.g_RightAddButton.UseVisualStyleBackColor = false;
            this.g_RightAddButton.Click += new System.EventHandler(this.g_RightAddButton_Click);
            // 
            // g_PrintBill3ListBox
            // 
            this.g_PrintBill3ListBox.FormattingEnabled = true;
            this.g_PrintBill3ListBox.Location = new System.Drawing.Point(496, 33);
            this.g_PrintBill3ListBox.Name = "g_PrintBill3ListBox";
            this.g_PrintBill3ListBox.Size = new System.Drawing.Size(120, 95);
            this.g_PrintBill3ListBox.TabIndex = 46;
            // 
            // CSplitByItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(780, 382);
            this.ControlBox = false;
            this.Controls.Add(this.g_PrintBill3ListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.g_PrintGuestBillButton);
            this.Controls.Add(this.g_CanceButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.g_LeftAddButton);
            this.Controls.Add(this.g_RightAddButton);
            this.Controls.Add(this.g_PrintBill2ListBox);
            this.Controls.Add(this.g_PrintBill1ListBox);
            this.Name = "CSplitByItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Split By Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox g_PrintBill1ListBox;
        private System.Windows.Forms.ListBox g_PrintBill2ListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RMSUI.FunctionalButton g_RightAddButton;
        private RMSUI.FunctionalButton g_CanceButton;
        private RMSUI.FunctionalButton g_PrintGuestBillButton;
        private RMSUI.FunctionalButton g_LeftAddButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox g_PrintBill3ListBox;
    }
}