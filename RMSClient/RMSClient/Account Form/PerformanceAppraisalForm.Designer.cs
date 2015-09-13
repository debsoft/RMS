namespace PayRoll.Forms
{
    partial class PerformanceAppraisalForm
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
            this.cboEmployeeID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.dTPTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dTPFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl1F = new System.Windows.Forms.Label();
            this.lbl2F = new System.Windows.Forms.Label();
            this.lbl3F = new System.Windows.Forms.Label();
            this.lbl4F = new System.Windows.Forms.Label();
            this.lbl5F = new System.Windows.Forms.Label();
            this.txt1F = new System.Windows.Forms.TextBox();
            this.txt1C = new System.Windows.Forms.TextBox();
            this.txt2F = new System.Windows.Forms.TextBox();
            this.txt2C = new System.Windows.Forms.TextBox();
            this.txt3F = new System.Windows.Forms.TextBox();
            this.txt3C = new System.Windows.Forms.TextBox();
            this.txt4F = new System.Windows.Forms.TextBox();
            this.txt4C = new System.Windows.Forms.TextBox();
            this.txt5F = new System.Windows.Forms.TextBox();
            this.txt5C = new System.Windows.Forms.TextBox();
            this.txtOverallRatings = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtOverallComments = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAverageRatings = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboEmployeeID
            // 
            this.cboEmployeeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEmployeeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmployeeID.BackColor = System.Drawing.Color.White;
            this.cboEmployeeID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployeeID.FormattingEnabled = true;
            this.cboEmployeeID.Location = new System.Drawing.Point(213, 8);
            this.cboEmployeeID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmployeeID.Name = "cboEmployeeID";
            this.cboEmployeeID.Size = new System.Drawing.Size(262, 24);
            this.cboEmployeeID.TabIndex = 86;
            this.cboEmployeeID.SelectedIndexChanged += new System.EventHandler(this.cboEmployeeID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MistyRose;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 23);
            this.label1.TabIndex = 87;
            this.label1.Text = "Employee ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MistyRose;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 23);
            this.label2.TabIndex = 91;
            this.label2.Text = "Job Title";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MistyRose;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(598, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 23);
            this.label4.TabIndex = 90;
            this.label4.Text = "Employee Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobTitle.Enabled = false;
            this.txtJobTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobTitle.Location = new System.Drawing.Point(746, 35);
            this.txtJobTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(235, 23);
            this.txtJobTitle.TabIndex = 89;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(746, 9);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(235, 23);
            this.txtEmployeeName.TabIndex = 88;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.MistyRose;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(598, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 23);
            this.label5.TabIndex = 93;
            this.label5.Text = "Department";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDepartment
            // 
            this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(746, 61);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(235, 23);
            this.txtDepartment.TabIndex = 92;
            // 
            // dTPTo
            // 
            this.dTPTo.CustomFormat = "dd/MM/yyyy";
            this.dTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPTo.Location = new System.Drawing.Point(368, 64);
            this.dTPTo.Name = "dTPTo";
            this.dTPTo.Size = new System.Drawing.Size(107, 23);
            this.dTPTo.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.MistyRose;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(326, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 23);
            this.label7.TabIndex = 96;
            this.label7.Text = "to";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dTPFrom
            // 
            this.dTPFrom.CustomFormat = "dd/MM/yyyy";
            this.dTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPFrom.Location = new System.Drawing.Point(213, 64);
            this.dTPFrom.Name = "dTPFrom";
            this.dTPFrom.Size = new System.Drawing.Size(107, 23);
            this.dTPFrom.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.MistyRose;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 23);
            this.label6.TabIndex = 94;
            this.label6.Text = "Review Period";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(41, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(940, 27);
            this.label8.TabIndex = 98;
            this.label8.Text = "Rating";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(940, 27);
            this.label9.TabIndex = 99;
            this.label9.Text = "5=Poor,  4= Fair,  3=Satisfactory,  2=Good,  1=Excellent";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(41, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 24);
            this.label10.TabIndex = 100;
            this.label10.Text = "Factors";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(239, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 24);
            this.label11.TabIndex = 101;
            this.label11.Text = "Rating";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(382, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(599, 24);
            this.label12.TabIndex = 102;
            this.label12.Text = "Comments";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl1F
            // 
            this.lbl1F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1F.Location = new System.Drawing.Point(41, 221);
            this.lbl1F.Name = "lbl1F";
            this.lbl1F.Size = new System.Drawing.Size(194, 24);
            this.lbl1F.TabIndex = 103;
            this.lbl1F.Text = "Job Knowledge";
            this.lbl1F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2F
            // 
            this.lbl2F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2F.Location = new System.Drawing.Point(41, 248);
            this.lbl2F.Name = "lbl2F";
            this.lbl2F.Size = new System.Drawing.Size(194, 24);
            this.lbl2F.TabIndex = 104;
            this.lbl2F.Text = "Work Quality";
            this.lbl2F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl3F
            // 
            this.lbl3F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3F.Location = new System.Drawing.Point(41, 275);
            this.lbl3F.Name = "lbl3F";
            this.lbl3F.Size = new System.Drawing.Size(194, 24);
            this.lbl3F.TabIndex = 105;
            this.lbl3F.Text = "Attendance/Punctuality";
            this.lbl3F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl4F
            // 
            this.lbl4F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4F.Location = new System.Drawing.Point(41, 302);
            this.lbl4F.Name = "lbl4F";
            this.lbl4F.Size = new System.Drawing.Size(194, 24);
            this.lbl4F.TabIndex = 106;
            this.lbl4F.Text = "Communication/Listening Skills";
            this.lbl4F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl5F
            // 
            this.lbl5F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl5F.Location = new System.Drawing.Point(41, 329);
            this.lbl5F.Name = "lbl5F";
            this.lbl5F.Size = new System.Drawing.Size(194, 24);
            this.lbl5F.TabIndex = 107;
            this.lbl5F.Text = "Dependability";
            this.lbl5F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt1F
            // 
            this.txt1F.Location = new System.Drawing.Point(239, 221);
            this.txt1F.Name = "txt1F";
            this.txt1F.Size = new System.Drawing.Size(137, 23);
            this.txt1F.TabIndex = 108;
            this.txt1F.Text = "0";
            this.txt1F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt1C
            // 
            this.txt1C.Location = new System.Drawing.Point(382, 221);
            this.txt1C.Name = "txt1C";
            this.txt1C.Size = new System.Drawing.Size(599, 23);
            this.txt1C.TabIndex = 109;
            // 
            // txt2F
            // 
            this.txt2F.Location = new System.Drawing.Point(239, 248);
            this.txt2F.Name = "txt2F";
            this.txt2F.Size = new System.Drawing.Size(137, 23);
            this.txt2F.TabIndex = 110;
            this.txt2F.Text = "0";
            this.txt2F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt2C
            // 
            this.txt2C.Location = new System.Drawing.Point(382, 248);
            this.txt2C.Name = "txt2C";
            this.txt2C.Size = new System.Drawing.Size(599, 23);
            this.txt2C.TabIndex = 111;
            // 
            // txt3F
            // 
            this.txt3F.Location = new System.Drawing.Point(239, 276);
            this.txt3F.Name = "txt3F";
            this.txt3F.Size = new System.Drawing.Size(137, 23);
            this.txt3F.TabIndex = 112;
            this.txt3F.Text = "0";
            this.txt3F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt3C
            // 
            this.txt3C.Location = new System.Drawing.Point(382, 277);
            this.txt3C.Name = "txt3C";
            this.txt3C.Size = new System.Drawing.Size(599, 23);
            this.txt3C.TabIndex = 113;
            // 
            // txt4F
            // 
            this.txt4F.Location = new System.Drawing.Point(239, 302);
            this.txt4F.Name = "txt4F";
            this.txt4F.Size = new System.Drawing.Size(137, 23);
            this.txt4F.TabIndex = 114;
            this.txt4F.Text = "0";
            this.txt4F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt4C
            // 
            this.txt4C.Location = new System.Drawing.Point(382, 303);
            this.txt4C.Name = "txt4C";
            this.txt4C.Size = new System.Drawing.Size(599, 23);
            this.txt4C.TabIndex = 115;
            // 
            // txt5F
            // 
            this.txt5F.Location = new System.Drawing.Point(239, 329);
            this.txt5F.Name = "txt5F";
            this.txt5F.Size = new System.Drawing.Size(137, 23);
            this.txt5F.TabIndex = 116;
            this.txt5F.Text = "0";
            this.txt5F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt5F.Leave += new System.EventHandler(this.txt5F_Leave);
            // 
            // txt5C
            // 
            this.txt5C.Location = new System.Drawing.Point(382, 329);
            this.txt5C.Name = "txt5C";
            this.txt5C.Size = new System.Drawing.Size(599, 23);
            this.txt5C.TabIndex = 117;
            // 
            // txtOverallRatings
            // 
            this.txtOverallRatings.Enabled = false;
            this.txtOverallRatings.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOverallRatings.Location = new System.Drawing.Point(239, 366);
            this.txtOverallRatings.Name = "txtOverallRatings";
            this.txtOverallRatings.Size = new System.Drawing.Size(137, 23);
            this.txtOverallRatings.TabIndex = 119;
            this.txtOverallRatings.Text = "0";
            this.txtOverallRatings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Red;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(41, 366);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(194, 24);
            this.label18.TabIndex = 118;
            this.label18.Text = "Overall Ratings";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Red;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(41, 392);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(335, 24);
            this.label19.TabIndex = 120;
            this.label19.Text = "Additional Comments";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOverallComments
            // 
            this.txtOverallComments.Location = new System.Drawing.Point(382, 392);
            this.txtOverallComments.Name = "txtOverallComments";
            this.txtOverallComments.Size = new System.Drawing.Size(599, 23);
            this.txtOverallComments.TabIndex = 121;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 33);
            this.button1.TabIndex = 122;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAverageRatings
            // 
            this.txtAverageRatings.Enabled = false;
            this.txtAverageRatings.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAverageRatings.Location = new System.Drawing.Point(548, 366);
            this.txtAverageRatings.Name = "txtAverageRatings";
            this.txtAverageRatings.Size = new System.Drawing.Size(137, 23);
            this.txtAverageRatings.TabIndex = 123;
            this.txtAverageRatings.Text = "0";
            this.txtAverageRatings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(382, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 24);
            this.label3.TabIndex = 124;
            this.label3.Text = "Average Ratings";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PerformanceAppraisalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAverageRatings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOverallComments);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtOverallRatings);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txt5C);
            this.Controls.Add(this.txt5F);
            this.Controls.Add(this.txt4C);
            this.Controls.Add(this.txt4F);
            this.Controls.Add(this.txt3C);
            this.Controls.Add(this.txt3F);
            this.Controls.Add(this.txt2C);
            this.Controls.Add(this.txt2F);
            this.Controls.Add(this.txt1C);
            this.Controls.Add(this.txt1F);
            this.Controls.Add(this.lbl5F);
            this.Controls.Add(this.lbl4F);
            this.Controls.Add(this.lbl3F);
            this.Controls.Add(this.lbl2F);
            this.Controls.Add(this.lbl1F);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dTPTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dTPFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.cboEmployeeID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PerformanceAppraisalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performance Appraisal Form";
            this.Load += new System.EventHandler(this.PerformanceAppraisalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEmployeeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.DateTimePicker dTPTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dTPFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl1F;
        private System.Windows.Forms.Label lbl2F;
        private System.Windows.Forms.Label lbl3F;
        private System.Windows.Forms.Label lbl4F;
        private System.Windows.Forms.Label lbl5F;
        private System.Windows.Forms.TextBox txt1F;
        private System.Windows.Forms.TextBox txt1C;
        private System.Windows.Forms.TextBox txt2F;
        private System.Windows.Forms.TextBox txt2C;
        private System.Windows.Forms.TextBox txt3F;
        private System.Windows.Forms.TextBox txt3C;
        private System.Windows.Forms.TextBox txt4F;
        private System.Windows.Forms.TextBox txt4C;
        private System.Windows.Forms.TextBox txt5F;
        private System.Windows.Forms.TextBox txt5C;
        private System.Windows.Forms.TextBox txtOverallRatings;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtOverallComments;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAverageRatings;
        private System.Windows.Forms.Label label3;
    }
}