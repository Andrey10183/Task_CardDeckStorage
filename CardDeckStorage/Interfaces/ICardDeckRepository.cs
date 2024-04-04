using CardDeckStorage.Models;
using CardDeckStorage.Shared;

namespace CardDeckStorage.Interfaces;

public interface ICardDeckRepository
{
    public List<CardDeck> GetAll();

    public Result<CardDeck> GetByName(string name);

    public Result Create(string name);

    public Result Update(CardDeck cardDeck);

    public Result Delete(string name);
}
