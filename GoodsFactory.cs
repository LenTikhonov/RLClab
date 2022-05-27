namespace RLClab
{
    public class GoodsFactory
{
    public Goods Create(string type, string title)
    {
        switch (type)
        {
            case "REG":
                return new RegularGoods(title);
            case "SAL":
                return new SaleGoods(title);
            case "SPO":
                return new SpecialGoods(title);
        }
        return null;
    }
}
}
