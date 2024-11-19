using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.ProductCategoryAgg;

namespace EfCore.Infrastructure.EfCore.Repository;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly EfContext context;

    public ProductCategoryRepository(EfContext context) 
    {
        this.context = context;
    }

    public ProductCategory? GetProductCategory(int id)
    {
        return context.ProductCategories.FirstOrDefault(x => x.Id == id);
    }

    public bool Exists(string name)
    {
        return context.ProductCategories.Any(x => x.Name == name);
    }

    public void CreateProductCategory(ProductCategory productCategory)
    {
        context.ProductCategories.Add(productCategory);
        SaveChanges();
    }

    public EditProductCategory? GetDetails(int id)
    {
        return context.ProductCategories.Select(x => new EditProductCategory
        {
            Id = x.Id,
            Name = x.Name,
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<ProductCategoryViewModel> Search(string name)
    {
        var query = context.ProductCategories.Select(x => new ProductCategoryViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            CreationDate = x.CreationDate.ToString()
        });
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        return query.OrderByDescending(x => x.Id).ToList();
    }

    public List<ProductCategoryViewModel> GetAll()
    {
        return context.ProductCategories.Select(x => new ProductCategoryViewModel()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}