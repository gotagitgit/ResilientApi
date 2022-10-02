namespace Forex.Domain.Factories
{
    internal interface IForexHttpClientFactory
    {
        ForexHttpClient CreateClient();
    }
}