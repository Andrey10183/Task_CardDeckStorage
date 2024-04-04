using System.ComponentModel;

namespace CardDeckStorage.Models;

public enum CardItem
{
    [Description("2")]
    Two,

    [Description("3")]
    Three,

    [Description("4")]
    Four,

    [Description("5")]
    Five,

    [Description("6")]
    Six,

    [Description("7")]
    Seven,

    [Description("8")]
    Eight,

    [Description("9")]
    Nine,

    [Description("6")]
    Ten,

    [Description("J")]
    Jack,

    [Description("Q")]
    Queen,

    [Description("K")]
    King,

    [Description("A")]
    Ace,
}
