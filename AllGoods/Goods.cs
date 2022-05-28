using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLClab
{
    public class Goods
    {
        protected String _title;
        protected BonusS _bonusStrategy;
        protected DiscountS _discountStrategy;
        protected UsedBonusS _usedBonusStrategy;

        public Goods(String title, BonusS bonusStrategy, DiscountS discountStrategy, UsedBonusS usedBonusStrategy)
        {
            _title = title;
            _bonusStrategy = bonusStrategy;
            _discountStrategy = discountStrategy;
            _usedBonusStrategy = usedBonusStrategy;

        }
        public String GetTitle()
        {
            return _title;
        }
        public virtual double GetUsedBonus(Item item, Customer customer)
        {
            return _usedBonusStrategy.GetUsedBonus(item, customer);
        }
        public virtual int GetBonus(Item item)
        {
            return (int)(item.GetSumm() * _bonusStrategy.GetBonus(item));
        }

        public virtual double GetDiscount(Item item)
        {
            return item.GetSumm() * _discountStrategy.GetDiscount(item);
        }
    }
}