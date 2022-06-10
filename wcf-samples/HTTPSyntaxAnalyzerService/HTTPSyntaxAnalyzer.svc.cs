﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using SyntaxAnalyzerLibrary;

namespace HTTPSyntaxAnalyzerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class HTTPSyntaxAnalyzerService : IHTTPSyntaxAnalyzer
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
