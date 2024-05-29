
using System.Collections.Generic;
using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string Vendor { get; set; }
        public int Stock { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Available;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}