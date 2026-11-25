using Library.Application.Common.Models;
using Library.Application.Features.Books.Commands.AddBook;
using Library.Application.Features.Books.Commands.DeleteBook;
using Library.Application.Features.Books.Dtos;
using Library.Application.Features.Books.Queries.GetBookById;
using Library.Application.Features.Books.Queries.SearchBooks;
using Microsoft.AspNetCore.Mvc;

namespace Library.Http.Controllers.Books;

[Route("books")]
[ApiController]
public class BooksController(
    SearchBooksQueryHandler searchBooksQueryHandler,
    GetBookByIdQueryHandler getBookByIdQueryHandler,
    AddBookCommandHandler addBookCommandHandler,
    DeleteBookCommandHandler deleteBookCommandHandler
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<BookDto>>> SearchAllBooks(
        [FromHeader(Name = "X-Page")] string? page,
        [FromHeader(Name = "X-Page-Size")] string? pageSize,
        [FromQuery(Name = "s")] string? searchTerm,
        [FromQuery(Name = "c")] SearchCriteria? searchCriteria,
        CancellationToken cancellationToken
    )
    {
        var pagedResult = await searchBooksQueryHandler.Handle(
            new SearchBooksQuery(
                string.IsNullOrEmpty(page) ? null : int.Parse(page),
                string.IsNullOrEmpty(pageSize) ? null : int.Parse(pageSize),
                searchTerm,
                searchCriteria
            ),
            cancellationToken
        );

        // Response.Headers.AttachPagedResult(pagedResult);
        return Ok(pagedResult);
    }

    [HttpGet]
    [Route("{bookId:Guid}")]
    public async Task<ActionResult<BookDto>> GetBookDetails(
        Guid bookId,
        CancellationToken cancellationToken
    )
    {
        var bookResponse = await getBookByIdQueryHandler.Handle(new(bookId), cancellationToken);

        if (bookResponse is null)
            return NotFound();

        return Ok(bookResponse);
    }

    [HttpPost]
    public Task<BookDto> AddBook([FromBody] AddBookCommand command, CancellationToken ct)
    {
        return addBookCommandHandler.Handle(command, ct);
    }

    [HttpDelete]
    [Route("{bookId:Guid}")]
    public async Task<ActionResult> DeleteBook(Guid bookId, CancellationToken cancellationToken)
    {
        bool hasDeletedSuccessfully = await deleteBookCommandHandler.Handle(
            new(bookId),
            cancellationToken
        );
        if (!hasDeletedSuccessfully)
            return NotFound();
        return NoContent();
    }
}
