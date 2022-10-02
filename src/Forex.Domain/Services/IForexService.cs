using Forex.Domain.Models;

namespace Forex.Domain.Services
{
    public interface IForexService
    {
        Task<ExchangeRate> GetExchangeRatesAsync(string currency);
    }
}