using Library.Infrastructure.Persistence.Configurations.Extensions;
using Library.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ConfigureSoftDeletable();
        builder.HasIndex(b => b.IsbnNumber).IsUnique().HasFilter("[DeletedAt] IS NULL");
    }
}
