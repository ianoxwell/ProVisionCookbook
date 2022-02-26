using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ref");

            migrationBuilder.EnsureSchema(
                name: "logs");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "map");

            migrationBuilder.EnsureSchema(
                name: "sec");

            migrationBuilder.CreateTable(
                name: "AllergyWarning",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyWarning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuisineType",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishTag",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishType",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthLabel",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthLabel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientFoodGroup",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientFoodGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientState",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogLevel",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementType = table.Column<int>(type: "int", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConvertsToId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teaser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfServings = table.Column<int>(type: "int", nullable: false),
                    PriceEstimate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceServing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrepTime = table.Column<int>(type: "int", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    ReadyInMinutes = table.Column<int>(type: "int", nullable: false),
                    RawInstructions = table.Column<string>(type: "text", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateByUserId = table.Column<int>(type: "int", nullable: false),
                    SourceOfRecipeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceOfRecipeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpoonacularId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberStars = table.Column<int>(type: "int", nullable: false),
                    NumberFavourites = table.Column<int>(type: "int", nullable: false),
                    NumberOfTimesCooked = table.Column<int>(type: "int", nullable: false),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsUser = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    BusinessContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GivenNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailedLoginAttempt = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    LastFailedLoginAttempt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TimesLoggedIn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    FirstLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsStudent = table.Column<bool>(type: "bit", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProviderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordReset = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawFoodUsda",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsdaFoodId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    PralScore = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCarbs = table.Column<int>(type: "int", nullable: true),
                    Sugars = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fiber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cholesterol = table.Column<int>(type: "int", nullable: true),
                    SaturatedFat = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    Omega3s = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Omega6s = table.Column<int>(type: "int", nullable: false),
                    TransFattyAcids = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FattyAcidsTotalMonounsaturated = table.Column<int>(type: "int", nullable: true),
                    FattyAcidsTotalPolyunsaturated = table.Column<int>(type: "int", nullable: true),
                    FattyAcidsTotalTransMonoenoic = table.Column<int>(type: "int", nullable: true),
                    FattyAcidsTotalTransPolyenoic = table.Column<int>(type: "int", nullable: true),
                    Calcium = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IronFe = table.Column<int>(type: "int", nullable: true),
                    PotassiumK = table.Column<int>(type: "int", nullable: true),
                    Magnesium = table.Column<int>(type: "int", nullable: true),
                    Sodium = table.Column<int>(type: "int", nullable: true),
                    ZincZn = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CopperCu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Manganese = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeleniumSe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FluorideF = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminAIu = table.Column<int>(type: "int", nullable: true),
                    VitaminARae = table.Column<int>(type: "int", nullable: true),
                    VitaminC = table.Column<decimal>(type: "decimal(18,1)", nullable: true),
                    VitaminB12 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThiaminB1 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    RiboflavinB2 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    NiacinB3 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    PantothenicAcidB5 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    VitaminB6 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FolateB9 = table.Column<int>(type: "int", nullable: true),
                    FolicAcid = table.Column<int>(type: "int", nullable: true),
                    FoodFolate = table.Column<int>(type: "int", nullable: true),
                    FolateDfe = table.Column<int>(type: "int", nullable: true),
                    VitaminDIu = table.Column<int>(type: "int", nullable: true),
                    VitaminK = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sucrose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GlucoseDextrose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fructose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Lactose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Maltose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Galactose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Starch = table.Column<int>(type: "int", nullable: true),
                    PhosphorusP = table.Column<int>(type: "int", nullable: true),
                    Alcohol = table.Column<int>(type: "int", nullable: true),
                    Caffeine = table.Column<int>(type: "int", nullable: true),
                    Theobromine = table.Column<int>(type: "int", nullable: true),
                    ServingWeight1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServingDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServingWeight2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServingDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalorieWeight200 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FoodGroupId = table.Column<int>(type: "int", nullable: true),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())")
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

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsdaFoodId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<int>(type: "int", nullable: true),
                    PurchasedBy = table.Column<int>(type: "int", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    PralScore = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCarbs = table.Column<int>(type: "int", nullable: true),
                    Sugars = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fiber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cholesterol = table.Column<int>(type: "int", nullable: true),
                    SaturatedFat = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    Omega3s = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Omega6s = table.Column<int>(type: "int", nullable: false),
                    TransFattyAcids = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FattyAcidsTotalMonounsaturated = table.Column<int>(type: "int", nullable: true),
                    FattyAcidsTotalPolyunsaturated = table.Column<int>(type: "int", nullable: true),
                    FattyAcidsTotalTransMonoenoic = table.Column<int>(type: "int", nullable: true),
                    FattyAcidsTotalTransPolyenoic = table.Column<int>(type: "int", nullable: true),
                    Calcium = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IronFe = table.Column<int>(type: "int", nullable: true),
                    PotassiumK = table.Column<int>(type: "int", nullable: true),
                    Magnesium = table.Column<int>(type: "int", nullable: true),
                    Sodium = table.Column<int>(type: "int", nullable: true),
                    ZincZn = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CopperCu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Manganese = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeleniumSe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FluorideF = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminAIu = table.Column<int>(type: "int", nullable: true),
                    VitaminARae = table.Column<int>(type: "int", nullable: true),
                    VitaminC = table.Column<decimal>(type: "decimal(18,1)", nullable: true),
                    VitaminB12 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThiaminB1 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    RiboflavinB2 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    NiacinB3 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    PantothenicAcidB5 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    VitaminB6 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    FolateB9 = table.Column<int>(type: "int", nullable: true),
                    FolicAcid = table.Column<int>(type: "int", nullable: true),
                    FoodFolate = table.Column<int>(type: "int", nullable: true),
                    FolateDfe = table.Column<int>(type: "int", nullable: true),
                    VitaminDIu = table.Column<int>(type: "int", nullable: true),
                    VitaminK = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sucrose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GlucoseDextrose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fructose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Lactose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Maltose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Galactose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Starch = table.Column<int>(type: "int", nullable: true),
                    PhosphorusP = table.Column<int>(type: "int", nullable: true),
                    Alcohol = table.Column<int>(type: "int", nullable: true),
                    Caffeine = table.Column<int>(type: "int", nullable: true),
                    Theobromine = table.Column<int>(type: "int", nullable: true),
                    ServingWeight1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServingDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServingWeight2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServingDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalorieWeight200 = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    PriceBrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceDollar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceMeasurement = table.Column<int>(type: "int", nullable: true),
                    PriceStoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceApiLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodGroupId = table.Column<int>(type: "int", nullable: true),
                    IngredientStateId = table.Column<int>(type: "int", nullable: true),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_IngredientFoodGroup_FoodGroupId",
                        column: x => x.FoodGroupId,
                        principalSchema: "ref",
                        principalTable: "IngredientFoodGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredient_IngredientState_IngredientStateId",
                        column: x => x.IngredientStateId,
                        principalSchema: "ref",
                        principalTable: "IngredientState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionGroupId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGroup_PermissionGroupId",
                        column: x => x.PermissionGroupId,
                        principalSchema: "ref",
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeAllergyWarning",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    AllergyWarningId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeAllergyWarning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeAllergyWarning_AllergyWarning_AllergyWarningId",
                        column: x => x.AllergyWarningId,
                        principalSchema: "ref",
                        principalTable: "AllergyWarning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeAllergyWarning_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCuisineType",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    CuisineTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCuisineType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeCuisineType_CuisineType_CuisineTypeId",
                        column: x => x.CuisineTypeId,
                        principalSchema: "ref",
                        principalTable: "CuisineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCuisineType_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDishTag",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    DishTagId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDishTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDishTag_DishTag_DishTagId",
                        column: x => x.DishTagId,
                        principalSchema: "ref",
                        principalTable: "DishTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDishTag_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDishType",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    DishTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDishType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDishType_DishType_DishTypeId",
                        column: x => x.DishTypeId,
                        principalSchema: "ref",
                        principalTable: "DishType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDishType_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeHealthLabel",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    HealthLabelId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeHealthLabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeHealthLabel_HealthLabel_HealthLabelId",
                        column: x => x.HealthLabelId,
                        principalSchema: "ref",
                        principalTable: "HealthLabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeHealthLabel_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipePicture",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PicturePosition = table.Column<int>(type: "int", nullable: false),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipePicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipePicture_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteppedInstruction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    StepDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteppedInstruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeSteppedInstruction_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                schema: "logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    LogLevelId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Machine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLog_LogLevel_LogLevelId",
                        column: x => x.LogLevelId,
                        principalSchema: "ref",
                        principalTable: "LogLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLog_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeReview",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeReview_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeReview_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: true),
                    IsCountryWide = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "sec",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_School_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "dbo",
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientAllergyWarning",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    AllergyWarningId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientAllergyWarning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientAllergyWarning_AllergyWarning_AllergyWarningId",
                        column: x => x.AllergyWarningId,
                        principalSchema: "ref",
                        principalTable: "AllergyWarning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientAllergyWarning_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "dbo",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientConversion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preference = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    BaseStateId = table.Column<int>(type: "int", nullable: true),
                    BaseMeasurementUnitId = table.Column<int>(type: "int", nullable: true),
                    BaseQuantity = table.Column<double>(type: "float", nullable: false),
                    ConvertToStateId = table.Column<int>(type: "int", nullable: true),
                    ConvertToMeasurementUnitId = table.Column<int>(type: "int", nullable: true),
                    ConvertToQuantity = table.Column<double>(type: "float", nullable: false),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientConversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "dbo",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_IngredientState_BaseStateId",
                        column: x => x.BaseStateId,
                        principalSchema: "ref",
                        principalTable: "IngredientState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_IngredientState_ConvertToStateId",
                        column: x => x.ConvertToStateId,
                        principalSchema: "ref",
                        principalTable: "IngredientState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_MeasurementUnit_BaseMeasurementUnitId",
                        column: x => x.BaseMeasurementUnitId,
                        principalSchema: "ref",
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_MeasurementUnit_ConvertToMeasurementUnitId",
                        column: x => x.ConvertToMeasurementUnitId,
                        principalSchema: "ref",
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "sec",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "sec",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentRecipeSteppedInstruction",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    RecipeSteppedInstructionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRecipeSteppedInstruction", x => new { x.EquipmentId, x.RecipeSteppedInstructionId });
                    table.ForeignKey(
                        name: "FK_EquipmentRecipeSteppedInstruction_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "ref",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentRecipeSteppedInstruction_RecipeSteppedInstruction_RecipeSteppedInstructionId",
                        column: x => x.RecipeSteppedInstructionId,
                        principalSchema: "dbo",
                        principalTable: "RecipeSteppedInstruction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientList",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preference = table.Column<int>(type: "int", nullable: false),
                    IngredientStateId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RecipeSteppedInstructionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientList_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "dbo",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientList_IngredientState_IngredientStateId",
                        column: x => x.IngredientStateId,
                        principalSchema: "ref",
                        principalTable: "IngredientState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientList_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalSchema: "ref",
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientList_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientList_RecipeSteppedInstruction_RecipeSteppedInstructionId",
                        column: x => x.RecipeSteppedInstructionId,
                        principalSchema: "dbo",
                        principalTable: "RecipeSteppedInstruction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "School",
                columns: new[] { "Id", "Address", "BusinessContactName", "Code", "EmailAddress", "EndDate", "PhoneNumber", "PostCode", "ShortName", "SortOrder", "StartDate", "StreetNumber", "Suburb", "Title" },
                values: new object[,]
                {
                    { 2, null, null, "DEFAULT", null, null, null, "0000", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Australia", "Default School" },
                    { 1, null, null, "NAS", null, null, null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Not a School" },
                    { 3, "18 Strathmore Parkway", "Paul Murphy", "HCC2020", "paul.murphy@hcc.wa.edu.au", null, null, "6030", "HCC", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ellenbrook", "Holy Cross College" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "AllergyWarning",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Gluten" },
                    { 2, null, null, null, null, "Lactose" },
                    { 3, null, null, null, null, "Shellfish" },
                    { 4, null, null, null, null, "Fish and Seafood" },
                    { 5, null, null, null, null, "Almonds and other Tree Nuts" },
                    { 6, null, null, null, null, "Sesame" },
                    { 7, null, null, null, null, "Soy" },
                    { 8, null, null, null, null, "Eggs" },
                    { 9, null, null, null, null, "Peanuts" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "CuisineType",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 12, null, null, null, null, "Latin American" },
                    { 11, null, null, null, null, "South American" },
                    { 10, null, null, null, null, "Mediterranean" },
                    { 9, null, null, null, null, "Indian" },
                    { 7, null, null, null, null, "Thai" },
                    { 6, null, null, null, null, "French" },
                    { 5, null, null, null, null, "Japanese" },
                    { 4, null, null, null, null, "Greek" },
                    { 3, null, null, null, null, "Italian" },
                    { 2, null, null, null, null, "Mexican" },
                    { 1, null, null, null, null, "Chinese" },
                    { 8, null, null, null, null, "Spanish" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "DishTag",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, "veryHealthy", null, null, null, "Very Healthy" },
                    { 2, "cheap", null, null, null, "Cheap" },
                    { 3, "veryPopular", null, null, null, "Very Popular" },
                    { 4, "sustainable", null, null, null, "Sustainable" },
                    { 5, "complicated", null, null, null, "Complicated" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "DishType",
                columns: new[] { "Id", "AltTitle", "CreatedAt", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 8, "mainDish", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Main Dish" },
                    { 7, "mainCourse", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Main Course" },
                    { 3, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Dinner" },
                    { 5, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Snack" },
                    { 4, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Dessert" },
                    { 1, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Breakfast" },
                    { 2, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Lunch" },
                    { 6, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, "Salad" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "Equipment",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, "Skillet", 464645, null, null, "Frying pan" },
                    { 2, "oven", 464784, null, null, "Oven" },
                    { 3, "bowl", 404783, null, null, "Bowl" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "HealthLabel",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 7, "ketogenic", null, "Keto is a very low-carb diet with less than 20g of carbohydrates per day. Substituting fats and oils for carbs.", null, "Keto" },
                    { 6, "lowFodmap", null, "FODMAP stands for Fermentable Oligosaccharides, Disaccharides, Monosaccharides, and Polyols, which are short chain carbohydrates and sugar alcohols that are poorly absorbed by the body, resulting in abdominal pain and bloating.", null, "Low FODMAP" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "HealthLabel",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 8, "whole30", null, "The Whole30 is a 30-day fad diet that emphasizes whole foods and the elimination of sugar, alcohol, grains, legumes, soy, and dairy. The Whole30 is similar to but more restrictive than the paleo diet, as adherents may not eat natural sweeteners like honey or maple syrup.", null, "Whole 30" },
                    { 4, "glutenFree", null, "On a gluten-free diet, you do not eat wheat, rye, and barley. These foods contain gluten, a type of protein. A gluten-free diet is the main treatment for celiac disease.", null, "Gluten Free" },
                    { 3, "vegan", null, "A vegetarian diet focuses on plants for food. These include fruits, vegetables,dried beans and peas, grains, seeds and nuts. Specifically excludes all meat and animal products.", null, "Vegan" },
                    { 2, null, null, "A vegetarian diet focuses on plants for food. These include fruits, vegetables,dried beans and peas, grains, seeds and nuts. Includes both diary products.", null, "Lacto Vegetarian" },
                    { 1, "vegetarian", null, "A vegetarian diet focuses on plants for food. These include fruits, vegetables,dried beans and peas, grains, seeds and nuts. Includes both diary products and eggs.", null, "Lacto-ovo Vegetarian" },
                    { 5, "dairyFree", null, "A diet that excludes all lactose based products, generally cows milk, cheeses and yoghurts. A Dairy Free diet is generally used by people with Lactose Intolerance.", null, "Dairy Free" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "IngredientFoodGroup",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 15, null, null, null, null, "Nuts and Seeds" },
                    { 22, "Produce", null, null, null, "Vegetables" },
                    { 21, null, null, null, null, "Sweets" },
                    { 20, "Spices and Seasonings", null, null, null, "Spices and Herbs" },
                    { 19, "Condiments", null, null, null, "Soups and Sauces" },
                    { 18, null, null, null, null, "Snacks" },
                    { 17, null, null, null, null, "Restaurant Foods" },
                    { 16, null, null, null, null, "Prepared Meals" },
                    { 14, null, null, null, null, "NULL" },
                    { 10, null, null, null, null, "Fish" },
                    { 12, "Pasta and Rice", null, null, null, "Grains and Pasta" },
                    { 11, null, null, null, null, "Fruits" },
                    { 9, "Oil, Vinegar, Salad Dressing", null, null, null, "Fats and Oils" },
                    { 8, null, null, null, null, "Fast Foods" },
                    { 7, null, null, null, null, "Dairy and Egg Products" },
                    { 6, null, null, null, null, "Breakfast Cereals" },
                    { 5, null, null, null, null, "Beverages" },
                    { 4, null, null, null, null, "Beans and Lentils" },
                    { 3, null, null, null, null, "Baked Foods" },
                    { 2, null, null, null, null, "Baby Foods" },
                    { 1, null, null, null, null, "American Indian" },
                    { 13, "Meat", null, null, null, "Meats" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "IngredientState",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 11, null, null, null, null, "Liquid" },
                    { 10, null, null, null, null, "Solid" },
                    { 9, null, null, null, null, "Boiling" },
                    { 8, null, null, null, null, "Ground" },
                    { 3, null, null, null, null, "Diced" },
                    { 6, null, null, null, null, "Firmly Packed" },
                    { 5, null, null, null, null, "Whole" },
                    { 4, null, null, null, null, "Shredded" },
                    { 2, null, null, null, null, "Sliced" },
                    { 1, null, null, null, null, "Chopped" },
                    { 7, null, null, null, null, "Loose" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "LogLevel",
                columns: new[] { "Id", "AltTitle", "OnlineId", "SortOrder", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 5, null, null, 2, null, null, "Error" },
                    { 6, null, null, 1, null, null, "Critical" },
                    { 3, null, null, 4, null, null, "Information" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "LogLevel",
                columns: new[] { "Id", "AltTitle", "OnlineId", "SortOrder", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, null, null, 6, null, null, "Trace" },
                    { 2, null, null, 5, null, null, "Debug" },
                    { 4, null, null, 3, null, null, "Warning" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "MeasurementUnit",
                columns: new[] { "Id", "AltShortName", "ConvertsToId", "CountryCode", "MeasurementType", "Quantity", "ShortName", "Title" },
                values: new object[,]
                {
                    { 15, null, 9, 2, 2, 1.0, "piece", "Pieces" },
                    { 14, null, 9, 2, 2, 1.0, "bch", "Bunch" },
                    { 12, null, 9, 2, 2, 1.0, "lg", "Large" },
                    { 11, null, 9, 2, 2, 1.0, "med", "Medium" },
                    { 10, null, 9, 2, 2, 1.0, "sml", "Small" },
                    { 13, null, 9, 2, 2, 1.0, "serving", "Servings" },
                    { 8, "kgs", 7, 0, 1, 1000.0, "kg", "Kilograms" },
                    { 7, "gr", 8, 0, 1, 0.001, "g", "Grams" },
                    { 6, null, 5, 0, 0, 1000.0, "L", "Litres" },
                    { 5, "mls", 6, 0, 0, 0.001, "ml", "Millilitres" },
                    { 4, null, 5, 0, 0, 250.0, "C", "Cup" },
                    { 3, "tsps", 5, 0, 0, 5.0, "tsp", "Teaspoon" },
                    { 1, null, 5, 0, 0, 1.0, "Pinch", "Pinch" },
                    { 2, "tbsps", 5, 0, 0, 20.0, "tbsp", "Tablespoon" },
                    { 9, null, 9, 2, 2, 1.0, "ea", "Each" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "PermissionGroup",
                columns: new[] { "Id", "AltTitle", "OnlineId", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 3, null, null, "", null, "User" },
                    { 2, null, null, "", null, "Teacher" },
                    { 1, null, null, "", null, "Administrator" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "Role",
                columns: new[] { "Id", "EndDate", "IsAdmin", "IsUser", "Rank", "StartDate", "Summary", "Title" },
                values: new object[,]
                {
                    { 2, null, false, true, 2, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "General User of Cookbook.", "User" },
                    { 3, null, false, true, 3, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "School Teacher.", "Teacher" },
                    { 4, null, false, true, 4, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "Student at a school.", "Student" },
                    { 1, null, true, false, 1, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "Global administrator with all permissions.", "Administrator" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "User",
                columns: new[] { "Id", "EmailAddress", "FamilyName", "FirstLogin", "GivenNames", "IsActive", "IsStudent", "LastFailedLoginAttempt", "LastLogin", "LoginProvider", "LoginProviderId", "PasswordHash", "PasswordReset", "PhoneNumber", "PhotoUrl", "ResetToken", "ResetTokenExpires", "Updated", "Username", "VerificationToken", "Verified" },
                values: new object[] { 1, "Admin@cookbook.com", "Min", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ad", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "$2a$11$c/nDkFT9M.hHuYafrMRqKuDhJLsl5B20F.Re4IYQgQtWj.Zxuiy0C", null, null, null, null, null, null, "admin", null, new DateTime(2018, 10, 10, 10, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "UserRole",
                columns: new[] { "Id", "IsCountryWide", "RoleId", "SchoolId", "UserId" },
                values: new object[] { 1, true, 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRecipeSteppedInstruction_RecipeSteppedInstructionId",
                table: "EquipmentRecipeSteppedInstruction",
                column: "RecipeSteppedInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_LogLevelId",
                schema: "logs",
                table: "EventLog",
                column: "LogLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_UserId",
                schema: "logs",
                table: "EventLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_FoodGroupId",
                schema: "dbo",
                table: "Ingredient",
                column: "FoodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientStateId",
                schema: "dbo",
                table: "Ingredient",
                column: "IngredientStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAllergyWarning_AllergyWarningId",
                schema: "map",
                table: "IngredientAllergyWarning",
                column: "AllergyWarningId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAllergyWarning_IngredientId",
                schema: "map",
                table: "IngredientAllergyWarning",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientConversion_BaseMeasurementUnitId",
                schema: "dbo",
                table: "IngredientConversion",
                column: "BaseMeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientConversion_BaseStateId",
                schema: "dbo",
                table: "IngredientConversion",
                column: "BaseStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientConversion_ConvertToMeasurementUnitId",
                schema: "dbo",
                table: "IngredientConversion",
                column: "ConvertToMeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientConversion_ConvertToStateId",
                schema: "dbo",
                table: "IngredientConversion",
                column: "ConvertToStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientConversion_IngredientId",
                schema: "dbo",
                table: "IngredientConversion",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionGroupId",
                schema: "sec",
                table: "Permission",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RawFoodUsda_FoodGroupId",
                schema: "dbo",
                table: "RawFoodUsda",
                column: "FoodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeAllergyWarning_AllergyWarningId",
                schema: "map",
                table: "RecipeAllergyWarning",
                column: "AllergyWarningId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeAllergyWarning_RecipeId",
                schema: "map",
                table: "RecipeAllergyWarning",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCuisineType_CuisineTypeId",
                schema: "map",
                table: "RecipeCuisineType",
                column: "CuisineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCuisineType_RecipeId",
                schema: "map",
                table: "RecipeCuisineType",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDishTag_DishTagId",
                schema: "map",
                table: "RecipeDishTag",
                column: "DishTagId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDishTag_RecipeId",
                schema: "map",
                table: "RecipeDishTag",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDishType_DishTypeId",
                schema: "map",
                table: "RecipeDishType",
                column: "DishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDishType_RecipeId",
                schema: "map",
                table: "RecipeDishType",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHealthLabel_HealthLabelId",
                schema: "map",
                table: "RecipeHealthLabel",
                column: "HealthLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHealthLabel_RecipeId",
                schema: "map",
                table: "RecipeHealthLabel",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientList_IngredientId",
                schema: "dbo",
                table: "RecipeIngredientList",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientList_IngredientStateId",
                schema: "dbo",
                table: "RecipeIngredientList",
                column: "IngredientStateId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientList_MeasurementUnitId",
                schema: "dbo",
                table: "RecipeIngredientList",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientList_RecipeId",
                schema: "dbo",
                table: "RecipeIngredientList",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientList_RecipeSteppedInstructionId",
                schema: "dbo",
                table: "RecipeIngredientList",
                column: "RecipeSteppedInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipePicture_RecipeId",
                schema: "dbo",
                table: "RecipePicture",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReview_RecipeId",
                schema: "dbo",
                table: "RecipeReview",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReview_UserId",
                schema: "dbo",
                table: "RecipeReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteppedInstruction_RecipeId",
                schema: "dbo",
                table: "RecipeSteppedInstruction",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                schema: "sec",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                schema: "sec",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "sec",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_SchoolId",
                schema: "sec",
                table: "UserRole",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "sec",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentRecipeSteppedInstruction");

            migrationBuilder.DropTable(
                name: "EventLog",
                schema: "logs");

            migrationBuilder.DropTable(
                name: "IngredientAllergyWarning",
                schema: "map");

            migrationBuilder.DropTable(
                name: "IngredientConversion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RawFoodUsda",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RecipeAllergyWarning",
                schema: "map");

            migrationBuilder.DropTable(
                name: "RecipeCuisineType",
                schema: "map");

            migrationBuilder.DropTable(
                name: "RecipeDishTag",
                schema: "map");

            migrationBuilder.DropTable(
                name: "RecipeDishType",
                schema: "map");

            migrationBuilder.DropTable(
                name: "RecipeHealthLabel",
                schema: "map");

            migrationBuilder.DropTable(
                name: "RecipeIngredientList",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RecipePicture",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RecipeReview",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "LogLevel",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "AllergyWarning",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "CuisineType",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "DishTag",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "DishType",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "HealthLabel",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "Ingredient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MeasurementUnit",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "RecipeSteppedInstruction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "School",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "IngredientFoodGroup",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "IngredientState",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "Recipe",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PermissionGroup",
                schema: "ref");
        }
    }
}
