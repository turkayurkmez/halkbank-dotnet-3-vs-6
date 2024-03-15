namespace whatIsMinimalApi.Services
{
    public class ProductService : IProductService
    {
        private List<ProductResponse> products;
        public ProductService()
        {
            products = new List<ProductResponse>()
                {
                     new ProductResponse(1,"Ürün A",5),
                     new ProductResponse(Id:2, Name:"Ürün B", Price:155),

                };
        }
        public IEnumerable<ProductResponse> GetProducts()
        {
            return products;
        }

        public ProductResponse GetProduct(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProductResponse> Search(string name)
        {
            return products.Where(p => p.Name.Contains(name));
        }

        public int Create(CreateProductRequest createProductRequest)
        {
            var lastId = products.Last().Id + 1;
            var product = new ProductResponse(lastId, createProductRequest.Name, createProductRequest.Price);
            products.Add(product);
            return lastId;

        }
    }

    public record ProductResponse(int Id, string Name, decimal? Price);
    public record CreateProductRequest(string Name, decimal? Price);
}
