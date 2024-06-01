

using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class Review : ModelBase
    {
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}