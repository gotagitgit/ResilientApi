using Resilient.Api.Dtos;
using Web.Common.RestHttpClient.Services;

namespace Resilient.Api.IntegrationTests.Services;

internal class ResilientApiClientService : IResilientApiClientService
{
    private readonly IRestHttpClientService _restHttpClientService;

    public ResilientApiClientService(ResilientApiHttpClientService resilientApiHttpClientService)
    {
        _restHttpClientService = resilientApiHttpClientService;
    }

    public async Task<IReadOnlyList<TodoDto>> GetAsync()
    {
        var result = await _restHttpClientService.GetAsync<IReadOnlyList<TodoDto>>("/api/todo");

        return result;
    }
}
