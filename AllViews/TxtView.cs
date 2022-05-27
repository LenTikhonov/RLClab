using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLClab.Views
{
    public class TxtView : IView
    {
        public string GetHeader(string customerName)
        {
            return $"Счет для {customerName}\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n";
        }

        public string GetBody(double thisAmount, double discount, int bonus, Item item)
        {
            //показать результаты
            return $"\t{item.GetGoods().GetTitle()}\t\t{item.GetPrice()}\t{item.GetQuantity()}\t{(GetSumm(item)).ToString()}" +
            $"\t{discount.ToString()}\t{thisAmount.ToString()}\t{bonus.ToString()}\n";
        }

        public string GetFooter(double totalAmount, int totalBonus)
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
