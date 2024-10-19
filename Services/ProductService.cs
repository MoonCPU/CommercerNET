using Ecommerce.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace Ecommerce.Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://fakestoreapi.com/products";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync(baseUrl);

            //if response's code is from 200 to 299
            if (response.IsSuccessStatusCode)
            {
                //Content is the body of the http response
                var content = await response.Content.ReadAsStringAsync();
                //Deserialize convert json response in C# objects
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(content);
                //if not null, return products, if null, return List<Product>
                return products ?? new List<Product>();
            }

            return new List<Product>();
        }

        public async Task<Product?> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/{id}");

            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Product>(content);
                return product;
            }

            return null;
        }
    }
}
