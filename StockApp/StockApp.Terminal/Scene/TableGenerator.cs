using Spectre.Console;
using StockApp.DataAcess.Entities;

namespace StockApp.Terminal.Scene;

public static class TableGenerator
{

    public static Table Generate(string tableName, IEnumerable<Pallete> palletes)
    {
        var table = new Table()
            .Border(TableBorder.HeavyEdge)
            .BorderColor(Color.Green4)
            .LeftAligned()
            .AddColumn(new TableColumn(tableName + ":"));
        
        foreach (var pallete in palletes)
        {
            table.AddRow(pallete.ToString());
        }

        return table;
    }
        
}