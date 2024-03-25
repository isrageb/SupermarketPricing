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
           
            Assert.Pass();
        }
    }
}