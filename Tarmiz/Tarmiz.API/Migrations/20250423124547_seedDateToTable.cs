using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarmiz.API.Migrations
{
    /// <inheritdoc />
    public partial class seedDateToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingId);
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "CreatedAt", "Description", "Governorate", "ImageUrl", "NumberType", "Price", "Title", "UpdatedAt" },
                values: new object[] { new Guid("aff847e9-a102-4353-9858-f4a6f1e04c24"), new DateTime(2025, 4, 23, 12, 45, 46, 734, DateTimeKind.Utc).AddTicks(3349), "This is a sample listing.", "Irbid", "https://example.com/image.jpg", "Type Gold", 100.00m, "Sample Listing", new DateTime(2025, 4, 23, 12, 45, 46, 734, DateTimeKind.Utc).AddTicks(3350) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
