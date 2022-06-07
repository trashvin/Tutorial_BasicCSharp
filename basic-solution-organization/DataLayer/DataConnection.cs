using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataConnection
    {
        public DataConnection()
        {
            Console.WriteLine("Data Connection is intatiated...");
        }

        public string  GetConnection()
        {
            return "This is the connection version 2";
        }

        private string GetPassword()
        {
            return "This is the password";
        }
    }
}
