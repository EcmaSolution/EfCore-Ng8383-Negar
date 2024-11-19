using EfCore.Application.Contracts.Product;
using EfCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Infrastructure.EfCore.Repository;

public class ProductRepository : IProductRepository
{
    private readonly EfContext context;

    public ProductRepository(EfContext context)
    {
        this.context = context;
    }

    public Product? GetProduct(int productId)
    {
        return context.Products.AsNoTracking().FirstOrDefault(x => x.Id == productId);
    }

    public EditProduct? GetDetails(int id)
    {
        return context.Products.Select(x => new EditProduct()
        {
            Id = (int)x.Id,
            Name = x.Name,
            UnitPrice = x.UnitPrice,
            CategoryId = x.CategoryId
        }).FirstOrDefault(x => x.Id == id);
    }

    public void CreateProduct(Product? product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public void Attach(Product product)
    {
        context.Attach(product);
    }

    public bool Exists(string name, int categoryId)
    {
        return context.Products.Any(x => x.Name == name && x.CategoryId == categoryId);
    }

    public List<ProductViewModel> Search(ProductSearchModel product)
    {
        var query = context.Products
            .Include(x => x.Category)
            .Select(x => new ProductViewModel()
        {
            Id = (int)x.Id,
            Name = x.Name,
            UnitPrice = x.UnitPrice,
            IsRemoved = x.IsRemoved,
            CreationDate = x.CreationDate.ToString(),
            Category = x.Category.Name
        });

        if (product.IsRemoved == true)
        {
            query = query.Where(x => x.IsRemoved == true);
        }

        if (!string.IsNullOrWhiteSpace(product.Name))
        {
            query = query.Where(x => x.Name.Contains(product.Name));
        }

        return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
    }
}