using System;
using System.Collections.Generic;

using System.Text;

namespace RMS.Common.ObjectModel
{
   public class BankTransaction
    {
       public int Id { set; get; }
       public string BankName { set; get; }
       public string BranchName { set; get; }
       public string AcoountNumber { set; get; }
       public string DepositeDate { set; get; }
       public string DepositePerson { set; get; }
       public double DepositeAmount { set; get;}



    }
}
