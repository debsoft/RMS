using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.DataAccess;
using System.Data.SqlClient;
using RMS.Common;
using RMS.Common.ObjectModel;
using Managers.Customer;
using RMS.TakeAway;
using RMSUI;
using RMS.Common.DataAccess;
using RMSClient.DataAccess;
using System.Linq;


namespace RMS.MemberShipCardNoManage
{
    public partial class CMemberShipForm : BaseForm
    {

        private IMembershipDao membershipDao = new MembershipDao();

        private bool isDialogBox;

        public bool ISDialogBox
        {
            get { return isDialogBox; }
            set { isDialogBox = value; }
        }
        
        private List<Membership> membershipList = new List<Membership>();


        public List<Membership> MembershipListData
        {
            get { return membershipList; }
            set { membershipList = value; }
        }
        private Membership membership;

        public Membership membershipData
        {
            get { return membership; }
        }
        
        public CMemberShipForm()
        {
            InitializeComponent();
            dgvMembership.RowCount = 17;
            LoadAllMemberShipList();

            this.ScreenTitle = "Membership Info";
        }

        private void LoadAllMemberShipList()
        {
            try
            {        
                List<Membership> membershipList = membershipDao.GetAllMembership();




                if (txtCode.Text != null && !txtCode.Text.ToString().Equals(""))
                {
                    var data = (from c in membershipList
                                where c.membershipCardCode.Contains(txtCode.Text)
                                select c).ToList();

                    membershipList = data.ToList();
                }
                else if (txtName.Text != null && !txtName.Text.ToString().Equals(""))
                {
                    var data = (from c in membershipList
                                where c.customerName.Contains(txtName.Text)
                                select c).ToList();

                    membershipList = data.ToList();
                }


                if (membershipList != null && membershipList.Count > 0)
                {
                    dgvMembership.DataSource = membershipList;
                }
                else
                {
                    dgvMembership.DataSource = null;
                }

            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Form tempForm = CFormManager.Forms.Pop();
                //tempForm.Show();
                this.Close();
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void NameTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                CWinKeyboardForm tempKeyboardForm = new CWinKeyboardForm("Search", "Enter Customer Name to search");
                tempKeyboardForm.ShowDialog();

                if (CWinKeyboardForm.Content.Equals("Cancel"))
                {
                    txtName.Clear();
                    return;
                }

                txtName.Text = CWinKeyboardForm.Content;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void PhoneTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                CWinKeyboardForm tempKeyboardForm = new CWinKeyboardForm("Search", "Enter Customer Name to search");
                tempKeyboardForm.ShowDialog();

                if (CWinKeyboardForm.Content.Equals("Cancel"))
                {
                    txtCode.Clear();
                    return;
                }
                txtCode.Text = CWinKeyboardForm.Content;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadAllMemberShipList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
               // CMemberShipAddForm.m_phoneNumber = String.Empty;
                CMemberShipAddForm tempCustomerInfoForm = new CMemberShipAddForm("Add", null);
                tempCustomerInfoForm.ShowDialog();
                //CFormManager.Forms.Push(this);
                //this.Hide();               
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Modified by Baruri at 12.12.2008 for the new customer address format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int rowIndex = 0; rowIndex < dgvMembership.Rows.Count; rowIndex++)
                {
                    if (dgvMembership.Rows[rowIndex].Selected == true && dgvMembership.Rows[rowIndex].Cells["id"].Value != null)
                    {
                        long ID = Convert.ToInt64(dgvMembership.Rows[rowIndex].Cells["id"].Value.ToString()); //for phone number
                       
                        
                        Membership  membership = membershipDao.GetMembershipByID(ID);
                        
                        //CCustomerManager tempCustomerManager = new CCustomerManager();
                        //CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                        //CResult tempResult = tempCustomerManager.CustomerInfoGetByPhone(phone);

                        if (membership != null )
                        {
                            CMemberShipAddForm tempCustomerInfoForm = new CMemberShipAddForm();
                            tempCustomerInfoForm.ISModify = true;
                            tempCustomerInfoForm.MembershipData = membership;
                            tempCustomerInfoForm.ShowDialog();
                            //CFormManager.Forms.Push(this);
                            //this.Hide();          
                 
                        }
                        break;
                    }
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int recordCounter = 0; recordCounter < dgvMembership.Rows.Count; recordCounter++)
                {
                    if (dgvMembership.Rows[recordCounter].Selected == true && dgvMembership.Rows[recordCounter].Cells["id"].Value != null)
                    {
                        DialogResult tempDialogResult = MessageBox.Show("WARNING!!!\nDeleting this Customer may also delete some other information.\nAre you sure to delete this Customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (tempDialogResult.Equals(DialogResult.No)) return;
                        else
                        {
                            long ID = Convert.ToInt64(dgvMembership.Rows[recordCounter].Cells["id"].Value.ToString()); //for phone number

                            bool isTrue = membershipDao.DeleteMembership(ID);
                            if (isTrue)
                            {
                                this.LoadAllMemberShipList();
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void CCustomerForm_VisibleChanged(object sender, EventArgs e)
        {
            LoadAllMemberShipList();
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            this.LoadAllMemberShipList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (isDialogBox)
                SelectMembership();
        }

        private void SelectMembership()
        {
            try
            {
                Form tempForm;
                bool isFound = false;
                for (int rowIndex = 0; rowIndex < dgvMembership.Rows.Count; rowIndex++)
                {
                    if (dgvMembership.Rows[rowIndex].Selected == true && dgvMembership.Rows[rowIndex].Cells["id"].Value != null)
                    {
                        long ID = Convert.ToInt64(dgvMembership.Rows[rowIndex].Cells["id"].Value.ToString()); //for phone number

                        membership = membershipDao.GetMembershipByID(ID);

                        this.DialogResult = DialogResult.OK;
                        isFound = true;

                 //       tempForm = CFormManager.Forms.Pop();
              //          tempForm.Show();
                   //     this.Close();


                        //if (tempResult.IsSuccess)
                        //{
                        //    CCustomerInfoForm tempCustomerInfoForm = new CCustomerInfoForm("Update", (CCustomerInfo)tempResult.Data);
                        //    tempCustomerInfoForm.Show();
                        //    CFormManager.Forms.Push(this);
                        //    this.Hide();                           
                        //}

                        break;
                    }
                }

                if (!isFound)
                {
                    this.DialogResult = DialogResult.No;
               //     tempForm = CFormManager.Forms.Pop();
               //     tempForm.Show();
               //     this.Close();
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
    }
}