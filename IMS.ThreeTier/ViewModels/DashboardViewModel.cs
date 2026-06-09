using IMS.BLL.DTOs;

namespace IMS.WEB.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }

        public int TotalCategories { get; set; }

        public int TotalSuppliers { get; set; }

        public int TotalUsers { get; set; }

        public int LowStockProducts { get; set; }

        public decimal TotalInventoryValue { get; set; }

        public List<StockTransactionDto> RecentTransactions { get; set; } = new();
    }
}
