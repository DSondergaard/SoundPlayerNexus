using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundPlayer
{
    [Serializable]
    public class SoundSet
    {
        public string Url { get; set; }
        public int Volume { get; set; }

    }
}
