namespace SecurityPoliceMG.Service;

public interface IEmailService
{
    void SendSimpleEmail(string to, string subject, string body);
}