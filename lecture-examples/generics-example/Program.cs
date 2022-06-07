using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generics_example
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> dicStrings = new Dictionary<int, string>();

            //  1 - One
            //  2 - Two

            dicStrings.Add(1, "One");
            dicStrings.Add(2, "Two");
            dicStrings.Add(10, "Teeen");
            Console.WriteLine(dicStrings[2]);
            Console.WriteLine(dicStrings[10]);

            Queue<int> intQueue = new Queue<int>();
            intQueue.Enqueue(1);
            intQueue.Enqueue(5);

            Console.WriteLine(intQueue.Dequeue());

            Stack<int> intStack = new Stack<int>();

            intStack.Push(11);
            intStack.Push(20);

            Console.WriteLine(intStack.Pop());



            Console.ReadLine();
        }
    }
}
