using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BistroAdmin.BLL;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS;
using RMS.Common.ObjectModel;

namespace BistroAdmin.UI
{
    public partial class TransactionForm : UserControl
    {
        public TransactionForm()
        {
            InitializeComponent();
          //  this.AcceptButton = saveTransactionbutton;
            transactionActionlabel.Visible = false;
            List<InventoryCategory> aaList = new List<InventoryCategory>();
            InventoryCategoryBLL aBll = new InventoryCategoryBLL();
            aaList = aBll.GetAllCategory();
            categoryNamecomboBox.DataSource = aaList;
            categoryNamecomboBox.DisplayMember = "CategoryName";
            categoryNamecomboBox.ValueMember = "CategoryId";

            //findout item
            try
            {
                InventoryItemBLL aaBll = new InventoryItemBLL();
                List<InventoryItem> aList = new List<InventoryItem>();
                Int32 category = Convert.ToInt32(categoryNamecomboBox.SelectedValue);
                aList = aaBll.GetItemByCategory(category);
                itemNamecomboBox.DataSource = aList;
                itemNamecomboBox.DisplayMember = "ItemName";
                itemNamecomboBox.ValueMember = "ItemId";
                InventoryItem aItem = new InventoryItem();
                aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
                unittypelabel.Text = aItem.UnitName;
            }
            catch (Exception)
            {
                
           
            }
        



            // This used for package activation
           // BookedTransactionTypecomboboxForBusiness();// when Businees Package is active
            BookedTransactionTypecomboboxForProfessional();// when When Professional Package is active

        }

        private void BookedTransactionTypecomboboxForBusiness()
        {
            transactionTypecomboBox.DataSource = new List<string>
                                                 {
                                                     "Stock In",
                                                     "Damage_in_kitchen"
                                                 };
        }

        private void BookedTransactionTypecomboboxForProfessional()
        {
            transactionTypecomboBox.DataSource = new List<string>
                                                 {
                                                     "Send_to_Kitchen",
                                                     "Return_from_Kitchen",
                                                     "Damage_in_kitchen",
                                                     "Damage_in_Stock",
                                                     "Stock_Out_In_Kitchen"
                                                 };
        }

        private void saveTransactionbutton_Click(object sender, EventArgs e)
        {
            try
            {
               

            if (quantitytextBox.Text.Length > 0)
            {


                // This used for package activation

                TransactionWhenProfessionalPackageIsActive();//when Professional Package is active
              // TransactionWhenBusinessPackageIsActive();//when Business Package is active
               

                

            }
            else MessageBox.Show("Please Check Your Input");

            }
            catch
            {
                MessageBox.Show("Please Check Your Input");

            }


        }

