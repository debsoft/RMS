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
using System.Data;

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
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
            }
            return oNewResult;
        }

        public void PostPrintingRequest(CPrintingFormat inPrintRequest)
        {
            try
            {
                bool bTempFlag = false;

                Debug.WriteLine("in PostPrintingRequest 1");
                CPrintQueue.Init();
                CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                m_oPrintRequest = inPrintRequest;

                Debug.WriteLine("in PostPrintingRequest 2");
                m_mPrintMutex = oCommonConstants.PrintMutex;

                Debug.WriteLine("in PostPrintingRequest 3");

                try
                {
                    Debug.WriteLine("in PostPrintingRequest 4");

                    bTempFlag = m_mPrintMutex.WaitOne(oCommonConstants.ThreadWaitTime, false);

                    Debug.WriteLine("in PostPrintingRequest 5");

                    if (bTempFlag)
                    {

                        try
                        {
                            Debug.WriteLine("in PostPrintingRequest 6");

                            if (m_oPrintRequest != null && CPrintQueue.PrintQueue != null)
                            {
                                Debug.WriteLine("in PostPrintingRequest 7");

                                CPrintQueue.PrintQueue.Enqueue(m_oPrintRequest);
                                
                                Debug.WriteLine("in PostPrintingRequest 8");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        try
                        {
                            Debug.WriteLine("in PostPrintingRequest 9");

                            m_mPrintMutex.ReleaseMutex();

                            Debug.WriteLine("in PostPrintingRequest 10");
                        }
                        catch (Exception ex1)
                        {
                            Console.WriteLine(ex1.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
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
                Console.WriteLine(ex.Message);
            }
            return oResult;
        }
    }
}
