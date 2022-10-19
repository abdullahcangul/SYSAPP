 
using SYS.Domain.Entities;

namespace Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T model);
    Task<bool> AddRangeAsync(List<T> datas);
    bool Remove(T model);
    bool RemoveRange(List<T> datas);
    Task<bool> RemoveAsync(int id);
    bool Update(T model);

    Task<int> SaveAsync();
    
}