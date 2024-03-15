using WhatsNewInASPdotnetSix.Models;

namespace WhatsNewInASPdotnetSix.Services
{
    public class AlternateProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Id=8, Name="A", Price=1000 },
                new(){ Id=9, Name="B", Price=1500 },

            };
        }
    }
}
