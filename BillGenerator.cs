using RLClab.BillUpdate;
using RLClab.Views;
using System;
using System.Collections.Generic;
namespace RLClab
{
    public class BillGenerator
    {
        private Bill _bill;

        private IView _view;

        public BillGenerator(Bill bill, IView view)
        {
            _bill = bill;
            _view = view;
        }

        public string Generate()
        {
            BillSummary bill = _bill.Process();

            string resultBill = _view.GetHeader(bill.CustomerName);
            List<ItemSummary>.Enumerator enumerator = bill.Items.GetEnumerator();
            while (enumerator.MoveNext())
            {

                ItemSummary item = enumerator.Current;
                resultBill += _view.GetBody(item);
            }
            resultBill += _view.GetFooter(bill.TotalAmount, bill.TotalBonus);
            return resultBill;
        }
    }
}