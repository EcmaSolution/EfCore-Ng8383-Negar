using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCore_UseCase.Pages.ProductCategory;

public class Index : PageModel
{
    public List<ProductCategoryViewModel> ProductCategories;
    private readonly IProductCategoryApplication productCategoryApplication;

    public Index(IProductCategoryApplication productCategoryApplication)
    {
        this.productCategoryApplication = productCategoryApplication;
    }

    public void OnGet(string name)
    {
        ProductCategories = productCategoryApplication.Search(name);
    }

}