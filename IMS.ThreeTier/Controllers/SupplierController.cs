using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5, string search = "")
        {
            var result = await _service.GetPagedAsync(page, pageSize, search);

            var vm = new SupplierListViewModel
            {
                Suppliers = result.Items.Select(x => new SupplierViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ContactPerson = x.ContactPerson,
                    Email = x.Email,
                    Phone = x.Phone,
                    Address = x.Address,
                    ProductCount = x.ProductCount,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    LastModifiedAt = x.LastModifiedAt,
                    LastModifiedBy = x.LastModifiedBy
                }).ToList(),

                Page = result.Page,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                Search = search
            };

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,InventoryManager")]
        public IActionResult Create()
        {
            return PartialView("_CreateSupplier", new SupplierCreateViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Create(SupplierCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new SupplierDto
            {
                Name = vm.Name,
                ContactPerson = vm.ContactPerson,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address
            };

            await _service.CreateAsync(dto, User.Identity.Name);

            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Edit(SupplierEditViewModel vm)
        {
            var dto = new SupplierDto
            {
                Id = vm.Id,
                Name = vm.Name,
                ContactPerson = vm.ContactPerson,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address
            };

            await _service.UpdateAsync(dto, User.Identity.Name);

            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id, User.Identity.Name);

            return Json(new { success = true });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts(int id)
        {
            var productNames = await _service.GetProductNamesBySupplierIdAsync(id);

            return PartialView("_ProductList", productNames);
        }
    }
}