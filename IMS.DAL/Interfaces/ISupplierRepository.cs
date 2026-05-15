using IMS.Models;

namespace IMS.DAL.Interfaces
{
    public interface ISupplierRepository
    {
        Task<(List<Supplier> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, string search);
        Task<List<Supplier>> GetAllAsync();

        Task<Supplier?> GetByIdAsync(int id);

        Task AddAsync(Supplier supplier);

        Task UpdateAsync(Supplier supplier);

        Task DeleteAsync(int id, string user);

        Task<List<string>> GetProductNamesBySupplierIdAsync(int supplierId);
    }
}