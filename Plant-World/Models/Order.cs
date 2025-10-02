using System.ComponentModel.DataAnnotations.Schema;

namespace Plant_World.Models
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

    }
}
