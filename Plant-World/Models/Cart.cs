using System.ComponentModel.DataAnnotations.Schema;

namespace Plant_World.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public DateTime AddedAt { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
