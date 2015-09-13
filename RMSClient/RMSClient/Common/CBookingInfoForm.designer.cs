namespace RMS.Common
{
    partial class CBookingInfoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBookingInfoForm));
            this.NoofGuestTextBox = new System.Windows.Forms.TextBox();
            this.NoOfGuest = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CallBackRadioButton = new System.Windows.Forms.RadioButton();
            this.ConfirmRadioButton = new System.Windows.Forms.RadioButton();
            this.ProvisionalRadioButton = new System.Windows.Forms.RadioButton();
            this.DateLabel = new System.Windows.Forms.Label();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.myCalendar = new System.Windows.Forms.MonthCalendar();
            this.label10 = new System.Windows.Forms.Label();
            this.FinishRadioButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBuildingName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFloorAptNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHouseNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.tmrCallerInfo = new System.Windows.Forms.Timer(this.components);
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnFindAddress = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.PhoneSearchButton = new System.Windows.Forms.Button();
            this.FinishButton = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.keyboard1 = new RMSUI.keyboard();
            this.SuspendLayout();
            // 
            // NoofGuestTextBox
            // 
            this.NoofGuestTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.NoofGuestTextBox.ForeColor = System.Drawing.Color.Black;
            this.NoofGuestTextBox.Location = new System.Drawing.Point(108, 252);
            this.NoofGuestTextBox.Name = "NoofGuestTextBox";
            this.NoofGuestTextBox.Size = new System.Drawing.Size(173, 20);
            this.NoofGuestTextBox.TabIndex = 13;
            this.NoofGuestTextBox.Click += new System.EventHandler(this.NoGuest_Click);
            this.NoofGuestTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoofGuestTextBox_KeyPress);
            // 
            // NoOfGuest
            // 
            this.NoOfGuest.AutoSize = true;
            this.NoOfGuest.BackColor = System.Drawing.Color.Transparent;
            this.NoOfGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoOfGuest.ForeColor = System.Drawing.Color.White;
            this.NoOfGuest.Location = new System.Drawing.Point(24, 252);
            this.NoOfGuest.Name = "NoOfGuest";
            this.NoOfGuest.Size = new System.Drawing.Size(75, 13);
            this.NoOfGuest.TabIndex = 93;
            this.NoOfGuest.Text = "No of Guest";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.CommentTextBox.ForeColor = System.Drawing.Color.Black;
            this.CommentTextBox.Location = new System.Drawing.Point(393, 224);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(133, 57);
            this.CommentTextBox.TabIndex = 12;
            this.CommentTextBox.Click += new System.EventHandler(this.Comments_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(326, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Comments";
            // 
            // CallBackRadioButton
            // 
            this.CallBackRadioButton.AutoSize = true;
            this.CallBackRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.CallBackRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallBackRadioButton.ForeColor = System.Drawing.Color.White;
            this.CallBackRadioButton.Location = new System.Drawing.Point(286, 285);
            this.CallBackRadioButton.Name = "CallBackRadioButton";
            this.CallBackRadioButton.Size = new System.Drawing.Size(79, 17);
            this.CallBackRadioButton.TabIndex = 27;
            this.CallBackRadioButton.Text = "Call Back";
            this.CallBackRadioButton.UseVisualStyleBackColor = false;
            // 
            // ConfirmRadioButton
            // 
            this.ConfirmRadioButton.AutoSize = true;
            this.ConfirmRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.ConfirmRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmRadioButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmRadioButton.Location = new System.Drawing.Point(199, 285);
            this.ConfirmRadioButton.Name = "ConfirmRadioButton";
            this.ConfirmRadioButton.Size = new System.Drawing.Size(81, 17);
            this.ConfirmRadioButton.TabIndex = 26;
            this.ConfirmRadioButton.Text = "Confirmed";
            this.ConfirmRadioButton.UseVisualStyleBackColor = false;
            // 
            // ProvisionalRadioButton
            // 
            this.ProvisionalRadioButton.AutoSize = true;
            this.ProvisionalRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.ProvisionalRadioButton.Checked = true;
            this.ProvisionalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProvisionalRadioButton.ForeColor = System.Drawing.Color.White;
            this.ProvisionalRadioButton.Location = new System.Drawing.Point(106, 285);
            this.ProvisionalRadioButton.Name = "ProvisionalRadioButton";
            this.ProvisionalRadioButton.Size = new System.Drawing.Size(87, 17);
            this.ProvisionalRadioButton.TabIndex = 25;
            this.ProvisionalRadioButton.TabStop = true;
            this.ProvisionalRadioButton.Text = "Provisional";
            this.ProvisionalRadioButton.UseVisualStyleBackColor = false;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.BackColor = System.Drawing.Color.Transparent;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(656, 271);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(38, 13);
            this.DateLabel.TabIndex = 109;
            this.DateLabel.Text = "Date:";
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.DateTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeLabel.Location = new System.Drawing.Point(483, 53);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(63, 13);
            this.DateTimeLabel.TabIndex = 110;
            this.DateTimeLabel.Text = "ffffffffffffff";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(343, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 178;
            this.label4.Text = "Phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 102);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 177;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Location = new System.Drawing.Point(393, 101);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(133, 22);
            this.txtPhoneNumber.TabIndex = 1;
            this.txtPhoneNumber.Click += new System.EventHandler(this.Phone_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.ForeColor = System.Drawing.Color.Black;
            this.NameTextBox.Location = new System.Drawing.Point(108, 99);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(173, 24);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.Click += new System.EventHandler(this.Name_Click);
            // 
            // myCalendar
            // 
            this.myCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.myCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.myCalendar.Location = new System.Drawing.Point(574, 94);
            this.myCalendar.Name = "myCalendar";
            this.myCalendar.TabIndex = 70;
            this.myCalendar.TitleBackColor = System.Drawing.Color.Gray;
            this.myCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.myCalendar_DateChanged);
            this.myCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.myCalendar_DateSelected);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(375, 51);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(102, 16);
            this.label10.TabIndex = 192;
            this.label10.Text = "Booking Date";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FinishRadioButton
            // 
            this.FinishRadioButton.AutoSize = true;
            this.FinishRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.FinishRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishRadioButton.ForeColor = System.Drawing.Color.White;
            this.FinishRadioButton.Location = new System.Drawing.Point(371, 285);
            this.FinishRadioButton.Name = "FinishRadioButton";
            this.FinishRadioButton.Size = new System.Drawing.Size(72, 17);
            this.FinishRadioButton.TabIndex = 28;
            this.FinishRadioButton.Text = "Finished";
            this.FinishRadioButton.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(279, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 16);
            this.label13.TabIndex = 200;
            this.label13.Text = "Building Name";
            // 
            // txtBuildingName
            // 
            this.txtBuildingName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBuildingName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuildingName.ForeColor = System.Drawing.Color.Black;
            this.txtBuildingName.Location = new System.Drawing.Point(393, 157);
            this.txtBuildingName.Name = "txtBuildingName";
            this.txtBuildingName.Size = new System.Drawing.Size(133, 22);
            this.txtBuildingName.TabIndex = 4;
            this.txtBuildingName.Click += new System.EventHandler(this.BuildinNo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 199;
            this.label8.Text = "Floor or apt No";
            // 
            // txtFloorAptNumber
            // 
            this.txtFloorAptNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFloorAptNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloorAptNumber.ForeColor = System.Drawing.Color.Black;
            this.txtFloorAptNumber.Location = new System.Drawing.Point(108, 127);
            this.txtFloorAptNumber.Name = "txtFloorAptNumber";
            this.txtFloorAptNumber.Size = new System.Drawing.Size(173, 22);
            this.txtFloorAptNumber.TabIndex = 3;
            this.txtFloorAptNumber.Click += new System.EventHandler(this.FloorNo_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(298, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 205;
            this.label14.Text = "House Number";
            // 
            // txtHouseNumber
            // 
            this.txtHouseNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtHouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHouseNumber.ForeColor = System.Drawing.Color.Black;
            this.txtHouseNumber.Location = new System.Drawing.Point(393, 129);
            this.txtHouseNumber.Name = "txtHouseNumber";
            this.txtHouseNumber.Size = new System.Drawing.Size(133, 22);
            this.txtHouseNumber.TabIndex = 5;
            this.txtHouseNumber.Click += new System.EventHandler(this.HouseNo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 204;
            this.label6.Text = "Street Name";
            // 
            // txtStreetName
            // 
            this.txtStreetName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetName.ForeColor = System.Drawing.Color.Black;
            this.txtStreetName.Location = new System.Drawing.Point(108, 193);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(173, 22);
            this.txtStreetName.TabIndex = 6;
            this.txtStreetName.Click += new System.EventHandler(this.Street_Click);
            // 
            // cmbCountry
            // 
            this.cmbCountry.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.ForeColor = System.Drawing.Color.Black;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Items.AddRange(new object[] {
            " Afghanistan (Kabul) (AS)",
            "Albania (Tirane) (EU)",
            "Algeria (Algers) (AF)",
            "Andorra (Andorra la Vella) (EU)",
            "Angola (Luanda) (AF)",
            "Antigua and Barbuda (St. John\'s) (NA)",
            "Argentina (Buenos Aires) (SA)",
            "Armenia (Yerevan) (EU)",
            "Australia (Canberra) (AU)",
            "Austria (Vienna) (EU)",
            "Azerbaijan (Baku) (AS)",
            " Bahamas (Nassau) (NA)",
            "Bahrain (Manama) (AS)",
            "Bangladesh (Dhaka) (AS)",
            "Barbados (Bridgetown) (NA)",
            "Belarus (Minsk) (EU)",
            "Belgium (Brussels) (EU)",
            "Belize (Belmopan) (NA)",
            "Benin (Port-Novo) (AF)",
            "Bhutan (Thimphu) (AS)",
            "Bolivia (Sucre) (SA)",
            "Bosnia and Herzegovina (Sarajevo) (EU)",
            "Botswana (Gaborone) (AF)",
            "Brazil (Brasilia) (SA)",
            "Brunei (Bander Seri Begawan) (AS)",
            "Bulgaria (Sofia) (EU)",
            "Burkina Faso (Ouagadougou) (AF)",
            "Burma/Myanmar (Yangon) (AS)",
            "Burundi (Bujumbura) (AF)",
            " Cambodia (Phnom Penh) (AS)",
            "Cameroon (Yaounde) (AF)",
            "Canada (Ottawa) (NA)",
            "Cape Verde (Praia) (EU - Portugal)",
            "Central African Republic (Bangui) (AF)",
            "Chad (N\'Djamena) (AF)",
            "Chile (Santiago) (SA)",
            "China (Beijing) (AS)",
            "Colombia (Bogota) (SA)",
            "Comoros (Moroni) (AF)",
            "Congo (Brazzaville) (AF)",
            "Congo, Democratic Republic of (Kinshasa) (AF)",
            "Costa Rica (San Jose) (NA)",
            "Cote d\'Ivoire/Ivory Coast (Yamoussoukro) (AF)",
            "Croatia (Zagreb) (EU)",
            "Cuba (Havana) (NA)",
            "Cyprus (Nicosia) (AS) and/or (EU)",
            "Czech Republic (Prague) (EU)",
            " Denmark (Copenhagen) (EU)",
            "Djibouti (Djibouti) (AF)",
            "Dominica (Roseau) (NA)",
            "Dominican Republic (Santo Domingo) (NA)",
            " East Timor (Dili) (AS)",
            "Ecuador (Quito) (SA)",
            "Egypt (Cairo) (AF)",
            "El Salvador (San Salvador) (NA)",
            "Equatorial Guinea (Malabo) (AF)",
            "Eritrea (Asmara) (AF)",
            "Estonia (Tallinn) (EU)",
            "Ethiopia (Addis Ababa) (AF)",
            " Fiji (Suva) (AU - Oceania)",
            "Finland (Helsinki) (EU)",
            "France (Paris) (EU)",
            " Gabon (Liberville) (AF)",
            "Gambia (Banjul) (AF)",
            "Georgia (Tbilisi) (EU)",
            "Germany (Berlin) (EU)",
            "Ghana (Accra) (AF)",
            "Greece (Athens) (EU)",
            "Grenada (St. George\'s) (NA)",
            "Guatemala (Guatemala City) (NA)",
            "Guinea (Conakry) (AF)",
            "Guinea-Bissau (Bissau) (AF)",
            "Guyana (Georgetown) (SA)",
            " Haiti (Port-au-Prince) (NA)",
            "Honduras (Tegucigalpa) (NA)",
            "Hungary (Budapest) (EU)",
            " Iceland (Reykjavik) (EU)",
            "India (New Delhi) (AS)",
            "Indonesia (Jakarta) (AS)",
            "Iran (Tehran) (AS)",
            "Iraq (Baghdad) (AS)",
            "Ireland (Dublin) (EU)",
            "Israel (Jerusalem) (AS)",
            "Italy (Rome) (EU)",
            " Jamaica (Kingston) (NA)",
            "Japan (Tokyo) (AS)",
            "Jordan (Amman) (AS)",
            " Kazakstan (Astana) (AS)",
            "Kenya (Nairobi) (AF)",
            "Kiribati (Bairiki) (AU - Oceania)",
            "Korea, North (Pyongyang) (AS)",
            "Korea, South (Seoul) (AS)",
            "Kuwait (Kuwait City) (AS)",
            "Kyrgyzstan (Bishkek) (AS)",
            " Laos (Vientiane) (AS)",
            "Latvia (Riga) (EU)",
            "Lebanon (Beirut) (AS)",
            "Lesotho (Maseru) (AF)",
            "Liberia (Monrovia) (AF)",
            "Libya (Tripoli) (AF)",
            "Liechtenstein (Vaduz) (EU)",
            "Lithuania (Vilnius) (EU)",
            "Luxembourg (Luxembourg) (EU)",
            " Macedonia (Skopje) (EU)",
            "Madagascar (Antananarivo) (AF)",
            "Malawi (Lilongwe) (AF)",
            "Malaysia (Kuala Lumpur) (AS)",
            "Maldives (Male) (AS)",
            "Mali (Bamako) (AF)",
            "Malta (Valletta) (EU)",
            "Marshall Islands (Majuro) (AU - Oceania)",
            "Mauritania (Nouakchott) (AF)",
            "Mauritius (Port Louis) (AF)",
            "Mexico (Mexico City) (NA)",
            "Micronesia (Palikir) (AU - Oceania)",
            "Moldova (Chisinau) (EU)",
            "Monaco (Monaco) (EU)",
            "Mongolia (Ulan Bator) (AS)",
            "Montenegro (Podgorica) (EU)",
            "Morocco (Rabat) (AF) (including Western Sahara)",
            "Mozambique (Maputo) (AF)",
            " Namibia (Windhoek) (AF)",
            "Nauru (no official capital) (AU - Oceania)",
            "Nepal (Kathmandu) (AS)",
            "Netherlands (Amsterdam, The Hague) (EU)",
            "New Zealand (Wellington) (AU)",
            "Nicaragua (Managua) (NA)",
            "Niger (Niamey) (AF)",
            "Nigeria (Abuja) (AF)",
            "Norway (Oslo) (EU)",
            " Oman (Muscat) (AS) ",
            " Pakistan (Islamabad) (AS)",
            "Palau (Koror) (AU - Oceania)",
            "Panama (Panama City) (NA)",
            "Papua New Guinea (Port Moresby) (AU)",
            "Paraguay (Asuncion) (SA)",
            "Peru (Lima) (SA)",
            "Philippines (Manila) (AS)",
            "Poland (Warsaw) (EU)",
            "Portugal (Lisbon) (EU)",
            " Qatar (Doha) (AS) ",
            " Romania (Bucharest) (EU)",
            "Russian Federation (Moscow) (AS)",
            "Rwanda (Kigali) (AF)",
            " Saint Kitts and Nevis (Basseterre) (NA)",
            "Saint Lucia (Castries) (NA)",
            "Saint Vincent and the Grenadines (Kingstown) (NA)",
            "Samoa (Apia) (AU - Oceania)",
            "San Marino (San Marino) (EU)",
            "Sao Tome and Principe (Sao Tome) (AF)",
            "Saudi Arabia (Riyadh) (AS)",
            "Senegal (Dakar) (AF)",
            "Serbia (Belgrade) (EU)",
            "Seychelles (Victoria) (AF)",
            "Sierra Leone (Freetown) (AF)",
            "Singapore (Singapore City) (AS)",
            "Slovakia (Bratislava) (EU)",
            "Slovenia (Ljubljana) (EU)",
            "Solomon Islands (Honiara) (AU - Oceania)",
            "Somalia (Mogadishu) (AF)",
            "South Africa (Pretoria, Cape Town, Bloemfontein) (AF)",
            "Spain (Madrid) (EU)",
            "Sri Lanka (Colombo) (AS)",
            "Sudan (Khartoum) (AF)",
            "Suriname (Paramaribo) (SA)",
            "Swaziland (Mbabane) (AF)",
            "Sweden (Stockholm) (EU)",
            "Switzerland (Bern) (EU)",
            "Syria (Damascus) (AS)",
            " Tajikistan (Dushanbe) (AS)",
            "Tanzania (Dodoma) (AF)",
            "Thailand (Bangkok) (AS)",
            "Togo (Lome) (AF)",
            "Tonga (Nuku\'alofa) (AU - Oceania)",
            "Trinidad and Tobago (Port-of-Spain) (NA)",
            "Tunisia (Tunis) (AF)",
            "Turkey (Ankara) (AS) & (EU)",
            "Turkmenistan (Ashgabat) (AS)",
            "Tuvalu (Funafuti) (AU - Oceania)",
            " Uganda (Kampala) (AF)",
            "Ukraine (Kiev) (EU)",
            "United Arab Emirates (Abu Dhabi) (AS)",
            "United Kingdom (London) (EU)",
            "United States (Washington D.C.) (NA)",
            "Uruguay (Montevideo) (SA)",
            "Uzbekistan (Tashkent) (AS)",
            " Vanuatu (Port-Vila) (AU - Oceania)",
            "Vatican City (na) (EU)",
            "Venezuela (Caracas) (SA)",
            "Vietnam (Hanoi) (AS)",
            " Yemen (Sana) (AS)",
            " Zambia (Lusaka) (AF)",
            "Zimbabwe (Harare) (AF)"});
            this.cmbCountry.Location = new System.Drawing.Point(393, 187);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(133, 21);
            this.cmbCountry.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(338, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 212;
            this.label9.Text = "Country";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(60, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 211;
            this.label7.Text = "Town";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 210;
            this.label5.Text = "Postal Code";
            // 
            // txtTown
            // 
            this.txtTown.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.ForeColor = System.Drawing.Color.Black;
            this.txtTown.Location = new System.Drawing.Point(108, 222);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(173, 22);
            this.txtTown.TabIndex = 10;
            this.txtTown.Click += new System.EventHandler(this.Town_Click);
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostalCode.ForeColor = System.Drawing.Color.Black;
            this.txtPostalCode.Location = new System.Drawing.Point(108, 155);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(88, 22);
            this.txtPostalCode.TabIndex = 8;
            this.txtPostalCode.Click += new System.EventHandler(this.PostalCode_Click);
            // 
            // tmrCallerInfo
            // 
            this.tmrCallerInfo.Interval = 1000;
            this.tmrCallerInfo.Tick += new System.EventHandler(this.tmrCallerInfo_Tick);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.Yellow;
            this.lblPhoneNumber.Location = new System.Drawing.Point(77, 54);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(90, 13);
            this.lblPhoneNumber.TabIndex = 218;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Yellow;
            this.lblCustomer.Location = new System.Drawing.Point(77, 73);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(95, 13);
            this.lblCustomer.TabIndex = 219;
            this.lblCustomer.Text = "Customer Name";
            // 
            // btnFindAddress
            // 
            this.btnFindAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFindAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFindAddress.FlatAppearance.BorderSize = 0;
            this.btnFindAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFindAddress.Location = new System.Drawing.Point(201, 153);
            this.btnFindAddress.Name = "btnFindAddress";
            this.btnFindAddress.Size = new System.Drawing.Size(78, 32);
            this.btnFindAddress.TabIndex = 215;
            this.btnFindAddress.Text = " Look Up";
            this.btnFindAddress.UseVisualStyleBackColor = false;
            this.btnFindAddress.Click += new System.EventHandler(this.btnFindAddress_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Silver;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
            this.btnAccept.Location = new System.Drawing.Point(39, 54);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(32, 32);
            this.btnAccept.TabIndex = 222;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // PhoneSearchButton
            // 
            this.PhoneSearchButton.BackColor = System.Drawing.Color.Transparent;
            this.PhoneSearchButton.BackgroundImage = global::RMS.Properties.Resources.search3;
            this.PhoneSearchButton.FlatAppearance.BorderSize = 0;
            this.PhoneSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PhoneSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneSearchButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PhoneSearchButton.Location = new System.Drawing.Point(529, 102);
            this.PhoneSearchButton.Name = "PhoneSearchButton";
            this.PhoneSearchButton.Size = new System.Drawing.Size(33, 29);
            this.PhoneSearchButton.TabIndex = 2;
            this.PhoneSearchButton.UseVisualStyleBackColor = false;
            this.PhoneSearchButton.Click += new System.EventHandler(this.PhoneSearchButton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.BackColor = System.Drawing.Color.Transparent;
            this.FinishButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FinishButton.BackgroundImage")));
            this.FinishButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("FinishButton.BgImageOnMouseDown")));
            this.FinishButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("FinishButton.BgImageOnMouseUp")));
            this.FinishButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FinishButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FinishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FinishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinishButton.Font = new System.Drawing.Font("Arial", 10F);
            this.FinishButton.ForeColor = System.Drawing.Color.Black;
            this.FinishButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.FinishButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.FinishButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.FinishButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FinishButton.Location = new System.Drawing.Point(627, 555);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(120, 40);
            this.FinishButton.TabIndex = 71;
            this.FinishButton.Text = "Finished";
            this.FinishButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FinishButton.UseVisualStyleBackColor = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelButton.BackgroundImage")));
            this.CancelButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseDown")));
            this.CancelButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("CancelButton.BgImageOnMouseUp")));
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 10F);
            this.CancelButton.ForeColor = System.Drawing.Color.Black;
            this.CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(488, 555);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 72;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.Color.White;
            this.keyboard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.ForeColor = System.Drawing.Color.Black;
            this.keyboard1.Location = new System.Drawing.Point(19, 304);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(728, 247);
            this.keyboard1.TabIndex = 307;
            this.keyboard1.textBox = null;
            // 
            // CBookingInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.btnFindAddress);
            this.Controls.Add(this.PhoneSearchButton);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtHouseNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStreetName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBuildingName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFloorAptNumber);
            this.Controls.Add(this.FinishRadioButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.CallBackRadioButton);
            this.Controls.Add(this.ConfirmRadioButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ProvisionalRadioButton);
            this.Controls.Add(this.myCalendar);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NoofGuestTextBox);
            this.Controls.Add(this.NoOfGuest);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CBookingInfoForm";
            this.ScreenTitle = "Booking Form";
            this.Load += new System.EventHandler(this.CBookingInfoForm_Load);
            this.Controls.SetChildIndex(this.NoOfGuest, 0);
            this.Controls.SetChildIndex(this.NoofGuestTextBox, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.CommentTextBox, 0);
            this.Controls.SetChildIndex(this.FinishButton, 0);
            this.Controls.SetChildIndex(this.myCalendar, 0);
            this.Controls.SetChildIndex(this.ProvisionalRadioButton, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.ConfirmRadioButton, 0);
            this.Controls.SetChildIndex(this.CallBackRadioButton, 0);
            this.Controls.SetChildIndex(this.DateLabel, 0);
            this.Controls.SetChildIndex(this.DateTimeLabel, 0);
            this.Controls.SetChildIndex(this.NameTextBox, 0);
            this.Controls.SetChildIndex(this.txtPhoneNumber, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.FinishRadioButton, 0);
            this.Controls.SetChildIndex(this.txtFloorAptNumber, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtBuildingName, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtStreetName, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtHouseNumber, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtPostalCode, 0);
            this.Controls.SetChildIndex(this.txtTown, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.PhoneSearchButton, 0);
            this.Controls.SetChildIndex(this.btnFindAddress, 0);
            this.Controls.SetChildIndex(this.lblPhoneNumber, 0);
            this.Controls.SetChildIndex(this.lblCustomer, 0);
            this.Controls.SetChildIndex(this.btnAccept, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NoofGuestTextBox;
        private System.Windows.Forms.Label NoOfGuest;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton CallBackRadioButton;
        private System.Windows.Forms.RadioButton ConfirmRadioButton;
        private System.Windows.Forms.RadioButton ProvisionalRadioButton;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.MonthCalendar myCalendar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton FinishRadioButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFloorAptNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHouseNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Button PhoneSearchButton;
        private System.Windows.Forms.Button btnFindAddress;
        private System.Windows.Forms.Timer tmrCallerInfo;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnAccept;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton FinishButton;
        private RMSUI.FunctionalButton CancelButton;
    }
}