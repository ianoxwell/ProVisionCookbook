using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class ConversionPreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Preference",
                schema: "dbo",
                table: "IngredientConversion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$5gaoKRK34WTxZOHr24kPYu7xYRqnlRaM/PS1JcsG8QeewMcx2VN1q");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preference",
                schema: "dbo",
                table: "IngredientConversion");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$pheOSS.b.1UvabpTIm7EA.IsMyEViqrTV8lHLKSeei6OBIq81Dz1i");
        }
    }
}
