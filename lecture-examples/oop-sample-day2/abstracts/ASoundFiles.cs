using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample_day2.abstracts
{
    public abstract class ASoundFiles
    {
        private string _fileName = string.Empty;
        public ASoundFiles(string fileName)
        {
            _fileName = fileName;
        }
        
        public void PrintFileName()
        {
            Console.WriteLine($"Filename = {_fileName}");
        }

        public abstract string GetSoundInformation();
    }
}
