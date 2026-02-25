using SecurityPoliceMG.Configuration.Mail;

namespace SecurityPoliceMG.Service.Impl;

public class EmailServiceImpl(EmailSender sender) : IEmailService
{
    public void SendSimpleEmail(string to, string subject, string body)
    {
        sender.To(to)
            .WithSubject(subject)
            .WithMessage(body)
            .Send();
    }
}