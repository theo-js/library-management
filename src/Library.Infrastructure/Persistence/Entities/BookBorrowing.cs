using System.ComponentModel.DataAnnotations.Schema;
using Library.Infrastructure.Persistence.Common;

namespace Library.Infrastructure.Persistence.Entities;

[Table("BookBorrowings")]
public class BookBorrowingEntity : AuditableEntity
{
    public Guid Id { get; set; }
    public DateOnly BorrowingStartDate { get; set; }
    public DateOnly BorrowingEndDate { get; set; }

    // User
    public Guid BorrowerId { get; set; }
    public UserEntity? Borrower { get; set; }

    // Book copy
    public Guid BorrowedBookCopyId { get; set; }
    public BookCopyEntity? BorrowedBookCopy { get; set; }
}
