using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public enum CurrencyCode
    {
        BTC,
        LTC, 
        DOGE, 
        AUR,       
        NXT,
        PPC, 
        QRK, 
        WDC,
        BC,
        ZET,
        IFC,
        XPM,
        DGC,
        FRK,
        GLD,
        NET,
        PXC,
        SBC,
        YAC
    }

    public class Markets
    {
        //Słownik id marketów
        public Dictionary< string, int> markets = new Dictionary<string, int>()
        {
               {"BTCLTC",3},
               {"DOGELTC",135},
               {"DOGEBTC",132},
               {"AURLTC",161},
               {"AURBTC",160},
               {"NXTLTC",162},
               {"NXTBTC",159},
               {"PPCLTC",125},
               {"PPCBTC",28},
               {"QRKLTC",126},
               {"QRKBTC",71},
               {"WDCLTC",21},
               {"WDCBTC",14},
               {"BCBTC",179},
               {"BCLTC",191},
               {"ZETBTC",85},
               {"ZETLTC",127},
               {"IFCBTC",59},
               {"IFCLTC",60},
               {"XPMBTC",63},
               {"XPMLTC",106},
               {"DGCBTC",26},
               {"DGCLTC",96},
               {"FRKBTC",33},
               {"FRKLTC",171},
               {"GLDBTC",30},
               {"GLDLTC",36},
               {"NETBTC",134},
               {"NETLTC",108},
               {"PXCBTC",31},
               {"PXCLTC",101},
               {"SBCBTC",51},
               {"SBCLTC",128},
               {"YACBTC",11},
               {"YACLTC",22}
           
        };

        //Pobieranie id marketu dla odpowiedniego przejscia
        public string getMarketId(string code1, string code2)
        {
            int id;
            try
            {
                id =  this.markets[code1 + code2];
            }
            catch (Exception e)
            {
                id =  this.markets[code2 + code1];
            }

            return Convert.ToString(id);
        }
           

    }


  

    

}
