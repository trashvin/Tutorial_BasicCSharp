using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_sample_day2.abstracts;

namespace oop_sample_day2
{
    public class MP3Player : AMusicPlayer
    {
        public override void Stop()
        {
            Console.WriteLine("Stopping the MP3 player.");
        }

        public override void Play(ASoundFiles sound)
        {
            Console.WriteLine($"The MP3 Player is now playing -> {sound.GetSoundInformation()}");
        }
    }
}
