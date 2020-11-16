using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class RemovedIngredientNutrition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientNutrition",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "RawFoodUsda",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsdaFoodId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Calories = table.Column<int>(nullable: true),
                    PralScore = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCarbs = table.Column<int>(nullable: true),
                    Sugars = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fiber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cholesterol = table.Column<int>(nullable: true),
                    SaturatedFat = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    Omega3s = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Omega6s = table.Column<int>(nullable: false),
                    TransFattyAcids = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FattyAcidsTotalMonounsaturated = table.Column<int>(nullable: true),
                    FattyAcidsTotalPolyunsaturated = table.Column<int>(nullable: true),
                    FattyAcidsTotalTransMonoenoic = table.Column<int>(nullable: true),
                    FattyAcidsTotalTransPolyenoic = table.Column<int>(nullable: true),
                    Calcium = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IronFe = table.Column<int>(nullable: true),
                    PotassiumK = table.Column<int>(nullable: true),
                    Magnesium = table.Column<int>(nullable: true),
                    Sodium = table.Column<int>(nullable: true),
                    ZincZn = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CopperCu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Manganese = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeleniumSe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FluorideF = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminAIu = table.Column<int>(nullable: true),
                    VitaminARae = table.Column<int>(nullable: true),
                    VitaminC = table.Column<decimal>(type: "decimal(18,1)", nullable: true),
                    VitaminB12 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThiaminB1 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    RiboflavinB2 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    NiacinB3 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    PantothenicAcidB5 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    VitaminB6 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FolateB9 = table.Column<int>(nullable: true),
                    FolicAcid = table.Column<int>(nullable: true),
                    FoodFolate = table.Column<int>(nullable: true),
                    FolateDfe = table.Column<int>(nullable: true),
                    VitaminDIu = table.Column<int>(nullable: true),
                    VitaminK = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sucrose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GlucoseDextrose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fructose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Lactose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Maltose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Galactose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Starch = table.Column<int>(nullable: true),
                    PhosphorusP = table.Column<int>(nullable: true),
                    Alcohol = table.Column<int>(nullable: true),
                    Caffeine = table.Column<int>(nullable: true),
                    Theobromine = table.Column<int>(nullable: true),
                    ServingWeight1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServingDescription1 = table.Column<string>(nullable: true),
                    ServingWeight2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServingDescription2 = table.Column<string>(nullable: true),
                    CalorieWeight200 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FoodGroupId = table.Column<int>(nullable: true),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawFoodUsda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawFoodUsda_IngredientFoodGroup_FoodGroupId",
                        column: x => x.FoodGroupId,
                        principalSchema: "ref",
                        principalTable: "IngredientFoodGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$W6D9YmUUPZ/aWZlY5V5JuuCUHS2UMOFLH4JO4w1IWDqB5HODJ2Laa" });

            migrationBuilder.CreateIndex(
                name: "IX_RawFoodUsda_FoodGroupId",
                schema: "dbo",
                table: "RawFoodUsda",
                column: "FoodGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawFoodUsda",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "IngredientNutrition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    PercentOfDailyNeeds = table.Column<int>(type: "int", nullable: false),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutrition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientNutrition_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "dbo",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$PaFLHch37b.AbSJqaGhdF.tLEndkHDCzVx7BeeauX21NfLxP8SqY." });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutrition_IngredientId",
                schema: "dbo",
                table: "IngredientNutrition",
                column: "IngredientId");
        }
    }
}
