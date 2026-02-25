namespace SecurityPoliceMG.Configuration.Mail;

public sealed class EmailSettings
{
    public string Subject { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 0;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public PropertiesSettings Properties { get; set; } = new PropertiesSettings();
    public bool Ssl { get; set; } = true;

    public sealed class PropertiesSettings
    {
        public bool SmtpAuth { get; set; } = true;
        public bool StartTlsEnable { get; set; } = true;
        public bool StartTlsRequired { get; set; } = true;
    }
}