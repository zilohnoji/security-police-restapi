using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Service;

public interface IEmailService
{
    void ActiveUserAccount(string userEmail, string code);

    void PersonRegisterOnScale(string userEmail, Scale scale);
}