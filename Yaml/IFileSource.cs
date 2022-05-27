using System;
using System.Collections.Generic;
using System.IO;

namespace RLClab
{
    public interface IFileSource
    {
        public void SetSource(TextReader source);

        public Customer GetCustomer();

        public int GetGoodsCount();

        public Goods GetNextGood();

        public int GetItemsCount();

        public Item GetNextItem(Goods[] goodsInBill);

        public string GetNextLine();

        public void CloseFile();
    }
}
