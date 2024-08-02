using BigFoodData.Models;
using System.Net.Http.Json;

namespace BigFoodWeb.Services
{
    public class CartServices
    {
        private readonly HttpClient _httpClient;

        public CartServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Cart> GetCartById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Cart>($"Cart/Get-Cart-By-Id?id={id}");
        }

        public async Task<Cart> GetCartByIdUser(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Cart>($"Cart/Get-Cart-By-Id-User?id={id}");
        }

        public async Task<bool> CreateCart(Cart cart)
        {
            var check = await _httpClient.PostAsJsonAsync<Cart>("Cart/Create", cart);
            if(check.IsSuccessStatusCode) 
            {
                return true;
            }
            return false;
        }

        public async Task<List<CartDetail>> GetAllCartDetails(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<List<CartDetail>>($"Cart/Get-All-CartDetails-By-CartId?id={id}");
        }
        
        public async Task<bool> DeleteCartDetailById(int id)
        {
            var check = await _httpClient.DeleteAsync($"Cart/Delete-CartDetail-By-Id?id={id}");
            if (check.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
