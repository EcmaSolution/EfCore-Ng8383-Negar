using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.ProductCategoryAgg;

namespace EfCore.Application;

public class ProductCategoryApplication : IProductCategoryApplication
{
    private readonly IProductCategoryRepository productCategoryRepository;

    public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
    {
        this.productCategoryRepository = productCategoryRepository;
    }

    public void Create(CreateProductCategory command)
    {
        if (productCategoryRepository.Exists(command.Name))
            return;
        
        var productCategory = new ProductCategory(command.Name);
        productCategoryRepository.CreateProductCategory(productCategory);
        productCategoryRepository.SaveChanges();
        
    }

    public void Edit(EditProductCategory command)
    {
        var productcategory = productCategoryRepository.GetProductCategory(command.Id);
        if (productcategory == null)
        {
            return;
        }
        productcategory.Edite(command.Name);
        productCategoryRepository.SaveChanges();
    }

    public List<ProductCategoryViewModel> GetAll()
    {
        return productCategoryRepository.GetAll();
    }

    public EditProductCategory? GetDetails(int id)
    {
        return productCategoryRepository.GetDetails(id);
    }

    public List<ProductCategoryViewModel> Search(string name)
    {
        return productCategoryRepository.Search(name);
    }
}