using IMS.DAL.Context;
using IMS.DAL.Interfaces;
using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalProductsAsync()
        {
            return await _context.Products
                .Where(p => !p.IsDeleted)
                .CountAsync();
        }

        public async Task<int> GetTotalCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => !c.IsDeleted)
                .CountAsync();
        }

        public async Task<int> GetTotalSuppliersAsync()
        {
            return await _context.Suppliers
                .Where(s => !s.IsDeleted)
                .CountAsync();
        }

        public async Task<List<StockTransaction>> GetRecentTransactionsAsync(int count = 10)
        {
            return await _context.StockTransactions
                .Include(st => st.Product)
                .OrderByDescending(st => st.CreatedAt)
                .Take(count)
                .ToListAsync();
        }
    }
}
