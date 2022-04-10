namespace RLClab
{
    public class SaleGoods : Goods
    {
        public SaleGoods(string title)
            : base(title)
        {
        }

        public override int GetBonus(Item item)
        {
            return (int)(GetSumm(item) * 0.01);
        }

        public override double GetDiscount(Item item)
        {

            if (item.GetQuantity() > 3)
                return GetSumm(item) * 0.01; // 0.1%
            else
                return 0;

        }

        private static double GetSumm(Item item)
        {
            return item.GetQuantity() * item.GetPrice();
        }
    }
}
