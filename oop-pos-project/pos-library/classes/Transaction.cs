using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos_library.abstracts;

namespace pos_library.classes
{
    public class Transaction : ATransaction
    {
        public Transaction() { }
        public Transaction(
            int tranNumber,
            DateTime tranDate,
            decimal tranTotal,
            bool isVoided = false,
            Constants.TranTypes tranType = Constants.TranTypes.SALE):base(tranNumber,tranDate,tranTotal,isVoided, tranType)
        {

        }
    }
}
