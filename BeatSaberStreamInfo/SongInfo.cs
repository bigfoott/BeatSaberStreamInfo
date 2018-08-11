using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaberStreamInfo
{
    class SongInfo
    {
        public int combo { get; set; }
        public int multiplier { get; set; }
        public int notes_hit { get; set; }
        public int notes_total { get; set; }
        public int score { get; set; }

        public SongInfo()
        {
            SetDefault();
        }

        public void SetDefault()
        {
            combo = 0;
            multiplier = 1;
            notes_hit = 0;
            notes_total = 0;
            score = 0;
        }
    }
}
