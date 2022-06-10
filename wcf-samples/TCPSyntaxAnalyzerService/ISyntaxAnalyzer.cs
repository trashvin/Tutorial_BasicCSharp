using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TCPSyntaxAnalyzerService
{
    [ServiceContract]
    interface ISyntaxAnalyzer
    {
        [OperationContract]
        SyntaxticCode AnalyzeCode(SyntaxticCode code);

    }
}
