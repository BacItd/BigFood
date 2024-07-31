using BigFoodData.Models;
using System.Net.Http.Json;

namespace BigFoodWeb.Services
{
    public class UserServices
    {
        private readonly HttpClient _httpClient;

        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUser(string search)
        {
            return await _httpClient.GetFromJsonAsync<List<User>>($"User/Get-All?search={search}");
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"User/Get-By-Id?id={id}");
        }

        public async Task<bool> CreateUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync<User>("User/Create", user);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var response = await _httpClient.PutAsJsonAsync<User>("User/Update", user);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"User/Delete?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
