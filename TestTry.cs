using NUnit.Framework;
using RLClab;
using RLClab.Views;
using System;

namespace RLCTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void With_SpecialOffer_No_Discount()
        {
            Goods food = new SpecialGoods("Lays");
            Item i3 = new Item(food, 5, 130);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i3);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tLays\t\t130\t5\t650\t0\t650\t0\n����� ����� ���������� 650\n�� ���������� 0 �������� �����";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Regular_No_Discount()
        {
            Goods food1 = new RegularGoods("potato");
            Item i1 = new Item(food1, 2, 22);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i1);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tpotato\t\t22\t2\t44\t0\t44\t2,2\n����� ����� ���������� 44\n�� ���������� 2,2 �������� �����";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Sales_No_Discount()
        {
            Goods food2 = new SaleGoods("Orange");
            Item i2 = new Item(food2, 3, 15);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i2);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tOrange\t\t15\t3\t45\t0\t45\t0,45\n����� ����� ���������� 45\n�� ���������� 0,45 �������� �����";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void With_SpecialOffer_with_Discount()
        {
            Goods food3 = new SpecialGoods("Crab");
            Item i3 = new Item(food3, 11, 55);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i3);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCrab\t\t55\t11\t605\t3,025\t601,975\t0\n����� ����� ���������� 601,975\n�� ���������� 0 �������� �����";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Regular_with_Discount()
        {
            Goods food4 = new RegularGoods("Aloe");
            Item i1 = new Item(food4, 4, 24);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i1);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tAloe\t\t24\t4\t96\t2,88\t93,12\t4,656\n����� ����� ���������� 93,12\n�� ���������� 4,656 �������� �����";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Sales_with_Discount()
        {
            Goods food5 = new SaleGoods("Milk");
            Item i2 = new Item(food5, 5, 85);
            Customer x = new Customer("Len", 0);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i2);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tMilk\t\t85\t5\t425\t4,25\t420,75\t4,2075\n����� ����� ���������� 420,75\n�� ���������� 4,2075 �������� �����";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void With_SpecialOffer_with_FullBonus()
        {
            Goods food5 = new SpecialGoods("Bread");
            Item i3 = new Item(food5, 3, 42);
            Customer x = new Customer("Len", 500);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i3);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tBread\t\t42\t3\t126\t126\t0\t0\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void With_Regular_with_FullBonus()
        {
            Goods food6 = new RegularGoods("Fish");
            Item i1 = new Item(food6, 7, 12);
            Customer x = new Customer("Len", 500);
            IView view = new TxtView();
            Bill bill = new Bill(x,view);
            bill.AddGoods(i1);
            string actual = bill.Process();
            string expected = "���� ��� Len\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFish\t\t12\t7\t84\t84\t0\t0\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            Assert.AreEqual(expected, actual);
        }

    }
}
