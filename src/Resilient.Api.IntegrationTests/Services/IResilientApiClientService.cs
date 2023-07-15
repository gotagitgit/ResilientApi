using Resilient.Api.Dtos;

namespace Resilient.Api.IntegrationTests.Services;

public interface IResilientApiClientService
{
    Task<IReadOnlyList<TodoDto>> GetAsync();
}