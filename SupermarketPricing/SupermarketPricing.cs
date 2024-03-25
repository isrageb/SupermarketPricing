namespace SupermarketPrice
{
    public class SupermarketPricing : ICheckout
    {
        private Dictionary<char, int> unitPrices = new Dictionary<char, int>();
        private Dictionary<char, int> scannedItems = new Dictionary<char, int>();
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

            if (!scannedItems.ContainsKey(sku))
            {
                scannedItems[sku] = 0;
            }
            scannedItems[sku]++;

        }


        public int GetTotalPrice()
        {
            int total = 0;

            foreach (var item in scannedItems)
            {
                char sku = item.Key;
                int quantity = item.Value;
                
                if(unitPrices.ContainsKey(sku))
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