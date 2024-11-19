using EfCore.Application.Contracts.Product;
using EfCore.Domain.ProductAgg;

namespace EfCore.Application;

public class ProductApplication : IProductApplication
{
    private readonly IProductRepository productRepository;

    public ProductApplication(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public void CreateProduct(CreateProduct command)
    {
        if (productRepository.Exists(command.Name, command.CategoryId))
        {
            return;
        }

        var product = new Product(command.Name, command.UnitPrice, command.CategoryId);
        productRepository.CreateProduct(product);
        productRepository.SaveChanges();
    }

    public EditProduct? GetDetails(int id)
    {
        return productRepository.GetDetails(id);
    }

    public void Edit(EditProduct command)
    {
        var product = productRepository.GetProduct(command.Id);
        if (product == null)
        {
            return;
        }

        productRepository.Attach(product);
        product.Edite(command.Name, command.UnitPrice, command.CategoryId);
        productRepository.SaveChanges();
    }

    public void Remove(int id)
    {
        var product = productRepository.GetProduct(id);
        if (product == null)
        {
            return;
        }

        product.Remove();
        productRepository.SaveChanges();
    }

    public void Restore(int id)
    {
        var product = productRepository.GetProduct(id);
        if (product == null)
        {
            return;
        }

        product.Restore();
        productRepository.SaveChanges();
    }

    public List<ProductViewModel> Search(ProductSearchModel productSearchModel)
    {
       return productRepository.Search(productSearchModel);
    }
}