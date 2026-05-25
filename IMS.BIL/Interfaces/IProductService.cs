using IMS.BLL.DTOs;

namespace IMS.BLL.Interfaces
{
    public interface IProductService
    {
        Task<PagedResult<ProductDto>> GetPagedAsync(int page, int pageSize, string search, int? categoryId = null, int? supplierId = null);

        Task<List<ProductDto>> GetAllAsync();

        Task<ProductDto> GetByIdAsync(int id);

        Task CreateAsync(ProductDto dto, string user);

        Task UpdateAsync(ProductDto dto, string user);

        Task DeleteAsync(int id, string user);
    }
}