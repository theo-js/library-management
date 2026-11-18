using FluentValidation;

namespace Library.Application.Features.Books.Queries.SearchBooks;

public class SearchBooksQueryValidator : AbstractValidator<SearchBooksQuery>
{
    private const int MAX_PAGE_SIZE = 100;

    public SearchBooksQueryValidator()
    {
        RuleFor(q => q.Page).GreaterThanOrEqualTo(1);
        RuleFor(q => q.PageSize).InclusiveBetween(1, MAX_PAGE_SIZE);
    }
}
