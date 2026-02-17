using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.EFCore.Configuration.Database.Context;

namespace SecurityPoliceMG.EFCore.Repository.Impl;

public sealed class UserRepositoryImpl(AppDbContext context) : GenericRepository<User>(context)
{
    public User FindByEmailOrThrowNotFound(string email)
    {
        return DataSet
                   .Include(u => u.Person)
                   .Include(u => u.RefreshToken)
                   .Include(u => u.EmailCodeConfirmation)
                   .FirstOrDefault(u => !string.IsNullOrEmpty(u.Email) && u.Email == email) ??
               throw new ArgumentException("Email não encontrado!");
    }

    public User? FindByEmail(string email)
    {
        return DataSet
            .Include(u => u.Person)
            .Include(u => u.RefreshToken)
            .Include(u => u.EmailCodeConfirmation)
            .FirstOrDefault(u => !string.IsNullOrEmpty(u.Email) && u.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return DataSet.Any(u => !string.IsNullOrEmpty(u.Email) && u.Email == email);
    }

    public User? FindByRefreshToken(string refreshToken)
    {
        return DataSet
            .Include(u => u.Person)
            .Include(u => u.RefreshToken)
            .Include(u => u.EmailCodeConfirmation)
            .FirstOrDefault(u => u.RefreshToken != null && u.RefreshToken.Token == refreshToken);
    }

    public User? FindByEmailCodeConfirmation(string emailCode)
    {
        return DataSet
            .Include(u => u.Person)
            .Include(u => u.RefreshToken)
            .Include(u => u.EmailCodeConfirmation)
            .FirstOrDefault(u => u.EmailCodeConfirmation != null && u.EmailCodeConfirmation.Code == emailCode);
    }
}