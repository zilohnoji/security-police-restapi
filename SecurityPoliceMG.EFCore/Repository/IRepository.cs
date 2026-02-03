namespace SecurityPoliceMG.EFCore.Repository;

public interface IRepository<T>
{
    T Create(T entity);
    
    List<T> FindAll();

    T Update(T entity);
}