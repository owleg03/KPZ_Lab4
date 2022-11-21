namespace WebAPI.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Vincode { get; set; } = null!;
    public decimal Price { get; set; }
    public int Year { get; set; }
    public int? OrderId { get; set; }
    public int? BrandId { get; set; }
    public int WarehouseId { get; set; }

    // Navigational
    public Brand? Brand { get; set; }
    public Warehouse Warehouse { get; set; } = null!;
}