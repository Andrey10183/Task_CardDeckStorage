using CardDeckStorage.Interfaces;
using CardDeckStorage.Models;

namespace CardDeckStorage.Services.Shuffle.CustomShuffle;

public class CustomShuffle2 : IShuffle
{
    public void Shuffle(List<Card> items)
    {
        items = items
            .OrderBy(x => Guid.NewGuid())
            .ToList();

        foreach (var item in items)
            item.Order = items.IndexOf(item);
    }
}
