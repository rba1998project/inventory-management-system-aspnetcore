using System.ComponentModel.DataAnnotations;

namespace IMS.BLL.DTOs
{
    public class StockAdjustmentDto
    {
        public int ProductId { get; set; }

        public int NewQuantity { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(500)]
        public string? Remarks { get; set; }
    }
}