        private void TransactionWhenBusinessPackageIsActive()
        {
             InventoryItem aItem = new InventoryItem();
            aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
            InventoryCategory aInventoryCategory = new InventoryCategory();
            aInventoryCategory = (InventoryCategory)categoryNamecomboBox.SelectedItem;


            Stock aStock = new Stock();
            StockBLL aStockBll = new StockBLL();
            string transactiontype = transactionTypecomboBox.SelectedItem.ToString();
            Transaction aTransaction = new Transaction();
            aTransaction.TransactionDate = DateTime.Now;
            aTransaction.Item = aItem;
            aTransaction.Category = aInventoryCategory;
            aTransaction.TransactionType = transactiontype;
            CUserInfo aUserInfo = new CUserInfo();
            aUserInfo.UserName = RMSGlobal.LogInUserName;
            aTransaction.UserInfo = aUserInfo;
            string sr = string.Empty;
           

            if (transactiontype == "Stock In")
            {
               // aStock = aStockBll.GetStockByItemid(aItem.ItemId);

                if ( (Convert.ToDouble(quantitytextBox.Text) != 0))
                {
                    aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                    aStock.Item = aItem;
                    aStock.Category = aInventoryCategory;
                    aTransaction.Stock = aStock;
                    TransactionBLL aBll = new TransactionBLL();
                    sr = aBll.SendToKitchen(aTransaction);
                    ShowAndClear(sr);
                }
                else MessageBox.Show("Your Quantity Must be Greater than 0 and  less than or equal to " + aStock.Stocks + " " + unittypelabel.Text);
            }

            //aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);
           

            if (transactiontype == "Damage_in_kitchen")
            {
                if (danmagetextBox.Text.Length > 0)
                {
                    aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);

                    if ((aStock.Stocks >= Convert.ToDouble(quantitytextBox.Text)) &&
                        (Convert.ToDouble(quantitytextBox.Text) != 0))
                    {
                        aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                        aStock.Item = aItem;
                        aStock.Category = aInventoryCategory;
                        aTransaction.Stock = aStock;
                        aTransaction.DamageReport = danmagetextBox.Text.Replace("'","''");

                        TransactionBLL aBll = new TransactionBLL();
                        sr = aBll.DamageInKitchen(aTransaction);
                        ShowAndClear(sr);
                    }
                    else
                        MessageBox.Show("Your Quantity Must be Greater than 0 and  less than or equal to  " + aStock.Stocks + " " +
                                        unittypelabel.Text);
                }
                else MessageBox.Show("Please Check Your Damage Report Field It's Never Empty");
            }
        }

        private void TransactionWhenProfessionalPackageIsActive()
        {


            InventoryItem aItem = new InventoryItem();
            aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
            InventoryCategory aInventoryCategory = new InventoryCategory();
            aInventoryCategory = (InventoryCategory)categoryNamecomboBox.SelectedItem;


            Stock aStock = new Stock();
            StockBLL aStockBll = new StockBLL();
            string transactiontype = transactionTypecomboBox.SelectedItem.ToString();
            Transaction aTransaction = new Transaction();
            aTransaction.TransactionDate = DateTime.Now;
            aTransaction.Item = aItem;
            aTransaction.Category = aInventoryCategory;
            aTransaction.TransactionType = transactiontype;
            CUserInfo aUserInfo = new CUserInfo();
            aUserInfo.UserName = RMSGlobal.LogInUserName;
            aTransaction.UserInfo = aUserInfo;
            string sr = string.Empty;
            if (transactiontype == "Damage_in_Stock")
            {
                if (danmagetextBox.Text.Length > 0)
                {
                    aStock = aStockBll.GetStockByItemid(aItem.ItemId);

                    if ((aStock.Stocks >= Convert.ToDouble(quantitytextBox.Text)) &&
                        (Convert.ToDouble(quantitytextBox.Text) != 0))
                    {
                        aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                        aStock.Item = aItem;
                        aStock.Category = aInventoryCategory;
                        aTransaction.Stock = aStock;
                        aTransaction.DamageReport = danmagetextBox.Text.Replace("'", "''");

                        TransactionBLL aBll = new TransactionBLL();
                        sr = aBll.DamageInStock(aTransaction);
                        ShowAndClear(sr);
                    }
                    else
                        MessageBox.Show("Your Quantity Must be Greater than 0 and  less than or equal to  " + aStock.Stocks + " " +
                                        unittypelabel.Text);
                }
                else MessageBox.Show("Please Check Your Damage Report Field It's Never Empty");
            }

            if (transactiontype == "Send_to_Kitchen")
            {
                aStock = aStockBll.GetStockByItemid(aItem.ItemId);

                if ((aStock.Stocks >= Convert.ToDouble(quantitytextBox.Text)) && (Convert.ToDouble(quantitytextBox.Text) != 0))
                {
                    aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                    aStock.Item = aItem;
                    aStock.Category = aInventoryCategory;
                    aTransaction.Stock = aStock;
                    TransactionBLL aBll = new TransactionBLL();
                    sr = aBll.SendToKitchen(aTransaction);
                    ShowAndClear(sr);
                }
                else MessageBox.Show("Your Quantity Must be Greater than 0 and  less than or equal to " + aStock.Stocks + " " + unittypelabel.Text);
            }

            //aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);
            if (transactiontype == "Return_from_Kitchen")
            {
                aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);

                if ((aStock.Stocks >= Convert.ToDouble(quantitytextBox.Text)) && (Convert.ToDouble(quantitytextBox.Text) != 0))
                {
                    aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                    aStock.Item = aItem;
                    aStock.Category = aInventoryCategory;
                    aTransaction.Stock = aStock;
                    TransactionBLL aBll = new TransactionBLL();
                    sr = aBll.ReturnFromKitchen(aTransaction);
                    ShowAndClear(sr);
                }
                else MessageBox.Show("Your Quantity Must be Greater than 0 and  less than or equal to " + aStock.Stocks + " " + unittypelabel.Text);
            }

