namespace StockApp.DataAcess.Entities;

public class Box
{
    public int Id { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Depth { get; set; }
    
    public double Weight { get; set; }
    public int PalleteId { get; set; }
    public virtual Pallete Pallete { get; set; }
    public DateOnly DateOfManufacture { get; set; }
    
}