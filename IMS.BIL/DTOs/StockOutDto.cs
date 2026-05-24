namespace IMS.BLL.DTOs
{
    public class StockOutDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string? Remarks { get; set; }
    }
}