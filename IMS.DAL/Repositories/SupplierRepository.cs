using IMS.DAL.Context;
using IMS.DAL.Interfaces;
using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<Supplier> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, string search)
        {
            var query = _context.Suppliers
                .Where(s => !s.IsDeleted);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(s => s.Name.Contains(search));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Include(s => s.Products.Where(p => !p.IsDeleted))
                .OrderBy(s => s.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers
                .Where(s => !s.IsDeleted)
                .Include(s => s.Products)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Suppliers
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string user)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            supplier.IsDeleted = true;
            supplier.LastModifiedAt = DateTime.UtcNow;
            supplier.LastModifiedBy = user;

            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> GetProductNamesBySupplierIdAsync(int supplierId)
        {
            return await _context.Products
                .Where(p => p.SupplierId == supplierId && !p.IsDeleted)
                .Select(p => p.Name)
                .ToListAsync();
        }
    }
}