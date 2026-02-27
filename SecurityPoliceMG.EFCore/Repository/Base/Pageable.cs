namespace SecurityPoliceMG.EFCore.Repository.Base;

public class Pageable<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    private Pageable(int? page, int? pageSize)
    {
        Page = page ?? 1;
        PageSize = pageSize ?? 10;
    }

    public static Pageable<T> Of(int? page, int? pageSize)
    {
        return new Pageable<T>(page, pageSize);
    }
}