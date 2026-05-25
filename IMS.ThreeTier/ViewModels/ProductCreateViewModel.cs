using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
    }
}