using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace Managers.GManager
{
    public class EFTCardManager
    {
        public EFTCardManager()
        { 
        
        }

        public List<EFTCard> GetEftCards()
        {
          
           return Database.Instance.GetEfTcard.GetEftCards();
        }

        public bool InsertEftCard(EFTCard eftCard)
        {
            CResult cResult= Database.Instance.GetEfTcard.InsertEFTCard(eftCard);
            return cResult.IsSuccess;
        }
        public bool UpdateEftCard(EFTCard eftCard)
        {
            CResult cResult = Database.Instance.GetEfTcard.UpdateEFTCardList(eftCard);
            return cResult.IsSuccess;
        }
        public bool DeteleEftcard(EFTCard eftCard)
        {
            CResult cResult = Database.Instance.GetEfTcard.DeleteEFTCard(eftCard);
            return cResult.IsSuccess;
        }

        public bool InsertEFTPayment(Int64 orderID, int cardID, string cardName)
        {
            CResult cResult = Database.Instance.GetEfTcard.InsertEFTPayment(orderID, cardID, cardName);
            return cResult.IsSuccess;
        
        }
        public bool UpdateEFTPaymentByOrderID(Int64 orderID, int cardID, string cardName)
        {
            CResult cResult = Database.Instance.GetEfTcard.UpdateEFTPaymentByOrderID(orderID, cardID, cardName);
            return cResult.IsSuccess;
        }

        public bool AllReadyExiste(Int64 orderID)
        {
            return Database.Instance.GetEfTcard.IsCardAllReadyAssigned(orderID);
        }
    }
}
