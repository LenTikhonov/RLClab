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

        public Bill(Customer customer)
        {
            _customer = customer;
            _items = new List<Item>();
        }

        public void AddGoods(Item item)
        {
            _items.Add(item);
        }

        public BillSummary Process()
        {
            BillSummary bill = new BillSummary();
            bill.CustomerName = _customer.GetName();
            List<Item> items = _items;
            foreach (var item in items)
            {
                ItemSummary itemSummary = item.GetItemSummary();

                bill.Items.Add(itemSummary);

                double usedBonus = item.GetUsedBonus(_customer);
                itemSummary.ThisAmount = itemSummary.Sum - itemSummary.Discount - usedBonus;
                bill.TotalAmount += itemSummary.ThisAmount;
                bill.TotalBonus += itemSummary.Bonus;
            }
            _customer.ReceiveBonus(bill.TotalBonus);
            return bill;
        }

    }
}