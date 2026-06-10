using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$",
            ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, and one digit.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
