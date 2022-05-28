using System;
using System.IO;

namespace RLClab
{
    public class YamlFileSource : IFileSource
    {
        TextReader _source;
        GoodsFactory _goodsFactory;

        public YamlFileSource(GoodsFactory goodsFactory)
        {
            _goodsFactory = goodsFactory;
        }

        public YamlFileSource(TextReader source, GoodsFactory goodsFactory)
        {
            _source = source;
            _goodsFactory = goodsFactory;
        }

        public void SetSource(TextReader source)
        {
            _source = source;
        }

        public Customer GetCustomer()
        {
            string line = _source.ReadLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();

            line = _source.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());

            return new Customer(name, bonus);
        }

        public int GetGoodsCount()
        {
            string line = _source.ReadLine();
            string[] result = line.Split(':');

            return Convert.ToInt32(result[1].Trim());
        }

        public Goods GetNextGood()
        {
            string[] result = GetNextLine().Split(':');
            result = result[1].Trim().Split();
            string type = result[1].Trim();

            return _goodsFactory.Create(type, result[0]);
        }

        public int GetItemsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }

        public Item GetNextItem(Goods[] goodsInBill)
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            result = result[1].Trim().Split();
            int gid = Convert.ToInt32(result[0].Trim());
            double price = Convert.ToDouble(result[1].Trim());
            int qty = Convert.ToInt32(result[2].Trim());

            return new Item(goodsInBill[gid - 1], qty, price);
        }

        public string GetNextLine()
        {
            string line;
            do
            {
                line = _source.ReadLine();
            }
            while (line.StartsWith("#"));

            return line;
        }

        public void CloseFile()
        {
            _source.Close();
        }
    }
}
