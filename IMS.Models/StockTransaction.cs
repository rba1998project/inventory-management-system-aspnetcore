using IMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }

        // FK → Product
        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int PreviousQuantity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int NewQuantity { get; set; }

        [MaxLength(500)]
        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }
    }
}