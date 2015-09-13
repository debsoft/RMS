using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.User;
using RMS.Common.ObjectModel;
using RMS.Common;
using Managers.TableInfo;
using System.Net;
using RMSUI;
using RMS;
using RMS.Common.Constants;

namespace RMS.SystemManagement
{
    public partial class CUsersForm : BaseForm
    {       
        public CUsersForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            CUserInfoForm tempUserInfoForm = new CUserInfoForm("Add",null);
            tempUserInfoForm.Show();
            CFormManager.Forms.Push(this);
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int rowIndex = 0; rowIndex < UserDataGridView.Rows.Count; rowIndex++)
                {
                    if (UserDataGridView.Rows[rowIndex].Selected == true && UserDataGridView.Rows[rowIndex].Cells["UserIDColumn"].Value != null)
                    {
                        CUserManager tempUserManager = new CUserManager();

                        int tempUserID = int.Parse(UserDataGridView.Rows[rowIndex].Cells["UserIDColumn"].Value.ToString());
                        CUserInfo tempUserInfo = new CUserInfo();
                        tempUserInfo.UserID = tempUserID;

                        CResult tempResult = tempUserManager.GetUser(tempUserInfo);
                        if (tempResult.IsSuccess)
                        {
                            CUserInfoForm tempUserInfoForm = new CUserInfoForm("Update", (CUserInfo)tempResult.Data);
                            tempUserInfoForm.Show();
                            CFormManager.Forms.Push(this);
                            this.Hide();
                        }
                        break;
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            CCommonConstants tempCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            try
            {
                for (int rowIndex = 0; rowIndex < UserDataGridView.Rows.Count; rowIndex++)
                {
                    if (UserDataGridView.Rows[rowIndex].Selected == true && UserDataGridView.Rows[rowIndex].Cells["UserIDColumn"].Value != null)
                    {                        
                        int tempCurrentUserID = tempCommonConstants.UserInfo.UserID;
                        int tempHostUserID = int.Parse(UserDataGridView.Rows[rowIndex].Cells["UserIDColumn"].Value.ToString());
                        if (tempCurrentUserID == tempHostUserID)
                        {
                            MessageBox.Show("Host User cannot be deleted.");
                            return;
                        }

                        DialogResult tempDialogResult = MessageBox.Show("Are you sure you want to delete this User?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (tempDialogResult.Equals(DialogResult.No)) return;
                        else
                        {
                            CUserManager tempUserManager = new CUserManager();

                            int tempUserID = int.Parse(UserDataGridView.Rows[rowIndex].Cells["UserIDColumn"].Value.ToString());
                            CUserInfo tempUserInfo = new CUserInfo();
                            tempUserInfo.UserID = tempUserID;

                            CResult tempResult = tempUserManager.GetUser(tempUserInfo);
                            if (tempResult.IsSuccess)
                            {
                                tempResult = tempUserManager.DeleteUser((CUserInfo)tempResult.Data);
                                if (tempResult.IsSuccess)
                                {
                                    UserDataGridView.Rows.RemoveAt(rowIndex);
                                }
                            }
                            break;
                        }                        
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }            
        }
        
        public void PopulateUserDataGridView(List<CUserInfo> inUserList)
        {
            try
            {
                CUserInfo[] tempUsers = inUserList.ToArray();
                UserDataGridView.Rows.Clear();

                for (int arrayIndex = 0; arrayIndex < tempUsers.Length; arrayIndex++)
                {
                    int sl = arrayIndex + 1;
                    string tempType = "";
                    string tempStatus = "";                   

                   // if (tempUsers[arrayIndex].Type == 0) tempType = "Admin";
                   // else if (tempUsers[arrayIndex].Type == 1) tempType = "User";

                    tempType = CUserConstant.GetUSerConstant(tempUsers[arrayIndex].Type); 

                    if (tempUsers[arrayIndex].Status == 0) tempStatus = "Inactive";
                    else if (tempUsers[arrayIndex].Status == 1) tempStatus = "Active";
                  

                    String[] tempString ={ tempUsers[arrayIndex].UserID.ToString(), sl.ToString(), tempUsers[arrayIndex].UserName, tempType, tempStatus, tempUsers[arrayIndex].Gender };

                    UserDataGridView.Rows.Add(tempString);                              
                }
                if (UserDataGridView.RowCount < 19) UserDataGridView.RowCount = 19;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            } 
        }

        private void CUsersForm_Activated(object sender, EventArgs e)
        {
            try
            {
                CUserManager tempUserManager = new CUserManager();
                CResult tempResult = tempUserManager.GetAllUser();
                if (tempResult.IsSuccess)
                {
                    List<CUserInfo> tempUserList = new List<CUserInfo>();
                    tempUserList = (List<CUserInfo>)tempResult.Data;
                    this.PopulateUserDataGridView(tempUserList);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            } 
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {

        }
        
    }
}