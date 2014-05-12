using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Kraken
{
    public static class KrakenUrls
    {
        public static string orderBookKrakenBTCLTC = "https://api.kraken.com/0/public/Depth?pair=BTCLTC";
        public static string orderBookKrakenBTCXDG = "https://api.kraken.com/0/public/Depth?pair=BTCXDG";
        public static string orderBookKrakenBTCNMC = "https://api.kraken.com/0/public/Depth?pair=BTCNMC";
        public static string orderBookKrakenLTCXDG = "https://api.kraken.com/0/public/Depth?pair=LTCXDG";
        public static string orderBookKrakenNMCXDG = "https://api.kraken.com/0/public/Depth?pair=NMCXDG";
    }

    public enum TypeCoinKraken
    {
        Bitcoin = 1,
        Litecoin = 2,
        Namecoin = 3,
        Dogecoin = 4
    }

    public class krakenCurrency
    {
        public List<TypeCoinKraken> relationList = new List<TypeCoinKraken>();
        public List<TypeCoinKraken> recentlyVisited = new List<TypeCoinKraken>();
        public TypeCoinKraken typeCoin;
    }

    public class krakenBitcoin : krakenCurrency
    {
        
        public krakenBitcoin()
        {
            relationList.Add(TypeCoinKraken.Litecoin);
            relationList.Add(TypeCoinKraken.Dogecoin);
            relationList.Add(TypeCoinKraken.Namecoin);
            typeCoin = TypeCoinKraken.Bitcoin;
        }
    }

    public class krakenLitecoin : krakenCurrency
    {
        //public List<TypeCoinKraken> relationList = new List<TypeCoinKraken>();
        
        public krakenLitecoin()
        {
            relationList.Add(TypeCoinKraken.Bitcoin);
            relationList.Add(TypeCoinKraken.Dogecoin);
            typeCoin = TypeCoinKraken.Litecoin;
        }
    }

    public class krakenNamecoin : krakenCurrency
    {
        //public List<TypeCoinKraken> relationList = new List<TypeCoinKraken>();
        
        public krakenNamecoin()
        {
            relationList.Add(TypeCoinKraken.Bitcoin);
            relationList.Add(TypeCoinKraken.Dogecoin);
            relationList.Add(TypeCoinKraken.Bitcoin);
            typeCoin = TypeCoinKraken.Namecoin;
        }
    }

    public class krakenDogecoin : krakenCurrency
    {
        //public List<TypeCoinKraken> relationList = new List<TypeCoinKraken>();
       
        public krakenDogecoin()
        {
            relationList.Add(TypeCoinKraken.Bitcoin);
            relationList.Add(TypeCoinKraken.Litecoin);
            relationList.Add(TypeCoinKraken.Namecoin);
            typeCoin = TypeCoinKraken.Dogecoin;
        }
    }

    //Classes defines two-way relations between alts 
    public class JsonKrakenBTCLTC
    {
        public class XXBTXLTC
        {
            //asks = ask side array of array entries(<price>, <volume>, <timestamp>)
            //bids = bid side array of array entries(<price>, <volume>, <timestamp>)
            public List<List<object>> asks { get; set; }
            public List<List<object>> bids { get; set; }
        }

        public class Result
        {
            public XXBTXLTC XXBTXLTC { get; set; }
        }

        public class RootObject
        {
            public List<object> error { get; set; }
            public Result result { get; set; }
        }
    }

    public class JsonKrakenBTCXDG
    {
        public class XXBTXXDG
        {
            public List<List<object>> asks { get; set; }
            public List<List<object>> bids { get; set; }
        }

        public class Result
        {
            public XXBTXXDG XXBTXXDG { get; set; }
        }

        public class RootObject
        {
            public List<object> error { get; set; }
            public Result result { get; set; }
        }
    }

    public class JsonKrakenBTCNMC
    {
        public class XXBTXNMC
        {
            public List<List<object>> asks { get; set; }
            public List<List<object>> bids { get; set; }
        }

        public class Result
        {
            public XXBTXNMC XXBTXNMC { get; set; }
        }

        public class RootObject
        {
            public List<object> error { get; set; }
            public Result result { get; set; }
        }
    }

    public class JsonKrakenLTCXDG
    {
        public class XLTCXXDG
        {
            public List<List<object>> asks { get; set; }
            public List<List<object>> bids { get; set; }
        }

        public class Result
        {
            public XLTCXXDG XLTCXXDG { get; set; }
        }

        public class RootObject
        {
            public List<object> error { get; set; }
            public Result result { get; set; }
        }
    }

    public class JsonKrakenNMCXDG
    {
        public class XNMCXXDG
        {
            public List<List<object>> asks { get; set; }
            public List<List<object>> bids { get; set; }
        }

        public class Result
        {
            public XNMCXXDG XNMCXXDG { get; set; }
        }

        public class RootObject
        {
            public List<object> error { get; set; }
            public Result result { get; set; }
        }
    }

}
