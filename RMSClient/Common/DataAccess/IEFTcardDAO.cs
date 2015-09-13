using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IEFTCardDAO
    {
       CResult UpdateEFTCardList(EFTCard eftcard);
       CResult InsertEFTCard(EFTCard eftcard);
       CResult DeleteEFTCard(EFTCard eftcard);
       List<EFTCard> GetEftCards();

       bool IsCardAllReadyAssigned(Int64 orderID);
       CResult InsertEFTPayment(Int64 orderID, int cardID, string cardName);
       CResult UpdateEFTPaymentByOrderID(Int64 orderID, int cardID, string cardName);
    }
}
