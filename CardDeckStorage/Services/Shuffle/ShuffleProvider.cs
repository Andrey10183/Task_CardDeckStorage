using CardDeckStorage.Interfaces;
using CardDeckStorage.Services.Shuffle.CustomShuffle;
using Microsoft.Extensions.Configuration;

namespace CardDeckStorage.Services.Shuffle;

public class ShuffleProvider
{
    private readonly IConfiguration? _configuration;

    private Dictionary<string, Type> _shuffleTypes = new Dictionary<string, Type>();

    /// <summary>
    /// Here we can expand or shuffle methods
    /// </summary>
    /// <param name="configuration"></param>
    public ShuffleProvider(IConfiguration configuration)
    {
        _shuffleTypes[nameof(CustomShuffle1)] = typeof(CustomShuffle1);
        _shuffleTypes[nameof(CustomShuffle2)] = typeof(CustomShuffle2);
    }

    public IShuffle? GetShuffleInstance(string name)
    {
        if (_shuffleTypes.ContainsKey(name))
        {
            Type type = _shuffleTypes[name];
            return Activator.CreateInstance(type) as IShuffle;
        }
        else
        {
            throw new ArgumentException($"No type found for name: {name}");
        }
    }
}
