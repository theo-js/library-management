using Library.Infrastructure.Persistence.Configurations.Extensions;
using Library.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configurations;

public class BookCopyConfiguration : IEntityTypeConfiguration<BookCopyEntity>
{
    public void Configure(EntityTypeBuilder<BookCopyEntity> builder)
    {
        builder.HasKey(bc => bc.Id);

        // BookCopy many -> 1 Book (required)
        builder
            .HasOne(bc => bc.Book)
            .WithMany(b => b.Copies)
            .HasForeignKey(bc => bc.BookId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.ConfigureSoftDeletable();
    }
}
