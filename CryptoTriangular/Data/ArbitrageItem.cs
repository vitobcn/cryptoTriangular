using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ArbitrageItem
    {
        public string StepOne { get; set; }
       // public string ValueNode1 { get; set; }
      //  public string ValueNode1Last { get; set; }
        public string StepTwo { get; set; }
       // public string ValueNode2 { get; set; }
        public string StepThree { get; set; }
       // public string ValueNode3 { get; set; }
        public string Profit { get; set; }
        public double PercentBenefit { get; set; }
      


        public void Fill(List<String> tracks, string start, string min1, string min2, string finish, string price1,string price2, string price3)
        {
            StepOne = tracks[0] + "-" + tracks[1] + Environment.NewLine + 
                "Start ("+tracks[0]+"): "+ start + Environment.NewLine +
                "Price: " + price1 + Environment.NewLine + 
                "Total (" + tracks[1] + "): " + min1;


            StepTwo = tracks[1] + "-" + tracks[2] + Environment.NewLine +
                "Price: " + price2 + Environment.NewLine +
                "Total (" + tracks[2] + "): " + min2;

            StepThree = tracks[2] + "-" + tracks[3] + Environment.NewLine +
                "Price: " + price3 + Environment.NewLine + 
                "Total (" + tracks[3] + "): " + finish;

      //      PercentBenefit = Convert.ToDouble(finish) * 100 / Convert.ToDouble(start);

        }
    }

    
}
