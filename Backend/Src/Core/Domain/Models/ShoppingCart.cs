
using System;
using System.Collections.Generic;
using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class ShoppingCart : ModelBase
    {
        public Guid ShoppingCartMasterId { get; set; }
        public virtual ICollection<ShoppingCartItem> Items { get; set; }
    }
}