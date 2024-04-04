using CardDeckStorage.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text;

var builder = Host.CreateApplicationBuilder(args);

//Register appsettings.json file
var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

//Register CardDeckService
builder.Services.AddCardDeckStorage();

using IHost host = builder.Build();

//Example usage
//Getting CardDeckService
var cardDeckStorage = host.Services.GetCardDeckStorage();
Console.OutputEncoding = Encoding.UTF8;

cardDeckStorage.Create("Deck1");
Console.WriteLine(cardDeckStorage.GetByName("Deck1").Value); 

cardDeckStorage.Create("Deck2");
Console.WriteLine(cardDeckStorage.GetByName("Deck2").Value);

Console.WriteLine(string.Join(", ", cardDeckStorage.GetAllCardDeckNames()));
Console.WriteLine();

cardDeckStorage.Shuffle("Deck1");
Console.WriteLine($"Shuffle of deck1 completed");
Console.WriteLine(cardDeckStorage.GetByName("Deck1").Value);
Console.WriteLine(cardDeckStorage.GetByName("Deck2").Value);

