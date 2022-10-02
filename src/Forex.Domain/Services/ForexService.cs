using System.Text.Json;
using Forex.Domain.Dtos;
using Forex.Domain.Extensions;
using Forex.Domain.Factories;
using Forex.Domain.Models;

namespace Forex.Domain.Services
{
    internal sealed class ForexService : IForexService
    {
        private readonly ForexHttpClient _httpClient;

        public ForexService(IForexHttpClientFactory forexHttpClientFactory)
        {
            _httpClient = forexHttpClientFactory.CreateClient();
        }

        public async Task<ExchangeRate> GetExchangeRatesAsync(string currency)
        {
            var currencyCode = string.IsNullOrEmpty(currency) ? "USD" : currency;

            var baseUri = new Uri(@"https://open.er-api.com/v6/latest/");
            var uri = new Uri(baseUri, currencyCode);

            using  var response = await _httpClient.GetAsync(uri);

            return await DeserializeResponeAsync(response);
        }

        private static async ValueTask<ExchangeRate> DeserializeResponeAsync(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var dto = JsonSerializer.Deserialize<ForexDto>(json, options);

            return ToModel(dto);
        }

        private static ExchangeRate ToModel(ForexDto dto)
        {
            _ = DateTime.TryParse(dto.Time_last_update_utc, out var lastUpdate);
            _ = DateTime.TryParse(dto.Time_next_update_utc, out var nextUpdate);

            return new ExchangeRate(dto.base_code, dto.Rates, lastUpdate, nextUpdate);
        }
    }
}
