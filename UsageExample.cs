using Newtonsoft.Json;
using RLClab.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace RLClab
{
    class UsageExample
    {
        static void Example(string[] args)
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food1 = goodFactory.Create("SPO", "Cola");
            var food2 = goodFactory.Create("SPO", "Pepsi");
            Item i1 = new Item(food1, 6, 65);
            Item i2 = new Item(food2, 3, 50);
            Customer x = new Customer("test", 10);
            IView view = new TxtView();
            Bill b1 = new Bill(x);
            b1.AddGoods(i1);
            b1.AddGoods(i2);
            BillGenerator generator = new BillGenerator(b1, view);
            string restulBill = generator.Generate();
            Console.WriteLine(b1);
        }
    }
}