using IMS.WEB.ViewModels;

public class CategoryListViewModel
{
    public List<CategoryViewModel> Categories { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public string? Search { get; set; }
}