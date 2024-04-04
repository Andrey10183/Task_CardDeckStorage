using CardDeckStorage.Interfaces;
using CardDeckStorage.Services.Shuffle;
using Microsoft.Extensions.Configuration;

namespace CardDeckStorage.Services.CardDeckServces;


/// <summary>
/// This is configuration class for CardDeckService
/// If we want to have more setup and config for our service
/// We can expand this
/// </summary>
public class CardDeckOptions
{
    private readonly IConfiguration _configuration;
    private readonly ShuffleProvider _shuffleProvider;

    private readonly string _shuffleName = string.Empty;

    public CardDeckOptions(IConfiguration configuration, ShuffleProvider shuffleProvider)
    {
        _configuration = configuration;
        _shuffleProvider = shuffleProvider;

        _shuffleName = _configuration.GetSection("Shuffle:ShuffleMethod").Value ??
            throw new ArgumentException("Shuffle algorithm name not provided in appsettings file");
    }

    public IShuffle GetShuffle()
    {
        return _shuffleProvider.GetShuffleInstance(_shuffleName)!;
    }
}
