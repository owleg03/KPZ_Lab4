using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehousesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public WarehousesController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Warehouses
    [HttpGet]
    public async Task<IEnumerable<WarehouseDto>> GetWarehouses()
    {
        return await _context.Warehouses
            .Select(w => _mapper.Map<Warehouse, WarehouseDto>(w))
            .ToListAsync();
    }

    // GET: api/Warehouses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WarehouseDto>> GetWarehouse(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);

        if (warehouse == null)
        {
            return NotFound();
        }

        return _mapper.Map<Warehouse, WarehouseDto>(warehouse);
    }

    // PUT: api/Warehouses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWarehouse(int id, WarehouseDto warehouseDto)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);

        if (warehouse == null)
        {
            return NotFound();
        }

        warehouse.Adress = warehouseDto.Adress;
        
        await _context.SaveChangesAsync();

        return Ok($"Warehouse at {warehouse.Adress} was edited succesfully.");
    }

    // POST: api/Warehouses
    [HttpPost]
    public async Task<ActionResult> PostWarehouse(WarehouseDto warehouseDto)
    {
        var warehouse = _mapper.Map<WarehouseDto, Warehouse>(warehouseDto);
        
        _context.Warehouses.Add(warehouse);
        await _context.SaveChangesAsync();

        return Ok($"Warehouse at {warehouse.Adress} was created succesfully.");
    }

    // DELETE: api/Warehouses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWarehouse(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);
        if (warehouse == null)
        {
            return NotFound();
        }

        _context.Warehouses.Remove(warehouse);
        await _context.SaveChangesAsync();

        return Ok($"Warehouse at {warehouse.Adress} was deleted succesfully.");
    }
}