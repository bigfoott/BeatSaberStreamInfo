using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaberStreamInfo.UI.Bot
{
    class BeatSaver
    {
        private Dictionary<string, List<string>> searches;
        private WebClient wc;

        public BeatSaver()
        {
            searches = new Dictionary<string, List<string>>();

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            wc = new WebClient();
        }

        public List<string> Search(string search)
        {
            var list = new List<string>();
            if (searches.ContainsKey(search))
                list = searches[search];
            else
            {
                list = GetSongsFromJson(wc.DownloadString("https://beatsaver.com/api/songs/search/name/" + search));
                searches.Add(search, list);
            }

            return list;
        }

        private List<string> GetSongsFromJson(string json)
        {
            json = json.Replace(",", "," + Environment.NewLine);
            var list = new List<string>();
            List<string> lines = json.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Where(l => l.StartsWith("\"name\"")).ToList();
            for (int i = 0; i < 3; i++)
            {
                if (i + 1 > lines.Count())
                    break;

                string l = lines[i].Split(new[] { "\"name\":\"" }, StringSplitOptions.None)[1];
                l = l.Substring(0, l.Length - 2);

                list.Add(l);
            }

            return list;
        }
    }
}
