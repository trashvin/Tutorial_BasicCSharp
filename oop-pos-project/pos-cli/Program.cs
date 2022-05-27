using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos_library;
using pos_library.tools;
using pos_library.abstracts;
using pos_library.classes;
using pos_library.classes.pos.desktops;
using pos_library.classes.pos;
using pos_library.classes.pos.mobiles;


namespace pos_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            UITools.Print("Starting program...");

            // comment this out if running the test application
            //ShowSampleUsage();

            // uncomment the codes below to test applications 

            DesktopPOS phPOS = new DesktopPOS("phPOS", "222.66.77.100", "2.9.99", "Manila,Philippines");
            DesktopPOS usPOS = new DesktopPOS("usPOS", "200.12.9.180", "3.8.3", "Boston, Massachusetts");
            WebPOS chromePOS = new WebPOS("chromeMachine", "123.45.67.89", "12.7.9", "Chrome 16");

            //MobilePOS
            //AndroidMobilePOS
            //IOSMobilePOS
            //LinuxDesktopPOS
            //WindowsDesktopPOS


            List<APOSMachine> machines = new List<APOSMachine>();
            machines.Add(phPOS);
            machines.Add(usPOS);
            machines.Add(chromePOS);

            List<ATransaction> transactions = new List<ATransaction>();

            TestMachines(machines, transactions);


            UITools.Print("Ending program...");
            Console.ReadLine();
        }

        private static void ShowSampleUsage()
        {
            // creating POS Machines
            using (DesktopPOS testPOS = new DesktopPOS("testPOS", "192.168.3.5", "5.0.0", "Cebu, Philippines"))
            {
                testPOS.PrintPOSDetail();
            }

            // creating transactions
            Transaction saleTran = new Transaction();
            saleTran.TransactionNumber = 1;
            saleTran.TransactionDate = DateTime.Now;
            saleTran.TransactionTotal = 1.99M;
            saleTran.TranType = Constants.TranTypes.SALE;
            saleTran.IsVoided = false;

            Transaction noSaleTran = new Transaction(2, DateTime.Now, 5.99M, tranType: Constants.TranTypes.NO_SALE);
            noSaleTran.VoidTransaction();

            // print transactions
            UITools.Print("Data for saleTran:");
            saleTran.ShowTransactionDetail();

            UITools.Print("Data for noSaleTran:");
            noSaleTran.ShowTransactionDetail();
        }

        static void TestMachines(List<APOSMachine> machines, List<ATransaction> transactions)
        {
            int testCount = 0;
            foreach(var machine in machines)
            {
                UITools.Print($"***********START TEST : {testCount} ***************");
                machine.PrintPOSDetail();
                UITools.Print($"POSType : {machine.POSType}");

                UITools.Print("Adding transactions ...");

                foreach(var tran in transactions)
                {
                    //this will add all transaction to the list of tran
                    //machine.AddTransaction(tran);
                }

                UITools.Print("Printing transactions ...");

                foreach (var tran in machine.GetTransactions())
                {
                    // prints the transactions, it must indicate if voided
                }

                UITools.Print("Showing transaction summary ...");

                // the method gets the summary : total tran, total voided, sum of amount(void not included)
                // machine.SummarizeTransactions();

                machine.StopMachine();
                UITools.Print($"***********END TEST : {testCount} ***************");
                testCount++;
            }
        }
    }
}
