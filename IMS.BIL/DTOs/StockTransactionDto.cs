namespace IMS.BLL.DTOs
{
    public class StockTransactionDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string TransactionType { get; set; }

        public int Quantity { get; set; }

        public int PreviousQuantity { get; set; }

        public int NewQuantity { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
