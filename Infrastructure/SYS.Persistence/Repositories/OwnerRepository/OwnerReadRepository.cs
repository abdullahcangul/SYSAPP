using Application.Repositories;
using Application.Repositories.OwnerRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistance.Repositories;
using SYSAPP.Persistence.Contexts;
using TodoCleanArch.Persistance.Repositories;

namespace SYS.Persistence.Repositories.OwnerRepository;

public class OwnerReadRepository:ReadRepository<Owner>,IOwnerReadRepository
{
    public OwnerReadRepository(SYSAPPDBContext context) : base(context)
    {
    }
}