using FluentValidation;
using Library.Application.Abstractions.Persistence;
using Library.Application.Common.Interfaces;
using Library.Application.Features.Books.Dtos;

namespace Library.Application.Features.Books.Queries.SearchBooks;

public class SearchBooksQueryHandler(
    SearchBooksQueryValidator validator,
    IBookRepository bookRepository
) : IQueryHandler<SearchBooksQuery, IReadOnlyCollection<BookDto>>
{
    public async Task<IReadOnlyCollection<BookDto>> Handle(
        SearchBooksQuery query,
        CancellationToken ct
    )
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken: ct);

        var bookSearchParameters =
            !string.IsNullOrEmpty(query.SearchTerm) && query.SearchCriteria is not null
                ? new BookSearchParameters(query.SearchTerm, query.SearchCriteria.Value)
                : null;

        return
        [
            .. (
                await bookRepository.GetAllAsync(
                    query.Page,
                    query.PageSize,
                    bookSearchParameters,
                    ct
                )
            ).Select(b => new BookDto(
                b.Id,
                b.Title,
                b.Author,
                b.IsbnNumber.Value,
                [.. b.Copies.Select(c => new BookCopyDto(c.Id))]
            )),
        ];
    }
}
