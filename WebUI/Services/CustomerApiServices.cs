using Entities.DTO_s;
using System.Net.Http.Headers;

namespace WebUI.Services
{
    public class CustomerApiServices
    {
        private readonly HttpClient _httpClient;

        public CustomerApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerDto>> GetAllAsync(string accessToken)
        {
            TakeToken(accessToken);

            var response = await _httpClient.GetFromJsonAsync<List<CustomerDto>>("customers");
            return response;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id,string accessToken)
        {
            TakeToken(accessToken);
            var response = await _httpClient.GetFromJsonAsync<CustomerDto>($"customers/CustomerId?id={id}");
            return response;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerDto customer, string accessToken)
        {
            TakeToken(accessToken);

            var response = await _httpClient.PutAsJsonAsync($"customers/CustomerId?id={customer.Id}", customer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomerAsync(int id, string accessToken)
        {
            TakeToken(accessToken);
            var response = await _httpClient.DeleteAsync($"customers/CustomerId?id={id}");
            return response.IsSuccessStatusCode;
        }

        public void TakeToken(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
