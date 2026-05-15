using IMS.BLL.DTOs;

namespace IMS.BLL.Interfaces
{
    public interface ISupplierService
    {
        Task<PagedResult<SupplierDto>> GetPagedAsync(int page, int pageSize, string search);
        Task<List<SupplierDto>> GetAllAsync();

        Task<SupplierDto> GetByIdAsync(int id);

        Task CreateAsync(SupplierDto dto, string user);

        Task UpdateAsync(SupplierDto dto, string user);

        Task DeleteAsync(int id, string user);

        Task<List<string>> GetProductNamesBySupplierIdAsync(int supplierId);
    }
}