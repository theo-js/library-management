namespace Library.Application.Features.Books.Queries.SearchBooks;

public record class BookSearchParameters(string SearchTerm, SearchCriteria SearchCriteria);
