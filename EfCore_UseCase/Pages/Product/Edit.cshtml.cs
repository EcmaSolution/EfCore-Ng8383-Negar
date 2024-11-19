using EfCore.Application.Contracts.Product;
using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCore_UseCase.Pages.Product;

public class Edit : PageModel
{
    public SelectList ProductCategories;
    public EditProduct? Command;
    private readonly IProductCategoryApplication productCategoryApplication;
    private readonly IProductApplication productApplication;

    public Edit(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
    {
        this.productApplication = productApplication;
        this.productCategoryApplication = productCategoryApplication;
    }

    public void OnGet(int id)
    {
        ProductCategories = new SelectList(productCategoryApplication.GetAll(), "Id", "Name");
        Command = productApplication.GetDetails(id);
    }

    public RedirectToPageResult OnPost(EditProduct command)
    {
        productApplication.Edit(command);
        return RedirectToPage("./Index");
    }
}