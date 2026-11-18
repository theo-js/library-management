using FluentValidation;

namespace Library.Application.Features.Books.Commands.AddBook;

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        RuleFor(b => b.Title).NotEmpty();
        RuleFor(b => b.Author).NotEmpty();
        RuleFor(b => b.IsbnNumber).NotEmpty();
    }
}
