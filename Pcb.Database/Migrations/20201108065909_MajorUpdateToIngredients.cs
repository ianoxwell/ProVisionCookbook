using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class MajorUpdateToIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientParentType_ParentTypeId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_ParentTypeId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ParentTypeId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PercentCarbs",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PercentFat",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PercentProtein",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Alcohol",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Caffeine",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Calcium",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CalorieWeight200",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Carbohydrate",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cholesterol",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CopperCu",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FattyAcidsTotalMonounsaturated",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FattyAcidsTotalPolyunsaturated",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FattyAcidsTotalTransMonoenoic",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FattyAcidsTotalTransPolyenoic",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fiber",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FluorideF",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FolateB9",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FolateDfe",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FolicAcid",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodFolate",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodGroupId",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fructose",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Galactose",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GlucoseDextrose",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IronFe",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Lactose",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Magnesium",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Maltose",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Manganese",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NetCarbs",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NiacinB3",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Omega3s",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Omega6s",
                schema: "dbo",
                table: "Ingredient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PantothenicAcidB5",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhosphorusP",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PotassiumK",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PralScore",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RiboflavinB2",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SaturatedFat",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SeleniumSe",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServingDescription1",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServingDescription2",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ServingWeight1",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ServingWeight2",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sodium",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Starch",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sucrose",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sugars",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Theobromine",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThiaminB1",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TransFattyAcids",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsdaFoodId",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminAIu",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminARae",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminB12",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminB6",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminC",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminD",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminDIu",
                schema: "dbo",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminE",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminK",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Water",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ZincZn",
                schema: "dbo",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Carbohydrate", "Fat", "FoodGroupId", "Name", "Protein", "Water" },
                values: new object[] { 95m, 0m, 4, "Wholemeal Flour", 5m, 0m });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Carbohydrate", "Fat", "FoodGroupId", "Name", "Protein", "Water" },
                values: new object[] { 11m, 49m, 4, "Baby Spinach Leaves", 30m, 15m });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Fish and Seafood");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Almonds and other Tree Nuts");

            migrationBuilder.InsertData(
                schema: "ref",
                table: "AllergyWarning",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[] { 9, null, null, "Peanuts" });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$NcDi3uTJRNQlelpne5POfO3gbjBeidCPW182TT4gPX8lE5/ahPSyW" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_FoodGroupId",
                schema: "dbo",
                table: "Ingredient",
                column: "FoodGroupId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientParentType_FoodGroupId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_FoodGroupId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DeleteData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Alcohol",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Caffeine",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Calcium",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CalorieWeight200",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Calories",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Carbohydrate",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Cholesterol",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CopperCu",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Fat",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FattyAcidsTotalMonounsaturated",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FattyAcidsTotalPolyunsaturated",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FattyAcidsTotalTransMonoenoic",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FattyAcidsTotalTransPolyenoic",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Fiber",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FluorideF",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FolateB9",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FolateDfe",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FolicAcid",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FoodFolate",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FoodGroupId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Fructose",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Galactose",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "GlucoseDextrose",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "IronFe",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Lactose",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Magnesium",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Maltose",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Manganese",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "NetCarbs",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "NiacinB3",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Omega3s",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Omega6s",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PantothenicAcidB5",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PhosphorusP",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PotassiumK",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PralScore",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Protein",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RiboflavinB2",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "SaturatedFat",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "SeleniumSe",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ServingDescription1",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ServingDescription2",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ServingWeight1",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ServingWeight2",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Sodium",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Starch",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Sucrose",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Sugars",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Theobromine",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ThiaminB1",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "TransFattyAcids",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "UsdaFoodId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminAIu",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminARae",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminB12",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminB6",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminC",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminD",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminDIu",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminE",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "VitaminK",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Water",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ZincZn",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "ParentTypeId",
                schema: "dbo",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentCarbs",
                schema: "dbo",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentFat",
                schema: "dbo",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentProtein",
                schema: "dbo",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ParentTypeId", "PercentCarbs", "PercentFat", "PercentProtein" },
                values: new object[] { "Wholemeal Flour", 4, 95, 0, 5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ParentTypeId", "PercentCarbs", "PercentFat", "PercentProtein" },
                values: new object[] { "Baby Spinach Leaves", 4, 11, 49, 30 });

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Seafood");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "AllergyWarning",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Nut");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$Ie7FcxLUw91rkKwj65YQ/euyXLpMsRoTh1F1yf4L/IX2NwVQ6cdFG" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_ParentTypeId",
                schema: "dbo",
                table: "Ingredient",
                column: "ParentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientParentType_ParentTypeId",
                schema: "dbo",
                table: "Ingredient",
                column: "ParentTypeId",
                principalSchema: "ref",
                principalTable: "IngredientParentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
