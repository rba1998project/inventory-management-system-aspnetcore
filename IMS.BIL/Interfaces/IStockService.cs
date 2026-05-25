using IMS.BLL.DTOs;
using IMS.Models;

namespace IMS.BLL.Interfaces
{
    public interface IStockService
    {
        Task StockInAsync(StockInDto dto, string username);

        Task<bool> StockOutAsync(StockOutDto dto, string username);

        Task AdjustStockAsync(StockAdjustmentDto dto, string username);

        Task<(List<StockTransaction> Items, int TotalCount)> GetPagedTransactionsAsync(int page, int pageSize, string search = "", string transactionType = "", string createdBy = "");

        Task<List<string>> GetDistinctCreatedByAsync();
    }
}