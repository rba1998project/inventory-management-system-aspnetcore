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

        public async Task<PagedResult<ProductDto>> GetPagedAsync(int page, int pageSize, string search, int? categoryId = null, int? supplierId = null)
        {
            var (items, totalCount) = await _repo.GetPagedAsync(page, pageSize, search, categoryId, supplierId);

            return new PagedResult<ProductDto>
            {
                Items = items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    LowStockThreshold = p.LowStockThreshold,
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
                LowStockThreshold = p.LowStockThreshold,
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
                LowStockThreshold = p.LowStockThreshold,
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

        public async Task<PagedResult<ProductDto>> GetLowStockProductsAsync(int page, int pageSize)
        {
            var (items, totalCount) = await _repo.GetLowStockProductsAsync(page, pageSize);

            return new PagedResult<ProductDto>
            {
                Items = items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    LowStockThreshold = p.LowStockThreshold,
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

        public async Task<int> GetLowStockCountAsync()
        {
            return await _repo.GetLowStockCountAsync();
        }

        public async Task<decimal> GetTotalInventoryValueAsync()
        {
            return await _repo.GetTotalInventoryValueAsync();
        }

        public async Task CreateAsync(ProductDto dto, string user)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = Math.Round(dto.Price, 2),
                Quantity = 0,
                LowStockThreshold = dto.LowStockThreshold,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId,
                ImagePath = dto.ImagePath,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = user
            };

            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(ProductDto dto, string user)
        {
            var product = await _repo.GetByIdAsync(dto.Id);

            product.Name = dto.Name;
            product.Price = Math.Round(dto.Price, 2);
            product.LowStockThreshold = dto.LowStockThreshold;
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;
            product.ImagePath = dto.ImagePath;

            product.LastModifiedAt = DateTime.UtcNow;
            product.LastModifiedBy = user;

            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id, string user)
        {
            await _repo.DeleteAsync(id, user);
        }
    }
}