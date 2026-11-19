using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IgnoreSoftlyDeletedRowsWhenComparingUniqueColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_EmailAddress",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Book_IsbnNumber",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailAddress",
                table: "Users",
                column: "EmailAddress",
                unique: true,
                filter: "[DeletedAt] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IsbnNumber",
                table: "Book",
                column: "IsbnNumber",
                unique: true,
                filter: "[DeletedAt] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_EmailAddress",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Book_IsbnNumber",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailAddress",
                table: "Users",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_IsbnNumber",
                table: "Book",
                column: "IsbnNumber",
                unique: true);
        }
    }
}
