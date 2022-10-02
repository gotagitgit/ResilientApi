namespace Forex.Domain.Factories
{
    internal sealed class ForexHttpClientFactory : IForexHttpClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ForexHttpClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public ForexHttpClient CreateClient()
        {
            var httpClient = _httpClientFactory.CreateClient(ForexHttpClient.ForexHttpClientName);

            return new ForexHttpClient(httpClient);
        }
    }
}
