using Library.Application.Abstractions.Persistence;
using Library.Application.Common.Interfaces;

namespace Library.Application.Features.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteBookCommand, bool>
{
    public async Task<bool> Handle(DeleteBookCommand deleteBookCommand, CancellationToken ct)
    {
        bool isDeleted = await bookRepository.SoftDeleteAsync(deleteBookCommand.BookId, ct);
        if (!isDeleted)
            return false;

        await unitOfWork.SaveChangesAsync(ct);

        return true;
    }
}
