using EfCore.Application.Contracts.Product;
using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCore_UseCase.Pages.Product
{
    public class Create : PageModel
    {
        public SelectList ProductCategories;
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;

        public Create(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            ProductCategories = new SelectList(productCategoryApplication.GetAll(), "Id", "Name");
        }

        public RedirectToPageResult OnPost(CreateProduct command)
        {
            productApplication.CreateProduct(command);
            return RedirectToPage("/Product/Index");
        }
    }
}