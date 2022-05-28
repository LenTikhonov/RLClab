
using System;
using System.Collections.Generic;

namespace RLClab
{
    public class GoodsFactory
    {
        Dictionary<string, Dictionary<string, Settings>> _config;
        public GoodsFactory(Dictionary<string, Dictionary<string, Settings>> config)
        {
            _config = config;
        }
        public Goods Create(string type, string title)
        {
            var strategyFactory = new StrategyFactory();
            var strategies = _config[type];

            var bonusStrategyType = "QtyBonus";
            var discountStrategyType = "QtyDiscount";
            var usedBonusStrategyType = "QtyUsedBonus";

            var now = DateTime.Now;
            if ((now > new DateTime(now.Year, 12, 24))
                & (now < new DateTime(now.Year, 12, 31)))
            {
                bonusStrategyType = "SummBonus";
                discountStrategyType = "SummDiscount";
            }

            var bonusStrategyParams = strategies[bonusStrategyType];
            var discountStrategyPapams = strategies[discountStrategyType];
            var usedBonusStrategyParams = strategies[usedBonusStrategyType];


            var bonusPercent = bonusStrategyParams.percent;
            var bonusMin = bonusStrategyParams.minSumm;
            var discountPercent = discountStrategyPapams.percent;
            var discountMin = discountStrategyPapams.minSumm;
            var usedBonusMin = usedBonusStrategyParams.minSumm;

            BonusS bonusStrategy = strategyFactory.CreateBonusStrategy(bonusStrategyType, bonusPercent, bonusMin);
            DiscountS discountStrategy = strategyFactory.CreateDiscountStrategy(discountStrategyType, discountPercent, discountMin);
            UsedBonusS usedBonusStrategy = strategyFactory.CreateUsedBonus(usedBonusStrategyType, usedBonusMin);


            return new Goods(title, bonusStrategy, discountStrategy, usedBonusStrategy);
        }
    }
}
