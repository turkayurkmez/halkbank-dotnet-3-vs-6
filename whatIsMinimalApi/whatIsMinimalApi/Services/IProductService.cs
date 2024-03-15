
namespace whatIsMinimalApi.Services
{
    public interface IProductService
    {
        int Create(CreateProductRequest createProductRequest);
        ProductResponse GetProduct(int id);
        IEnumerable<ProductResponse> GetProducts();
        IEnumerable<ProductResponse> Search(string name);
    }
}