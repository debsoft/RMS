using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BistroAdmin.BLL;
using Common.ObjectModel;

namespace RMSAdmin.UI
{
    public partial class ItemExpireDateShowForm : Form
    {
        private int itemId = 0;
        public ItemExpireDateShowForm(int Id)
        {
            InitializeComponent();
            itemId = Id;

        }

        private void ItemExpireDateShowForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            InventoryPurchaseBLL aInventoryPurchaseBll=new InventoryPurchaseBLL();
            List<InventoryPurchase> aInventoryPurchases = new List<InventoryPurchase>();
            aInventoryPurchases = aInventoryPurchaseBll.GetInventoryPurchaseById(itemId);
            aInventoryPurchases = aInventoryPurchases.OrderByDescending(a => a.Date).ToList();



            DateTime fromdate = DateTime.Now.Date;
            DateTime todate = DateTime.Now.Date;
            todate = todate.AddDays(1);
            fromdate = fromdate.Date;
            todate = todate.Date;
            todate = todate.AddSeconds(-1);
            List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
            InventoryStockReportBLL aBll = new InventoryStockReportBLL();
            aInventoryStockReports = aBll.GetInventoryStockReportBetweenDate(fromdate, todate);

            InventoryStockReport aInventoryStockReport = aInventoryStockReports.SingleOrDefault(a => a.ItemId == itemId);

            List<InventoryPurchase> tempInventoryPurchases = new List<InventoryPurchase>();
            double sum = 0;

            foreach (InventoryPurchase inventoryPurchase in aInventoryPurchases)
            {
                
                sum += inventoryPurchase.Quantity;
                if(sum >= aInventoryStockReport.BalanceQty)
                {
                    double qty = sum - aInventoryStockReport.BalanceQty;
                    inventoryPurchase.Quantity -= qty;
                    tempInventoryPurchases.Add(inventoryPurchase);
                    break;
                }
                else tempInventoryPurchases.Add(inventoryPurchase);
            }


            var item = tempInventoryPurchases.Select(a => new { ItemName = a.Item.ItemName, Qty = a.Quantity, ExpireDate = a.ExpireDate, PurchaseDate = a.Date }).ToList();
            itemShowDataGridView.DataSource = item;

        }
    }
}
