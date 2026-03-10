using SecurityPoliceMG.Configuration.Mail;
using SecurityPoliceMG.Domain.Entity.Model;
using SecurityPoliceMG.Service.Impl.Email.Config;

namespace SecurityPoliceMG.Service.Impl.Email;

public class EmailServiceImpl(EmailSender sender) : IEmailService
{
    public void ActiveUserAccount(string userEmail, string code)
    {
        var html = TemplateHelper.BuildActiveAccountTemplate(BuildConfirmLink(userEmail, code));

        SendSimpleEmail(userEmail, "Confirmação de Cadastro", html);
    }

    public void PersonRegisterOnScale(string userEmail, Scale scale)
    {
        var html = TemplateHelper.BuildPersonRegisterOnScaleTemplate(scale, BuildDownloadLink(scale));
        SendSimpleEmail(userEmail, $"Escala - {scale.Id}", html);
    }


    private string BuildDownloadLink(Scale scale)
    {
        var encodedScaleId = Uri.EscapeDataString(scale.Id.ToString().Trim());

        return $"http://localhost:4200/api/scales/{encodedScaleId}";
    }

    private string BuildConfirmLink(string userEmail, string emailCode)
    {
        var encodedEmail = Uri.EscapeDataString(userEmail.Trim());
        var encodedEmailCode = Uri.EscapeDataString(emailCode.Trim());

        return $"http://localhost:4200/api/auth/{encodedEmail}/active/{encodedEmailCode}";
    }

    private void SendSimpleEmail(string to, string subject, string body)
    {
        sender.To(to)
            .WithSubject(subject)
            .WithMessage(body)
            .Send();
    }
}