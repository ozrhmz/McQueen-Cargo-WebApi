namespace WebUI.Services
{
    public class CargoApiServices
    {
        private readonly HttpClient _httpClient;

        public CargoApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
