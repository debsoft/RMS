namespace RMS.TableOrder
{
    partial class KeyBooardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyBooardForm));
            this.keyboard1 = new RMSUI.keyboard();
            this.btnHide = new RMSUI.FunctionalButton();
            this.SuspendLayout();
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.Color.White;
            this.keyboard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.ForeColor = System.Drawing.Color.Black;
            this.keyboard1.Location = new System.Drawing.Point(4, 3);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(728, 247);
            this.keyboard1.TabIndex = 308;
            this.keyboard1.textBox = null;
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.Transparent;
            this.btnHide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHide.BackgroundImage")));
            this.btnHide.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnHide.BgImageOnMouseDown")));
            this.btnHide.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnHide.BgImageOnMouseUp")));
            this.btnHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Arial", 10F);
            this.btnHide.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnHide.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnHide.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnHide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHide.Location = new System.Drawing.Point(590, 257);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(140, 35);
            this.btnHide.TabIndex = 309;
            this.btnHide.Text = "Hide Keyboard";
            this.btnHide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // KeyBooardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(734, 305);
            this.ControlBox = false;
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.keyboard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(50, 380);
            this.Name = "KeyBooardForm";
            this.ShowIcon = false;
            this.Text = "KeyBooardForm";
            this.Load += new System.EventHandler(this.KeyBooardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton btnHide;
    }
}