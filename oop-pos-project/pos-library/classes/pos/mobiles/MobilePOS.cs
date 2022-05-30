using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos_library.abstracts;
using pos_library.interfaces;
using pos_library.tools;
using pos_library;

namespace pos_library.classes.pos.mobiles
{
    public class MobilePOS : APOSMachine, IMobilePOS
    {
        public MobilePOS(string machineName, string ipAddress, string version, string phoneNumber) : base(machineName, ipAddress)
        {
            DevicePhoneNumber = phoneNumber;
            Version = version;
            SetPOSType(Constants.POS_TYPE_MOBILE);
        }
        public string DevicePhoneNumber { get; set; }

        public override void AddTransaction(ATransaction transaction)
        {
            UITools.Print($"-Adding transaction {transaction.TransactionNumber} at the BASE {POSType}");
            _transactions.Add(transaction);
        }

        public override List<ATransaction> GetTransactions()
        {
            return _transactions;
        }

        public override void PrintPOSDetail()
        {
            UITools.Print($"This mobile POS with version {Version} witn device phone number : {DevicePhoneNumber}");
        }

        public override void SummarizeTransactions()
        {
            var totalSale = 0M;
            var voidedSaleCount = 0;
            var voidedNoSaleCount = 0;
            var totalNoSale = 0M;
            foreach (var tran in _transactions)
            {
                if (tran.TranType == Constants.TranTypes.SALE)
                {
                    if (!tran.IsVoided)
                    {
                        totalSale += tran.TransactionTotal;
                    }
                    else
                    {
                        voidedSaleCount++;
                    }
                }
                else
                {
                    if (!tran.IsVoided)
                    {
                        totalNoSale += tran.TransactionTotal;
                    }
                    else
                    {
                        voidedNoSaleCount++;
                    }
                }
            }

            UITools.Print("---------------- SUMMARY ----------------");
            UITools.Print($"Total Number of Transactions : {_transactions.Count}");
            UITools.Print($"----------------------------------------");
            UITools.Print($"Total Sale Amount : {totalSale}");
            UITools.Print($"Total No Sale Amount : {totalNoSale}");
            UITools.Print($"----------------------------------------");
            UITools.Print($"Voided Sale : {voidedSaleCount}");
            UITools.Print($"Voided No Sale : {voidedNoSaleCount}");
            UITools.Print("-----------------------------------------");
            UITools.Print($"Source : {POSType} - {IPAddress}");
            UITools.Print("-----------------------------------------");
        }
    }
}
