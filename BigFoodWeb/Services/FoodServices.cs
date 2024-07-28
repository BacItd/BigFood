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
            var allFood = await _httpClient.GetAsync("https://localhost:7240/Food/Get-All");
            var response = await allFood.Content.ReadFromJsonAsync<List<Food>>();
            return response;
        }

        public Food GetById(Guid id)
        {
            string url = $"https://localhost:7240/Food/Get-By-Id?id={id}";
            var response = _httpClient.GetStringAsync(url).Result;
            Food obj = JsonConvert.DeserializeObject<Food>(response);

            return obj;
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
