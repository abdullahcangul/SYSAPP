using System.Collections;
using System.Linq.Expressions;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using SYS.Application.DTOs;
using SYS.Application.Utility;
using SYS.Application.Utility.Result;
using SYS.Domain.Entities;

namespace SYSAPP.Persistance.Services;

public class BaseManager<T> : IBaseService<T> where T : BaseEntity 
{
    private readonly IReadRepository<T> _readRepository;
    private readonly IWriteRepository<T> _writeRepository;
    private readonly IMapper _mapper;

    public BaseManager( IMapper mapper, IReadRepository<T> readRepository, IWriteRepository<T> writeRepository)
    {
       
        _mapper = mapper;
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<T> AddAsync(T dto)
    {
        return await _writeRepository.AddAsync(dto);
    }

    public  void Delete(T dto)
    {
         _writeRepository.Remove(dto);
    }

    public  IEnumerable<T> GetAll()
    {
        return _readRepository.GetAll().ToList();
    }

    public  IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
    {
        var result = _readRepository.GetWhere(predicate);

        return result.ToList();
    }

    public  IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includeString = null,
        bool disableTracking = true)
    {
        var result = _readRepository.GetWhere(predicate, disableTracking);
        return result;
    }
    
    public async Task<T> GetByIdAsync(int id)
    {
        var result = await _readRepository.GetByIdAsync(id);
        return  result;
    }
    public  void Update(T dto)
    {
         _writeRepository.Update(dto);
    }
}