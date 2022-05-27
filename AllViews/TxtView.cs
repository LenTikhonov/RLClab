using System;
using RLClab.BillUpdate;
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

        public string GetBody(ItemSummary item)
        {
            return $"\t{item.Name}\t\t{item.Price}\t{item.Quantity}\t{item.Sum.ToString()}" +
            $"\t{item.Discount.ToString()}\t{item.ThisAmount.ToString()}\t{item.Bonus.ToString()}\n";
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
