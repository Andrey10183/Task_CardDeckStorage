using CardDeckStorage.Models;

namespace CardDeckStorage.Interfaces;

public interface IShuffle
{
    public void Shuffle(List<Card> items);
}
