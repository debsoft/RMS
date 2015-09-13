using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using Managers.User;
using RMS.Common.Config;
using RMS;
using System.Diagnostics;
using RMS.DataAccess;
using RMS.Common;
using System.Threading;

namespace RmsRemote
{
    public class CLogin : MarshalByRefObject
    {
        private Mutex m_mPrintMutex;
        private CPrintingFormat m_oPrintRequest;

        public CLogin()
        {

        }

        public CResult ProcessLogout(CUserInfo inUserInfo)
        {
            CUserManager oManager = new CUserManager();

            CResult oResult = oManager.LogoutUser(inUserInfo);


            if (oResult.IsSuccess && oResult.Data != null)
            {

            }

            return oResult;
        }

        public CResult ProcessLogin(CUserInfo inUserInfo)
        {


            CResult oNewResult = new CResult();

            try
            {

                CUserManager oManager = new CUserManager();



                CResult oResult = oManager.LoginUser(inUserInfo);



                if (oResult.IsSuccess && oResult.Data != null)
                {


                    CUserInfo oUser = (CUserInfo)oResult.Data;

                    CResult oResult2 = oManager.GetUserAccess(oUser);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {


                        CUserAccess oUserAccess = (CUserAccess)oResult2.Data;

                        oUser.UserAccess = oUserAccess;

                        CUserLogin oUserLogin = new CUserLogin();

                        oUserLogin.UserInfo = oUser;

                        CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();



                        String tempConnStr = oTempDal.ConnectionString;

                        oUserLogin.ConnectionStr = tempConnStr;



                        oNewResult.Data = oUserLogin;

                        oNewResult.IsSuccess = true;

                    }

                }

            }
            catch (Exception ex)
            {
            }



            return oNewResult;
        }

        public CResult ProcessAdminLogin(CUserInfo inUserInfo)
        {


            CResult oNewResult = new CResult();

            try
            {

                CUserManager oManager = new CUserManager();



                CResult oResult = oManager.LoginAdminUser(inUserInfo);



                if (oResult.IsSuccess && oResult.Data != null)
                {


                    CUserInfo oUser = (CUserInfo)oResult.Data;

                    CResult oResult2 = oManager.GetUserAccess(oUser);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {


                        CUserAccess oUserAccess = (CUserAccess)oResult2.Data;

                        oUser.UserAccess = oUserAccess;

                        CUserLogin oUserLogin = new CUserLogin();

                        oUserLogin.UserInfo = oUser;

                        CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();



                        String tempConnStr = oTempDal.ConnectionString;

                        oUserLogin.ConnectionStr = tempConnStr;



                        oNewResult.Data = oUserLogin;

                        oNewResult.IsSuccess = true;

                    }

                }

            }
            catch (Exception ex)
            {
            }



            return oNewResult;
        }



        public void PostPrintingRequest(CPrintingFormat inPrintRequest)
        {
            try
            {

                CPrintQueue.Init();
                CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                m_oPrintRequest = inPrintRequest;
                m_mPrintMutex = oCommonConstants.PrintMutex;

                try
                {
                    m_mPrintMutex.WaitOne(oCommonConstants.ThreadWaitTime, false);
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (m_oPrintRequest != null && CPrintQueue.PrintQueue != null)
                    {
                        CPrintQueue.PrintQueue.Enqueue(m_oPrintRequest);
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    m_mPrintMutex.ReleaseMutex();
                }
                catch (Exception ex1)
                {
                }
            }
            catch (Exception ex2)
            {
            }
        }

        public CResult GetInitialDBStr()
        {
            CResult oResult = new CResult();

            try
            {
                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String sTempDB = oTempDal.ConnectionString;

                oResult.Data = sTempDB;

                oResult.IsSuccess = true;

            }
            catch (Exception ex)
            {
            }

            return oResult;


        }
    }
}
