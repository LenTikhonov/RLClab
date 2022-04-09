﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLClab
{
    class UsageExample
    {
        static void Example(string[] args)
        {
            Goods cola = new Goods("Cola", Goods.REGULAR);
            Goods pepsi = new Goods("Pepsi", Goods.SALE);
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.AddGoods(i1);
            b1.AddGoods(i2);
            string bill = b1.Statement();
            Console.WriteLine(bill);
        }
    }
}