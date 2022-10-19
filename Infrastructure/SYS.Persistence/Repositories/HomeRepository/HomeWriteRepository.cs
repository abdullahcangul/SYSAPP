using Application.Repositories;
using Application.Repositories.HomeRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistance.Repositories;
using SYSAPP.Persistence.Contexts;

namespace SYS.Persistence.Repositories.HomeRepository;

public class HomeWriteRepository:WriteRepository<Home>,IHomeWriteRepository
{
    public HomeWriteRepository(SYSAPPDBContext context) : base(context)
    {
    }
}