using AutoMapper;

using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Mapping;

public class WarehouseProfile: Profile
{
    public WarehouseProfile()
    {
        CreateMap<Warehouse, WarehouseDto>();
        CreateMap<WarehouseDto, Warehouse>();
    }
}