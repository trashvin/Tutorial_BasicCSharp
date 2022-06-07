using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TerminalUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DataConnection connection = new DataConnection();

            string connectionString = connection.GetConnection();

            Console.WriteLine(connectionString);

            Console.ReadLine();
        }
    }
}
