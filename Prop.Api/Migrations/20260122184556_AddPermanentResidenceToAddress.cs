using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prop.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPermanentResidenceToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PermanentResidence",
                table: "Addresses",
                type: "bit",
                maxLength: 5,
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermanentResidence",
                table: "Addresses");
        }
    }
}
