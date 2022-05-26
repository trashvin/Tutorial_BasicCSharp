using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace example1_main
{
    class Program
    {
        static void Main(string[] args)
        {
            // is to process the arguments
            if (args.Length != 3)
            {
                Console.WriteLine("ERROR : Invalid argument count");
                Console.ReadLine();
                return;
            }

            var rawFile = args[0];
            var cleanFile = args[1];
            var filter = args[2];

            Console.WriteLine("Start processing...");

            List<string> rawLogs = ReadFileToList(rawFile);
            List<string> cleanLogsV2 = CleanFileV2(rawLogs, filter);
            WriteCleanFile(cleanLogsV2, cleanFile);

            List<string> cleanLogs = CleanFile(rawFile, filter);
            WriteCleanFile(cleanLogs, cleanFile);

            Console.WriteLine("Done processing...");
            Console.ReadLine();
        }

        private static List<string> CleanFileV2(List<string> rawLogs, string filter)
        {
            // ERR|INFO = {"ERR","INFO"}
            string[] filters = filter.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> cleanLogs = new List<string>();
            
            foreach (var rawLog in rawLogs)
            {
                foreach (var stringFilter in filters)
                {
                    if (rawLog.Substring(1).StartsWith(stringFilter.ToUpper()))
                    {
                        cleanLogs.Add(rawLog);
                    }
                }
            }
            return cleanLogs;
        }

        private static void WriteCleanFile(List<string> cleanLogs, string cleanFile)
        {
            using (StreamWriter writer = new StreamWriter(cleanFile,true))
            {
                foreach(var log in cleanLogs)
                {
                    writer.WriteLine(log);
                }
            }
        }

        private static List<string> CleanFile(string rawFile, string filter)
        {
            // ERR|INFO = {"ERR","INFO"}
            string[] filters = filter.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> cleanLogs = new List<string>();

            StringBuilder test = new StringBuilder();
            StringBuilder test1 = new StringBuilder();


            List<string> rawLogs = ReadFileToList(rawFile);

            foreach(var rawLog in rawLogs)
            {
                foreach(var stringFilter in filters)
                {
                    if (rawLog.Substring(1).StartsWith(stringFilter.ToUpper()))
                    {
                        cleanLogs.Add(rawLog);
                    }
                }
            }
            return cleanLogs;
        }

        private static List<string> ReadFileToList(string rawFile)
        {
            List<string> rawLogs = new List<string>();

            using(StreamReader reader = new StreamReader(rawFile))
            {
                string line = String.Empty;
                while((line = reader.ReadLine())!=null)
                {
                    rawLogs.Add(line);
                }
            }

            return rawLogs;
        }
    }
}
