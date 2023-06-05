using Resilient.Api.Dtos;
using Web.Common.Services;

namespace Resilient.Api.IntegrationTests.Services;

internal class ResilientApiClientService : IResilientApiClientService
{
    private readonly IRestHttpClientService _restHttpClientService;

    public ResilientApiClientService(IRestHttpClientService restHttpClientService)
    {
        this._restHttpClientService = restHttpClientService;
    }

    public async Task<IEnumerable<TodoDto>> GetAsync()
    {
        return await _restHttpClientService.GetAsync<IEnumerable<TodoDto>>();
    }
}
