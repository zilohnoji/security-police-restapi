
using SecurityPoliceMG.Domain.Entity;

namespace SecurityPoliceMG.Repository;

public interface IPersonRepository
{
    Person Create(Person entity);
    List<Person> FindAll();
}