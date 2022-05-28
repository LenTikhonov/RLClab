using Newtonsoft.Json;
using NUnit.Framework;
using RLClab;
using RLClab.Views;
using System;
using System.Collections.Generic;
using System.IO;

namespace RLCTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void With_SpecialOffer_No_Discount()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food = goodFactory.Create("SPO", "Lays");
            Item i3 = new Item(food, 5, 130);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i3);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для Len\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tLays\t\t130\t5\t650\t0\t650\t0\nСумма счета составляет 650\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Regular_No_Discount()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food1 = goodFactory.Create("REG", "potato");
            Item i1 = new Item(food1, 2, 22);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i1);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для Len\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tpotato\t\t22\t2\t44\t0\t44\t2,2\nСумма счета составляет 44\nВы заработали 2,2 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Sales_No_Discount()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food2 = goodFactory.Create("SAL", "Orange");
            Item i2 = new Item(food2, 3, 15);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i2);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для Len\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tOrange\t\t15\t3\t45\t0\t45\t0,45\nСумма счета составляет 45\nВы заработали 0,45 бонусных балов";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void With_SpecialOffer_with_Discount()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food3 = goodFactory.Create("SPO", "Crab");
            Item i3 = new Item(food3, 11, 55);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i3);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для Len\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCrab\t\t55\t11\t605\t3,025\t601,975\t0\nСумма счета составляет 601,975\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Regular_with_Discount()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food4 = goodFactory.Create("REG", "Aloe");
            Item i1 = new Item(food4, 4, 23);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i1);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t40\t4\t160\t0,8\t159,2\t0\nСумма счета составляет 159,2\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Sales_with_Discount()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food5 = goodFactory.Create("SAL", "Milk");
            Item i2 = new Item(food5, 5, 85);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i2);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для Len\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tMilk\t\t85\t5\t425\t4,25\t420,75\t4,2075\nСумма счета составляет 420,75\nВы заработали 4,2075 бонусных балов";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void With_SpecialOffer_with_FullBonus()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food6 = goodFactory.Create("SPO", "Bread");
            Item i3 = new Item(food6, 3, 42);
            Customer x = new Customer("Len", 500);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i3);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для Len\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tBread\t\t42\t3\t126\t126\t0\t0\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Regular_with_FullBonus()
        {
            StreamReader json = new StreamReader("Settings.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodFactory = new GoodsFactory(config);
            var food7 = goodFactory.Create("REG", "Fish");
            Item i1 = new Item(food7, 7, 12);
            Customer x = new Customer("Len", 500);
            IView view = new TxtView();
            Bill bill = new Bill(x);
            bill.AddGoods(i1);
            BillGenerator generator = new BillGenerator(bill, view);
            string actual = generator.Generate();
            string expected = "Счет для Len\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFish\t\t12\t7\t84\t84\t0\t0\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

    }
}
