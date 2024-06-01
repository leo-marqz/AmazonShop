

using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class Image : ModelBase
    {
        public string Url { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string PublicId { get; set; }
    }
}