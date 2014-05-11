using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Data;
using Newtonsoft.Json;

namespace Logic
{
    public class Track
    {
        public List<string> path = new List<string>();
        public IList<CryptsyJson.RootObject> jsons = new List<CryptsyJson.RootObject>();
        public List<string> tracks = new List<string>();
        public string[] test;

        //Pobieranie marketu dla danego przejscia
        public bool getJson()
        {
            jsons.Clear();
            Markets m = new Markets();
            for (int i = 0; i < path.Count - 1; i++)
            {
                try
                {
                    //Orderbooki sciagane z sieci
                    var x = Download_Parse("http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid="
                        + m.getMarketId(path[i], path[i + 1]));
                    jsons.Add(JsonConvert.DeserializeObject<CryptsyJson.RootObject>(x));
                    
                    //czytanie z lokalnego repo zamiast sciagania z sieci
                    //string dir = AppDomain.CurrentDomain.BaseDirectory;
                    //using (
                    //    StreamReader r =
                    //        new StreamReader(dir + String.Format("\\stubData\\{0}-{1}.txt", path[i], path[i + 1])))
                    //{
                    //    string json = r.ReadToEnd();
                    //    jsons.Add(JsonConvert.DeserializeObject<CryptsyJson.RootObject>(json));
                    //}

                    //ta cześć zapisuje wszystkie jsony do plików by zrobic lokalne repo
                    //string dir = AppDomain.CurrentDomain.BaseDirectory;
                    //System.IO.File.WriteAllText(dir + String.Format("\\stubData\\{0}-{1}.txt",path[i],path[i+1]),x);

                }
                catch (Exception)
                {
                    //throw;
                    return false;
                }
            }
            return true;
        }

        private string Download_Parse(string download)
        {
            try
            {
                var client = new WebClient();
                var textjson = client.DownloadString(download);
                if (textjson.StartsWith("{\"success\":1,\"return\":{\"markets\":{\"") == true)
                {
                    int indexOfApostrof = textjson.IndexOf("\"", 36, System.StringComparison.Ordinal);
                    var name = textjson.Substring(35, indexOfApostrof - 35);
                    return Regex.Replace(client.DownloadString(download), "{\"" + name + "\"", "{\"ABC\"");
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Wyznaczanie wszystkich możliwych ścieżek
        public void generateTrack()
        {
            if (Options.Instance.OnlyFavouriteTracks == true)
                tracks = Options.Instance.definedTracks;
            else
                foreach (var code in Options.Instance.selectedCurrency)
                {
                    if (code.Equals("BTC") || code.Equals("LTC"))
                        continue;
                    tracks.Add(code.ToString() + "-LTC-BTC-" + code.ToString());
                    tracks.Add(code.ToString() + "-BTC-LTC-" + code.ToString());
                    tracks.Add("LTC-" + code.ToString() + "-BTC-LTC");
                    tracks.Add("BTC-" + code.ToString() + "-LTC-BTC");
                    tracks.Add("LTC-BTC-" + code.ToString() + "-LTC");
                    tracks.Add("BTC-LTC-" + code.ToString() + "-BTC");
                }

        }

        //Zamiana wyznaczonej ścieżki na tablice
        public List<string> decodeTrack(string track)
        {
            test = track.Split("-".ToCharArray());
            path.Clear();
            path.AddRange(test);
            return path;
        }

        public Boolean checkTrack(string track)
        {            
            decodeTrack(track);
            if (path.Count() != 4 || path[0] != path[3])
                return false;            
            foreach (string code in path)
            {
                if(!Enum.IsDefined(typeof(CurrencyCode),code))
                    return false;
            }
            
            return true;

        }
    }
}
