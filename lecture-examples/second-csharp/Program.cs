using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //DisplayMessage("hello cruel world");

            MyLibrary library = new MyLibrary();
            
            List<string> listOfMessages = new List<string>
            {
                "good morning",
                "hiyah",
                "good bye"
            };

            foreach(var message in listOfMessages)
            {
                //DisplayMessage(message);
            }

            var num1 = 9;
            var num2 = 5;

            //library.DisplayMessage(library.Add(num1, num2).ToString());

            //library.DisplayMessage(library.Add(num1, num2, 10).ToString());


            List<string> data = library.ReadFile("Input.txt");
            foreach(var value in data)
            {
                //Console.WriteLine(value);
            }

            foreach(var entry in data)
            {
                if (!String.IsNullOrEmpty(entry))
                {
                    library.WriteToFile(entry, "outAppend.txt");
                    library.WriteToFile(entry, "outOverwrite.txt", false);
                }  
            }


            var output = library.GetIndexData(0);
            var output1 = library.GetIndexData(1);
            var output2 = library.GetIndexData(2);
            var output3 = library.GetIndexData(6);

            Console.WriteLine($"{output} - {output1} - {output2} - {output3}");
            Console.ReadLine();
        }

       

    }
}
