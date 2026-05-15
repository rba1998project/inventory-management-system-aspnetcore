using IMS.Models;

namespace IMS.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id, string user);
        Task<List<string>> GetProductNamesByCategoryIdAsync(int categoryId);
    }
}
