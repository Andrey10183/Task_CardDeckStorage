using CardDeckStorage.Extensions;
using CardDeckStorage.Models;

namespace CardDeckStorage.Storage;

/// <summary>
/// This class present CardDecks table behavior imitation
/// </summary>
public static class DecksStorage
{
    private static int _currentDeckId = 0;

    private static List<CardDeck> _cardDecks = new();

    public static void Add(string name)
    {
        var suits = EnumUtil.GetValues<CardSuit>();
        var items = EnumUtil.GetValues<CardItem>();

        var order = 0;
        foreach (var suit in suits)
            foreach (var item in items)
            {
                var card = new Card()
                {
                    CardSuit = suit,
                    CardItem = item,
                    CardDeckId = _currentDeckId,
                    Order = order++,
                };

                CardStorage.Add(card);
            }

        var cardDeck = new CardDeck() { Id = _currentDeckId, Name = name};

        _cardDecks.Add(cardDeck);
        _currentDeckId++;
    }

    public static List<CardDeck> GetAll()
    {
        var cards = CardStorage.GetAll().GroupBy(x => x.CardDeckId);

        var cardDecks = _cardDecks
            .Select(x => new CardDeck()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cards = cards.First(gr => gr.Key == x.Id).OrderBy(or => or.Order).ToList(),
                })
            .ToList();

        return cardDecks;
    }

    public static void Remove(CardDeck cardDeck)
    {
        CardStorage.Remove(cardDeck.Id);
        _cardDecks.RemoveAll(x => x.Id == cardDeck.Id);
    }
}
