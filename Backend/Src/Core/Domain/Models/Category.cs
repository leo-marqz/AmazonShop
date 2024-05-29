
using System.Collections.Generic;
using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}