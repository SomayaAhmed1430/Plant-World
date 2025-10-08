using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plant_World.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string MainImageUrl { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Cart> Carts { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
