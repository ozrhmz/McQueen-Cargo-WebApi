namespace WebUI.Extensions
{
    public static class HttpClientExtensions
    {
        public static IHttpClientBuilder AddMyHttpClient<TClient>(this IServiceCollection services, Uri baseAddress) where TClient : class
        {
            return services.AddHttpClient<TClient>(client =>
            {
                client.BaseAddress = baseAddress;
            });
        }
    }
}