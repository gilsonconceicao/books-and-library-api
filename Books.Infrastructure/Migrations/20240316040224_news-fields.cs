using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newsfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Catalogs",
                table: "Librarys",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Librarys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Librarys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Librarys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Format",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ibsn",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageNumber",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublishYear",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublishingCompany",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusAvailability",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Librarys");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Librarys");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Librarys");

            migrationBuilder.DropColumn(
                name: "Format",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Ibsn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishYear",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishingCompany",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "StatusAvailability",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Catalogs",
                table: "Librarys",
                type: "text",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);
        }
    }
}
