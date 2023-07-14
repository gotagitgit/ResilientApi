namespace Resilient.Api.IntegrationTests.Services;

internal class ResilientApiClientService : IResilientApiClientService
{    
    private readonly HttpClient _httpClient;

    public ResilientApiClientService(HttpClient httpClient)
    {        
        this._httpClient = httpClient;
    }

    public async Task GetAsync()
    {
        var uri = new Uri(_httpClient.BaseAddress, "/api/todo");

        await _httpClient.GetAsync(uri);
    }
}
