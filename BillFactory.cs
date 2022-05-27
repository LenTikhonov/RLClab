using RLClab.Views;
using System;
using System.IO;

namespace RLClab
{
    public class BillFactory
    {
        public static string CreateBill(TextReader source)
        {
            IView view = new TxtView();

            ContentFile file = new ContentFile();
            file.SetSource(source);

            Customer customer = file.GetCustomer();
            Bill resultBill = new Bill(customer);

            int goodsQty = file.GetGoodsCount();
            Goods[] goodsInBill = new Goods[goodsQty];

            for (int i = 0; i < goodsInBill.Length; i++)
            {
                goodsInBill[i] = file.GetNextGood();
            }

            int itemsQty = file.GetItemsCount();
            for (int i = 0; i < itemsQty; i++)
            {
                Item item = file.GetNextItem(goodsInBill);
                resultBill.AddGoods(item);
            }

            BillGenerator generator = new BillGenerator(resultBill, view);
            string bill = generator.Generate();
            source.Close();
            return bill;
        }
    }
}
