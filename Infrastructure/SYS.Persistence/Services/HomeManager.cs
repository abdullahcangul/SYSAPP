using Application.Repositories;
using Application.Services;
using AutoMapper;
using SYS.Application.DTOs.Home;
using SYS.Domain.Entities;

namespace SYSAPP.Persistance.Services;

public class HomeManager:BaseManager<Home>, IHomeService
{
    public HomeManager(IMapper mapper, IReadRepository<Home> readRepository, IWriteRepository<Home> writeRepository) : base(mapper, readRepository, writeRepository)
    {
    }
}