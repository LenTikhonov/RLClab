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
    }
}