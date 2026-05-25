namespace IMS.WEB.ViewModels
{
    public class StockHistoryViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new();

        public List<StockTransactionViewModel> Transactions { get; set; } = new();

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public string Search { get; set; } = string.Empty;
    }
}