using CardDeckStorage.Errors;
using CardDeckStorage.Interfaces;
using CardDeckStorage.Models;
using CardDeckStorage.Shared;
using CardDeckStorage.Storage;

namespace CardDeckStorage.Repositories;

/// <summary>
/// Repository for CardDecks entries. 
/// You could provide your custom implementation for ICardDeckRepository.
/// For example we can use dbContext to access DB via EF
/// </summary>
public class CardDeckRepository : ICardDeckRepository
{
    public Result Create(string name)
    {
        var deckResult = GetByName(name);

        if (deckResult.IsSuccess)
        {
            return CardDeckErrors.NameAlreadyExis;
        }

        DecksStorage.Add(name);

        return Result.Success();
    }

    public Result Delete(string name)
    {
        var deletedDeckResult = GetByName(name);

        if (deletedDeckResult.IsFailure) 
        {
            return deletedDeckResult;
        }

        DecksStorage.Remove(deletedDeckResult.Value!);

        return Result.Success();
    }

    public List<CardDeck> GetAll()
    {
        return DecksStorage.GetAll();
    }

    public Result<CardDeck> GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return CardDeckErrors.InvalidInputParameter;
        }

        var deck = DecksStorage
            .GetAll()
            .Where(x => x.Name == name)
            .FirstOrDefault();

        if (deck == null)
        {
            return CardDeckErrors.NameNotExis;
        }

        return deck;
    }

    public Result Update(CardDeck cardDeck)
    {
        var updatedDeckResult = GetByName(cardDeck.Name);

        if (updatedDeckResult.IsFailure)
        {
            return updatedDeckResult;
        }

        updatedDeckResult.Value!.Cards = cardDeck.Cards;

        return Result.Success();
    }
}
