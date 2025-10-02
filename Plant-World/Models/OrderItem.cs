using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plant_World.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        //public decimal TotalPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

    }
}
