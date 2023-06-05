using Resilient.Api.Dtos;

namespace Resilient.Api.Services;
public interface ITodosService
{
    Task<IReadOnlyList<TodoDto>> GetAsync();
}