using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class StockInViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [MaxLength(500)]
        public string? Remarks { get; set; }
    }
}