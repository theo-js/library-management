namespace Library.Http.Common.Headers;

public static class PaginationHeaders
{
    public const string TotalCount = "X-Total-Count";
    public const string TotalPages = "X-Total-Pages";
    public const string Page = "X-Page";
    public const string PageSize = "X-Page-Size";

    public static readonly string[] All = [TotalCount, TotalPages, Page, PageSize];
}
