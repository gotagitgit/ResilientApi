using Polly;
using Web.Common.Simmy.Settings;

namespace Web.Common.Simmy.Extensions;

public static class SimmyContextExtensions
{
    public const string ChaosSettings = "ChaosSettings";

    public static Context WithChaosSettings(this Context context, ChaosSettings options)
    {
        context[ChaosSettings] = options;
        return context;
    }

    public static ChaosSettings GetChaosSettings(this Context context) => context.GetSetting<ChaosSettings>(ChaosSettings);

    private static T GetSetting<T>(this Context context, string key)
    {
        if (context.TryGetValue(key, out object setting))
        {
            if (setting is T)
            {
                return (T)setting;
            }
        }
        return default(T);
    }
}

