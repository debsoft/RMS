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

namespace RMS.MemberShipCardManage
{
    public partial class CMemberShipCardForm : BaseForm
    {
        private bool isDialogBox;

        private int row_index = 0;
        public bool ISDialogBox
        {
            get { return isDialogBox; }
            set { isDialogBox = value; }
        }


        private IMembershipCardDao membershipCardDao = new MembershipCardDao();

        private List<MembershipCard> membershipCardList = new List<MembershipCard>();


        public List<MembershipCard> MembershipCardListData
        {
            get { return membershipCardList; }
            set { membershipCardList = value; }
        }
        private MembershipCard membershipCard;

        public MembershipCard membershipCardData
        {
            get { return membershipCard; }
        }

        public CMemberShipCardForm()
        {
            InitializeComponent();
            dgvMembershipCard.RowCount = 17;
            LoadAllCustomerList();

            this.ScreenTitle = "Membership Card Info";
        }

        private void LoadAllCustomerList()
        {
            try
            {               

                if (!isDialogBox)
                {
                    membershipCardList = membershipCardDao.GetAllMembershipCard();
                }


                if (txtCode.Text != null && !txtCode.Text.ToString().Equals(""))
                { 
                    var data = (from c in membershipCardList  where c.code.Contains(txtCode.Text)
                                select c).ToList();

                    membershipCardList = data.ToList();
                 }
                else if (txtName.Text != null && !txtName.Text.ToString().Equals(""))
                {
                    var data = (from c in membershipCardList
                                where c.name.Contains(txtName.Text)
                                select c).ToList();

                    membershipCardList = data.ToList();
                }

                if (membershipCardList != null && membershipCardList.Count > 0)
                {
                    dgvMembershipCard.DataSource = membershipCardList;
                }
                else                    
                {
                    dgvMembershipCard.DataSource = null;
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
               // tempForm.Show();
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
            LoadAllCustomerList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerListForm.m_phoneNumber = String.Empty;
                CMemberShipCardAddForm tempCustomerInfoForm = new CMemberShipCardAddForm("Add", null);
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
                for (int rowIndex = 0; rowIndex < dgvMembershipCard.Rows.Count; rowIndex++)
                {
                    if (dgvMembershipCard.Rows[rowIndex].Selected == true && dgvMembershipCard.Rows[rowIndex].Cells["id"].Value != null)
                    {
                        long ID = Convert.ToInt64(dgvMembershipCard.Rows[rowIndex].Cells["id"].Value.ToString()); //for phone number
                       
                        
                        MembershipCard  membershipCard  = membershipCardDao.GetMembershipCardByID(ID);
                        
                        //CCustomerManager tempCustomerManager = new CCustomerManager();
                        //CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                        //CResult tempResult = tempCustomerManager.CustomerInfoGetByPhone(phone);

                        if (membershipCard != null )
                        {
                            
                            CMemberShipCardAddForm tempCustomerInfoForm = new CMemberShipCardAddForm("Update", membershipCard);
                            tempCustomerInfoForm.ISModify = true;
                            tempCustomerInfoForm.MembershipCardData = membershipCard;
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
                for (int recordCounter = 0; recordCounter < dgvMembershipCard.Rows.Count; recordCounter++)
                {
                    if (dgvMembershipCard.Rows[recordCounter].Selected == true && dgvMembershipCard.Rows[recordCounter].Cells["id"].Value != null)
                    {
                        DialogResult tempDialogResult = MessageBox.Show("WARNING!!!\nDeleting this Customer may also delete some other information.\nAre you sure to delete this Customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (tempDialogResult.Equals(DialogResult.No)) return;
                        else
                        {
                            long ID = Convert.ToInt64(dgvMembershipCard.Rows[recordCounter].Cells["id"].Value.ToString()); //for phone number

                            bool isTrue = membershipCardDao.DeleteMembershipCard(ID);
                            if (isTrue)
                            {                              
                                this.LoadAllCustomerList();
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
            LoadAllCustomerList();
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            this.LoadAllCustomerList();
        }

        private void dgvMembershipCard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMembershipCard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (isDialogBox)
            SelectMembershipCard();
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (isDialogBox)
                SelectMembershipCard();
        }

        private void SelectMembershipCard()
        {
            try
            {
                if (row_index == -1)
                    return;

                Form tempForm;
                bool isFound = false;
                //for (int rowIndex = 0; rowIndex < dgvMembershipCard.Rows.Count; rowIndex++)
                //{
                if (dgvMembershipCard.Rows[row_index].Selected == true && dgvMembershipCard.Rows[row_index].Cells["id"].Value != null)
                    {
                        long ID = Convert.ToInt64(dgvMembershipCard.Rows[row_index].Cells["id"].Value.ToString()); //for phone number

                         membershipCard = membershipCardDao.GetMembershipCardByID(ID);
                                              
                        this.DialogResult = DialogResult.OK;
                        isFound = true;

                    //     tempForm = CFormManager.Forms.Pop();
                  //      tempForm.Show();
                 //       this.Close();

                   
                        //if (tempResult.IsSuccess)
                        //{
                        //    CCustomerInfoForm tempCustomerInfoForm = new CCustomerInfoForm("Update", (CCustomerInfo)tempResult.Data);
                        //    tempCustomerInfoForm.Show();
                        //    CFormManager.Forms.Push(this);
                        //    this.Hide();                           
                        //}

                     //   break;
                    }
           //     }

                if (!isFound)
                {
                    this.DialogResult = DialogResult.No;
               ////     tempForm = CFormManager.Forms.Pop();
                //    tempForm.Show();
                //    this.Close();
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void dgvMembershipCard_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row_index = e.RowIndex;
        }

        
    }
}