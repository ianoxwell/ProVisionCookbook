using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class AltTitleAllReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "PermissionGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "PermissionGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "LogLevel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "LogLevel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "IngredientState",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "HealthLabel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "DishType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "DishType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "DishTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "CuisineType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "CuisineType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "AllergyWarning",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "AllergyWarning",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$TS8dKgDnLbQ8f8768.JwVediNbIbU00vWaoAaCIpdVFzC/Ve2eLTa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "PermissionGroup");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "PermissionGroup");

            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "LogLevel");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "LogLevel");

            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "IngredientState");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientState");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "HealthLabel");

            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "DishType");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "DishType");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "DishTag");

            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "CuisineType");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "CuisineType");

            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "AllergyWarning");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "AllergyWarning");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$mp.ed40Nt4LTHqj9J12xyementoLs4m08dYSMin297Ecg6OFEvvdi");
        }
    }
}
