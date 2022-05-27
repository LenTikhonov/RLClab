using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using RLClab.Views;

namespace RLClab
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.ymal";

            if (args.Length == 1)
                filename = args[0];

            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            FileSourceFactory sourceFactory = new FileSourceFactory();
            IFileSource file = sourceFactory.Create(filename);
            file.SetSource(sr);
            BillFactory billFactory = new BillFactory(file);
            string bill = billFactory.CreateBill();

            Console.WriteLine(bill);
        }
    }
}