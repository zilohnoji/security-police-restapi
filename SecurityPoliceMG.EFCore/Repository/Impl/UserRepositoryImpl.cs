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
            .Include(u => u.RefreshToken)
            .FirstOrDefault(u => u.Email.Equals(email));
    }

    public bool ExistsByEmail(string email)
    {
        return DataSet.FirstOrDefault(u => u.Email.Equals(email)) != null ? true : false;
    }

    public User? FindByRefreshToken(string refreshToken)
    {
        return DataSet
            .Include(u => u.Person)
            .Include(u => u.RefreshToken)
            .FirstOrDefault(u => u.RefreshToken != null && u.RefreshToken.Token.Equals(refreshToken));
    }
}