using SecurityPoliceMG.Domain.Entity.Enum;

namespace SecurityPoliceMG.Domain.Entity.Model;

public class Document : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string Size { get; private set; } = string.Empty;

    public DocumentType DocType { get; private set; }

    public string Url { get; private set; } = string.Empty;

    private Document()
    {
    }
}