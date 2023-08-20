using Microsoft.Extensions.DependencyInjection;
using StockApp.Domain.Services.Implementations;
using StockApp.Domain.Services.Interfaces;

namespace StockApp.Domain.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationScopes(this IServiceCollection collection)
    {
        collection.AddScoped<IBoxService, BoxService>();
        collection.AddScoped<IPalleteService, PalleteService>();

        return collection;
    }
}