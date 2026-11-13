using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Entities;

namespace Library.Infrastructure.Persistence.Mappers;

public static class BookBorrowingMapper
{
    public static BookBorrowing ToDomain(this BookBorrowingEntity bookBorrowingEntity) =>
        BookBorrowing.Reconstitute(new() { Id = bookBorrowingEntity.Id });

    public static BookBorrowingEntity ToPersistence(this BookBorrowing bookBorrowing) =>
        new() { Id = bookBorrowing.Id };
}
