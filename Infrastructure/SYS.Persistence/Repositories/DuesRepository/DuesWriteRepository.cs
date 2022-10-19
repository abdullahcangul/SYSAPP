using Application.Repositories.DuesRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistance.Repositories;
using SYSAPP.Persistence.Contexts;

namespace SYS.Persistence.Repositories.DuesRepository;

public class DuesWriteRepository:WriteRepository<Dues>,IDuesWriteRepository
{
    public DuesWriteRepository(SYSAPPDBContext context) : base(context)
    {
    }
}