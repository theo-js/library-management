using Library.Application.Abstractions.Persistence;
using Library.Application.Features.Books.Queries.SearchBooks;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepository(AppDbContext dbContext) : IBookRepository
{
    public async Task<Book?> GetByIdAsync(Guid bookId, CancellationToken cancellationToken) =>
        await dbContext
            .Books.Where(book => book.Id == bookId)
            .Include(book => book.Copies)
            .Select(book => book.ToDomain())
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IReadOnlyCollection<Book>> GetAllAsync(
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
            .Skip(pageSize * (page - 1))
            .Take(pageSize)
            .Include(book => book.Copies)
            .Select(book => book.ToDomain())
            .ToListAsync(cancellationToken);
    }

    public async void Add(Book book)
    {
        dbContext.Books.Add(book.ToPersistence());
    }
}
