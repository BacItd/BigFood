using BigFoodData.Models;
using System.Net.Http.Json;

namespace BigFoodWeb.Services
{
    public class RoleServices
    {
        private readonly HttpClient _httpClient;

        public RoleServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Role>> GetAllRole()
        {
            return await _httpClient.GetFromJsonAsync<List<Role>>($"Role/Get-All");
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Role>($"Role/Get-By-Id?id={id}");
        }
    }
}
