using WhatsNewInASPdotnetSix.Models;

namespace WhatsNewInASPdotnetSix.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
