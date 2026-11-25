using Library.Infrastructure.Persistence.Configurations.Extensions;
using Library.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configurations;

public class BookBorrowingConfiguration : IEntityTypeConfiguration<BookBorrowingEntity>
{
    public void Configure(EntityTypeBuilder<BookBorrowingEntity> builder)
    {
        builder.HasKey(bb => bb.Id);

        // BookBorrowing Many -> 1 BookCopy (required)
        builder
            .HasOne(bb => bb.BorrowedBookCopy)
            .WithMany(bc => bc.BorrowingsHistory)
            .HasForeignKey(bb => bb.BorrowedBookCopyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // BookBorrowing many -> 1 User (required)
        builder
            .HasOne(bb => bb.Borrower)
            .WithMany(u => u.BorrowedBooks)
            .HasForeignKey(bb => bb.BorrowerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.ConfigureAuditable();
    }
}
