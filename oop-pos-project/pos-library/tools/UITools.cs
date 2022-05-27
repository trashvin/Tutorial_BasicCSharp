using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_library.tools
{
    public static class UITools
    {
        public static void Print(string message)
        {
            Console.WriteLine($"{DateTime.Now} : {message}");
        }
    }
}
