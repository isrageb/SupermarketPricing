namespace SupermarketPrice
{
    public class SupermarketPricing : ICheckout
    {
        private Dictionary<char, int> unitPrices = new Dictionary<char, int>();
        private List<char> scannedItems = new List<char>();
        private Dictionary<char, Tuple<int, int>> specialPrices = new Dictionary<char, Tuple<int, int>>();


        public void SetUnitPrice(char sku, int price)
        {
            unitPrices[sku] = price;
        }

        public void SetSpecialPrice(char sku, int quantity, int price)
        {
            specialPrices[sku] = Tuple.Create(quantity, price);
        }

        public void Scan(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Length > 1)
            {
                throw new ArgumentException("Invalid item");
            }

            char sku = item[0];

            scannedItems.Add(sku);           

        }


        public int GetTotalPrice()
        {
            int total = 0;

            foreach (var item in scannedItems)
            {
                char sku = item.Key;
                int quantity = item.Value;

                if (specialPrices.ContainsKey(sku))
                {
                    var specialPrice = specialPrices[sku];
                    int specialQuantity = specialPrice.Item1;
                    int specialPriceAmount = specialPrice.Item2;

                    while (quantity >= specialQuantity)
                    {
                        total += specialPriceAmount;
                        quantity -= specialQuantity;
                    }
                }




                if (unitPrices.ContainsKey(sku))
                {
                    total += quantity * unitPrices[sku];
                }
                else
                {
                    throw new ArgumentException($"Unknown SKU: {sku}");
                }

            }
            return total;
        }

       
    }
}