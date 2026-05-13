using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999999999999999.99")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }= 0;

        // FK → Category
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        // FK → Supplier
        [Required]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        [MaxLength(300)]
        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public string? LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
