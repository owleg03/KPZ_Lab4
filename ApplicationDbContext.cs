using Microsoft.EntityFrameworkCore;

using WebAPI.Models;

namespace WebAPI;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options): base(options) { }

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Warehouse> Warehouses { get; set; } = null!;
}