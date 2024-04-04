using CardDeckStorage.Errors;
using CardDeckStorage.Interfaces;
using CardDeckStorage.Models;
using CardDeckStorage.Shared;

namespace CardDeckStorage.Services.CardDeckServces;

/// <summary>
/// This is main Service. It rely on CardDeckRepository and Options class
/// </summary>
public class CardDeckService : ICardDeckService
{
    private readonly ICardDeckRepository _cardDeckRepository;
    private readonly CardDeckOptions _options;

    public CardDeckService(
        ICardDeckRepository cardDeckRepository,
        CardDeckOptions options)
    {
        _cardDeckRepository = cardDeckRepository;
        _options = options;
    }

    public Result Create(string name)
    {
        return _cardDeckRepository.Create(name);
    }

    public Result DeleteByName(string name)
    {
        return _cardDeckRepository.Delete(name);
    }

    public List<string> GetAllCardDeckNames()
    {
        var decks = _cardDeckRepository.GetAll();

        return decks.Select(x => x.Name).ToList();
    }

    public Result<CardDeck> GetByName(string name)
    {
        var deck = _cardDeckRepository.GetByName(name);

        return deck;
    }

    public Result Shuffle(string name)
    {
        var deck = _cardDeckRepository.GetByName(name);

        if (deck.IsFailure)
        {
            return deck;
        }

        var shuffle = _options.GetShuffle();
        shuffle.Shuffle(deck.Value!.Cards);

        return Result.Success();
    }

    /// <summary>
    /// Additional overload if we want to pass external method for card shuffle
    /// </summary>
    /// <param name="name"></param>
    /// <param name="shuffleMethod"></param>
    /// <returns></returns>
    public Result Shuffle(string name, Action<List<Card>> shuffleMethod)
    {
        var deck = _cardDeckRepository.GetByName(name);

        if (deck.IsFailure)
        {
            return deck;
        }

        shuffleMethod(deck.Value!.Cards);

        return Result.Success();
    }
}
