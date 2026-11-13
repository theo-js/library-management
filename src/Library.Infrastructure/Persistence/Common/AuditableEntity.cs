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
}
