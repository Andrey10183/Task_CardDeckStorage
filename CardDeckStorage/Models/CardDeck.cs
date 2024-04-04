using CardDeckStorage.Extensions;
using System.Text;

namespace CardDeckStorage.Models;

public class CardDeck
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Card> Cards { get; set; } = new ();

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Name:{Name}\n");

        for (int i = 0; i < Cards.Count; i++) 
        {
            sb.Append($"{Cards[i].CardSuit.GetEnumDescription()}{Cards[i].CardItem.GetEnumDescription()} ");
            if ((i+1) % 13 == 0) sb.Append("\n");
        }

        return sb.ToString();
    }
}
