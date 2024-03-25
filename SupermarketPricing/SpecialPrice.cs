using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
