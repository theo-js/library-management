using Library.Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configurations.Extensions;

public static class AuditableEntityConfiguration
{
    public static EntityTypeBuilder<TEntity> ConfigureAuditable<TEntity>(
        this EntityTypeBuilder<TEntity> builder
    )
        where TEntity : AuditableEntity
    {
        builder
            .HasOne(ae => ae.CreatedBy)
            .WithMany()
            .HasForeignKey(ae => ae.CreatedByUserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(ae => ae.UpdatedBy)
            .WithMany()
            .HasForeignKey(ae => ae.UpdatedByUserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        return builder;
    }
}
