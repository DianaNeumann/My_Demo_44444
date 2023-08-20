using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Domain.Extensions;
using StockApp.Domain.Services.Interfaces;
using StockApp.Terminal.Generations;


var serviceProvider = new ServiceCollection()
    .AddApplicationScopes()
    .BuildServiceProvider();

var cancellationToken = new CancellationToken();

var palleteService = serviceProvider.GetService<IPalleteService>();
var boxService = serviceProvider.GetService<IBoxService>();

await StartDataGenerator.Generate(cancellationToken); ;

Console.WriteLine(boxService.GetExpirationDateByIdAsync(1, cancellationToken));