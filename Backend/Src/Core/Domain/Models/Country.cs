
using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class Country : ModelBase
    {
        public string Name { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
    }
}