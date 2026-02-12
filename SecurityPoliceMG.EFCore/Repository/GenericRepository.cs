using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Repository;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    protected readonly DbSet<T> DataSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        DataSet = context.Set<T>();
    }

    public virtual T Create(T entity)
    {
        entity = DataSet.Add(entity).Entity;
        _context.SaveChanges();
        return entity;
    }

    public virtual List<T> FindAll()
    {
        return DataSet.ToList();
    }

    public virtual T Update(T entity)
    {
        var res = DataSet.Update(entity).Entity;
        _context.SaveChanges();
        return res;
    }

    public virtual T FindById(Guid id)
    {
        return DataSet.FirstOrDefault(t => t.Id.Equals(id)) ??
               throw new ArgumentException($"Not found entity with ID {id}");
    }
}