using System.Reflection;
using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SYS.Application.Mapper;

namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddAutoMapper(Assembly.GetExecutingAssembly());
        collection.AddMediatR(typeof(ServiceRegistration));
       
        
        #region Configure Mapper
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<ApplicationMappingProfile>();
        });
        var mapper = config.CreateMapper();
        #endregion

    }
}