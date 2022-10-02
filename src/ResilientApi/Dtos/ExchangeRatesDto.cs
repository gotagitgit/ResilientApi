namespace ResilientApi.Dtos
{
    public sealed class ExchangeRatesDto
    {
        public ExchangeRatesDto()
        {
            Rates = new Dictionary<string, float>();
        }

        public IDictionary<string, float> Rates { get; set; }
    }
}
