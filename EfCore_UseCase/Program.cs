using EfCore.Application;
using EfCore.Application.Contracts.Product;
using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.ProductAgg;
using EfCore.Domain.ProductCategoryAgg;
using EfCore.Infrastructure.EfCore;
using EfCore.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddTransient<IProductApplication, ProductApplication>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

//var connectionString = builder.Configuration.GetConnectionString("EfCoreProject");
var connectionString = builder.Configuration.GetConnectionString("EfCoreLocal");
builder.Services.AddDbContext<EfContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();