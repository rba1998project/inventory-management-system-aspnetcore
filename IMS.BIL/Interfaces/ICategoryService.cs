using IMS.BLL.DTOs;

namespace IMS.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedResult<CategoryDto>> GetPagedAsync(int page, int pageSize, string search);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryDto dto, string user);
        Task UpdateAsync(CategoryDto dto, string user);
        Task DeleteAsync(int id, string user);
        Task<List<string>> GetProductNamesByCategoryIdAsync(int categoryId);
    }
}
