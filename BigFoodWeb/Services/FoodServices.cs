using BigFoodData.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BigFoodWeb.Services
{
    public class FoodServices
    {
        private readonly HttpClient _httpClient;

        public FoodServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Food>> GetAllFood()
        {
            var lst = await _httpClient.GetFromJsonAsync<List<Food>>("Food/Get-All");
            return lst;
        }

        public async Task<Food> GetById(Guid id)
        {
            var obj1 = await _httpClient.GetFromJsonAsync<Food>($"Food/Get-By-Id?id={id}");
            return obj1;
        }

        public bool Create(Food food)
        {
            string url = "https://localhost:7240/Food/Create";
            var response = _httpClient.PostAsJsonAsync(url, food).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool Update(Food food)
        {
            string url = "https://localhost:7240/Food/Update";
            var response = _httpClient.PutAsJsonAsync(url, food).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            string url = $"https://localhost:7240/Food/Delete?={id}";
            var response = _httpClient.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
