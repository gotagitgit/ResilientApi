namespace Forex.Domain.Models
{
    public class ExchangeRate
    {
        public ExchangeRate(string baseCode, IDictionary<string, float> rates, DateTime timeLasUpdate, DateTime timeNextUpdate)
        {
            BaseCode = baseCode;
            Rates = rates;
            TimeLasUpdate = timeLasUpdate;
            TimeNextUpdate = timeNextUpdate;
        }

        public string BaseCode { get; }
        public IDictionary<string, float> Rates { get; }
        public DateTime TimeLasUpdate { get; }
        public DateTime TimeNextUpdate { get; }
    }
}
