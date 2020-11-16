using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class InitialStart : Migration
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
                name: "School",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    SortOrder = table.Column<int>(nullable: true),
                    BusinessContactName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllergyWarning",
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
                    table.PrimaryKey("PK_AllergyWarning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuisineType",
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
                    table.PrimaryKey("PK_CuisineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishTag",
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
                    table.PrimaryKey("PK_DishTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishType",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthLabel",
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
                    table.PrimaryKey("PK_HealthLabel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientParentType",
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
                    table.PrimaryKey("PK_IngredientParentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientState",
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
                    table.PrimaryKey("PK_IngredientState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogLevel",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    MeasurementType = table.Column<int>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    AltShortName = table.Column<string>(nullable: true),
                    ConvertsToId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    CountryCode = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsUser = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    FamilyName = table.Column<string>(nullable: false),
                    GivenNames = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    IsEmailVerified = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TimesLoggedIn = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    FirstLogin = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    IsStudent = table.Column<bool>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LinkUrl = table.Column<string>(nullable: true),
                    PurchasedBy = table.Column<int>(nullable: false),
                    PercentProtein = table.Column<int>(nullable: true),
                    PercentFat = table.Column<int>(nullable: true),
                    PercentCarbs = table.Column<int>(nullable: true),
                    PriceBrandName = table.Column<string>(nullable: true),
                    PriceDollar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceMeasurement = table.Column<int>(nullable: false),
                    PriceStoreName = table.Column<string>(nullable: true),
                    PriceApiLink = table.Column<string>(nullable: true),
                    ParentTypeId = table.Column<int>(nullable: true),
                    IngredientStateId = table.Column<int>(nullable: true),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_IngredientState_IngredientStateId",
                        column: x => x.IngredientStateId,
                        principalSchema: "ref",
                        principalTable: "IngredientState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredient_IngredientParentType_ParentTypeId",
                        column: x => x.ParentTypeId,
                        principalSchema: "ref",
                        principalTable: "IngredientParentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    PermissionGroupId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                name: "EventLog",
                schema: "logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    LogLevelId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Machine = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
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
                name: "UserRole",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    SchoolId = table.Column<int>(nullable: true),
                    IsCountryWide = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                name: "IngredientConversion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: false),
                    BaseStateId = table.Column<int>(nullable: true),
                    BaseMeasurementUnitId = table.Column<int>(nullable: true),
                    BaseQuantity = table.Column<double>(nullable: false),
                    ConvertToStateId = table.Column<int>(nullable: true),
                    ConvertToMeasurementUnitId = table.Column<int>(nullable: true),
                    ConvertToQuantity = table.Column<double>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientConversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_MeasurementUnit_BaseMeasurementUnitId",
                        column: x => x.BaseMeasurementUnitId,
                        principalSchema: "ref",
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_IngredientState_BaseStateId",
                        column: x => x.BaseStateId,
                        principalSchema: "ref",
                        principalTable: "IngredientState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientConversion_MeasurementUnit_ConvertToMeasurementUnitId",
                        column: x => x.ConvertToMeasurementUnitId,
                        principalSchema: "ref",
                        principalTable: "MeasurementUnit",
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
                        name: "FK_IngredientConversion_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "dbo",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientNutrition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentOfDailyNeeds = table.Column<int>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())")
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

            migrationBuilder.CreateTable(
                name: "Recipe",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Teaser = table.Column<string>(nullable: true),
                    NumberOfServings = table.Column<int>(nullable: false),
                    PriceEstimate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceServing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrepTime = table.Column<int>(nullable: false),
                    CookTime = table.Column<int>(nullable: false),
                    ReadyInMinutes = table.Column<int>(nullable: false),
                    RawInstructions = table.Column<string>(type: "text", nullable: true),
                    CreateByUserId = table.Column<int>(nullable: false),
                    SourceOfRecipeLink = table.Column<string>(nullable: true),
                    CreditsText = table.Column<string>(nullable: true),
                    NumberStars = table.Column<int>(nullable: false),
                    NumberFavourites = table.Column<int>(nullable: false),
                    NumberOfTimesCooked = table.Column<int>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    IngredientId = table.Column<int>(nullable: true),
                    IngredientStateId = table.Column<int>(nullable: true),
                    MeasurementUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "dbo",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipe_IngredientState_IngredientStateId",
                        column: x => x.IngredientStateId,
                        principalSchema: "ref",
                        principalTable: "IngredientState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipe_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalSchema: "ref",
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientAllergyWarning",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: false),
                    AllergyWarningId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                name: "RolePermission",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                name: "RecipeIngredientList",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Preference = table.Column<int>(nullable: false),
                    IngredientStateId = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())")
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
                });

            migrationBuilder.CreateTable(
                name: "RecipePicture",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FileLink = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    PicturePosition = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())")
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
                name: "RecipeReview",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())")
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
                name: "RecipeSteppedInstruction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    StepNumber = table.Column<int>(nullable: false),
                    StepDescription = table.Column<string>(nullable: true),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())")
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
                name: "RecipeAllergyWarning",
                schema: "map",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    AllergyWarningId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    CuisineTypeId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    DishTagId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    DishTypeId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    HealthLabelId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    RowVer = table.Column<byte[]>(rowVersion: true, nullable: true)
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

            migrationBuilder.InsertData(
                schema: "ref",
                table: "AllergyWarning",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, null, null, "Gluten" },
                    { 2, null, null, "Lactose" },
                    { 3, null, null, "Shellfish" },
                    { 4, null, null, "Seafood" },
                    { 5, null, null, "Nut" },
                    { 6, null, null, "Sesame" },
                    { 7, null, null, "Soy" },
                    { 8, null, null, "Eggs" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "CuisineType",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 10, null, null, "Mediterranean" },
                    { 9, null, null, "Indian" },
                    { 8, null, null, "Spannish" },
                    { 7, null, null, "Thai" },
                    { 6, null, null, "French" },
                    { 2, null, null, "Mexican" },
                    { 4, null, null, "Greek" },
                    { 3, null, null, "Italian" },
                    { 1, null, null, "Chinese" },
                    { 5, null, null, "Japenese" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "DishTag",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 5, null, null, "Complicated" },
                    { 4, null, null, "Sustainable" },
                    { 2, null, null, "Cheap" },
                    { 1, null, null, "Very Healthy" },
                    { 3, null, null, "Very Popular" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "DishType",
                columns: new[] { "Id", "CreatedAt", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Breakfast" },
                    { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Lunch" },
                    { 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dinner" },
                    { 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dessert" },
                    { 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Snack" },
                    { 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Salad" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "HealthLabel",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 2, "A vegetarian diet focuses on plants for food. These include fruits, vegetables,dried beans and peas, grains, seeds and nuts. Includes both diary products.", null, "Lacto Vegetarian" },
                    { 1, "A vegetarian diet focuses on plants for food. These include fruits, vegetables,dried beans and peas, grains, seeds and nuts. Includes both diary products and eggs.", null, "Lacto-ovo Vegetarian" },
                    { 3, "A vegetarian diet focuses on plants for food. These include fruits, vegetables,dried beans and peas, grains, seeds and nuts. Specifically excludes all meat and animal products.", null, "Vegan" },
                    { 4, "On a gluten-free diet, you do not eat wheat, rye, and barley. These foods contain gluten, a type of protein. A gluten-free diet is the main treatment for celiac disease.", null, "Gluten Free" },
                    { 5, "A diet that excludes all lactose based products, generally cows milk, cheeses and yoghurts. A Dairy Free diet is generally used by people with Lactose Intolerance.", null, "Dairy Free" },
                    { 6, "FODMAP stands for Fermentable Oligosaccharides, Disaccharides, Monosaccharides, and Polyols, which are short chain carbohydrates and sugar alcohols that are poorly absorbed by the body, resulting in abdominal pain and bloating.", null, "Low FODMAP" },
                    { 7, "Keto is a very low-carb diet with less than 20g of carbohydrates per day. Substituting fats and oils for carbs.", null, "Keto" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "IngredientParentType",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 8, null, null, "Sauce" },
                    { 7, null, null, "Meat" },
                    { 9, null, null, "Condiment" },
                    { 5, null, null, "Oil" },
                    { 6, null, null, "Spice" },
                    { 3, null, null, "Fruit" },
                    { 2, null, null, "Vegetable" },
                    { 1, null, null, "Flour" },
                    { 4, null, null, "Baking" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "IngredientState",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 10, null, null, "Solid" },
                    { 11, null, null, "Liquid" },
                    { 9, null, null, "Boiling" },
                    { 8, null, null, "Ground" },
                    { 7, null, null, "Loose" },
                    { 5, null, null, "Whole" },
                    { 4, null, null, "Shredded" },
                    { 3, null, null, "Diced" },
                    { 2, null, null, "Sliced" },
                    { 1, null, null, "Chopped" },
                    { 6, null, null, "Firmly Packed" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "LogLevel",
                columns: new[] { "Id", "SortOrder", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 6, 1, null, null, "Critical" },
                    { 4, 3, null, null, "Warning" },
                    { 5, 2, null, null, "Error" },
                    { 2, 5, null, null, "Debug" },
                    { 1, 6, null, null, "Trace" },
                    { 3, 4, null, null, "Information" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "MeasurementUnit",
                columns: new[] { "Id", "AltShortName", "ConvertsToId", "CountryCode", "MeasurementType", "Quantity", "ShortName", "Title" },
                values: new object[,]
                {
                    { 14, null, 9, 2, 2, 1.0, "bch", "Bunch" },
                    { 9, null, 9, 2, 2, 1.0, "ea", "Each" },
                    { 13, null, 9, 2, 2, 1.0, "serving", "Servings" },
                    { 12, null, 9, 2, 2, 1.0, "lg", "Large" },
                    { 11, null, 9, 2, 2, 1.0, "med", "Medium" },
                    { 10, null, 9, 2, 2, 1.0, "sml", "Small" },
                    { 8, "kgs", 7, 0, 1, 1000.0, "kg", "Kilograms" },
                    { 1, null, 5, 0, 0, 1.0, "Pinch", "Pinch" },
                    { 6, null, 5, 0, 0, 1000.0, "L", "Litres" },
                    { 5, "mls", 6, 0, 0, 0.001, "ml", "Millilitres" },
                    { 4, null, 5, 0, 0, 250.0, "C", "Cup" },
                    { 3, "tsps", 5, 0, 0, 5.0, "tsp", "Teaspoon" },
                    { 2, "tbsps", 5, 0, 0, 20.0, "tbsp", "Tablespoon" },
                    { 7, "gr", 8, 0, 1, 0.001, "g", "Grams" }
                });

            migrationBuilder.InsertData(
                schema: "ref",
                table: "PermissionGroup",
                columns: new[] { "Id", "Summary", "Symbol", "Title" },
                values: new object[,]
                {
                    { 3, "", null, "User" },
                    { 1, "", null, "Administrator" },
                    { 2, "", null, "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "Role",
                columns: new[] { "Id", "EndDate", "IsAdmin", "IsUser", "Rank", "StartDate", "Summary", "Title" },
                values: new object[,]
                {
                    { 3, null, false, true, 3, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "School Teacher.", "Teacher" },
                    { 4, null, false, true, 4, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "Student at a school.", "Student" },
                    { 1, null, true, false, 1, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "Global administrator with all permissions.", "Administrator" },
                    { 2, null, false, true, 2, new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999), "General User of Cookbook.", "User" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "User",
                columns: new[] { "Id", "EmailAddress", "FamilyName", "FirstLogin", "GivenNames", "IsActive", "IsEmailVerified", "IsStudent", "LastLogin", "PhoneNumber", "Username" },
                values: new object[] { 1, "Admin@cookbook.com", "Min", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ad", true, true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ingredient",
                columns: new[] { "Id", "IngredientStateId", "LinkUrl", "Name", "ParentTypeId", "PercentCarbs", "PercentFat", "PercentProtein", "PriceApiLink", "PriceBrandName", "PriceDollar", "PriceMeasurement", "PriceQuantity", "PriceStoreName", "PurchasedBy" },
                values: new object[] { 1, 8, null, "Wholemeal Flour", 4, 95, 0, 5, null, "Black and Gold", 1.99m, 1, 1m, "Woolworth", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ingredient",
                columns: new[] { "Id", "IngredientStateId", "LinkUrl", "Name", "ParentTypeId", "PercentCarbs", "PercentFat", "PercentProtein", "PriceApiLink", "PriceBrandName", "PriceDollar", "PriceMeasurement", "PriceQuantity", "PriceStoreName", "PurchasedBy" },
                values: new object[] { 2, 8, null, "Baby Spinach Leaves", 4, 11, 49, 30, null, "Farmers produce", 5.00m, 1, 400m, "Woolworth", 1 });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "UserRole",
                columns: new[] { "Id", "IsCountryWide", "RoleId", "SchoolId", "UserId" },
                values: new object[] { 1, true, 1, null, 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientStateId",
                schema: "dbo",
                table: "Ingredient",
                column: "IngredientStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_ParentTypeId",
                schema: "dbo",
                table: "Ingredient",
                column: "ParentTypeId");

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
                name: "IX_IngredientNutrition_IngredientId",
                schema: "dbo",
                table: "IngredientNutrition",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IngredientId",
                schema: "dbo",
                table: "Recipe",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IngredientStateId",
                schema: "dbo",
                table: "Recipe",
                column: "IngredientStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_MeasurementUnitId",
                schema: "dbo",
                table: "Recipe",
                column: "MeasurementUnitId");

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
                name: "IX_Permission_PermissionGroupId",
                schema: "sec",
                table: "Permission",
                column: "PermissionGroupId");

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
                name: "IngredientConversion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "IngredientNutrition",
                schema: "dbo");

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
                name: "RecipeSteppedInstruction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EventLog",
                schema: "logs");

            migrationBuilder.DropTable(
                name: "IngredientAllergyWarning",
                schema: "map");

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
                name: "RefreshToken",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "sec");

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
                name: "Recipe",
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
                name: "Ingredient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MeasurementUnit",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "PermissionGroup",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "IngredientState",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "IngredientParentType",
                schema: "ref");
        }
    }
}
