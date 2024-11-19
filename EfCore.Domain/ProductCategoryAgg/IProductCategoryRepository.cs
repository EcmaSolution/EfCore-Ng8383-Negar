using EfCore.Application.Contracts.ProductCategory;

namespace EfCore.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository
{
    ProductCategory? GetProductCategory(int id);
    bool Exists(string name);
    void CreateProductCategory(ProductCategory productCategory);
    EditProductCategory? GetDetails(int id);
    List<ProductCategoryViewModel> Search(string name);
    List<ProductCategoryViewModel> GetAll();
    void SaveChanges();
}