using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos_library;
using pos_library.tools;

namespace pos_library.abstracts
{
    public abstract class ATransaction
    {
        public int TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionTotal { get; set; }
        public bool IsVoided { get; set; }
        public Constants.TranTypes TranType { get; set; }
        
        public void VoidTransaction()
        {
            IsVoided = true;
        }

        public virtual void ShowTransactionDetail()
        {
            StringBuilder tranDetails = new StringBuilder("-");
            tranDetails.Append($"TranNo = {TransactionNumber} ; ");
            tranDetails.Append($"Date = {TransactionDate} ; ");
            tranDetails.Append($"Total = {TransactionTotal} ; ");
            tranDetails.Append($"Type = {TranType.ToString()} ; ");

            string voidDesc = IsVoided ? "VOIDED" : "VALID";

            tranDetails.Append($"{voidDesc}");

            UITools.Print(tranDetails.ToString());
        }

        public ATransaction() { }
        public ATransaction(
            int tranNumber, 
            DateTime tranDate, 
            decimal tranTotal, 
            bool isVoided = false, 
            Constants.TranTypes tranType = Constants.TranTypes.SALE)
        {
            TransactionNumber = tranNumber;
            TransactionDate = tranDate;
            TransactionTotal = tranTotal;
            IsVoided = isVoided;
            TranType = tranType;
        }
    }
}
