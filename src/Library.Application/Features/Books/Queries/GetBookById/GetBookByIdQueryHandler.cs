using Library.Application.Abstractions.Persistence;
using Library.Application.Common.Interfaces;
using Library.Application.Features.Books.Dtos;

namespace Library.Application.Features.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler(IBookRepository bookRepository)
    : IQueryHandler<GetBookByIdQuery, BookDto?>
{
    public async Task<BookDto?> Handle(GetBookByIdQuery query, CancellationToken ct)
    {
        var book = await bookRepository.GetByIdAsync(query.BookId, ct);
        return book is not null ? BookDto.From(book) : null;
    }
}
