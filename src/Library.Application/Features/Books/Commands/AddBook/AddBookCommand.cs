namespace Library.Application.Features.Books.Commands.AddBook;

public sealed record class AddBookCommand(string Title, string Author, string IsbnNumber);
