using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Web.Common.Extensions;
using Web.Common.Loggers;
using Web.Common.RestHttpClient.Services;
using Web.Common.Simmy.Extensions;
using Web.Common.Simmy.Settings;

namespace Web.Common.ChaosMonkey.Services;

internal sealed class InjectChaosService : IChaosService
{
    private readonly ChaosSettings _chaosSettings;
    private readonly IResilientStrategyLogger _logger;


    public InjectChaosService(IOptions<ChaosSettings> chaosSettings, IResilientStrategyLogger logger)
    {
        _chaosSettings = chaosSettings.Value;
        _logger = logger;
    }

    public void InjectChaosToRequest(HttpRequestMessage request, string contextName)
    {
        if (_chaosSettings is null)
            return;

        var context = new Context(contextName).WithChaosSettings(_chaosSettings)
                                              .WithLogger(_logger);

        request.SetPolicyExecutionContext(context);
    }
}
