using Library.Domain.Entities;

namespace Library.Application.Features.Books.Dtos;

public record class BookCopyDto(Guid Id)
{
    public static BookCopyDto From(BookCopy bookCopy) => new(bookCopy.Id);
};
