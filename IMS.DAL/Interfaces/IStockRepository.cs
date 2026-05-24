using IMS.Models;

namespace IMS.DAL.Interfaces
{
    public interface IStockRepository
    {
        Task AddTransactionAsync(StockTransaction transaction);

        Task<List<StockTransaction>> GetTransactionsByProductIdAsync(int productId);

        Task SaveChangesAsync();
    }
}