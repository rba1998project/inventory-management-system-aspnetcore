using IMS.Models;

namespace IMS.DAL.Interfaces
{
    public interface IStockRepository
    {
        Task AddTransactionAsync(StockTransaction transaction);

        Task SaveChangesAsync();

        Task<(List<StockTransaction> Items, int TotalCount)> GetPagedTransactionsAsync(int page, int pageSize, string search = "", string transactionType = "", string createdBy = "");

        Task<List<string>> GetDistinctCreatedByAsync();
    }
}