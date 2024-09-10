using Product_MVC.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Product_MVC.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //TODO 2
        private readonly HttpClient _httpClient;
        public ProductRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync("api/Home/GetAllProducts/GetAllProducts");
            response.EnsureSuccessStatusCode();
            List<ProductViewModel> products = await response.Content.ReadFromJsonAsync<List<ProductViewModel>>();

            if (products.Count > 0)
            {
                return products;
            }
            else
            {
                return new List<ProductViewModel>();
            }            

        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
        {
            var json = JsonSerializer.Serialize(productVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Home/CreateProduct", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var prd = JsonSerializer.Deserialize<ProductViewModel>(responseData);
                return prd;
            }
            else
            {
                return new ProductViewModel();
            }
        }
    }
}
