using Plant_World.Models;
using System.ComponentModel.DataAnnotations;

namespace Plant_World.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; }
    }
}
