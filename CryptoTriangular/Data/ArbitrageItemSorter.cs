using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{

    public class ArbitrageItemSorter : IComparer<ArbitrageItem>
    {
        public enum SField { StepOne, StepTwo, StepThree, Profit, PercentBenefit }
        SField _sField;        
        SortOrder _sortOrder;      
        

        public ArbitrageItemSorter(SField field, SortOrder order)
        { 
            _sField = field; 
            _sortOrder = order;
        }
                  

        public int Compare(ArbitrageItem x, ArbitrageItem y)
        {
            if (_sortOrder == SortOrder.Descending)
            {
                ArbitrageItem tmp = x;
                x = y;
                y = tmp;
            }

            if (x == null || y == null)
                return 0;

            int result = 0;
            switch (_sField)
            {
                case SField.StepOne:
                    result = x.StepOne.CompareTo(y.StepOne);
                    break;
                case SField.StepTwo:
                    result = x.StepTwo.CompareTo(y.StepTwo);
                    break;
                case SField.StepThree:
                    result = x.StepThree.CompareTo(y.StepThree);
                    break;
                case SField.Profit:
                    result = x.Profit.CompareTo(y.Profit);
                    break;
                case SField.PercentBenefit:
                    result = x.PercentBenefit.CompareTo(y.PercentBenefit);
                    break;
            }

            return result;
        }
    }
}
