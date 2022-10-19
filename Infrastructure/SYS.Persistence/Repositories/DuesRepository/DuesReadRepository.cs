using Application.Repositories.DuesRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistence.Contexts;
using TodoCleanArch.Persistance.Repositories;

namespace SYS.Persistence.Repositories.DuesRepository;

public class DuesReadRepository:ReadRepository<Dues>,IDuesReadRepository
{
    public DuesReadRepository(SYSAPPDBContext context) : base(context)
    {
    }
}