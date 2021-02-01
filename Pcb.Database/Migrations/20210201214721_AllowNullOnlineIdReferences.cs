using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class AllowNullOnlineIdReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "PermissionGroup",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "LogLevel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientState",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientFoodGroup",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "HealthLabel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "Equipment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "DishType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "DishTag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "CuisineType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "AllergyWarning",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OnlineId", "Title" },
                values: new object[] { null, "Japanese" });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OnlineId", "Title" },
                values: new object[] { null, "Spanish" });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 10,
                column: "OnlineId",
                value: null);

            migrationBuilder.InsertData(
                schema: "ref",
                table: "CuisineType",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 11, null, null, null, null, "South American" },
                    { 12, null, null, null, null, "Latin American" }
                });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: null);

            migrationBuilder.InsertData(
                schema: "ref",
                table: "DishType",
                columns: new[] { "Id", "AltTitle", "CreatedAt", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 8, "mainDish", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Main Dish" },
                    { 7, "mainCourse", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Main Course" }
                });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 10,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 11,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 12,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AltTitle", "OnlineId" },
                values: new object[] { "Meat", null });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 14,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 15,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 16,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 17,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 18,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 19,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 20,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 21,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 22,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 10,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 11,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$UHpxOawOv.5PmlsODbxVtucI3YuswX/9.7TuX585RHEmGOzsFi8My");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "PermissionGroup",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "LogLevel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientState",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientFoodGroup",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "HealthLabel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "DishType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "DishTag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "CuisineType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "AllergyWarning",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OnlineId", "Title" },
                values: new object[] { 0, "Japenese" });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OnlineId", "Title" },
                values: new object[] { 0, "Spannish" });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "CuisineType",
                keyColumn: "Id",
                keyValue: 10,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishType",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 10,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 11,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 12,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AltTitle", "OnlineId" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 14,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 15,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 16,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 17,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 18,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 19,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 20,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 21,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 22,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 7,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 8,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 9,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 10,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientState",
                keyColumn: "Id",
                keyValue: 11,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 4,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 5,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "LogLevel",
                keyColumn: "Id",
                keyValue: 6,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 3,
                column: "OnlineId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$S4dxbyF50IGHihuLuY5WIuvkWZTnHLJhrGOEOhhrzqFbYYeCtdKai");
        }
    }
}
