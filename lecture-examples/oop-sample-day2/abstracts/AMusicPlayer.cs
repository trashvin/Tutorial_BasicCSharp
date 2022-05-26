using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample_day2.abstracts
{
    public abstract class AMusicPlayer
    {
        public AMusicPlayer() { }

        // automatic properties
        public string PlayerName { get; set; }  //read-write
        private string ReadOnlyName { get; }  // readonly
        private string WriteOnlyName
        {
            set
            {
                
            }
        }  // writeonly

        public abstract void Stop();

        private int _volume = 0;

        public void IncreaseVolume()
        {
            _volume++;
        }

        public void DecreaseVolume()
        {
            _volume--;
        }

        public int GetVolumeLevel()
        {
            return _volume;
        }

        public abstract void Play(ASoundFiles sound);

    }
}
