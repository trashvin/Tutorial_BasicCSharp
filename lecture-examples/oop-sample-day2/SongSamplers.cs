using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample_day2
{
    public class SongSamplers : abstracts.ASoundFiles, interfaces.ISongAttributes
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public SongSamplers(string fileName) : base(fileName)
        {

        }

        public override string GetSoundInformation()
        {
            return $"WARNING: This is a song sample --- {Title} - {Artist} - {Album}";
        }
    }
}
