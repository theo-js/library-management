using Library.Application.Features.Books.Queries.SearchBooks;
using Library.Domain.Entities;

namespace Library.Application.Abstractions.Persistence;

public interface IBookRepository
{
    public Task<IReadOnlyCollection<Book>> GetAllAsync(
        int page,
        int pageSize,
        BookSearchParameters? bookSearchParameters,
        CancellationToken cancellationToken
    );
    public Task<Book?> GetByIdAsync(Guid BookId, CancellationToken cancellationToken);
    public void Add(Book book);
    public Task<bool> SoftDeleteAsync(Guid bookId, CancellationToken cancellationToken);
}
