// See https://aka.ms/new-console-template for more information

using StockApp.DataAcess;
using StockApp.DataAcess.Entities;

Console.WriteLine("Hello, World!");

using var db  = new MasterDbContext();

db.Boxes.Add(new Box()
{
    Width = 1,
    Height = 2,
    Depth = 3
});

db.SaveChanges();

foreach(var a in db.Boxes){
    Console.WriteLine(a.Id);
}