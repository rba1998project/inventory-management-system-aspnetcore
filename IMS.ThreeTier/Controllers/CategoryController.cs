using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        //TODO: Implement pagination and search functionality
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5, string search = "")
        {
            //commented and added for pagination and search functionality
            //var data = await _service.GetAllAsync();

            //var vm = data.Select(x => new CategoryViewModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    ProductCount = x.ProductCount,
            //    CreatedAt = x.CreatedAt,
            //    CreatedBy = x.CreatedBy,
            //    LastModifiedAt = x.LastModifiedAt,
            //    LastModifiedBy = x.LastModifiedBy
            //}).ToList();

            var result = await _service.GetPagedAsync(page, pageSize, search);

            var vm = new CategoryListViewModel
            {
                Categories = result.Items.Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
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

        [Authorize(Roles = "Admin,InventoryManager")]
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreateCategory", new CategoryCreateViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Create(CategoryCreateViewModel ccvm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new CategoryDto
            {
                Name = ccvm.Name,
                Description = ccvm.Description
            };

            var user = User.Identity.Name;

            await _service.CreateAsync(dto, user);

            return Json(new { success = true });
        }


        [HttpPost]
        [Authorize(Roles = "Admin,InventoryManager")]
        public async Task<IActionResult> Edit(CategoryEditViewModel cevm)
        {
            var dto = new CategoryDto
            {
                Id = cevm.Id,
                Name = cevm.Name,
                Description = cevm.Description
            };

            var user = User.Identity.Name;

            await _service.UpdateAsync(dto, user);

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
            var productNames = await _service.GetProductNamesByCategoryIdAsync(id);

            return PartialView("_ProductList", productNames);
        }
    }
}
