using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.DAL.Interfaces;
using IMS.Models;

namespace IMS.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<PagedResult<ProductDto>> GetPagedAsync(int page, int pageSize, string search)
        {
            var (items, totalCount) = await _repo.GetPagedAsync(page, pageSize, search);

            return new PagedResult<ProductDto>
            {
                Items = items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId,
                    SupplierId = p.SupplierId,
                    CategoryName = p.Category?.Name,
                    SupplierName = p.Supplier?.Name,
                    ImagePath = p.ImagePath,
                    CreatedAt = p.CreatedAt,
                    CreatedBy = p.CreatedBy,
                    LastModifiedAt = p.LastModifiedAt,
                    LastModifiedBy = p.LastModifiedBy
                }).ToList(),

                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();

            return data.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId,
                CategoryName = p.Category?.Name,
                SupplierName = p.Supplier?.Name
            }).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);

            if (p == null)
                return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId,
                CategoryName = p.Category?.Name,
                SupplierName = p.Supplier?.Name,
                ImagePath = p.ImagePath,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy,
                LastModifiedAt = p.LastModifiedAt,
                LastModifiedBy = p.LastModifiedBy
            };
        }

        public async Task CreateAsync(ProductDto dto, string user)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = Math.Round(dto.Price, 2),
                Quantity = 0, 
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId,
                ImagePath = dto.ImagePath,
                CreatedAt = DateTime.Now,
                CreatedBy = user
            };

            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(ProductDto dto, string user)
        {
            var product = await _repo.GetByIdAsync(dto.Id);

            product.Name = dto.Name;
            product.Price = Math.Round(dto.Price, 2);
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;
            product.ImagePath = dto.ImagePath;

            product.LastModifiedAt = DateTime.Now;
            product.LastModifiedBy = user;

            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id, string user)
        {
            await _repo.DeleteAsync(id, user);
        }
    }
}