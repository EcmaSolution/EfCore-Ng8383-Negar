using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCore_UseCase.Pages.ProductCategory
{
    public class CreateModel : PageModel
    {
        private readonly IProductCategoryApplication productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateProductCategory command)
        {
            productCategoryApplication.Create(command);
            return RedirectToPage("/ProductCategory/Index");
        }
    }
}
