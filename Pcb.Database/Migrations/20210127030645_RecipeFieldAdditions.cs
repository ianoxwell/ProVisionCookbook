using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class RecipeFieldAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceOfRecipeName",
                schema: "dbo",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpoonacularId",
                schema: "dbo",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XaXlI07k/IZTCijnq.qh4eAxWTZc50.UF1isNFcye6wOzI4Kf3gfC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceOfRecipeName",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "SpoonacularId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$5gaoKRK34WTxZOHr24kPYu7xYRqnlRaM/PS1JcsG8QeewMcx2VN1q");
        }
    }
}
