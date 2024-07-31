using BigFoodData.Models;
using System.Net.Http.Json;

namespace BigFoodWeb.Services
{
    public class SaleServices
    {
        private readonly HttpClient _httpClient;

        public SaleServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Sale>> GetAllSale(string search)
        {
            return await _httpClient.GetFromJsonAsync<List<Sale>>($"Sale/Get-All?search={search}");
        }

        public async Task<Sale> GetSaleById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Sale>($"Sale/Get-By-Id?id={id}");
        }

        public async Task<bool> CreateSale(Sale sale)
        {
            var response = await _httpClient.PostAsJsonAsync<Sale>("Sale/Create", sale);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSale(Sale sale)
        {
            var response = await _httpClient.PutAsJsonAsync<Sale>("Sale/Update", sale);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSale(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"Sale/Delete?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
