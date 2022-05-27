using System;
using RLClab.BillUpdate;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLClab
{
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private double _price;
        public Item(Goods Goods, int quantity, double price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }

        public String GetTitle()
        {
            return _Goods.GetTitle();
        }

        public int GetQuantity()
        {
            return _quantity;
        }
        public double GetPrice()
        {
            return _price;
        }
        public int GetBonus()
        {
            return _Goods.GetBonus(this);
        }

        public virtual double GetUsedBonus(Customer customer)
        {
            return _Goods.GetUsedBonus(this, customer);
        }

        public double GetDiscount()
        {
            return _Goods.GetDiscount(this);
        }

        public double GetSumm()
        {
            return GetQuantity() * GetPrice();
        }

        public ItemSummary GetItemSummary()
        {
            return new ItemSummary
            {
                Name = GetTitle(),
                Price = GetPrice(),
                Quantity = GetQuantity(),
                Sum = GetSumm(),
                Discount = GetDiscount(),
                Bonus = GetBonus()
            };

        }
    }
}