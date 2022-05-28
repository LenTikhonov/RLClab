using System;
using System.Collections.Generic;
using System.Text;

namespace RLClab
{
    public class SummaryDiscountS : DiscountS
    {
        private double _precent;
        private int _minSumm;

        public SummaryDiscountS(double percent, int minSumm)
        {
            _precent = percent;
            _minSumm = minSumm;
        }

        public double GetDiscount(Item item)
        {
            if (item.GetSumm() > _minSumm)
            {
                return _precent;
            }
            return 0;
        }
    }
}
