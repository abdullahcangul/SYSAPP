using Application.Repositories.OwnerRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistance.Repositories;
using SYSAPP.Persistence.Contexts;

namespace SYS.Persistence.Repositories.OwnerRepository;

public class OwnerWriteRepository:WriteRepository<Owner>,IOwnerWriteRepository
{
    public OwnerWriteRepository(SYSAPPDBContext context) : base(context)
    {
    }
}