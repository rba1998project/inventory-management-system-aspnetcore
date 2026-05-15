using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
