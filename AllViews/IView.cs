using RLClab.BillUpdate;

namespace RLClab.Views
{
    public interface IView
    {
        string GetHeader(string customerName);
        string GetBody(ItemSummary item);
        string GetFooter(double totalAmount, int totalBonus);
    }
}

