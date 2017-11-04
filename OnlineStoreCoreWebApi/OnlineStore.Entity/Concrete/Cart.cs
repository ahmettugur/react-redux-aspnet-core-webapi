using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Entity.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }
        public string Message { get; set; }
        public decimal Total
        {
            get { return CartLines.Sum(_ => _.Product.Price * _.Quantity); }
        }
    }
}
