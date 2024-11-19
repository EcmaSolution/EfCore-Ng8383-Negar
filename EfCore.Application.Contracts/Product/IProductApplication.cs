namespace EfCore.Application.Contracts.Product;

public interface IProductApplication
{
    void CreateProduct(CreateProduct command);
    EditProduct? GetDetails(int id);
    void Edit(EditProduct command);
    void Remove(int id);
    void Restore(int id);

    List<ProductViewModel> Search(ProductSearchModel productSearchModel);
}