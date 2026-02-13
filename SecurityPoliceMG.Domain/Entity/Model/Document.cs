using SecurityPoliceMG.Domain.Entity.Enum;

namespace SecurityPoliceMG.Domain.Entity.Model;

public sealed class Document : BaseEntity
{
    public string Name { get; private set; }

    public string Size { get; private set; }

    public DocumentType DocType { get; private set; }

    public string Url { get; private set; }

    private Document()
    {
    }
}