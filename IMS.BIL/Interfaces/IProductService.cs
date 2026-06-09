using IMS.BLL.DTOs;

namespace IMS.BLL.Interfaces
{
    public interface IProductService
    {
        Task<PagedResult<ProductDto>> GetPagedAsync(int page, int pageSize, string search, int? categoryId = null, int? supplierId = null);

        Task<List<ProductDto>> GetAllAsync();

        Task<ProductDto> GetByIdAsync(int id);

        Task<PagedResult<ProductDto>> GetLowStockProductsAsync(int page, int pageSize);

        Task<int> GetLowStockCountAsync();

        Task<decimal> GetTotalInventoryValueAsync();

        Task CreateAsync(ProductDto dto, string user);

        Task UpdateAsync(ProductDto dto, string user);

        Task DeleteAsync(int id, string user);
    }
}