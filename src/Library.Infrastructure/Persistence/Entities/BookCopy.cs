using System.ComponentModel.DataAnnotations.Schema;
using Library.Infrastructure.Persistence.Common;

namespace Library.Infrastructure.Persistence.Entities;

[Table("BookCopies")]
public class BookCopyEntity : SoftDeletableEntity
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public BookEntity? Book { get; set; }
    public BookBorrowingEntity? CurrentBorrowing { get; set; }
}
