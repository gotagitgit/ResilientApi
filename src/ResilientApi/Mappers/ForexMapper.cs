using Forex.Domain.Models;
using ResilientApi.Dtos;

namespace ResilientApi.Mappers
{
    public sealed class ForexMapper
    {
        public static ExchangeRatesDto ToDto(ExchangeRate exchangeRate)
        {
            var dto = new ExchangeRatesDto
            {
                Rates = exchangeRate.Rates
            };

            return dto;
        }
    
    }
}
