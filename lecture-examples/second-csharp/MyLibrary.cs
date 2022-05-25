using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace second_csharp
{
    class MyLibrary
    {
        public void DisplayMessage(string message)
        {
            // this can contain 50 lines
            Console.WriteLine("Start of message");
            Console.WriteLine(message);
            Console.WriteLine("End of message");
        }

        public int Add(int numberOne, int numberTwo, int numberThree = 0)
        {
            // ....
            return numberOne + numberTwo + numberThree;
        }

        public List<string> ReadFile(string fileName)
        {
            List<string> data = new List<string>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string temp = reader.ReadLine();
                data.Add(temp);
                while(temp != null)
                {
                    temp = reader.ReadLine();
                    data.Add(temp);
                }
            }

            return data;
        }

        public void WriteToFile(string message, string fileName, bool append = true)
        {
            using (StreamWriter writer = new StreamWriter(fileName, append))
            {
                writer.WriteLine(message);
            }
        }

        public string GetIndexData(int index)
        {
            try
            {
                string[] data = { "one", "two", "three" };
                return data[index];
            }
            catch(IndexOutOfRangeException ioex)
            {
                Console.WriteLine(ioex.ToString());
                return "not in range";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "not valid";
            }
            
     
        }
    }
}
