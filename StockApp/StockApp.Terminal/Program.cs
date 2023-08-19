// See https://aka.ms/new-console-template for more information

using StockApp.DataAcess;
using StockApp.DataAcess.Entities;

Console.WriteLine("Hello, World!");

using var db = new MasterDbContext();


var p1 = new Pallete()
{
    Height = 11,
    Width = 21,
    Depth = 31,
};

var p2 = new Pallete()
{
    Height = 12,
    Width = 22,
    Depth = 32,
};

db.Palletes.AddRange(p1, p2);

db.SaveChangesAsync();

var bb = new Box()
{
    Height = 1,
    Width = 2,
    Depth = 2,
    PalleteId = 1
};

db.Boxes.Add(bb);
db.SaveChanges();

var boxes = db.Boxes.ToList();
var palletes = db.Palletes.ToList();
Console.WriteLine();