using CardDeckStorage.Models;
using CardDeckStorage.Shared;

namespace CardDeckStorage.Interfaces;

public interface ICardDeckService
{
    public Result Create(string cardDeckName);

    public Result Shuffle(string name);

    public Result Shuffle(string name, Action<List<Card>> shuffleMethod);

    public Result DeleteByName(string name);

    public List<string> GetAllCardDeckNames();

    public Result<CardDeck> GetByName(string name);
}
