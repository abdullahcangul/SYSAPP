using System.Linq.Expressions;
using SYS.Application.DTOs;
using SYS.Application.Utility.Result;
using SYS.Domain.Entities;

namespace Application.Services;

public interface IBaseService<T> where T : BaseEntity 
{
    IEnumerable<T> GetAll();
    IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

    IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<string>? includeString = null,
        bool disableTracking = true
    );

    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}