
using System.Collections.Generic;
using AmazonShop.Domain.Common;

namespace AmazonShop.Domain.Models
{
    public class Order : ModelBase
    {
        public Order(){}

        public Order(string buyerName, string buyerEmail, OrderAddress address, decimal subtotal, decimal total, decimal tax, decimal shippingCost)
        {
            BuyerName = buyerName;
            BuyerUsername = buyerEmail;
            Address = address;
            SubTotal = subtotal;
            Total = total;
            Tax = tax;
            ShippingCost = shippingCost;
        }

        public string BuyerName { get; set; }
        public string BuyerUsername { get; set; }
        public OrderAddress Address { get; set; }
        public IReadOnlyList<OrderItem> Items { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal Total { get; set; }

        public decimal Tax { get; set; }
        public decimal ShippingCost { get; set; }

        //Stripe
        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public string StripeApiKey { get; set; }
    }
}