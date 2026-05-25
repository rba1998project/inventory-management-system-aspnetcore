using IMS.DAL.Context;
using IMS.DAL.Interfaces;
using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, string search, int? categoryId = null, int? supplierId = null)
        {
            var query = _context.Products
                .Where(p => !p.IsDeleted);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p => p.Name.Contains(search));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            if (supplierId.HasValue)
            {
                query = query.Where(p => p.SupplierId == supplierId.Value);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderBy(p => p.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string user)
        {
            var product = await _context.Products.FindAsync(id);

            product.IsDeleted = true;
            product.LastModifiedAt = DateTime.UtcNow;
            product.LastModifiedBy = user;

            await _context.SaveChangesAsync();
        }
    }
}