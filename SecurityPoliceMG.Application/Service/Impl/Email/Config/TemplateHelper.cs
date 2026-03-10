using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.Service.Impl.Email.Config;

public static class TemplateHelper
{
    public static string BuildActiveAccountTemplate(string confirmLink)
    {
        return GetEmailTemplate("ActiveUserAccount.html", new Dictionary<string, string>
        {
            { "CONFIRM_LINK", confirmLink },
            { "DATE", DateTime.UtcNow.ToString("dd/MM/yyyy") }
        });
    }

    public static string BuildPersonRegisterOnScaleTemplate(Scale scale, string downloadLink)
    {
        return GetEmailTemplate("PersonRegisterOnScale.html", new Dictionary<string, string>
        {
            { "ScaleMonth", scale.StartsAt.ToString("MMMM") },
            { "ScaleDay", scale.StartsAt.ToString("dd") },
            { "ScaleTime", scale.StartsAt.ToString("HH:mm") },
            { "ScaleDescription", scale.Description },
            { "DownloadLink", downloadLink }
        });
    }

    private static string GetEmailTemplate(string fileName, Dictionary<string, string> values)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Service/Impl/Email/Template", fileName);
        var html = File.ReadAllText(path);

        foreach (var p in values)
        {
            html = html.Replace("{{" + p.Key + "}}", p.Value);
        }

        return html;
    }
}