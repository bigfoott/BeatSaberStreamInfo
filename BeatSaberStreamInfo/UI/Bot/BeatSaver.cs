using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaberStreamInfo.UI.Bot
{
    class BeatSaver
    {
        private static Dictionary<string, List<string>> searches = new Dictionary<string, List<string>>();

        public static List<string> Search(string search)
        {
            var list = new List<string>();

            if (searches.ContainsKey(search))
                list = searches[search];
            else
            {
                dynamic json = JsonConvert.DeserializeObject(new WebClient().DownloadString("https://beatsaver.com/api/songs/search/name/" + search));
                list = GetSongsFromJson(json);
                searches.Add(search, list);
            }

            return list;
        }

        private static List<string> GetSongsFromJson(dynamic json)
        {
            var list = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                if (i + 1 > ((JArray)json.songs).Count)
                    break;

                list.Add((string)json.songs[i].name);
            }

            return list;
        }

    }
}
