using Application.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SYS.Domain.Entities;
using SYSAPP.Persistence.Contexts;

namespace SYSAPP.Persistance.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    readonly private SYSAPPDBContext _context;
    public WriteRepository(SYSAPPDBContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    public async Task<T> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.Entity;
    }
    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }
    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        var result = entityEntry.State == EntityState.Deleted;
        return result;
    }
    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }
    public async Task<bool> RemoveAsync(int id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
        return Remove(model);
    }
    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        var result = entityEntry.State == EntityState.Modified;
        return result;
    }
    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();


}