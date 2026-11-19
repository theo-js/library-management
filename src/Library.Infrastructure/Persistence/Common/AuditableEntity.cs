using Library.Infrastructure.Persistence.Entities;

namespace Library.Infrastructure.Persistence.Common;

public abstract class AuditableEntity
{
    public DateTime CreatedAt { get; private set; }
    public Guid? CreatedByUserId { get; private set; }
    public UserEntity? CreatedBy { get; private set; }

    public DateTime? UpdatedAt { get; private set; }
    public Guid? UpdatedByUserId { get; private set; }
    public UserEntity? UpdatedBy { get; private set; }

    public void SetCreated(Guid currentUserId)
    {
        CreatedByUserId = currentUserId;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetUpdated(Guid currentUserId)
    {
        UpdatedByUserId = currentUserId;
        UpdatedAt = DateTime.UtcNow;
    }
}
