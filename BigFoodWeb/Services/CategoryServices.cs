using BigFoodData.Models;
using System.Net.Http.Json;

namespace BigFoodWeb.Services
{
    public class CategoryServices
    {
        private readonly HttpClient _httpClient;

        public CategoryServices( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetAllCategory(string search)
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>($"Category/Get-All?search={search}");
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"Category/Get-By-Id?id={id}");
        }

        public async Task<bool> CreateCategory(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync<Category>("Category/Create", category);
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var response = await _httpClient.PutAsJsonAsync<Category>("Category/Update", category);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var response = await _httpClient.DeleteAsync($"Category/Delete?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
