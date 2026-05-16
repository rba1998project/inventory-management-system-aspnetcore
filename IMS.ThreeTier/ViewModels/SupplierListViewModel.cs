namespace IMS.WEB.ViewModels
{

    public class SupplierListViewModel
    {
        public List<SupplierViewModel> Suppliers { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public string? Search { get; set; }
    }
}