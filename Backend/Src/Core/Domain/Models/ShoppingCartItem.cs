
using System;
using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class ShoppingCartItem  : ModelBase
    {
         public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }

        public Guid ShoppingCartMasterId { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}