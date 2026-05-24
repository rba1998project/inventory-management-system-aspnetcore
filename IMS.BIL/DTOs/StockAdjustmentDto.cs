namespace IMS.BLL.DTOs
{
    public class StockAdjustmentDto
    {
        public int ProductId { get; set; }

        public int NewQuantity { get; set; }

        public string? Remarks { get; set; }
    }
}