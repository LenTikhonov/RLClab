using System;
using System.Collections.Generic;
using System.Text;

namespace RLClab
{
    class SummaryBonusS : BonusS
    {
        private double _precent;
        private int _minSumm;

        public SummaryBonusS(double percent, int minSumm)
        {
            _precent = percent;
            _minSumm = minSumm;
        }

        public double GetBonus(Item item)
        {
            if (item.GetSumm() > _minSumm)
            {
                return _precent;
            }
            return 0;
        }
    }
}