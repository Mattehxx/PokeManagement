using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangePersonalizationLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personalizations_Ingredients_IngredientId",
                table: "Personalizations");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Personalizations",
                newName: "DefaultPersonalizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Personalizations_IngredientId",
                table: "Personalizations",
                newName: "IX_Personalizations_DefaultPersonalizationId");

            migrationBuilder.CreateTable(
                name: "DefaultPersonalizations",
                columns: table => new
                {
                    DefaultPersonalizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    MaxAllowed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultPersonalizations", x => x.DefaultPersonalizationId);
                    table.ForeignKey(
                        name: "FK_DefaultPersonalizations_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultPersonalizations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPersonalizations_IngredientId",
                table: "DefaultPersonalizations",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPersonalizations_ProductId",
                table: "DefaultPersonalizations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personalizations_DefaultPersonalizations_DefaultPersonalizationId",
                table: "Personalizations",
                column: "DefaultPersonalizationId",
                principalTable: "DefaultPersonalizations",
                principalColumn: "DefaultPersonalizationId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personalizations_DefaultPersonalizations_DefaultPersonalizationId",
                table: "Personalizations");

            migrationBuilder.DropTable(
                name: "DefaultPersonalizations");

            migrationBuilder.RenameColumn(
                name: "DefaultPersonalizationId",
                table: "Personalizations",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_Personalizations_DefaultPersonalizationId",
                table: "Personalizations",
                newName: "IX_Personalizations_IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personalizations_Ingredients_IngredientId",
                table: "Personalizations",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
