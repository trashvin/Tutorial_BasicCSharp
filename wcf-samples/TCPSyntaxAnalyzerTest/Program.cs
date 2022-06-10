using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCPSyntaxAnalyzerTest.TCPSyntaxAnalyzer;

namespace TCPSyntaxAnalyzerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPSyntaxAnalyzer.SyntaxAnalyzerClient client = new SyntaxAnalyzerClient();


            Console.WriteLine("Enter code:");
            SyntaxticCode testCode = new SyntaxticCode();
            testCode.Code = Console.ReadLine();
            testCode.Score = -1;

            SyntaxticCode result = new SyntaxticCode();

            result = client.AnalyzeCode(testCode);

            client.Close();

            Console.WriteLine($"The {result.Code} has a score of {result.Score} ");

            Console.ReadLine();


        }
    }
}
