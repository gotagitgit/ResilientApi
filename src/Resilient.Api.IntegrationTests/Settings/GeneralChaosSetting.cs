namespace Resilient.Api.IntegrationTests.Settings;

public class GeneralChaosSetting
{
    public bool Sentinel { get; set; }

    public Guid Id { get; set; }

    public bool AutomaticChaosInjectionEnabled { get; set; }

    public bool ClusterChaosEnabled { get; set; }

    public double ClusterChaosInjectionRate { get; set; }

    public TimeSpan Frequency { get; set; }

    public TimeSpan MaxDuration { get; set; }

    public string SubscriptionId { get; set; }

    public string TenantId { get; set; }

    public string ClientId { get; set; }

    public string ClientKey { get; set; }

    public int PercentageNodesToRestart { get; set; }

    public int PercentageNodesToStop { get; set; }

    public string ResourceGroupName { get; set; }

    public string VMScaleSetName { get; set; }

    public List<OperationChaosSetting> OperationChaosSettings { get; set; }

    public OperationChaosSetting GetSettingsFor(string operationKey) => OperationChaosSettings?.SingleOrDefault(i => i.OperationKey == operationKey);
}
