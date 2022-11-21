using AutoMapper;

using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Mapping;

public class CarProfile: Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
    }
}