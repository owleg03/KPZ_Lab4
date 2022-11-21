namespace WebAPI.Models;

public class Warehouse
{
    public int Id { get; set; }
    public string Adress { get; set; } = null!;
    
    // Navigational
    public ICollection<Car> Cars { get; set; } = null!;
}