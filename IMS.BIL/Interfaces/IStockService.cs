using IMS.BLL.DTOs;
using IMS.Models;

namespace IMS.BLL.Interfaces
{
    public interface IStockService
    {
        Task StockInAsync(StockInDto dto, string username);

        Task<bool> StockOutAsync(StockOutDto dto, string username);

        Task AdjustStockAsync(StockAdjustmentDto dto, string username);

        Task<List<StockTransaction>> GetTransactionHistoryAsync(int productId);
    }
}