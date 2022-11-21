using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public BrandsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Brands
    [HttpGet]
    public async Task<IEnumerable<BrandDto>> GetBrands()
    {
        return await _context.Brands
            .Select(b => _mapper.Map<Brand, BrandDto>(b))
            .ToListAsync();
    }

    // GET: api/Brands/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BrandDto>> GetBrand(int id)
    {
        var brand = await _context.Brands.FindAsync(id);

        if (brand == null)
        {
            return NotFound();
        }

        return _mapper.Map<Brand, BrandDto>(brand);
    }

    // PUT: api/Brands/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBrand(int id, BrandDto brandDto)
    {
        var brand = await _context.Brands.FindAsync(id);

        if (brand == null)
        {
            return NotFound();
        }

        brand.Name = brandDto.Name;
        brand.Description = brandDto.Description;
        
        await _context.SaveChangesAsync();

        return Ok($"Brand {brand.Name} was edited succesfully.");
    }

    // POST: api/Brands
    [HttpPost]
    public async Task<IActionResult> PostBrand(BrandDto brandDto)
    {
        var brand = _mapper.Map<BrandDto, Brand>(brandDto);
        
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();

        return Ok($"Brand {brand.Name} was added successfully");
    }

    // DELETE: api/Brands/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();

        return Ok($"Brand {brand.Name} was deleted successfully");
    }
}