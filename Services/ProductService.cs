using System.Net.Http.Json;
using ECommerce.Client.Models;

namespace ECommerce.Client.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
            return products ?? new List<Product>();
        }

        public async Task AddProductAsync(Product newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", newProduct);
            response.EnsureSuccessStatusCode();
        }
    }
}
