using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public sealed class Options
    {
        static Options _instance =  new Options();
        public bool HideBalloonAfter5thDisplay;
        public decimal TimerInterval { get; set; }
        public bool displayAllPaths { get; set; }
        public bool DisplayBalloonWhenPercentChanges { get; set; }
        public bool SoundNotification { get; set; }
        public bool OnlyFavouriteTracks { get; set; }
        public double minPercentBenefit { get; set; }
        public List<string> selectedCurrency = new List<string>();
        public List<string> definedTracks = new List<string>();
        public bool accountLocked { get; set; }
        public bool complexArbitrageAnalysis { get; set; }

        public static Options Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public Options()
        {
            TimerInterval = 30000;
            HideBalloonAfter5thDisplay = OnlyFavouriteTracks = displayAllPaths= false;
            DisplayBalloonWhenPercentChanges = true;
            SoundNotification = true;
            minPercentBenefit = 0.01;
            complexArbitrageAnalysis = false;
            //selectedCurrency = Enum.GetNames(typeof(CurrencyCode)).ToList();
        }      
    }
}
