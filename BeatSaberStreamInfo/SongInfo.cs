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
        public int energy { get; set; }

        public SongInfo()
        {
            SetDefault();
        }

        public string GetVal(string s)
        {
            switch (s.ToLower())
            {
                case "combo":
                    return combo.ToString();
                case "multiplier":
                    return multiplier.ToString();
                case "notes_hit":
                    return notes_hit.ToString();
                case "notes_total":
                    return notes_total.ToString();
                case "percent":
                    if (notes_total != 0)
                        return ((notes_hit * 100) / notes_total).ToString("N0");
                    else
                        return "0%";
                case "score":
                    return score.ToString();
                case "energy":
                    return energy.ToString("N0");
                default:
                    return "";
            }
        }

        public void SetDefault()
        {
            combo = 0;
            multiplier = 1;
            notes_hit = 0;
            notes_total = 0;
            score = 0;
            energy = 50;
        }
    }
}
