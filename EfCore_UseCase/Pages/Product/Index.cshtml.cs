using EfCore.Application;
using EfCore.Application.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCore_UseCase.Pages.Product;

[BindProperties]
public class Index : PageModel
{
    
    public List<ProductViewModel>? Products;
  
    private readonly IProductApplication productApplication;

    public Index(IProductApplication productApplication)
    {
        this.productApplication = productApplication;
    }

    public void OnGet(ProductSearchModel name)
    {
        Products = productApplication.Search(name);
    }

    public IActionResult OnPostRemove(int id)
    {
        productApplication.Remove(id);
        return RedirectToPage("/Product/Index");
    }

    public IActionResult OnPostRestore(int id)
    {
        productApplication.Restore(id);
        return RedirectToPage("/Product/Index");
    }
}