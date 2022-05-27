using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLClab.BillUpdate
{
    public class BillSummary
    {
        public double TotalAmount { get; set; }
        public double TotalDiscount { get; set; }
        public string CustomerName { get; set; }
        public int TotalBonus { get; set; }

        public List<ItemSummary> Items = new List<ItemSummary>();
    }
}
