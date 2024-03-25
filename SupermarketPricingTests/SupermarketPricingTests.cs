using SupermarketPrice;

namespace SupermarketPricingTests
{
    public class SupermarketPricingTests
    {
        private SupermarketPricing pricing;

        [SetUp]
        public void Setup()
        {
           pricing = new SupermarketPricing();
        }

        [Test]
        public void Scan_OneItem_NospeicalPrice_mustReturnUnitPrice()
        {
            pricing.SetUnitPrice('A', 50);
            pricing.Scan("A");

            int totalPrice = pricing.GetTotalPrice();

            Assert.AreEqual(50, totalPrice);
        }


    }
}