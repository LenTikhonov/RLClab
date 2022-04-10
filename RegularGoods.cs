namespace RLClab
{
    public class RegularGoods : Goods
    {
        public RegularGoods(string title)
            : base(title)
        {
        }

        public override int GetBonus(Item item)
        {
            return (int)(GetSumm(item) * 0.05);
        }

        public override double GetDiscount(Item item)
        {
            if (item.GetQuantity() > 2)
                return GetSumm(item) * 0.03; // 3%
            else
                return 0;
        }

        private static double GetSumm(Item item)
        {
            return item.GetQuantity() * item.GetPrice();
        }
    }
}
