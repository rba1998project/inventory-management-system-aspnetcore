using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.DAL.Interfaces;
using IMS.Models;
using Microsoft.Extensions.Logging;

namespace IMS.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository repo, ILogger<CategoryService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<PagedResult<CategoryDto>> GetPagedAsync(int page, int pageSize, string search)
        {
            var (items, totalCount) = await _repo.GetPagedAsync(page, pageSize, search);

            return new PagedResult<CategoryDto>
            {
                Items = items.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ProductCount = c.Products?.Count ?? 0,
                    CreatedAt = c.CreatedAt,
                    CreatedBy = c.CreatedBy,
                    LastModifiedAt = c.LastModifiedAt,
                    LastModifiedBy = c.LastModifiedBy
                }).ToList(),

                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();

            return data.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ProductCount = c.Products?.Count ?? 0,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                LastModifiedAt = c.LastModifiedAt,
                LastModifiedBy = c.LastModifiedBy
            }).ToList();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);

            return new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            };
        }



        public async Task CreateAsync(CategoryDto dto, string user)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = user
            };

            await _repo.AddAsync(category);

            _logger.LogInformation(
                "Category {CategoryName} created by {User}",
                category.Name,
                user);
        }

        //TODO: Implement optimistic concurrency control using RowVersion
        public async Task UpdateAsync(CategoryDto dto, string user)
        {
            var category = await _repo.GetByIdAsync(dto.Id);

            category.Name = dto.Name;
            category.Description = dto.Description;
            category.LastModifiedAt = DateTime.UtcNow;
            category.LastModifiedBy = user;

            await _repo.UpdateAsync(category);

            _logger.LogInformation(
                "Category {CategoryName} updated by {User}",
                category.Name,
                user);
        }


        public async Task DeleteAsync(int id, string user)
        {
            await _repo.DeleteAsync(id, user);

            _logger.LogInformation(
                "Category(id) {CategoryId} deleted by {User}",
                id,
                user);
        }

        public async Task<List<string>> GetProductNamesByCategoryIdAsync(int categoryId)
        {
            return await _repo.GetProductNamesByCategoryIdAsync(categoryId);
        }
    }
}
