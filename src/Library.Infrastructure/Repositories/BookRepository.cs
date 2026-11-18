using Library.Application.Abstractions.Persistence;
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
        CancellationToken cancellationToken
    ) =>
        await dbContext
            .Books.OrderBy(book => book.Id)
            .Skip(pageSize * (page - 1))
            .Take(pageSize)
            .Include(book => book.Copies)
            .Select(book => book.ToDomain())
            .ToListAsync(cancellationToken);

    public async void Add(Book book)
    {
        dbContext.Books.Add(book.ToPersistence());
    }
}
