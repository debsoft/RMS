﻿namespace RMS
{
    partial class CustomerControl
    {
        /// <summary> 
        /// Required designer variable. which are necessary to design
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblKitchenTextSent = new System.Windows.Forms.Label();
            this.txtKitchenTextSent = new System.Windows.Forms.TextBox();
            this.btnEditCustomer = new RMSUI.FunctionalButton();
            this.txtKitchenText = new System.Windows.Forms.TextBox();
            this.lblKitchen = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblGuestBillPrintStatus = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblLastKitchen = new System.Windows.Forms.Label();
            this.lblTown = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFirstKitchen = new System.Windows.Forms.Label();
            this.lblFirstOrderTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLastOrdertime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblKitchenTextSent);
            this.panel1.Controls.Add(this.txtKitchenTextSent);
            this.panel1.Controls.Add(this.btnEditCustomer);
            this.panel1.Controls.Add(this.txtKitchenText);
            this.panel1.Controls.Add(this.lblKitchen);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 313);
            this.panel1.TabIndex = 60;
            // 
            // lblKitchenTextSent
            // 
            this.lblKitchenTextSent.AutoSize = true;
            this.lblKitchenTextSent.ForeColor = System.Drawing.Color.Black;
            this.lblKitchenTextSent.Location = new System.Drawing.Point(2, 207);
            this.lblKitchenTextSent.Name = "lblKitchenTextSent";
            this.lblKitchenTextSent.Size = new System.Drawing.Size(92, 13);
            this.lblKitchenTextSent.TabIndex = 64;
            this.lblKitchenTextSent.Text = "Kitchen Text Sent";
            this.lblKitchenTextSent.Visible = false;
            // 
            // txtKitchenTextSent
            // 
            this.txtKitchenTextSent.BackColor = System.Drawing.Color.White;
            this.txtKitchenTextSent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKitchenTextSent.Enabled = false;
            this.txtKitchenTextSent.ForeColor = System.Drawing.Color.Black;
            this.txtKitchenTextSent.Location = new System.Drawing.Point(3, 223);
            this.txtKitchenTextSent.Multiline = true;
            this.txtKitchenTextSent.Name = "txtKitchenTextSent";
            this.txtKitchenTextSent.ReadOnly = true;
            this.txtKitchenTextSent.Size = new System.Drawing.Size(177, 36);
            this.txtKitchenTextSent.TabIndex = 63;
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnEditCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditCustomer.BackgroundImage")));
            this.btnEditCustomer.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnEditCustomer.BgImageOnMouseDown")));
            this.btnEditCustomer.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnEditCustomer.BgImageOnMouseUp")));
            this.btnEditCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnEditCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCustomer.Font = new System.Drawing.Font("Arial", 10F);
            this.btnEditCustomer.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnEditCustomer.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnEditCustomer.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnEditCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCustomer.Location = new System.Drawing.Point(3, 265);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(181, 40);
            this.btnEditCustomer.TabIndex = 62;
            this.btnEditCustomer.Text = "Edit Takeaway";
            this.btnEditCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditCustomer.UseVisualStyleBackColor = false;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // txtKitchenText
            // 
            this.txtKitchenText.BackColor = System.Drawing.Color.White;
            this.txtKitchenText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKitchenText.Enabled = false;
            this.txtKitchenText.ForeColor = System.Drawing.Color.Black;
            this.txtKitchenText.Location = new System.Drawing.Point(7, 166);
            this.txtKitchenText.Multiline = true;
            this.txtKitchenText.Name = "txtKitchenText";
            this.txtKitchenText.ReadOnly = true;
            this.txtKitchenText.Size = new System.Drawing.Size(180, 38);
            this.txtKitchenText.TabIndex = 61;
            // 
            // lblKitchen
            // 
            this.lblKitchen.AutoSize = true;
            this.lblKitchen.ForeColor = System.Drawing.Color.Black;
            this.lblKitchen.Location = new System.Drawing.Point(4, 151);
            this.lblKitchen.Name = "lblKitchen";
            this.lblKitchen.Size = new System.Drawing.Size(112, 13);
            this.lblKitchen.TabIndex = 60;
            this.lblKitchen.Text = "Kitchen Text Not Sent";
            this.lblKitchen.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblGuestBillPrintStatus, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPhone, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLastKitchen, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstKitchen, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstOrderTime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLastOrdertime, 1, 4);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(185, 142);
            this.tableLayoutPanel1.TabIndex = 59;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(4, 1);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblGuestBillPrintStatus
            // 
            this.lblGuestBillPrintStatus.AutoSize = true;
            this.lblGuestBillPrintStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGuestBillPrintStatus.Location = new System.Drawing.Point(93, 124);
            this.lblGuestBillPrintStatus.Name = "lblGuestBillPrintStatus";
            this.lblGuestBillPrintStatus.Size = new System.Drawing.Size(27, 13);
            this.lblGuestBillPrintStatus.TabIndex = 38;
            this.lblGuestBillPrintStatus.Text = "N/A";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(93, 1);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(31, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Bill Printed:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(4, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Phone";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPhone.Location = new System.Drawing.Point(93, 19);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(27, 13);
            this.lblPhone.TabIndex = 22;
            this.lblPhone.Text = "N/A";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(4, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 17;
            this.label20.Text = "Town";
            // 
            // lblLastKitchen
            // 
            this.lblLastKitchen.AutoSize = true;
            this.lblLastKitchen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLastKitchen.Location = new System.Drawing.Point(93, 105);
            this.lblLastKitchen.Name = "lblLastKitchen";
            this.lblLastKitchen.Size = new System.Drawing.Size(27, 13);
            this.lblLastKitchen.TabIndex = 34;
            this.lblLastKitchen.Text = "N/A";
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTown.Location = new System.Drawing.Point(93, 37);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(27, 13);
            this.lblTown.TabIndex = 18;
            this.lblTown.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Last to KTN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "First Taken";
            // 
            // lblFirstKitchen
            // 
            this.lblFirstKitchen.AutoSize = true;
            this.lblFirstKitchen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFirstKitchen.Location = new System.Drawing.Point(93, 89);
            this.lblFirstKitchen.Name = "lblFirstKitchen";
            this.lblFirstKitchen.Size = new System.Drawing.Size(27, 13);
            this.lblFirstKitchen.TabIndex = 30;
            this.lblFirstKitchen.Text = "N/A";
            // 
            // lblFirstOrderTime
            // 
            this.lblFirstOrderTime.AutoSize = true;
            this.lblFirstOrderTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstOrderTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFirstOrderTime.Location = new System.Drawing.Point(93, 54);
            this.lblFirstOrderTime.Name = "lblFirstOrderTime";
            this.lblFirstOrderTime.Size = new System.Drawing.Size(31, 16);
            this.lblFirstOrderTime.TabIndex = 28;
            this.lblFirstOrderTime.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = " 1st to KTN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(4, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Last Taken";
            // 
            // lblLastOrdertime
            // 
            this.lblLastOrdertime.AutoSize = true;
            this.lblLastOrdertime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLastOrdertime.Location = new System.Drawing.Point(93, 72);
            this.lblLastOrdertime.Name = "lblLastOrdertime";
            this.lblLastOrdertime.Size = new System.Drawing.Size(27, 13);
            this.lblLastOrdertime.TabIndex = 32;
            this.lblLastOrdertime.Text = "N/A";
            // 
            // CustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "CustomerControl";
            this.Size = new System.Drawing.Size(217, 320);
            this.Load += new System.EventHandler(this.CustomerControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtKitchenText;
        private System.Windows.Forms.Label lblKitchen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblGuestBillPrintStatus;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblLastKitchen;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFirstKitchen;
        private System.Windows.Forms.Label lblFirstOrderTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLastOrdertime;
        private System.Windows.Forms.Label lblKitchenTextSent;
        private System.Windows.Forms.TextBox txtKitchenTextSent;
        private RMSUI.FunctionalButton btnEditCustomer;

    }
}
