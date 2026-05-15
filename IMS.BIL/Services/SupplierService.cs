using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.DAL.Interfaces;
using IMS.Models;

namespace IMS.BLL.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;

        public SupplierService(ISupplierRepository repo)
        {
            _repo = repo;
        }
        public async Task<PagedResult<SupplierDto>> GetPagedAsync(int page, int pageSize, string search)
        {
            var (items, totalCount) = await _repo.GetPagedAsync(page, pageSize, search);

            return new PagedResult<SupplierDto>
            {
                Items = items.Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContactPerson = s.ContactPerson,
                    Email = s.Email,
                    Phone = s.Phone,
                    Address = s.Address,
                    ProductCount = s.Products?.Count ?? 0,
                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy,
                    LastModifiedAt = s.LastModifiedAt,
                    LastModifiedBy = s.LastModifiedBy
                }).ToList(),

                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();

            return data.Select(s => new SupplierDto
            {
                Id = s.Id,
                Name = s.Name,
                ContactPerson = s.ContactPerson,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                ProductCount = s.Products?.Count ?? 0,
                CreatedAt = s.CreatedAt,
                CreatedBy = s.CreatedBy,
                LastModifiedAt = s.LastModifiedAt,
                LastModifiedBy = s.LastModifiedBy
            }).ToList();
        }

        public async Task<SupplierDto> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);

            return new SupplierDto
            {
                Id = s.Id,
                Name = s.Name,
                ContactPerson = s.ContactPerson,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address
            };
        }

        public async Task CreateAsync(SupplierDto dto, string user)
        {
            var supplier = new Supplier
            {
                Name = dto.Name,
                ContactPerson = dto.ContactPerson,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                CreatedAt = DateTime.Now,
                CreatedBy = user
            };

            await _repo.AddAsync(supplier);
        }

        public async Task UpdateAsync(SupplierDto dto, string user)
        {
            var supplier = await _repo.GetByIdAsync(dto.Id);

            supplier.Name = dto.Name;
            supplier.ContactPerson = dto.ContactPerson;
            supplier.Email = dto.Email;
            supplier.Phone = dto.Phone;
            supplier.Address = dto.Address;
            supplier.LastModifiedAt = DateTime.Now;
            supplier.LastModifiedBy = user;

            await _repo.UpdateAsync(supplier);
        }

        public async Task DeleteAsync(int id, string user)
        {
            await _repo.DeleteAsync(id, user);
        }

        public async Task<List<string>> GetProductNamesBySupplierIdAsync(int supplierId)
        {
            return await _repo.GetProductNamesBySupplierIdAsync(supplierId);
        }
    }
}