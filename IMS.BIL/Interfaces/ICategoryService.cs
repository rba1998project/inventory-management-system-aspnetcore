using IMS.BLL.DTOs;

namespace IMS.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryDto dto, string user);
        Task UpdateAsync(CategoryDto dto, string user);
        Task DeleteAsync(int id, string user);
        Task<List<string>> GetProductNamesByCategoryIdAsync(int categoryId);
    }
}
