using System;
using System.Collections.Generic;
using System.Text;

namespace RLClab
{
    public class QuantityBonusS : BonusS
    {
        private double _precent;
        private int _minQty;

        public QuantityBonusS(double percent, int minQty)
        {
            _precent = percent;
            _minQty = minQty;
        }

        public double GetBonus(Item item)
        {
            if (item.GetQuantity() > _minQty)
            {
                return _precent;
            }
            return 0;
        }
    }
}
