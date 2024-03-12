using ConsoleClient;

namespace UnitTests.Mocks;

public class ConfigMock : IConfigurator
{
    public int AgeTreshold { get; set; } = 18;
    public TValue Get<TValue>(string key)
    {
        return (TValue)(object)AgeTreshold;
    }

    public void Set<TValue>(string key, TValue value)
    {
    }
}