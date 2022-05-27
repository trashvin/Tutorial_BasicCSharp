using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos_library.abstracts;
using pos_library.interfaces;
using pos_library.tools;
using pos_library;

namespace pos_library.classes.pos
{
    public class WebPOS : APOSMachine , IWebPOS
    {
        public WebPOS(string machineName, string ipAddress, string version, string browserType) : base(machineName, ipAddress)
        {
            BrowserType = browserType;
            Version = version;
            SetPOSType(Constants.POS_TYPE_WEB);
        }
        public string BrowserType { get; set; }

        public override void AddTransaction(ATransaction transaction)
        {
            //add a line message telling that the transaction is from a desktop pos 
            throw new System.NotImplementedException();
        }

        public override List<ATransaction> GetTransactions()
        {
            return _transactions;
        }

        public override void PrintPOSDetail()
        {
            UITools.Print($"This Web POS with version {Version} is using a browser {BrowserType}.");
        }

        public override void SummarizeTransactions()
        {
            // req
            throw new NotImplementedException();
        }
    }
}
