using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDefaultPersonalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personalizations_DefaultPersonalizations_DefaultPersonalizationId",
                table: "Personalizations");

            migrationBuilder.DropTable(
                name: "DefaultPersonalizations");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Personalizations",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DefaultPersonalizationId",
                table: "Personalizations",
                newName: "ProductIngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_Personalizations_DefaultPersonalizationId",
                table: "Personalizations",
                newName: "IX_Personalizations_ProductIngredientId");

            migrationBuilder.AddColumn<bool>(
                name: "IsIncluded",
                table: "ProductIngredients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxAllowed",
                table: "ProductIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Personalizations_ProductIngredients_ProductIngredientId",
                table: "Personalizations",
                column: "ProductIngredientId",
                principalTable: "ProductIngredients",
                principalColumn: "ProductIngredientId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personalizations_ProductIngredients_ProductIngredientId",
                table: "Personalizations");

            migrationBuilder.DropColumn(
                name: "IsIncluded",
                table: "ProductIngredients");

            migrationBuilder.DropColumn(
                name: "MaxAllowed",
                table: "ProductIngredients");

            migrationBuilder.RenameColumn(
                name: "ProductIngredientId",
                table: "Personalizations",
                newName: "DefaultPersonalizationId");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Personalizations",
                newName: "IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Personalizations_ProductIngredientId",
                table: "Personalizations",
                newName: "IX_Personalizations_DefaultPersonalizationId");

            migrationBuilder.CreateTable(
                name: "DefaultPersonalizations",
                columns: table => new
                {
                    DefaultPersonalizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
