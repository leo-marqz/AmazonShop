
using System;

namespace AmazonShop.Domain.Common
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}