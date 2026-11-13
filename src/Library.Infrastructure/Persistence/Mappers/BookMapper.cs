using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Entities;

namespace Library.Infrastructure.Persistence.Mappers;

public static class BookMapper
{
    public static Book ToDomain(this BookEntity bookEntity) =>
        Book.Reconstitute(
            new()
            {
                Id = bookEntity.Id,
                Author = bookEntity.Author,
                IsbnNumber = bookEntity.IsbnNumber,
                Title = bookEntity.Title,
                Copies = [.. bookEntity.Copies.Select(c => c.ToDomain())],
            }
        );

    public static BookEntity ToPersistence(this Book book) =>
        new()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            IsbnNumber = book.IsbnNumber.Value,
            Copies = [.. book.Copies.Select(c => c.ToPersistence())],
        };
}
