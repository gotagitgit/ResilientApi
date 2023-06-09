namespace Resilient.Api.Settings;

public class ResilienceSettings
{
    public int RetryCount { get; set; }

    public int ExceptionsAllowedBeforeBreaking { get; set; }
}
