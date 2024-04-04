using System.ComponentModel;

namespace CardDeckStorage.Models;

public enum CardSuit
{
    [Description("♦")]
    Diamonds,

    [Description("♣")]
    Clubs,

    [Description("♥")]
    Hearts,

    [Description("♠")]
    Spades
}
