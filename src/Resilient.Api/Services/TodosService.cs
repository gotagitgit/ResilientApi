using Resilient.Api.Dtos;
using Resilient.Api.Factories;
using Web.Common.Services;

namespace Resilient.Api.Services;

internal sealed class TodosService : ITodosService
{
    private readonly IRestHttpClientService _restHttpClientService;

    public TodosService(ITodoClientFactory todoClientFactory)
    {
        _restHttpClientService = todoClientFactory.CreateClient();
    }

    public async Task<IReadOnlyList<TodoDto>> GetAsync()
    {
        var todos = await _restHttpClientService.GetAsync<IEnumerable<TodoDto>>();

        return todos.ToList();
    }
}
