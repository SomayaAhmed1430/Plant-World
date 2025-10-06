using System.ComponentModel.DataAnnotations;

namespace Plant_World.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Description can't be longer than 300 characters")]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public List<Product>? Products { get; set; }
    }
}
