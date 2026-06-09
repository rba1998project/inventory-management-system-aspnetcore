using IMS.Models;

namespace IMS.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, string search, int? categoryId = null, int? supplierId = null);

        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<(List<Product> Items, int TotalCount)> GetLowStockProductsAsync(int page, int pageSize);

        Task<int> GetLowStockCountAsync();

        Task<decimal> GetTotalInventoryValueAsync();

        Task AddAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(int id, string user);
    }
}