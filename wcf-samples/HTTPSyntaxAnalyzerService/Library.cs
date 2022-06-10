using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HTTPSyntaxAnalyzerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHTTPSyntaxAnalyzer
    {

        [OperationContract]
        SyntaxticCode AnalyzeCode(SyntaxticCode code);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class SyntaxticCode
    { 
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public int Score { get; set; }
    }
}
