using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class ChangeToFoodGroupRefData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientParentType_FoodGroupId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "IngredientParentType",
                schema: "ref");

            migrationBuilder.CreateTable(
                name: "IngredientFoodGroup",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientFoodGroup", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "IngredientFoodGroup",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, null, null, "American Indian" },
                    { 21, null, null, "Sweets" },
                    { 20, null, null, "Spices and Herbs" },
                    { 19, null, null, "Soups and Sauces" },
                    { 18, null, null, "Snacks" },
                    { 17, null, null, "Restaurant Foods" },
                    { 16, null, null, "Prepared Meals" },
                    { 15, null, null, "Nuts and Seeds" },
                    { 14, null, null, "NULL" },
                    { 13, null, null, "Meats" },
                    { 22, null, null, "Vegetables" },
                    { 12, null, null, "Grains and Pasta" },
                    { 10, null, null, "Fish" },
                    { 9, null, null, "Fats and Oils" },
                    { 8, null, null, "Fast Foods" },
                    { 7, null, null, "Dairy and Egg Products" },
                    { 6, null, null, "Breakfast Cereals" },
                    { 5, null, null, "Beverages" },
                    { 4, null, null, "Beans and Lentils" },
                    { 3, null, null, "Baked Foods" },
                    { 2, null, null, "Baby Foods" },
                    { 11, null, null, "Fruits" }
                });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$DUv80uHd614LIHQS8zcA0uRsDwWTontbJ7wKXG6vuTtHuSMr3W/ZC" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Wholemeal Flour");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Baby Spinach Leaves");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientFoodGroup_FoodGroupId",
                schema: "dbo",
                table: "Ingredient",
                column: "FoodGroupId",
                principalSchema: "ref",
                principalTable: "IngredientFoodGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientFoodGroup_FoodGroupId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "IngredientFoodGroup",
                schema: "ref");

            migrationBuilder.CreateTable(
                name: "IngredientParentType",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientParentType", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "IngredientParentType",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, null, null, "Flour" },
                    { 2, null, null, "Vegetable" },
                    { 3, null, null, "Fruit" },
                    { 4, null, null, "Baking" },
                    { 5, null, null, "Oil" },
                    { 6, null, null, "Spice" },
                    { 7, null, null, "Meat" },
                    { 8, null, null, "Sauce" },
                    { 9, null, null, "Condiment" }
                });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$NcDi3uTJRNQlelpne5POfO3gbjBeidCPW182TT4gPX8lE5/ahPSyW" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Wholemeal Flour");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Baby Spinach Leaves");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientParentType_FoodGroupId",
                schema: "dbo",
                table: "Ingredient",
                column: "FoodGroupId",
                principalSchema: "ref",
                principalTable: "IngredientParentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
