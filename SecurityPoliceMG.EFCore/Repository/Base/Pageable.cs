namespace SecurityPoliceMG.EFCore.Repository.Base;

public class Pageable
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string Sort { get; set; }
    public string OrderTerm { get; set; }
    public string SearchTerm { get; set; }

    public Pageable()
    {
        Page = 1;
        PageSize = 10;
        Sort = "desc";
        OrderTerm = "id";
        SearchTerm = "";
    }

    public static Pageable Of(int? page, int? pageSize, string? sort, string? orderTerm, string? searchTerm)
    {
        return new Pageable()
        {
            Page = page ?? 1,
            PageSize = pageSize ?? 10,
            Sort = sort ?? "desc",
            SearchTerm = searchTerm ?? "",
            OrderTerm = orderTerm ?? "id"
        };
    }
}