using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamepropbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Ibsn",
                table: "Books",
                newName: "BookNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookNumber",
                table: "Books",
                newName: "Ibsn");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Books",
                type: "text",
                nullable: true);
        }
    }
}
