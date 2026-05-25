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

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<(List<StockTransaction> Items, int TotalCount)> GetPagedTransactionsAsync(int page, int pageSize, string search = "", string transactionType = "", string createdBy = "")
        {
            IQueryable<StockTransaction> query = _context.StockTransactions.Include(s => s.Product);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(t => t.Product.Name.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(transactionType))
            {
                if (Enum.TryParse<Models.Enums.TransactionType>(transactionType, out var enumValue))
                {
                    query = query.Where(t => t.TransactionType == enumValue);
                }
            }

            if (!string.IsNullOrWhiteSpace(createdBy))
            {
                query = query.Where(t => t.CreatedBy == createdBy);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(t => t.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<List<string>> GetDistinctCreatedByAsync()
        {
            return await _context.StockTransactions
                .Select(t => t.CreatedBy)
                .Distinct()
                .OrderBy(cb => cb)
                .ToListAsync();
        }
    }
}