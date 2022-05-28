using System;
using System.Collections.Generic;
using System.Text;

namespace RLClab
{
    public class QuantityDiscountS : DiscountS
    {
        private double _precent;
        private int _minQty;

        public QuantityDiscountS(double percent, int minQty)
        {
            _precent = percent;
            _minQty = minQty;
        }

        public double GetDiscount(Item item)
        {
            if (item.GetQuantity() > _minQty)
            {
                return _precent;
            }
            return 0;
        }
    }
}
