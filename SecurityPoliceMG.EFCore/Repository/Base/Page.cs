namespace SecurityPoliceMG.EFCore.Repository.Base;

public class Page<T>
{
    public List<T> Elements { get; set; }
    public Pageable Pageable { get; set; }
    public int Total { get; set; }

    private Page(List<T> elements, int total, Pageable pageable)
    {
        Elements = elements;
        Pageable = pageable;
        Total = total;
    }

    public static Page<T> Of(List<T> elements, int total, Pageable pageable)
    {
        return new Page<T>(elements, total, pageable);
    }
}