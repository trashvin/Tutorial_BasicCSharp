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

            var choice = "A";

            UITools.Print("A - Test with same transaction set");
            UITools.Print("B - Test with different transaction set");
            UITools.Print("Enter your choice:", false);
            choice = Console.ReadLine().Trim().ToUpper();

            if (choice.CompareTo("A") == 0)
            {
                TestWithSameTransactionSet();
            }
            else if (choice.CompareTo("B") == 0)
            {
                TestWithDifferentTransactionSet();
            }
            else
            {
                UITools.Print("ERROR : Invalid choice ...");
            }

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

        private static void TestWithSameTransactionSet()
        {
            // uncomment the codes below to test applications 

            DesktopPOS phPOS = new DesktopPOS("phPOS", "222.66.77.100", "2.9.99", "Manila,Philippines");
            AndroidMobilePOS samsungPOS = new AndroidMobilePOS("samsungPOS", "111.13.56.156", "1.6.7", "+13452341214");
            MobilePOS mobPOS = new MobilePOS("mobPOS", "21.13.56.56", "1.7.7", "+13452347612");
            LinuxDesktopPOS ubuntuPOS = new LinuxDesktopPOS("ubuntuPOS", "22.66.77.70", "2.9.95", "Boston,Massachusetts");

            WebPOS chromePOS = new WebPOS("chromePOS", "134.7.8.9", "5.8.0", "Chrome v20");

            List<APOSMachine> machines = new List<APOSMachine>();
            machines.Add(phPOS);
            machines.Add(chromePOS);
            machines.Add(samsungPOS);
            machines.Add(mobPOS);
            machines.Add(ubuntuPOS);

            List<ATransaction> transactions = new List<ATransaction>();
            Transaction tran1 = new Transaction(2, DateTime.Now, 5.99M, tranType: Constants.TranTypes.SALE);
            Transaction tran2 = new Transaction(3, DateTime.Now, 1.99M, tranType: Constants.TranTypes.SALE);
            Transaction tran3 = new Transaction(4, DateTime.Now, 5.99M, tranType: Constants.TranTypes.NO_SALE);
            Transaction tran4 = new Transaction(5, DateTime.Now, 6.99M, isVoided: true, tranType: Constants.TranTypes.SALE);
            Transaction tran6 = new Transaction(6, DateTime.Now, 5.99M, isVoided: true, tranType: Constants.TranTypes.NO_SALE);
            transactions.Add(tran1);
            transactions.Add(tran2);
            transactions.Add(tran3);
            transactions.Add(tran4);
            transactions.Add(tran6);

            TestMachines(machines, transactions);
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
                    machine.AddTransaction(tran);
                }

                UITools.Print("Printing transactions ...");

                foreach (var tran in machine.GetTransactions())
                {
                    tran.ShowTransactionDetail();
                }

                UITools.Print("Showing transaction summary ...");

                // the method gets the summary : total tran, total voided, sum of amount(void not included)
                machine.SummarizeTransactions();

                machine.ClearTransactions();
                machine.StopMachine();
                UITools.Print($"***********END TEST : {testCount} ***************");
                testCount++;
            }
        }

        private static void TestWithDifferentTransactionSet()
        {
            DesktopPOS phPOS = new DesktopPOS("phPOS", "222.66.77.100", "2.9.99", "Manila,Philippines");
            AndroidMobilePOS samsungPOS = new AndroidMobilePOS("samsungPOS", "111.13.56.156", "1.6.7", "+13452341214");

            List<APOSMachine> machines = new List<APOSMachine>();
            machines.Add(phPOS);
            machines.Add(samsungPOS);

            List<ATransaction> posTransactions = new List<ATransaction>();
            Transaction tran1 = new Transaction(2, DateTime.Now, 5.99M, tranType: Constants.TranTypes.SALE);
            Transaction tran2 = new Transaction(3, DateTime.Now, 1.99M, tranType: Constants.TranTypes.SALE);
            Transaction tran3 = new Transaction(4, DateTime.Now, 5.99M, tranType: Constants.TranTypes.NO_SALE);
            Transaction tran4 = new Transaction(5, DateTime.Now, 6.99M, isVoided: true, tranType: Constants.TranTypes.SALE);
            Transaction tran6 = new Transaction(6, DateTime.Now, 5.99M, isVoided: true, tranType: Constants.TranTypes.NO_SALE);
            posTransactions.Add(tran1);
            //posTransactions.Add(tran2);
            //posTransactions.Add(tran3);
            //posTransactions.Add(tran4);
            //posTransactions.Add(tran6);

            List<ATransaction> mobTransactions = new List<ATransaction>();
            Transaction tran7 = new Transaction(2, DateTime.Now, 5.99M, tranType: Constants.TranTypes.SALE);
            Transaction tran8 = new Transaction(3, DateTime.Now, 5.99M, tranType: Constants.TranTypes.SALE);
            Transaction tran9 = new Transaction(4, DateTime.Now, 5.99M, tranType: Constants.TranTypes.NO_SALE);
            Transaction tran10 = new Transaction(5, DateTime.Now, 6.99M, isVoided: true, tranType: Constants.TranTypes.SALE);
            mobTransactions.Add(tran7);
            mobTransactions.Add(tran8);
            mobTransactions.Add(tran9);
            mobTransactions.Add(tran10);
            

            List<List<ATransaction>> transactions = new List<List<ATransaction>>();
            transactions.Add(posTransactions);
            transactions.Add(mobTransactions);

            int index = 0;
            foreach(var machine in machines)
            {
                TestMachine(machine, transactions[index]);
                index++;
            }

        }

        static void TestMachine(APOSMachine machine, List<ATransaction> transactions)
        {
            int testCount = 0;
          
            UITools.Print($"***********START TEST : {testCount} ***************");
            machine.PrintPOSDetail();
            UITools.Print($"POSType : {machine.POSType}");

            UITools.Print("Adding transactions ...");

            foreach (var tran in transactions)
            {
                machine.AddTransaction(tran);
            }

            UITools.Print("Printing transactions ...");

            foreach (var tran in machine.GetTransactions())
            {
                tran.ShowTransactionDetail();
            }

            UITools.Print("Showing transaction summary ...");

            // the method gets the summary : total tran, total voided, sum of amount(void not included)
            machine.SummarizeTransactions();

            machine.ClearTransactions();
            machine.StopMachine();
            UITools.Print($"***********END TEST : {testCount} ***************");
            testCount++;
          
        }

    }
}
