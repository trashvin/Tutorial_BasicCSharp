using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos_library.tools;


namespace pos_library.abstracts
{
    public abstract class APOSMachine : IDisposable
    {
        protected string _machineName = string.Empty;
        protected string _ipAddress = string.Empty;
        public APOSMachine(string machineName, string ipAddress)
        {
            MachineName = machineName;
            IPAddress = ipAddress;
            StartMachine();
        }

        public string MachineName { get; }
        public string IPAddress { get; }
        public string Version { get; set; }
        public string POSType { get; set; }

        // requirement - provide a public read only property POSSoftware
        // this will return a concatenate POSType and Version

        private void StartMachine()
        {
            UITools.Print($"POS machine {MachineName} is starting...");
            UITools.Print($"Machine Name : {MachineName} ; IPAddress : {IPAddress}");
            UITools.Print($"POS {MachineName} sucessfully started.");
        }

        public void StopMachine()
        {
            UITools.Print($"Powering down the {MachineName} POS machine ....");
            UITools.Print($"Releasing the address {IPAddress} ...");
            UITools.Print($"POS Machine {MachineName} stopped.");
        }

        protected List<ATransaction> _transactions = new List<ATransaction>();

        public abstract List<ATransaction> GetTransactions();


        /// <summary>
        /// implement this 
        /// </summary>
        /// <param name="transaction"></param>
        public abstract void AddTransaction(ATransaction transaction);


        /// <summary>
        /// No of transactions
        /// No of Sale transactions
        /// No of No-sale
        /// No of voided
        /// Sum of tran total of not voided transaction
        /// Design the output
        /// </summary>
        public abstract void SummarizeTransactions();

        public void ClearTransactions()
        {
            _transactions.Clear();
        }

        public void SetPOSType(string type)
        {
            POSType = type;
        }

        public abstract void PrintPOSDetail();

        public void Dispose()
        {
            StopMachine();
        }
    }
}
