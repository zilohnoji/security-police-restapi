using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;
using SecurityPoliceMG.EFCore.Repository.Base;

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

    public Page<T> FindAll<TKey>(Expression<Func<T, TKey>> sortRule, Pageable<T> pageable, string sortDirection = "")
    {
        var query = string.IsNullOrEmpty(sortDirection)
            ? DataSet.OrderBy(sortRule)
            : DataSet.OrderByDescending(sortRule);

        var entities = query
            .AsNoTracking()
            .Skip((pageable.Page - 1) * pageable.PageSize)
            .Take(pageable.PageSize);

        return Page<T>.Of(entities.ToList(), pageable);
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