using Application.Repositories;
using Application.Repositories.HomeRepository;
using SYS.Domain.Entities;
using SYSAPP.Persistence.Contexts;
using TodoCleanArch.Persistance.Repositories;

namespace SYS.Persistence.Repositories.HomeRepository;

public class HomeReadRepository:ReadRepository<Home>,IHomeReadRepository
{
    public HomeReadRepository(SYSAPPDBContext context) : base(context)
    {
    }
}