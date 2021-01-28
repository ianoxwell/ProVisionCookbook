using Microsoft.EntityFrameworkCore;
using Pcb.Common.Enums;
using Pcb.Database.Context.Models;
using System;
using System.Reflection;
using BC = BCrypt.Net.BCrypt;

namespace Pcb.Database.Context
{
    public partial class PcbDbContext : DbContext
    {
        public PcbDbContext()
        {
        }

        public PcbDbContext(DbContextOptions options) : base(options)
        {
        }

        // Ingredient section
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientConversion> IngredientConversion { get; set; }

        public virtual DbSet<RawFoodUsda> RawFoodUsda { get; set; }

        // Recipe
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeIngredientList> RecipeIngredientList { get; set; }
        public virtual DbSet<RecipePicture> RecipePicture { get; set; }
        public virtual DbSet<RecipeReview> RecipeReview { get; set; }
        public virtual DbSet<RecipeSteppedInstruction> RecipeSteppedInstruction { get; set; }

        // School
        public virtual DbSet<School> School { get; set; }

        // Logs
        public virtual DbSet<EventLog> EventLog { get; set; }

        // Maps
        public virtual DbSet<IngredientAllergyWarning> IngredientAllergyWarning { get; set; }
        public virtual DbSet<RecipeAllergyWarning> RecipeAllergyWarning { get; set; }
        public virtual DbSet<RecipeCuisineType> RecipeCuisineType { get; set; }
        public virtual DbSet<RecipeDishTag> RecipeDishTag { get; set; }
        public virtual DbSet<RecipeDishType> RecipeDishType { get; set; }
        public virtual DbSet<RecipeHealthLabel> RecipeHealthLabel { get; set; }

        // Ref
        public virtual DbSet<AllergyWarning> AllergyWarning { get; set; }
        public virtual DbSet<CuisineType> CuisineType { get; set; }
        public virtual DbSet<DishTag> DishTag { get; set; }
        public virtual DbSet<DishType> DishType { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<HealthLabel> HealthLabel { get; set; }
        public virtual DbSet<IngredientFoodGroup> IngredientFoodGroup { get; set; }
        public virtual DbSet<IngredientState> IngredientState { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnit { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroup { get; set; }
        public virtual DbSet<LogLevel> LogLevel { get; set; }

        // Sec
        public virtual DbSet<Permission> Permission { get; set; }
        // no DbSet on Refresh token as it is [Owned] by User
        //public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        public dynamic FindEntity(string table)
        {
            PropertyInfo prop = this.GetType().GetProperty(table, BindingFlags.Instance | BindingFlags.Public);
            return prop.GetValue(this, null);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dbo
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<IngredientConversion>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeIngredientList>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipePicture>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeReview>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeSteppedInstruction>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });

            // Maps
            modelBuilder.Entity<IngredientAllergyWarning>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeAllergyWarning>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeCuisineType>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeDishTag>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeDishType>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RecipeHealthLabel>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });

