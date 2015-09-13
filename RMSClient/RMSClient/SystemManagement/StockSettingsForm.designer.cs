using RMSUI;
namespace RMS.SystemManagement
{
    partial class StockSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockSettingsForm));
            this.rdbAllowedToOrder = new System.Windows.Forms.RadioButton();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.txtbxCurrency = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new RMSUI.FunctionalButton();
            this.functionalButton1 = new RMSUI.FunctionalButton();
            this.roundDailogeBox1 = new RMSUI.RoundDailogeBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdbAllowedToOrder
            // 
            this.rdbAllowedToOrder.AutoSize = true;
            this.rdbAllowedToOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(63)))), ((int)(((byte)(64)))));
            this.rdbAllowedToOrder.Checked = true;
            this.rdbAllowedToOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAllowedToOrder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rdbAllowedToOrder.Location = new System.Drawing.Point(104, 104);
            this.rdbAllowedToOrder.Name = "rdbAllowedToOrder";
            this.rdbAllowedToOrder.Size = new System.Drawing.Size(131, 21);
            this.rdbAllowedToOrder.TabIndex = 4;
            this.rdbAllowedToOrder.TabStop = true;
            this.rdbAllowedToOrder.Text = "Allowed to Order";
            this.rdbAllowedToOrder.UseVisualStyleBackColor = false;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(63)))), ((int)(((byte)(64)))));
            this.rdbNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rdbNo.Location = new System.Drawing.Point(286, 104);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(44, 21);
            this.rdbNo.TabIndex = 5;
            this.rdbNo.Text = "No";
            this.rdbNo.UseVisualStyleBackColor = false;
            // 
            // txtbxCurrency
            // 
            this.txtbxCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxCurrency.Location = new System.Drawing.Point(12, 212);
            this.txtbxCurrency.Name = "txtbxCurrency";
            this.txtbxCurrency.Size = new System.Drawing.Size(42, 38);
            this.txtbxCurrency.TabIndex = 6;
            this.txtbxCurrency.Visible = false;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(63)))), ((int)(((byte)(64)))));
            this.btnSaveChanges.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveChanges.BackgroundImage")));
            this.btnSaveChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveChanges.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSaveChanges.BgImageOnMouseDown")));
            this.btnSaveChanges.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSaveChanges.BgImageOnMouseUp")));
            this.btnSaveChanges.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSaveChanges.FlatAppearance.BorderSize = 0;
            this.btnSaveChanges.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSaveChanges.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSaveChanges.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSaveChanges.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSaveChanges.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSaveChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanges.Location = new System.Drawing.Point(77, 193);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(136, 47);
            this.btnSaveChanges.TabIndex = 10;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // functionalButton1
            // 
            this.functionalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(63)))), ((int)(((byte)(64)))));
            this.functionalButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BackgroundImage")));
            this.functionalButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.functionalButton1.BgImageOnMouseDown = null;
            this.functionalButton1.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BgImageOnMouseUp")));
            this.functionalButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.functionalButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.functionalButton1.FlatAppearance.BorderSize = 0;
            this.functionalButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functionalButton1.Font = new System.Drawing.Font("Arial", 10F);
            this.functionalButton1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton1.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.functionalButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton1.Location = new System.Drawing.Point(220, 193);
            this.functionalButton1.Name = "functionalButton1";
            this.functionalButton1.Size = new System.Drawing.Size(134, 47);
            this.functionalButton1.TabIndex = 11;
            this.functionalButton1.Text = "Cancel";
            this.functionalButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton1.UseVisualStyleBackColor = false;
            // 
            // roundDailogeBox1
            // 
            this.roundDailogeBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundDailogeBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundDailogeBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.roundDailogeBox1.Location = new System.Drawing.Point(0, 0);
            this.roundDailogeBox1.Name = "roundDailogeBox1";
            this.roundDailogeBox1.Size = new System.Drawing.Size(448, 275);
            this.roundDailogeBox1.TabIndex = 16;
            this.roundDailogeBox1.Load += new System.EventHandler(this.roundDailogeBox1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(63)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(145, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Out of Stock Setting";
            // 
            // StockSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(448, 275);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.functionalButton1);
            this.Controls.Add(this.txtbxCurrency);
            this.Controls.Add(this.rdbNo);
            this.Controls.Add(this.rdbAllowedToOrder);
            this.Controls.Add(this.roundDailogeBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Settings";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbAllowedToOrder;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.TextBox txtbxCurrency;
        private FunctionalButton btnSaveChanges;
        private FunctionalButton functionalButton1;
        private RoundDailogeBox roundDailogeBox1;
        private System.Windows.Forms.Label label1;
    }
}