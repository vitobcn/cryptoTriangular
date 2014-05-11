using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Newtonsoft.Json;

namespace Logic
{

    public class DataCollector
    {
        public double val;
        public Dictionary<string, double> differences = new Dictionary<string, double>();
        public IList<ArbitrageItem> arbitrageList = new List<ArbitrageItem>(); 
        public int finishCounter = 0;
        public List<Thread> ThreadArray = new List<Thread>();
        
        public List<List<string>> ThreadsListsOfTracks = new List<List<string>>();

        public List<string> thread1List = new List<string>();
        public List<string> thread2List = new List<string>();
        public List<string> thread3List = new List<string>();
        public List<string> thread4List = new List<string>();
        public List<string> thread5List = new List<string>();
        public List<string> thread6List = new List<string>();
        public List<string> thread7List = new List<string>();
        public List<string> thread8List = new List<string>();
        public List<string> thread9List = new List<string>();
        public List<string> thread0List = new List<string>();

        public DataCollector()
        {
            ThreadsListsOfTracks.Add(thread0List);
            ThreadsListsOfTracks.Add(thread1List);
            ThreadsListsOfTracks.Add(thread2List);
            ThreadsListsOfTracks.Add(thread3List);
            ThreadsListsOfTracks.Add(thread4List);
            ThreadsListsOfTracks.Add(thread5List);
            ThreadsListsOfTracks.Add(thread6List);
            ThreadsListsOfTracks.Add(thread7List);
            ThreadsListsOfTracks.Add(thread8List);
            ThreadsListsOfTracks.Add(thread9List);
        }

        public void StartNeededThreads(int i)
        {
            //ThreadArray.Clear();
            for (int k = 0; k < i; k++)
            {
                //ThreadStart start = new ThreadStart(PerformTask1);
                Thread th = new Thread(new ParameterizedThreadStart(PerformTask1));
                th.Start(k);
            }
        }

        public void ClearThreadLists()
        {
            thread1List.Clear();
            thread2List.Clear();
            thread3List.Clear();
            thread4List.Clear();
            thread5List.Clear();
            thread6List.Clear();
            thread7List.Clear();
            thread8List.Clear();
            thread9List.Clear();
            thread0List.Clear();
            differences.Clear();
        }

        public void InvokeComputingMethod()
        {
            arbitrageList.Clear();
            Track track = new Track();
            if (Options.Instance.OnlyFavouriteTracks != true)
                track.generateTrack();
            else
                track.tracks = Options.Instance.definedTracks;

            ClearThreadLists();
            for (int i = 0; i < track.tracks.Count; i++)
            {
                #region prepare lists
                var rest = i%10;
                switch (rest)
                {
                    case 0 :
                    {
                        thread0List.Add(track.tracks[i]);
                        break;
                    }
                    case 1:
                    {
                        thread1List.Add(track.tracks[i]);
                        break;
                    }
                    case 2:
                    {
                        thread2List.Add(track.tracks[i]);
                        break;
                    }
                    case 3:
                    {
                        thread3List.Add(track.tracks[i]);
                        break;
                    }
                    case 4:
                    {
                        thread4List.Add(track.tracks[i]);
                        break;
                    }
                    case 5:
                    {
                        thread5List.Add(track.tracks[i]);
                        break;
                    }
                    case 6:
                    {
                        thread6List.Add(track.tracks[i]);
                        break;
                    }
                    case 7:
                    {
                        thread7List.Add(track.tracks[i]);
                        break;
                    }
                    case 8:
                    {
                        thread8List.Add(track.tracks[i]);
                        break;
                    }
                    case 9:
                    {
                        thread9List.Add(track.tracks[i]);
                        break;
                    }
                    default:
                    {
                        break;
                    }

                }
                #endregion
            }

            var confirmationNeeded = track.tracks.Count > 10 ? 10 : track.tracks.Count;
            finishCounter = 0;
            StartNeededThreads(confirmationNeeded);
            while (finishCounter < confirmationNeeded) { }
            //StopNeededThreads(confirmationNeeded);
        }

