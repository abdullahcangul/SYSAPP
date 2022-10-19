
using Microsoft.EntityFrameworkCore;
using SYS.Domain.Entities;

namespace Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}