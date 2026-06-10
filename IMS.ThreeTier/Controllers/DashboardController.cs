using IMS.BLL.Interfaces;
using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    [Authorize(Roles = "Admin,InventoryManager")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var totalProducts = await _dashboardService.GetTotalProductsAsync();
            var totalCategories = await _dashboardService.GetTotalCategoriesAsync();
            var totalSuppliers = await _dashboardService.GetTotalSuppliersAsync();
            var totalUsers = await _dashboardService.GetTotalUsersAsync();
            var lowStockCount = await _dashboardService.GetLowStockCountAsync();
            var totalInventoryValue = await _dashboardService.GetTotalInventoryValueAsync();
            var recentTransactions = await _dashboardService.GetRecentTransactionsAsync(10);

            var vm = new DashboardViewModel
            {
                TotalProducts = totalProducts,
                TotalCategories = totalCategories,
                TotalSuppliers = totalSuppliers,
                TotalUsers = totalUsers,
                LowStockProducts = lowStockCount,
                TotalInventoryValue = totalInventoryValue,
                RecentTransactions = recentTransactions
            };

            return View(vm);
        }
    }
}
