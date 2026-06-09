using IMS.BLL.DTOs;

namespace IMS.BLL.Interfaces
{
    public interface IDashboardService
    {
        Task<int> GetTotalProductsAsync();

        Task<int> GetTotalCategoriesAsync();

        Task<int> GetTotalSuppliersAsync();

        Task<int> GetTotalUsersAsync();

        Task<int> GetLowStockCountAsync();

        Task<decimal> GetTotalInventoryValueAsync();

        Task<List<StockTransactionDto>> GetRecentTransactionsAsync(int count = 10);
    }
}
