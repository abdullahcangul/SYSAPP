using Application.Repositories;
using Application.Services;
using AutoMapper;
using SYS.Domain.Entities;

namespace SYSAPP.Persistance.Services;

public class DuesManager:BaseManager<Dues>, IDuesService
{
    public DuesManager(IMapper mapper, IReadRepository<Dues> readRepository, IWriteRepository<Dues> writeRepository) : base(mapper, readRepository, writeRepository)
    {
    }
}