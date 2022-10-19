
using System.Configuration;
using Application.Repositories;
using Application.Repositories.DeptRepository;
using Application.Repositories.DuesRepository;
using Application.Repositories.HomeRepository;
using Application.Repositories.OwnerRepository;
using Application.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SYS.Domain.Entities;
using SYS.Persistence.Repositories.DeptRepository;
using SYS.Persistence.Repositories.DuesRepository;
using SYS.Persistence.Repositories.HomeRepository;
using SYS.Persistence.Repositories.OwnerRepository;
using SYSAPP.Persistance.Repositories;
using SYSAPP.Persistance.Services;
using SYSAPP.Persistence.Contexts;
using TodoCleanArch.Persistance.Repositories;

namespace SYSAPP.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection collection)
    {
        collection.AddDbContext<SYSAPPDBContext>(options => options
            .UseNpgsql(Configuration.ConnectionString));
        collection.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
        collection.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        collection.AddTransient(typeof(IBaseService<BaseEntity>), typeof(BaseManager<BaseEntity>));
        collection.AddScoped<IMapper, Mapper>();
        
        collection.AddScoped<IHomeReadRepository, HomeReadRepository>();
        collection.AddScoped<IHomeWriteRepository, HomeWriteRepository>();
        collection.AddScoped<IDeptReadRepository, DeptReadRepository>();
        collection.AddScoped<IDeptWriteRepository, DeptWriteRepository>();
        collection.AddScoped<IDuesReadRepository, DuesReadRepository>();
        collection.AddScoped<IDuesWriteRepository, DuesWriteRepository>();
        collection.AddScoped<IOwnerReadRepository, OwnerReadRepository>();
        collection.AddScoped<IOwnerWriteRepository, OwnerWriteRepository>();
        
        collection.AddScoped<IHomeService, HomeManager>();
        collection.AddScoped<IOwnerService, OwnerManager>();
        collection.AddScoped<IDuesService, DuesManager>();
        collection.AddScoped<IDeptService, DeptManager>();
        
    }
}