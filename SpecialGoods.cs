namespace RLClab
{
    public class SpecialGoods : Goods
    {
        public SpecialGoods(string title)
            : base(title)
        {
        }

        public override int GetBonus(Item item)
        {
            return 0;
        }

        public double GetDiscount(Item item)
        {
            if (item.GetQuantity() > 10)
                return (GetSumm(item)) * 0.005; // 0.5%
            else
                return 0;
        }

        private static double GetSumm(Item item)
        {
            return item.GetQuantity() * item.GetPrice();
        }
    }
}
