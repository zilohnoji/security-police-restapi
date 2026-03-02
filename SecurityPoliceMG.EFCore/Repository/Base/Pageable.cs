namespace SecurityPoliceMG.EFCore.Repository.Base;

public class Pageable
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string Sort { get; set; }
    public string OrderTerm { get; set; }
    public string SearchTerm { get; set; }

    private Pageable(int? page, int? pageSize, string? sort, string? orderTerm, string? searchTerm)
    {
        Page = page ?? 1;
        PageSize = pageSize ?? 10;
        Sort = sort ?? "desc";
        OrderTerm = orderTerm ?? "id";
        SearchTerm = searchTerm ?? "";
    }

    public static Pageable Of(int? page, int? pageSize, string? sort, string? orderTerm, string? searchTerm)
    {
        return new Pageable(page, pageSize, sort, orderTerm, searchTerm);
    }
}