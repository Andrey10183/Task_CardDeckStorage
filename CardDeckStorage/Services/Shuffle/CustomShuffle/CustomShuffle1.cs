using CardDeckStorage.Interfaces;
using CardDeckStorage.Models;

namespace CardDeckStorage.Services.Shuffle.CustomShuffle;

public class CustomShuffle1 : IShuffle
{
    public void Shuffle(List<Card> items)
    {
        Random random = new Random();
        int n = items.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var item = items[k].Order;
            items[k].Order = items[n].Order;
            items[n].Order = item;
        }
    }
}
