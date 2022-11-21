using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs;

public class CarDto
{
    public string Name { get; set; } = null!;
    public string Vincode { get; set; } = null!;
    public decimal Price { get; set; }
    
    [Range(1900, 2022)]
    public int Year { get; set; }
    
    [Range(1, int.MaxValue)]
    public int? BrandId { get; set; }
    
    [Range(1, int.MaxValue)]
    public int WarehouseId { get; set; }
}