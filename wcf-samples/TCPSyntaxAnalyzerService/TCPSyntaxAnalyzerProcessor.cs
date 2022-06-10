using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using SyntaxAnalyzerLibrary;

namespace TCPSyntaxAnalyzerService
{
    public class TCPSyntaxAnalyzerProcessor : ISyntaxAnalyzer
    {
        public SyntaxticCode AnalyzeCode(SyntaxticCode code)
        {
            Processor analyzer = new Processor();

            int score = analyzer.ParseCode(code.Code);

            SyntaxticCode result = new SyntaxticCode();
            result.Code = code.Code;
            result.Score = score;

            return result;
        }
            

       
    }
}
