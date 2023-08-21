using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using StockApp.Domain.Extensions;
using StockApp.Domain.Services.Interfaces;
using StockApp.Terminal.Generations;
using StockApp.Terminal.Scene;


var serviceProvider = new ServiceCollection()
    .AddApplicationScopes()
    .BuildServiceProvider();

var cancellationToken = new CancellationToken();

var palleteService = serviceProvider.GetService<IPalleteService>();
await StartDataGenerator.Generate(cancellationToken);

var expiredPalletes = palleteService.GetExpiredPalletes();
var expiredPalletsTable = TableGenerator.Generate("Expired Pallets", expiredPalletes);
AnsiConsole.Write(expiredPalletsTable);

var nonExpiredPalletes = palleteService.GetNonExpiredPalletes();
var nonExpiredPalletsTable = TableGenerator.Generate("Non-expired Pallets", nonExpiredPalletes);
AnsiConsole.Write(nonExpiredPalletsTable);

var palletes = palleteService.GetAllPalletes();
var palletesTable = TableGenerator.Generate("All Palletes", palletes);
AnsiConsole.Write(palletesTable);







