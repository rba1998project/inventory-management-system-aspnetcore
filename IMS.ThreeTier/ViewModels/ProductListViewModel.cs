using IMS.BLL.DTOs;

namespace IMS.WEB.ViewModels
{
    public class ProductListViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new();

        public List<CategoryDto> Categories { get; set; } = new();

        public List<SupplierDto> Suppliers { get; set; } = new();

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public string Search { get; set; }

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }
    }
}