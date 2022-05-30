using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace activity1_main
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Invalid number of arguments");
                Console.ReadLine();
                return;
            }

            var firstFile = args[0];
            var lastFile = args[1];
            var outFile = args[2];

            List<string> firstNames = ReadFromFile(firstFile);
            List<string> lastNames = ReadFromFile(lastFile);

            List<string> listOfCompleteNames = JoinFiles(firstNames, lastNames, outFile);

            WriteToOutputFile(listOfCompleteNames, outFile);

            Console.WriteLine("Finish joining the files...");
            Console.ReadLine();
        }

        static void WriteToOutputFile(List<string> listOfCompleteNames, string outFile)
        {
            if (File.Exists(outFile)) File.Delete(outFile);

            using (StreamWriter writer = new StreamWriter(outFile, true))
            {
                foreach(var data in listOfCompleteNames)
                {
                    writer.WriteLine(data);
                }
            }
        }

        static List<string> JoinFiles(List<string> firstNames, List<string> lastNames, string outFile)
        {
            List<string> names = new List<string>();
            // find the last name by looping through the list
            foreach(var first in firstNames)
            {
                foreach(var last in lastNames)
                {
                    if (first.Trim()[0] == last.Trim()[0])
                    {
                        names.Add($"{first} {last.Substring(2)}");
                    }
                }
            }
            // find those that have no last name partners
            foreach(var first in firstNames)
            {
                bool found = false;
                foreach(var name in names)
                {
                    if (first.Trim()[0] == name.Trim()[0])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    names.Add($"{first} - -");
                }
            }

            // find those that have no first name partners
            foreach (var last in lastNames)
            {
                bool found = false;
                foreach (var name in names)
                {
                    if (last.Trim()[0] == name.Trim()[0])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    names.Add($"{last.Trim()[0]} - - {last.Substring(2)}");
                }
            }
            names.Sort();
            return names;
        }

        static List<string> ReadFromFile(string fileName)
        {
            List<string> data = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = string.Empty;
                while((line = reader.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }

            return data;
        }
    }
}
