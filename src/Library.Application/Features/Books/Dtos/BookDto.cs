using Library.Domain.Entities;

namespace Library.Application.Features.Books.Dtos;

public record class BookDto(
    Guid Id,
    string Title,
    string Author,
    string IsbnNumber,
    IReadOnlyCollection<BookCopyDto> Copies
)
{
    public static BookDto From(Book book) =>
        new(
            Id: book.Id,
            Title: book.Title,
            Author: book.Author,
            IsbnNumber: book.IsbnNumber.Value,
            Copies: [.. book.Copies.Select(BookCopyDto.From)]
        );
};
