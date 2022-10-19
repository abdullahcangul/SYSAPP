using AutoMapper;
using SYS.Application.DTOs.Home;
using SYS.Domain.Entities;

namespace SYS.Application.Mapper;

public class ApplicationMappingProfile: Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<HomeAddDto, Home>().ReverseMap();
        CreateMap<HomeUpdateDto, Home>().ReverseMap();
        CreateMap<HomeListDto, Home>().ReverseMap();
    }
}