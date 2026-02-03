using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Repository;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dataSet;

    public GenericRepository(AppDbContext context)
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

    public T Update(T entity)
    {
        return _dataSet.Update(entity).Entity;
    }
}