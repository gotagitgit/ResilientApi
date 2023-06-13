namespace Web.Common.Simmy.Settings;

public class ChaosSettings
{
    public List<OperationChaosSetting> OperationChaosSettings { get; set; }

    public OperationChaosSetting GetSettingsFor(string operationKey) => OperationChaosSettings?.SingleOrDefault(i => i.OperationKey == operationKey);
}
