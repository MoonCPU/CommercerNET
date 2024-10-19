using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product?> GetProductById(int id);
    }
}
