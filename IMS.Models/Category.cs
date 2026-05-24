using System.ComponentModel.DataAnnotations;

namespace IMS.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(150)]
        public string CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }
        
        [MaxLength(150)]
        public string? LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Product> Products { get; set; }
    }
}
