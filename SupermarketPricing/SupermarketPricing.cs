namespace SupermarketPrice
{
    public class SupermarketPricing : ICheckout
    {
        private Dictionary<char, int> unitPrices = new Dictionary<char, int>();
        private List<char> scannedItems = new List<char>();
        private Dictionary<char, SpecialPrice> specialPrices = new Dictionary<char, SpecialPrice>();


        public void SetUnitPrice(char sku, int price)
        {
            unitPrices[sku] = price;
        }

        public void SetSpecialPrice(char sku, int quantity, int price)
        {
            specialPrices[sku] = new SpecialPrice(quantity, price);
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

            Dictionary<char, int> itemCounts = new Dictionary<char, int>();

            // Count the quantity of each scanned item
            foreach (var sku in scannedItems)
            {
                if (!itemCounts.ContainsKey(sku))
                {
                    itemCounts[sku] = 0;
                }

                itemCounts[sku]++;
            }



            foreach (var entry in itemCounts)
            {
                char sku = entry.Key;
                int quantity = entry.Value;

                if (specialPrices.ContainsKey(sku))
                {
                    var specialPrice = specialPrices[sku];
                    int specialQuantity = specialPrice.Quantity;
                    int specialPriceAmount = specialPrice.Price;

                    int specialPriceApplications = quantity / specialQuantity;

                    total += specialPriceApplications * specialPriceAmount;

                    int remainingQuantity = quantity % specialQuantity;

                    total += remainingQuantity * unitPrices[sku];

                }
                else
                {
                    total += quantity * unitPrices[sku];
                }
            }

            return total;
        }
       
    }
}