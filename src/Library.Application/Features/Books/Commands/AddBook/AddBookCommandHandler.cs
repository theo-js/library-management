using Library.Application.Abstractions.Persistence;
using Library.Application.Common.Interfaces;
using Library.Application.Features.Books.Dtos;
using Library.Domain.Entities;

namespace Library.Application.Features.Books.Commands.AddBook;

public class AddBookCommandHandler(
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork,
    AddBookCommandValidator validator
) : ICommandHandler<AddBookCommand, BookDto>
{
    public async Task<BookDto> Handle(AddBookCommand command, CancellationToken ct)
    {
        await validator.ValidateAsync(command, ct);

        Book book = Book.Create(
            new()
            {
                Author = command.Author,
                Title = command.Title,
                IsbnNumber = command.IsbnNumber,
            }
        );
        bookRepository.Add(book);
        await unitOfWork.SaveChangesAsync(ct);

        return BookDto.From(book);
    }
}
