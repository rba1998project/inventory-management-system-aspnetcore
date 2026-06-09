using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.DAL.Interfaces;
using IMS.Models;
using Microsoft.AspNetCore.Identity;

namespace IMS.BLL.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepo;
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardService(
            IDashboardRepository dashboardRepo,
            IProductRepository productRepo,
            UserManager<ApplicationUser> userManager)
        {
            _dashboardRepo = dashboardRepo;
            _productRepo = productRepo;
            _userManager = userManager;
        }

        public async Task<int> GetTotalProductsAsync()
        {
            return await _dashboardRepo.GetTotalProductsAsync();
        }

        public async Task<int> GetTotalCategoriesAsync()
        {
            return await _dashboardRepo.GetTotalCategoriesAsync();
        }

        public async Task<int> GetTotalSuppliersAsync()
        {
            return await _dashboardRepo.GetTotalSuppliersAsync();
        }

        public async Task<int> GetTotalUsersAsync()
        {
            return _userManager.Users.Count();
        }

        public async Task<int> GetLowStockCountAsync()
        {
            return await _productRepo.GetLowStockCountAsync();
        }

        public async Task<decimal> GetTotalInventoryValueAsync()
        {
            return await _productRepo.GetTotalInventoryValueAsync();
        }

        public async Task<List<StockTransactionDto>> GetRecentTransactionsAsync(int count = 10)
        {
            var transactions = await _dashboardRepo.GetRecentTransactionsAsync(count);

            return transactions.Select(t => new StockTransactionDto
            {
                Id = t.Id,
                ProductId = t.ProductId,
                ProductName = t.Product?.Name,
                TransactionType = t.TransactionType.ToString(),
                Quantity = t.Quantity,
                PreviousQuantity = t.PreviousQuantity,
                NewQuantity = t.NewQuantity,
                Remarks = t.Remarks,
                CreatedAt = t.CreatedAt,
                CreatedBy = t.CreatedBy
            }).ToList();
        }
    }
}
