using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Deposit
{
    public class CDepositManager
    {
        private CResult m_oResult;

        public CDepositManager()
        {
            m_oResult = new CResult();
        }

        public CResult InsertDeposit(CDeposit inDeposit)
        {

            try
            {
                m_oResult = Database.Instance.Deposit.InsertDeposit(inDeposit);

                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertDeposit() : " + ex.Message);

                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertDeposit()", LogLevel.Error, "CDepositManager");
            }
            return m_oResult;
        }

        public CResult UpdateDeposit(CDeposit inDeposit)
        {

            try
            {
                m_oResult = Database.Instance.Deposit.UpdateDeposit(inDeposit);

                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateDeposit() : " + ex.Message);

                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateDeposit()", LogLevel.Error, "CDepositManager");
            }
            return m_oResult;
        }

        public CResult DepositGetByDepositID(Int64 inDepositID)
        {

            try
            {
                m_oResult = Database.Instance.Deposit.GetDepositByDepositID(inDepositID);

                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DepositGetByDepositID() : " + ex.Message);

                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DepositGetByDepositID()", LogLevel.Error, "CDepositManager");
            }
            return m_oResult;
        }

        public CResult InsertDepositUsed(CDepositUsed inDepositUsed)
        {

            try
            {
                m_oResult = Database.Instance.Deposit.InsertDepositUsed(inDepositUsed);

                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertDepositUsed() : " + ex.Message);

                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertDepositUsed()", LogLevel.Error, "CDepositManager");
            }
            return m_oResult;
        }
    }
}
