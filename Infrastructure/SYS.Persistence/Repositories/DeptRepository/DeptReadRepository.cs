using Application.Repositories.DeptRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistence.Contexts;
using TodoCleanArch.Persistance.Repositories;

namespace SYS.Persistence.Repositories.DeptRepository;

public class DeptReadRepository:ReadRepository<Dept>,IDeptReadRepository
{
    public DeptReadRepository(SYSAPPDBContext context) : base(context)
    {
    }
}