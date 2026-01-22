using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prop.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewQuoteFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaimNumber",
                table: "Quotes",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "FlammableFloor",
                table: "Quotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Quotes",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Quotes",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TopFloor",
                table: "Quotes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimNumber",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "FlammableFloor",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "TopFloor",
                table: "Quotes");
        }
    }
}
