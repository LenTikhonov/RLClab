using System;
using System.Collections.Generic;
using System.Text;

namespace RLClab
{
    public class QtyUsedBonus : UsedBonusS
    {
        private int _minQty;

        public QtyUsedBonus(int minQty)
        {
            _minQty = minQty;
        }

        public double GetUsedBonus(Item item, Customer customer)
        {
            if (item.GetQuantity() > _minQty)
                return customer.UseBonus((int)(item.GetSumm()));
            return 0;
        }
    }
}
