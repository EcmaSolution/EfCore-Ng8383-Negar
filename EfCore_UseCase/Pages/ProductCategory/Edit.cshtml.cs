﻿using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EfCore_UseCase.Pages.ProductCategory;

public class Edit : PageModel
{
    public EditProductCategory Command;
    private readonly IProductCategoryApplication productCategoryApplication;

    public Edit(IProductCategoryApplication productCategoryApplication)
    {
        this.productCategoryApplication = productCategoryApplication;
    }

    public void OnGet(int id)
    {
        Command = productCategoryApplication.GetDetails(id);
    }

    public RedirectToPageResult OnPost(EditProductCategory command)
    {
        productCategoryApplication.Edit(command);
        return RedirectToPage("./Index");
    }
}