using Application.Repositories.DeptRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistance.Repositories;
using SYSAPP.Persistence.Contexts;

namespace SYS.Persistence.Repositories.DeptRepository;

public class DeptWriteRepository:WriteRepository<Dept>,IDeptWriteRepository
{
    public DeptWriteRepository(SYSAPPDBContext context) : base(context)
    {
    }
}