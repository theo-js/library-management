using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BookBorrowingManyToOneBookCopy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookBorrowings_BorrowedBookCopyId",
                table: "BookBorrowings");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowings_BorrowedBookCopyId",
                table: "BookBorrowings",
                column: "BorrowedBookCopyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookBorrowings_BorrowedBookCopyId",
                table: "BookBorrowings");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowings_BorrowedBookCopyId",
                table: "BookBorrowings",
                column: "BorrowedBookCopyId",
                unique: true);
        }
    }
}
