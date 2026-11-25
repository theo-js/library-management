using Library.Application.Abstractions.Persistence;
using Library.Application.Common.Models;
using Library.Application.Features.Books.Queries.SearchBooks;
using Library.Domain.Entities;
using Library.Infrastructure.Extensions;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepository(AppDbContext dbContext) : IBookRepository
{
    public async Task<Book?> GetByIdAsync(Guid bookId, CancellationToken cancellationToken)
    {
        var bookEntity = await dbContext.Books.FindAsync(bookId, cancellationToken);
        return bookEntity?.ToDomain() ?? null;
    }

    public async Task<PagedResult<Book>> GetAllAsync(
        int page,
        int pageSize,
        BookSearchParameters? bookSearchParameters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.Books.AsQueryable();

        if (bookSearchParameters is not null)
        {
            query = bookSearchParameters.SearchCriteria switch
            {
                SearchCriteria.Author => query.Where(book =>
                    EF.Functions.Like(book.Author, $"%{bookSearchParameters.SearchTerm}%")
                ),
                SearchCriteria.IsbnNumber => query.Where(book =>
                    EF.Functions.Like(book.IsbnNumber, $"%{bookSearchParameters.SearchTerm}%")
                ),
                SearchCriteria.Title => query.Where(book =>
                    EF.Functions.Like(book.Title, $"%{bookSearchParameters.SearchTerm}%")
                ),
                _ => query,
            };
        }

        return await query
            .OrderBy(book => book.Id)
            .Include(book => book.Copies)
            .Select(book => book.ToDomain())
            .ToPagedResultAsync(page, pageSize, cancellationToken);
    }

    public async void Add(Book book)
    {
        dbContext.Books.Add(book.ToPersistence());
    }

    public async Task<bool> SoftDeleteAsync(Guid bookId, CancellationToken ct)
    {
        var bookEntity = await dbContext.Books.FindAsync(bookId, ct);
        if (bookEntity is null)
            return false;

        // TODO implement auth & current user service
        bookEntity.SoftDelete(Guid.Parse("4fc189ff-e6a2-4d7e-917b-4991b8797ed6"));
        return true;
    }
}
