using System.ComponentModel.DataAnnotations;

namespace crud2.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Product name must be between 5 and 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(20, 3000, ErrorMessage = "Price must be between 20 and 3000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
        public string Description { get; set; }
    }
}
