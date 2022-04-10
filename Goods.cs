using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLClab
{
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int GetPriceCode()
        {
            return _priceCode;
        }
        public void SetPriceCode(int priceCode)
        {
            _priceCode = priceCode;
        }
        public String GetTitle()
        {
            return _title;
        }
        private static double GetSumm(Item item)
        {
            return item.GetQuantity() * item.GetPrice();
        }

        public int GetBonus(Item item)
        {
            switch (item.GetGoods()._priceCode)
            {
                case Goods.REGULAR:
                    return (int)(GetSumm(item) * 0.05);
                case Goods.SALE:
                    return (int)(GetSumm(item) * 0.01);
            }
            return 0;
        }

        public double GetDiscount(Item item)
        {
            switch (item.GetGoods().GetPriceCode())
            {
                case Goods.REGULAR:
                    if (item.GetQuantity() > 2)
                        return GetSumm(item) * 0.03; // 3%
                    break;
                case Goods.SPECIAL_OFFER:
                    if (item.GetQuantity() > 10)
                        return (GetSumm(item)) * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (item.GetQuantity() > 3)
                        return GetSumm(item) * 0.01; // 0.1%
                    break;
            }
            return 0;
        }
    }
}