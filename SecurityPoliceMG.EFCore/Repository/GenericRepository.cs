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

    public T Create(T entity)
    {
        entity = DataSet.Add(entity).Entity;
        _context.SaveChanges();
        return entity;
    }

    public Page<T> FindAll(Pageable pageable, IQueryable<T>? customQuery = null)
    {
        var sortRule = MakeExpressionByOrderTerm(pageable.OrderTerm);

        IQueryable<T> query = customQuery ?? DataSet;
        var total = query.Count();

        if (!string.IsNullOrEmpty(pageable.Sort) && pageable.Sort.Equals("desc", StringComparison.OrdinalIgnoreCase))
        {
            query = query.OrderByDescending(sortRule);
        }
        else
        {
            query = query.OrderBy(sortRule);
        }

        var entities = query
            .AsNoTracking()
            .Skip((pageable.Page - 1) * pageable.PageSize)
            .Take(pageable.PageSize)
            .ToList();

        return Page<T>.Of(entities, total, pageable);
    }

    public T Update(T entity)
    {
        var res = DataSet.Update(entity).Entity;
        _context.SaveChanges();
        return res;
    }

    public T FindById(Guid id, IQueryable<T>? query = null)
    {
        query = query ?? DataSet;
        return query.FirstOrDefault(t => t.Id.Equals(id));
    }

    private static Expression<Func<T, object>> MakeExpressionByOrderTerm(string orderTerm)
    {
        var parameter = Expression.Parameter(typeof(T), "t");
        var propertyInfo = typeof(T).GetProperties()
            .FirstOrDefault(p => string.Equals(p.Name, orderTerm, StringComparison.OrdinalIgnoreCase));

        if (propertyInfo == null)
        {
            throw new ArgumentException($"The property {orderTerm} not found");
        }

        var property = Expression.Property(parameter, propertyInfo);

        var conversion = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(conversion, parameter);
    }
}