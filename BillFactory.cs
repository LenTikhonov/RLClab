using RLClab.Views;
using System;
using System.IO;

namespace RLClab
{
    public class BillFactory
    {
        IFileSource _file;

        public BillFactory(IFileSource file)
        {
            _file = file;
        }

        public BillGenerator CreateBill()
        {
            IView view = new TxtView();

            Customer customer = _file.GetCustomer();
            Bill resultBill = new Bill(customer);

            int goodsQty = _file.GetGoodsCount();
            Goods[] goodsInBill = new Goods[goodsQty];

            for (int i = 0; i < goodsInBill.Length; i++)
            {
                goodsInBill[i] = _file.GetNextGood();
            }

            int itemsQty = _file.GetItemsCount();
            for (int i = 0; i < itemsQty; i++)
            {
                Item item = _file.GetNextItem(goodsInBill);
                resultBill.AddGoods(item);
            }
            _file.CloseFile();
            return new BillGenerator(resultBill, view);
        }
    }
}
