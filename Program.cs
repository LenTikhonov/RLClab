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
            string filename = "BillInfo.yaml";

            if (args.Length == 1)
                filename = args[0];

            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string BillFactor = BillFactory.CreateBill(sr);

            Console.WriteLine(BillFactor);
        }
    }
}