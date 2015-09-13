namespace RMS.Common
{
    partial class CCustomerInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCustomerInfoForm));
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBuildingName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFloorAptNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHouseNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.FinishButton = new RMSUI.FunctionalButton();
            this.CancelButton = new RMSUI.FunctionalButton();
            this.btnAddressLookup = new RMSUI.FunctionalButton();
            this.btnSearchByPhone = new System.Windows.Forms.Button();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.keyboard1 = new RMSUI.keyboard();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(137, 55);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 301;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerName.Location = new System.Drawing.Point(188, 52);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(342, 23);
            this.txtCustomerName.TabIndex = 300;
            this.txtCustomerName.Click += new System.EventHandler(this.Name_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(86, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 16);
            this.label13.TabIndex = 305;
            this.label13.Text = "Building Name";
            // 
            // txtBuildingName
            // 
            this.txtBuildingName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBuildingName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuildingName.ForeColor = System.Drawing.Color.Black;
            this.txtBuildingName.Location = new System.Drawing.Point(188, 136);
            this.txtBuildingName.Name = "txtBuildingName";
            this.txtBuildingName.Size = new System.Drawing.Size(342, 23);
            this.txtBuildingName.TabIndex = 303;
            this.txtBuildingName.Click += new System.EventHandler(this.buildingName_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(80, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 16);
            this.label8.TabIndex = 304;
            this.label8.Text = "Floor or Apt No.";
            // 
            // txtFloorAptNumber
            // 
            this.txtFloorAptNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFloorAptNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloorAptNumber.ForeColor = System.Drawing.Color.Black;
            this.txtFloorAptNumber.Location = new System.Drawing.Point(188, 108);
            this.txtFloorAptNumber.Name = "txtFloorAptNumber";
            this.txtFloorAptNumber.Size = new System.Drawing.Size(99, 23);
            this.txtFloorAptNumber.TabIndex = 302;
            this.txtFloorAptNumber.Click += new System.EventHandler(this.Floor_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(83, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 16);
            this.label14.TabIndex = 312;
            this.label14.Text = "House Number";
            // 
            // txtHouseNumber
            // 
            this.txtHouseNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtHouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHouseNumber.ForeColor = System.Drawing.Color.Black;
            this.txtHouseNumber.Location = new System.Drawing.Point(188, 163);
            this.txtHouseNumber.Name = "txtHouseNumber";
            this.txtHouseNumber.Size = new System.Drawing.Size(99, 23);
            this.txtHouseNumber.TabIndex = 306;
            this.txtHouseNumber.Click += new System.EventHandler(this.HouseNo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(141, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 311;
            this.label7.Text = "Town";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(99, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 310;
            this.label6.Text = "Street Name";
            // 
            // txtTown
            // 
            this.txtTown.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.ForeColor = System.Drawing.Color.Black;
            this.txtTown.Location = new System.Drawing.Point(188, 217);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(342, 23);
            this.txtTown.TabIndex = 309;
            this.txtTown.Click += new System.EventHandler(this.Town_Click);
            // 
            // txtStreetName
            // 
            this.txtStreetName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetName.ForeColor = System.Drawing.Color.Black;
            this.txtStreetName.Location = new System.Drawing.Point(188, 190);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(342, 23);
            this.txtStreetName.TabIndex = 308;
            this.txtStreetName.Click += new System.EventHandler(this.StreetName_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Location = new System.Drawing.Point(188, 81);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(342, 23);
            this.txtPhoneNumber.TabIndex = 307;
            this.txtPhoneNumber.Click += new System.EventHandler(this.Phone_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(134, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 316;
            this.label4.Text = "Phone";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(342, 278);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 13);
            this.label16.TabIndex = 322;
            this.label16.Text = "*";
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
            this.cmbCountry.Location = new System.Drawing.Point(188, 273);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(154, 24);
            this.cmbCountry.TabIndex = 318;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(129, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 320;
            this.label9.Text = "Country";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(100, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 319;
            this.label5.Text = "Postal Code";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostalCode.ForeColor = System.Drawing.Color.Black;
            this.txtPostalCode.Location = new System.Drawing.Point(188, 246);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(154, 23);
            this.txtPostalCode.TabIndex = 317;
            this.txtPostalCode.Click += new System.EventHandler(this.PostalCode_Click);
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
            this.FinishButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.FinishButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.FinishButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.FinishButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FinishButton.Location = new System.Drawing.Point(433, 559);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(120, 40);
            this.FinishButton.TabIndex = 62;
            this.FinishButton.Text = "Save";
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
            this.CancelButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.CancelButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.CancelButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(570, 559);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 63;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // btnAddressLookup
            // 
            this.btnAddressLookup.BackColor = System.Drawing.Color.Transparent;
            this.btnAddressLookup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddressLookup.BackgroundImage")));
            this.btnAddressLookup.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnAddressLookup.BgImageOnMouseDown")));
            this.btnAddressLookup.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnAddressLookup.BgImageOnMouseUp")));
            this.btnAddressLookup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddressLookup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddressLookup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddressLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddressLookup.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAddressLookup.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnAddressLookup.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnAddressLookup.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.btnAddressLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddressLookup.Location = new System.Drawing.Point(386, 246);
            this.btnAddressLookup.Name = "btnAddressLookup";
            this.btnAddressLookup.Size = new System.Drawing.Size(145, 40);
            this.btnAddressLookup.TabIndex = 326;
            this.btnAddressLookup.Text = "Address Lookup";
            this.btnAddressLookup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddressLookup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddressLookup.UseVisualStyleBackColor = false;
            this.btnAddressLookup.Click += new System.EventHandler(this.btnAddressLookup_Click);
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
            this.btnSearchByPhone.Location = new System.Drawing.Point(536, 81);
            this.btnSearchByPhone.Name = "btnSearchByPhone";
            this.btnSearchByPhone.Size = new System.Drawing.Size(35, 29);
            this.btnSearchByPhone.TabIndex = 328;
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
            this.btnFindCustomer.Location = new System.Drawing.Point(536, 48);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(35, 29);
            this.btnFindCustomer.TabIndex = 327;
            this.btnFindCustomer.UseVisualStyleBackColor = false;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboard1.ControlToInputText = null;
            this.keyboard1.Location = new System.Drawing.Point(25, 306);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(665, 247);
            this.keyboard1.TabIndex = 329;
            this.keyboard1.textBox = null;
            // 
            // CCustomerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.keyboard1);
            this.Controls.Add(this.btnSearchByPhone);
            this.Controls.Add(this.btnFindCustomer);
            this.Controls.Add(this.btnAddressLookup);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtHouseNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.txtStreetName);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBuildingName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFloorAptNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "CCustomerInfoForm";
            this.ScreenTitle = "Customer Information ";
            this.Text = "CCustomerInfoForm";
            this.Activated += new System.EventHandler(this.CCustomerInfoForm_Activated);
            this.Load += new System.EventHandler(this.CCustomerInfoForm_Load);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.FinishButton, 0);
            this.Controls.SetChildIndex(this.txtCustomerName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtFloorAptNumber, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtBuildingName, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtPhoneNumber, 0);
            this.Controls.SetChildIndex(this.txtStreetName, 0);
            this.Controls.SetChildIndex(this.txtTown, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtHouseNumber, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtPostalCode, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.btnAddressLookup, 0);
            this.Controls.SetChildIndex(this.btnFindCustomer, 0);
            this.Controls.SetChildIndex(this.btnSearchByPhone, 0);
            this.Controls.SetChildIndex(this.keyboard1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFloorAptNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHouseNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Button btnSearchByPhone;
        private System.Windows.Forms.Button btnFindCustomer;
        private RMSUI.keyboard keyboard1;
        private RMSUI.FunctionalButton btnAddressLookup;
        private RMSUI.FunctionalButton FinishButton;
        private RMSUI.FunctionalButton CancelButton;

    }
}