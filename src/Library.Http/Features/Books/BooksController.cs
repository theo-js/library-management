using Library.Application.Features.Books.Commands.AddBook;
using Library.Application.Features.Books.Dtos;
using Library.Application.Features.Books.Queries.SearchBooks;
using Microsoft.AspNetCore.Mvc;

namespace Library.Http.Controllers.Books;

[Route("books")]
[ApiController]
public class BooksController(
    SearchBooksQueryHandler searchBooksQueryHandler,
    AddBookCommandHandler addBookCommandHandler
) : ControllerBase
{
    [HttpGet]
    public Task<IReadOnlyCollection<BookDto>> SearchAllBooks(
        [FromHeader(Name = "X-Page")] string? page,
        [FromHeader(Name = "X-Page-Size")] string? pageSize,
        [FromQuery(Name = "s")] string? searchTerm,
        [FromQuery(Name = "c")] SearchCriteria? searchCriteria,
        CancellationToken cancellationToken
    )
    {
        return searchBooksQueryHandler.Handle(
            new SearchBooksQuery(
                string.IsNullOrEmpty(page) ? null : int.Parse(page),
                string.IsNullOrEmpty(pageSize) ? null : int.Parse(pageSize),
                searchTerm,
                searchCriteria
            ),
            cancellationToken
        );
    }

    [HttpGet]
    [Route("/{bookId:Guid}")]
    public async Task GetBookDetails(Guid bookId) { }

    [HttpPost]
    public Task<BookDto> AddBook([FromBody] AddBookCommand command, CancellationToken ct)
    {
        return addBookCommandHandler.Handle(command, ct);
    }
}
