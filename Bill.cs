using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLClab
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;

        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
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
            String resultBill = GetHeader(_customer.GetName());
            while (items.MoveNext())
            {
                //определить сумму для каждой строки
                Item item = items.Current;
                double discount = GetDiscount(item);
                int bonus = GetBonus(item);
                double usedBonus = GetUsedBonus(item, _customer);
                // учитываем скидку и бонусы
                double thisAmount = GetSumm(item) - discount - usedBonus;
                resultBill += GetBody(thisAmount, discount, bonus, item);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            resultBill += GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.ReceiveBonus(totalBonus);
            return resultBill;
        }

        private static int GetBonus(Item item)
        {
            switch (item.GetGoods().GetPriceCode())
            {
                case Goods.REGULAR:
                    return (int)(GetSumm(item) * 0.05);
                case Goods.SALE:
                    return (int)(GetSumm(item) * 0.01);
            }
            return 0;
        }

        private static double GetUsedBonus(Item item, Customer customer)
        {
            switch (item.GetGoods().GetPriceCode())
            {
                case Goods.REGULAR:
                    // используем бонусы
                    if (item.GetQuantity() > 5)
                        return customer.UseBonus((int)(GetSumm(item)));
                    break;
                case Goods.SPECIAL_OFFER:
                    if (item.GetQuantity() > 1)
                        return customer.UseBonus((int)(GetSumm(item)));
                    break;
            }
            return 0;
        }

        private static double GetDiscount(Item item)
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

        private static string GetHeader(string customerName)
        {
            return $"Счет для {customerName}\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n";
        }

        private static string GetBody(double thisAmount, double discount, int bonus, Item item)
        {
            //показать результаты
            return $"\t{item.GetGoods().GetTitle()}\t\t{item.GetPrice()}\t{item.GetQuantity()}\t{(GetSumm(item)).ToString()}" +
            $"\t{discount.ToString()}\t{thisAmount.ToString()}\t{bonus.ToString()}\n";
        }

        private static string GetFooter(double totalAmount, int totalBonus)
        {
            //добавить нижний колонтитул
            return $"Сумма счета составляет {totalAmount.ToString()}\nВы заработали {totalBonus.ToString()} бонусных балов";
        }

        private static double GetSumm(Item item)
        {
            return item.GetQuantity() * item.GetPrice();
        }
    }
}
