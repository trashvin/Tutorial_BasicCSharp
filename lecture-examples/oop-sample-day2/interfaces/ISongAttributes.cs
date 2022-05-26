using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample_day2.interfaces
{
    interface ISongAttributes
    {
        string Title { get; set; }
        string Artist { get; set; }
        string Album { get; set; }
    }
}
