namespace Library.Application.Features.Books.Queries.SearchBooks;

public sealed record class SearchBooksQuery
{
    private const int DEFAULT_PAGE = 1;
    private const int DEFAULT_PAGE_SIZE = 10;

    public int Page { get; set; }
    public int PageSize { get; set; }

    public SearchBooksQuery(int? page, int? pageSize)
    {
        Page = page ?? DEFAULT_PAGE;
        PageSize = pageSize ?? DEFAULT_PAGE_SIZE;
    }
};
