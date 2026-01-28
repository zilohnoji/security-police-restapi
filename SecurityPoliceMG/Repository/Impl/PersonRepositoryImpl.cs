using SecurityPoliceMG.Domain.Entity;
using SecurityPoliceMG.Domain.Entity.Context;

namespace SecurityPoliceMG.Repository.Impl;

public sealed class PersonRepositoryImpl : IPersonRepository
{
    private readonly AppDatabaseContext _context;

    public PersonRepositoryImpl(AppDatabaseContext context)
    {
        _context = context;
    }

    public Person Create(Person entity)
    {
        entity = _context.Persons.Add(entity).Entity;
        _context.SaveChanges();
        return entity;
    }

    public List<Person> FindAll()
    {
        return _context.Persons.ToList();
    }
    
}