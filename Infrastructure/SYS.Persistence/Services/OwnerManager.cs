using Application.Repositories;
using Application.Services;
using AutoMapper;
using SYS.Domain.Entities;

namespace SYSAPP.Persistance.Services;

public class OwnerManager:BaseManager<Owner>, IOwnerService
{
    public OwnerManager(IMapper mapper, IReadRepository<Owner> readRepository, IWriteRepository<Owner> writeRepository) : base(mapper, readRepository, writeRepository)
    {
    }
}