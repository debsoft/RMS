namespace RMS.TakeAway
{
    partial class CTakeAwayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTakeAwayForm));
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.lblTown = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblDelTime = new System.Windows.Forms.Label();
            this.RecentOrderButton = new RMSUI.FunctionalButton();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.cmbHour = new System.Windows.Forms.ComboBox();
            this.cmbMinute = new System.Windows.Forms.ComboBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.cmbMeridiem = new System.Windows.Forms.ComboBox();
            this.lblMeridien = new System.Windows.Forms.Label();
            this.lblFlatApt = new System.Windows.Forms.Label();
            this.txtFloorAptNumber = new System.Windows.Forms.TextBox();
            this.lblBuildingName = new System.Windows.Forms.Label();
            this.txtBuildingName = new System.Windows.Forms.TextBox();
            this.lblHouseNumber = new System.Windows.Forms.Label();
            this.txtHouseNumber = new System.Windows.Forms.TextBox();
            this.lblMandatoryPostalCode = new System.Windows.Forms.Label();
            this.lblMandatoryTown = new System.Windows.Forms.Label();
            this.btnFindAddress = new RMSUI.FunctionalButton();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.tmrCallerInfo = new System.Windows.Forms.Timer(this.components);
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnSearchByPhone = new System.Windows.Forms.Button();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.FinishButton = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.txtTips = new System.Windows.Forms.TextBox();
            this.keyboard1 = new RMSUI.keyboard();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerName.Location = new System.Drawing.Point(129, 54);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(233, 24);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.Click += new System.EventHandler(this.TextBox_Click);
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerName_KeyPress);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Location = new System.Drawing.Point(129, 85);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(233, 22);
            this.txtPhoneNumber.TabIndex = 2;
            this.txtPhoneNumber.Click += new System.EventHandler(this.TextBox_Click_txtPhoneNumber);
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneTextBox_KeyPress);
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostalCode.ForeColor = System.Drawing.Color.Black;
            this.txtPostalCode.Location = new System.Drawing.Point(604, 142);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(119, 22);
            this.txtPostalCode.TabIndex = 9;
            this.txtPostalCode.Click += new System.EventHandler(this.TextBox_Click_txtPostalCode);
            this.txtPostalCode.TextChanged += new System.EventHandler(this.txtPostalCode_TextChanged);
            this.txtPostalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPostalCode_KeyPress);
            // 
            // txtStreetName
            // 
            this.txtStreetName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetName.ForeColor = System.Drawing.Color.Black;
            this.txtStreetName.Location = new System.Drawing.Point(129, 141);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(374, 22);
            this.txtStreetName.TabIndex = 7;
            this.txtStreetName.Click += new System.EventHandler(this.TextBox_Click_txtStreetName);
            // 
            // txtTown
            // 
            this.txtTown.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.ForeColor = System.Drawing.Color.Black;
            this.txtTown.Location = new System.Drawing.Point(605, 173);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(118, 22);
            this.txtTown.TabIndex = 12;
            this.txtTown.Click += new System.EventHandler(this.TextBox_Click_txtTown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(74, 58);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 99;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(74, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 100;
            this.label4.Text = "Phone";
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.BackColor = System.Drawing.Color.Transparent;
            this.lblPostCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostCode.ForeColor = System.Drawing.Color.Black;
            this.lblPostCode.Location = new System.Drawing.Point(516, 145);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(82, 16);
            this.lblPostCode.TabIndex = 101;
            this.lblPostCode.Text = "Postal Code";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.BackColor = System.Drawing.Color.Transparent;
            this.lblStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreetName.ForeColor = System.Drawing.Color.Black;
            this.lblStreetName.Location = new System.Drawing.Point(38, 145);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(83, 16);
            this.lblStreetName.TabIndex = 102;
            this.lblStreetName.Text = "Street Name";
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.BackColor = System.Drawing.Color.Transparent;
            this.lblTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.ForeColor = System.Drawing.Color.Black;
            this.lblTown.Location = new System.Drawing.Point(557, 175);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(41, 16);
            this.lblTown.TabIndex = 103;
            this.lblTown.Text = "Town";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.BackColor = System.Drawing.Color.Transparent;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.Color.Black;
            this.lblCountry.Location = new System.Drawing.Point(590, 221);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(53, 16);
            this.lblCountry.TabIndex = 105;
            this.lblCountry.Text = "Country";
            this.lblCountry.Visible = false;
            // 
            // lblDelTime
            // 
            this.lblDelTime.AutoSize = true;
            this.lblDelTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelTime.ForeColor = System.Drawing.Color.Black;
            this.lblDelTime.Location = new System.Drawing.Point(60, 219);
            this.lblDelTime.Name = "lblDelTime";
            this.lblDelTime.Size = new System.Drawing.Size(63, 16);
            this.lblDelTime.TabIndex = 106;
            this.lblDelTime.Text = "Del Time";
            // 
            // RecentOrderButton
            // 
            this.RecentOrderButton.BackColor = System.Drawing.Color.Transparent;
            this.RecentOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RecentOrderButton.BackgroundImage")));
            this.RecentOrderButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("RecentOrderButton.BgImageOnMouseDown")));
            this.RecentOrderButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("RecentOrderButton.BgImageOnMouseUp")));
            this.RecentOrderButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.RecentOrderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RecentOrderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RecentOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecentOrderButton.Font = new System.Drawing.Font("Arial", 10F);
            this.RecentOrderButton.ForeColor = System.Drawing.Color.Black;
            this.RecentOrderButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.RecentOrderButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.RecentOrderButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.RecentOrderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecentOrderButton.Location = new System.Drawing.Point(424, 209);
            this.RecentOrderButton.Name = "RecentOrderButton";
            this.RecentOrderButton.Size = new System.Drawing.Size(119, 34);
            this.RecentOrderButton.TabIndex = 11;
            this.RecentOrderButton.Text = "Recent Orders";
            this.RecentOrderButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecentOrderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RecentOrderButton.UseVisualStyleBackColor = false;
            this.RecentOrderButton.Click += new System.EventHandler(this.RecentOrderButton_Click);
            // 
            // cmbCountry
            // 
            this.cmbCountry.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cmbCountry.Location = new System.Drawing.Point(567, 215);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(121, 24);
            this.cmbCountry.TabIndex = 13;
            this.cmbCountry.Visible = false;
            // 
            // cmbHour
            // 
            this.cmbHour.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHour.ForeColor = System.Drawing.Color.Black;
            this.cmbHour.FormattingEnabled = true;
            this.cmbHour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbHour.Location = new System.Drawing.Point(127, 215);
            this.cmbHour.Name = "cmbHour";
            this.cmbHour.Size = new System.Drawing.Size(43, 24);
            this.cmbHour.TabIndex = 14;
            // 
            // cmbMinute
            // 
            this.cmbMinute.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMinute.ForeColor = System.Drawing.Color.Black;
            this.cmbMinute.FormattingEnabled = true;
            this.cmbMinute.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cmbMinute.Location = new System.Drawing.Point(176, 215);
            this.cmbMinute.Name = "cmbMinute";
            this.cmbMinute.Size = new System.Drawing.Size(46, 24);
            this.cmbMinute.TabIndex = 15;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.BackColor = System.Drawing.Color.Transparent;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMinutes.ForeColor = System.Drawing.Color.Black;
            this.lblMinutes.Location = new System.Drawing.Point(174, 197);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(47, 16);
            this.lblMinutes.TabIndex = 110;
            this.lblMinutes.Text = "Minute";
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.BackColor = System.Drawing.Color.Transparent;
            this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblHour.ForeColor = System.Drawing.Color.Black;
            this.lblHour.Location = new System.Drawing.Point(126, 196);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(37, 16);
            this.lblHour.TabIndex = 111;
            this.lblHour.Text = "Hour";
            // 
            // cmbMeridiem
            // 
            this.cmbMeridiem.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbMeridiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeridiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMeridiem.ForeColor = System.Drawing.Color.Black;
            this.cmbMeridiem.FormattingEnabled = true;
            this.cmbMeridiem.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbMeridiem.Location = new System.Drawing.Point(228, 215);
            this.cmbMeridiem.Name = "cmbMeridiem";
            this.cmbMeridiem.Size = new System.Drawing.Size(57, 24);
            this.cmbMeridiem.TabIndex = 16;
            // 
            // lblMeridien
            // 
            this.lblMeridien.AutoSize = true;
            this.lblMeridien.BackColor = System.Drawing.Color.Transparent;
            this.lblMeridien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMeridien.ForeColor = System.Drawing.Color.Black;
            this.lblMeridien.Location = new System.Drawing.Point(227, 197);
            this.lblMeridien.Name = "lblMeridien";
            this.lblMeridien.Size = new System.Drawing.Size(64, 16);
            this.lblMeridien.TabIndex = 113;
            this.lblMeridien.Text = "Meridiem";
            // 
            // lblFlatApt
            // 
            this.lblFlatApt.AutoSize = true;
            this.lblFlatApt.BackColor = System.Drawing.Color.Transparent;
            this.lblFlatApt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlatApt.ForeColor = System.Drawing.Color.Black;
            this.lblFlatApt.Location = new System.Drawing.Point(24, 117);
            this.lblFlatApt.Name = "lblFlatApt";
            this.lblFlatApt.Size = new System.Drawing.Size(97, 16);
            this.lblFlatApt.TabIndex = 115;
            this.lblFlatApt.Text = "Floor or apt No";
            // 
            // txtFloorAptNumber
            // 
            this.txtFloorAptNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFloorAptNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloorAptNumber.ForeColor = System.Drawing.Color.Black;
            this.txtFloorAptNumber.Location = new System.Drawing.Point(129, 113);
            this.txtFloorAptNumber.Name = "txtFloorAptNumber";
            this.txtFloorAptNumber.Size = new System.Drawing.Size(71, 22);
            this.txtFloorAptNumber.TabIndex = 4;
            this.txtFloorAptNumber.Click += new System.EventHandler(this.TextBox_Click_txtFloorAptNumber);
            // 
            // lblBuildingName
            // 
            this.lblBuildingName.AutoSize = true;
            this.lblBuildingName.BackColor = System.Drawing.Color.Transparent;
            this.lblBuildingName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildingName.ForeColor = System.Drawing.Color.Black;
            this.lblBuildingName.Location = new System.Drawing.Point(423, 115);
            this.lblBuildingName.Name = "lblBuildingName";
            this.lblBuildingName.Size = new System.Drawing.Size(96, 16);
            this.lblBuildingName.TabIndex = 117;
            this.lblBuildingName.Text = "Building Name";
            // 
            // txtBuildingName
            // 
            this.txtBuildingName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBuildingName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuildingName.ForeColor = System.Drawing.Color.Black;
            this.txtBuildingName.Location = new System.Drawing.Point(528, 113);
            this.txtBuildingName.Name = "txtBuildingName";
            this.txtBuildingName.Size = new System.Drawing.Size(195, 22);
            this.txtBuildingName.TabIndex = 5;
            this.txtBuildingName.Click += new System.EventHandler(this.TextBox_Click_txtBuildingName);
            // 
            // lblHouseNumber
            // 
            this.lblHouseNumber.AutoSize = true;
            this.lblHouseNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblHouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseNumber.ForeColor = System.Drawing.Color.Black;
            this.lblHouseNumber.Location = new System.Drawing.Point(215, 116);
            this.lblHouseNumber.Name = "lblHouseNumber";
            this.lblHouseNumber.Size = new System.Drawing.Size(99, 16);
            this.lblHouseNumber.TabIndex = 119;
            this.lblHouseNumber.Text = "House Number";
            // 
            // txtHouseNumber
            // 
            this.txtHouseNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtHouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHouseNumber.ForeColor = System.Drawing.Color.Black;
            this.txtHouseNumber.Location = new System.Drawing.Point(318, 112);
            this.txtHouseNumber.Name = "txtHouseNumber";
            this.txtHouseNumber.Size = new System.Drawing.Size(71, 22);
            this.txtHouseNumber.TabIndex = 6;
            this.txtHouseNumber.Click += new System.EventHandler(this.TextBox_Click_txtHouseNumber);
            // 
            // lblMandatoryPostalCode
            // 
            this.lblMandatoryPostalCode.AutoSize = true;
            this.lblMandatoryPostalCode.BackColor = System.Drawing.Color.Transparent;
            this.lblMandatoryPostalCode.ForeColor = System.Drawing.Color.Orange;
            this.lblMandatoryPostalCode.Location = new System.Drawing.Point(362, 49);
            this.lblMandatoryPostalCode.Name = "lblMandatoryPostalCode";
            this.lblMandatoryPostalCode.Size = new System.Drawing.Size(11, 13);
            this.lblMandatoryPostalCode.TabIndex = 120;
            this.lblMandatoryPostalCode.Text = "*";
            // 
            // lblMandatoryTown
            // 
            this.lblMandatoryTown.AutoSize = true;
            this.lblMandatoryTown.BackColor = System.Drawing.Color.Transparent;
            this.lblMandatoryTown.ForeColor = System.Drawing.Color.Orange;
            this.lblMandatoryTown.Location = new System.Drawing.Point(363, 86);
            this.lblMandatoryTown.Name = "lblMandatoryTown";
            this.lblMandatoryTown.Size = new System.Drawing.Size(11, 13);
            this.lblMandatoryTown.TabIndex = 123;
            this.lblMandatoryTown.Text = "*";
            // 
            // btnFindAddress
            // 
            this.btnFindAddress.BackColor = System.Drawing.Color.Transparent;
            this.btnFindAddress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindAddress.BackgroundImage")));
            this.btnFindAddress.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnFindAddress.BgImageOnMouseDown")));
            this.btnFindAddress.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnFindAddress.BgImageOnMouseUp")));
            this.btnFindAddress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnFindAddress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFindAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFindAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindAddress.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFindAddress.ForeColor = System.Drawing.Color.Black;
            this.btnFindAddress.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnFindAddress.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnFindAddress.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.btnFindAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindAddress.Location = new System.Drawing.Point(297, 209);
            this.btnFindAddress.Name = "btnFindAddress";
            this.btnFindAddress.Size = new System.Drawing.Size(121, 34);
            this.btnFindAddress.TabIndex = 10;
            this.btnFindAddress.Text = "Address Lookup";
            this.btnFindAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindAddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindAddress.UseVisualStyleBackColor = false;
            this.btnFindAddress.Click += new System.EventHandler(this.btnFindAddress_Click);
            // 
            // txtStreet2
            // 
            this.txtStreet2.BackColor = System.Drawing.Color.Gainsboro;
            this.txtStreet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet2.ForeColor = System.Drawing.Color.Black;
            this.txtStreet2.Location = new System.Drawing.Point(129, 170);
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(374, 22);
            this.txtStreet2.TabIndex = 8;
            this.txtStreet2.Click += new System.EventHandler(this.TextBox_Click_txtStreet2);
            // 
            // tmrCallerInfo
            // 
            this.tmrCallerInfo.Interval = 1000;
            this.tmrCallerInfo.Tick += new System.EventHandler(this.tmrCallerInfo_Tick);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.SystemColors.Info;
            this.lblPhone.Location = new System.Drawing.Point(718, 223);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(90, 13);
            this.lblPhone.TabIndex = 221;
            this.lblPhone.Text = "Phone Number";
            this.lblPhone.Visible = false;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.Info;
            this.lblCustomerName.Location = new System.Drawing.Point(718, 281);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 222;
            this.lblCustomerName.Text = "Customer Name";
            this.lblCustomerName.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
            this.btnAccept.Location = new System.Drawing.Point(700, 245);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(32, 32);
            this.btnAccept.TabIndex = 220;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Visible = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnSearchByPhone
            // 
            this.btnSearchByPhone.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchByPhone.BackgroundImage = global::RMS.Properties.Resources.search3;
            this.btnSearchByPhone.FlatAppearance.BorderSize = 0;
            this.btnSearchByPhone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearchByPhone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearchByPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByPhone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearchByPhone.Location = new System.Drawing.Point(377, 82);
            this.btnSearchByPhone.Name = "btnSearchByPhone";
            this.btnSearchByPhone.Size = new System.Drawing.Size(35, 29);
            this.btnSearchByPhone.TabIndex = 3;
            this.btnSearchByPhone.UseVisualStyleBackColor = false;
            this.btnSearchByPhone.Click += new System.EventHandler(this.btnSearchByPhone_Click);
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnFindCustomer.BackgroundImage = global::RMS.Properties.Resources.search2;
            this.btnFindCustomer.FlatAppearance.BorderSize = 0;
            this.btnFindCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFindCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFindCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFindCustomer.Location = new System.Drawing.Point(375, 51);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(35, 29);
            this.btnFindCustomer.TabIndex = 1;
            this.btnFindCustomer.UseVisualStyleBackColor = false;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
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
            this.FinishButton.Location = new System.Drawing.Point(468, 509);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(130, 40);
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
            this.CancelButton.Location = new System.Drawing.Point(608, 509);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(80, 40);
            this.CancelButton.TabIndex = 72;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // txtTips
            // 
            this.txtTips.BackColor = System.Drawing.SystemColors.ControlText;
            this.txtTips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTips.ForeColor = System.Drawing.Color.White;
            this.txtTips.Location = new System.Drawing.Point(18, 509);
            this.txtTips.Multiline = true;
            this.txtTips.Name = "txtTips";
            this.txtTips.ReadOnly = true;
            this.txtTips.Size = new System.Drawing.Size(348, 36);
            this.txtTips.TabIndex = 226;
            this.txtTips.Text = "*Tips: You can keep customer name and telephone number empty and click finish, th" +
                "at will generate an auto ID for the collection/waiting order";
            this.txtTips.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyboard1
            // 
            this.keyboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.keyboard1.BackColor = System.Drawing.Color.LightGray;
            this.keyboard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.ForeColor = System.Drawing.Color.Black;
            this.keyboard1.Location = new System.Drawing.Point(18, 254);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(669, 248);
            this.keyboard1.TabIndex = 227;
            this.keyboard1.textBox = null;
            // 
            // CTakeAwayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtStreet2);
            this.Controls.Add(this.btnSearchByPhone);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.btnFindCustomer);
            this.Controls.Add(this.lblMandatoryTown);
            this.Controls.Add(this.lblMandatoryPostalCode);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblFlatApt);
            this.Controls.Add(this.lblHouseNumber);
            this.Controls.Add(this.txtFloorAptNumber);
            this.Controls.Add(this.txtHouseNumber);
            this.Controls.Add(this.txtBuildingName);
            this.Controls.Add(this.btnFindAddress);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.lblBuildingName);
            this.Controls.Add(this.lblMeridien);
            this.Controls.Add(this.cmbMeridiem);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.cmbMinute);
            this.Controls.Add(this.cmbHour);
            this.Controls.Add(this.RecentOrderButton);
            this.Controls.Add(this.lblStreetName);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblDelTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStreetName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTown);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.lblPostCode);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.txtTips);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CTakeAwayForm";
            this.Activated += new System.EventHandler(this.CTakeAwayForm_Activated);
            this.Controls.SetChildIndex(this.txtTips, 0);
            this.Controls.SetChildIndex(this.FinishButton, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.txtTown, 0);
            this.Controls.SetChildIndex(this.lblPostCode, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.txtPostalCode, 0);
            this.Controls.SetChildIndex(this.txtCustomerName, 0);
            this.Controls.SetChildIndex(this.txtPhoneNumber, 0);
            this.Controls.SetChildIndex(this.lblTown, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtStreetName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblDelTime, 0);
            this.Controls.SetChildIndex(this.lblCountry, 0);
            this.Controls.SetChildIndex(this.lblStreetName, 0);
            this.Controls.SetChildIndex(this.RecentOrderButton, 0);
            this.Controls.SetChildIndex(this.cmbHour, 0);
            this.Controls.SetChildIndex(this.cmbMinute, 0);
            this.Controls.SetChildIndex(this.lblMinutes, 0);
            this.Controls.SetChildIndex(this.cmbMeridiem, 0);
            this.Controls.SetChildIndex(this.lblMeridien, 0);
            this.Controls.SetChildIndex(this.lblBuildingName, 0);
            this.Controls.SetChildIndex(this.lblHour, 0);
            this.Controls.SetChildIndex(this.btnFindAddress, 0);
            this.Controls.SetChildIndex(this.txtBuildingName, 0);
            this.Controls.SetChildIndex(this.txtHouseNumber, 0);
            this.Controls.SetChildIndex(this.txtFloorAptNumber, 0);
            this.Controls.SetChildIndex(this.lblHouseNumber, 0);
            this.Controls.SetChildIndex(this.lblFlatApt, 0);
            this.Controls.SetChildIndex(this.lblPhone, 0);
            this.Controls.SetChildIndex(this.lblCustomerName, 0);
            this.Controls.SetChildIndex(this.lblMandatoryPostalCode, 0);
            this.Controls.SetChildIndex(this.lblMandatoryTown, 0);
            this.Controls.SetChildIndex(this.btnFindCustomer, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.Controls.SetChildIndex(this.btnSearchByPhone, 0);
            this.Controls.SetChildIndex(this.txtStreet2, 0);
            this.Controls.SetChildIndex(this.btnAccept, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblDelTime;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.ComboBox cmbHour;
        private System.Windows.Forms.ComboBox cmbMinute;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.ComboBox cmbMeridiem;
        private System.Windows.Forms.Label lblMeridien;
        private System.Windows.Forms.Label lblFlatApt;
        private System.Windows.Forms.TextBox txtFloorAptNumber;
        private System.Windows.Forms.Label lblBuildingName;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.Label lblHouseNumber;
        private System.Windows.Forms.TextBox txtHouseNumber;
        private System.Windows.Forms.Label lblMandatoryPostalCode;
        private System.Windows.Forms.Label lblMandatoryTown;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Button btnSearchByPhone;
        public System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtStreet2;
        private System.Windows.Forms.Timer tmrCallerInfo;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtTips;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton FinishButton;
        private RMSUI.FunctionalButton CancelButton;
        private RMSUI.FunctionalButton btnFindAddress;
        private RMSUI.FunctionalButton RecentOrderButton;

        public System.EventHandler txtCustomerName_TextChanged { get; set; }
    }
}