using Web.Common.RestHttpClient;

namespace Web.Common.RestHttpClient.Services;

public interface IRestHttpClientService
{
    HttpClientName HttpClientName { get; }
    Task<TResponse> GetAsync<TResponse>(string routeSuffix = "");
    Task<TResponse> PostAsync<TRequest, TResponse>(string routeSuffix, TRequest requestContent);
}