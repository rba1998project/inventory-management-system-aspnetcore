using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class SupplierCreateViewModel
    {
        [Required(ErrorMessage = "Supplier name is required.")]
        public string Name { get; set; }

        public string? ContactPerson { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        //using a regex to validate phone numbers instead of the built-in Phone attribute, which is too permissive and doesn't show error messages in the view.
        //[Phone(ErrorMessage = "Invalid phone number.")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}