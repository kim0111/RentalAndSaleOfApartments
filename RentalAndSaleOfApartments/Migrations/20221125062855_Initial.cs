using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAndSaleOfApartments.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    SizeInM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalPeriodInMounth = table.Column<int>(type: "int", nullable: false),
                    OwnersPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isRenovation = table.Column<bool>(type: "bit", nullable: false),
                    PostedOnSite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    SizeInM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnersPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isRenovation = table.Column<bool>(type: "bit", nullable: false),
                    PostedOnSite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
