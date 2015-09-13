namespace RMSAdmin
{
    partial class ButtonColorCtl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonColorCtl));
            this.grpBtnColors = new System.Windows.Forms.GroupBox();
            this.lblSaveStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.cmbButtonColor = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.clrDlg = new System.Windows.Forms.ColorDialog();
            this.grpBtnColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBtnColors
            // 
            this.grpBtnColors.Controls.Add(this.lblSaveStatus);
            this.grpBtnColors.Controls.Add(this.label2);
            this.grpBtnColors.Controls.Add(this.label1);
            this.grpBtnColors.Controls.Add(this.txtColorName);
            this.grpBtnColors.Controls.Add(this.cmbButtonColor);
            this.grpBtnColors.Controls.Add(this.btnUpdate);
            this.grpBtnColors.Controls.Add(this.btnBrowse);
            this.grpBtnColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBtnColors.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpBtnColors.Location = new System.Drawing.Point(185, 119);
            this.grpBtnColors.Name = "grpBtnColors";
            this.grpBtnColors.Size = new System.Drawing.Size(523, 215);
            this.grpBtnColors.TabIndex = 0;
            this.grpBtnColors.TabStop = false;
            this.grpBtnColors.Text = "Button\'s Color Information";
            // 
            // lblSaveStatus
            // 
            this.lblSaveStatus.AutoSize = true;
            this.lblSaveStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveStatus.Location = new System.Drawing.Point(120, 130);
            this.lblSaveStatus.Name = "lblSaveStatus";
            this.lblSaveStatus.Size = new System.Drawing.Size(203, 13);
            this.lblSaveStatus.TabIndex = 6;
            this.lblSaveStatus.Text = "Button color has been saved successfully";
            this.lblSaveStatus.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Color Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Button Name";
            // 
            // txtColorName
            // 
            this.txtColorName.BackColor = System.Drawing.Color.Black;
            this.txtColorName.ForeColor = System.Drawing.Color.White;
            this.txtColorName.Location = new System.Drawing.Point(176, 65);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new System.Drawing.Size(192, 23);
            this.txtColorName.TabIndex = 1;
            // 
            // cmbButtonColor
            // 
            this.cmbButtonColor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbButtonColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbButtonColor.ForeColor = System.Drawing.Color.White;
            this.cmbButtonColor.FormattingEnabled = true;
            this.cmbButtonColor.Location = new System.Drawing.Point(176, 32);
            this.cmbButtonColor.Name = "cmbButtonColor";
            this.cmbButtonColor.Size = new System.Drawing.Size(192, 24);
            this.cmbButtonColor.TabIndex = 0;
            this.cmbButtonColor.DropDown += new System.EventHandler(this.cmbButtonColor_DropDown);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(188, 158);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse.BackgroundImage")));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.Black;
            this.btnBrowse.Location = new System.Drawing.Point(374, 57);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(120, 40);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ButtonColorCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.grpBtnColors);
            this.Name = "ButtonColorCtl";
            this.Size = new System.Drawing.Size(752, 470);
            this.grpBtnColors.ResumeLayout(false);
            this.grpBtnColors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBtnColors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.ComboBox cmbButtonColor;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSaveStatus;
        private System.Windows.Forms.ColorDialog clrDlg;

    }
}
