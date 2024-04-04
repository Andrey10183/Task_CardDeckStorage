using CardDeckStorage.Shared;

namespace CardDeckStorage.Errors;

/// <summary>
/// This class contain all possible listed errors that CardDeckService could provide
/// </summary>
public class CardDeckErrors
{
    public static readonly Error NameNotExis = new(
        "CardDeck.NameNotExis",
        "Can't find entry with specified name");

    public static readonly Error NameAlreadyExis = new(
        "CardDeck.NameAlreadyExis",
        "Try to create entry that already exist");

    public static readonly Error InvalidInputParameter = new(
        "CardDeck.InvalidInputParameter",
        "Input parameter can't be null or empty");
}
