using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample_day2
{
    public class MusicFile : abstracts.ASoundFiles, interfaces.ISongAttributes
    {
        public MusicFile(string fileName):base(fileName)
        {
        }

        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public override string GetSoundInformation()
        {
            return $"{Title} - {Artist} - {Album}";
        }
    }
}
