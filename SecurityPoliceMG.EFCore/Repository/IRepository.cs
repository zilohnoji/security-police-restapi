using SecurityPoliceMG.EFCore.Repository.Base;

namespace SecurityPoliceMG.EFCore.Repository;

public interface IRepository<T>
{
    T Create(T entity);

    Page<T> FindAll(Pageable pageable, IQueryable<T> query);

    T Update(T entity);

    T FindById(Guid id, IQueryable<T> query);
}