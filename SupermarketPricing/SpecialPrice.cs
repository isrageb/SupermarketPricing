namespace SupermarketPrice
{
    public class SpecialPrice
    {
        public int Quantity { get; }
        public int Price { get; }

        public SpecialPrice(int quantity, int price)
        {
            Quantity = quantity;
            Price = price;
        }
    }
}
