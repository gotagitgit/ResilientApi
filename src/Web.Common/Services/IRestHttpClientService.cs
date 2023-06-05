namespace Web.Common.Services;

public interface IRestHttpClientService
{
    Task<TResponse> GetAsync<TResponse>(string routeSuffix = "");
    Task<TResponse> PostAsync<TRequest, TResponse>(string routeSuffix, TRequest requestContent);
}