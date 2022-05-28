using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLClab
{
    public class StrategyFactory
    {
        public BonusS CreateBonusStrategy(string type, double percent, int minSumm)
        {
            if (type == "SummBonus") return new QuantityBonusS(percent, minSumm);
            if (type == "QtyBonus") return new SummaryBonusS(percent, minSumm);
            return null;
        }

        public DiscountS CreateDiscountStrategy(string type, double percent, int minSumm)
        {
            if (type == "SummDiscount") return new QuantityDiscountS(percent, minSumm);
            if (type == "QtyDiscount") return new SummaryDiscountS(percent, minSumm);
            return null;
        }

        public UsedBonusS CreateUsedBonus(string type, int minSumm)
        {
            if (type == "QtyUsedBonus") return new QtyUsedBonus(minSumm);
            return null;
        }
    }
}
