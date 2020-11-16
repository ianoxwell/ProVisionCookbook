using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class IngredientNullablePurchasedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IngredientConversion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IngredientNutrition",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IngredientNutrition",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IngredientNutrition",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IngredientNutrition",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "map",
                table: "IngredientAllergyWarning",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "PurchasedBy",
                schema: "dbo",
                table: "Ingredient",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$5QZGWpWTCePRm7Gutj6Tw.ijA7waIaoGd6/w/EBJBUaTSE2AfNpHC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PurchasedBy",
                schema: "dbo",
                table: "Ingredient",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ingredient",
                columns: new[] { "Id", "Alcohol", "Caffeine", "Calcium", "CalorieWeight200", "Calories", "Carbohydrate", "Cholesterol", "CopperCu", "Fat", "FattyAcidsTotalMonounsaturated", "FattyAcidsTotalPolyunsaturated", "FattyAcidsTotalTransMonoenoic", "FattyAcidsTotalTransPolyenoic", "Fiber", "FluorideF", "FolateB9", "FolateDfe", "FolicAcid", "FoodFolate", "FoodGroupId", "Fructose", "Galactose", "GlucoseDextrose", "IngredientStateId", "IronFe", "Lactose", "LinkUrl", "Magnesium", "Maltose", "Manganese", "Name", "NetCarbs", "NiacinB3", "Omega3s", "Omega6s", "PantothenicAcidB5", "PhosphorusP", "PotassiumK", "PralScore", "PriceApiLink", "PriceBrandName", "PriceDollar", "PriceMeasurement", "PriceQuantity", "PriceStoreName", "Protein", "PurchasedBy", "RiboflavinB2", "SaturatedFat", "SeleniumSe", "ServingDescription1", "ServingDescription2", "ServingWeight1", "ServingWeight2", "Sodium", "Starch", "Sucrose", "Sugars", "Theobromine", "ThiaminB1", "TransFattyAcids", "UsdaFoodId", "VitaminAIu", "VitaminARae", "VitaminB12", "VitaminB6", "VitaminC", "VitaminD", "VitaminDIu", "VitaminE", "VitaminK", "Water", "ZincZn" },
                values: new object[] { 1, null, null, null, null, null, 95m, null, null, 0m, null, null, null, null, null, null, null, null, null, null, 4, null, null, null, 8, null, null, null, null, null, null, "Wholemeal Flour", null, null, 0m, 0, null, null, null, null, null, "Black and Gold", 1.99m, 1, 1m, "Woolworth", 5m, 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0m, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ingredient",
                columns: new[] { "Id", "Alcohol", "Caffeine", "Calcium", "CalorieWeight200", "Calories", "Carbohydrate", "Cholesterol", "CopperCu", "Fat", "FattyAcidsTotalMonounsaturated", "FattyAcidsTotalPolyunsaturated", "FattyAcidsTotalTransMonoenoic", "FattyAcidsTotalTransPolyenoic", "Fiber", "FluorideF", "FolateB9", "FolateDfe", "FolicAcid", "FoodFolate", "FoodGroupId", "Fructose", "Galactose", "GlucoseDextrose", "IngredientStateId", "IronFe", "Lactose", "LinkUrl", "Magnesium", "Maltose", "Manganese", "Name", "NetCarbs", "NiacinB3", "Omega3s", "Omega6s", "PantothenicAcidB5", "PhosphorusP", "PotassiumK", "PralScore", "PriceApiLink", "PriceBrandName", "PriceDollar", "PriceMeasurement", "PriceQuantity", "PriceStoreName", "Protein", "PurchasedBy", "RiboflavinB2", "SaturatedFat", "SeleniumSe", "ServingDescription1", "ServingDescription2", "ServingWeight1", "ServingWeight2", "Sodium", "Starch", "Sucrose", "Sugars", "Theobromine", "ThiaminB1", "TransFattyAcids", "UsdaFoodId", "VitaminAIu", "VitaminARae", "VitaminB12", "VitaminB6", "VitaminC", "VitaminD", "VitaminDIu", "VitaminE", "VitaminK", "Water", "ZincZn" },
                values: new object[] { 2, null, null, null, null, null, 11m, null, null, 49m, null, null, null, null, null, null, null, null, null, null, 4, null, null, null, 8, null, null, null, null, null, null, "Baby Spinach Leaves", null, null, 0m, 0, null, null, null, null, null, "Farmers produce", 5.00m, 1, 400m, "Woolworth", 30m, 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 15m, null });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$DUv80uHd614LIHQS8zcA0uRsDwWTontbJ7wKXG6vuTtHuSMr3W/ZC" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "IngredientConversion",
                columns: new[] { "Id", "BaseMeasurementUnitId", "BaseQuantity", "BaseStateId", "ConvertToMeasurementUnitId", "ConvertToQuantity", "ConvertToStateId", "IngredientId" },
                values: new object[] { 1, 1, 1.0, 6, 2, 120.0, 6, 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "IngredientNutrition",
                columns: new[] { "Id", "Amount", "IngredientId", "PercentOfDailyNeeds", "Title", "Unit" },
                values: new object[,]
                {
                    { 1, 340m, 1, 0, "Calories", 2 },
                    { 2, 363m, 1, 10, "Potassium ", 1 },
                    { 3, 23m, 2, 0, "Calories", 2 },
                    { 4, 558m, 2, 10, "Potassium ", 1 }
                });

            migrationBuilder.InsertData(
                schema: "map",
                table: "IngredientAllergyWarning",
                columns: new[] { "Id", "AllergyWarningId", "IngredientId" },
                values: new object[] { 1, 1, 1 });
        }
    }
}
