namespace SecurityPoliceMG.EFCore.Repository.Base;

public class Page<T>
{
    public IEnumerable<T> Elements { get; set; }
    public Pageable Pageable { get; set; }
    public int Total { get; set; }

    private Page(IEnumerable<T> elements, Pageable pageable)
    {
        Elements = elements;
        Pageable = pageable;
        Total = elements.Count();
    }

    public static Page<T> Of(IEnumerable<T> elements, Pageable pageable)
    {
        return new Page<T>(elements, pageable);
    }
}