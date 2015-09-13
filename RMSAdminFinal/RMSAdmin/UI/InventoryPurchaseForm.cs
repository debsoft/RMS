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
using Microsoft.ReportingServices.ReportRendering;
using RMS;
using RMS.Common.ObjectModel;

namespace BistroAdmin.UI
{
    public partial class InventoryPurchaseForm :UserControl
    {
        public InventoryPurchaseForm()
        {
          
            InitializeComponent();
          //  this.AcceptButton=savePurchasebutton;
            purchaseActionlabel.Visible = false;
            //Find out category
            List<InventoryCategory> aaList=new List<InventoryCategory>();
            InventoryCategoryBLL aBll=new InventoryCategoryBLL();
            aaList = aBll.GetAllCategory();
            categoryNamecomboBox.DataSource = aaList;
            categoryNamecomboBox.DisplayMember = "CategoryName";
            categoryNamecomboBox.ValueMember = "CategoryId";

           

            //findout item
            InventoryItemBLL aaBll = new InventoryItemBLL();
            List<InventoryItem> aList = new List<InventoryItem>();
            Int32 category = Convert.ToInt32(categoryNamecomboBox.SelectedValue);
            aList = aaBll.GetItemByCategory(category);
            itemNamecomboBox.DataSource = aList;
            itemNamecomboBox.DisplayMember = "ItemName";
            itemNamecomboBox.ValueMember = "ItemId";

            //find out unit
            //int unitId = aaList[categoryNamecomboBox.SelectedIndex].UnitId;
            //UnitCreateBLL aCreateBll = new UnitCreateBLL();
            //Unit aUnit = new Unit();
            //aUnit = aCreateBll.GetUnitByUnitId(unitId);
            try
            {
                unittypelabel.Text = aList[itemNamecomboBox.SelectedIndex].UnitName;
            }
            catch (Exception)
            {
                
            }
        

            //find out supplier
            SupplierBLL aSupplierBll=new SupplierBLL();
            List<Supplier>aSuppliers=new List<Supplier>();
            aSuppliers = aSupplierBll.GetAllSupplier();
            supplierNamecomboBox.DataSource = aSuppliers;
            supplierNamecomboBox.DisplayMember = "Name";
            supplierNamecomboBox.ValueMember = "SupplierId";
            dueOradvancelabel.Text = aSupplierBll.GetDueOrAdvance(aSuppliers,Convert.ToInt32(supplierNamecomboBox.SelectedValue));
            BookedPaymentTypeCombobox();



        }

