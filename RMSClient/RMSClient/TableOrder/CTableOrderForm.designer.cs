namespace RMS.TableOrder
{
    partial class CTableOrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTableOrderForm));
            this.label1 = new System.Windows.Forms.Label();
            this.g_ItemSelectionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.g_FoodItemPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.g_FoodDataGridView = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cat_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cat_rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_details_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foodselect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.complementoryfood = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.g_BeveragePanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.g_BeverageDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nonfoodselect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.complementorynonfood = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMembershipDiscountValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.g_SubtotalLabel = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.lbvat = new System.Windows.Forms.Label();
            this.g_DiscountLabel = new System.Windows.Forms.Label();
            this.g_serviceCharge = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lbltips = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.g_AmountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.totalItemWiseDiscountlabel = new System.Windows.Forms.Label();
            this.TableOrderStatusStrip = new System.Windows.Forms.StatusStrip();
            this.UserStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TableStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GuestStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TableValueStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BillNoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnOrderLog = new RMSUI.FunctionalButton();
            this.g_SeatButton = new RMSUI.FunctionalButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSetOrderWaiter = new RMSUI.FunctionalButton();
            this.g_ItemDescriptionButton = new RMSUI.FunctionalButton();
            this.g_PrintGuestBillButton = new RMSUI.FunctionalButton();
            this.g_SpecialButton = new RMSUI.FunctionalButton();
            this.g_PromotionsButton = new RMSUI.FunctionalButton();
            this.btnKitchenText = new RMSUI.FunctionalButton();
            this.g_ServiceChargeButton = new RMSUI.FunctionalButton();
            this.btnPLU = new RMSUI.FunctionalButton();
            this.g_ConvertButton = new RMSUI.FunctionalButton();
            this.btnEditOrder = new RMSUI.FunctionalButton();
            this.g_QuantityButton = new RMSUI.FunctionalButton();
            this.g_PayCloseButton = new RMSUI.FunctionalButton();
            this.g_ExitButton = new RMSUI.FunctionalButton();
            this.g_MiscButton = new RMSUI.FunctionalButton();
            this.g_SendButton = new RMSUI.FunctionalButton();
            this.g_RemoveButton = new RMSUI.FunctionalButton();
            this.g_Category3NextButton = new RMSUI.FunctionalButton();
            this.g_Category3PreviousButton = new RMSUI.FunctionalButton();
            this.g_NextButton = new RMSUI.FunctionalButton();
            this.g_PreviousButton = new RMSUI.FunctionalButton();
            this.g_Category2Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtBoxSearchItem = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.foodMenuPanal = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrevParent = new RMSUI.FunctionalButton();
            this.btnNextParent = new RMSUI.FunctionalButton();
            this.delivaryfromkitchneButton = new RMSUI.FunctionalButton();
            this.membershipfunctionalButton = new RMSUI.FunctionalButton();
            this.complementoryButton = new RMSUI.FunctionalButton();
            this.itemComplementoryButton = new RMSUI.FunctionalButton();
            this.vatComplementoryButton = new RMSUI.FunctionalButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.functionalButton1 = new RMSUI.FunctionalButton();
            this.g_FoodItemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_FoodDataGridView)).BeginInit();
            this.g_BeveragePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_BeverageDataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TableOrderStatusStrip.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // g_ItemSelectionFlowLayoutPanel
            // 
            this.g_ItemSelectionFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.g_ItemSelectionFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.g_ItemSelectionFlowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_ItemSelectionFlowLayoutPanel.ForeColor = System.Drawing.Color.Black;
            this.g_ItemSelectionFlowLayoutPanel.Location = new System.Drawing.Point(3, 54);
            this.g_ItemSelectionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.g_ItemSelectionFlowLayoutPanel.Name = "g_ItemSelectionFlowLayoutPanel";
            this.g_ItemSelectionFlowLayoutPanel.Size = new System.Drawing.Size(262, 396);
            this.g_ItemSelectionFlowLayoutPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ItemSelection (Menu)";
            // 
            // g_FoodItemPanel
            // 
            this.g_FoodItemPanel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.g_FoodItemPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.g_FoodItemPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.g_FoodItemPanel.Controls.Add(this.label4);
            this.g_FoodItemPanel.Controls.Add(this.g_FoodDataGridView);
            this.g_FoodItemPanel.Location = new System.Drawing.Point(6, 54);
            this.g_FoodItemPanel.Name = "g_FoodItemPanel";
            this.g_FoodItemPanel.Padding = new System.Windows.Forms.Padding(3);
            this.g_FoodItemPanel.Size = new System.Drawing.Size(459, 201);
            this.g_FoodItemPanel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Food Items Ordered";
            // 
            // g_FoodDataGridView
            // 
            this.g_FoodDataGridView.AllowUserToAddRows = false;
            this.g_FoodDataGridView.AllowUserToDeleteRows = false;
            this.g_FoodDataGridView.AllowUserToResizeRows = false;
            this.g_FoodDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.g_FoodDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.g_FoodDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_FoodDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.g_FoodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_FoodDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Qty,
            this.vatTotal,
            this.Price,
            this.Cat_id,
            this.Cat_level,
            this.Cat_rank,
            this.Order_details_id,
            this.Column1,
            this.unitPrice,
            this.foodselect,
            this.complementoryfood});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_FoodDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.g_FoodDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.g_FoodDataGridView.GridColor = System.Drawing.Color.Maroon;
            this.g_FoodDataGridView.Location = new System.Drawing.Point(3, 18);
            this.g_FoodDataGridView.MultiSelect = false;
            this.g_FoodDataGridView.Name = "g_FoodDataGridView";
            this.g_FoodDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.g_FoodDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.g_FoodDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.g_FoodDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.g_FoodDataGridView.RowTemplate.Height = 15;
            this.g_FoodDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.g_FoodDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_FoodDataGridView.ShowEditingIcon = false;
            this.g_FoodDataGridView.Size = new System.Drawing.Size(451, 178);
            this.g_FoodDataGridView.TabIndex = 0;
            this.g_FoodDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_FoodDataGridView_CellContentClick);
            this.g_FoodDataGridView.Click += new System.EventHandler(this.g_FoodDataGridView_Click);
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item.FillWeight = 200F;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Qty.Width = 45;
            // 
            // vatTotal
            // 
            this.vatTotal.HeaderText = "Vat";
            this.vatTotal.Name = "vatTotal";
            this.vatTotal.Width = 45;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 50;
            // 
            // Cat_id
            // 
            this.Cat_id.HeaderText = "Cat_id";
            this.Cat_id.Name = "Cat_id";
            this.Cat_id.Visible = false;
            // 
            // Cat_level
            // 
            this.Cat_level.HeaderText = "Cat_level";
            this.Cat_level.Name = "Cat_level";
            this.Cat_level.Visible = false;
            // 
            // Cat_rank
            // 
            dataGridViewCellStyle2.NullValue = "9999999999999999999";
            this.Cat_rank.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cat_rank.HeaderText = "Cat_rank";
            this.Cat_rank.Name = "Cat_rank";
            this.Cat_rank.Visible = false;
            // 
            // Order_details_id
            // 
            this.Order_details_id.HeaderText = "Order_details_id";
            this.Order_details_id.Name = "Order_details_id";
            this.Order_details_id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Print Send";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "unitPrice";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.Visible = false;
            // 
            // foodselect
            // 
            this.foodselect.HeaderText = "Select";
            this.foodselect.Name = "foodselect";
            this.foodselect.Visible = false;
            this.foodselect.Width = 30;
            // 
            // complementoryfood
            // 
            this.complementoryfood.HeaderText = "Com";
            this.complementoryfood.Name = "complementoryfood";
            this.complementoryfood.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.complementoryfood.Width = 50;
            // 
            // g_BeveragePanel
            // 
            this.g_BeveragePanel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.g_BeveragePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.g_BeveragePanel.Controls.Add(this.label6);
            this.g_BeveragePanel.Controls.Add(this.g_BeverageDataGridView);
            this.g_BeveragePanel.Location = new System.Drawing.Point(6, 260);
            this.g_BeveragePanel.Name = "g_BeveragePanel";
            this.g_BeveragePanel.Padding = new System.Windows.Forms.Padding(3);
            this.g_BeveragePanel.Size = new System.Drawing.Size(459, 140);
            this.g_BeveragePanel.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Non Food Items Ordered";
            // 
            // g_BeverageDataGridView
            // 
            this.g_BeverageDataGridView.AllowUserToAddRows = false;
            this.g_BeverageDataGridView.AllowUserToDeleteRows = false;
            this.g_BeverageDataGridView.AllowUserToResizeRows = false;
            this.g_BeverageDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.g_BeverageDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.g_BeverageDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_BeverageDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.g_BeverageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_BeverageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.vatRate,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.Column2,
            this.dataGridViewTextBoxColumn8,
            this.nonfoodselect,
            this.complementorynonfood});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_BeverageDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.g_BeverageDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.g_BeverageDataGridView.GridColor = System.Drawing.Color.Maroon;
            this.g_BeverageDataGridView.Location = new System.Drawing.Point(3, 19);
            this.g_BeverageDataGridView.MultiSelect = false;
            this.g_BeverageDataGridView.Name = "g_BeverageDataGridView";
            this.g_BeverageDataGridView.RowHeadersVisible = false;
            this.g_BeverageDataGridView.RowHeadersWidth = 4;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.g_BeverageDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.g_BeverageDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.g_BeverageDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.g_BeverageDataGridView.RowTemplate.Height = 15;
            this.g_BeverageDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.g_BeverageDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_BeverageDataGridView.Size = new System.Drawing.Size(451, 116);
            this.g_BeverageDataGridView.TabIndex = 1;
            this.g_BeverageDataGridView.Click += new System.EventHandler(this.g_BeverageDataGridView_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 45;
            // 
            // vatRate
            // 
            this.vatRate.HeaderText = "Vat";
            this.vatRate.Name = "vatRate";
            this.vatRate.Width = 26;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Price";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Cat_id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Cat_level";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Cat_rank";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Order_details_id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Print Send";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "unitPrice";
            this.dataGridViewTextBoxColumn8.HeaderText = "unitPrice";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // nonfoodselect
            // 
            this.nonfoodselect.HeaderText = "Select";
            this.nonfoodselect.Name = "nonfoodselect";
            this.nonfoodselect.Visible = false;
            this.nonfoodselect.Width = 30;
            // 
            // complementorynonfood
            // 
            this.complementorynonfood.HeaderText = "Com";
            this.complementorynonfood.Name = "complementorynonfood";
            this.complementorynonfood.Width = 50;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Location = new System.Drawing.Point(6, 402);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(232, 135);
            this.panel5.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.56075F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.43925F));
            this.tableLayoutPanel1.Controls.Add(this.lblMembershipDiscountValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.g_SubtotalLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOrderTotal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbvat, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.g_DiscountLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.g_serviceCharge, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblVat, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbltotal, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbltips, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDiscount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.g_AmountLabel, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalItemWiseDiscountlabel, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(230, 130);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblMembershipDiscountValue
            // 
            this.lblMembershipDiscountValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMembershipDiscountValue.AutoSize = true;
            this.lblMembershipDiscountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembershipDiscountValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMembershipDiscountValue.Location = new System.Drawing.Point(195, 65);
            this.lblMembershipDiscountValue.Name = "lblMembershipDiscountValue";
            this.lblMembershipDiscountValue.Size = new System.Drawing.Size(32, 13);
            this.lblMembershipDiscountValue.TabIndex = 27;
            this.lblMembershipDiscountValue.Text = "0.00";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(8, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Membership Discount= Tk";
            // 
            // g_SubtotalLabel
            // 
            this.g_SubtotalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.g_SubtotalLabel.AutoSize = true;
            this.g_SubtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.g_SubtotalLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.g_SubtotalLabel.Location = new System.Drawing.Point(195, 4);
            this.g_SubtotalLabel.Name = "g_SubtotalLabel";
            this.g_SubtotalLabel.Size = new System.Drawing.Size(32, 13);
            this.g_SubtotalLabel.TabIndex = 5;
            this.g_SubtotalLabel.Text = "0.00";
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOrderTotal.AutoSize = true;
            this.lblOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOrderTotal.Location = new System.Drawing.Point(82, 4);
            this.lblOrderTotal.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(80, 13);
            this.lblOrderTotal.TabIndex = 4;
            this.lblOrderTotal.Text = "Sub Total= �";
            // 
            // lbvat
            // 
            this.lbvat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbvat.AutoSize = true;
            this.lbvat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbvat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbvat.Location = new System.Drawing.Point(85, 99);
            this.lbvat.Margin = new System.Windows.Forms.Padding(0);
            this.lbvat.Name = "lbvat";
            this.lbvat.Size = new System.Drawing.Size(77, 13);
            this.lbvat.TabIndex = 7;
            this.lbvat.Text = "Vat Total= �";
            // 
            // g_DiscountLabel
            // 
            this.g_DiscountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.g_DiscountLabel.AutoSize = true;
            this.g_DiscountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_DiscountLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.g_DiscountLabel.Location = new System.Drawing.Point(195, 25);
            this.g_DiscountLabel.Name = "g_DiscountLabel";
            this.g_DiscountLabel.Size = new System.Drawing.Size(32, 13);
            this.g_DiscountLabel.TabIndex = 4;
            this.g_DiscountLabel.Text = "0.00";
            // 
            // g_serviceCharge
            // 
            this.g_serviceCharge.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.g_serviceCharge.AutoSize = true;
            this.g_serviceCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_serviceCharge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.g_serviceCharge.Location = new System.Drawing.Point(195, 83);
            this.g_serviceCharge.Name = "g_serviceCharge";
            this.g_serviceCharge.Size = new System.Drawing.Size(32, 13);
            this.g_serviceCharge.TabIndex = 6;
            this.g_serviceCharge.Text = "0.00";
            // 
            // lblVat
            // 
            this.lblVat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblVat.Location = new System.Drawing.Point(195, 99);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(32, 13);
            this.lblVat.TabIndex = 8;
            this.lblVat.Text = "0.00";
            // 
            // lbltotal
            // 
            this.lbltotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbltotal.Location = new System.Drawing.Point(108, 115);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(54, 13);
            this.lbltotal.TabIndex = 2;
            this.lbltotal.Text = "Total= �";
            // 
            // lbltips
            // 
            this.lbltips.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbltips.AutoSize = true;
            this.lbltips.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltips.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbltips.Location = new System.Drawing.Point(20, 83);
            this.lbltips.Margin = new System.Windows.Forms.Padding(0);
            this.lbltips.Name = "lbltips";
            this.lbltips.Size = new System.Drawing.Size(142, 13);
            this.lbltips.TabIndex = 5;
            this.lbltips.Text = "Tips/Service Charge= �";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDiscount.Location = new System.Drawing.Point(87, 25);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(75, 13);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "Discount= �";
            // 
            // g_AmountLabel
            // 
            this.g_AmountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.g_AmountLabel.AutoSize = true;
            this.g_AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_AmountLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.g_AmountLabel.Location = new System.Drawing.Point(195, 115);
            this.g_AmountLabel.Name = "g_AmountLabel";
            this.g_AmountLabel.Size = new System.Drawing.Size(32, 13);
            this.g_AmountLabel.TabIndex = 1;
            this.g_AmountLabel.Text = "0.00";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(48, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Item Discount= Tk";
            // 
            // totalItemWiseDiscountlabel
            // 
            this.totalItemWiseDiscountlabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalItemWiseDiscountlabel.AutoSize = true;
            this.totalItemWiseDiscountlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.totalItemWiseDiscountlabel.Location = new System.Drawing.Point(195, 45);
            this.totalItemWiseDiscountlabel.Name = "totalItemWiseDiscountlabel";
            this.totalItemWiseDiscountlabel.Size = new System.Drawing.Size(32, 13);
            this.totalItemWiseDiscountlabel.TabIndex = 29;
            this.totalItemWiseDiscountlabel.Text = "0.00";
            // 
            // TableOrderStatusStrip
            // 
            this.TableOrderStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserStatusLabel,
            this.TableStatusLabel,
            this.GuestStatusLabel,
            this.TableValueStatusLabel,
            this.BillNoStatusLabel,
            this.toolStripStatusLabel1});
            this.TableOrderStatusStrip.Location = new System.Drawing.Point(3, 753);
            this.TableOrderStatusStrip.Name = "TableOrderStatusStrip";
            this.TableOrderStatusStrip.Size = new System.Drawing.Size(1270, 24);
            this.TableOrderStatusStrip.TabIndex = 0;
            // 
            // UserStatusLabel
            // 
            this.UserStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UserStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.UserStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.UserStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UserStatusLabel.Name = "UserStatusLabel";
            this.UserStatusLabel.Size = new System.Drawing.Size(154, 19);
            this.UserStatusLabel.Text = "Logged in as Administrator";
            // 
            // TableStatusLabel
            // 
            this.TableStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TableStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TableStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.TableStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TableStatusLabel.Name = "TableStatusLabel";
            this.TableStatusLabel.Size = new System.Drawing.Size(71, 19);
            this.TableStatusLabel.Text = "Table No. 1";
            // 
            // GuestStatusLabel
            // 
            this.GuestStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GuestStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.GuestStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.GuestStatusLabel.Name = "GuestStatusLabel";
            this.GuestStatusLabel.Size = new System.Drawing.Size(74, 19);
            this.GuestStatusLabel.Text = "GuestCount";
            // 
            // TableValueStatusLabel
            // 
            this.TableValueStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TableValueStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TableValueStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.TableValueStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TableValueStatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TableValueStatusLabel.Name = "TableValueStatusLabel";
            this.TableValueStatusLabel.Size = new System.Drawing.Size(108, 19);
            this.TableValueStatusLabel.Text = "Table Value �0.000";
            // 
            // BillNoStatusLabel
            // 
            this.BillNoStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BillNoStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.BillNoStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.BillNoStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BillNoStatusLabel.Name = "BillNoStatusLabel";
            this.BillNoStatusLabel.Size = new System.Drawing.Size(88, 19);
            this.BillNoStatusLabel.Text = "Bill No. 111111";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tlTips
            // 
            this.tlTips.IsBalloon = true;
            // 
            // btnOrderLog
            // 
            this.btnOrderLog.BackColor = System.Drawing.Color.Transparent;
            this.btnOrderLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOrderLog.BackgroundImage")));
            this.btnOrderLog.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnOrderLog.BgImageOnMouseDown")));
            this.btnOrderLog.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnOrderLog.BgImageOnMouseUp")));
            this.btnOrderLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnOrderLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOrderLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOrderLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderLog.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnOrderLog.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnOrderLog.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnOrderLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderLog.Location = new System.Drawing.Point(2, 2);
            this.btnOrderLog.Name = "btnOrderLog";
            this.btnOrderLog.Size = new System.Drawing.Size(140, 53);
            this.btnOrderLog.TabIndex = 14;
            this.btnOrderLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tlTips.SetToolTip(this.btnOrderLog, "Shows the current status of the order");
            this.btnOrderLog.UseVisualStyleBackColor = false;
            this.btnOrderLog.Click += new System.EventHandler(this.btnOrderLog_Click);
            // 
            // g_SeatButton
            // 
            this.g_SeatButton.BackColor = System.Drawing.Color.Transparent;
            this.g_SeatButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_SeatButton.BackgroundImage")));
            this.g_SeatButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_SeatButton.BgImageOnMouseDown")));
            this.g_SeatButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_SeatButton.BgImageOnMouseUp")));
            this.g_SeatButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_SeatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_SeatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_SeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_SeatButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_SeatButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_SeatButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_SeatButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.g_SeatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_SeatButton.Location = new System.Drawing.Point(369, 403);
            this.g_SeatButton.Name = "g_SeatButton";
            this.g_SeatButton.Size = new System.Drawing.Size(45, 35);
            this.g_SeatButton.TabIndex = 14;
            this.g_SeatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_SeatButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tlTips.SetToolTip(this.g_SeatButton, "Click here to increase the selected item");
            this.g_SeatButton.UseVisualStyleBackColor = false;
            this.g_SeatButton.Click += new System.EventHandler(this.g_SeatButton_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGreen;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnSetOrderWaiter);
            this.panel6.Controls.Add(this.btnOrderLog);
            this.panel6.Controls.Add(this.g_ItemDescriptionButton);
            this.panel6.Controls.Add(this.g_PrintGuestBillButton);
            this.panel6.Controls.Add(this.g_SpecialButton);
            this.panel6.Controls.Add(this.g_PromotionsButton);
            this.panel6.Controls.Add(this.btnKitchenText);
            this.panel6.Controls.Add(this.g_ServiceChargeButton);
            this.panel6.Controls.Add(this.btnPLU);
            this.panel6.Location = new System.Drawing.Point(1027, 54);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(145, 536);
            this.panel6.TabIndex = 18;
            // 
            // btnSetOrderWaiter
            // 
            this.btnSetOrderWaiter.BackColor = System.Drawing.Color.Transparent;
            this.btnSetOrderWaiter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetOrderWaiter.BackgroundImage")));
            this.btnSetOrderWaiter.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnSetOrderWaiter.BgImageOnMouseDown")));
            this.btnSetOrderWaiter.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnSetOrderWaiter.BgImageOnMouseUp")));
            this.btnSetOrderWaiter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSetOrderWaiter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetOrderWaiter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetOrderWaiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOrderWaiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetOrderWaiter.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnSetOrderWaiter.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnSetOrderWaiter.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnSetOrderWaiter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetOrderWaiter.Location = new System.Drawing.Point(2, 478);
            this.btnSetOrderWaiter.Name = "btnSetOrderWaiter";
            this.btnSetOrderWaiter.Size = new System.Drawing.Size(140, 53);
            this.btnSetOrderWaiter.TabIndex = 16;
            this.btnSetOrderWaiter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetOrderWaiter.UseVisualStyleBackColor = false;
            this.btnSetOrderWaiter.Click += new System.EventHandler(this.btnSetOrderWaiter_Click);
            // 
            // g_ItemDescriptionButton
            // 
            this.g_ItemDescriptionButton.BackColor = System.Drawing.Color.Transparent;
            this.g_ItemDescriptionButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_ItemDescriptionButton.BackgroundImage")));
            this.g_ItemDescriptionButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_ItemDescriptionButton.BgImageOnMouseDown")));
            this.g_ItemDescriptionButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_ItemDescriptionButton.BgImageOnMouseUp")));
            this.g_ItemDescriptionButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_ItemDescriptionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_ItemDescriptionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_ItemDescriptionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_ItemDescriptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_ItemDescriptionButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_ItemDescriptionButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_ItemDescriptionButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_ItemDescriptionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_ItemDescriptionButton.Location = new System.Drawing.Point(2, 124);
            this.g_ItemDescriptionButton.Name = "g_ItemDescriptionButton";
            this.g_ItemDescriptionButton.Size = new System.Drawing.Size(140, 53);
            this.g_ItemDescriptionButton.TabIndex = 8;
            this.g_ItemDescriptionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_ItemDescriptionButton.UseVisualStyleBackColor = false;
            this.g_ItemDescriptionButton.Click += new System.EventHandler(this.g_ItemDescriptionButton_Click);
            // 
            // g_PrintGuestBillButton
            // 
            this.g_PrintGuestBillButton.BackColor = System.Drawing.Color.Transparent;
            this.g_PrintGuestBillButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_PrintGuestBillButton.BackgroundImage")));
            this.g_PrintGuestBillButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_PrintGuestBillButton.BgImageOnMouseDown")));
            this.g_PrintGuestBillButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_PrintGuestBillButton.BgImageOnMouseUp")));
            this.g_PrintGuestBillButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_PrintGuestBillButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_PrintGuestBillButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_PrintGuestBillButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_PrintGuestBillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_PrintGuestBillButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_PrintGuestBillButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_PrintGuestBillButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_PrintGuestBillButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_PrintGuestBillButton.Location = new System.Drawing.Point(2, 419);
            this.g_PrintGuestBillButton.Name = "g_PrintGuestBillButton";
            this.g_PrintGuestBillButton.Size = new System.Drawing.Size(140, 53);
            this.g_PrintGuestBillButton.TabIndex = 9;
            this.g_PrintGuestBillButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_PrintGuestBillButton.UseVisualStyleBackColor = false;
            this.g_PrintGuestBillButton.Click += new System.EventHandler(this.g_PrintGuestBillButton_Click);
            // 
            // g_SpecialButton
            // 
            this.g_SpecialButton.BackColor = System.Drawing.Color.Transparent;
            this.g_SpecialButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_SpecialButton.BackgroundImage")));
            this.g_SpecialButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_SpecialButton.BgImageOnMouseDown")));
            this.g_SpecialButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_SpecialButton.BgImageOnMouseUp")));
            this.g_SpecialButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_SpecialButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_SpecialButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_SpecialButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_SpecialButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_SpecialButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_SpecialButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_SpecialButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_SpecialButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_SpecialButton.Location = new System.Drawing.Point(2, 184);
            this.g_SpecialButton.Name = "g_SpecialButton";
            this.g_SpecialButton.Size = new System.Drawing.Size(140, 53);
            this.g_SpecialButton.TabIndex = 7;
            this.g_SpecialButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_SpecialButton.UseVisualStyleBackColor = false;
            this.g_SpecialButton.Click += new System.EventHandler(this.g_SpecialButton_Click);
            // 
            // g_PromotionsButton
            // 
            this.g_PromotionsButton.BackColor = System.Drawing.Color.Transparent;
            this.g_PromotionsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_PromotionsButton.BackgroundImage")));
            this.g_PromotionsButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_PromotionsButton.BgImageOnMouseDown")));
            this.g_PromotionsButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_PromotionsButton.BgImageOnMouseUp")));
            this.g_PromotionsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_PromotionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_PromotionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_PromotionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_PromotionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_PromotionsButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_PromotionsButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_PromotionsButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_PromotionsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_PromotionsButton.Location = new System.Drawing.Point(2, 360);
            this.g_PromotionsButton.Name = "g_PromotionsButton";
            this.g_PromotionsButton.Size = new System.Drawing.Size(140, 53);
            this.g_PromotionsButton.TabIndex = 5;
            this.g_PromotionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_PromotionsButton.UseVisualStyleBackColor = false;
            this.g_PromotionsButton.Click += new System.EventHandler(this.g_PromotionsButton_Click);
            // 
            // btnKitchenText
            // 
            this.btnKitchenText.BackColor = System.Drawing.Color.Transparent;
            this.btnKitchenText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKitchenText.BackgroundImage")));
            this.btnKitchenText.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnKitchenText.BgImageOnMouseDown")));
            this.btnKitchenText.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnKitchenText.BgImageOnMouseUp")));
            this.btnKitchenText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnKitchenText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnKitchenText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnKitchenText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitchenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKitchenText.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnKitchenText.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnKitchenText.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnKitchenText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKitchenText.Location = new System.Drawing.Point(2, 63);
            this.btnKitchenText.Name = "btnKitchenText";
            this.btnKitchenText.Size = new System.Drawing.Size(140, 53);
            this.btnKitchenText.TabIndex = 12;
            this.btnKitchenText.TabStop = false;
            this.btnKitchenText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKitchenText.UseVisualStyleBackColor = false;
            this.btnKitchenText.Click += new System.EventHandler(this.btnKitchenText_Click);
            // 
            // g_ServiceChargeButton
            // 
            this.g_ServiceChargeButton.BackColor = System.Drawing.Color.Transparent;
            this.g_ServiceChargeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_ServiceChargeButton.BackgroundImage")));
            this.g_ServiceChargeButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_ServiceChargeButton.BgImageOnMouseDown")));
            this.g_ServiceChargeButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_ServiceChargeButton.BgImageOnMouseUp")));
            this.g_ServiceChargeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_ServiceChargeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_ServiceChargeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_ServiceChargeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_ServiceChargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_ServiceChargeButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_ServiceChargeButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_ServiceChargeButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_ServiceChargeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_ServiceChargeButton.Location = new System.Drawing.Point(2, 301);
            this.g_ServiceChargeButton.Name = "g_ServiceChargeButton";
            this.g_ServiceChargeButton.Size = new System.Drawing.Size(140, 53);
            this.g_ServiceChargeButton.TabIndex = 6;
            this.g_ServiceChargeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_ServiceChargeButton.UseVisualStyleBackColor = false;
            this.g_ServiceChargeButton.Click += new System.EventHandler(this.g_ServiceChargeButton_Click);
            // 
            // btnPLU
            // 
            this.btnPLU.BackColor = System.Drawing.Color.Transparent;
            this.btnPLU.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPLU.BackgroundImage")));
            this.btnPLU.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPLU.BgImageOnMouseDown")));
            this.btnPLU.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPLU.BgImageOnMouseUp")));
            this.btnPLU.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPLU.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPLU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPLU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPLU.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPLU.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPLU.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnPLU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPLU.Location = new System.Drawing.Point(2, 242);
            this.btnPLU.Name = "btnPLU";
            this.btnPLU.Size = new System.Drawing.Size(140, 53);
            this.btnPLU.TabIndex = 13;
            this.btnPLU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPLU.UseVisualStyleBackColor = false;
            this.btnPLU.Click += new System.EventHandler(this.btnPLU_Click);
            // 
            // g_ConvertButton
            // 
            this.g_ConvertButton.BackColor = System.Drawing.Color.Transparent;
            this.g_ConvertButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_ConvertButton.BackgroundImage")));
            this.g_ConvertButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_ConvertButton.BgImageOnMouseDown")));
            this.g_ConvertButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_ConvertButton.BgImageOnMouseUp")));
            this.g_ConvertButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_ConvertButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_ConvertButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_ConvertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_ConvertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_ConvertButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_ConvertButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_ConvertButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_ConvertButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_ConvertButton.Location = new System.Drawing.Point(806, 565);
            this.g_ConvertButton.Name = "g_ConvertButton";
            this.g_ConvertButton.Size = new System.Drawing.Size(140, 53);
            this.g_ConvertButton.TabIndex = 25;
            this.g_ConvertButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_ConvertButton.UseVisualStyleBackColor = false;
            this.g_ConvertButton.Visible = false;
            this.g_ConvertButton.Click += new System.EventHandler(this.functionalButton1_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnEditOrder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditOrder.BackgroundImage")));
            this.btnEditOrder.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnEditOrder.BgImageOnMouseDown")));
            this.btnEditOrder.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnEditOrder.BgImageOnMouseUp")));
            this.btnEditOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnEditOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOrder.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnEditOrder.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnEditOrder.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.btnEditOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditOrder.Location = new System.Drawing.Point(577, 595);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(140, 42);
            this.btnEditOrder.TabIndex = 15;
            this.btnEditOrder.Text = "Change Order  Details";
            this.btnEditOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditOrder.UseVisualStyleBackColor = false;
            this.btnEditOrder.Visible = false;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // g_QuantityButton
            // 
            this.g_QuantityButton.BackColor = System.Drawing.Color.Transparent;
            this.g_QuantityButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_QuantityButton.BackgroundImage")));
            this.g_QuantityButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_QuantityButton.BgImageOnMouseDown")));
            this.g_QuantityButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_QuantityButton.BgImageOnMouseUp")));
            this.g_QuantityButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_QuantityButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_QuantityButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_QuantityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_QuantityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_QuantityButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_QuantityButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_QuantityButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_QuantityButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_QuantityButton.Location = new System.Drawing.Point(577, 643);
            this.g_QuantityButton.Name = "g_QuantityButton";
            this.g_QuantityButton.Size = new System.Drawing.Size(140, 42);
            this.g_QuantityButton.TabIndex = 4;
            this.g_QuantityButton.Text = "Set Item Quantity";
            this.g_QuantityButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_QuantityButton.UseVisualStyleBackColor = false;
            this.g_QuantityButton.Visible = false;
            this.g_QuantityButton.Click += new System.EventHandler(this.g_QuantityButton_Click);
            // 
            // g_PayCloseButton
            // 
            this.g_PayCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.g_PayCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.g_PayCloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_PayCloseButton.BackgroundImage")));
            this.g_PayCloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.g_PayCloseButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_PayCloseButton.BgImageOnMouseDown")));
            this.g_PayCloseButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_PayCloseButton.BgImageOnMouseUp")));
            this.g_PayCloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_PayCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_PayCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_PayCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_PayCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_PayCloseButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_PayCloseButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_PayCloseButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_PayCloseButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.g_PayCloseButton.Location = new System.Drawing.Point(1046, 659);
            this.g_PayCloseButton.Name = "g_PayCloseButton";
            this.g_PayCloseButton.Size = new System.Drawing.Size(140, 65);
            this.g_PayCloseButton.TabIndex = 12;
            this.g_PayCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_PayCloseButton.UseVisualStyleBackColor = false;
            this.g_PayCloseButton.Click += new System.EventHandler(this.g_PayCloseButton_Click);
            // 
            // g_ExitButton
            // 
            this.g_ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.g_ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.g_ExitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_ExitButton.BackgroundImage")));
            this.g_ExitButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_ExitButton.BgImageOnMouseDown")));
            this.g_ExitButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_ExitButton.BgImageOnMouseUp")));
            this.g_ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_ExitButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_ExitButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_ExitButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_ExitButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Back;
            this.g_ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("g_ExitButton.Image")));
            this.g_ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_ExitButton.Location = new System.Drawing.Point(3, 701);
            this.g_ExitButton.Name = "g_ExitButton";
            this.g_ExitButton.Size = new System.Drawing.Size(140, 51);
            this.g_ExitButton.TabIndex = 10;
            this.g_ExitButton.Text = "  ";
            this.g_ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_ExitButton.UseVisualStyleBackColor = false;
            this.g_ExitButton.Click += new System.EventHandler(this.g_ExitButton_Click);
            // 
            // g_MiscButton
            // 
            this.g_MiscButton.BackColor = System.Drawing.Color.Transparent;
            this.g_MiscButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_MiscButton.BackgroundImage")));
            this.g_MiscButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_MiscButton.BgImageOnMouseDown")));
            this.g_MiscButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_MiscButton.BgImageOnMouseUp")));
            this.g_MiscButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_MiscButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_MiscButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_MiscButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_MiscButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_MiscButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_MiscButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_MiscButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_MiscButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_MiscButton.Location = new System.Drawing.Point(168, 3);
            this.g_MiscButton.Name = "g_MiscButton";
            this.g_MiscButton.Size = new System.Drawing.Size(151, 57);
            this.g_MiscButton.TabIndex = 11;
            this.g_MiscButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_MiscButton.UseVisualStyleBackColor = false;
            this.g_MiscButton.Click += new System.EventHandler(this.g_MiscButton_Click);
            // 
            // g_SendButton
            // 
            this.g_SendButton.BackColor = System.Drawing.Color.Transparent;
            this.g_SendButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_SendButton.BackgroundImage")));
            this.g_SendButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_SendButton.BgImageOnMouseDown")));
            this.g_SendButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_SendButton.BgImageOnMouseUp")));
            this.g_SendButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_SendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_SendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_SendButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_SendButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_SendButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_SendButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.g_SendButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_SendButton.Location = new System.Drawing.Point(1, 5);
            this.g_SendButton.Name = "g_SendButton";
            this.g_SendButton.Size = new System.Drawing.Size(161, 55);
            this.g_SendButton.TabIndex = 10;
            this.g_SendButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_SendButton.UseVisualStyleBackColor = false;
            this.g_SendButton.Click += new System.EventHandler(this.g_SendButton_Click);
            // 
            // g_RemoveButton
            // 
            this.g_RemoveButton.BackColor = System.Drawing.Color.Transparent;
            this.g_RemoveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_RemoveButton.BackgroundImage")));
            this.g_RemoveButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_RemoveButton.BgImageOnMouseDown")));
            this.g_RemoveButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_RemoveButton.BgImageOnMouseUp")));
            this.g_RemoveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_RemoveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_RemoveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_RemoveButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_RemoveButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_RemoveButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_RemoveButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Normal;
            this.g_RemoveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_RemoveButton.Location = new System.Drawing.Point(420, 403);
            this.g_RemoveButton.Name = "g_RemoveButton";
            this.g_RemoveButton.Size = new System.Drawing.Size(45, 35);
            this.g_RemoveButton.TabIndex = 13;
            this.g_RemoveButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_RemoveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_RemoveButton.UseVisualStyleBackColor = false;
            this.g_RemoveButton.Click += new System.EventHandler(this.g_RemoveButton_Click);
            // 
            // g_Category3NextButton
            // 
            this.g_Category3NextButton.BackColor = System.Drawing.Color.Transparent;
            this.g_Category3NextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_Category3NextButton.BackgroundImage")));
            this.g_Category3NextButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_Category3NextButton.BgImageOnMouseDown")));
            this.g_Category3NextButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_Category3NextButton.BgImageOnMouseUp")));
            this.g_Category3NextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_Category3NextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_Category3NextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_Category3NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_Category3NextButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_Category3NextButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_Category3NextButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_Category3NextButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Next;
            this.g_Category3NextButton.Image = ((System.Drawing.Image)(resources.GetObject("g_Category3NextButton.Image")));
            this.g_Category3NextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_Category3NextButton.Location = new System.Drawing.Point(678, 515);
            this.g_Category3NextButton.Name = "g_Category3NextButton";
            this.g_Category3NextButton.Size = new System.Drawing.Size(61, 35);
            this.g_Category3NextButton.TabIndex = 16;
            this.g_Category3NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_Category3NextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.g_Category3NextButton.UseVisualStyleBackColor = false;
            this.g_Category3NextButton.Click += new System.EventHandler(this.g_Category3NextButton_Click);
            // 
            // g_Category3PreviousButton
            // 
            this.g_Category3PreviousButton.BackColor = System.Drawing.Color.Transparent;
            this.g_Category3PreviousButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_Category3PreviousButton.BackgroundImage")));
            this.g_Category3PreviousButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_Category3PreviousButton.BgImageOnMouseDown")));
            this.g_Category3PreviousButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_Category3PreviousButton.BgImageOnMouseUp")));
            this.g_Category3PreviousButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_Category3PreviousButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_Category3PreviousButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_Category3PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_Category3PreviousButton.Font = new System.Drawing.Font("Arial", 10F);
            this.g_Category3PreviousButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_Category3PreviousButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_Category3PreviousButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Previous;
            this.g_Category3PreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("g_Category3PreviousButton.Image")));
            this.g_Category3PreviousButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_Category3PreviousButton.Location = new System.Drawing.Point(609, 515);
            this.g_Category3PreviousButton.Name = "g_Category3PreviousButton";
            this.g_Category3PreviousButton.Size = new System.Drawing.Size(61, 35);
            this.g_Category3PreviousButton.TabIndex = 15;
            this.g_Category3PreviousButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_Category3PreviousButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.g_Category3PreviousButton.UseVisualStyleBackColor = false;
            this.g_Category3PreviousButton.Click += new System.EventHandler(this.g_Category3PreviousButton_Click);
            // 
            // g_NextButton
            // 
            this.g_NextButton.BackColor = System.Drawing.Color.Transparent;
            this.g_NextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_NextButton.BackgroundImage")));
            this.g_NextButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_NextButton.BgImageOnMouseDown")));
            this.g_NextButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_NextButton.BgImageOnMouseUp")));
            this.g_NextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_NextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_NextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_NextButton.Font = new System.Drawing.Font("Arial", 8F);
            this.g_NextButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_NextButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_NextButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Next;
            this.g_NextButton.Image = ((System.Drawing.Image)(resources.GetObject("g_NextButton.Image")));
            this.g_NextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_NextButton.Location = new System.Drawing.Point(815, 515);
            this.g_NextButton.Name = "g_NextButton";
            this.g_NextButton.Size = new System.Drawing.Size(61, 35);
            this.g_NextButton.TabIndex = 3;
            this.g_NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_NextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.g_NextButton.UseVisualStyleBackColor = false;
            this.g_NextButton.Click += new System.EventHandler(this.g_NextButton_Click);
            // 
            // g_PreviousButton
            // 
            this.g_PreviousButton.BackColor = System.Drawing.Color.Transparent;
            this.g_PreviousButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("g_PreviousButton.BackgroundImage")));
            this.g_PreviousButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("g_PreviousButton.BgImageOnMouseDown")));
            this.g_PreviousButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("g_PreviousButton.BgImageOnMouseUp")));
            this.g_PreviousButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.g_PreviousButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.g_PreviousButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.g_PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.g_PreviousButton.Font = new System.Drawing.Font("Arial", 8F);
            this.g_PreviousButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.g_PreviousButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.g_PreviousButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.Previous;
            this.g_PreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("g_PreviousButton.Image")));
            this.g_PreviousButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.g_PreviousButton.Location = new System.Drawing.Point(748, 515);
            this.g_PreviousButton.Name = "g_PreviousButton";
            this.g_PreviousButton.Size = new System.Drawing.Size(61, 35);
            this.g_PreviousButton.TabIndex = 2;
            this.g_PreviousButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.g_PreviousButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.g_PreviousButton.UseVisualStyleBackColor = false;
            this.g_PreviousButton.Click += new System.EventHandler(this.g_PreviousButton_Click);
            // 
            // g_Category2Panel
            // 
            this.g_Category2Panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.g_Category2Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.g_Category2Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.g_Category2Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.g_Category2Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_Category2Panel.Location = new System.Drawing.Point(3, 18);
            this.g_Category2Panel.Margin = new System.Windows.Forms.Padding(0);
            this.g_Category2Panel.Name = "g_Category2Panel";
            this.g_Category2Panel.Padding = new System.Windows.Forms.Padding(4);
            this.g_Category2Panel.Size = new System.Drawing.Size(121, 432);
            this.g_Category2Panel.TabIndex = 0;
            this.g_Category2Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.g_Category2Panel_Paint);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.txtBoxSearchItem);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.g_ItemSelectionFlowLayoutPanel);
            this.panel9.Location = new System.Drawing.Point(471, 54);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(3);
            this.panel9.Size = new System.Drawing.Size(270, 455);
            this.panel9.TabIndex = 19;
            // 
            // txtBoxSearchItem
            // 
            this.txtBoxSearchItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBoxSearchItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxSearchItem.Enabled = false;
            this.txtBoxSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearchItem.Location = new System.Drawing.Point(3, 19);
            this.txtBoxSearchItem.Name = "txtBoxSearchItem";
            this.txtBoxSearchItem.Size = new System.Drawing.Size(261, 30);
            this.txtBoxSearchItem.TabIndex = 5;
            this.txtBoxSearchItem.Text = "search item";
            this.txtBoxSearchItem.Click += new System.EventHandler(this.txtBoxSearchItem_Click);
            this.txtBoxSearchItem.TextChanged += new System.EventHandler(this.txtBoxSearchItem_TextChanged);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.g_Category2Panel);
            this.panel10.Location = new System.Drawing.Point(748, 54);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3);
            this.panel10.Size = new System.Drawing.Size(129, 455);
            this.panel10.TabIndex = 20;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label3);
            this.panel11.Controls.Add(this.foodMenuPanal);
            this.panel11.Location = new System.Drawing.Point(886, 54);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(3);
            this.panel11.Size = new System.Drawing.Size(129, 455);
            this.panel11.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Food Manu";
            // 
            // foodMenuPanal
            // 
            this.foodMenuPanal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.foodMenuPanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.foodMenuPanal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foodMenuPanal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.foodMenuPanal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodMenuPanal.Location = new System.Drawing.Point(3, 18);
            this.foodMenuPanal.Margin = new System.Windows.Forms.Padding(0);
            this.foodMenuPanal.Name = "foodMenuPanal";
            this.foodMenuPanal.Padding = new System.Windows.Forms.Padding(4);
            this.foodMenuPanal.Size = new System.Drawing.Size(121, 432);
            this.foodMenuPanal.TabIndex = 0;
            this.foodMenuPanal.Paint += new System.Windows.Forms.PaintEventHandler(this.foodMenuPanal_Paint);
            // 
            // btnPrevParent
            // 
            this.btnPrevParent.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevParent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrevParent.BackgroundImage")));
            this.btnPrevParent.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnPrevParent.BgImageOnMouseDown")));
            this.btnPrevParent.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnPrevParent.BgImageOnMouseUp")));
            this.btnPrevParent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrevParent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrevParent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrevParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevParent.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPrevParent.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnPrevParent.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnPrevParent.FunctionType = RMSUI.RMSUIConstants.FunctionType.Previous;
            this.btnPrevParent.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevParent.Image")));
            this.btnPrevParent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevParent.Location = new System.Drawing.Point(885, 515);
            this.btnPrevParent.Name = "btnPrevParent";
            this.btnPrevParent.Size = new System.Drawing.Size(61, 35);
            this.btnPrevParent.TabIndex = 22;
            this.btnPrevParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevParent.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrevParent.UseVisualStyleBackColor = false;
            this.btnPrevParent.Click += new System.EventHandler(this.btnPrevParent_Click);
            // 
            // btnNextParent
            // 
            this.btnNextParent.BackColor = System.Drawing.Color.Transparent;
            this.btnNextParent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextParent.BackgroundImage")));
            this.btnNextParent.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("btnNextParent.BgImageOnMouseDown")));
            this.btnNextParent.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("btnNextParent.BgImageOnMouseUp")));
            this.btnNextParent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNextParent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNextParent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNextParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextParent.Font = new System.Drawing.Font("Arial", 8F);
            this.btnNextParent.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.btnNextParent.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.btnNextParent.FunctionType = RMSUI.RMSUIConstants.FunctionType.Next;
            this.btnNextParent.Image = ((System.Drawing.Image)(resources.GetObject("btnNextParent.Image")));
            this.btnNextParent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNextParent.Location = new System.Drawing.Point(955, 515);
            this.btnNextParent.Name = "btnNextParent";
            this.btnNextParent.Size = new System.Drawing.Size(61, 35);
            this.btnNextParent.TabIndex = 23;
            this.btnNextParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNextParent.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNextParent.UseVisualStyleBackColor = false;
            this.btnNextParent.Click += new System.EventHandler(this.btnNextParent_Click);
            // 
            // delivaryfromkitchneButton
            // 
            this.delivaryfromkitchneButton.BackColor = System.Drawing.Color.Transparent;
            this.delivaryfromkitchneButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delivaryfromkitchneButton.BackgroundImage")));
            this.delivaryfromkitchneButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("delivaryfromkitchneButton.BgImageOnMouseDown")));
            this.delivaryfromkitchneButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("delivaryfromkitchneButton.BgImageOnMouseUp")));
            this.delivaryfromkitchneButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.delivaryfromkitchneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.delivaryfromkitchneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.delivaryfromkitchneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delivaryfromkitchneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delivaryfromkitchneButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.delivaryfromkitchneButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.delivaryfromkitchneButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.delivaryfromkitchneButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delivaryfromkitchneButton.Location = new System.Drawing.Point(511, 691);
            this.delivaryfromkitchneButton.Name = "delivaryfromkitchneButton";
            this.delivaryfromkitchneButton.Size = new System.Drawing.Size(140, 42);
            this.delivaryfromkitchneButton.TabIndex = 25;
            this.delivaryfromkitchneButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.delivaryfromkitchneButton.UseVisualStyleBackColor = false;
            this.delivaryfromkitchneButton.Visible = false;
            this.delivaryfromkitchneButton.Click += new System.EventHandler(this.delivaryfromkitchneButton_Click);
            // 
            // membershipfunctionalButton
            // 
            this.membershipfunctionalButton.BackColor = System.Drawing.Color.Transparent;
            this.membershipfunctionalButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("membershipfunctionalButton.BackgroundImage")));
            this.membershipfunctionalButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("membershipfunctionalButton.BgImageOnMouseDown")));
            this.membershipfunctionalButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("membershipfunctionalButton.BgImageOnMouseUp")));
            this.membershipfunctionalButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.membershipfunctionalButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.membershipfunctionalButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.membershipfunctionalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.membershipfunctionalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membershipfunctionalButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.membershipfunctionalButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.membershipfunctionalButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.membershipfunctionalButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.membershipfunctionalButton.Location = new System.Drawing.Point(314, 445);
            this.membershipfunctionalButton.Name = "membershipfunctionalButton";
            this.membershipfunctionalButton.Size = new System.Drawing.Size(155, 67);
            this.membershipfunctionalButton.TabIndex = 26;
            this.membershipfunctionalButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.membershipfunctionalButton.UseVisualStyleBackColor = false;
            this.membershipfunctionalButton.Click += new System.EventHandler(this.membershipfunctionalButton_Click);
            // 
            // complementoryButton
            // 
            this.complementoryButton.BackColor = System.Drawing.Color.Transparent;
            this.complementoryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("complementoryButton.BackgroundImage")));
            this.complementoryButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("complementoryButton.BgImageOnMouseDown")));
            this.complementoryButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("complementoryButton.BgImageOnMouseUp")));
            this.complementoryButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.complementoryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.complementoryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.complementoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.complementoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complementoryButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.complementoryButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.complementoryButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.complementoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.complementoryButton.Location = new System.Drawing.Point(177, 62);
            this.complementoryButton.Name = "complementoryButton";
            this.complementoryButton.Size = new System.Drawing.Size(140, 53);
            this.complementoryButton.TabIndex = 27;
            this.complementoryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.complementoryButton.UseVisualStyleBackColor = false;
            this.complementoryButton.Click += new System.EventHandler(this.complementoryButton_Click);
            // 
            // itemComplementoryButton
            // 
            this.itemComplementoryButton.BackColor = System.Drawing.Color.Transparent;
            this.itemComplementoryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("itemComplementoryButton.BackgroundImage")));
            this.itemComplementoryButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("itemComplementoryButton.BgImageOnMouseDown")));
            this.itemComplementoryButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("itemComplementoryButton.BgImageOnMouseUp")));
            this.itemComplementoryButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.itemComplementoryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.itemComplementoryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.itemComplementoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemComplementoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemComplementoryButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.itemComplementoryButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.itemComplementoryButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.itemComplementoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.itemComplementoryButton.Location = new System.Drawing.Point(325, 62);
            this.itemComplementoryButton.Name = "itemComplementoryButton";
            this.itemComplementoryButton.Size = new System.Drawing.Size(140, 53);
            this.itemComplementoryButton.TabIndex = 28;
            this.itemComplementoryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.itemComplementoryButton.UseVisualStyleBackColor = false;
            this.itemComplementoryButton.Click += new System.EventHandler(this.itemComplementoryButton_Click);
            // 
            // vatComplementoryButton
            // 
            this.vatComplementoryButton.BackColor = System.Drawing.Color.Transparent;
            this.vatComplementoryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vatComplementoryButton.BackgroundImage")));
            this.vatComplementoryButton.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("vatComplementoryButton.BgImageOnMouseDown")));
            this.vatComplementoryButton.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("vatComplementoryButton.BgImageOnMouseUp")));
            this.vatComplementoryButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.vatComplementoryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.vatComplementoryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.vatComplementoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vatComplementoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vatComplementoryButton.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.vatComplementoryButton.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.vatComplementoryButton.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.vatComplementoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vatComplementoryButton.Location = new System.Drawing.Point(325, 3);
            this.vatComplementoryButton.Name = "vatComplementoryButton";
            this.vatComplementoryButton.Size = new System.Drawing.Size(140, 53);
            this.vatComplementoryButton.TabIndex = 29;
            this.vatComplementoryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vatComplementoryButton.UseVisualStyleBackColor = false;
            this.vatComplementoryButton.Click += new System.EventHandler(this.vatComplementoryButton_Click);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel12.Controls.Add(this.vatComplementoryButton);
            this.panel12.Controls.Add(this.complementoryButton);
            this.panel12.Controls.Add(this.itemComplementoryButton);
            this.panel12.Controls.Add(this.g_SendButton);
            this.panel12.Controls.Add(this.g_MiscButton);
            this.panel12.Location = new System.Drawing.Point(6, 559);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(471, 128);
            this.panel12.TabIndex = 33;
            // 
            // functionalButton1
            // 
            this.functionalButton1.BackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BackgroundImage")));
            this.functionalButton1.BgImageOnMouseDown = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BgImageOnMouseDown")));
            this.functionalButton1.BgImageOnMouseUp = ((System.Drawing.Image)(resources.GetObject("functionalButton1.BgImageOnMouseUp")));
            this.functionalButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.functionalButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.functionalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.functionalButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.functionalButton1.ForeColorOnMouseDown = System.Drawing.Color.White;
            this.functionalButton1.ForeColorOnMouseUp = System.Drawing.Color.Black;
            this.functionalButton1.FunctionType = RMSUI.RMSUIConstants.FunctionType.NormalCenter;
            this.functionalButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.functionalButton1.Location = new System.Drawing.Point(782, 670);
            this.functionalButton1.Name = "functionalButton1";
            this.functionalButton1.Size = new System.Drawing.Size(140, 42);
            this.functionalButton1.TabIndex = 34;
            this.functionalButton1.Text = "Item Wise Discount";
            this.functionalButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.functionalButton1.UseVisualStyleBackColor = false;
            this.functionalButton1.Click += new System.EventHandler(this.functionalButton1_Click_2);
            // 
            // CTableOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1276, 780);
            this.Controls.Add(this.functionalButton1);
            this.Controls.Add(this.g_ConvertButton);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.g_ExitButton);
            this.Controls.Add(this.membershipfunctionalButton);
            this.Controls.Add(this.delivaryfromkitchneButton);
            this.Controls.Add(this.btnPrevParent);
            this.Controls.Add(this.g_PayCloseButton);
            this.Controls.Add(this.btnNextParent);
            this.Controls.Add(this.btnEditOrder);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.g_Category3PreviousButton);
            this.Controls.Add(this.g_QuantityButton);
            this.Controls.Add(this.g_Category3NextButton);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.g_PreviousButton);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.TableOrderStatusStrip);
            this.Controls.Add(this.g_NextButton);
            this.Controls.Add(this.g_RemoveButton);
            this.Controls.Add(this.g_SeatButton);
            this.Controls.Add(this.g_BeveragePanel);
            this.Controls.Add(this.g_FoodItemPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "CTableOrderForm";
            this.ScreenTitle = "Table Order Form";
            this.Activated += new System.EventHandler(this.CTableOrderForm_Activated);
            this.Load += new System.EventHandler(this.CTableOrderForm_Load);
            this.Shown += new System.EventHandler(this.CTableOrderForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.CTableOrderForm_VisibleChanged);
            this.Controls.SetChildIndex(this.g_FoodItemPanel, 0);
            this.Controls.SetChildIndex(this.g_BeveragePanel, 0);
            this.Controls.SetChildIndex(this.g_SeatButton, 0);
            this.Controls.SetChildIndex(this.g_RemoveButton, 0);
            this.Controls.SetChildIndex(this.g_NextButton, 0);
            this.Controls.SetChildIndex(this.TableOrderStatusStrip, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.g_PreviousButton, 0);
            this.Controls.SetChildIndex(this.panel9, 0);
            this.Controls.SetChildIndex(this.g_Category3NextButton, 0);
            this.Controls.SetChildIndex(this.g_QuantityButton, 0);
            this.Controls.SetChildIndex(this.g_Category3PreviousButton, 0);
            this.Controls.SetChildIndex(this.panel10, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel11, 0);
            this.Controls.SetChildIndex(this.btnEditOrder, 0);
            this.Controls.SetChildIndex(this.btnNextParent, 0);
            this.Controls.SetChildIndex(this.g_PayCloseButton, 0);
            this.Controls.SetChildIndex(this.btnPrevParent, 0);
            this.Controls.SetChildIndex(this.delivaryfromkitchneButton, 0);
            this.Controls.SetChildIndex(this.membershipfunctionalButton, 0);
            this.Controls.SetChildIndex(this.g_ExitButton, 0);
            this.Controls.SetChildIndex(this.panel12, 0);
            this.Controls.SetChildIndex(this.g_ConvertButton, 0);
            this.Controls.SetChildIndex(this.functionalButton1, 0);
            this.g_FoodItemPanel.ResumeLayout(false);
            this.g_FoodItemPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_FoodDataGridView)).EndInit();
            this.g_BeveragePanel.ResumeLayout(false);
            this.g_BeveragePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_BeverageDataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TableOrderStatusStrip.ResumeLayout(false);
            this.TableOrderStatusStrip.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel g_Category2Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel g_ItemSelectionFlowLayoutPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel g_FoodItemPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel g_BeveragePanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label g_AmountLabel;
        private System.Windows.Forms.DataGridView g_FoodDataGridView;
        private System.Windows.Forms.DataGridView g_BeverageDataGridView;
        private System.Windows.Forms.StatusStrip TableOrderStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel UserStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel TableStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel TableValueStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel BillNoStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel GuestStatusLabel;
        private System.Windows.Forms.Label g_DiscountLabel;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label g_serviceCharge;
        private System.Windows.Forms.Label lbltips;
        private System.Windows.Forms.ToolTip tlTips;
        private System.Windows.Forms.Panel panel6;
        private RMSUI.FunctionalButton g_PreviousButton;
        private RMSUI.FunctionalButton g_NextButton;
        private RMSUI.FunctionalButton g_SendButton;
        private RMSUI.FunctionalButton g_MiscButton;
        private RMSUI.FunctionalButton btnKitchenText;
        private RMSUI.FunctionalButton g_RemoveButton;
        private RMSUI.FunctionalButton g_SeatButton;
        private RMSUI.FunctionalButton g_ServiceChargeButton;
        private RMSUI.FunctionalButton g_PromotionsButton;
        private RMSUI.FunctionalButton g_QuantityButton;
        private RMSUI.FunctionalButton g_PayCloseButton;
        private RMSUI.FunctionalButton g_ExitButton;
        private RMSUI.FunctionalButton g_PrintGuestBillButton;
        private RMSUI.FunctionalButton g_ItemDescriptionButton;
        private RMSUI.FunctionalButton g_SpecialButton;
        private RMSUI.FunctionalButton g_Category3NextButton;
        private RMSUI.FunctionalButton g_Category3PreviousButton;
        private RMSUI.FunctionalButton btnPLU;
        private RMSUI.FunctionalButton btnOrderLog;
        private RMSUI.FunctionalButton btnEditOrder;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lbvat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label g_SubtotalLabel;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.TextBox txtBoxSearchItem;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel foodMenuPanal;
        private RMSUI.FunctionalButton btnPrevParent;
        private RMSUI.FunctionalButton btnNextParent;
        private RMSUI.FunctionalButton btnSetOrderWaiter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private RMSUI.FunctionalButton g_ConvertButton;
        private RMSUI.FunctionalButton delivaryfromkitchneButton;
        private RMSUI.FunctionalButton membershipfunctionalButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMembershipDiscountValue;
        private RMSUI.FunctionalButton complementoryButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cat_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cat_rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_details_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn foodselect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn complementoryfood;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nonfoodselect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn complementorynonfood;
        private RMSUI.FunctionalButton itemComplementoryButton;
        private RMSUI.FunctionalButton vatComplementoryButton;
        private System.Windows.Forms.Panel panel12;
        private RMSUI.FunctionalButton functionalButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label totalItemWiseDiscountlabel;
    }
}