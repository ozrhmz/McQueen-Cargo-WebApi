using Entities.DTO_s.Auth;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TokenDto> Login()
    {
        try
        {
            UserForAuthenticationDto userInfo = new UserForAuthenticationDto()
            {
                UserName = "muratcals",
                Password = "C5raxmGc1-"
            };

            var response = await _httpClient.PostAsJsonAsync("authentication/login", userInfo);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TokenDto>();
            }
            else
            {
                return null; // Başarısız bir giriş durumu
            }
        }
        catch (Exception ex)
        {
            // Hata yönetimi
            return null;
        }
    }
}
