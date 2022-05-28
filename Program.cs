using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using RLClab.Views;
using Newtonsoft.Json;

namespace RLClab
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.yaml";

            if (args.Length == 1)
                filename = args[0];

            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            FileSourceFactory sourceFactory = new FileSourceFactory();
            StreamReader json = new StreamReader("config.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Settings>>>(json.ReadToEnd());
            GoodsFactory goodsFactory = new GoodsFactory(config);
            IFileSource file = sourceFactory.Create(filename, goodsFactory);
            file.SetSource(sr);
            BillFactory billFactory = new BillFactory(file);
            var billGenerator = billFactory.CreateBill();
            var bill = billGenerator.Generate();

            Console.WriteLine(bill);
        }
    }
}