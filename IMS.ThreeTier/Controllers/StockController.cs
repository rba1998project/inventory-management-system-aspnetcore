using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    [Authorize(Roles = "Admin,InventoryManager")]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IProductService _productService;

        public StockController(
            IStockService stockService,
            IProductService productService)
        {
            _stockService = stockService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(
           int page = 1,
           int pageSize = 10,
           string search = "")
        {
            var result = await _productService
                .GetPagedAsync(page, pageSize, search);

            var vm = new StockHistoryViewModel
            {
                Products = result.Items.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.Quantity
                }).ToList(),

                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(
                    result.TotalCount / (double)pageSize),

                Search = search
            };

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> History(
            int page = 1,
            int pageSize = 10,
            string search = "")
        {
            var transactions = await _stockService
                .GetAllTransactionsAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                transactions = transactions
                    .Where(t => t.Product.Name
                    .Contains(search,
                    StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var totalCount = transactions.Count;

            var paged = transactions
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var vm = new StockHistoryViewModel
            {
                Transactions = paged.Select(t =>
                    new StockTransactionViewModel
                    {
                        Id = t.Id,
                        ProductName = t.Product.Name,
                        TransactionType = t.TransactionType.ToString(),
                        Quantity = t.Quantity,
                        PreviousQuantity = t.PreviousQuantity,
                        NewQuantity = t.NewQuantity,
                        Remarks = t.Remarks,
                        CreatedAt = t.CreatedAt,
                        CreatedBy = t.CreatedBy
                    }).ToList(),

                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(
                    totalCount / (double)pageSize),

                Search = search
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> StockIn(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var vm = new StockInViewModel
            {
                ProductId = product.Id
            };

            ViewBag.ProductName = product.Name;
            ViewBag.CurrentStock = product.Quantity;

            return PartialView("_StockInModal", vm);
        }

        [HttpPost]
        public async Task<IActionResult> StockIn(StockInViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid stock input.");

            var dto = new StockInDto
            {
                ProductId = vm.ProductId,
                Quantity = vm.Quantity,
                Remarks = vm.Remarks
            };

            await _stockService.StockInAsync(dto, User.Identity.Name);

            return Json(new
            {
                success = true
            });
        }

        [HttpGet]
        public async Task<IActionResult> StockOut(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var vm = new StockOutViewModel
            {
                ProductId = product.Id
            };

            ViewBag.ProductName = product.Name;
            ViewBag.CurrentStock = product.Quantity;

            return PartialView("_StockOutModal", vm);
        }

        [HttpPost]
        public async Task<IActionResult> StockOut(StockOutViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid stock output.");

            var dto = new StockOutDto
            {
                ProductId = vm.ProductId,
                Quantity = vm.Quantity,
                Remarks = vm.Remarks
            };

            var success = await _stockService.StockOutAsync(dto, User.Identity.Name);

            if (!success)
            {
                return BadRequest("Insufficient stock.");
            }

            return Json(new
            {
                success = true
            });
        }
    }
}