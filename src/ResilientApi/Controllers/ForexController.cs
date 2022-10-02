using Forex.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using ResilientApi.Dtos;
using ResilientApi.Mappers;

namespace ResilientApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForexController : ControllerBase
    {
        private readonly IForexService _forexService;

        public ForexController(IForexService forexService)
        {
            _forexService = forexService;
        }

        [HttpGet]
        public async Task<ActionResult<ExchangeRatesDto>> GetAsync(string currency)
        {
            var exchangeRate = await _forexService.GetExchangeRatesAsync(currency);            

            return Ok(ForexMapper.ToDto(exchangeRate));
        }
    }
}