            // Ref
            modelBuilder.Entity<AllergyWarning>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<CuisineType>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<DishTag>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<DishTag>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<HealthLabel>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<IngredientFoodGroup>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<IngredientState>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<LogLevel>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<PermissionGroup>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });

            // Sec
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RawFoodUsda>(entity =>
           {
               entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
           });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
                entity.Property(e => e.TimesLoggedIn).HasDefaultValueSql("0");
                entity.Property(e => e.FailedLoginAttempt).HasDefaultValueSql("0");
            });

            // Seed Data Role
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Title = "Administrator",
                    Summary = "Global administrator with all permissions.",
                    Rank = 1,
                    IsAdmin = true,
                    IsUser = false,
                    StartDate = new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999),
                });

            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = 2,
                   Title = "User",
                   Summary = "General User of Cookbook.",
                   Rank = 2,
                   IsAdmin = false,
                   IsUser = true,
                   StartDate = new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999),
               });
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 3,
                    Title = "Teacher",
                    Summary = "School Teacher.",
                    Rank = 3,
                    IsAdmin = false,
                    IsUser = true,
                    StartDate = new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999),
                });
            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = 4,
                   Title = "Student",
                   Summary = "Student at a school.",
                   Rank = 4,
                   IsAdmin = false,
                   IsUser = true,
                   StartDate = new DateTime(2020, 4, 15, 0, 0, 0, 999, DateTimeKind.Local).AddTicks(9999),
               });

            // Seed data Permission group
            modelBuilder.Entity<PermissionGroup>().HasData(
               new PermissionGroup()
               {
                   Id = 1,
                   Title = "Administrator",
                   Summary = string.Empty,
               });
            modelBuilder.Entity<PermissionGroup>().HasData(
               new PermissionGroup()
               {
                   Id = 2,
                   Title = "Teacher",
                   Summary = string.Empty,
               });
            modelBuilder.Entity<PermissionGroup>().HasData(
               new PermissionGroup()
               {
                   Id = 3,
                   Title = "User",
                   Summary = string.Empty,
               });

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "admin",
                    GivenNames = "Ad",
                    FamilyName = "Min",
                    EmailAddress = "Admin@cookbook.com",
                    PasswordHash = BC.HashPassword("admin"),
                    IsActive = true,
                    Verified = new DateTime(2018, 10, 10, 10, 10, 0),
                    IsStudent = false
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1,
                    IsCountryWide = true
                });

            modelBuilder.Entity<MeasurementUnit>().HasData(
                new MeasurementUnit()
                {
                    Id = 1,
                    Title = "Pinch",
                    MeasurementType = MeasurementType.Volume,
                    ShortName = "Pinch",
                    AltShortName = null,
                    ConvertsToId = 5,
                    Quantity = 1,
                    CountryCode = CountryCode.AU
                });
            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 2,
                   Title = "Tablespoon",
                   MeasurementType = MeasurementType.Volume,
                   ShortName = "tbsp",
                   AltShortName = "tbsps",
                   ConvertsToId = 5,
                   Quantity = 20,
                   CountryCode = CountryCode.AU
               });
            modelBuilder.Entity<MeasurementUnit>().HasData(
                new MeasurementUnit()
                {
                    Id = 3,
                    Title = "Teaspoon",
                    MeasurementType = MeasurementType.Volume,
                    ShortName = "tsp",
                    AltShortName = "tsps",
                    ConvertsToId = 5,
                    Quantity = 5,
                    CountryCode = CountryCode.AU
                });

            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 4,
                   Title = "Cup",
                   MeasurementType = MeasurementType.Volume,
                   ShortName = "C",
                   AltShortName = null,
                   ConvertsToId = 5,
                   Quantity = 250,
                   CountryCode = CountryCode.AU
               });

            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 5,
                   Title = "Millilitres",
                   MeasurementType = MeasurementType.Volume,
                   ShortName = "ml",
                   AltShortName = "mls",
                   ConvertsToId = 6,
                   Quantity = 0.001,
                   CountryCode = CountryCode.AU
               });

            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 6,
                   Title = "Litres",
                   MeasurementType = MeasurementType.Volume,
                   ShortName = "L",
                   AltShortName = null,
                   ConvertsToId = 5,
                   Quantity = 1000,
                   CountryCode = CountryCode.AU
               });

            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 7,
                   Title = "Grams",
                   MeasurementType = MeasurementType.Weight,
                   ShortName = "g",
                   AltShortName = "gr",
                   ConvertsToId = 8,
                   Quantity = 0.001,
                   CountryCode = CountryCode.AU
               });

            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 8,
                   Title = "Kilograms",
                   MeasurementType = MeasurementType.Weight,
                   ShortName = "kg",
                   AltShortName = "kgs",
                   ConvertsToId = 7,
                   Quantity = 1000,
                   CountryCode = CountryCode.AU
               });
            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 9,
                   Title = "Each",
                   MeasurementType = MeasurementType.Item,
                   ShortName = "ea",
                   AltShortName = null,
                   ConvertsToId = 9,
                   Quantity = 1,
                   CountryCode = CountryCode.ALL
               });
            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 10,
                   Title = "Small",
                   MeasurementType = MeasurementType.Item,
                   ShortName = "sml",
                   AltShortName = null,
                   ConvertsToId = 9,
                   Quantity = 1,
                   CountryCode = CountryCode.ALL
               });
            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 11,
                   Title = "Medium",
                   MeasurementType = MeasurementType.Item,
                   ShortName = "med",
                   AltShortName = null,
                   ConvertsToId = 9,
                   Quantity = 1,
                   CountryCode = CountryCode.ALL
               });
            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 12,
                   Title = "Large",
                   MeasurementType = MeasurementType.Item,
                   ShortName = "lg",
                   AltShortName = null,
                   ConvertsToId = 9,
                   Quantity = 1,
                   CountryCode = CountryCode.ALL
               });

            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 13,
                   Title = "Servings",
                   MeasurementType = MeasurementType.Item,
                   ShortName = "serving",
                   AltShortName = null,
                   ConvertsToId = 9,
                   Quantity = 1,
                   CountryCode = CountryCode.ALL
               });

            modelBuilder.Entity<MeasurementUnit>().HasData(
               new MeasurementUnit()
               {
                   Id = 14,
                   Title = "Bunch",
                   MeasurementType = MeasurementType.Item,
                   ShortName = "bch",
                   AltShortName = null,
                   ConvertsToId = 9,
                   Quantity = 1,
                   CountryCode = CountryCode.ALL
               });
            modelBuilder.Entity<MeasurementUnit>().HasData(
           new MeasurementUnit()
           {
               Id = 15,
               Title = "Pieces",
               MeasurementType = MeasurementType.Item,
               ShortName = "piece",
               AltShortName = null,
               ConvertsToId = 9,
               Quantity = 1,
               CountryCode = CountryCode.ALL
           });

            // Allergy Warnings
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 1,
                    Title = "Gluten"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 2,
                    Title = "Lactose"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 3,
                    Title = "Shellfish"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 4,
                    Title = "Fish and Seafood"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 5,
                    Title = "Almonds and other Tree Nuts"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 6,
                    Title = "Sesame"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 7,
                    Title = "Soy"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 8,
                    Title = "Eggs"
                });
            modelBuilder.Entity<AllergyWarning>().HasData(
                new AllergyWarning()
                {
                    Id = 9,
                    Title = "Peanuts"
                });

            // Cuisine Types
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 1,
                    Title = "Chinese"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 2,
                    Title = "Mexican"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 3,
                    Title = "Italian"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 4,
                    Title = "Greek"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 5,
                    Title = "Japanese"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 6,
                    Title = "French"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 7,
                    Title = "Thai"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 8,
                    Title = "Spanish"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 9,
                    Title = "Indian"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 10,
                    Title = "Mediterranean"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 11,
                    Title = "South American"
                });
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType()
                {
                    Id = 12,
                    Title = "Latin American"
                });


            // Dish Tags
            modelBuilder.Entity<DishTag>().HasData(
                new DishTag()
                {
                    Id = 1,
                    Title = "Very Healthy",
                    AltTitle = "veryHealthy"
                });
            modelBuilder.Entity<DishTag>().HasData(
                new DishTag()
                {
                    Id = 2,
                    Title = "Cheap",
                    AltTitle = "cheap"
                });
            modelBuilder.Entity<DishTag>().HasData(
                new DishTag()
                {
                    Id = 3,
                    Title = "Very Popular",
                    AltTitle = "veryPopular"
                });
            modelBuilder.Entity<DishTag>().HasData(
                new DishTag()
                {
                    Id = 4,
                    Title = "Sustainable",
                    AltTitle = "sustainable"
                });
            modelBuilder.Entity<DishTag>().HasData(
                new DishTag()
                {
                    Id = 5,
                    Title = "Complicated",
                    AltTitle = "complicated"
                });

            // DishTypes
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 1,
                    Title = "Breakfast"
                });
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 2,
                    Title = "Lunch"
                });
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 3,
                    Title = "Dinner"
                });
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 4,
                    Title = "Dessert"
                });
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 5,
                    Title = "Snack"
                });
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 6,
                    Title = "Salad"
                });
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 7,
                    Title = "Main Course",
                    AltTitle = "mainCourse"
                });
            modelBuilder.Entity<DishType>().HasData(
                new DishType()
                {
                    Id = 8,
                    Title = "Main Dish",
                    AltTitle = "mainDish"
                });
            // Equipment
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment() { Id = 1, Title = "Frying pan", AltTitle = "Skillet", OnlineId = 464645 },
                new Equipment() { Id = 2, Title = "Oven", AltTitle = "oven", OnlineId = 464784 },
                new Equipment() { Id = 3, Title = "Bowl", AltTitle = "bowl", OnlineId = 404783 }
                );
            // Health Labels
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 1,
                    Title = "Lacto-ovo Vegetarian",
                    AltTitle = "vegetarian",
                    Summary = "A vegetarian diet focuses on plants for food. These include fruits, vegetables," +
                    "dried beans and peas, grains, seeds and nuts. Includes both diary products and eggs."
                });
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 2,
                    Title = "Lacto Vegetarian",
                    Summary = "A vegetarian diet focuses on plants for food. These include fruits, vegetables," +
                    "dried beans and peas, grains, seeds and nuts. Includes both diary products."
                });
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 3,
                    Title = "Vegan",
                    AltTitle = "vegan",
                    Summary = "A vegetarian diet focuses on plants for food. These include fruits, vegetables," +
                    "dried beans and peas, grains, seeds and nuts. Specifically excludes all meat and animal products."
                });
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 4,
                    Title = "Gluten Free",
                    AltTitle = "glutenFree",
                    Summary = "On a gluten-free diet, you do not eat wheat, rye, and barley. These foods contain gluten, " +
                    "a type of protein. A gluten-free diet is the main treatment for celiac disease."
                });
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 5,
                    Title = "Dairy Free",
                    AltTitle = "dairyFree",
                    Summary = "A diet that excludes all lactose based products, generally cows milk, cheeses and yoghurts. A Dairy Free diet is generally used by people with Lactose Intolerance."
                });
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 6,
                    Title = "Low FODMAP",
                    AltTitle = "lowFodmap",
                    Summary = "FODMAP stands for Fermentable Oligosaccharides, Disaccharides, Monosaccharides, and Polyols, which are short chain carbohydrates and sugar alcohols that are poorly absorbed by the body, resulting in abdominal pain and bloating."
                });
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 7,
                    Title = "Keto",
                    AltTitle = "ketogenic",
                    Summary = "Keto is a very low-carb diet with less than 20g of carbohydrates per day. Substituting fats and oils for carbs."
                });
            modelBuilder.Entity<HealthLabel>().HasData(
                new HealthLabel()
                {
                    Id = 8,
                    Title = "Whole 30",
                    AltTitle = "whole30",
                    Summary = "The Whole30 is a 30-day fad diet that emphasizes whole foods and the elimination of sugar, alcohol, grains, legumes, soy, and dairy. The Whole30 is similar to but more restrictive than the paleo diet, as adherents may not eat natural sweeteners like honey or maple syrup."
                });

            // Parent Type
            modelBuilder.Entity<IngredientFoodGroup>().HasData(
                new IngredientFoodGroup() { Id = 1, Title = "American Indian" },
                new IngredientFoodGroup() { Id = 2, Title = "Baby Foods" },
                new IngredientFoodGroup() { Id = 3, Title = "Baked Foods" },
                new IngredientFoodGroup() { Id = 4, Title = "Beans and Lentils" },
                new IngredientFoodGroup() { Id = 5, Title = "Beverages" },
                new IngredientFoodGroup() { Id = 6, Title = "Breakfast Cereals" },
                new IngredientFoodGroup() { Id = 7, Title = "Dairy and Egg Products" },
                new IngredientFoodGroup() { Id = 8, Title = "Fast Foods" },
                new IngredientFoodGroup() { Id = 9, Title = "Fats and Oils", AltTitle = "Oil, Vinegar, Salad Dressing" },
                new IngredientFoodGroup() { Id = 10, Title = "Fish" },
                new IngredientFoodGroup() { Id = 11, Title = "Fruits" },
                new IngredientFoodGroup() { Id = 12, Title = "Grains and Pasta", AltTitle = "Pasta and Rice" },
                new IngredientFoodGroup() { Id = 13, Title = "Meats", AltTitle = "Meat" },
                new IngredientFoodGroup() { Id = 14, Title = "NULL" },
                new IngredientFoodGroup() { Id = 15, Title = "Nuts and Seeds" },
                new IngredientFoodGroup() { Id = 16, Title = "Prepared Meals" },
                new IngredientFoodGroup() { Id = 17, Title = "Restaurant Foods" },
                new IngredientFoodGroup() { Id = 18, Title = "Snacks" },
                new IngredientFoodGroup() { Id = 19, Title = "Soups and Sauces", AltTitle = "Condiments" },
                new IngredientFoodGroup() { Id = 20, Title = "Spices and Herbs", AltTitle = "Spices and Seasonings" },
                new IngredientFoodGroup() { Id = 21, Title = "Sweets" },
                new IngredientFoodGroup() { Id = 22, Title = "Vegetables", AltTitle = "Produce" }
            );

            // Ingredient State
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 1,
                    Title = "Chopped"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 2,
                    Title = "Sliced"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 3,
                    Title = "Diced"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 4,
                    Title = "Shredded"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 5,
                    Title = "Whole"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 6,
                    Title = "Firmly Packed"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 7,
                    Title = "Loose"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 8,
                    Title = "Ground"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 9,
                    Title = "Boiling"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 10,
                    Title = "Solid"
                });
            modelBuilder.Entity<IngredientState>().HasData(
                new IngredientState()
                {
                    Id = 11,
                    Title = "Liquid"
                });

            // LogLevel
            modelBuilder.Entity<LogLevel>().HasData(
                          new LogLevel
                          {
                              Id = 1,
                              SortOrder = 6,
                              Title = "Trace"
                          },
                          new LogLevel
                          {
                              Id = 2,
                              SortOrder = 5,
                              Title = "Debug"
                          },
                          new LogLevel
                          {
                              Id = 3,
                              SortOrder = 4,
                              Title = "Information"
                          },
                          new LogLevel
                          {
                              Id = 4,
                              SortOrder = 3,
                              Title = "Warning"
                          },
                          new LogLevel
                          {
                              Id = 5,
                              SortOrder = 2,
                              Title = "Error"
                          },
                          new LogLevel
                          {
                              Id = 6,
                              SortOrder = 1,
                              Title = "Critical"
                          });


            //modelBuilder.Entity<Ingredient>().HasData(
            //	new Ingredient()
            //	{
            //		Id = 1,
            //		Name = "Wholemeal Flour",
            //		PurchasedBy = MeasurementType.Weight,
            //		Protein = 5,
            //		Carbohydrate = 95,
            //		Fat = 0,
            //		Water = 0,
            //		PriceBrandName = "Black and Gold",
            //		PriceDollar = 1.99m,
            //		PriceQuantity = 1,
            //		PriceMeasurement = MeasurementType.Weight,
            //		PriceStoreName = "Woolworth",
            //		FoodGroupId = 4,
            //		IngredientStateId = 8
            //	});
            //modelBuilder.Entity<Ingredient>().HasData(
            //  new Ingredient()
            //  {
            //	  Id = 2,
            //	  Name = "Baby Spinach Leaves",
            //	  PurchasedBy = MeasurementType.Weight,
            //	  Protein = 30,
            //	  Carbohydrate = 11,
            //	  Fat = 49,
            //	  Water = 15,
            //	  PriceBrandName = "Farmers produce",
            //	  PriceDollar = 5.00m,
            //	  PriceQuantity = 400,
            //	  PriceMeasurement = MeasurementType.Weight,
            //	  PriceStoreName = "Woolworth",
            //	  FoodGroupId = 4,
            //	  IngredientStateId = 8
            //  });

            //modelBuilder.Entity<IngredientAllergyWarning>().HasData(
            //	new IngredientAllergyWarning()
            //	{
            //		Id = 1,
            //		IngredientId = 1,
            //		AllergyWarningId = 1
            //	});

            //modelBuilder.Entity<IngredientConversion>().HasData(
            //	new IngredientConversion()
            //	{
            //		Id = 1,
            //		IngredientId = 1,
            //		BaseStateId = 6,
            //		BaseMeasurementUnitId = 1,
            //		BaseQuantity = 1,
            //		ConvertToStateId = 6,
            //		ConvertToMeasurementUnitId = 2,
            //		ConvertToQuantity = 120,
            //	});

            modelBuilder.Entity<School>().HasData(
                new School()
                {
                    Id = 1,
                    Code = "NAS",
                    Title = "Not a School",
                });
            modelBuilder.Entity<School>().HasData(
                new School()
                {
                    Id = 2,
                    Code = "DEFAULT",
                    Title = "Default School",
                    Suburb = "Australia",
                    PostCode = "0000",
                });
            modelBuilder.Entity<School>().HasData(
                new School()
                {
                    Id = 3,
                    Code = "HCC2020",
                    Title = "Holy Cross College",
                    ShortName = "HCC",
                    Address = "18 Strathmore Parkway",
                    Suburb = "Ellenbrook",
                    PostCode = "6030",
                    BusinessContactName = "Paul Murphy",
                    EmailAddress = "paul.murphy@hcc.wa.edu.au"
                });
        }
    }
}
