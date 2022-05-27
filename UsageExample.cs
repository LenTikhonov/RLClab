using RLClab.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLClab
{
    class UsageExample
    {
        static void Example(string[] args)
        {
            Goods cola = new Goods("Cola");
            Goods pepsi = new Goods("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            IView view = new TxtView();
            Bill b1 = new Bill(x, view);
            b1.AddGoods(i1);
            b1.AddGoods(i2);
            string bill = b1.Process();
            Console.WriteLine(bill);
        }
    }
}