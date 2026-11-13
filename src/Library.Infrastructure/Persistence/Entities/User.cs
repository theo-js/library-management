using System.ComponentModel.DataAnnotations.Schema;
using Library.Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Entities;

[Table("Users")]
[Index(nameof(EmailAddress), IsUnique = true)]
public class UserEntity : SoftDeletableEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = null!;
    public ICollection<BookBorrowingEntity> BorrowedBooks { get; set; } = [];
    public bool IsActive { get; set; }
}
