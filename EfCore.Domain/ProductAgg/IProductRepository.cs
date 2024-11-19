using EfCore.Application.Contracts.Product;

namespace EfCore.Domain.ProductAgg;

public interface IProductRepository
{
    Product? GetProduct(int productId);
    EditProduct? GetDetails(int id);
    void CreateProduct(Product? product);
    void SaveChanges();
    void Attach(Product product);
    bool Exists(string name, int categoryId);
    List<ProductViewModel> Search(ProductSearchModel product);
}