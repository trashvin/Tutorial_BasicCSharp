using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_sample_day2.abstracts;

namespace oop_sample_day2
{
    public class BaseMusicPlayer : AMusicPlayer
    {
        public override void Play(ASoundFiles sound)
        {
            Console.WriteLine($"The Base Player is now playing -> {sound.GetSoundInformation()}");
        }

        public override void Stop()
        {
            Console.WriteLine("Stopping the base player.");
        }
    }
}
