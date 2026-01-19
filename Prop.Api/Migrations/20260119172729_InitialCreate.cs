using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prop.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClientEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PropertyArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropertyYear = table.Column<int>(type: "int", nullable: false),
                    HasSecuritySystem = table.Column<bool>(type: "bit", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
