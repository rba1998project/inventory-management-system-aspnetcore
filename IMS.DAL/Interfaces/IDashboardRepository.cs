using IMS.Models;

namespace IMS.DAL.Interfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalProductsAsync();

        Task<int> GetTotalCategoriesAsync();

        Task<int> GetTotalSuppliersAsync();

        Task<List<StockTransaction>> GetRecentTransactionsAsync(int count = 10);
    }
}
