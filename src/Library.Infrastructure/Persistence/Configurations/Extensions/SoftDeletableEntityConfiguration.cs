using Library.Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configurations.Extensions;

public static class SoftDeletableEntityConfiguration
{
    public static EntityTypeBuilder<TEntity> ConfigureSoftDeletable<TEntity>(
        this EntityTypeBuilder<TEntity> builder
    )
        where TEntity : SoftDeletableEntity
    {
        builder.ConfigureAuditable();

        builder
            .HasOne(sde => sde.DeletedBy)
            .WithMany()
            .HasForeignKey(sde => sde.DeletedByUserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(sde => !sde.DeletedAt.HasValue);

        return builder;
    }
}
