using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLClab
{
    public class Goods
    {
        protected String _title;
        public Goods(String title)
        {
            _title = title;
        }
        public String GetTitle()
        {
            return _title;
        }

        public virtual int GetBonus(Item item)
        {
            return 0;
        }

        public virtual double GetDiscount(Item item)
        {
            return 0;
        }
    }
}