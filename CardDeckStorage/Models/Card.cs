namespace CardDeckStorage.Models;

public class Card
{
    public int Id { get; set; }

    public int CardDeckId { get; set; }

    public int Order { get; set; }

    public CardSuit CardSuit { get; set; }

    public CardItem CardItem { get; set; }
}
