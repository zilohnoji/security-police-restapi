using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Repository;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DataSet;

    public GenericRepository(AppDbContext context)
    {
        Context = context;
        DataSet = context.Set<T>();
    }

    public T Create(T entity)
    {
        entity = DataSet.Add(entity).Entity;
        Context.SaveChanges();
        return entity;
    }

    public List<T> FindAll()
    {
        return DataSet.ToList();
    }

    public T Update(T entity)
    {
        return DataSet.Update(entity).Entity;
    }
}