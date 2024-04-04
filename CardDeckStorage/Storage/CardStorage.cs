using CardDeckStorage.Models;

namespace CardDeckStorage.Storage;

/// <summary>
/// This class present Cards table behavior imitation
/// </summary>
public static class CardStorage
{
    private static int _currentCardId = 0;

    private static List<Card> _cards = new();

    public static void Add(Card card)
    {
        card.Id = _currentCardId++;
        _cards.Add(card);
    }

    public static List<Card> GetAll()
    {
        return _cards;
    }

    public static void Remove(int cardDeckId) 
    {
        _cards.RemoveAll(x => x.CardDeckId == cardDeckId);
    }
}
