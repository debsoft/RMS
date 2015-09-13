
namespace RMS.Main
{
    partial class CMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMainForm));
            this.SysMngmntButton = new RMSUI.FunctionalButton();
            this.TableInfoButton = new RMSUI.FunctionalButton();
            this.NameTableButton = new RMSUI.FunctionalButton();
            this.ChangeDetailsButton = new RMSUI.FunctionalButton();
            this.TWButton = new RMSUI.FunctionalButton();
            this.BarServiceButton = new RMSUI.FunctionalButton();
            this.NewTableButton = new RMSUI.FunctionalButton();
            this.LogOffButton = new RMSUI.FunctionalButton();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsLblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.UserStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpenOrdersLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TerminalIDLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCallerIdStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.tmrCallerInfo = new System.Windows.Forms.Timer(this.components);
            this.tlTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnCallRefresh = new RMSUI.FunctionalButton();
            this.label14 = new System.Windows.Forms.Label();
            this.TotalPageLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CurrentPageLabel = new System.Windows.Forms.Label();
            this.TablePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCallerID = new System.Windows.Forms.Panel();
            this.picBoxPhone = new RMSUI.FunctionalButton();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFirstAddress = new System.Windows.Forms.TextBox();
            this.RefreshButton = new RMSUI.FunctionalButton();
            this.PreviousButton = new RMSUI.FunctionalButton();
            this.NextButton = new RMSUI.FunctionalButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshlobbyButton = new RMSUI.FunctionalButton();
            this.MainStatusStrip.SuspendLayout();
            this.panelCallerID.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // SysMngmntButton
            // 
            this.SysMngmntButton.BackColor = System.Drawing.Color.Transparent;
            this.SysMngmntButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SysMngmntButton.BackgroundImage")));
            this.SysMngmntButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("SysMngmntButton.BgImageOnMouseDown")));
            this.SysMngmntButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("SysMngmntButton.BgImageOnMouseUp")));
            this.SysMngmntButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SysMngmntButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SysMngmntButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SysMngmntButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SysMngmntButton.Font = new System.Drawing.Font("Arial", 10F);
            this.SysMngmntButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.SysMngmntButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.SysMngmntButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Control;
            this.SysMngmntButton.Image = ((System.Drawing.Image)(resources.GetObject("SysMngmntButton.Image")));
            this.SysMngmntButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SysMngmntButton.Location = new System.Drawing.Point(991, 533);
            this.SysMngmntButton.Name = "SysMngmntButton";
            this.SysMngmntButton.Size = new System.Drawing.Size(145, 90);
            this.SysMngmntButton.TabIndex = 0;
            this.SysMngmntButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SysMngmntButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SysMngmntButton.UseVisualStyleBackColor = false;
            this.SysMngmntButton.Click += new System.EventHandler(this.SysMngmntButton_Click);
            // 
            // TableInfoButton
            // 
            this.TableInfoButton.BackColor = System.Drawing.Color.Transparent;
            this.TableInfoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TableInfoButton.BackgroundImage")));
            this.TableInfoButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("TableInfoButton.BgImageOnMouseDown")));
            this.TableInfoButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("TableInfoButton.BgImageOnMouseUp")));
            this.TableInfoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.TableInfoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TableInfoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TableInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TableInfoButton.Font = new System.Drawing.Font("Arial", 10F);
            this.TableInfoButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.TableInfoButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.TableInfoButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.TableInfoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TableInfoButton.Location = new System.Drawing.Point(991, 437);
            this.TableInfoButton.Name = "TableInfoButton";
            this.TableInfoButton.Size = new System.Drawing.Size(145, 90);
            this.TableInfoButton.TabIndex = 1;
            this.TableInfoButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TableInfoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TableInfoButton.UseVisualStyleBackColor = false;
            this.TableInfoButton.Click += new System.EventHandler(this.TabInfoButton_Click);
            // 
            // NameTableButton
            // 
            this.NameTableButton.BackColor = System.Drawing.Color.Transparent;
            this.NameTableButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NameTableButton.BackgroundImage")));
            this.NameTableButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("NameTableButton.BgImageOnMouseDown")));
            this.NameTableButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("NameTableButton.BgImageOnMouseUp")));
            this.NameTableButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NameTableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NameTableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NameTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NameTableButton.Font = new System.Drawing.Font("Arial", 10F);
            this.NameTableButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.NameTableButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.NameTableButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.NameTableButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NameTableButton.Location = new System.Drawing.Point(991, 245);
            this.NameTableButton.Name = "NameTableButton";
            this.NameTableButton.Size = new System.Drawing.Size(145, 90);
            this.NameTableButton.TabIndex = 2;
            this.NameTableButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NameTableButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NameTableButton.UseVisualStyleBackColor = false;
            this.NameTableButton.Click += new System.EventHandler(this.NameTableButton_Click);
            // 
            // ChangeDetailsButton
            // 
            this.ChangeDetailsButton.BackColor = System.Drawing.Color.Transparent;
            this.ChangeDetailsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChangeDetailsButton.BackgroundImage")));
            this.ChangeDetailsButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("ChangeDetailsButton.BgImageOnMouseDown")));
            this.ChangeDetailsButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("ChangeDetailsButton.BgImageOnMouseUp")));
            this.ChangeDetailsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ChangeDetailsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ChangeDetailsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ChangeDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeDetailsButton.Font = new System.Drawing.Font("Arial", 10F);
            this.ChangeDetailsButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.ChangeDetailsButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.ChangeDetailsButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.ChangeDetailsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeDetailsButton.Location = new System.Drawing.Point(991, 341);
            this.ChangeDetailsButton.Name = "ChangeDetailsButton";
            this.ChangeDetailsButton.Size = new System.Drawing.Size(145, 90);
            this.ChangeDetailsButton.TabIndex = 3;
            this.ChangeDetailsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeDetailsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeDetailsButton.UseVisualStyleBackColor = false;
            this.ChangeDetailsButton.Click += new System.EventHandler(this.ChangeDetailsButton_Click);
            // 
            // TWButton
            // 
            this.TWButton.BackColor = System.Drawing.Color.Transparent;
            this.TWButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TWButton.BackgroundImage")));
            this.TWButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("TWButton.BgImageOnMouseDown")));
            this.TWButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("TWButton.BgImageOnMouseUp")));
            this.TWButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.TWButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TWButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TWButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TWButton.Font = new System.Drawing.Font("Arial", 10F);
            this.TWButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.TWButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.TWButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.TWButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TWButton.Location = new System.Drawing.Point(991, 149);
            this.TWButton.Name = "TWButton";
            this.TWButton.Size = new System.Drawing.Size(145, 90);
            this.TWButton.TabIndex = 8;
            this.TWButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TWButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TWButton.UseVisualStyleBackColor = false;
            this.TWButton.Click += new System.EventHandler(this.TWButton_Click);
            // 
            // BarServiceButton
            // 
            this.BarServiceButton.BackColor = System.Drawing.Color.Transparent;
            this.BarServiceButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BarServiceButton.BackgroundImage")));
            this.BarServiceButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("BarServiceButton.BgImageOnMouseDown")));
            this.BarServiceButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("BarServiceButton.BgImageOnMouseUp")));
            this.BarServiceButton.Enabled = false;
            this.BarServiceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BarServiceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BarServiceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BarServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BarServiceButton.Font = new System.Drawing.Font("Arial", 10F);
            this.BarServiceButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.BarServiceButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.BarServiceButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.BarServiceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarServiceButton.Location = new System.Drawing.Point(825, 740);
            this.BarServiceButton.Name = "BarServiceButton";
            this.BarServiceButton.Size = new System.Drawing.Size(145, 40);
            this.BarServiceButton.TabIndex = 9;
            this.BarServiceButton.Text = "Bar Service";
            this.BarServiceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BarServiceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BarServiceButton.UseVisualStyleBackColor = false;
            this.BarServiceButton.Visible = false;
            this.BarServiceButton.Click += new System.EventHandler(this.BarServiceButton_Click);
            // 
            // NewTableButton
            // 
            this.NewTableButton.BackColor = System.Drawing.Color.Transparent;
            this.NewTableButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NewTableButton.BackgroundImage")));
            this.NewTableButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("NewTableButton.BgImageOnMouseDown")));
            this.NewTableButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("NewTableButton.BgImageOnMouseUp")));
            this.NewTableButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NewTableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NewTableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NewTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewTableButton.Font = new System.Drawing.Font("Arial", 10F);
            this.NewTableButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.NewTableButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.NewTableButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Add;
            this.NewTableButton.Image = ((System.Drawing.Image)(resources.GetObject("NewTableButton.Image")));
            this.NewTableButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewTableButton.Location = new System.Drawing.Point(991, 53);
            this.NewTableButton.Name = "NewTableButton";
            this.NewTableButton.Size = new System.Drawing.Size(145, 90);
            this.NewTableButton.TabIndex = 10;
            this.NewTableButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewTableButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NewTableButton.UseVisualStyleBackColor = false;
            this.NewTableButton.Click += new System.EventHandler(this.NewTableButton_Click);
            // 
            // LogOffButton
            // 
            this.LogOffButton.BackColor = System.Drawing.Color.Transparent;
            this.LogOffButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LogOffButton.BackgroundImage")));
            this.LogOffButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("LogOffButton.BgImageOnMouseDown")));
            this.LogOffButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("LogOffButton.BgImageOnMouseUp")));
            this.LogOffButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LogOffButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LogOffButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LogOffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOffButton.Font = new System.Drawing.Font("Arial", 10F);
            this.LogOffButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.LogOffButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.LogOffButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.LogOffButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogOffButton.Location = new System.Drawing.Point(991, 629);
            this.LogOffButton.Name = "LogOffButton";
            this.LogOffButton.Size = new System.Drawing.Size(145, 90);
            this.LogOffButton.TabIndex = 11;
            this.LogOffButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LogOffButton.UseVisualStyleBackColor = false;
            this.LogOffButton.Click += new System.EventHandler(this.LogOffButton_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblCurrentUser});
            this.MainStatusStrip.Location = new System.Drawing.Point(3, 941);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(1294, 24);
            this.MainStatusStrip.TabIndex = 9;
            // 
            // tsLblCurrentUser
            // 
            this.tsLblCurrentUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsLblCurrentUser.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsLblCurrentUser.Name = "tsLblCurrentUser";
            this.tsLblCurrentUser.Size = new System.Drawing.Size(77, 19);
            this.tsLblCurrentUser.Text = "Current User";
            // 
            // UserStatusLabel
            // 
            this.UserStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.UserStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.UserStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UserStatusLabel.Name = "UserStatusLabel";
            this.UserStatusLabel.Size = new System.Drawing.Size(138, 17);
            this.UserStatusLabel.Text = "Logged in as Administrator";
            // 
            // OpenOrdersLabel
            // 
            this.OpenOrdersLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.OpenOrdersLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.OpenOrdersLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenOrdersLabel.Name = "OpenOrdersLabel";
            this.OpenOrdersLabel.Size = new System.Drawing.Size(126, 17);
            this.OpenOrdersLabel.Text = "Number of Open Orders";
            // 
            // TerminalIDLabel
            // 
            this.TerminalIDLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TerminalIDLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.TerminalIDLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TerminalIDLabel.Name = "TerminalIDLabel";
            this.TerminalIDLabel.Size = new System.Drawing.Size(65, 17);
            this.TerminalIDLabel.Text = "Terminal ID";
            // 
            // tsCallerIdStatus
            // 
            this.tsCallerIdStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsCallerIdStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsCallerIdStatus.Name = "tsCallerIdStatus";
            this.tsCallerIdStatus.Size = new System.Drawing.Size(52, 17);
            this.tsCallerIdStatus.Text = "Caller ID";
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 10000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // tmrCallerInfo
            // 
            this.tmrCallerInfo.Tick += new System.EventHandler(this.tmrCallerInfo_Tick);
            // 
            // tlTip
            // 
            this.tlTip.IsBalloon = true;
            this.tlTip.ShowAlways = true;
            // 
            // btnCallRefresh
            // 
            this.btnCallRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnCallRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCallRefresh.BackgroundImage")));
            this.btnCallRefresh.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnCallRefresh.BgImageOnMouseDown")));
            this.btnCallRefresh.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnCallRefresh.BgImageOnMouseUp")));
            this.btnCallRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCallRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCallRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCallRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallRefresh.Font = new System.Drawing.Font("Arial", 10F);
            this.btnCallRefresh.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnCallRefresh.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnCallRefresh.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.btnCallRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCallRefresh.Location = new System.Drawing.Point(286, 42);
            this.btnCallRefresh.Name = "btnCallRefresh";
            this.btnCallRefresh.Size = new System.Drawing.Size(55, 32);
            this.btnCallRefresh.TabIndex = 7;
            this.btnCallRefresh.Text = "Clear";
            this.btnCallRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCallRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tlTip.SetToolTip(this.btnCallRefresh, "Refresh");
            this.btnCallRefresh.UseVisualStyleBackColor = false;
            this.btnCallRefresh.Click += new System.EventHandler(this.btnCallRefresh_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(197, 504);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "of";
            // 
            // TotalPageLabel
            // 
            this.TotalPageLabel.AutoSize = true;
            this.TotalPageLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalPageLabel.ForeColor = System.Drawing.Color.Black;
            this.TotalPageLabel.Location = new System.Drawing.Point(221, 504);
            this.TotalPageLabel.Name = "TotalPageLabel";
            this.TotalPageLabel.Size = new System.Drawing.Size(13, 13);
            this.TotalPageLabel.TabIndex = 2;
            this.TotalPageLabel.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(77, 504);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Open Order - Page";
            // 
            // CurrentPageLabel
            // 
            this.CurrentPageLabel.AutoSize = true;
            this.CurrentPageLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentPageLabel.ForeColor = System.Drawing.Color.Black;
            this.CurrentPageLabel.Location = new System.Drawing.Point(179, 504);
            this.CurrentPageLabel.Name = "CurrentPageLabel";
            this.CurrentPageLabel.Size = new System.Drawing.Size(13, 13);
            this.CurrentPageLabel.TabIndex = 0;
            this.CurrentPageLabel.Text = "1";
            // 
            // TablePanel
            // 
            this.TablePanel.BackColor = System.Drawing.Color.Teal;
            this.TablePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TablePanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TablePanel.Location = new System.Drawing.Point(7, 0);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Padding = new System.Windows.Forms.Padding(5);
            this.TablePanel.Size = new System.Drawing.Size(972, 484);
            this.TablePanel.TabIndex = 14;
            this.TablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TablePanel_Paint);
            // 
            // panelCallerID
            // 
            this.panelCallerID.BackColor = System.Drawing.Color.White;
            this.panelCallerID.Controls.Add(this.picBoxPhone);
            this.panelCallerID.Controls.Add(this.lblPhoneNumber);
            this.panelCallerID.Controls.Add(this.txtCustomerName);
            this.panelCallerID.Controls.Add(this.btnCallRefresh);
            this.panelCallerID.Controls.Add(this.label18);
            this.panelCallerID.Controls.Add(this.label16);
            this.panelCallerID.Controls.Add(this.txtFirstAddress);
            this.panelCallerID.Location = new System.Drawing.Point(479, 762);
            this.panelCallerID.Name = "panelCallerID";
            this.panelCallerID.Size = new System.Drawing.Size(301, 99);
            this.panelCallerID.TabIndex = 10;
            this.panelCallerID.Visible = false;
            // 
            // picBoxPhone
            // 
            this.picBoxPhone.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picBoxPhone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxPhone.BackgroundImage")));
            this.picBoxPhone.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("picBoxPhone.BgImageOnMouseDown")));
            this.picBoxPhone.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("picBoxPhone.BgImageOnMouseUp")));
            this.picBoxPhone.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.picBoxPhone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.picBoxPhone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.picBoxPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.picBoxPhone.Font = new System.Drawing.Font("Arial", 10F);
            this.picBoxPhone.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.picBoxPhone.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.picBoxPhone.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.picBoxPhone.Image = global::RMS.Properties.Resources.ring_stop;
            this.picBoxPhone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.picBoxPhone.Location = new System.Drawing.Point(308, 5);
            this.picBoxPhone.Name = "picBoxPhone";
            this.picBoxPhone.Size = new System.Drawing.Size(32, 32);
            this.picBoxPhone.TabIndex = 12;
            this.picBoxPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.picBoxPhone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.picBoxPhone.UseVisualStyleBackColor = false;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblPhoneNumber.Location = new System.Drawing.Point(15, 59);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(119, 15);
            this.lblPhoneNumber.TabIndex = 10;
            this.lblPhoneNumber.Text = "45445645646543";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AutoSize = true;
            this.txtCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtCustomerName.Location = new System.Drawing.Point(15, 19);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(121, 17);
            this.txtCustomerName.TabIndex = 11;
            this.txtCustomerName.Text = "There is no call";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(5, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Customer Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(4, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Phone Number";
            // 
            // txtFirstAddress
            // 
            this.txtFirstAddress.BackColor = System.Drawing.Color.White;
            this.txtFirstAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstAddress.Enabled = false;
            this.txtFirstAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFirstAddress.Location = new System.Drawing.Point(7, 78);
            this.txtFirstAddress.Multiline = true;
            this.txtFirstAddress.Name = "txtFirstAddress";
            this.txtFirstAddress.Size = new System.Drawing.Size(334, 42);
            this.txtFirstAddress.TabIndex = 2;
            this.txtFirstAddress.Text = "There is no call";
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.Transparent;
            this.RefreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RefreshButton.BackgroundImage")));
            this.RefreshButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("RefreshButton.BgImageOnMouseDown")));
            this.RefreshButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("RefreshButton.BgImageOnMouseUp")));
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.RefreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Arial", 10F);
            this.RefreshButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.RefreshButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.RefreshButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Refresh;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.Location = new System.Drawing.Point(895, 490);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(35, 30);
            this.RefreshButton.TabIndex = 7;
            this.RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.BackColor = System.Drawing.Color.Transparent;
            this.PreviousButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PreviousButton.BackgroundImage")));
            this.PreviousButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("PreviousButton.BgImageOnMouseDown")));
            this.PreviousButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("PreviousButton.BgImageOnMouseUp")));
            this.PreviousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousButton.Enabled = false;
            this.PreviousButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PreviousButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PreviousButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousButton.Font = new System.Drawing.Font("Arial", 10F);
            this.PreviousButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.PreviousButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.PreviousButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Previous;
            this.PreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousButton.Image")));
            this.PreviousButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PreviousButton.Location = new System.Drawing.Point(853, 490);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(35, 30);
            this.PreviousButton.TabIndex = 11;
            this.PreviousButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PreviousButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PreviousButton.UseVisualStyleBackColor = false;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.Transparent;
            this.NextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NextButton.BackgroundImage")));
            this.NextButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("NextButton.BgImageOnMouseDown")));
            this.NextButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("NextButton.BgImageOnMouseUp")));
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.Enabled = false;
            this.NextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Arial", 10F);
            this.NextButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.NextButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.NextButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Next;
            this.NextButton.Image = ((System.Drawing.Image)(resources.GetObject("NextButton.Image")));
            this.NextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NextButton.Location = new System.Drawing.Point(937, 490);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(35, 30);
            this.NextButton.TabIndex = 5;
            this.NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Location = new System.Drawing.Point(11, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(68, 35);
            this.panel2.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(4, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 13;
            this.label21.Text = "Information";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(3, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 17);
            this.label15.TabIndex = 13;
            this.label15.Text = "Caller\'s";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(140, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "1";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BackgroundImage = global::RMS.Properties.Resources.lobby_window_bg;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Controls.Add(this.RefreshButton);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.TablePanel);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Controls.Add(this.TotalPageLabel);
            this.panel9.Controls.Add(this.CurrentPageLabel);
            this.panel9.Controls.Add(this.PreviousButton);
            this.panel9.Controls.Add(this.label14);
            this.panel9.Controls.Add(this.NextButton);
            this.panel9.Location = new System.Drawing.Point(6, 53);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(984, 532);
            this.panel9.TabIndex = 15;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(11, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Lobby";
            // 
            // refreshlobbyButton
            // 
            this.refreshlobbyButton.BackColor = System.Drawing.Color.Transparent;
            this.refreshlobbyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshlobbyButton.BackgroundImage")));
            this.refreshlobbyButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("refreshlobbyButton.BgImageOnMouseDown")));
            this.refreshlobbyButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("refreshlobbyButton.BgImageOnMouseUp")));
            this.refreshlobbyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.refreshlobbyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.refreshlobbyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.refreshlobbyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshlobbyButton.Font = new System.Drawing.Font("Arial", 10F);
            this.refreshlobbyButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.refreshlobbyButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.refreshlobbyButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.refreshlobbyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshlobbyButton.Location = new System.Drawing.Point(833, 804);
            this.refreshlobbyButton.Name = "refreshlobbyButton";
            this.refreshlobbyButton.Size = new System.Drawing.Size(145, 90);
            this.refreshlobbyButton.TabIndex = 16;
            this.refreshlobbyButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshlobbyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshlobbyButton.UseVisualStyleBackColor = false;
            this.refreshlobbyButton.Visible = false;
            this.refreshlobbyButton.Click += new System.EventHandler(this.refreshlobbyButton_Click);
            // 
            // CMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1300, 968);
            this.Controls.Add(this.refreshlobbyButton);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.LogOffButton);
            this.Controls.Add(this.NewTableButton);
            this.Controls.Add(this.BarServiceButton);
            this.Controls.Add(this.TWButton);
            this.Controls.Add(this.ChangeDetailsButton);
            this.Controls.Add(this.NameTableButton);
            this.Controls.Add(this.TableInfoButton);
            this.Controls.Add(this.SysMngmntButton);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.panelCallerID);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "CMainForm";
            this.Activated += new System.EventHandler(this.CMainForm_Activated);
            this.Deactivate += new System.EventHandler(this.CMainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMainForm_FormClosing);
            this.Load += new System.EventHandler(this.CMainForm_Load);
            this.Controls.SetChildIndex(this.panelCallerID, 0);
            this.Controls.SetChildIndex(this.MainStatusStrip, 0);
            this.Controls.SetChildIndex(this.SysMngmntButton, 0);
            this.Controls.SetChildIndex(this.TableInfoButton, 0);
            this.Controls.SetChildIndex(this.NameTableButton, 0);
            this.Controls.SetChildIndex(this.ChangeDetailsButton, 0);
            this.Controls.SetChildIndex(this.TWButton, 0);
            this.Controls.SetChildIndex(this.BarServiceButton, 0);
            this.Controls.SetChildIndex(this.NewTableButton, 0);
            this.Controls.SetChildIndex(this.LogOffButton, 0);
            this.Controls.SetChildIndex(this.panel9, 0);
            this.Controls.SetChildIndex(this.refreshlobbyButton, 0);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.panelCallerID.ResumeLayout(false);
            this.panelCallerID.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel UserStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel OpenOrdersLabel;
        private System.Windows.Forms.ToolStripStatusLabel TerminalIDLabel;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ToolStripStatusLabel tsCallerIdStatus;
        private System.Windows.Forms.Panel panelCallerID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFirstAddress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Timer tmrCallerInfo;
        private System.Windows.Forms.ToolTip tlTip;
        private System.Windows.Forms.Label txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label TotalPageLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label CurrentPageLabel;
        private System.Windows.Forms.FlowLayoutPanel TablePanel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ToolStripStatusLabel tsLblCurrentUser;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private RMSUI.FunctionalButton SysMngmntButton;
        private RMSUI.FunctionalButton TableInfoButton;
        private RMSUI.FunctionalButton NameTableButton;
        private RMSUI.FunctionalButton ChangeDetailsButton;
        private RMSUI.FunctionalButton TWButton;
        private RMSUI.FunctionalButton BarServiceButton;
        private RMSUI.FunctionalButton NewTableButton;
        private RMSUI.FunctionalButton LogOffButton;
        private RMSUI.FunctionalButton NextButton;
        private RMSUI.FunctionalButton RefreshButton;
        private RMSUI.FunctionalButton btnCallRefresh;
        private RMSUI.FunctionalButton picBoxPhone;
        private RMSUI.FunctionalButton PreviousButton;
        private RMSUI.FunctionalButton refreshlobbyButton;
    }
}