            if (transactiontype == "Damage_in_kitchen")
            {
                if (danmagetextBox.Text.Length > 0)
                {
                    aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);

                    if ((aStock.Stocks >= Convert.ToDouble(quantitytextBox.Text)) &&
                        (Convert.ToDouble(quantitytextBox.Text) != 0))
                    {
                        aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                        aStock.Item = aItem;
                        aStock.Category = aInventoryCategory;
                        aTransaction.Stock = aStock;
                        aTransaction.DamageReport = danmagetextBox.Text.Replace("'", "''");

                        TransactionBLL aBll = new TransactionBLL();
                        sr = aBll.DamageInKitchen(aTransaction);
                        ShowAndClear(sr);
                    }
                    else
                        MessageBox.Show("Your Quantity Must be Greater than 0 and  less than or equal to  " + aStock.Stocks + " " +
                                        unittypelabel.Text);
                }
                else MessageBox.Show("Please Check Your Damage Report Field It's Never Empty");
            }

            if (transactiontype == "Stock_Out_In_Kitchen")
            {
                if (danmagetextBox.Text.Length > 0)
                {
                    aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);

                    if ((aStock.Stocks >= Convert.ToDouble(quantitytextBox.Text)) &&
                        (Convert.ToDouble(quantitytextBox.Text) != 0))
                    {
                        aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                        aStock.Item = aItem;
                        aStock.Category = aInventoryCategory;
                        aTransaction.Stock = aStock;
                        aTransaction.DamageReport = danmagetextBox.Text.Replace("'", "''");

                        TransactionBLL aBll = new TransactionBLL();
                        sr = aBll.SendOutInKitchen(aTransaction);

                        StockDAO aStockDao=new StockDAO();
                        aStockDao.InsertOrUpdateSaleRawmaterialsReport(aTransaction.Item.ItemId, Convert.ToDouble(quantitytextBox.Text),aStock.UnitPrice);
                        ShowAndClear(sr);
                    }
                    else
                        MessageBox.Show("Your Quantity Must be Greater than 0 and  less than or equal to  " + aStock.Stocks + " " +
                                        unittypelabel.Text);
                }
                else MessageBox.Show("Please Check Your Damage Report Field It's Never Empty");
            }

        }

        private void ShowAndClear( string sr)
        {
            transactionActionlabel.Visible = true;
            transactionActionlabel.Text = sr;
            quantitytextBox.Clear();
            danmagetextBox.Clear();
        }

        private void categoryNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(categoryNamecomboBox.SelectedValue) > 0)
                {
                    InventoryItemBLL aBll = new InventoryItemBLL();
                    List<InventoryItem> aList = new List<InventoryItem>();

                    Int32 category = Convert.ToInt32(categoryNamecomboBox.SelectedValue);

                    aList = aBll.GetItemByCategory(category);
                    itemNamecomboBox.DataSource = aList;
                    itemNamecomboBox.DisplayMember = "ItemName";
                    itemNamecomboBox.ValueMember = "ItemId";
                    unittypelabel.Text = aList[itemNamecomboBox.SelectedIndex].UnitName;

                }

            }
            catch
            {


            }
        }

        private void itemNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (Convert.ToInt32(itemNamecomboBox.SelectedValue) > 0)
                {
                    InventoryItem aItem = new InventoryItem();
                    aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
                    unittypelabel.Text = aItem.UnitName;

                    string transactiontype = transactionTypecomboBox.SelectedItem.ToString();
                    if (transactiontype == "Send_to_Kitchen" || transactiontype == "Damage_in_Stock")
                    {
                        if (transactiontype == "Damage_in_Stock")
                        {
                            ShowDamageField();
                        }
                        else if (transactiontype == "Send_to_Kitchen")
                        {
                            HideDamageField();
                        }
                        aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
                        Stock aStock = new Stock();
                        StockBLL aStockBll = new StockBLL();
                        aStock = aStockBll.GetStockByItemid(aItem.ItemId);
                        stocklabel.Visible = true;
                        stocklabel.Text = "Now Current Stocks are " + aStock.Stocks + " " + unittypelabel.Text;
                    }

                    if (transactiontype == "Return_from_Kitchen" || transactiontype == "Damage_in_kitchen" || transactiontype == "Stock In" )
                    {
                        if (transactiontype == "Damage_in_kitchen")
                        {
                            ShowDamageField();
                        }
                        else if (transactiontype == "Return_from_Kitchen")
                        {
                            HideDamageField();
                        }

                        else if (transactiontype == "Stock In")
                        {
                            HideDamageField();
                        }
                        aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
                        Stock aStock = new Stock();
                        StockBLL aStockBll = new StockBLL();
                        aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);
                        stocklabel.Visible = true;
                        stocklabel.Text = "Now Current Kitchen Stocks are " + aStock.Stocks + " " + unittypelabel.Text;
                    }
                }
            }
            catch
            {

            }
        }

        private void transactionTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

          
            InventoryItem aItem = new InventoryItem();
            string transactiontype = transactionTypecomboBox.SelectedItem.ToString();
            if (transactiontype == "Send_to_Kitchen"||transactiontype == "Damage_in_Stock")
            {
                if (transactiontype == "Damage_in_Stock")
                {
                    ShowDamageField();
                }
                else if (transactiontype == "Send_to_Kitchen")
                {
                    HideDamageField();
                }
                aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
                Stock aStock = new Stock();
                StockBLL aStockBll = new StockBLL();
                aStock = aStockBll.GetStockByItemid(aItem.ItemId);
                stocklabel.Visible = true;
                stocklabel.Text = "Now Current Stocks are " + aStock.Stocks + " " + unittypelabel.Text;
            }
            if (transactiontype == "Return_from_Kitchen" || transactiontype == "Damage_in_kitchen" || transactiontype == "Stock In" || transactiontype == "Stock_Out_In_Kitchen")
            {
                if (transactiontype == "Damage_in_kitchen" || transactiontype == "Stock_Out_In_Kitchen")
                {
                    ShowDamageField();
                }
                else if (transactiontype == "Return_from_Kitchen")
                {
                    HideDamageField();
                }

                else if (transactiontype == "Stock In")
                {
                    HideDamageField();
                }
                aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
                Stock aStock = new Stock();
                StockBLL aStockBll = new StockBLL();
                aStock = aStockBll.GetStockByItemidFrominventory_kitchen_stock(aItem);
                stocklabel.Visible = true;
                stocklabel.Text = "Now Current Kitchen Stocks are " + aStock.Stocks + " " + unittypelabel.Text;
            }
            }
            catch (Exception)
            {
            }
        }

        private void HideDamageField()
        {
            danmagetextBox.Visible = false;
            damagelabel.Visible = false;
        }

        private void ShowDamageField()
        {
            danmagetextBox.Visible = true;
            damagelabel.Visible = true;

        }
    }
}
