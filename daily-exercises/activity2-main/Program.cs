using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace activity2_main
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments.");
                Console.ReadLine();
                return;
            }

            var inputFile = args[0];
           

            Console.WriteLine($"Getting the readings from {inputFile}.....");

            List<int> readings = GetReadings(inputFile);

            Console.WriteLine("Determining the depth increase count .....");

            int deptIncreaseCount = GetDepthIncreaseCount(readings);

            Console.WriteLine($"Scubaachine detected {deptIncreaseCount} depth increase.");

            Console.ReadLine();

        }

        private static List<int> GetReadings(string inputFile)
        {
            List<int> readings = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader(inputFile))
                {
                    string line = string.Empty;
                    while((line = reader.ReadLine())!= null)
                    {
                        int number = 0;
                        if (Int32.TryParse(line, out number))
                        {
                            readings.Add(number);
                        }
                    }
                }

                return readings;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected error occured : {ex.ToString()}");
                return readings;
            }
        }

        private static int GetDepthIncreaseCount(List<int> readings)
        {
            int count = 0;
            try
            {
                for(var index = 0; index < readings.Count; index++)
                {
                    if (index == 0) continue;

                    if (readings[index] > readings[index -1])
                    {
                        count++;
                    }

                    //  continue  vs  break
                }

                return count;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected error occured : {ex.ToString()}");
                return count;
            }
        }

    }
}
