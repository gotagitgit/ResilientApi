namespace Forex.Domain.Factories
{
    public sealed class ForexHttpClient : IDisposable
    {
        public const string ForexHttpClientName = "ForexHttpClient";

        private readonly HttpClient _httpClient;

        public ForexHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _httpClient.SendAsync(request);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
