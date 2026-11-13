using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Entities;

namespace Library.Infrastructure.Persistence.Mappers;

public static class BookCopyMapper
{
    public static BookCopy ToDomain(this BookCopyEntity bookCopyEntity) =>
        BookCopy.Reconstitute(new() { Id = bookCopyEntity.Id });

    public static BookCopyEntity ToPersistence(this BookCopy bookCopy) =>
        new() { Id = bookCopy.Id };
}