        #region PERFORMING TASKS
        public void PerformTask1(object numberOfList)
        {
            int indexOfList = Convert.ToInt32(numberOfList);
            foreach (string item in ThreadsListsOfTracks[indexOfList])
            {
                var newTrack = new Track();
                newTrack.path = newTrack.decodeTrack(item);
                if (newTrack.getJson() == false)
                    continue;
                if(!Options.Instance.complexArbitrageAnalysis)
                    ComputeArbitrage(newTrack);
                else
                    ComputeArbitrageInDetails(newTrack);
                //differences.Add(item, val);
            }
            finishCounter++;
        }
        #endregion

        public void ComputeArbitrage(Track track)
        {
            double fee;
            double min_doge_double =0, min_ltc_double = 0, min_btc_double = 0;
            double price1 = 0, price2 = 0, price3 = 0;
            double amountBTC = 0;
            double min_ltc_minus_fee = 0, min_btc_minus_fee = 0, min_doge_minus_fee = 0, tmp=0;

            #region ETAP 1
            //
            //ETAP 1 BTC-LTC 
            // 
            
            if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode &&
                track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)
            {
                min_btc_double = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[0].total.Replace('.', ','));
                price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                price1 = Math.Round(price1, 10, MidpointRounding.AwayFromZero);
                min_ltc_double = min_btc_double*price1;//.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[0].quantity.Replace('.', ','));
                fee = FeeTransaction(track.path,0);
                min_ltc_minus_fee = (min_ltc_double)*(1 - fee);
                min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);
                
            }
            else //(path[0] == orders_ltcbtc.@return.markets.ABC.primarycode && path[1] == orders_ltcbtc.@return.markets.ABC.secondarycode)
            {
                min_ltc_double = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[0].total.Replace('.', ','));
                price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                price1 = Math.Round(price1, 10, MidpointRounding.AwayFromZero);
                min_btc_double = min_ltc_double / price1;// Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[0].quantity.Replace('.', ','));
                min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                fee = FeeTransaction(track.path,0);
                min_ltc_minus_fee = min_ltc_double * (1 - fee);
            }
            #endregion

            //
            //ETAP 2 LTC-DOGE
            //

            if (track.path[1] == track.jsons[1].@return.markets.ABC.secondarycode &&
                track.path[2] == track.jsons[1].@return.markets.ABC.primarycode)
            {
                if (min_ltc_minus_fee >
                    Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[0].total.Replace('.', ',')))
                {
                    min_ltc_minus_fee =  Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[0].total.Replace('.', ','));
                    var tmpFee = FeeTransaction(track.path,0);
                    min_ltc_double = min_ltc_minus_fee / (1 - tmpFee)*1.00;
                    min_ltc_double = Math.Round(min_ltc_double, 10, MidpointRounding.AwayFromZero);

                    if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode && track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)
                    {
                        price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double * price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double / price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }                    
                }

                price2 = Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                min_doge_double = min_ltc_minus_fee / price2;
                min_doge_double = Math.Round(min_doge_double, 10, MidpointRounding.AwayFromZero);
            }
            else //(path[0] == track.jsons[0].@return.markets.ABC.primarycode && path[1] == track.jsons[0].@return.markets.ABC.secondarycode)
            {
                if (min_ltc_minus_fee >
                    Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].quantity.Replace('.', ',')))
                {
                    tmp = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].total.Replace('.', ','));
                    double tmpprice = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                    min_ltc_minus_fee = tmp * tmpprice;// Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].quantity.Replace('.', ','));
                    min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);

                    var tmpFee = FeeTransaction(track.path,0);
                    min_ltc_double = min_ltc_minus_fee / (1 - tmpFee);
                    min_ltc_double = Math.Round(min_ltc_double, 10, MidpointRounding.AwayFromZero);
                    //przelicz        
                    if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode && track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)   
                    {
                        price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double * price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        //min_ltc_double = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].quantity.Replace('.', ','));
                        price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double / price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }
                }
                price2 = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                min_doge_double = min_ltc_minus_fee * price2;
                min_doge_double = Math.Round(min_doge_double, 10, MidpointRounding.AwayFromZero);
            }
            //odlicz opłaty (fee) za transakcje
            fee = FeeTransaction(track.path,1);
            min_doge_minus_fee = (min_doge_double * (1 - fee));
            min_doge_minus_fee = Math.Round(min_doge_minus_fee, 10, MidpointRounding.AwayFromZero);

            //
            //ETAP 3 DOGE-BTC
            //
            if (track.path[2] == track.jsons[2].@return.markets.ABC.primarycode &&
                track.path[3] == track.jsons[2].@return.markets.ABC.secondarycode)
            {
                
                if (min_doge_minus_fee >
                    Convert.ToDouble(track.jsons[2].@return.markets.ABC.sellorders[0].quantity.Replace('.', ',')))
                {
                    //przelicz od poczatku
                    min_doge_minus_fee = Convert.ToDouble(track.jsons[2].@return.markets.ABC.sellorders[0].quantity.Replace('.', ','));

                    price3 = Convert.ToDouble(track.jsons[2].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                    amountBTC = min_doge_minus_fee * price3;//zgadza sie z wartoscią sellorders[0].total
                    amountBTC = Math.Round(amountBTC, 10, MidpointRounding.AwayFromZero);

                    var tmpFee = FeeTransaction(track.path,1);
                    min_doge_double = (min_doge_minus_fee / (1 - tmpFee));
                    min_doge_double = Math.Round(min_doge_double, 10, MidpointRounding.AwayFromZero);

                    if (track.path[1] == track.jsons[1].@return.markets.ABC.secondarycode &&
                        track.path[2] == track.jsons[1].@return.markets.ABC.primarycode)
                    {
                        price2 = Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                        min_ltc_minus_fee = (min_doge_double * price2);
                        min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        price2 = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                        min_ltc_minus_fee = (min_doge_double * price2);
                        min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);
                    }

                    tmpFee = FeeTransaction(track.path,0);
                    min_ltc_double = min_ltc_minus_fee / (1 - tmpFee);
                    min_ltc_double = Math.Round(min_ltc_double, 10, MidpointRounding.AwayFromZero);

                    if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode && track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)
                    {
                        price1 =
                            Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double * price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double / price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    price3 = Convert.ToDouble(track.jsons[2].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                    amountBTC = min_doge_minus_fee*price3;
                    amountBTC = Math.Round(amountBTC, 10, MidpointRounding.AwayFromZero);
                } 
            }
            else
            {
                if (min_doge_double > Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[0].quantity.Replace('.', ',')))
                {
                    // przelicz od poczatku
                    tmp = Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[0].total.Replace('.', ','));
                    price3 = Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                    min_doge_minus_fee = tmp * price3;
                    min_doge_minus_fee = Math.Round(min_doge_minus_fee, 10, MidpointRounding.AwayFromZero);

                    price3 = Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                    amountBTC = min_doge_minus_fee / price3;
                    amountBTC = Math.Round(amountBTC, 10, MidpointRounding.AwayFromZero);

                    var tmpFee = FeeTransaction(track.path,1);
                    min_doge_double = (min_doge_minus_fee / (1 - tmpFee));
                    min_doge_double = Math.Round(min_doge_double, 10, MidpointRounding.AwayFromZero);

                    if (track.path[1] == track.jsons[1].@return.markets.ABC.secondarycode &&
                        track.path[2] == track.jsons[1].@return.markets.ABC.primarycode)
                    {
                        price2 =
                            Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                        min_ltc_minus_fee = (min_doge_double * price2);
                        min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        price2 =
                            Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                        min_ltc_minus_fee = (min_doge_double * price2);
                        min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);
                    }

                    tmpFee = FeeTransaction(track.path,0);
                    min_ltc_double = min_ltc_minus_fee / (1 - tmpFee);
                    min_ltc_double = Math.Round(min_ltc_double, 10, MidpointRounding.AwayFromZero);

                    if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode && track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)
                    {
                        price1 =
                            Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double * price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        price1 =
                            Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[0].price.Replace('.', ','));
                        min_btc_double = (min_ltc_double/price1);
                        min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    min_doge_minus_fee = Math.Round(min_doge_minus_fee, 10, MidpointRounding.AwayFromZero);
                    price3 = Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[0].price.Replace('.', ','));
                    price3 = Math.Round(price3, 10, MidpointRounding.AwayFromZero);
                    amountBTC = min_doge_minus_fee / price3;
                    amountBTC = Math.Round(amountBTC, 10, MidpointRounding.AwayFromZero);
                }
                
            }

            fee = FeeTransaction(track.path,2);
            amountBTC = (amountBTC * (1 - fee));
            amountBTC = Math.Round(amountBTC, 10, MidpointRounding.AwayFromZero);

            //
            //FINAL STAGE - COMPUTE PROFIT
            //
            #region Compute PROFIT and DISPLAY
            var difference = amountBTC - min_btc_double;

            this.val = difference;

            if (difference!=0)
            {
                //var BRAWO = "BRAWO JEST OKAZJA DO ARBITRAZU";
                ArbitrageItem arbitrageItem = new ArbitrageItem();
                if (min_btc_double < 0.000001 || min_ltc_double < 0.000000001 || min_doge_double < 0.0000000001)
                    return;
                
                arbitrageItem.Fill(track.path, String.Format("{0:F10}", min_btc_double),
                    String.Format("{0:F10}", min_ltc_minus_fee),
                    String.Format("{0:F10}", min_doge_minus_fee),
                    String.Format("{0:F10}", amountBTC),
                    String.Format("{0:F10}", price1),
                    String.Format("{0:F10}", price2),
                    String.Format("{0:F10}", price3));
                arbitrageItem.Profit = String.Format("{0:F10}",difference);
                arbitrageItem.PercentBenefit = Convert.ToDouble(String.Format("{0:F10}", difference)) * 100 / min_btc_double;
                if (Options.Instance.displayAllPaths == false)
                {
                    if (arbitrageItem.PercentBenefit > Options.Instance.minPercentBenefit)
                        arbitrageList.Add(arbitrageItem);
                }
                else
                {
                    arbitrageList.Add(arbitrageItem);
                }
            }
            #endregion
        }

        private double FeeTransaction(List<string> path, int step)
        {
            // ltc->btc - fee 0,2%
            // ltc || btc -> alt - fee 0,2%
            // alt ->  ltc || btc - fee 0,3%
            // btc->ltc - fee 0,3%
            if (path[step].Equals("LTC") &&
                path[step+1].Equals("BTC"))
            {
                //0,2%
                return 0.002;
            }
            if (path[step].Equals("BTC") &&
                path[step+1].Equals("LTC"))
            {
                //0,3%
                return 0.003;
            }
            if (path[step].Equals("LTC") || path[step].Equals("BTC"))
            {
                //0,2%
                return 0.002;
            }
            if (path[step + 1].Equals("LTC") || path[step+1].Equals("BTC"))
            {
                //0,3%
                return 0.003;
            }
            return 0;
        }


        public void ComputeArbitrageInDetails(Track track)
        {
            List<OffersIndicator> offersIndicators = CreateVariationWithRepeats(3);
            List<ComputedPaths> computedPaths = new List<ComputedPaths>();

            foreach (var Indicator in offersIndicators)
            {
                ComputeSinglePath(Indicator,track, computedPaths);
            }
        }

        public void ComputeSinglePath(OffersIndicator Indicator, Track track,List<ComputedPaths> computedPaths)
        {
            #region VARIABLES
            double fee;
            double min_doge_double = 0, min_ltc_double = 0, min_btc_double = 0;
            double price1 = 0, price2 = 0, price3 = 0;
            double amountBTC = 0;
            double min_ltc_minus_fee = 0, min_btc_minus_fee = 0, min_doge_minus_fee = 0, tmp = 0;

            double btc_common = 0, ltc_common = 0, doge_common = 0, btc_common_final = 0;
            #endregion

            #region STEP 1
            for (int i = 0; i < Indicator.one; i++)
            {
                //zbierz oferty
                if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode &&
                    track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)
                {
                    min_btc_double = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[i].total.Replace('.', ','));
                    price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[i].price.Replace('.', ','));
                    price1 = Math.Round(price1, 10, MidpointRounding.AwayFromZero);
                    min_ltc_double = min_btc_double * price1;
                    fee = FeeTransaction(track.path, 0);
                    min_ltc_minus_fee = (min_ltc_double) * (1 - fee);
                    min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);
                }
                else
                {
                    min_ltc_double = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[i].total.Replace('.', ','));
                    price1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[i].price.Replace('.', ','));
                    price1 = Math.Round(price1, 10, MidpointRounding.AwayFromZero);
                    min_btc_double = min_ltc_double / price1;
                    min_btc_double = Math.Round(min_btc_double, 10, MidpointRounding.AwayFromZero);
                    fee = FeeTransaction(track.path, 0);
                    min_ltc_minus_fee = min_ltc_double * (1 - fee);
                    min_ltc_minus_fee = Math.Round(min_ltc_minus_fee, 10, MidpointRounding.AwayFromZero);
                }

                btc_common += min_btc_double;
                ltc_common += min_ltc_minus_fee;
            }
            #endregion

            #region ETAP 2
            double[] temp_LTC = new double[Indicator.two];
            double[] temp_price2 = new double[Indicator.two];
            for (int j = 0; j < Indicator.two; j++)
            {
                //zbierz oferty DOGE
                if (track.path[1] == track.jsons[1].@return.markets.ABC.secondarycode && track.path[2] == track.jsons[1].@return.markets.ABC.primarycode)
                {
                    temp_price2[j] = Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[j].price.Replace('.', ','));
                    min_doge_double = Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[j].quantity.Replace('.', ','));
                    temp_LTC[j] = Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[j].total.Replace('.', ','));
                }
                else 
                {
                    temp_price2[j] = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[j].price.Replace('.', ','));
                    min_doge_double = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[j].quantity.Replace('.', ','));
                    temp_LTC[j] = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[j].total.Replace('.', ','));
                }
                //odlicz opłaty (fee) za transakcje
                fee = FeeTransaction(track.path, 1);
                min_doge_minus_fee = (min_doge_double * (1 - fee));
                min_doge_minus_fee = Math.Round(min_doge_minus_fee, 10, MidpointRounding.AwayFromZero);

                doge_common += min_doge_minus_fee;
            }
            
            //jesli za mało ltc to trudno KONIEC będą inne ścieżki krotsze na ktore wystarczy
            if (ltc_common < temp_LTC.Sum())
                return;

            //jeśli wystarczyło to przelicz tak zeby nic nie zostało - sie nie zmarnowało 
            var tempLtcSum = temp_LTC.Sum();
            double tmpMinLtcSum = 0;
            double tmpMinBtcSum = 0;
            double tmpPrice1 = 0;
            for (int i = 0; i < Indicator.one; i++)
            {
                double tmpMinBtcDouble = 0;
                double tmpMinLtcDouble = 0;
                double tmpMinLtcMinusFee = 0;
                if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode &&
                    track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)
                {
                    tmpMinBtcDouble = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[i].total.Replace('.', ','));
                    tmpPrice1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[i].price.Replace('.', ','));
                    tmpPrice1 = Math.Round(tmpPrice1, 10, MidpointRounding.AwayFromZero);
                    tmpMinLtcDouble = tmpMinBtcDouble * tmpPrice1;
                }
                else
                {
                    tmpMinLtcDouble = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[i].total.Replace('.', ','));
                    tmpPrice1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[i].price.Replace('.', ','));
                    tmpPrice1 = Math.Round(tmpPrice1, 10, MidpointRounding.AwayFromZero);
                    tmpMinBtcDouble = tmpMinLtcDouble / tmpPrice1;
                    
                }
                fee = FeeTransaction(track.path, 0);
                tmpMinLtcMinusFee = (tmpMinLtcDouble) * (1 - fee);
                tmpMinLtcSum += Math.Round(tmpMinLtcMinusFee, 10, MidpointRounding.AwayFromZero);
                if (tempLtcSum >= tmpMinLtcSum)
                {
                    tmpMinBtcSum += tmpMinBtcDouble;
                    continue;
                }
                else if (tempLtcSum < tmpMinLtcSum)
                {
                    tmpMinLtcSum = tmpMinLtcSum - tmpMinLtcMinusFee;
                    var difference = tempLtcSum - tmpMinLtcSum;
                    tmpMinLtcSum = tmpMinLtcSum + difference;
                    var howMuchWeNeedToBuy = difference / (1 - fee);
                    var amountOfBtc = howMuchWeNeedToBuy / tmpPrice1;
                    tmpMinBtcSum += amountOfBtc;
                    break;
                }
            }
            btc_common = tmpMinBtcSum;
            ltc_common = tmpMinLtcSum;
            #endregion

            #region ETAP 3
            double[] temp_DOGE = new double[Indicator.three];
            double[] temp_price3 = new double[Indicator.three];
            double final_btc = 0.0;
            double final_btc_minus_fee = 0.0;
            for (int k = 0; k < Indicator.three; k++)
            {
                //zbierz oferty btc
                if (track.path[2] == track.jsons[2].@return.markets.ABC.primarycode &&
                    track.path[3] == track.jsons[2].@return.markets.ABC.secondarycode)
                {
                    temp_price3[k] = Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[k].price.Replace('.', ','));
                    final_btc = Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[k].quantity.Replace('.', ','));
                    temp_DOGE[k] = Convert.ToDouble(track.jsons[2].@return.markets.ABC.buyorders[k].total.Replace('.', ','));
                }
                else
                {
                    temp_price3[k] = Convert.ToDouble(track.jsons[2].@return.markets.ABC.sellorders[k].price.Replace('.', ','));
                    final_btc = Convert.ToDouble(track.jsons[2].@return.markets.ABC.sellorders[k].quantity.Replace('.', ','));
                    temp_DOGE[k] = Convert.ToDouble(track.jsons[2].@return.markets.ABC.sellorders[k].total.Replace('.', ','));
                }

                //odlicz opłaty (fee) za transakcje
                fee = FeeTransaction(track.path, 2);
                final_btc_minus_fee = (final_btc * (1 - fee));
                final_btc_minus_fee = Math.Round(final_btc_minus_fee, 10, MidpointRounding.AwayFromZero);

                btc_common_final += final_btc_minus_fee;
            }
            double tmpPrice3 = temp_price3.Last();

            //jesli za mało doge to trudno KONIEC będą inne ścieżki
            if (doge_common < temp_DOGE.Sum())
                return;

            //jeśli wystarczyło to przelicz tak zeby nic nie zostało - sie nie zmarnowało 
            //przelicz DOGE - LTC
            var tempDogeSum = temp_DOGE.Sum();
            double _tmpMinDogeSum = 0;
            double _tmpMinLtcSum = 0;
            double _tmpMinBtcSum = 0;
            double tmpPrice2 = 0.0;
            for (int i = 0; i < Indicator.two; i++)
            {
                double tmpMinDogeDouble = 0.0;
                double tmpMinLtcDouble = 0.0;
                double tmpMinDogeMinusFee = 0.0;
                
                if (track.path[1] == track.jsons[1].@return.markets.ABC.secondarycode &&
                    track.path[2] == track.jsons[1].@return.markets.ABC.primarycode)
                {
                    //przelicz od poczatku
                    tmpMinLtcDouble = Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[i].total.Replace('.', ','));
                    tmpPrice2 = Convert.ToDouble(track.jsons[1].@return.markets.ABC.buyorders[i].price.Replace('.', ','));
                    tmpPrice2 = Math.Round(tmpPrice2, 10, MidpointRounding.AwayFromZero);
                    tmpMinDogeDouble = tmpMinLtcDouble*tmpPrice2;            
                }
                else
                {
                    //przelicz od poczatku
                    tmpMinLtcDouble = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[i].total.Replace('.', ','));
                    tmpPrice2 = Convert.ToDouble(track.jsons[1].@return.markets.ABC.sellorders[i].price.Replace('.', ','));
                    tmpPrice2 = Math.Round(tmpPrice2, 10, MidpointRounding.AwayFromZero);
                    tmpMinDogeDouble = tmpMinLtcDouble / tmpPrice2;
                }

                fee = FeeTransaction(track.path, 1);
                tmpMinDogeMinusFee = (tmpMinDogeDouble) * (1 - fee);
                _tmpMinDogeSum += Math.Round(tmpMinDogeMinusFee, 10, MidpointRounding.AwayFromZero);

                if (tempDogeSum >= _tmpMinDogeSum)
                {
                    _tmpMinLtcSum += tmpMinLtcDouble;
                    continue;
                }
                else if (tempDogeSum < _tmpMinDogeSum)
                {
                    _tmpMinDogeSum = _tmpMinDogeSum - tmpMinDogeMinusFee;
                    var difference = tempDogeSum - _tmpMinDogeSum;
                    _tmpMinDogeSum = difference + _tmpMinDogeSum;
                    var howMuchWeNeedToBuy = difference / (1 - fee);
                    var amountOfLtc = howMuchWeNeedToBuy / tmpPrice2;
                    _tmpMinLtcSum += amountOfLtc;
                    break;
                }
            }
            doge_common = _tmpMinDogeSum;
            ltc_common = _tmpMinLtcSum;

            //przelicz LTC-BTC idąc wstecz tak zeby nic sie nie zmarnowało..
            //jeśli wystarczyło to przelicz tak zeby nic nie zostało - sie nie zmarnowało 
            tempLtcSum = ltc_common;
            tmpMinLtcSum = 0;
            tmpMinBtcSum = 0;
            for (int i = 0; i < Indicator.one; i++)
            {
                double tmpMinBtcDouble = 0;
                double tmpMinLtcDouble = 0;
                double tmpMinLtcMinusFee = 0;
                if (track.path[0] == track.jsons[0].@return.markets.ABC.secondarycode &&
                    track.path[1] == track.jsons[0].@return.markets.ABC.primarycode)
                {
                    tmpMinBtcDouble = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[i].total.Replace('.', ','));
                    tmpPrice1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.buyorders[i].price.Replace('.', ','));
                    tmpPrice1 = Math.Round(tmpPrice1, 10, MidpointRounding.AwayFromZero);
                    tmpMinLtcDouble = tmpMinBtcDouble * tmpPrice1;
                }
                else
                {
                    tmpMinLtcDouble = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[i].total.Replace('.', ','));
                    tmpPrice1 = Convert.ToDouble(track.jsons[0].@return.markets.ABC.sellorders[i].price.Replace('.', ','));
                    tmpPrice1 = Math.Round(tmpPrice1, 10, MidpointRounding.AwayFromZero);
                    tmpMinBtcDouble = tmpMinLtcDouble / tmpPrice1;

                }
                fee = FeeTransaction(track.path, 0);
                tmpMinLtcMinusFee = (tmpMinLtcDouble) * (1 - fee);
                tmpMinLtcSum += Math.Round(tmpMinLtcMinusFee, 10, MidpointRounding.AwayFromZero);
                if (tempLtcSum >= tmpMinLtcSum)
                {
                    tmpMinBtcSum += tmpMinBtcDouble;
                    continue;
                }
                else if (tempLtcSum < tmpMinLtcSum)
                {
                    tmpMinLtcSum = tmpMinLtcSum - tmpMinLtcMinusFee;
                    var difference = tempLtcSum - tmpMinLtcSum;
                    tmpMinLtcSum = tmpMinLtcSum + difference;
                    var howMuchWeNeedToBuy = difference / (1 - fee);
                    var amountOfBtc = howMuchWeNeedToBuy / tmpPrice1;
                    tmpMinBtcSum += amountOfBtc;
                    break;
                }
            }
            btc_common = tmpMinBtcSum;
            ltc_common = tmpMinLtcSum;
            #endregion

            #region Add to list and compute profit
            //
            //FINAL STAGE - COMPUTE PROFIT
            //

            double finalDiff = btc_common_final - btc_common;

            //this.val = difference;

            if (finalDiff > 0.0)
            {
                //var BRAWO = "BRAWO JEST OKAZJA DO ARBITRAZU";
                ArbitrageItem arbitrageItem = new ArbitrageItem();
                //if (min_btc_double < 0.000001 || min_ltc_double < 0.000000001 || min_doge_double < 0.0000000001)
                //    return;



                arbitrageItem.Fill(track.path, String.Format("{0:F10}", btc_common),
                    String.Format("{0:F10}", ltc_common),
                    String.Format("{0:F10}", doge_common),
                    String.Format("{0:F10}", btc_common_final),
                    String.Format("{0:F10}", tmpPrice1),
                    String.Format("{0:F10}", tmpPrice2),
                    String.Format("{0:F10}", tmpPrice3));
                arbitrageItem.Profit = String.Format("{0:F10}", finalDiff);
                arbitrageItem.PercentBenefit = Convert.ToDouble(String.Format("{0:F10}", finalDiff)) * 100 / btc_common;
                
                computedPaths.Add(new ComputedPaths(arbitrageItem.PercentBenefit,arbitrageItem.Profit,track, Indicator));
                if (Options.Instance.displayAllPaths == false)
                {
                    if (arbitrageItem.PercentBenefit > Options.Instance.minPercentBenefit)
                        arbitrageList.Add(arbitrageItem);
                }
                else
                {
                    arbitrageList.Add(arbitrageItem);
                }
            }
            #endregion
        }

        public List<OffersIndicator> CreateVariationWithRepeats(int howDeep=2)
        {
            List<OffersIndicator> offersIndicators = new List<OffersIndicator>();
            for (int i = 1; i <= howDeep; i++)
            {
                for (int j = 1; j <= howDeep; j++)
                {
                    for (int k = 1; k <= howDeep; k++)
                    {
                        offersIndicators.Add(new OffersIndicator(i,j,k));
                    }
                }
            }
            return offersIndicators;
        }

        public class OffersIndicator
        {
            public int one;
            public int two;
            public int three;

            public OffersIndicator(int _1, int _2, int _3)
            {
                one = _1;
                two = _2;
                three = _3;
            }
        }

        public class ComputedPaths
        {
            public double PercentageProfit;
            public string UnitProfit;
            public Track Track;
            public OffersIndicator Indicator;

            public ComputedPaths(double percentProfit, string unitProfit, Track track, OffersIndicator indicator)
            {
                PercentageProfit = percentProfit;
                UnitProfit = unitProfit;
                Track = track;
                Indicator = indicator;
            }
        }
    }
}



/* private double FeeTransaction(CryptsyJson.RootObject orderbook)
 {
     // ltc->btc - fee 0,2%
     // ltc || btc -> alt - fee 0,2%
     // alt ->  ltc || btc - fee 0,3%
     // btc->ltc - fee 0,3%
     if (orderbook.@return.markets.ABC.primarycode.Equals("LTC") &&
         orderbook.@return.markets.ABC.secondarycode.Equals("BTC"))
     {
         //0,2%
         return 0.002;
     }
     if (orderbook.@return.markets.ABC.primarycode.Equals("BTC") &&
         orderbook.@return.markets.ABC.secondarycode.Equals("LTC"))
     {
         //0,3%
         return 0.003;
     }
     if (orderbook.@return.markets.ABC.primarycode.Equals("LTC") || orderbook.@return.markets.ABC.primarycode.Equals("BTC"))
     {
         //0,2%
         return 0.002;
     }
     if (orderbook.@return.markets.ABC.secondarycode.Equals("LTC") || orderbook.@return.markets.ABC.secondarycode.Equals("BTC"))
     {
         //0,3%
         return 0.003;
     }
     return 0;
 }*/