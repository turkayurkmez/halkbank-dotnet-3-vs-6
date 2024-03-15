using WhatsNewInASPdotnetSix.Models;

namespace WhatsNewInASPdotnetSix.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Id=1, Name="X", Price=100 },
                new(){ Id=2, Name="Y", Price=150 },

            };
        }
    }
}
