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

namespace BistroAdmin.UI
{
    public partial class SupplierPayment : UserControl
    {
        public SupplierPayment()
        {
            InitializeComponent();
           // this.AcceptButton = savePaymentbutton;
            //find out supplier
            purchaseActionlabel.Visible = false;
            SupplierBLL aSupplierBll = new SupplierBLL();
            List<Supplier> aSuppliers = new List<Supplier>();
            aSuppliers = aSupplierBll.GetAllSupplier();
            supplierNamecomboBox.DataSource = aSuppliers;
            supplierNamecomboBox.DisplayMember = "Name";
            supplierNamecomboBox.ValueMember = "SupplierId";
            dueOradvancelabel.Text = aSupplierBll.GetDueOrAdvance(aSuppliers, Convert.ToInt32(supplierNamecomboBox.SelectedValue));
            BookedPaymentTypeCombobox();
        }

        private void savePaymentbutton_Click(object sender, System.EventArgs e)
        {
            if (paidPricetextBox.Text.Length > 0)
            {
                try
                {
                   // Supplier aSupplier = (Supplier) supplierNamecomboBox.SelectedItem;
                    if (Convert.ToDouble(paidPricetextBox.Text) > 0)
                    {
                        SupplierBLL aSupplierBll = new SupplierBLL();
                        Supplier aSupplier =
                            aSupplierBll.GetSupplierByid(Convert.ToInt32(supplierNamecomboBox.SelectedValue));

                        Supplier aasSupplier = new Supplier();
                        aasSupplier.SupplierId = aSupplier.SupplierId;
                        aasSupplier.TotalAmount = aSupplier.TotalAmount;
                        aasSupplier.PaidAmount = Convert.ToDouble(paidPricetextBox.Text);
                        aasSupplier.PaymentType = (string)paymentTypecomboBox.SelectedItem;
                        aSupplierBll.InsertIntosupplier_payment_reportForSupplierPaymentTrack(aasSupplier);
                        aSupplier.PaidAmount += Convert.ToDouble(paidPricetextBox.Text);
                        aSupplierBll.UpdateSupplierForPurchase(aSupplier);
                        purchaseActionlabel.Visible = true;
                        purchaseActionlabel.Text = "Payment Successfully";
                        paidPricetextBox.Clear();
                    }
                    else MessageBox.Show("You cannot put zero balance!");


                }
                catch (Exception ex)
                {

                   // throw new Exception("Please check input format",ex);
                    MessageBox.Show("Please check input format");
                }
            }
            else MessageBox.Show("Please Check Paid Amount, May be Empty");
            
        }

        private void supplierNamecomboBox_SelectedIndexChanged(object sender, System.EventArgs e)
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
        private void BookedPaymentTypeCombobox()
        {
            paymentTypecomboBox.DataSource = new List<string>
                                                 {
                                                     "Cash",
                                                     "Cheque",
                                                     "Card"
                                                   //  "WithoutPayment"
                                                 };

        }
    }
}
