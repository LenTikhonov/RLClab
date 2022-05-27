using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLClab.Views
{
    public class HtmlView : IView
    {
        public string GetBody(double thisAmount, double discount, int bonus, Item item)
        {
            throw new NotImplementedException();
        }

        public string GetFooter(double totalAmount, int totalBonus)
        {
            throw new NotImplementedException();
        }

        public string GetHeader(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
