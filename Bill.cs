using RLClab.Views;
using RLClab.BillUpdate;
using System;
using System.Collections.Generic;
namespace RLClab
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;

        private IView _view;

        public Bill(Customer customer, IView view)
        {
            _customer = customer;
            _items = new List<Item>();
            _view = view;
        }

        public void AddGoods(Item item)
        {
            _items.Add(item);
        }

        public BillSummary Process() //GetBill
        {
            BillSummary bill = new BillSummary();
            bill.CustomerName = _customer.GetName();
            List<Item>.Enumerator items = _items.GetEnumerator();
            while (items.MoveNext())
            {
                Item item = items.Current;
                ItemSummary itemSummary = new ItemSummary
                {
                    Name = item.GetGoods().GetTitle(),
                    Price = item.GetPrice(),
                    Quantity = item.GetQuantity(),
                    Sum = GetSumm(item),
                    Discount = item.GetDiscount(),
                    Bonus = item.GetBonus()
                };

                bill.Items.Add(itemSummary);

                double usedBonus = GetUsedBonus(item, _customer);
                itemSummary.ThisAmount = itemSummary.Sum - itemSummary.Discount - usedBonus;
                bill.TotalAmount += itemSummary.ThisAmount;
                bill.TotalBonus += itemSummary.Bonus;
            }
            _customer.ReceiveBonus(bill.TotalBonus);
            return bill;
        }

        private static double GetUsedBonus(Item item, Customer customer)
        {
            if (item.GetGoods().GetType() == typeof(RegularGoods))
                if (item.GetQuantity() > 5)
                    return customer.UseBonus((int)(GetSumm(item)));

            if (item.GetGoods().GetType() == typeof(SpecialGoods))
                if (item.GetQuantity() > 1)
                    return customer.UseBonus((int)(GetSumm(item)));

            return 0;
        }

        private static double GetSumm(Item item)
        {
            return item.GetQuantity() * item.GetPrice();
        }
    }
}