namespace RLClab.Views
{
    public interface IView
    {
        string GetHeader(string customerName);
        string GetBody(double thisAmount, double discount, int bonus, Item item);
        string GetFooter(double totalAmount, int totalBonus);
    }
}
