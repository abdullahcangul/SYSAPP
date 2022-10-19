using Application.Repositories;
using Application.Services;
using AutoMapper;
using SYS.Domain.Entities;

namespace SYSAPP.Persistance.Services;

public class DeptManager:BaseManager<Dept>, IDeptService
{
    public DeptManager(IMapper mapper, IReadRepository<Dept> readRepository, IWriteRepository<Dept> writeRepository) : base(mapper, readRepository, writeRepository)
    {
    }
}