using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductController(
            IProductService service,
            ICategoryService categoryService,
            ISupplierService supplierService)
        {
            _service = service;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5, string search = "")
        {
            var result = await _service.GetPagedAsync(page, pageSize, search);

            var categories = await _categoryService.GetAllAsync();
            var suppliers = await _supplierService.GetAllAsync();

            var vm = new ProductListViewModel
            {
                Products = result.Items.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    CategoryId = x.CategoryId,
                    SupplierId = x.SupplierId,
                    CategoryName = x.CategoryName,
                    SupplierName = x.SupplierName,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    LastModifiedAt = x.LastModifiedAt,
                    LastModifiedBy = x.LastModifiedBy
                }).ToList(),

                Categories = categories.ToList(),
                Suppliers = suppliers.ToList(),

                Page = result.Page,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                Search = search
            };

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            var suppliers = await _supplierService.GetAllAsync();

            ViewBag.Categories = categories;
            ViewBag.Suppliers = suppliers;

            return PartialView("_CreateProduct", new ProductCreateViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Create(ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new ProductDto
            {
                Name = vm.Name,
                Price = vm.Price,
                CategoryId = vm.CategoryId,
                SupplierId = vm.SupplierId
            };

            var user = User?.Identity?.Name ?? "System";

            await _service.CreateAsync(dto, user);

            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Edit(ProductEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new ProductDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Price = vm.Price,
                CategoryId = vm.CategoryId,
                SupplierId = vm.SupplierId
            };

            var user = User?.Identity?.Name ?? "System";

            await _service.UpdateAsync(dto, user);

            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = User?.Identity?.Name ?? "System";

            await _service.DeleteAsync(id, user);

            return Json(new { success = true });
        }
    }
}