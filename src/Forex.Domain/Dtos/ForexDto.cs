namespace Forex.Domain.Dtos
{
    internal class ForexDto
    {
        public ForexDto()
        {
        }

        public string base_code { get; set; }
        public IDictionary<string, float> Rates { get; set; }
        public string Time_last_update_utc { get; set; }
        public string Time_next_update_utc { get; set; }
    }
}
