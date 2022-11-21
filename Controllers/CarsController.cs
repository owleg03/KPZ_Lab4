using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CarsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Cars
    [HttpGet]
    public async Task<IEnumerable<CarDto>> GetCars()
    {
        return await _context.Cars
            .Select(c => _mapper.Map<Car, CarDto>(c))
            .ToListAsync();
    }

    // GET: api/Cars/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CarDto>> GetCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        return _mapper.Map<Car, CarDto>(car);
    }

    // PUT: api/Cars/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, CarDto carDto)
    {
        var car = await _context.Cars.FindAsync(id);

        if (car == null)
        {
            return BadRequest();
        }

        car.Name = carDto.Name;
        car.Year = carDto.Year;
        car.Price = carDto.Price;
        car.Vincode = carDto.Vincode;
        car.BrandId = carDto.BrandId;
        car.WarehouseId = carDto.WarehouseId;

        await _context.SaveChangesAsync();

        return Ok($"Car {carDto.Name} was edited successfully.");
    }

    // POST: api/Cars
    [HttpPost]
    public async Task<ActionResult> PostCar(CarDto carDto)
    {
        var car = _mapper.Map<CarDto, Car>(carDto);
        
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        return Ok($"Car {car.Name} was created succesfully.");
    }

    // DELETE: api/Cars/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();

        return Ok($"Car {car.Name} was deleted successfully.");
    }
}