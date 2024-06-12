using Entities.DTO_s.Auth;
using Entities.DTO_s.Employee;
using System.Net.Http.Headers;
using static Presentation.Controllers.EmployeeController;

namespace WebUI.Services
{
    public class HomeApiService
    {
        private readonly HttpClient _httpClient;

        public HomeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EmployeeDto> LoginEmployee(LoginRequestEmployee LoginEmployee, string accessToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await _httpClient.PostAsJsonAsync("employee/loginEmployee", LoginEmployee);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EmployeeDto>();
                }
                else
                {
                    return null; // Başarısız bir giriş durumu
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}