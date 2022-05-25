using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
 
            //primitive types
            int primitiveNumber = 0;
            string primitiveString = "sample primitive string";

            Console.WriteLine($"primitive number = {primitiveNumber}");
            Console.WriteLine($"primitive string = {primitiveString}");

            //c# types
            Int16 customNumber = 1;
            string customString = string.Empty; //""

            // "" is empty string
            //String emptyOne = "";

            Console.WriteLine($"C# number = {customNumber}");
            Console.WriteLine($"C# string = {customString}");

            // using var
            var name = "Name";
            var numberTwo = 2;
            var unknown = true;

            // var detrmines the type of the variable based on the value
            Console.WriteLine(name.GetType().ToString());
            Console.WriteLine(numberTwo.GetType().ToString());
            Console.WriteLine(unknown.GetType().ToString());

            //string examples

            String string1 = "Test 1";
            String string2 = "Test 2";

            //ways of concatenating strings
            Console.WriteLine(string1 + " - " + string2);
            Console.WriteLine(String.Format("{0} - {1}", string1, string2));
            Console.WriteLine($"{string1} - {string2}");

            //StringBuilder
            //mutable vs immutable 
            StringBuilder builder = new StringBuilder("The resulting strings:");
            builder.AppendLine(string1);
            builder.AppendLine(string2);
            Console.WriteLine(builder.ToString());


            //Decision statements
            //- if then else
            //- switch

            if (unknown == true) Console.WriteLine("Yes");

            if (unknown == true)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Yes is yes");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("No is no");
            }
            

            var value = 1;
            // || or
            // && and   (short circuit)
            // == equality
            // !  not

            if (value == 1 && value < 3) Console.WriteLine("One");
            else if (value == 2) Console.WriteLine("Two");
            else Console.WriteLine("Ewan");

            //switch
            Console.WriteLine("-----SWITCH----");
            switch (value)
            {
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                default:
                    Console.WriteLine("Ewan");
                    break;
            }

            // loop statements
            // logical expressin
            // based on a count

            for (var counter = 0; counter < 6; counter++)
            {
                Console.WriteLine($"counter = {counter}");
            }

            // the following lines are commented out to prevent running into infinite loop
            //var continueAsking = true;
            //while(continueAsking)
            //{
            //    continueAsking = Boolean.Parse(Console.ReadLine());    
            //}

            var counter1 = 0;
            while (counter1 < 6)
            {
                counter1++;
            }


            // arrays -  same types
            // ArrayList - different types
            // generic collections
            Console.WriteLine("-----ARRAY----");
            int[] arrayOfNumber = { 1, 3, 4, 5, 6 };
            var element0 = arrayOfNumber[0];
            var element1 = arrayOfNumber[1];
            arrayOfNumber[0] = arrayOfNumber[1] + arrayOfNumber[2];

            for (var index1 = 0; index1 < arrayOfNumber.Length; index1++)
            {
                Console.WriteLine(arrayOfNumber[index1]);
            }

            string[] arrayOfString = { "Hello", "World" };
            bool[] arrayOfBoolean = { true, false, true };

            Console.WriteLine("-----LIST----");

            List<int> listOfNumbers = new List<int>();
            listOfNumbers.Add(1);
            listOfNumbers.Add(5);

            List<string> listOfStrings = new List<string>
            {
                "test1",
                "ok",
                "yes"
            };
            listOfStrings.Add("no");

            foreach(var number in listOfNumbers)
            {
                Console.WriteLine($"The number is {number}");
            }

            foreach(var message in listOfStrings)
            {
                Console.WriteLine($"The message is {message}");
            }

            for(var index2 = 0; index2 < listOfStrings.Count; index2++)
            {
                Console.WriteLine($"The message is {listOfStrings[index2]}");
            }

            Console.ReadLine();
        }
    }
}
