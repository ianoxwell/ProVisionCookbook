using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class NewDataPieces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "ref",
                table: "MeasurementUnit",
                columns: new[] { "Id", "AltShortName", "ConvertsToId", "CountryCode", "MeasurementType", "Quantity", "ShortName", "Title" },
                values: new object[] { 15, null, 9, 2, 2, 1.0, "piece", "Pieces" });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$iZljFMzez13U9chdBurBIO0vYXsYwisvkukqW3EfU6hCwLItJDIim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ref",
                table: "MeasurementUnit",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$ExOjJLkd1rs18hh2DxbYMehvGhCOTfip.pOW7cukLHEEJW1Rt4pWy" });
        }
    }
}
