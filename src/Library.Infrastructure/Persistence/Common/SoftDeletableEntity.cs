using Library.Infrastructure.Persistence.Entities;

namespace Library.Infrastructure.Persistence.Common;

public abstract class SoftDeletableEntity : AuditableEntity
{
    public DateTime? DeletedAt { get; private set; }
    public Guid? DeletedByUserId { get; private set; }
    public UserEntity? DeletedBy { get; private set; }
}
