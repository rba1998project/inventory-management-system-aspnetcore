using System.ComponentModel.DataAnnotations;

namespace IMS.WEB.ViewModels
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Low Stock Threshold must be a positive number")]
        public int LowStockThreshold { get; set; } = 1;
    }
}