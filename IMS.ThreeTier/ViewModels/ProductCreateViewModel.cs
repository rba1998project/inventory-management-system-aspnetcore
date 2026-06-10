using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Low Stock Threshold must be a positive number")]
        [Display(Name = "Low Stock Threshold")]
        public int LowStockThreshold { get; set; } = 1;
    }
}