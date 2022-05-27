using RLClab.Views;
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

        public String Statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String resultBill = _view.GetHeader(_customer.GetName());
            while (items.MoveNext())
            {
                //определить сумму для каждой строки
                Item item = items.Current;
                double discount = item.GetDiscount();
                int bonus = item.GetBonus();
                double usedBonus = GetUsedBonus(item, _customer);
                // учитываем скидку и бонусы
                double thisAmount = GetSumm(item) - discount - usedBonus;
                resultBill += _view.GetBody(thisAmount, discount, bonus, item);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            resultBill += _view.GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.ReceiveBonus(totalBonus);
            return resultBill;
        }

        private static double GetUsedBonus(Item item, Customer customer)
        {
            if (item.GetGoods().GetType() == typeof(RegularGoods))
                // используем бонусы
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