using IMS.BLL.DTOs;

namespace IMS.WEB.ViewModels
{
    public class LowStockViewModel
    {
        public List<ProductDto> Products { get; set; } = new();

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }
    }
}
