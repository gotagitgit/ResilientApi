using Web.Common.Services;

namespace Resilient.Api.Factories;

public interface ITodoClientFactory
{
    IRestHttpClientService CreateClient();
    void Dispose();
}