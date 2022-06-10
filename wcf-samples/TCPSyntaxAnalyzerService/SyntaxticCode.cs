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
    [DataContract]
    public class SyntaxticCode
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public int Score { get; set; }
    }
}
