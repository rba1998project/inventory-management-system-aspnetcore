using IMS.DAL.Context;
using IMS.DAL.Interfaces;
using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddTransactionAsync(StockTransaction transaction)
        {
            await _context.StockTransactions.AddAsync(transaction);
        }

        //public async Task<List<StockTransaction>> GetTransactionsByProductIdAsync(int productId)
        //{
        //    return await _context.StockTransactions
        //        .Include(st => st.Product)
        //        .Where(st => st.ProductId == productId)
        //        .OrderByDescending(st => st.CreatedAt)
        //        .ToListAsync();
        //}

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<StockTransaction>> GetAllTransactionsAsync()
        {
            return await _context.StockTransactions
                .Include(s => s.Product)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }
    }
}