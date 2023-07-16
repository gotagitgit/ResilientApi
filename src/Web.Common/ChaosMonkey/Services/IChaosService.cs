namespace Web.Common.ChaosMonkey.Services;

public interface IChaosService
{
    void InjectChaosToRequest(HttpRequestMessage request);
}