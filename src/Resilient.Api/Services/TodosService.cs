using Resilient.Api.Dtos;
using Web.Common.Services;

namespace Resilient.Api.Services;

internal sealed class TodosService : ITodosService
{
    private readonly IRestHttpClientService _restHttpClientService;

    public TodosService(IRestHttpClientService restHttpClientService)
    {
        _restHttpClientService = restHttpClientService;
    }

    public async Task<IReadOnlyList<TodoDto>> GetAsync()
    {   
        var todos = await _restHttpClientService.GetAsync<IEnumerable<TodoDto>>();

        return todos.ToList();
    }
}
