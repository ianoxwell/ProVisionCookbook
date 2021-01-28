using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class EquipmentRefDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeSteppedInstructionId",
                schema: "dbo",
                table: "RecipeIngredientList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "ref",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rw75abeYG/CNFdjBqDrDquEh2ggQNrFgHtxpPC3n3IRATyB01sUC6");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientList_RecipeSteppedInstructionId",
                schema: "dbo",
                table: "RecipeIngredientList",
                column: "RecipeSteppedInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRecipeSteppedInstruction_RecipeSteppedInstructionId",
                table: "EquipmentRecipeSteppedInstruction",
                column: "RecipeSteppedInstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredientList_RecipeSteppedInstruction_RecipeSteppedInstructionId",
                schema: "dbo",
                table: "RecipeIngredientList",
                column: "RecipeSteppedInstructionId",
                principalSchema: "dbo",
                principalTable: "RecipeSteppedInstruction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredientList_RecipeSteppedInstruction_RecipeSteppedInstructionId",
                schema: "dbo",
                table: "RecipeIngredientList");

            migrationBuilder.DropTable(
                name: "EquipmentRecipeSteppedInstruction");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "ref");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredientList_RecipeSteppedInstructionId",
                schema: "dbo",
                table: "RecipeIngredientList");

            migrationBuilder.DropColumn(
                name: "RecipeSteppedInstructionId",
                schema: "dbo",
                table: "RecipeIngredientList");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XaXlI07k/IZTCijnq.qh4eAxWTZc50.UF1isNFcye6wOzI4Kf3gfC");
        }
    }
}
