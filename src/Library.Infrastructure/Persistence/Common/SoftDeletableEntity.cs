using Library.Infrastructure.Persistence.Entities;

namespace Library.Infrastructure.Persistence.Common;

public abstract class SoftDeletableEntity : AuditableEntity
{
    public DateTime? DeletedAt { get; private set; }
    public Guid? DeletedByUserId { get; private set; }
    public UserEntity? DeletedBy { get; private set; }

    public void SoftDelete(Guid currentUserId)
    {
        DeletedAt = DateTime.UtcNow;
        DeletedByUserId = currentUserId;
    }

    public void Restore()
    {
        DeletedAt = null;
        DeletedByUserId = null;
    }
}
