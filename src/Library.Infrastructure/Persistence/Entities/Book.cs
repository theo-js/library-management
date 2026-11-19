using System.ComponentModel.DataAnnotations.Schema;
using Library.Infrastructure.Persistence.Common;

namespace Library.Infrastructure.Persistence.Entities;

[Table("Book")]
public class BookEntity : SoftDeletableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string IsbnNumber { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public ICollection<BookCopyEntity> Copies { get; set; } = [];
}
