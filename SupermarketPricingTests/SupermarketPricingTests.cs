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
            //arrange

            pricing.SetUnitPrice('A', 50);
            pricing.Scan("A");

            //act
            int totalPrice = pricing.GetTotalPrice();

            //Assert
            Assert.AreEqual(50, totalPrice);
        }

        public void Scan_MultiplItems_NospecialPrice_shouldReturnCorrectTotal()
        {
            //arrange
            pricing.SetUnitPrice('A', 50);
            pricing.SetUnitPrice('B', 30);
            pricing.Scan("A");
            pricing.Scan("B");

            //act
            int totalPrice = pricing.GetTotalPrice();

            //assert

            Assert.AreEqual(70, totalPrice);

        }
    }
}