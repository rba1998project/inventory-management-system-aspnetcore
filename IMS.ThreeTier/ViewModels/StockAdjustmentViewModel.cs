using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class StockAdjustmentViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "New quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "New quantity must be a non-negative number.")]
        public int NewQuantity { get; set; }

        [Required(ErrorMessage = "Adjustment reason is required.")]
        [StringLength(500)]
        public string? Remarks { get; set; }
    }
}