        private void BookedPaymentTypeCombobox()
        {
            paymentTypecomboBox.DataSource = new List<string>
                                                 {
                                                     "Cash",
                                                     "Cheque",
                                                     "Card",
                                                     "WithoutPayment"
                                                 };

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
                InventoryCategory aInventoryCategory =(InventoryCategory) categoryNamecomboBox.Items[categoryNamecomboBox.SelectedIndex];
                UnitCreateBLL aCreateBll = new UnitCreateBLL();
                //Unit aUnit = new Unit();
                //aUnit = aCreateBll.GetUnitByUnitId(aInventoryCategory.UnitId);
                //unittypelabel.Text = aUnit.UnitName;

                aList = aBll.GetItemByCategory(category);
                itemNamecomboBox.DataSource = aList;
                itemNamecomboBox.DisplayMember = "ItemName";
                itemNamecomboBox.ValueMember = "ItemId";
                if (Convert.ToInt32(itemNamecomboBox.SelectedValue) > 0)
                {
                    InventoryItem aItem = new InventoryItem();
                    aItem = (InventoryItem)itemNamecomboBox.SelectedItem;
                    unittypelabel.Text = aItem.UnitName;
                }
            }

            }
            catch 
            {

             
            }
        }

        private void supplierNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierBLL aSupplierBll = new SupplierBLL();
            List<Supplier> aSuppliers = new List<Supplier>();
            aSuppliers = aSupplierBll.GetAllSupplier();
            try
            {
                dueOradvancelabel.Text = aSupplierBll.GetDueOrAdvance(aSuppliers, Convert.ToInt32(supplierNamecomboBox.SelectedValue));
            }
            catch 
            {
                

            }
            

        }

        private void savePurchasebutton_Click(object sender, EventArgs e)
        {

            try
            {

                if (expiredateTimePicker.Value.Date == DateTime.Now.Date)
                {
                    DialogResult result = MessageBox.Show("Do you want to Empty Expire Date?", "Confirmation",
                                                          MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }

                }


                if (pricetextBox.Text.Length != 0 && paidPricetextBox.Text.Length != 0 && quantitytextBox.Text.Length != 0)
                {
                    InventoryPurchase aInventoryPurchase = new InventoryPurchase();
                    InventoryCategory aCategory = new InventoryCategory();
                    InventoryItem aItem = new InventoryItem();
                    Supplier aSupplier = new Supplier();
                    Supplier aaSupplier = new Supplier();
                    Unit aUnit = new Unit();


                    //Add for purchase record
                    aCategory = (InventoryCategory) categoryNamecomboBox.Items[categoryNamecomboBox.SelectedIndex];

                    SupplierBLL aSupplierBll = new SupplierBLL();
                    aSupplier = aSupplierBll.GetSupplierByid(Convert.ToInt32(supplierNamecomboBox.SelectedValue));
                   // aSupplier = (Supplier) supplierNamecomboBox.Items[supplierNamecomboBox.SelectedIndex];
                    if (aSupplier.PaidAmount > aSupplier.TotalAmount)
                    {
                        aSupplier.AdvanceAmount = aSupplier.PaidAmount - aSupplier.TotalAmount;
                    }
                    else aSupplier.DueAmount = aSupplier.TotalAmount - aSupplier.PaidAmount;

                    aItem = (InventoryItem) itemNamecomboBox.Items[itemNamecomboBox.SelectedIndex];
                    aInventoryPurchase.Quantity = Convert.ToDouble(quantitytextBox.Text);
                    aInventoryPurchase.Price = Convert.ToDouble(pricetextBox.Text);
                    aInventoryPurchase.Date = DateTime.Now;
                    aInventoryPurchase.Category = aCategory;
                    aInventoryPurchase.Item = aItem;
                    aaSupplier.PaidAmount = Convert.ToDouble(paidPricetextBox.Text);
                    aInventoryPurchase.Supplier = aaSupplier;
                    if (((aSupplier.DueAmount + Convert.ToDouble(pricetextBox.Text) -
                          (Convert.ToDouble(paidPricetextBox.Text) + aSupplier.AdvanceAmount))) >= 0)
                        aInventoryPurchase.Supplier.DueAmount = aSupplier.DueAmount +
                                                                Convert.ToDouble(pricetextBox.Text) -
                                                                (Convert.ToDouble(paidPricetextBox.Text) +
                                                                 aSupplier.AdvanceAmount);
                    else aInventoryPurchase.Supplier.DueAmount = 0.0;
                    if (((Convert.ToDouble(paidPricetextBox.Text) + aSupplier.AdvanceAmount) -
                         (aSupplier.DueAmount + Convert.ToDouble(pricetextBox.Text))) >= 0)
                    {
                        aInventoryPurchase.Supplier.AdvanceAmount = (Convert.ToDouble(paidPricetextBox.Text) +
                                                                     aSupplier.AdvanceAmount) -
                                                                    (aSupplier.DueAmount +
                                                                     Convert.ToDouble(pricetextBox.Text));
                    }
                    else aInventoryPurchase.Supplier.AdvanceAmount = 0.0;
                    aInventoryPurchase.Supplier.Name = aSupplier.Name;
                    aInventoryPurchase.Supplier.SupplierId = aSupplier.SupplierId;
                    aUnit.UnitName = unittypelabel.Text;
                    aInventoryPurchase.Unit = aUnit;
                    CUserInfo aUserInfo= new CUserInfo();
                    aUserInfo.UserName= RMSGlobal.LogInUserName;
                    aInventoryPurchase.PaymentType= paymentTypecomboBox.SelectedItem.ToString();
                    aInventoryPurchase.CUserInfo= aUserInfo;
                    if (expiredateTimePicker.Value.Date == DateTime.Now.Date)
                    {
                        
                    }
                    else
                    {
                        aInventoryPurchase.ExpireDate = expiredateTimePicker.Value.Date;
                    }


                    string res = string.Empty;

                    InventoryPurchaseBLL aInventoryPurchaseBll = new InventoryPurchaseBLL();
                    res = aInventoryPurchaseBll.InsertPurchase(aInventoryPurchase);

                    
                    if(res=="Purchase Insert Sucessfully")
                    {
                        //Add for Supplier Update
                        aSupplier.TotalAmount += Convert.ToDouble(pricetextBox.Text);
                        aSupplier.PaidAmount += Convert.ToDouble(paidPricetextBox.Text);
                       
                        aSupplierBll.UpdateSupplierForPurchase(aSupplier);

                        //Add for Supplier payment report
                        Supplier paymentSupplier=new Supplier();
                        paymentSupplier.PaidAmount = Convert.ToDouble(paidPricetextBox.Text);
                        paymentSupplier.TotalAmount = Convert.ToDouble(pricetextBox.Text);
                        paymentSupplier.SupplierId = aSupplier.SupplierId;
                        paymentSupplier.PaymentType = paymentTypecomboBox.SelectedItem.ToString();
                        aSupplierBll.InsertIntosupplier_payment_reportForSupplierPaymentTrack(paymentSupplier);


                        //Add for stock update
                        Stock aStock=new Stock();
                        aStock.Category = aCategory;
                        aStock.Item = aItem;
                        aStock.Unit = aUnit;
                        aStock.Stocks = Convert.ToDouble(quantitytextBox.Text);
                        aStock.UnitPrice = Convert.ToDouble(pricetextBox.Text)/aStock.Stocks;
                        StockBLL aStockBll=new StockBLL();
                        aStockBll.InsertStockOrUpdate(aStock);




                        purchaseActionlabel.Visible = true;
                        purchaseActionlabel.Text = res;
                        Clear();
                    }else
                    {
                        purchaseActionlabel.Visible = true;
                        purchaseActionlabel.Text = res;
                    }

                }else
                {
                    purchaseActionlabel.Visible = true;
                    purchaseActionlabel.Text = "Please Check Your Input";
                }


            }
            catch
            {
                MessageBox.Show("Try Again May Be Your Given Input Format Not Correct Please Given Again ");

            }



        }

        private void Clear()
        {
            quantitytextBox.Clear();
            paidPricetextBox.Clear();
            pricetextBox.Clear();
        }

        private void itemNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

           
            if (Convert.ToInt32(itemNamecomboBox.SelectedValue) > 0)
            {
                InventoryItem aItem = new InventoryItem();
                aItem=(InventoryItem)itemNamecomboBox.SelectedItem;
                unittypelabel.Text = aItem.UnitName;
            }
            }
            catch
            {

            }
        }

        private void purchaseActionlabel_Click(object sender, EventArgs e)
        {

        }
    }
}
