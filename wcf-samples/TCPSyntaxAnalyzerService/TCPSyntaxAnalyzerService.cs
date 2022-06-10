using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ServiceModel;
using System.ServiceModel.Description;

namespace TCPSyntaxAnalyzerService
{
    public class TCPSyntaxAnalyzerService
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;

            try
            {
                host = new ServiceHost(typeof(TCPSyntaxAnalyzerProcessor));
                host.Open();

                foreach (ServiceEndpoint endPoint in host.Description.Endpoints)
                {
                    Console.WriteLine("Listening on ");
                    Console.WriteLine(endPoint.ListenUri.AbsoluteUri);
                }

                while (true)
                {
                    System.Threading.Thread.Sleep(5000);
                    Console.WriteLine("listening to requests ...");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.ReadLine();
        }
    }
}
