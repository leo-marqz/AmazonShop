
using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class OrderItem : ModelBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public int ProductItemId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}