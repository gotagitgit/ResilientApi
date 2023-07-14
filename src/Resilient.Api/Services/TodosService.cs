using Resilient.Api.Dtos;
using Web.Common.RestHttpClient;
using Web.Common.RestHttpClient.Factories;
using Web.Common.RestHttpClient.Services;

namespace Resilient.Api.Services;

internal sealed class TodosService : ITodosService
{
    private readonly IRestHttpClientService _restHttpClientService;

    public TodosService(IRestHttpClientFactory restHttpClientFactory)
    {
        _restHttpClientService = restHttpClientFactory.Create(HttpClientName.TodoApi);
    }

    public async Task<IReadOnlyList<TodoDto>> GetAsync()
    {   
        var todos = await _restHttpClientService.GetAsync<IEnumerable<TodoDto>>();

        return todos.ToList();
    }
}
