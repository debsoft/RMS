namespace RMSAdmin
{
    partial class RMSAdminMdiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RMSAdminMdiForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.proMnuParent = new System.Windows.Forms.ToolStripMenuItem();
            this.proMnuFoodType = new System.Windows.Forms.ToolStripMenuItem();
            this.proMnuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.proMnuFoodItems = new System.Windows.Forms.ToolStripMenuItem();
            this.proMnuSelectionItems = new System.Windows.Forms.ToolStripMenuItem();
            this.proMnuPLU = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuButtonColors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuReceiptStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuViewToolBox = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuItemProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tssubmnuitemParent = new System.Windows.Forms.ToolStripMenuItem();
            this.tssubmnuitemFoodType = new System.Windows.Forms.ToolStripMenuItem();
            this.tssubmnuitemCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tssubmnuitemFoodItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tssubmnuitemSelectionofItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuItemInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRptInventorySoldToday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRptInventorybyInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainSwitching = new System.Windows.Forms.ToolStripMenuItem();
            this.tssubmnuLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMnuItemManual = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsLblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblLoginTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlContext = new System.Windows.Forms.Panel();
            this.rmsAdminToolStrip = new System.Windows.Forms.ToolStrip();
            this.parentCatTsButton = new System.Windows.Forms.ToolStripButton();
            this.foodTypeTsButton = new System.Windows.Forms.ToolStripButton();
            this.categoryTsButton = new System.Windows.Forms.ToolStripButton();
            this.foodItemTsButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.usersTsButton = new System.Windows.Forms.ToolStripButton();
            this.buttoncolorTsButton = new System.Windows.Forms.ToolStripButton();
            this.receiptStyleTsButton = new System.Windows.Forms.ToolStripButton();
            this.pluTsButton = new System.Windows.Forms.ToolStripButton();
            this.userManualTsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRawMaterial = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.rmsAdminToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.tsMnuSettings,
            this.mnuView,
            this.mnuMainUsers,
            this.mnuReports,
            this.mnuMainSwitching,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.mnuMainSwitching;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1026, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proMnuParent,
            this.proMnuFoodType,
            this.proMnuCategory,
            this.proMnuFoodItems,
            this.proMnuSelectionItems,
            this.proMnuPLU,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(66, 20);
            this.fileMenu.Text = "&Products";
            // 
            // proMnuParent
            // 
            this.proMnuParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.proMnuParent.Image = ((System.Drawing.Image)(resources.GetObject("proMnuParent.Image")));
            this.proMnuParent.Name = "proMnuParent";
            this.proMnuParent.Size = new System.Drawing.Size(168, 22);
            this.proMnuParent.Text = "Parent Category";
            this.proMnuParent.Click += new System.EventHandler(this.proMnuParent_Click);
            // 
            // proMnuFoodType
            // 
            this.proMnuFoodType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.proMnuFoodType.Image = global::RMSAdmin.Properties.Resources.food_type;
            this.proMnuFoodType.Name = "proMnuFoodType";
            this.proMnuFoodType.Size = new System.Drawing.Size(168, 22);
            this.proMnuFoodType.Text = "Food Type";
            this.proMnuFoodType.Click += new System.EventHandler(this.proMnuFoodType_Click);
            // 
            // proMnuCategory
            // 
            this.proMnuCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.proMnuCategory.Image = global::RMSAdmin.Properties.Resources.categories;
            this.proMnuCategory.Name = "proMnuCategory";
            this.proMnuCategory.Size = new System.Drawing.Size(168, 22);
            this.proMnuCategory.Text = "Category";
            this.proMnuCategory.Click += new System.EventHandler(this.proMnuCategory_Click);
            // 
            // proMnuFoodItems
            // 
            this.proMnuFoodItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.proMnuFoodItems.Image = global::RMSAdmin.Properties.Resources.food_item;
            this.proMnuFoodItems.Name = "proMnuFoodItems";
            this.proMnuFoodItems.Size = new System.Drawing.Size(168, 22);
            this.proMnuFoodItems.Text = "Food Items";
            this.proMnuFoodItems.Click += new System.EventHandler(this.proMnuFoodItems_Click);
            // 
            // proMnuSelectionItems
            // 
            this.proMnuSelectionItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.proMnuSelectionItems.Image = global::RMSAdmin.Properties.Resources.selection_item;
            this.proMnuSelectionItems.Name = "proMnuSelectionItems";
            this.proMnuSelectionItems.Size = new System.Drawing.Size(168, 22);
            this.proMnuSelectionItems.Text = "Selection of Items";
            this.proMnuSelectionItems.Click += new System.EventHandler(this.proMnuSelectionItems_Click);
            // 
            // proMnuPLU
            // 
            this.proMnuPLU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.proMnuPLU.Image = ((System.Drawing.Image)(resources.GetObject("proMnuPLU.Image")));
            this.proMnuPLU.Name = "proMnuPLU";
            this.proMnuPLU.Size = new System.Drawing.Size(168, 22);
            this.proMnuPLU.Text = "Product PLU";
            this.proMnuPLU.Click += new System.EventHandler(this.proMnuPLU_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // tsMnuSettings
            // 
            this.tsMnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMnuButtonColors,
            this.tsMnuReceiptStyle});
            this.tsMnuSettings.Name = "tsMnuSettings";
            this.tsMnuSettings.Size = new System.Drawing.Size(61, 20);
            this.tsMnuSettings.Text = "&Settings";
            // 
            // tsMnuButtonColors
            // 
            this.tsMnuButtonColors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tsMnuButtonColors.Image = global::RMSAdmin.Properties.Resources.button_color2;
            this.tsMnuButtonColors.Name = "tsMnuButtonColors";
            this.tsMnuButtonColors.Size = new System.Drawing.Size(147, 22);
            this.tsMnuButtonColors.Text = "Button Colors";
            this.tsMnuButtonColors.Click += new System.EventHandler(this.tsMnuButtonColors_Click);
            // 
            // tsMnuReceiptStyle
            // 
            this.tsMnuReceiptStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tsMnuReceiptStyle.Image = global::RMSAdmin.Properties.Resources.receipt_style;
            this.tsMnuReceiptStyle.Name = "tsMnuReceiptStyle";
            this.tsMnuReceiptStyle.Size = new System.Drawing.Size(147, 22);
            this.tsMnuReceiptStyle.Text = "Receipt Style";
            this.tsMnuReceiptStyle.Click += new System.EventHandler(this.tsMnuReceiptStyle_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemClear,
            this.tsMnuViewToolBox});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            // 
            // tsMenuItemClear
            // 
            this.tsMenuItemClear.Name = "tsMenuItemClear";
            this.tsMenuItemClear.Size = new System.Drawing.Size(139, 22);
            this.tsMenuItemClear.Text = "Clear Screen";
            this.tsMenuItemClear.Click += new System.EventHandler(this.tsMenuItemClear_Click);
            // 
            // tsMnuViewToolBox
            // 
            this.tsMnuViewToolBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tsMnuViewToolBox.Checked = true;
            this.tsMnuViewToolBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsMnuViewToolBox.Name = "tsMnuViewToolBox";
            this.tsMnuViewToolBox.Size = new System.Drawing.Size(139, 22);
            this.tsMnuViewToolBox.Text = "Tool Bar";
            this.tsMnuViewToolBox.Click += new System.EventHandler(this.tsMnuViewToolBox_Click);
            // 
            // mnuMainUsers
            // 
            this.mnuMainUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMnuUsers});
            this.mnuMainUsers.Name = "mnuMainUsers";
            this.mnuMainUsers.Size = new System.Drawing.Size(47, 20);
            this.mnuMainUsers.Text = "&Users";
            this.mnuMainUsers.Click += new System.EventHandler(this.mnuMainUsers_Click);
            // 
            // tsMnuUsers
            // 
            this.tsMnuUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tsMnuUsers.Image = global::RMSAdmin.Properties.Resources.users;
            this.tsMnuUsers.Name = "tsMnuUsers";
            this.tsMnuUsers.Size = new System.Drawing.Size(148, 22);
            this.tsMnuUsers.Text = "Manage Users";
            this.tsMnuUsers.Click += new System.EventHandler(this.tsMnuUsers_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMnuItemProducts,
            this.tsMnuItemInventory});
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(59, 20);
            this.mnuReports.Text = "&Reports";
            // 
            // tsMnuItemProducts
            // 
            this.tsMnuItemProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tsMnuItemProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssubmnuitemParent,
            this.tssubmnuitemFoodType,
            this.tssubmnuitemCategory,
            this.tssubmnuitemFoodItem,
            this.tssubmnuitemSelectionofItem});
            this.tsMnuItemProducts.Name = "tsMnuItemProducts";
            this.tsMnuItemProducts.Size = new System.Drawing.Size(124, 22);
            this.tsMnuItemProducts.Text = "Products";
            // 
            // tssubmnuitemParent
            // 
            this.tssubmnuitemParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tssubmnuitemParent.Name = "tssubmnuitemParent";
            this.tssubmnuitemParent.Size = new System.Drawing.Size(163, 22);
            this.tssubmnuitemParent.Text = "Parent Category";
            this.tssubmnuitemParent.Click += new System.EventHandler(this.tssubmnuitemParent_Click);
            // 
            // tssubmnuitemFoodType
            // 
            this.tssubmnuitemFoodType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tssubmnuitemFoodType.Name = "tssubmnuitemFoodType";
            this.tssubmnuitemFoodType.Size = new System.Drawing.Size(163, 22);
            this.tssubmnuitemFoodType.Text = "Food Type";
            this.tssubmnuitemFoodType.Click += new System.EventHandler(this.tssubmnuitemFoodType_Click);
            // 
            // tssubmnuitemCategory
            // 
            this.tssubmnuitemCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tssubmnuitemCategory.Name = "tssubmnuitemCategory";
            this.tssubmnuitemCategory.Size = new System.Drawing.Size(163, 22);
            this.tssubmnuitemCategory.Text = "Category";
            this.tssubmnuitemCategory.Visible = false;
            this.tssubmnuitemCategory.Click += new System.EventHandler(this.tssubmnuitemCategory_Click);
            // 
            // tssubmnuitemFoodItem
            // 
            this.tssubmnuitemFoodItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tssubmnuitemFoodItem.Name = "tssubmnuitemFoodItem";
            this.tssubmnuitemFoodItem.Size = new System.Drawing.Size(163, 22);
            this.tssubmnuitemFoodItem.Text = "Food Item";
            this.tssubmnuitemFoodItem.Visible = false;
            // 
            // tssubmnuitemSelectionofItem
            // 
            this.tssubmnuitemSelectionofItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tssubmnuitemSelectionofItem.Name = "tssubmnuitemSelectionofItem";
            this.tssubmnuitemSelectionofItem.Size = new System.Drawing.Size(163, 22);
            this.tssubmnuitemSelectionofItem.Text = "Selection of Item";
            this.tssubmnuitemSelectionofItem.Visible = false;
            // 
            // tsMnuItemInventory
            // 
            this.tsMnuItemInventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRptInventorySoldToday,
            this.tsRptInventorybyInterval});
            this.tsMnuItemInventory.Name = "tsMnuItemInventory";
            this.tsMnuItemInventory.Size = new System.Drawing.Size(124, 22);
            this.tsMnuItemInventory.Text = "Inventory";
            // 
            // tsRptInventorySoldToday
            // 
            this.tsRptInventorySoldToday.Name = "tsRptInventorySoldToday";
            this.tsRptInventorySoldToday.Size = new System.Drawing.Size(157, 22);
            this.tsRptInventorySoldToday.Text = "Report Today";
            this.tsRptInventorySoldToday.Click += new System.EventHandler(this.tsRptInventorySoldToday_Click);
            // 
            // tsRptInventorybyInterval
            // 
            this.tsRptInventorybyInterval.Name = "tsRptInventorybyInterval";
            this.tsRptInventorybyInterval.Size = new System.Drawing.Size(157, 22);
            this.tsRptInventorybyInterval.Text = "Previous Report";
            this.tsRptInventorybyInterval.Click += new System.EventHandler(this.tsRptInventorybyInterval_Click);
            // 
            // mnuMainSwitching
            // 
            this.mnuMainSwitching.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssubmnuLogoff});
            this.mnuMainSwitching.Name = "mnuMainSwitching";
            this.mnuMainSwitching.Size = new System.Drawing.Size(54, 20);
            this.mnuMainSwitching.Text = "&Logoff";
            this.mnuMainSwitching.Click += new System.EventHandler(this.mnuMainSwitching_Click);
            // 
            // tssubmnuLogoff
            // 
            this.tssubmnuLogoff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tssubmnuLogoff.Image = global::RMSAdmin.Properties.Resources.logoff;
            this.tssubmnuLogoff.Name = "tssubmnuLogoff";
            this.tssubmnuLogoff.Size = new System.Drawing.Size(112, 22);
            this.tssubmnuLogoff.Text = "Log off";
            this.tssubmnuLogoff.Click += new System.EventHandler(this.tssubmnuLogoff_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMnuItemAbout,
            this.tsMnuItemManual});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // tsMnuItemAbout
            // 
            this.tsMnuItemAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tsMnuItemAbout.Image = global::RMSAdmin.Properties.Resources.about;
            this.tsMnuItemAbout.Name = "tsMnuItemAbout";
            this.tsMnuItemAbout.Size = new System.Drawing.Size(140, 22);
            this.tsMnuItemAbout.Text = "About";
            this.tsMnuItemAbout.Click += new System.EventHandler(this.tsMnuItemAbout_Click);
            // 
            // tsMnuItemManual
            // 
            this.tsMnuItemManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.tsMnuItemManual.Image = global::RMSAdmin.Properties.Resources.user_manual;
            this.tsMnuItemManual.Name = "tsMnuItemManual";
            this.tsMnuItemManual.Size = new System.Drawing.Size(140, 22);
            this.tsMnuItemManual.Text = "User Manual";
            this.tsMnuItemManual.Click += new System.EventHandler(this.tsMnuItemManual_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblCurrentUser,
            this.tsLblLoginTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 520);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1026, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // tsLblCurrentUser
            // 
            this.tsLblCurrentUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsLblCurrentUser.Name = "tsLblCurrentUser";
            this.tsLblCurrentUser.Size = new System.Drawing.Size(76, 17);
            this.tsLblCurrentUser.Text = "Current User:";
            // 
            // tsLblLoginTime
            // 
            this.tsLblLoginTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsLblLoginTime.Name = "tsLblLoginTime";
            this.tsLblLoginTime.Size = new System.Drawing.Size(67, 17);
            this.tsLblLoginTime.Text = "Login Time";
            // 
            // pnlContext
            // 
            this.pnlContext.BackColor = System.Drawing.Color.Black;
            this.pnlContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContext.Location = new System.Drawing.Point(0, 49);
            this.pnlContext.Name = "pnlContext";
            this.pnlContext.Size = new System.Drawing.Size(1026, 471);
            this.pnlContext.TabIndex = 5;
            // 
            // rmsAdminToolStrip
            // 
            this.rmsAdminToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(184)))), ((int)(((byte)(209)))));
            this.rmsAdminToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parentCatTsButton,
            this.foodTypeTsButton,
            this.categoryTsButton,
            this.foodItemTsButton,
            this.printPreviewToolStripButton,
            this.usersTsButton,
            this.toolStripButtonRawMaterial,
            this.buttoncolorTsButton,
            this.receiptStyleTsButton,
            this.pluTsButton,
            this.userManualTsButton});
            this.rmsAdminToolStrip.Location = new System.Drawing.Point(0, 24);
            this.rmsAdminToolStrip.Name = "rmsAdminToolStrip";
            this.rmsAdminToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.rmsAdminToolStrip.Size = new System.Drawing.Size(1026, 25);
            this.rmsAdminToolStrip.TabIndex = 7;
            this.rmsAdminToolStrip.Text = "ToolStrip";
            // 
            // parentCatTsButton
            // 
            this.parentCatTsButton.Image = ((System.Drawing.Image)(resources.GetObject("parentCatTsButton.Image")));
            this.parentCatTsButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.parentCatTsButton.Name = "parentCatTsButton";
            this.parentCatTsButton.Size = new System.Drawing.Size(112, 22);
            this.parentCatTsButton.Text = "Parent Category";
            this.parentCatTsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.parentCatTsButton.ToolTipText = "Parent Category which is called menu of the restaurent.";
            this.parentCatTsButton.Click += new System.EventHandler(this.parentCatTsButton_Click);
            // 
            // foodTypeTsButton
            // 
            this.foodTypeTsButton.Image = ((System.Drawing.Image)(resources.GetObject("foodTypeTsButton.Image")));
            this.foodTypeTsButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.foodTypeTsButton.Name = "foodTypeTsButton";
            this.foodTypeTsButton.Size = new System.Drawing.Size(83, 22);
            this.foodTypeTsButton.Text = "Food Type";
            this.foodTypeTsButton.ToolTipText = "Food Type of a certain menu ";
            this.foodTypeTsButton.Click += new System.EventHandler(this.foodTypeTsButton_Click);
            // 
            // categoryTsButton
            // 
            this.categoryTsButton.Image = ((System.Drawing.Image)(resources.GetObject("categoryTsButton.Image")));
            this.categoryTsButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.categoryTsButton.Name = "categoryTsButton";
            this.categoryTsButton.Size = new System.Drawing.Size(75, 22);
            this.categoryTsButton.Text = "Category";
            this.categoryTsButton.ToolTipText = "Food Category";
            this.categoryTsButton.Click += new System.EventHandler(this.categoryTsButton_Click);
            // 
            // foodItemTsButton
            // 
            this.foodItemTsButton.Image = ((System.Drawing.Image)(resources.GetObject("foodItemTsButton.Image")));
            this.foodItemTsButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.foodItemTsButton.Name = "foodItemTsButton";
            this.foodItemTsButton.Size = new System.Drawing.Size(81, 22);
            this.foodItemTsButton.Text = "Food Item";
            this.foodItemTsButton.ToolTipText = "Food Item";
            this.foodItemTsButton.Click += new System.EventHandler(this.foodItemTsButton_Click);
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(116, 22);
            this.printPreviewToolStripButton.Text = "Selection of Item";
            this.printPreviewToolStripButton.ToolTipText = "Selection of Item";
            this.printPreviewToolStripButton.Click += new System.EventHandler(this.printPreviewToolStripButton_Click);
            // 
            // usersTsButton
            // 
            this.usersTsButton.Image = ((System.Drawing.Image)(resources.GetObject("usersTsButton.Image")));
            this.usersTsButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.usersTsButton.Name = "usersTsButton";
            this.usersTsButton.Size = new System.Drawing.Size(55, 22);
            this.usersTsButton.Text = "Users";
            this.usersTsButton.ToolTipText = "Current Users List";
            this.usersTsButton.Click += new System.EventHandler(this.usersTsButton_Click);
            // 
            // buttoncolorTsButton
            // 
            this.buttoncolorTsButton.Image = global::RMSAdmin.Properties.Resources.button_color2;
            this.buttoncolorTsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttoncolorTsButton.Name = "buttoncolorTsButton";
            this.buttoncolorTsButton.Size = new System.Drawing.Size(95, 22);
            this.buttoncolorTsButton.Text = "Button Color";
            this.buttoncolorTsButton.ToolTipText = "Button Color helps the user to set the background color of the specific function";
            this.buttoncolorTsButton.Click += new System.EventHandler(this.buttoncolorTsButton_Click);
            // 
            // receiptStyleTsButton
            // 
            this.receiptStyleTsButton.Image = global::RMSAdmin.Properties.Resources.receipt_style;
            this.receiptStyleTsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.receiptStyleTsButton.Name = "receiptStyleTsButton";
            this.receiptStyleTsButton.Size = new System.Drawing.Size(94, 22);
            this.receiptStyleTsButton.Text = "Receipt Style";
            this.receiptStyleTsButton.ToolTipText = "Receipt Style";
            this.receiptStyleTsButton.Click += new System.EventHandler(this.receiptStyleTsButton_Click);
            // 
            // pluTsButton
            // 
            this.pluTsButton.Image = ((System.Drawing.Image)(resources.GetObject("pluTsButton.Image")));
            this.pluTsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pluTsButton.Name = "pluTsButton";
            this.pluTsButton.Size = new System.Drawing.Size(93, 22);
            this.pluTsButton.Text = "Prpduct PLU";
            this.pluTsButton.ToolTipText = "PLU of the product";
            this.pluTsButton.Click += new System.EventHandler(this.pluTsButton_Click);
            // 
            // userManualTsButton
            // 
            this.userManualTsButton.Image = global::RMSAdmin.Properties.Resources.user_manual;
            this.userManualTsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userManualTsButton.Name = "userManualTsButton";
            this.userManualTsButton.Size = new System.Drawing.Size(93, 22);
            this.userManualTsButton.Text = "User Manual";
            this.userManualTsButton.ToolTipText = "User Manual which helps the user how to run the application.";
            this.userManualTsButton.Click += new System.EventHandler(this.userManualTsButton_Click);
            // 
            // toolStripButtonRawMaterial
            // 
            this.toolStripButtonRawMaterial.Image = global::RMSAdmin.Properties.Resources.food_item;
            this.toolStripButtonRawMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButtonRawMaterial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRawMaterial.Name = "toolStripButtonRawMaterial";
            this.toolStripButtonRawMaterial.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonRawMaterial.Text = "Raw Material";
            this.toolStripButtonRawMaterial.ToolTipText = "Raw Material";
            this.toolStripButtonRawMaterial.Click += new System.EventHandler(this.toolStripButtonRawMaterial_Click);
            // 
            // RMSAdminMdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1026, 542);
            this.Controls.Add(this.pnlContext);
            this.Controls.Add(this.rmsAdminToolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "RMSAdminMdiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RMS Administration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RMSAdminMdiForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RMSAdminMdiForm_FormClosed);
            this.Load += new System.EventHandler(this.RMSAdminMdiForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.rmsAdminToolStrip.ResumeLayout(false);
            this.rmsAdminToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsLblCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem mnuMainUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuMainSwitching;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.Panel pnlContext;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proMnuParent;
        private System.Windows.Forms.ToolStripMenuItem proMnuFoodType;
        private System.Windows.Forms.ToolStripMenuItem proMnuCategory;
        private System.Windows.Forms.ToolStripMenuItem proMnuFoodItems;
        private System.Windows.Forms.ToolStripMenuItem proMnuSelectionItems;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStrip rmsAdminToolStrip;
        private System.Windows.Forms.ToolStripButton parentCatTsButton;
        private System.Windows.Forms.ToolStripButton foodTypeTsButton;
        private System.Windows.Forms.ToolStripButton categoryTsButton;
        private System.Windows.Forms.ToolStripButton foodItemTsButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripButton usersTsButton;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem tsMnuViewToolBox;
        private System.Windows.Forms.ToolStripMenuItem tsMnuSettings;
        private System.Windows.Forms.ToolStripMenuItem tsMnuButtonColors;
        private System.Windows.Forms.ToolStripMenuItem tsMnuReceiptStyle;
        private System.Windows.Forms.ToolStripMenuItem tsMnuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem tsMnuItemManual;
        private System.Windows.Forms.ToolStripMenuItem tsMnuUsers;
        private System.Windows.Forms.ToolStripButton buttoncolorTsButton;
        private System.Windows.Forms.ToolStripButton receiptStyleTsButton;
        private System.Windows.Forms.ToolStripMenuItem tsMnuItemProducts;
        private System.Windows.Forms.ToolStripMenuItem tssubmnuitemParent;
        private System.Windows.Forms.ToolStripMenuItem tssubmnuitemFoodType;
        private System.Windows.Forms.ToolStripMenuItem tssubmnuitemCategory;
        private System.Windows.Forms.ToolStripMenuItem tssubmnuitemFoodItem;
        private System.Windows.Forms.ToolStripMenuItem tssubmnuitemSelectionofItem;
        private System.Windows.Forms.ToolStripMenuItem tssubmnuLogoff;
        private System.Windows.Forms.ToolStripButton userManualTsButton;
        private System.Windows.Forms.ToolStripMenuItem tsMnuItemInventory;
        private System.Windows.Forms.ToolStripMenuItem tsRptInventorySoldToday;
        private System.Windows.Forms.ToolStripMenuItem tsRptInventorybyInterval;
        private System.Windows.Forms.ToolStripButton pluTsButton;
        private System.Windows.Forms.ToolStripMenuItem proMnuPLU;
        private System.Windows.Forms.ToolStripStatusLabel tsLblLoginTime;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemClear;
        private System.Windows.Forms.ToolStripButton toolStripButtonRawMaterial;
    }
}



