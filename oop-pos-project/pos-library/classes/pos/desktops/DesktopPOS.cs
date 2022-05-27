using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos_library.abstracts;
using pos_library.interfaces;
using pos_library.tools;
using pos_library;

namespace pos_library.classes.pos.desktops
{
    public class DesktopPOS : APOSMachine, IDesktopPOS
    {
        public DesktopPOS(string machineName, string ipAddress, string version, string location):base(machineName, ipAddress)
        {
            POSLocation = location;
            Version = version;
            SetPOSType(Constants.POS_TYPE_DESKTOP);
        }
        public string POSLocation { get; set; }

        public override void AddTransaction(ATransaction transaction)
        {
            //add a line message telling that the transaction is from a desktop pos 
            throw new NotImplementedException();
        }

        public override List<ATransaction> GetTransactions()
        {
            return _transactions;
        }

        public override void PrintPOSDetail()
        {
            UITools.Print($"This desktop POS with version {Version} is located in {POSLocation}");
        }

        public override void SummarizeTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
