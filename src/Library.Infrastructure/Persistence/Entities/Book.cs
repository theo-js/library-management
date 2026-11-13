using System.ComponentModel.DataAnnotations.Schema;
using Library.Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Entities;

[Table("Book")]
[Index(nameof(IsbnNumber), IsUnique = true)]
public class BookEntity : SoftDeletableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string IsbnNumber { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public ICollection<BookCopyEntity> Copies { get; set; } = [];
}
