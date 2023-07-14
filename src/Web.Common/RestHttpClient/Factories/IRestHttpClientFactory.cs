using Web.Common.RestHttpClient.Services;

namespace Web.Common.RestHttpClient.Factories;

public interface IRestHttpClientFactory
{
    IRestHttpClientService Create(HttpClientName httpClientName);
}