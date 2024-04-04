using CardDeckStorage.Interfaces;
using CardDeckStorage.Repositories;
using CardDeckStorage.Services.CardDeckServces;
using CardDeckStorage.Services.Shuffle;
using Microsoft.Extensions.DependencyInjection;

namespace CardDeckStorage.Extensions;

public static class CardDeckDiExtensions
{
    public static IServiceCollection AddCardDeckStorage(this IServiceCollection services)
    {
        services.AddScoped<ICardDeckRepository, CardDeckRepository>();
        services.AddScoped<ICardDeckService, CardDeckService>();
        services.AddScoped<CardDeckOptions>();
        services.AddScoped<ShuffleProvider>();

        return services;
    }

    public static ICardDeckService GetCardDeckStorage(this IServiceProvider provider) =>
        provider.GetRequiredService<ICardDeckService>();
}
