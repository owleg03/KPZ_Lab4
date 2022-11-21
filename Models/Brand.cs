namespace WebAPI.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    
    // Navigational
    public ICollection<Car> Cars { get; set; } = null!;
}