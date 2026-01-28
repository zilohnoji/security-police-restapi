using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.Domain.Entity.Context;

namespace SecurityPoliceMG.Repository;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDatabaseContext _context;
    private readonly DbSet<T> _dataSet;
    
    public GenericRepository(AppDatabaseContext context)
    {
        _context = context;
        _dataSet = context.Set<T>();
    }

    public T Create(T entity)
    {
        entity = _dataSet.Add(entity).Entity;
        _context.SaveChanges();
        return entity;
    }

    public List<T> FindAll()
    {
        return _dataSet.ToList();
    }
}