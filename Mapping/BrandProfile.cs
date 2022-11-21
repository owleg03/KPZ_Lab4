using AutoMapper;

using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Mapping;

public class BrandProfile: Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandDto>();
        CreateMap<BrandDto, Brand>();
    }
}