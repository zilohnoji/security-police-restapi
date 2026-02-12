using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public sealed class UserRepositoryImpl(AppDbContext context) : GenericRepository<User>(context)
{
    public User? FindByEmail(string email)
    {
        return DataSet
            .Include(u => u.Person)
            .FirstOrDefault(u => u.Email.Equals(email));
    }

    public User? FindByRefreshToken(string refreshToken)
    {
        return DataSet
            .Include(u => u.Person)
            .FirstOrDefault(u => u.RefreshToken.Equals(refreshToken));
    }
}