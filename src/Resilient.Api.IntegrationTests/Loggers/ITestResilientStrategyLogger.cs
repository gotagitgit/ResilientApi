using Web.Common.Loggers;

namespace Resilient.Api.IntegrationTests.Loggers;

internal interface ITestResilientStrategyLogger : IResilientStrategyLogger
{
    int RetryCount { get; }    
}