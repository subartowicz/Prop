using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prop.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddClientAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Quotes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientPhone",
                table: "Quotes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Quotes",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeNumber",
                table: "Quotes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Quotes",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Quotes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "ClientPhone",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "HomeNumber",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Quotes");
        }
    }
}
