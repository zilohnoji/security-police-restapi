using MailKit.Net.Smtp;
using MimeKit;

namespace SecurityPoliceMG.Configuration.Mail;

public class EmailSender
{
    private readonly EmailSettings _settings;
    private string? _to;
    private string? _subject;
    private string? _body;

    public EmailSender(EmailSettings settings)
    {
        _settings = settings;
    }

    public EmailSender To(string to)
    {
        _to = to;
        return this;
    }

    public EmailSender WithSubject(string subject)
    {
        _subject = subject;
        return this;
    }

    public EmailSender WithMessage(string body)
    {
        _body = body;
        return this;
    }

    public void Reset()
    {
        _to = null;
        _subject = null;
        _body = null;
    }

    public void Send()
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(_settings.From, _settings.Username));
        message.Subject = _subject ?? _settings.Subject;

        if (!string.IsNullOrWhiteSpace(_to))
        {
            message.To.Add(MailboxAddress.Parse(_to));
        }

        var builder = new BodyBuilder()
        {
            HtmlBody = _body ?? _settings.Message,
        };

        message.Body = builder.ToMessageBody();

        using var client = new SmtpClient();

        try
        {
            client.Connect(_settings.Host, _settings.Port);
            if (_settings.Properties.SmtpAuth)
            {
                client.Authenticate(_settings.Username, _settings.Password);
            }

            client.Send(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            Reset();
            client.Disconnect(true);
        }
    }
}