namespace StockApp.DataAcess.Entities;

public class Pallete
{
    public int Id { get; set; }
    
    public double Height { get; set; }
    public double Width { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }
    public DateOnly ExpireDate => Boxes.Min(b => b.DateOfManufacture);

    public double FullWeight => Boxes.Sum(b => b.Height * b.Width * b.Depth) + Height * Width * Depth;

    public virtual ICollection<Box> Boxes { get; set; } = new List<Box>();
    
    public override string ToString()
    {
        return $"Id: {Id}," +
               $" Height: {Height}," +
               $" Width: {Width}," +
               $" Depth: {Depth}," +
               $" Weight: {FullWeight}," + 
               $" ExpireDate: {ExpireDate}";
    }
}