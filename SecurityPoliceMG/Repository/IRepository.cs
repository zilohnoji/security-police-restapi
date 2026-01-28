using SecurityPoliceMG.Domain.Entity;

namespace SecurityPoliceMG.Repository;

public interface IRepository<T> where T : BaseEntity
{
    T Create(T entity);
    List<T> FindAll();
}