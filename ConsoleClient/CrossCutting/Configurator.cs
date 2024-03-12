namespace ConsoleClient.CrossCutting;

class Configurator : IConfigurator
{
    private Dictionary<string, object> _items;

    public Configurator()
    {
        _items = new Dictionary<string, object>();
    }

    public TValue Get<TValue>(string key, TValue defaultValue = default)
    {
        return (TValue)_items[key];
    }

    public void Set<TValue>(string key, TValue value)
    {
        _items[key] = value;
    }
}