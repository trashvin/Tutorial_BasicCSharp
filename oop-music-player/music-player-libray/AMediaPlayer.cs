using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace music_player_libray
{
    public abstract class AMediaPlayer
    {
        public String PlayerName
        {
            get; set;
        }

        public int PowerSource
        {
            get; set;
        }

        public int IsPowerOn
        {
            get => default(int);
            set
            {
            }
        }

        public int BatteryLevel
        {
            get => default(int);
            set
            {
            }
        }

        public abstract void PowerOn();

        public abstract void PowerOff();
    }
}